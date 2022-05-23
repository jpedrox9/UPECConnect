using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using UPECLogic.Classes.Aplicacao;
using UPECLogic.Repositorio;
using UPWebPrestaShop.Models;
using UPID.WEBSERVICE.Sage;
using Newtonsoft.Json;

namespace UPECConnectService
{
    public partial class UPEcc : ServiceBase
    {
        public UPEcc()
        {
            InitializeComponent();
        }

        public static Timer timer;

        protected override void OnStart(string[] args)
        {
            Library.WriteErrorLog("O serviço começou a funcionar!");
            CheckConfig(LerConfiguracoes().EmpresaId);
            System.Threading.Thread.Sleep(1000);

            timer = new Timer();
            timer.Interval = LerConfiguracoes().TempoArranque * 60000;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
            Library.WriteErrorLog("O serviço parou de funcionar!");
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            timer.Enabled = false;
            Library.WriteErrorLog("O serviço começou a sincronização!");
            CheckConfig(LerConfiguracoes().EmpresaId);
            System.Threading.Thread.Sleep(1000);

            timer.Interval = LerConfiguracoes().TempoArranque * 60000;

            Working();
            Library.WriteErrorLog("O serviço realizou a sincronização com sucesso!");
            timer.Enabled = true;
        }


        public void Working()
        {
            var config = LerConfiguracoes();
            var connectionString = GetConnectionString();
            var configWeb = LerConfiguracoesWeb();

            using (UPWebPrestashop.Services.ArtigosService web = new UPWebPrestashop.Services.ArtigosService(config.Dados.DadosSite.URL, config.Dados.DadosSite.Token))
            {
                web.AtualizarArtigos(configWeb, connectionString);
            }
            Library.WriteErrorLog("artigos");

            using (UPWebPrestashop.Services.StockService web = new UPWebPrestashop.Services.StockService(config.Dados.DadosSite.URL, config.Dados.DadosSite.Token))
            {
                web.AtualizarStock(configWeb, connectionString);
            }
            Library.WriteErrorLog("stock");

            using (UPWebPrestashop.Services.ImagensService web = new UPWebPrestashop.Services.ImagensService(config.Dados.DadosSite.URL, config.Dados.DadosSite.Token))
            {
                web.AtualizarImagens(configWeb, connectionString);
            }
            Library.WriteErrorLog("imagens");

            using (UPWebPrestashop.Services.ClientesService web = new UPWebPrestashop.Services.ClientesService(config.Dados.DadosSite.URL, config.Dados.DadosSite.Token))
            {
                web.AtualizarClientes(configWeb, connectionString);
            }
            Library.WriteErrorLog("clientes");

            AtualizarEncomendas(config, connectionString);
            Library.WriteErrorLog("encomendas");

            RegistarLogs(config);
            Library.WriteErrorLog("logs");
        }

        public async void CheckConfig(string empresaId)
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            var client = new HttpClient(handler);
            HttpResponseMessage response = await client.GetAsync("https://localhost:44300/api/Service?id=" + empresaId);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var config = Config.Converter(JsonConvert.DeserializeObject<Config>(responseBody));

            if (config.EmpresaId == "0")
            {
                Library.WriteErrorLog("A Empresa não existe.");
                Stop();
            }

            ConfigApp configOld = LerConfiguracoes();
            if (!ConfigApp.Compare(config, configOld))
            {
                string sFicheiroConfig;
                if (PastaSoftware().EndsWith(@"\")) sFicheiroConfig = PastaSoftware() + "config.json";
                else sFicheiroConfig = PastaSoftware() + @"\config.json";
                string sConfig = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(sFicheiroConfig, sConfig);
            }
        }

        public string GetConnectionString()
        {
            var config = LerConfiguracoes();
            SqlConnectionStringBuilder sSqlConnection = new SqlConnectionStringBuilder()
            {
                UserID = config.Dados.DadosERP.Utilizador,
                Password = config.Dados.DadosERP.Password,
                DataSource = config.Dados.DadosERP.Servidor,
                InitialCatalog = config.Dados.DadosERP.BaseDados,
                ApplicationName = "UPECConnect"
            };
            string connectionString = sSqlConnection.ToString();
            return connectionString;
        }

        public ConfigApp LerConfiguracoes()
        {
            string sFicheiroConfig;
            if (PastaSoftware().EndsWith(@"\")) sFicheiroConfig = PastaSoftware() + "config.json";
            else sFicheiroConfig = PastaSoftware() + @"\config.json";
            ConfigApp ConfigApp = null;
            if (File.Exists(sFicheiroConfig))
            {
                try
                {
                    var sFileContent = File.ReadAllText(sFicheiroConfig);
                    ConfigApp = JsonConvert.DeserializeObject<ConfigApp>(sFileContent);
                }
                catch
                {
                    ConfigApp = null;
                }
            }
            return ConfigApp;
        }

        public UPWebPrestaShop.ConfigApp LerConfiguracoesWeb()
        {
            string sFicheiroConfig;
            if (PastaSoftware().EndsWith(@"\")) sFicheiroConfig = PastaSoftware() + "config.json";
            else sFicheiroConfig = PastaSoftware() + @"\config.json";
            UPWebPrestaShop.ConfigApp ConfigApp = null;
            if (File.Exists(sFicheiroConfig))
            {
                try
                {
                    var sFileContent = File.ReadAllText(sFicheiroConfig);
                    ConfigApp = JsonConvert.DeserializeObject<UPWebPrestaShop.ConfigApp>(sFileContent);
                }
                catch
                {
                    ConfigApp = null;
                }
            }
            return ConfigApp;
        }

        public string PastaSoftware()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public void AtualizarEncomendas(ConfigApp config, string connectionString)
        {
            var web = new UPWebPrestashop.Services.EncomendasService(config.Dados.DadosSite.URL, config.Dados.DadosSite.Token);
            var encomendas = web.ListaEncomendas();

            using (Documentos ws = new Documentos(config.Dados.DadosERP.WebService))
            {
                Documentos.Resultado res = new Documentos.Resultado();
                foreach (var encomenda in encomendas)
                {
                    var linhas = new List<Documentos.Linhas>();
                    foreach (var row in encomenda.associations.order_rows)
                    {
                        var armazem = new StockRepositorio(connectionString, eTipoBD.SQL).LerArmazem(row.product_reference);
                        var linha = new Documentos.Linhas()
                        {
                            MovimentoStock = Documentos.eMovimentoStock.Entradas,
                            Artigo = row.product_reference,
                            Armazem = armazem,
                            Quantidade = decimal.Parse(row.product_quantity),
                            TaxaIva = decimal.Parse(encomenda.carrier_tax_rate.Replace(".", ",")),
                            TipoLinha = Documentos.eTipoLinha.Movimento,
                            PrecoUnit = decimal.Parse(row.product_price.Replace(".", ","))
                        };
                        linhas.Add(linha);
                    }

                    var morada = web.LerMorada(encomenda.id_address_delivery);
                    string contribuinte = "";
                    if (morada.vat_number != "") contribuinte = morada.vat_number.Remove(0, 2);
                    var dadosTerceiro = new Documentos.DadosTerceiro()
                    {
                        CodigoPostal = morada.postcode,
                        Contribuinte = contribuinte,
                        Localidade = morada.city,
                        MeioPagamento = encomenda.payment,
                        Morada = morada.address1,
                        Morada2 = morada.address2,
                        Nome = morada.firstname + morada.lastname
                    };

                    var cliente = new ClientesRepositorio(connectionString, eTipoBD.SQL).LerCodigo(encomenda.id_customer);
                    var documento = new Documentos.DadosDocumento()
                    {
                        Linhas = linhas,
                        DadosTerceiro = dadosTerceiro,
                        Terceiro = cliente,
                        TipoDoc = config.Dados.DadosDoc.TipoDoc,
                        Serie = config.Dados.DadosDoc.Serie,
                        Sector = config.Dados.DadosDoc.Setor,
                        Data = DateTime.Parse(encomenda.date_add),
                        Moeda = web.LerMoeda(encomenda.id_currency),
                        NumeroDoc = encomenda.id
                    };

                    var db = new EncomendasRepositorio(connectionString, eTipoBD.SQL);
                    var documentos = db.LerEncomendas();
                    int check = 0;
                    foreach (var doc in documentos)
                    {
                        if (doc.NumeroDoc == encomenda.id) check = 1;
                    }
                    if (check != 1)
                    {
                        res = ws.Inserir(ref documento);
                        CreateLog(config.Logs_Path, encomenda.id.ToString(), connectionString, res);
                    }
                }
            }
        }
        public void CreateLog(string localizacao, string id, string connectionString, Documentos.Resultado res)
        {
            DirectoryInfo pasta = new DirectoryInfo(localizacao);
            FileInfo[] logs = pasta.GetFiles();
            string nome = (logs.Count() + 1).ToString();

            string descricao = "Sucesso";
            string numero = id;

            if (res.Gravou == false)
            { 
                descricao = "Erro! " + res.UltimaMensagem;
                numero = "-";
            }
            var log = new Logs()
            {
                Sincronizado = "Encomenda",
                Codigo_BD = numero,
                Codigo_Site = id,
                Data = DateTime.Now,
                Descricao = descricao
            };

            string texto = JsonConvert.SerializeObject(log, Formatting.Indented);

            using (FileStream fs = File.Create(localizacao + @"\" + nome + ".json"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(texto);
                fs.Write(info, 0, info.Length);
            }
        }

        public async void RegistarLogs(ConfigApp config)
        {
            DirectoryInfo pasta = new DirectoryInfo(config.Logs_Path);
            FileInfo[] logs = pasta.GetFiles();
            for (int i = 1; i <= logs.Count(); i++)
            {
                string path = config.Logs_Path + @"\" + i + ".json";
                string file = File.ReadAllText(path);
                var log = JsonConvert.DeserializeObject<Logs>(file);
                log.EmpresaId = int.Parse(config.EmpresaId);
                var handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                var client = new HttpClient(handler);

                JsonSerializerSettings sSettings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                };
                string content = JsonConvert.SerializeObject(log, sSettings);

                HttpResponseMessage response = await client.PostAsync("https://localhost:44300/api/Service", new StringContent(content, Encoding.UTF8, "application/json"));
                File.Delete(path);
            }
        }
    }
}

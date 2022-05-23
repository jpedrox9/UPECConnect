using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UPECLogic.Repositorio;
using UPECLogic.Classes.Aplicacao;
using UPECLogic.Model;
using UPECConnectService;
using System.IO;
using System.Drawing;
using System.Web;
using UPWebPrestaShop.Models.Encomenda;
using UPWebPrestaShop.Models;
using System.Net.Http;
using System.Collections;

namespace TESTES1
{
    class Program
    {
        public static void Main(string[] args)
        {
            //var servico = new UPEcc();
            //var connectionString = servico.GetConnectionString();
            //var config = servico.LerConfiguracoes();
            //var configWeb = servico.LerConfiguracoesWeb();


            //var servico1 = new UPEcc();
            //servico1.CheckConfig("2007");
            //servico1.Working();
            //servico1.LerConfiguracoes();

            //using (UPWebPrestashop.Services.ArtigosService web = new UPWebPrestashop.Services.ArtigosService(config.Dados.DadosSite.URL, config.Dados.DadosSite.Token))
            //{
            //    web.AtualizarArtigos(configWeb, connectionString);
            //}

            //using (UPWebPrestashop.Services.StockService web = new UPWebPrestashop.Services.StockService(config.Dados.DadosSite.URL, config.Dados.DadosSite.Token))
            //{
            //    web.AtualizarStock(configWeb, connectionString);
            //}

            //using (UPWebPrestashop.Services.ImagensService web = new UPWebPrestashop.Services.ImagensService(config.Dados.DadosSite.URL, config.Dados.DadosSite.Token))
            //{
            //    web.AtualizarImagens(configWeb, connectionString);
            //}

            //using (UPWebPrestashop.Services.ClientesService web = new UPWebPrestashop.Services.ClientesService(config.Dados.DadosSite.URL, config.Dados.DadosSite.Token))
            //{
            //    web.AtualizarClientes(configWeb, connectionString);
            //}

            //using (UPWebPrestashop.Services.FornecedoresService web = new UPWebPrestashop.Services.FornecedoresService(config.Dados.DadosSite.URL, config.Dados.DadosSite.Token))
            //{
            //    var coiso = web.ListaFornecedores();
            //    web.AtualizarFornecedores(configWeb, connectionString);
            //}

            //    Order encomenda;

            //    var db = new UPWebPrestashop.Services.EncomendasService(config.Dados.DadosSite.URL, config.Dados.DadosSite.Token);
            //    var teste = db.ListaEncomendas();
            //    var c = teste;
            //    var test = db.LerEncomenda("93");
            //    encomenda = test;

            //    using (UPID.WEBSERVICE.Sage.Documentos ws = new UPID.WEBSERVICE.Sage.Documentos(config.Dados.DadosERP.WebService))
            //    {
            //        var linhas = new List<UPID.WEBSERVICE.Sage.Documentos.Linhas>();
            //        foreach (var row in encomenda.associations.order_rows)
            //        {
            //            var armazem = new StockRepositorio(connectionString, eTipoBD.SQL).LerArmazem(row.product_reference);
            //            var linha = new UPID.WEBSERVICE.Sage.Documentos.Linhas()
            //            {
            //                MovimentoStock = UPID.WEBSERVICE.Sage.Documentos.eMovimentoStock.Entradas,
            //                Artigo = row.product_reference,
            //                Armazem = armazem,
            //                Quantidade = Decimal.Parse(row.product_quantity),
            //                TaxaIva = Decimal.Parse(encomenda.carrier_tax_rate.Replace(".", ",")),
            //                TipoLinha = UPID.WEBSERVICE.Sage.Documentos.eTipoLinha.Movimento,
            //                PrecoUnit = Decimal.Parse(row.product_price.Replace(".", ","))
            //            };
            //            linhas.Add(linha);
            //        }

            //        var morada = db.LerMorada(encomenda.id_address_delivery);
            //        string contribuinte = "";
            //        if (morada.vat_number != "") contribuinte = morada.vat_number.Remove(0, 2);
            //        var dadosTerceiro = new UPID.WEBSERVICE.Sage.Documentos.DadosTerceiro()
            //        {
            //            CodigoPostal = morada.postcode,
            //            Contribuinte = contribuinte,
            //            Localidade = morada.city,
            //            MeioPagamento = encomenda.payment,
            //            Morada = morada.address1,
            //            Morada2 = morada.address2,
            //            Nome = morada.firstname + morada.lastname
            //        };

            //        var cliente = new ClientesRepositorio(connectionString, eTipoBD.SQL).LerCodigo(encomenda.id_customer);
            //        var documento = new UPID.WEBSERVICE.Sage.Documentos.DadosDocumento()
            //        {
            //            Linhas = linhas,
            //            DadosTerceiro = dadosTerceiro,
            //            Terceiro = cliente,
            //            TipoDoc = config.Dados.DadosDoc.TipoDoc,
            //            Serie = config.Dados.DadosDoc.Serie,
            //            Sector = config.Dados.DadosDoc.Setor,
            //            Data = DateTime.Parse(encomenda.date_add),
            //            Moeda = db.LerMoeda(encomenda.id_currency)
            //        };
            //        var res = ws.Inserir(ref documento);
            //        CreateLog(config.Logs_Path, encomenda.id.ToString(), connectionString, res);
            //    }
            //}

            //public static void CreateLog(string localizacao, string id, string connectionString, UPID.WEBSERVICE.Sage.Documentos.Resultado res)
            //{
            //    DirectoryInfo pasta = new DirectoryInfo(localizacao);
            //    FileInfo[] logs = pasta.GetFiles();
            //    string nome = (logs.Count() + 1).ToString();

            //    var encomendas = new EncomendasRepositorio(connectionString, eTipoBD.SQL).LerEncomendas();
            //    string numero = encomendas[encomendas.Count() - 1].NumeroDoc.ToString();

            //    string descricao = "Sucesso";
            //    if (res.Gravou == false) descricao = "Erro! " + res.UltimaMensagem;
            //    var log = new Logs()
            //    {
            //        Sincronizado = "Encomenda",
            //        Codigo_BD = numero,
            //        Codigo_Site = id,
            //        Data = DateTime.Now,
            //        Descricao = descricao
            //    };

            //    string texto = Newtonsoft.Json.JsonConvert.SerializeObject(log, Newtonsoft.Json.Formatting.Indented);

            //    using (FileStream fs = File.Create(localizacao + @"\" + nome + ".json"))
            //    {
            //        byte[] info = new UTF8Encoding(true).GetBytes(texto);
            //        fs.Write(info, 0, info.Length);
            //    }
        }
    }
}

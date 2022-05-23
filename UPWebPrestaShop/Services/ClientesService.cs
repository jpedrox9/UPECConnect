using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPWebPrestashop.Models;
using UPID.Extensoes.File;
using UPECLogic.Model;
using UPECLogic.Repositorio;
using static UPWebPrestaShop.Models.ClientesXML;
using static UPWebPrestaShop.Models.ClientesJSON;
using System.IO;
using UPWebPrestaShop.Models;
using UPWebPrestaShop;

namespace UPWebPrestashop.Services
{
    public class ClientesService : Base
    {
        private readonly string _site;
        private readonly URLParameters _key;
        public ClientesService(string Site, string Key) : base(Site, Key)
        {
            _site = Site;
            _key = new URLParameters()
            {
                Propriedade = "ws_key",
                Valor = Key
            };
        }

        private string URL = "customers";

        private prestashopCl ToWeb(Clientes Data)
        {
            if (Data.Email == "") Data.Email = "sem@email.com";
            if (Data.Nome2 == "") Data.Nome2 = "lastname";

            prestashopCustomer costumer = new prestashopCustomer()
            {
                id_lang = "2",
                passwd = Data.Telefone,
                firstname = Data.Nome,
                lastname = Data.Nome2,
                email = Data.Email,
                website = Data.Site,
                active = "1",
                id_shop = "1",
                id_shop_group = "1",
            };

            prestashopCl cliente = new prestashopCl()
            {
                customer = costumer
            };

            return cliente;
        }

        public void AtualizarClientes(ConfigApp config, string connectionString)
        {
            var db = new ClientesRepositorio(connectionString, UPECLogic.Classes.Aplicacao.eTipoBD.SQL);
            var clientes = db.LerClientes();
            var clientesSite = ListaClientes();
            foreach (Clientes cliente in clientes)
            {
                var check = 0;
                string id = GetId(cliente.Codigo, connectionString);
                foreach (var cl in clientesSite)
                {
                    if (cl.id == id) check = 1;
                }
                if (check == 0 && cliente.Codigo != "")
                {
                    var sres = InserirCliente(cliente);
                    var dados = ListaClientes()[ListaClientes().Count - 1];
                    db.InserirCodigo(cliente.Codigo, dados.id);
                    CreateLog(config.Logs_Path, cliente.Codigo, dados.id, sres);
                }
                if (check == 1)
                {
                    var dados = ListaClientes()[ListaClientes().Count - 1];
                    var sres = AlterarCliente(cliente, dados);
                    var tes = sres;
                }
            }
        }

        public async Task<ClientesResponse> ListaClientesAsync()
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);
            Parametros.Add(new URLParameters
            {
                Propriedade = "display",
                Valor = "full"
            });

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.GetAsync(GetURL(URL, Parametros)))
            {
                ClientesResponse sResult = await RestResponse.GetContent<ClientesResponse>();
                return sResult;
            }

        }
        public List<Customer> ListaClientes()
        {
            var st = Task.Run(async () =>
            {
                return await ListaClientesAsync();
            });
            st.Wait();
            return st.Result.Clientes;
        }


        public async Task<ClientesResponse> LerClienteAsync(string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.GetAsync(GetURL(URL, id, Parametros)))
            {
                ClientesResponse sresult = await RestResponse.GetContent<ClientesResponse>();
                return sresult;
            }
        }
        public Customer LerCliente(string id)
        {
            var st = Task.Run(async () =>
            {
                return await LerClienteAsync(id);
            });
            st.Wait();
            if(st.Result != null) return st.Result.Cliente;
            return null;
        }


        public async Task<Resultado> InserirClienteAsync(Clientes Dados)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            prestashopCl sCliente = ToWeb(Dados);
            Resultado sResultado = new Resultado();

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.PostAsync(GetURL(URL, Parametros), sCliente.ToXML()))
            {
                try
                {
                    ClientesResponse sResult = await RestResponse.GetContent<ClientesResponse>();
                    sResultado.Sucesso = true;
                }
                catch (Exception ex)
                {
                    sResultado.Mensagem = ex.Message;
                    sResultado.Sucesso = false;
                }
            }
            return sResultado;
        }
        public Resultado InserirCliente(Clientes Dados)
        {
            var st = Task.Run(async () =>
            {
                return await InserirClienteAsync(Dados);
            });
            st.Wait();
            return st.Result;
        }


        public async Task<Resultado> AlterarClienteAsync(Clientes Dados, Customer dados)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            prestashopCl sCliente = ToWeb(Dados);
            sCliente.customer.id = dados.id;
            sCliente.customer.secure_key = dados.secure_key;
            Resultado sResultado = new Resultado();

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.PutAsync(GetURL(URL, Parametros), sCliente.ToXML()))
            {
                try
                {
                    ClientesResponse sResult = await RestResponse.GetContent<ClientesResponse>();
                    sResultado.Sucesso = true;
                }
                catch (Exception ex)
                {
                    sResultado.Mensagem = ex.Message;
                    sResultado.Sucesso = false;
                }
            }
            return sResultado;
        }
        public Resultado AlterarCliente(Clientes Dados, Customer dados)
        {
            var st = Task.Run(async () =>
            {
                return await AlterarClienteAsync(Dados, dados);
            });
            st.Wait();
            return st.Result;
        }


        public async Task<Resultado> ApagarClienteAsync(string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            Resultado sResultado = new Resultado();

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.DeleteAsync(GetURL(URL, id, Parametros)))
            {
                try
                {
                    ClientesResponse sResult = await RestResponse.GetContent<ClientesResponse>();
                    sResultado.Sucesso = true;
                }
                catch (Exception ex)
                {
                    sResultado.Mensagem = ex.Message;
                    sResultado.Sucesso = false;
                }
            }
            return sResultado;
        }
        public Resultado ApagarCliente(string id)
        {
            var st = Task.Run(async () =>
            {
                return await ApagarClienteAsync(id);
            });
            st.Wait();
            return st.Result;
        }


        public string GetId(string codigo, string connectionString)
        {
            var db = new ClientesRepositorio(connectionString, UPECLogic.Classes.Aplicacao.eTipoBD.SQL);
            var clientes = db.ListarCodigos();
            var clientesSite = ListaClientes();
            foreach (var cliente in clientes)
            {
                foreach (var cl in clientesSite)
                {
                    if (cliente.Codigo == codigo && cliente.Id == cl.id) return cliente.Id;
                }
            }
            return null;
        }

        public void CreateLog(string localizacao, string codigo, string id, Resultado res)
        {
            DirectoryInfo pasta = new DirectoryInfo(localizacao);
            FileInfo[] logs = pasta.GetFiles();
            string nome = (logs.Count() + 1).ToString();

            string descricao = "Sucesso";
            if (res.Sucesso == false) descricao = "Erro! " + res.Mensagem;
            var log = new Logs()
            {
                Sincronizado = "Cliente",
                Codigo_BD = codigo,
                Codigo_Site = id,
                Data = DateTime.Now,
                Descricao = descricao
            };

            string texto = Newtonsoft.Json.JsonConvert.SerializeObject(log, Newtonsoft.Json.Formatting.Indented);

            using (FileStream fs = File.Create(localizacao + @"\" + nome + ".json"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(texto);
                fs.Write(info, 0, info.Length);
            }
        }
    }
}

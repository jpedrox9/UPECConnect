using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPWebPrestashop.Models;
using UPID.Extensoes.File;
using UPECLogic.Model;
using UPECLogic.Repositorio;
using System.IO;
using UPWebPrestaShop.Models;
using UPWebPrestaShop;

namespace UPWebPrestashop.Services
{
    public class FornecedoresService : Base
    {
        private readonly string _site;
        private readonly URLParameters _key;
        public FornecedoresService(string Site, string Key) : base(Site, Key)
        {
            _site = Site;
            _key = new URLParameters()
            {
                Propriedade = "ws_key",
                Valor = Key
            };
        }

        private string URL = "customers";

        private prestashopSupp ToWeb(Fornecedores Data)
        {
            var languageMeta_description = new prestashopSupplierMeta_descriptionLanguage()
            {
                id = 2,
                Value = Data.Nome
            };
            var metaDescription = new prestashopSupplierMeta_description()
            {
                language = languageMeta_description
            };

            var languageMeta_keywords = new prestashopSupplierMeta_keywordsLanguage()
            {
                id = 2,
                Value = Data.Codigo
            };
            var metaKeywords = new prestashopSupplierMeta_keywords()
            {
                language = languageMeta_keywords
            };

            var languageMeta_title = new prestashopSupplierMeta_titleLanguage()
            {
                id = 2,
                Value = Data.Nome
            };
            var metaTitle = new prestashopSupplierMeta_title()
            {
                language = languageMeta_title
            };

            var languageDescription = new prestashopSupplierDescriptionLanguage()
            {
                id = 2,
                Value = Data.Nome
            };
            var description = new prestashopSupplierDescription()
            {
                language = languageDescription
            };

            prestashopSupplier supplier = new prestashopSupplier()
            {
                link_rewrite = Data.Nome,
                name = Data.Nome,
                active = "1",
                description = description,
                meta_description = metaDescription,
                meta_keywords = metaKeywords,
                meta_title = metaTitle
            };

            prestashopSupp fornecedor = new prestashopSupp()
            {
                supplier = supplier
            };

            return fornecedor;
        }

        public void AtualizarFornecedores(ConfigApp config, string connectionString)
        {
            var db = new FornecedoresRepositorio(connectionString, UPECLogic.Classes.Aplicacao.eTipoBD.SQL);
            var fornecedores = db.LerFornecedores();
            var fornecedoresSite = ListaFornecedores();
            foreach (Fornecedores fornecedor in fornecedores)
            {
                var check = 0;
                string id = GetId(fornecedor.Codigo, connectionString);
                foreach (var forn in fornecedoresSite)
                {
                    if (forn.id == id) check = 1;
                }
                if (check == 0 && fornecedor.Codigo != "")
                {
                    var sres = InserirFornecedor(fornecedor);
                    id = ListaFornecedores()[ListaFornecedores().Count - 1].id;
                    db.InserirCodigo(fornecedor.Codigo, id);
                    CreateLog(config.Logs_Path, fornecedor.Codigo, id, sres);
                }
                if (check == 1)
                {
                    AlterarFornecedor(fornecedor, id);
                }
            }
        }

        public async Task<FornecedoresResponse> ListaFornecedoresAsync()
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
                FornecedoresResponse sResult = await RestResponse.GetContent<FornecedoresResponse>();
                return sResult;
            }

        }
        public List<Supplier> ListaFornecedores()
        {
            var st = Task.Run(async () =>
            {
                return await ListaFornecedoresAsync();
            });
            st.Wait();
            return st.Result.suppliers;
        }


        public async Task<FornecedoresResponse> LerFornecedorAsync(string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.GetAsync(GetURL(URL, id, Parametros)))
            {
                FornecedoresResponse sresult = await RestResponse.GetContent<FornecedoresResponse>();
                return sresult;
            }
        }
        public Supplier LerFornecedor(string id)
        {
            var st = Task.Run(async () =>
            {
                return await LerFornecedorAsync(id);
            });
            st.Wait();
            if(st.Result != null) return st.Result.supplier;
            return null;
        }


        public async Task<Resultado> InserirFornecedorAsync(Fornecedores Dados)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            prestashopSupp sForn = ToWeb(Dados);
            Resultado sResultado = new Resultado();

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.PostAsync(GetURL(URL, Parametros), sForn.ToXML()))
            {
                try
                {
                    FornecedoresResponse sResult = await RestResponse.GetContent<FornecedoresResponse>();
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
        public Resultado InserirFornecedor(Fornecedores Dados)
        {
            var st = Task.Run(async () =>
            {
                return await InserirFornecedorAsync(Dados);
            });
            st.Wait();
            return st.Result;
        }


        public async Task<Resultado> AlterarFornecedorAsync(Fornecedores Dados, string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            prestashopSupp sForn = ToWeb(Dados);
            sForn.supplier.id = id;
            Resultado sResultado = new Resultado();

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.PutAsync(GetURL(URL, Parametros), sForn.ToXML()))
            {
                try
                {
                    FornecedoresResponse sResult = await RestResponse.GetContent<FornecedoresResponse>();
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
        public Resultado AlterarFornecedor(Fornecedores Dados, string id)
        {
            var st = Task.Run(async () =>
            {
                return await AlterarFornecedorAsync(Dados, id);
            });
            st.Wait();
            return st.Result;
        }


        public async Task<Resultado> ApagarFornecedorAsync(string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            Resultado sResultado = new Resultado();

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.DeleteAsync(GetURL(URL, id, Parametros)))
            {
                try
                {
                    FornecedoresResponse sResult = await RestResponse.GetContent<FornecedoresResponse>();
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
        public Resultado ApagarFornecedor(string id)
        {
            var st = Task.Run(async () =>
            {
                return await ApagarFornecedorAsync(id);
            });
            st.Wait();
            return st.Result;
        }


        public string GetId(string codigo, string connectionString)
        {
            var db = new FornecedoresRepositorio(connectionString, UPECLogic.Classes.Aplicacao.eTipoBD.SQL);
            var Fornecedores = db.LerCodigos();
            var fornecedoresSite = ListaFornecedores();
            foreach (var fornecedor in Fornecedores)
            {
                foreach (var forn in fornecedoresSite)
                {
                    if (fornecedor.Codigo == codigo && fornecedor.Id == forn.id) return fornecedor.Id;
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
                Sincronizado = "Fornecedor",
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

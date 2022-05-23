using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPWebPrestashop.Models;
using UPID.Extensoes.File;
using UPECLogic.Model;
using UPECLogic.Repositorio;
using UPWebPrestaShop.Models;
using UPWebPrestaShop;
using System.IO;
using System.Net.Http;

namespace UPWebPrestashop.Services
{
    public class ArtigosService : Base
    {
        private readonly string _site;
        private readonly URLParameters _key;
        public ArtigosService(string Site, string Key) : base(Site, Key)
        {
            _site = Site;
            _key = new URLParameters()
            {
                Propriedade = "ws_key",
                Valor = Key
            };
        }

        private string URL = "products";


        private prestashopART ToWeb(Artigos Data)
        {
            var metaDescription = new List<prestashopProductLanguage2>();
            metaDescription.Add(new prestashopProductLanguage2()
            {
                id = 2,
                Value = Data.Nome
            });
            var metaKeywords = new List<prestashopProductLanguage3>();
            metaKeywords.Add(new prestashopProductLanguage3()
            {
                id = 2,
                Value = Data.Codigo
            });
            var metaTitle = new List<prestashopProductLanguage4>();
            metaTitle.Add(new prestashopProductLanguage4()
            {
                id = 2,
                Value = Data.Nome
            });
            var link = new List<prestashopProductLanguage5>();
            link.Add(new prestashopProductLanguage5()
            {
                id = 2,
            });
            var name = new List<prestashopProductLanguage6>();
            name.Add(new prestashopProductLanguage6()
            {
                id = 2,
                Value = Data.Nome
            });
            var description = new List<prestashopProductLanguage7>();
            description.Add(new prestashopProductLanguage7()
            {
                id = 2,
                Value = Data.Nome
            });
            var descriptionShort = new List<prestashopProductLanguage8>();
            descriptionShort.Add(new prestashopProductLanguage8()
            {
                id = 2,
                Value = Data.Nome
            });

            var associations = new associations();
            var categoria = new List<category>();
            categoria.Add(new category() { id = "2" });
            categoria.Add(new category() { id = "3" });
            associations.categories = categoria;

            prestashopProduct produto = new prestashopProduct()
            {
                //type = Data.Familia,
                reference = Data.Codigo,
                //supplier_reference = Data.Fornecedor,
                //width = Data.MedidaHorizontal,
                //height = Data.MedidaVertical,
                //weight = Data.PesoLiquido.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us")),
                //minimal_quantity = Decimal.ToInt32(Data.StockMinimo).ToString(),
                state = "1",
                price = Data.PrecoSemIva.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us")),//obrigatorio
                //additional_shipping_cost = Data.FactorTransporte.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us")),
                active = "1",
                meta_description = metaDescription,
                meta_keywords = metaKeywords,
                meta_title = metaTitle,
                link_rewrite = link,//obrigatorio
                name = name,//obrigatorio
                description = description,
                description_short = descriptionShort,
                associations = associations
            };

            prestashopART artigo = new prestashopART()
            {
                product = produto
            };

            return artigo;
        }

        public void AtualizarArtigos(ConfigApp config, string connectionString)
        {
            var db = new ArtigosRepositorio(connectionString, UPECLogic.Classes.Aplicacao.eTipoBD.SQL);
            List<Artigos> artigos = db.LerArtigos();
            var artigosSite = ListaArtigos();
            string id = "";
            foreach (var artigo in artigos)
            {
                var check = 0;
                foreach (var art in artigosSite)
                {
                    if (art.reference == artigo.Codigo)
                    {
                        check = 1;
                        id = art.id.ToString();
                    }
                }
                if (check == 0)
                {
                    var sres = InserirArtigo(artigo);
                    artigosSite = ListaArtigos();
                    foreach (var art in artigosSite)
                    {
                        if (art.reference == artigo.Codigo)
                        {
                            CreateLog(config.Logs_Path, art, sres);
                        }
                    }
                }
                else if (check == 1)
                {
                    var sres = AlterarArtigo(artigo, id);
                    var tes = sres;
                }
            }
        }

        public async Task<ArtigosResponse> ListaArtigosAsync()
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);
            Parametros.Add(new URLParameters
            {
                Propriedade = "display",
                Valor = "full"
            });

            using (HttpResponseMessage RestResponse = await ClienteHTTP.GetAsync(GetURL(URL, Parametros)))
            {
                ArtigosResponse sResult = await RestResponse.GetContent<ArtigosResponse>();
                return sResult;
            }

        }
        public List<Product> ListaArtigos()
        {
            var st = Task.Run(async () =>
            {
                return await ListaArtigosAsync();
            });
            st.Wait();
            return st.Result.Produtos;
        }


        public async Task<ArtigosResponse> LerArtigoAsync(string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            using (HttpResponseMessage RestResponse = await ClienteHTTP.GetAsync(GetURL(URL, id, Parametros)))
            {
                ArtigosResponse sresult = await RestResponse.GetContent<ArtigosResponse>();
                return sresult;
            }
        }
        public Product LerArtigo(string id)
        {
            var st = Task.Run(async () =>
            {
                return await LerArtigoAsync(id);
            });
            st.Wait();
            if(st.Result != null) return st.Result.Produto;
            return null;
        }


        public async Task<Resultado> InserirArtigoAsync(Artigos Dados)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            prestashopART sArtigo = ToWeb(Dados);
            Resultado sResultado = new Resultado();

            using (HttpResponseMessage RestResponse = await ClienteHTTP.PostAsync(GetURL(URL, Parametros), sArtigo.ToXML()))
            {
                try
                {
                    ArtigosResponse sResult = await RestResponse.GetContent<ArtigosResponse>();
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
        public Resultado InserirArtigo(Artigos Dados)
        {
            var st = Task.Run(async () =>
            {
                return await InserirArtigoAsync(Dados);
            });
            st.Wait();
            return st.Result;
        }


        public async Task<Resultado> AlterarArtigoAsync(Artigos Dados, string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            prestashopART sArtigo = ToWeb(Dados);
            sArtigo.product.id = id;
            Resultado sResultado = new Resultado();

            using (HttpResponseMessage RestResponse = await ClienteHTTP.PutAsync(GetURL(URL, Parametros), sArtigo.ToXML()))
            {
                try
                {
                    ArtigosResponse sResult = await RestResponse.GetContent<ArtigosResponse>();
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
        public Resultado AlterarArtigo(Artigos Dados, string id)
        {
            var st = Task.Run(async () =>
            {
                return await AlterarArtigoAsync(Dados, id);
            });
            st.Wait();
            return st.Result;
        }

        public async Task<Resultado> ApagarArtigoAsync(string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            Resultado sResultado = new Resultado();

            using (HttpResponseMessage RestResponse = await ClienteHTTP.DeleteAsync(GetURL(URL, id, Parametros)))
            {
                try
                {
                    ArtigosResponse sResult = await RestResponse.GetContent<ArtigosResponse>();
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

        public Resultado ApagarArtigo(string id)
        {
            var st = Task.Run(async () =>
            {
                return await ApagarArtigoAsync(id);
            });
            st.Wait();
            return st.Result;
        }


        public void CreateLog(string localizacao, Product artigo, Resultado res)
        {
            DirectoryInfo pasta = new DirectoryInfo(localizacao);
            FileInfo[] logs = pasta.GetFiles();
            string nome = (logs.Count() + 1).ToString();

            string descricao = "Sucesso";
            if (res.Sucesso == false) descricao = "Erro! " + res.Mensagem;
            var log = new Logs()
            {
                Sincronizado = "Artigo",
                Codigo_BD = artigo.reference,
                Codigo_Site = artigo.id,
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

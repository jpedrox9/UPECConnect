using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPWebPrestashop.Models;
using UPID.Extensoes.File;
using UPECLogic.Repositorio;
using UPWebPrestaShop.Models;
using System.IO;
using UPWebPrestaShop;
using UPECLogic.Model;

namespace UPWebPrestashop.Services
{
    public class StockService : Base
    {
        private readonly string _site;
        private readonly URLParameters _key;
        public StockService(string Site, string Key) : base(Site, Key)
        {
            _site = Site;
            _key = new URLParameters()
            {
                Propriedade = "ws_key",
                Valor = Key
            };
        }

        private string URL = "stock_availables";

        private prestashopST ToWeb(UPWebPrestaShop.Models.Stock Data)
        {
            prestashopStock dados = new prestashopStock()
            {
                id = Data.id,
                id_product = Data.id_product,
                id_product_attribute = Data.id_product_attribute,
                id_shop = Data.id_shop,
                id_shop_group = Data.id_shop_group,
                quantity = Data.quantity,
                depends_on_stock = Data.depends_on_stock,
                out_of_stock = Data.out_of_stock,
                location = Data.location
            };
            prestashopST stock = new prestashopST()
            {
                stock_available = dados
            };

            return stock;
        }

        public void AtualizarStock(ConfigApp config, string connectionString)
        {
            var db = new StockRepositorio(connectionString, UPECLogic.Classes.Aplicacao.eTipoBD.SQL);
            List<UPECLogic.Model.Stock> artigos = db.LerStock();
            var artigosService = new ArtigosService(_site, _key.Valor);
            var artigosSite = artigosService.ListaArtigos();
            foreach (UPECLogic.Model.Stock artigo in artigos)
            {
                foreach (var art in artigosSite)
                {
                    if(art.reference == artigo.Artigo)
                    {
                        var stock = LerStock(art.associations.stock_availables[0].id.ToString());
                        if (stock != null && int.Parse(stock.quantity) != ((int)artigo.Existencia))
                        {
                            var sres = AlterarStock(stock, artigo.Existencia);
                            CreateLog(config.Logs_Path, art, sres);
                        }
                    }
                }
            }
        }

        public async Task<StockResponse> ListaStockAsync()
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
                StockResponse sResult = await RestResponse.GetContent<StockResponse>();
                return sResult;
            }

        }
        public List<UPWebPrestaShop.Models.Stock> ListaStock()
        {
            var st = Task.Run(async () =>
            {
                return await ListaStockAsync();
            });
            st.Wait();
            return st.Result.Stocks;
        }


        public async Task<StockResponse> LerStockAsync(string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.GetAsync(GetURL(URL, id, Parametros)))
            {
                StockResponse sresult = await RestResponse.GetContent<StockResponse>();
                return sresult;
            }
        }
        public UPWebPrestaShop.Models.Stock LerStock(string id)
        {
            var st = Task.Run(async () =>
            {
                return await LerStockAsync(id);
            });
            st.Wait();
            return st.Result.Stock;
        }


        public async Task<Resultado> AlterarStockAsync(UPWebPrestaShop.Models.Stock Dados, string quant)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            Dados.quantity = quant;
            Dados.out_of_stock = "1";
            prestashopST sStock = ToWeb(Dados);
            Resultado sResultado = new Resultado();

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.PutAsync(GetURL(URL, Parametros), sStock.ToXML()))
            {
                try
                {
                    StockResponse sResult = await RestResponse.GetContent<StockResponse>();
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
        public Resultado AlterarStock(UPWebPrestaShop.Models.Stock Dados, decimal quant)
        {
            var st = Task.Run(async () =>
            {
                return await AlterarStockAsync(Dados, Decimal.ToInt32(quant).ToString());
            });
            st.Wait();
            return st.Result;
        }

        public async Task<Resultado> ApagarStockAsync(string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            Resultado sResultado = new Resultado();

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.DeleteAsync(GetURL(URL, id, Parametros)))
            {
                try
                {
                    StockResponse sResult = await RestResponse.GetContent<StockResponse>();
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

        public Resultado ApagarStock(string id)
        {
            var st = Task.Run(async () =>
            {
                return await ApagarStockAsync(id);
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
                Sincronizado = "Stock",
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

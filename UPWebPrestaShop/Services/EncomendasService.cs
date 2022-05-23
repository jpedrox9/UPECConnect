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
using UPWebPrestaShop.Models.Encomenda;

namespace UPWebPrestashop.Services
{
    public class EncomendasService : Base
    {
        private readonly string _site;
        private readonly URLParameters _key;
        public EncomendasService(string Site, string Key) : base(Site, Key)
        {
            _site = Site;
            _key = new URLParameters()
            {
                Propriedade = "ws_key",
                Valor = Key
            };
        }

        private string URL = "orders";


        public async Task<EncomendasResponse> ListaEncomendasAsync()
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
                EncomendasResponse sResult = await RestResponse.GetContent<EncomendasResponse>();
                return sResult;
            }

        }
        public List<Order> ListaEncomendas()
        {
            var st = Task.Run(async () =>
            {
                return await ListaEncomendasAsync();
            });
            st.Wait();
            return st.Result.orders;
        }


        public async Task<EncomendasResponse> LerEncomendaAsync(string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.GetAsync(GetURL(URL, id, Parametros)))
            {
                EncomendasResponse sresult = await RestResponse.GetContent<EncomendasResponse>();
                return sresult;
            }
        }
        public Order LerEncomenda(string id)
        {
            var st = Task.Run(async () =>
            {
                return await LerEncomendaAsync(id);
            });
            st.Wait();
            if (st.Result != null) return st.Result.order;
            return null;
        }

        public async Task<Moeda.MoedaResponse> LerMoedaAsync(string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.GetAsync(GetURL("currencies", id, Parametros)))
            {
                Moeda.MoedaResponse sresult = await RestResponse.GetContent<Moeda.MoedaResponse>();
                return sresult;
            }
        }
        public string LerMoeda(string id)
        {
            var st = Task.Run(async () =>
            {
                return await LerMoedaAsync(id);
            });
            st.Wait();
            if (st.Result != null) return st.Result.currency.iso_code;
            return null;
        }

        public async Task<Morada.MoradaResponse> LerMoradaAsync(string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.GetAsync(GetURL("addresses", id, Parametros)))
            {
                Morada.MoradaResponse sresult = await RestResponse.GetContent<Morada.MoradaResponse>();
                return sresult;
            }
        }
        public Morada.Address LerMorada(string id)
        {
            var st = Task.Run(async () =>
            {
                return await LerMoradaAsync(id);
            });
            st.Wait();
            if (st.Result != null) return st.Result.address;
            return null;
        }

        public async Task<Resultado> ApagarArtigoAsync(string id)
        {
            List<URLParameters> Parametros = new List<URLParameters>();
            Parametros.Add(_key);

            Resultado sResultado = new Resultado();

            using (System.Net.Http.HttpResponseMessage RestResponse = await ClienteHTTP.DeleteAsync(GetURL(URL, id, Parametros)))
            {
                try
                {
                    EncomendasResponse sResult = await RestResponse.GetContent<EncomendasResponse>();
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
    }

    public class Morada
    {
        public class MoradaResponse
        {
            public Address address { get; set; }
        }

        public class Address
        {
            public int id { get; set; }
            public string id_customer { get; set; }
            public string id_manufacturer { get; set; }
            public string id_supplier { get; set; }
            public string id_warehouse { get; set; }
            public string id_country { get; set; }
            public string id_state { get; set; }
            public string alias { get; set; }
            public string company { get; set; }
            public string lastname { get; set; }
            public string firstname { get; set; }
            public string vat_number { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string postcode { get; set; }
            public string city { get; set; }
            public string other { get; set; }
            public string phone { get; set; }
            public string phone_mobile { get; set; }
            public string dni { get; set; }
            public string deleted { get; set; }
            public string date_add { get; set; }
            public string date_upd { get; set; }
        }
    }

    public class Moeda
    {
        public class MoedaResponse
        {
            public Currency currency { get; set; }
        }

        public class Currency
        {
            public int id { get; set; }
            public string name { get; set; }
            public string symbol { get; set; }
            public string iso_code { get; set; }
            public string numeric_iso_code { get; set; }
            public string precision { get; set; }
            public string conversion_rate { get; set; }
            public string deleted { get; set; }
            public string active { get; set; }
        }
    }
}

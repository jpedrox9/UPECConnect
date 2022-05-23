using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPWebPrestaShop.Models
{
    public class ClientesJSON
    {
        public class ClientesResponse
        {
            [JsonProperty("customers")]
            public List<Customer> Clientes { get; set; }

            [JsonProperty("customer")]
            public Customer Cliente { get; set; }
        }
        public class Customer
        {
            public string id { get; set; }
            public string id_default_group { get; set; }
            public string id_lang { get; set; }
            public string newsletter_date_add { get; set; }
            public string ip_registration_newsletter { get; set; }
            public string last_passwd_gen { get; set; }
            public string secure_key { get; set; }
            public string deleted { get; set; }
            public string passwd { get; set; }
            public string lastname { get; set; }
            public string firstname { get; set; }
            public string email { get; set; }
            public string id_gender { get; set; }
            public string birthday { get; set; }
            public string newsletter { get; set; }
            public string optin { get; set; }
            public string website { get; set; }
            public string company { get; set; }
            public string siret { get; set; }
            public string ape { get; set; }
            public string outstanding_allow_amount { get; set; }
            public string show_public_prices { get; set; }
            public string id_risk { get; set; }
            public string max_payment_days { get; set; }
            public string active { get; set; }
            public string note { get; set; }
            public string is_guest { get; set; }
            public string id_shop { get; set; }
            public string id_shop_group { get; set; }
            public string date_add { get; set; }
            public string date_upd { get; set; }
            public string reset_password_token { get; set; }
            public string reset_password_validity { get; set; }
            public Associations associations { get; set; }
        }

        public class Associations
        {
            public Group[] groups { get; set; }
        }

        public class Group
        {
            public object id { get; set; }
        }

    }
}

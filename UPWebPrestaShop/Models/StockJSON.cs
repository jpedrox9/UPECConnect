using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace UPWebPrestaShop.Models
{
    public class StockResponse
    {
        [JsonProperty("stock_availables")]
        public List<Stock> Stocks { get; set; }

        [JsonProperty("stock_available")]
        public Stock Stock { get; set; }
    }
    public class Stock
    {
        public string id { get; set; }
        public string id_product { get; set; }
        public string id_product_attribute { get; set; }
        public string id_shop { get; set; }
        public string id_shop_group { get; set; }
        public string quantity { get; set; }
        public string depends_on_stock { get; set; }
        public string out_of_stock { get; set; }
        public string location { get; set; }
    }

}

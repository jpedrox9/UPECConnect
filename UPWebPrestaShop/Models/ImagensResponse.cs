using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPWebPrestaShop.Models
{
    public class ImagensResponse
    {
        [JsonProperty("")]
        public List<ids> Imagens { get; set; }
    }
    public class ids
    {
        public string id { get; set; }
    }
}
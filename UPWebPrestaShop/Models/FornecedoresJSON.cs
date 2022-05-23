using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPWebPrestaShop.Models
{

    public class FornecedoresResponse
    {
        public Supplier supplier { get; set; }
        public List<Supplier> suppliers { get; set; }
    }

    public class Supplier
    {
        public string id { get; set; }
        public string link_rewrite { get; set; }
        public string name { get; set; }
        public string active { get; set; }
        public string date_add { get; set; }
        public string date_upd { get; set; }
        public string description { get; set; }
        public string meta_title { get; set; }
        public string meta_description { get; set; }
        public string meta_keywords { get; set; }
    }

}

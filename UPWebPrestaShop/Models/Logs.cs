using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UPWebPrestaShop.Models
{
    public class Logs
    {
        public int EmpresaId { get; set; }
        public string Sincronizado { get; set; }
        public string Codigo_BD { get; set; }
        public string Codigo_Site { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}

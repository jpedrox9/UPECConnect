using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UPECConnect.Data.Models
{
    public class Logs
    {
        [Key]
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Sincronizado { get; set; }
        public string Codigo_BD { get; set; }
        public string Codigo_Site { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}

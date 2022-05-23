using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPWebPrestaShop
{
    public class ConfigApp
    {
        public Dados Dados { get; set; }
        public int Tempo { get; set; }
        public int TempoArranque { get; set; }
        public string Images_Path { get; set; }
        public string Logs_Path { get; set; }
    }
}

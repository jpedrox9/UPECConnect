using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPECLogic.Model
{
    [Table("_IMAGENS")]
    public class Imagens
    {
        [Column("NOME", Order = 0, TypeName = "nvarchar")]
        [Key]
        [StringLength(30)]
        public string Nome { get; set; }

        [Column("ARTIGO", Order = 1, TypeName = "nvarchar")]
        [StringLength(15)]
        public string Artigo { get; set; }

        [Column("CODIGO", Order = 2, TypeName = "nvarchar")]
        [StringLength(10)]
        public string Codigo { get; set; }

        [Column("DATA_MOD", Order = 3, TypeName = "datetime")]
        public DateTime Data_Mod { get; set; }
    }
}

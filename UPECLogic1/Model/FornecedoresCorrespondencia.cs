using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPECLogic.Model
{
    [Table("_FORNECCORRES")]
    public class FornecedoresCorrespondencia
    {
        [Column("CODIGO", Order = 0, TypeName = "nvarchar")]
        [StringLength(15)]
        public string Codigo { get; set; }

        [Column("ID", Order = 1, TypeName = "nvarchar")]
        [StringLength(15)]
        public string Id { get; set; }
    }
}

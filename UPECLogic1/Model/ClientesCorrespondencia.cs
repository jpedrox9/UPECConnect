using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPECLogic.Model
{
    [Table("_CLICORRES")]
    public class ClientesCorrespondencia
    {
        [Column("CODIGO", Order = 0, TypeName = "nvarchar")]
        [StringLength(15)]
        public string Codigo { get; set; }

        [Column("ID", Order = 1, TypeName = "nvarchar")]
        [StringLength(15)]
        public string Id { get; set; }
    }
}

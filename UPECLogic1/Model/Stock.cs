using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPECLogic.Model
{
    [Table(UPID.Logic.Sage100c.BaseDados.Tabelas.ArtigosPorArmazem)]
    public class Stock : UPID.Logic.Sage100c.BaseDados.BDArtigosPorArmazem
    {
    }
}

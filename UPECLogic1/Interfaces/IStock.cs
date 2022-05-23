using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPECLogic.Model;

namespace UPECLogic.Interfaces
{
    interface IStock
    {
        List<Stock> LerStock();
        string LerArmazem(string codigo);
    }
}

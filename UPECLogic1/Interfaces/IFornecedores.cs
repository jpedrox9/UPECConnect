using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPECLogic.Model;

namespace UPECLogic.Interfaces
{
    public interface IFornecedores
    {
        List<Fornecedores> LerFornecedores();
        List<FornecedoresCorrespondencia> LerCodigos();
        void InserirCodigo(string codigo, string id);
    }
}

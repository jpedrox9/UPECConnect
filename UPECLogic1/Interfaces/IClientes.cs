using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPECLogic.Model;

namespace UPECLogic.Interfaces
{
    public interface IClientes
    {
        List<Clientes> LerClientes();
        List<ClientesCorrespondencia> ListarCodigos();
        string LerCodigo(string id);
        void InserirCodigo(string codigo, string id);
    }
}

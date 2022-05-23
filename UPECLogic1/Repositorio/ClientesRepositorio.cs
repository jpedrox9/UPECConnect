using Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPECLogic.Classes.Aplicacao;
using UPECLogic.Interfaces;
using UPECLogic.Model;

namespace UPECLogic.Repositorio
{
    public class ClientesRepositorio : BaseRepository<ClientesRepositorio>, IClientes, IDisposable
    {
        public ClientesRepositorio(string NameOrConectionString, eTipoBD TipoBD) : base(NameOrConectionString, TipoBD)
        {
        }

        public List<Clientes> LerClientes()
        {
            return ContextBD.Clientes.ToList();
        }
        public List<ClientesCorrespondencia> ListarCodigos()
        {
            return ContextBD.ClientesCorrespondencia.ToList();
        }
        public string LerCodigo(string id)
        {
            if(ContextBD.ClientesCorrespondencia.Where(x => x.Id == id).Select(x => x.Codigo).SingleOrDefault() != null) return ContextBD.ClientesCorrespondencia.Where(x => x.Id == id).Select(x => x.Codigo).SingleOrDefault();
            return "000";
        }
        public void InserirCodigo(string codigo, string id)
        {
            var cliente = new ClientesCorrespondencia
            {
                Codigo = codigo,
                Id = id
            };
            ContextBD.ClientesCorrespondencia.Add(cliente);
            ContextBD.SaveChanges();
        }
    }
}

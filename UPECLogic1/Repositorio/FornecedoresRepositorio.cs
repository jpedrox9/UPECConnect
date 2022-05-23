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
    public class FornecedoresRepositorio : BaseRepository<FornecedoresRepositorio>, IFornecedores, IDisposable
    {
        public FornecedoresRepositorio(string NameOrConectionString, eTipoBD TipoBD) : base(NameOrConectionString, TipoBD)
        {
        }

        public List<Fornecedores> LerFornecedores()
        {
            return ContextBD.Fornecedores.ToList();
        }
        public List<FornecedoresCorrespondencia> LerCodigos()
        {
            return ContextBD.FornecedoresCorrespondencia.ToList();
        }
        public void InserirCodigo(string codigo, string id)
        {
            var fornecedor = new FornecedoresCorrespondencia
            {
                Codigo = codigo,
                Id = id
            };
            ContextBD.FornecedoresCorrespondencia.Add(fornecedor);
            ContextBD.SaveChanges();
        }
    }
}

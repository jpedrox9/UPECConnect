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
    public class EncomendasRepositorio : BaseRepository<Encomendas>, IEncomendas, IDisposable
    {
        public EncomendasRepositorio(string NameOrConectionString, eTipoBD TipoBD) : base(NameOrConectionString, TipoBD)
        {
        }

        public List<Encomendas> LerEncomendas()
        {
            return ContextBD.Encomendas.Where(x => x.TipoDocumento == "ENC").OrderBy(x => x.NumeroDoc).ToList();
        }
    }
}

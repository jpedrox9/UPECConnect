using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPECLogic.Classes.Aplicacao;
using UPECLogic.Model;
using Repositorios.Base;
using UPECLogic.Interfaces;

namespace UPECLogic.Repositorio
{
    public class ArtigosRepositorio : BaseRepository<Artigos>, IArtigos, IDisposable
    {
        public ArtigosRepositorio(string NameOrConectionString, eTipoBD TipoBD) : base(NameOrConectionString, TipoBD)
        {
        }

        public List<Artigos> LerArtigos()
        {
                return ContextBD.Artigos.ToList();
        }
    }
}

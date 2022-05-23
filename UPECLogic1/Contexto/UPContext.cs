using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPECLogic.Model;

namespace UPECLogic.Contexto
{
    public class UPContext : BaseContext
    {
        public UPContext(string sConectionString, Classes.Aplicacao.eTipoBD TipoBD) : base(sConectionString, TipoBD)
        {
        }
        public DbSet<Artigos> Artigos { get; set; }

        public DbSet<Stock> Stock { get; set; }

        public DbSet<Imagens> Imagens { get; set; }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<ClientesCorrespondencia> ClientesCorrespondencia { get; set; }

        public DbSet<Fornecedores> Fornecedores { get; set; }

        public DbSet<FornecedoresCorrespondencia> FornecedoresCorrespondencia { get; set; }

        public DbSet<Encomendas> Encomendas { get; set; }

    }
}

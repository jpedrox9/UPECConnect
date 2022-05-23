using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Entity;

namespace UPECLogic.Contexto
{
    public abstract class BaseContext : DbContext
    {
        private void InicializationConection()
        {
            Database.SetInitializer<UPContext>(null);
        }



        private string _ConectionString;



        private Classes.Aplicacao.eTipoBD _TipoBD;



        public BaseContext(string sConectionString, Classes.Aplicacao.eTipoBD TipoBD) : base(sConectionString)
        {
            _ConectionString = sConectionString;
            _TipoBD = TipoBD;
            InicializationConection();
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Keys
            //BdKeys.SetKeys(modelBuilder);
        }
    }
}
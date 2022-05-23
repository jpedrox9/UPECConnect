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
using Interfaces.Base;
using System.Linq.Expressions;
using UPECLogic.Contexto;
using UPECLogic.Classes.Aplicacao;
using System.Data.Entity;

namespace Repositorios.Base
{
    public class BaseRepository<TModel> : IBase<TModel> where TModel : class
    {
        private bool ObrigaDispose;



        private string _ConectionString;



        private eTipoBD _TipoBD;



        private string ECCUltimaMensagem { get; set; }



        private UPContext ContextLocal { get; set; }



        public string UltimaMensagem
        {
            get
            {
                return ECCUltimaMensagem;
            }
            set
            {
                ECCUltimaMensagem = value;
            }
        }



        private bool disposed;



        public BaseRepository(string NameOrConectionString, eTipoBD TipoBD)
        {
            LoadingConection(NameOrConectionString, TipoBD);
        }



        private void LoadingConection(string NameOrConectionString, eTipoBD TipoBD)
        {
            ObrigaDispose = true;
            _ConectionString = NameOrConectionString;
            _TipoBD = TipoBD;
            ContextLocal = new UPContext(NameOrConectionString, TipoBD);
        }



        public BaseRepository(UPContext sContexto)
        {
            ObrigaDispose = false;
            ContextLocal = sContexto;
        }



        public BaseRepository(ConfiguracoesBD sConfig)
        {
            ObrigaDispose = true;
            ContextLocal = new UPContext(sConfig.ConectionString, sConfig.TipoBD);
        }



        public void Save()
        {
            // Dim sErros As IEnumerable(Of Microsoft.EntityFrameworkCore.Validation.DbEntityValidationResult)
            // sErros = ContextBD.GetValidationErrors.Where(Function(x) Not x.IsValid)
            // If sErros.Count > 0 Then
            // For Each sDados As Microsoft.EntityFrameworkCore.Validation.DbEntityValidationResult In ContextBD.GetValidationErrors.Where(Function(x) Not x.IsValid)
            // For Each sErro In sDados.ValidationErrors
            // If String.IsNullOrWhiteSpace(Contexto.UPOdloContext.GetLogEntity) Then
            // Contexto.UPOdloContext.GetLogEntity = sErro.PropertyName & " : " & sErro.ErrorMessage
            // Else
            // Contexto.UPOdloContext.GetLogEntity = Contexto.UPOdloContext.GetLogEntity & vbCrLf & sErro.PropertyName & " : " & sErro.ErrorMessage
            // End If
            // Next
            // Next
            // End If
            ContextBD.SaveChanges();
        }



        public void RefreshAll()
        {
            foreach (var sEntity in ContextBD.ChangeTracker.Entries())
                sEntity.Reload();
        }



        public UPContext ContextBD
        {
            get
            {
                return ContextLocal;
            }
        }



        private bool disposedValue; // To detect redundant calls



        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (ObrigaDispose)
                    {
                        if (ContextBD != null)
                        {
                            ContextBD.Dispose();
                            ContextLocal = null/* TODO Change to default(_) if this is not a reference type */;
                        }
                    }
                }
            }
            disposedValue = true;
        }



        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        public TModel Get(Expression<Func<TModel, bool>> where)
        {
            return ContextBD.Set<TModel>().FirstOrDefault(where);
        }



        public TResult Get<TResult>(Expression<Func<TModel, bool>> where, Expression<Func<TModel, TResult>> Columns)
        {
            return ContextBD.Set<TModel>().Where(where).Select(Columns).FirstOrDefault();
        }



        public IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> where)
        {
            return ContextBD.Set<TModel>().Where(where);
        }



        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TModel, bool>> where, Expression<Func<TModel, TResult>> Columns)
        {
            return ContextBD.Set<TModel>().Where(where).Select(Columns);
        }



        public Task<List<TModel>> GetAllASync(Expression<Func<TModel, bool>> where)
        {
            return ContextBD.Set<TModel>().Where(where).ToListAsync();
        }



        public Task<List<TResult>> GetAllASync<TResult>(Expression<Func<TModel, bool>> where, Expression<Func<TModel, TResult>> Columns)
        {
            return ContextBD.Set<TModel>().Where(where).Select(Columns).ToListAsync();
        }



        public Task<TModel> GetASync(Expression<Func<TModel, bool>> where)
        {
            return ContextBD.Set<TModel>().FirstOrDefaultAsync(where);
        }



        public Task<TResult> GetASync<TResult>(Expression<Func<TModel, bool>> where, Expression<Func<TModel, TResult>> Columns)
        {
            return ContextBD.Set<TModel>().Where(where).Select(Columns).FirstOrDefaultAsync();
        }



        public bool Exist(Expression<Func<TModel, bool>> where)
        {
            return ContextBD.Set<TModel>().Any(where);
        }



        public Task<bool> ExistASync(Expression<Func<TModel, bool>> where)
        {
            return ContextBD.Set<TModel>().AnyAsync(where);
        }



        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TModel, TResult>> Columns)
        {
            return ContextBD.Set<TModel>().Select(Columns);
        }



        public IEnumerable<TResult2> GetAll<TResult, TResult2>(Expression<Func<TModel, TResult>> Columns, Expression<Func<TResult, TResult2>> Columns2)
        {
            return ContextBD.Set<TModel>().Select(Columns).Select(Columns2);
        }



        public TResult2 Get<TResult, TResult2>(Expression<Func<TModel, bool>> where, Expression<Func<TModel, TResult>> Columns, Expression<Func<TResult, TResult2>> Columns2)
        {
            return ContextBD.Set<TModel>().Where(where).Select(Columns).Select(Columns2).FirstOrDefault();
        }



        public IEnumerable<TResult2> GetAll<TResult, TResult2>(Expression<Func<TModel, bool>> where, Expression<Func<TModel, TResult>> Columns, Expression<Func<TResult, TResult2>> Columns2)
        {
            return ContextBD.Set<TModel>().Where(where).Select(Columns).Select(Columns2);
        }
    }
}
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
using Microsoft.VisualBasic;
using System.Linq.Expressions;
using UPECLogic.Interfaces;



namespace Interfaces.Base
{
    public interface IBase<T> : IBaseSimples
    {
        T Get(Expression<Func<T, bool>> where);



        Task<T> GetASync(Expression<Func<T, bool>> where);



        IEnumerable<T> GetAll(Expression<Func<T, bool>> where);



        IEnumerable<TResult> GetAll<TResult>(Expression<Func<T, TResult>> Columns);



        IEnumerable<TResult2> GetAll<TResult, TResult2>(Expression<Func<T, TResult>> Columns, Expression<Func<TResult, TResult2>> Columns2);



        Task<List<T>> GetAllASync(Expression<Func<T, bool>> where);



        TResult Get<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> Columns);



        TResult2 Get<TResult, TResult2>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> Columns, Expression<Func<TResult, TResult2>> Columns2);



        Task<TResult> GetASync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> Columns);



        IEnumerable<TResult> GetAll<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> Columns);



        IEnumerable<TResult2> GetAll<TResult, TResult2>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> Columns, Expression<Func<TResult, TResult2>> Columns2);



        Task<List<TResult>> GetAllASync<TResult>(Expression<Func<T, bool>> where, Expression<Func<T, TResult>> Columns);



        bool Exist(Expression<Func<T, bool>> where);



        Task<bool> ExistASync(Expression<Func<T, bool>> where);
    }
}
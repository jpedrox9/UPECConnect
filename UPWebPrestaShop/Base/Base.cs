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
using UPID.Extensoes.Objectos;
using UPID.Extensoes.Texto;

public class Base : IDisposable
{
    private string Site { get; set; }

    internal System.Net.Http.HttpClient ClienteHTTP { get; set; }

    public Base(string sSite, string Key)
    {
        Site = sSite;
        ClienteHTTP = new System.Net.Http.HttpClient()
        {
            BaseAddress = new Uri(Site)
        };
        //ClienteHTTP.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("PostmanRuntime/7.28.4"));
        ClienteHTTP.DefaultRequestHeaders.Add("Io-Format", "JSON");
    }

    internal string GetURL(string Action,  List<URLParameters> Parametros)
    {
        return GetURL(string.Empty, Action, Parametros);
    }

    internal string GetURL(string Action)
    {
        return GetURL(string.Empty, Action, null);
    }

    internal string GetURL(string Controller, string Action)
    {
        return GetURL(Controller, Action, null);
    }

    internal string GetURL(string Controller, string Action,  List<URLParameters> Parametros)
    {
        StringBuilder sURL = new StringBuilder();
        sURL.Append(Site);
        if (!Site.EndsWith("/"))
            sURL.Append("/");
        if (Controller.isNotEmpty())
        {
            sURL.Append(Controller);
            sURL.Append("/");
        }
        sURL.Append(Action);
        if (Parametros.isNull(() => false, x => x.Any()))
        {
            sURL.Append("?");
            bool sTemParametro = false;
            foreach (URLParameters sTempParametro in Parametros)
            {
                if (sTemParametro)
                    sURL.Append("&");
                sURL.Append(sTempParametro.Propriedade);
                sURL.Append("=");
                sURL.Append(sTempParametro.Valor);
                sTemParametro = true;
            }
        }
        return sURL.ToString();
    }

    private bool disposedValue; // To detect redundant calls

    // IDisposable
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
                ClienteHTTP.Dispose();

            ClienteHTTP = null;
            Site = null;
        }
        disposedValue = true;
    }

    // This code added by Visual Basic to correctly implement the disposable pattern.
    public void Dispose()
    {
        // Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

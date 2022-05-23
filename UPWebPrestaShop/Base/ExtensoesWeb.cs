using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UPID.Extensoes.File;
using Newtonsoft.Json;

[HideModuleName]
internal static class ExtensoesWeb
{
    public static HttpContent ToHtmlContent<T>(this T sender)
    {
        JsonSerializerSettings sSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };
        string sTexto = JsonConvert.SerializeObject(sender, sSettings);

        // System.IO.File.AppendAllText("C:\Backups\log.txt", $"{vbCrLf}--------------------------{vbCrLf}{sTexto}")
        return new StringContent(sTexto, Encoding.UTF8, "application/json");
    }

    public static HttpContent ToXML<T>(this T sender)
    {
        string sTexto = sender.SerializeToStringXML(Encoding.UTF8);

        // System.IO.File.AppendAllText("C:\Backups\log.txt", $"{vbCrLf}--------------------------{vbCrLf}{sTexto}")
        return new StringContent(sTexto, Encoding.UTF8, "text/xml");
    }


    public async static Task<T> GetContent<T>(this HttpResponseMessage Sender)
    {
        string responseBody3 = await Sender.Content.ReadAsStringAsync();
        T sResult;
        sResult = JsonConvert.DeserializeObject<T>(responseBody3);
        return sResult;
    }
}

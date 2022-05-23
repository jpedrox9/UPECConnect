using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UPECConnectService;

namespace UPECConnect.Data.Models
{
    public class Config
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Empresa { get; set; }
        public int TempoArranque { get; set; }
        public string Images_Path { get; set; }
        public string Logs_Path { get; set; }
        public string URL { get; set; }
        public string Token { get; set; }
        public string Servidor { get; set; }
        public string BaseDados { get; set; }
        public string Utilizador { get; set; }
        public string Password { get; set; }
        public string WebService { get; set; }
        public string TipoDoc { get; set; }
        public short Serie { get; set; }
        public string Setor { get; set; }


        public static object GetConfig(int empresa, string conn)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string queryString = "select * from Config where Empresa='" + empresa + "';";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                Config res = new Config();
                foreach (DataRow row in table.Rows)
                {
                    res = new Config()
                    { 
                        Empresa = Convert.ToInt32(row["Empresa"]),
                        TempoArranque = Convert.ToInt32(row["TempoArranque"]),
                        Images_Path = row["Images_Path"].ToString(),
                        Logs_Path = row["Logs_Path"].ToString(),
                        URL = row["URL"].ToString(),
                        Token = row["Token"].ToString(),
                        Servidor = row["Servidor"].ToString(),
                        BaseDados = row["BaseDados"].ToString(),
                        Utilizador = row["Utilizador"].ToString(),
                        Password = row["Password"].ToString(),
                        WebService = row["WebService"].ToString(),
                        TipoDoc = row["TipoDoc"].ToString(),
                        Serie = Convert.ToInt16(row["Serie"]),
                        Setor = row["Setor"].ToString()
                    };
                }

                return res;
            }
        }
        public static ConfigApp Converter(Config dados)
        {
            var dadosDoc = new Doc
            {
                TipoDoc = dados.TipoDoc,
                Serie = dados.Serie,
                Setor = dados.Setor
            };
            var dadosSite = new Site
            {
                URL = dados.URL,
                Token = dados.Token
            };
            var dadosERP = new ERP
            {
                Servidor = dados.Servidor,
                BaseDados = dados.BaseDados,
                Utilizador = dados.Utilizador,
                Password = dados.Password,
                WebService = dados.WebService
            };
            var dados1 = new Dados
            {
                DadosSite = dadosSite,
                DadosERP = dadosERP,
                DadosDoc = dadosDoc
            };
            var config = new ConfigApp
            {
                Dados = dados1,
                TempoArranque = dados.TempoArranque,
                Images_Path = dados.Images_Path,
                Logs_Path = dados.Logs_Path,
                EmpresaId = dados.Empresa.ToString()
            };
            return config;
        }
        public static Config Converter(ConfigApp dados)
        {
            var config = new Config()
            {
                Empresa = int.Parse(dados.EmpresaId),
                Images_Path = dados.Images_Path,
                Logs_Path = dados.Logs_Path,
                TempoArranque = dados.TempoArranque,
                URL = dados.Dados.DadosSite.URL,
                Token = dados.Dados.DadosSite.Token,
                Servidor = dados.Dados.DadosERP.Servidor,
                BaseDados = dados.Dados.DadosERP.BaseDados,
                Utilizador = dados.Dados.DadosERP.Utilizador,
                Password = dados.Dados.DadosERP.Password,
                WebService = dados.Dados.DadosERP.WebService,
                TipoDoc = dados.Dados.DadosDoc.TipoDoc,
                Serie = dados.Dados.DadosDoc.Serie,
                Setor = dados.Dados.DadosDoc.Setor
            };
            return config;
        }
    }
}

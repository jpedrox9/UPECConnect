using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace UPECConnect.Data.Models
{
    [Table("UsersEmpresas")]
    public class UserEmpresa
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EmpresaId { get; set; }

        public static void Save(int empresaId, string userId, string conn)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                var lista = GetEmpresas(userId,conn);
                if (!lista.Contains(empresaId))
                {
                    string queryString = "insert into UsersEmpresas(UserId,EmpresaId) values('" + userId + "'," + empresaId + ");";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<int> GetEmpresas(string userId, string conn)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                var lista = new List<int>();
                string queryString = "select EmpresaId from UsersEmpresas where UserId='" + userId + "';";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow row in table.Rows) lista.Add((int)row["EmpresaId"]);
                return lista;
            }
        }

        public static object Listar(List<int> empresas, string conn)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                var lista = new List<Empresa>();
                string queryString = "select * from Empresas";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    if (empresas.Contains((int)row["Id"]))
                    {
                        var empresa = new Empresa();
                        empresa.Id = Convert.ToInt32(row["id"]);
                        empresa.Sigla = row["Sigla"].ToString();
                        empresa.Nome = row["nome"].ToString();

                        lista.Add(empresa);
                    }
                }
                return lista;
            }
        }

        public static void Delete(int empresaId, string userId, string conn)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string queryString = "delete from UsersEmpresas where UserId='" + userId + "' and EmpresaId=" + empresaId;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

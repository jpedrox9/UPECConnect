using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UPECConnect.Data.Models
{
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(Order = 0, TypeName = "nvarchar(20)")]
        public string Sigla { get; set; }
        [Required]
        [Column(Order = 1, TypeName = "nvarchar(250)")]
        public string Nome { get; set; }
        [Required]
        [Column(Order = 2, TypeName = "nvarchar(250)")]
        public string Password { get; set; }

        public static string GetEmpresaById(int id, string conn)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                string queryString = "select Nome from Empresas where Id='" + id + "';";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                if(command.ExecuteScalar() != null)
                {
                    return command.ExecuteScalar().ToString();
                }
                return null;
            }
        }
    }
}

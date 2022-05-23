using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace UPECConnect.Data.Models
{
    public class Claims
    {
        public const string Empresa = "Empresa";

        public static bool HasClaims(string userId, string conn)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                var lista = new List<string>();
                string queryString = "select ClaimValue from AspNetUserClaims where UserId='" + userId + "';";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow row in table.Rows) lista.Add(row["ClaimValue"].ToString());
                if (lista.Count() == 0) return false;
                return true;
            }
        }
    }
}

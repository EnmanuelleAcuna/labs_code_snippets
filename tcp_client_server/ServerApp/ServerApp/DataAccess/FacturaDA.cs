using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.DataAccess
{
    public static class FacturaDA
    {
        private static string connString = "Server=(localdb)\\MSSQLLocalDB;initial catalog=TCPLab;Integrated Security=True";

        public static void Save(Factura factura)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Facturas VALUES (@Id, @Concepto, @Fecha, @Monto, @Proveedor)";
                cmd.Parameters.Add(new SqlParameter("@Id", factura.Id));
                cmd.Parameters.Add(new SqlParameter("@Concepto", factura.Concepto));
                cmd.Parameters.Add(new SqlParameter("@Fecha", factura.Fecha));
                cmd.Parameters.Add(new SqlParameter("@Monto", factura.Monto));
                cmd.Parameters.Add(new SqlParameter("@Proveedor", factura.Proveedor));

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Factura> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Facturas";

                List<Factura> facturas = new List<Factura>();

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            facturas.Add(new Factura
                            {
                                Id = reader.GetGuid(0),
                                Concepto = reader.GetString(1),
                                Fecha = reader.GetDateTime(2),
                                Monto = reader.GetFloat(3),
                                Proveedor = reader.GetString(4),
                            });
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }

                return facturas;
            }
        }
    }
}

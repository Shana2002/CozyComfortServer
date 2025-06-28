using CozyComfortServer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CozyComfortServer.Data
{
    public class BlanketsDAL
    {
        private SqlConnection con = DataAccess.GetConnection();

        public List<Blanket> GetAllBlankets()
        {
            List<Blanket> blankets = new List<Blanket>();
            string query = @"SELECT b.BlanketId, b.Name AS BlanketName, b.UnitPrice, b.ProductionCapacity,
                             m.MaterialId, m.MaterialName
                             FROM Blankets b JOIN Material m ON b.MaterialId = m.MaterialId";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                blankets.Add(new Blanket
                {
                    BlanketId = Convert.ToInt32(reader["BlanketId"]),
                    BlanketName = reader["BlanketName"].ToString(),
                    Price = Convert.ToDouble(reader["UnitPrice"]),
                    ProductionCapacity = Convert.ToInt32(reader["ProductionCapacity"]),
                    Material = new Material
                    {
                        MaterialId = Convert.ToInt32(reader["MaterialId"]),
                        MaterialName = reader["MaterialName"].ToString()
                    }
                });
            }
            con.Close();
            return blankets;
        }

        public void AddBlanket(Blanket b)
        {
            string query = @"INSERT INTO Blankets(Name, UnitPrice, ProductionCapacity, MaterialId)
                             VALUES(@Name, @UnitPrice, @ProductionCapacity, @MaterialId)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", b.BlanketName);
            cmd.Parameters.AddWithValue("@UnitPrice", b.Price);
            cmd.Parameters.AddWithValue("@ProductionCapacity", b.ProductionCapacity);
            cmd.Parameters.AddWithValue("@MaterialId", b.Material.MaterialId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateBlanket(Blanket b)
        {
            string query = @"UPDATE Blankets 
                             SET Name=@Name, UnitPrice=@UnitPrice, ProductionCapacity=@ProductionCapacity, MaterialId=@MaterialId 
                             WHERE BlanketId=@BlanketId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", b.BlanketName);
            cmd.Parameters.AddWithValue("@UnitPrice", b.Price);
            cmd.Parameters.AddWithValue("@ProductionCapacity", b.ProductionCapacity);
            cmd.Parameters.AddWithValue("@MaterialId", b.Material.MaterialId);
            cmd.Parameters.AddWithValue("@BlanketId", b.BlanketId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteBlanket(int id)
        {
            string query = "DELETE FROM Blankets WHERE BlanketId = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
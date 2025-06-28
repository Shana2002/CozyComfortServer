using CozyComfortServer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CozyComfortServer.Data
{
    public class MaterialsDAL
    {
        private SqlConnection con = DataAccess.GetConnection();

        public List<Material> GetAllMaterials()
        {
            List<Material> materials = new List<Material>();
            string query = "SELECT * FROM Material";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                materials.Add(new Material
                {
                    MaterialId = Convert.ToInt32(reader["MaterialId"]),
                    MaterialName = reader["MaterialName"].ToString()
                });
            }
            con.Close();
            return materials;
        }

        public void AddMaterial(Material mat)
        {
            string query = "INSERT INTO Material(MaterialName) VALUES(@MaterialName)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@MaterialName", mat.MaterialName);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateMaterial(Material mat)
        {
            string query = "UPDATE Material SET MaterialName = @MaterialName WHERE MaterialId = @MaterialId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@MaterialName", mat.MaterialName);
            cmd.Parameters.AddWithValue("@MaterialId", mat.MaterialId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteMaterial(int id)
        {
            string query = "DELETE FROM Material WHERE MaterialId = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
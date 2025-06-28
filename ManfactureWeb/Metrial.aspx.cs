using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI;
using CozyComfortServer.Models;
using Newtonsoft.Json;

namespace ManfactureWeb
{
    public partial class Metrial : Page
    {
        private static readonly string apiUrl = "http://localhost:52814/api/MaterialsDAL";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMaterialsFromApi();
            }
        }

        private async void LoadMaterialsFromApi()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Material> materials = JsonConvert.DeserializeObject<List<Material>>(json);
                        gvMaterials.DataSource = materials;
                        gvMaterials.DataBind();
                    }
                    else
                    {
                        ShowAlert("Failed to load materials. Status: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    ShowAlert("Error loading materials: " + ex.Message);
                }
            }
        }

        protected async void btnAddMaterial_Click(object sender, EventArgs e)
        {
            string name = txtMaterialName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                ShowAlert("Material name cannot be empty.");
                return;
            }

            Material material = new Material { MaterialName = name };

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonData = JsonConvert.SerializeObject(material);
                    HttpContent content = new StringContent(jsonData);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        txtMaterialName.Text = "";
                        LoadMaterialsFromApi(); // Refresh grid
                        ShowAlert("Material added successfully.");
                    }
                    else
                    {
                        ShowAlert("Failed to add material. Status: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    ShowAlert("Error adding material: " + ex.Message);
                }
            }
        }

        private void ShowAlert(string message)
        {
            string script = $"alert('{message.Replace("'", "\\'")}');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }
    }
}

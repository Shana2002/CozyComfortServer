using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI;
using System.Web.UI.WebControls;
using CozyComfortServer.Models;
using Newtonsoft.Json;

namespace ManfactureWeb
{
    public partial class Blankets : Page
    {
        private static readonly string apiUrl = "http://localhost:52814/api/Blankets";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBlankets();
            }
        }

        private async void LoadBlankets()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var blankets = JsonConvert.DeserializeObject<List<Blanket>>(json);
                        gvBlankets.DataSource = blankets;
                        gvBlankets.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    ShowAlert("Error loading blankets: " + ex.Message);
                }
            }
        }

        protected async void btnAddBlanket_Click(object sender, EventArgs e)
        {
            string name = txtBlanketName.Text.Trim();
            int materialId = int.Parse(txtMaterialId.Text.Trim());
            int capacity = int.Parse(txtCapacity.Text.Trim());
            double price = double.Parse(txtPrice.Text.Trim());

            var newBlanket = new Blanket
            {
                BlanketName = name,
                Material = new Material { MaterialId = materialId },
                ProductionCapacity = capacity,
                Price = price
            };

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(newBlanket);
                    var content = new StringContent(json);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = await client.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        ShowAlert("Blanket added successfully.");
                        ClearInputs();
                        LoadBlankets();
                    }
                    else
                    {
                        ShowAlert("Add failed: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    ShowAlert("Error adding blanket: " + ex.Message);
                }
            }
        }

        protected void gvBlankets_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBlankets.EditIndex = e.NewEditIndex;
            LoadBlankets();
        }

        protected async void gvBlankets_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvBlankets.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvBlankets.Rows[e.RowIndex];

            string name = ((TextBox)row.Cells[1].Controls[0]).Text;
            int materialId = int.Parse(((TextBox)row.Cells[2].Controls[0]).Text);
            int capacity = int.Parse(((TextBox)row.Cells[3].Controls[0]).Text);
            double price = double.Parse(((TextBox)row.Cells[4].Controls[0]).Text);

            var updatedBlanket = new Blanket
            {
                BlanketId = id,
                BlanketName = name,
                Material = new Material { MaterialId = materialId },
                ProductionCapacity = capacity,
                Price = price
            };

            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(updatedBlanket);
                var content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PutAsync($"{apiUrl}/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    gvBlankets.EditIndex = -1;
                    LoadBlankets();
                    ShowAlert("Blanket updated.");
                }
                else
                {
                    ShowAlert("Update failed.");
                }
            }
        }

        protected void gvBlankets_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBlankets.EditIndex = -1;
            LoadBlankets();
        }

        private void ClearInputs()
        {
            txtBlanketName.Text = "";
            txtMaterialId.Text = "";
            txtCapacity.Text = "";
            txtPrice.Text = "";
        }

        private void ShowAlert(string message)
        {
            string script = $"alert('{message.Replace("'", "\\'")}');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }
    }
}

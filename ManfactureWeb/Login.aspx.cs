﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManfactureWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Replace with real validation logic (e.g., DB check)
            if (username == "admin" && password == "1234")
            {
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid credentials');</script>");
            }
        }

    }
}
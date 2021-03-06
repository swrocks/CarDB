﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace CarDB
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MileageDBConnectionString"].ConnectionString);

            SqlCommand comm = new SqlCommand("SELECT * FROM CarTable", conn);

            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();

            CarList.DataSource = reader;
            CarList.DataBind();

            reader.Close();
            conn.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void CarList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            var theCarID = e.CommandArgument.ToString();
            if (theCarID != "")
            {
                DeleteACar(theCarID);
                Response.Redirect("default.aspx");
            }
            else
            {
                Response.Write("Nothing to delete!");
            }

        }

        public void DeleteACar(string theCarID)
        {
            SqlConnection conn;
            SqlCommand comm;
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MileageDBConnectionString"].ConnectionString);
            comm = new SqlCommand("DELETE FROM CarTable WHERE CarID = @theCarID", conn);

            comm.Parameters.Add("@theCarID", System.Data.SqlDbType.VarChar);

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MileageDBConnectionString"].ConnectionString);

            comm = new SqlCommand("INSERT INTO CarTable (Car, Manufact, MPG) VALUES (@CarMake, @Manafacture, @MPG)", conn);

            comm.Parameters.Add("@CarMake", System.Data.SqlDbType.VarChar);
            comm.Parameters["@CarMake"].Value = CarMake.Text;
            comm.Parameters.Add("@Manafacture", System.Data.SqlDbType.VarChar);
            comm.Parameters["@Manafacture"].Value = Manafacture.Text;
            comm.Parameters.Add("@MPG", System.Data.SqlDbType.Int);
            comm.Parameters["@MPG"].Value = MPG.Text;

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("default.aspx");
        }

    }
}
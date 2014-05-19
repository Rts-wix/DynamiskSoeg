using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;

public partial class SoegKunder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String conStr = ConfigurationManager.ConnectionStrings["NW1ConnectionString1"].ToString();
        SqlConnection conn = new SqlConnection(conStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM Customers";

        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        GridViewKunder.DataSource = reader;
        GridViewKunder.DataBind();
        conn.Close();
    }
}
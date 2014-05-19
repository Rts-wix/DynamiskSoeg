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
    private string whereClause = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSearchResult();
        }
    }

    private void LoadSearchResult(string whereClause = "")
    {
        String conStr = ConfigurationManager.ConnectionStrings["NW1ConnectionString1"].ToString();
        SqlConnection conn = new SqlConnection(conStr);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM Customers" + whereClause;

        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        GridViewKunder.DataSource = reader;
        GridViewKunder.DataBind();
        conn.Close();
    }

    protected void ButtonSoeg_Click(object sender, EventArgs e)
    {
        // WHERE 
        //CompanyName LIKE '%%'
        //AND
        //ContactName = 'Palle Ibsen'
        //AND
        //(Country = 'Denmark' or Country = 'Sweden')

        string whereCompanyName = "";
        if (TextBoxCompanyName.Text != "")
        {
            whereCompanyName = "CompanyName LIKE '%" + TextBoxCompanyName.Text + "%'";
            AddToWhere(whereCompanyName);
        }

        string whereContactName = "";
        if (DropDownListContactName.SelectedValue != "")
        {
            whereContactName = "ContactName = '" + DropDownListContactName.SelectedValue + "'";
            AddToWhere(whereContactName);
        }

        string whereCountries = "";
        if (CheckBoxListCountries.SelectedIndex > 0)
        {
            foreach (ListItem country in CheckBoxListCountries.Items)
            {            
                if (country.Selected)
                {
                    if (whereCountries != "")
                    {
                        whereCountries += " OR";
                    }
                    whereCountries += " Country = '" + country.Value + "'";
                }
            }
            whereCountries = "(" + whereCountries + ")";
            AddToWhere(whereCountries);
        }

        if (whereClause != "")
        {
            whereClause = " WHERE" + whereClause;
        }

        LoadSearchResult(whereClause);
    }

    private void AddToWhere(string newWherePart)
    {
        if (whereClause != "")
        {
            whereClause += " AND";
        }
        whereClause += " " + newWherePart;
    }
}
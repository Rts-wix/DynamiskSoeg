using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class SoegProdukter : System.Web.UI.Page
{
    private string categoryjoin = " INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID";
    private string whereClause = "";
    private SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void LoadSearchResult(string whereClause = "")
    {
        String conStr = ConfigurationManager.ConnectionStrings["NW1ConnectionString1"].ToString();
        SqlConnection conn = new SqlConnection(conStr);

        cmd.Connection = conn;

        cmd.CommandText = "SELECT * FROM Products" + categoryjoin + whereClause;

        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        GridViewProducts.DataSource = reader;
        GridViewProducts.DataBind();
        conn.Close();
    }
    protected void ButtonSoeg_Click(object sender, EventArgs e)
    {
        // WHERE 
        //CategoryName LIKE '%%'
        //AND
        //ProductName = 'Palle Ibsen'
        //AND
        //QuantityPerUnitMin >= 1
        //AND
        //QuantityPerUnitMax <= 8
        //AND
        //UnitsInStockMin = <= 5
        //AND
        //UnitsInStockMax = <= 5
        //AND
        //(Discontinued = 'false')
        string whereCategoryName = "";
        if (TextBoxCategoryName.Text != "")
        {
            //categoryjoin = " INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID";
            whereCategoryName = "CategoryName LIKE '%'+@CategoryName+'%'";
            AddToWhere(whereCategoryName);
            cmd.Parameters.AddWithValue("CategoryName", TextBoxCategoryName.Text);
        }
        else { }

        string whereProductName = "";
        if (TextBoxProductName.Text != "")
        {
            whereProductName = "ProductName LIKE '%'+@ProductName+'%'";
            AddToWhere(whereProductName);
            cmd.Parameters.AddWithValue("ProductName", TextBoxProductName.Text);
        }
        else { }

        string whereQuantityPerUnitMin = "";
        string whereQuantityPerUnitMax = "";
        string whereQuantityPerUnitMinMax = "";
        if (TextBoxQtyPerUnit_min.Text != "" && TextBoxQtyPerUnit_max.Text != "")
        {
            whereQuantityPerUnitMinMax = "(QuantityPerUnit >= @QuantityMin AND QuantityPerUnit <= @QuantityMax)";
            AddToWhere(whereQuantityPerUnitMinMax);
            cmd.Parameters.AddWithValue("QuantityMin", TextBoxQtyPerUnit_min.Text);
            cmd.Parameters.AddWithValue("QuantityMax", TextBoxQtyPerUnit_max.Text);
        }
        else
        {
            if (TextBoxQtyPerUnit_min.Text != "")
            {
                whereQuantityPerUnitMin = "QuantityPerUnit >= @QuantityMin";
                AddToWhere(whereQuantityPerUnitMin);
                cmd.Parameters.AddWithValue("QuantityMin", TextBoxQtyPerUnit_min.Text);
            }
            else { }


            if (TextBoxQtyPerUnit_max.Text != "")
            {
                whereQuantityPerUnitMax = "QuantityPerUnit <= @QuantityMax";
                AddToWhere(whereQuantityPerUnitMax);
                cmd.Parameters.AddWithValue("QuantityMax", TextBoxQtyPerUnit_max.Text);
            }
        }


        string whereStockPerUnitMin = "";
        string whereStockPerUnitMax = "";
        string whereStockPerUnitMinMax = "";
        if (TextBoxStockPerUnit_min.Text != "" && TextBoxStockPerUnit_max.Text != "")
        {
            whereStockPerUnitMinMax = "(UnitsInStock >= @StockMin AND UnitsInStock <= @StockMax)";
            AddToWhere(whereStockPerUnitMinMax);
            cmd.Parameters.AddWithValue("StockMin", TextBoxStockPerUnit_min.Text);
            cmd.Parameters.AddWithValue("StockMax", TextBoxStockPerUnit_max.Text);
        }
        else
        {
            if (TextBoxStockPerUnit_min.Text != "")
            {
                whereStockPerUnitMin = "UnitsInStock >= @StockMin";
                AddToWhere(whereQuantityPerUnitMin);
                cmd.Parameters.AddWithValue("StockMin", TextBoxStockPerUnit_min.Text);
            }
            else { }


            if (TextBoxStockPerUnit_max.Text != "")
            {
                whereStockPerUnitMax = "UnitsInStock <= @StockMax";
                AddToWhere(whereQuantityPerUnitMax);
                cmd.Parameters.AddWithValue("StockMax", TextBoxStockPerUnit_max.Text);
            }
        }

        string whereDiscontinued = "";
        string whereNotDiscontinued = "";
        string whereBothDiscontinued = "";
        if ((CheckBox_Discontinued.Checked && CheckBox_NotDiscontinued.Checked) || (!CheckBox_Discontinued.Checked && !CheckBox_NotDiscontinued.Checked))
        {
            
        }
        else
        {
            if (CheckBox_Discontinued.Checked)
            {
                whereDiscontinued = "Discontinued = @Discontinued";
                AddToWhere(whereDiscontinued);
                cmd.Parameters.AddWithValue("@Discontinued", "1");
            }
            if (CheckBox_NotDiscontinued.Checked)
            {
                whereNotDiscontinued = "Discontinued = @Discontinued";
                AddToWhere(whereNotDiscontinued);
                cmd.Parameters.AddWithValue("@Discontinued", "0");
            }
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

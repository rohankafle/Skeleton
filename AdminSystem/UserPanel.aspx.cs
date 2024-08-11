using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_ConfirmDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindProductsGrid();
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        // Clear the session
        Session.Clear();
        Session.Abandon();

        // Redirect to the login page
        Response.Redirect("Product_User_Login.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string keyword = txtSearch.Text.Trim();

        ClsProductsCollection products = new ClsProductsCollection();
        products.FilterByName(keyword);

        gvProducts.DataSource = products.ProductsList;
        gvProducts.DataBind();
    }

    protected void btnClearFilter_Click(object sender, EventArgs e)
    {
        txtSearch.Text = string.Empty;
        BindProductsGrid();
    }

    private void BindProductsGrid()
    {
        ClsProductsCollection products = new ClsProductsCollection();
        gvProducts.DataSource = products.ProductsList;
        gvProducts.DataBind();
    }
}
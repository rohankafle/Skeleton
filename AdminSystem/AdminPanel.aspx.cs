using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1Viewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindProductsGrid();
        }
    }

    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        ClsProductsCollection products = new ClsProductsCollection();
        ClsProducts product = new ClsProducts
        {
            CategoryId = Convert.ToInt32(txtCategoryId.Text),
            Name = txtName.Text,
            Description = txtDescription.Text,
            Price = Convert.ToDecimal(txtPrice.Text),
            Quantity = Convert.ToInt32(txtQuantity.Text)
        };
        products.ThisProduct = product;
        products.Add();

        lblMessage.ForeColor = System.Drawing.Color.Green;
        lblMessage.Text = "Product added successfully!";
        ClearForm();
        BindProductsGrid();
    }

    protected void btnUpdateProduct_Click(object sender, EventArgs e)
    {
        ClsProductsCollection products = new ClsProductsCollection();
        products.ThisProduct.ProductId = Convert.ToInt32(hfProductId.Value);
        products.ThisProduct.CategoryId = Convert.ToInt32(txtCategoryId.Text);
        products.ThisProduct.Name = txtName.Text;
        products.ThisProduct.Description = txtDescription.Text;
        products.ThisProduct.Price = Convert.ToDecimal(txtPrice.Text);
        products.ThisProduct.Quantity = Convert.ToInt32(txtQuantity.Text);
        products.Update();

        lblMessage.ForeColor = System.Drawing.Color.Green;
        lblMessage.Text = "Product updated successfully!";
        ClearForm();
        BindProductsGrid();
        btnAddProduct.Visible = true;
        btnUpdateProduct.Visible = false;
    }

    protected void gvProducts_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int productId = Convert.ToInt32(gvProducts.DataKeys[e.NewEditIndex].Value);
        ClsProductsCollection products = new ClsProductsCollection();
        products.ThisProduct.Find(productId);

        hfProductId.Value = products.ThisProduct.ProductId.ToString();
        txtCategoryId.Text = products.ThisProduct.CategoryId.ToString();
        txtName.Text = products.ThisProduct.Name;
        txtDescription.Text = products.ThisProduct.Description;
        txtPrice.Text = products.ThisProduct.Price.ToString();
        txtQuantity.Text = products.ThisProduct.Quantity.ToString();

        btnAddProduct.Visible = false;
        btnUpdateProduct.Visible = true;
    }

    protected void gvProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        ClearForm();
        btnAddProduct.Visible = true;
        btnUpdateProduct.Visible = false;
    }

    protected void gvProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int productId = Convert.ToInt32(gvProducts.DataKeys[e.RowIndex].Value);
        ClsProductsCollection products = new ClsProductsCollection();
        products.Delete(productId);

        lblMessage.ForeColor = System.Drawing.Color.Green;
        lblMessage.Text = "Product deleted successfully!";
        BindProductsGrid();
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
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        // Clear the session
        Session.Clear();
        Session.Abandon();

        // Redirect to the login page
        Response.Redirect("Product_User_Login.aspx");
    }

    private void ClearForm()
    {
        txtCategoryId.Text = string.Empty;
        txtName.Text = string.Empty;
        txtDescription.Text = string.Empty;
        txtPrice.Text = string.Empty;
        txtQuantity.Text = string.Empty;
        hfProductId.Value = string.Empty;
    }
}
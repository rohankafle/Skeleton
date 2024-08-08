using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Add any necessary initialization code here
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        // Retrieve email and password from input fields
        string email = txtEmail.Text.Trim();
        string password = txtPassword.Text.Trim(); // Plain text password

        // Create an instance of the collection class
        ClsProductUsersCollection userCollection = new ClsProductUsersCollection();

        // Check if the email is registered
        if (userCollection.IsEmailRegistered(email))
        {
            // Filter by email to get the user details
            userCollection.FilterByName(email);

            // Ensure there is exactly one user with this email
            if (userCollection.Count == 1)
            {
                ClsProductUsers user = userCollection.ThisUser;

                // Compare the plain text password
                if (user.Password == password)
                {
                    // Redirect to dashboard or another page upon successful login
                    Response.Redirect("Product_User_Dashboard.aspx");
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Invalid password.";
                }
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Invalid email.";
            }
        }
        else
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Email not registered.";
        }
    }
}
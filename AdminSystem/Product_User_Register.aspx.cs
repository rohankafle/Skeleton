using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product_user_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Any page load logic can go here
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        // Create a new instance of the ClsProductUsersCollection
        ClsProductUsersCollection userCollection = new ClsProductUsersCollection();

        // Create a new instance of ClsProductUsers and populate its properties
        ClsProductUsers newUser = new ClsProductUsers
        {
            FirstName = txtFirstName.Text.Trim(),
            LastName = txtLastName.Text.Trim(),
            Email = txtEmail.Text.Trim(),
            Address = txtAddress.Text.Trim(),
            Password = txtPassword.Text.Trim(), // Ensure this is securely handled in a real application
            Role = ddlRole.SelectedValue,
            IsActive = chkIsActive.Checked
        };

        // Validate user input
        string validationError = newUser.Valid(newUser.FirstName, newUser.LastName, newUser.Email, newUser.Address, newUser.Password, newUser.Role, newUser.IsActive.ToString());

        if (string.IsNullOrEmpty(validationError))
        {
            // Check if the email is already registered
            if (!userCollection.IsEmailRegistered(newUser.Email))
            {
                // Assign the new user to the collection
                userCollection.ThisUser = newUser;

                // Add the new user and get the user ID
                int userId = userCollection.Add();
                if (userId > 0)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Registration Unsuccessful!";
                }
                else
                {
                    lblMessage.Text = "Registration successful!.";
                }
                Response.Redirect("Product_User_Login.aspx");
            }
            else
            {
                lblMessage.Text = "Error: This email is already registered.";
            }
        }
        else
        {
            lblMessage.Text = validationError;
        }
    }
}
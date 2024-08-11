using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product_User_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnLogin_Click(object sender, EventArgs e)

    {

        // Trim whitespace from the input values

        string email = txtEmail.Text.Trim();

        string password = txtPassword.Text.Trim();



        // Create an instance of ClsProductUsers to interact with the user data

        ClsProductUsers user = new ClsProductUsers();



        // Attempt to find the user by email and password

        if (user.FindUser(email, password))

        {

            // Check if the user account is active

            if (user.IsActive)

            {

                // Store user details in session variables

                Session["UserId"] = user.UserId;

                Session["UserRole"] = user.Role;

                Session["UserName"] = string.Format("{0} {1}", user.FirstName, user.LastName);



                // Redirect based on the user's role

                if (user.Role == "Admin")

                {

                    Response.Redirect("AdminPanel.aspx");

                }

                else if (user.Role == "User")

                {

                    Response.Redirect("UserPanel.aspx");

                }

                else

                {

                    lblMessage.Text = "Invalid role. Please contact the administrator.";

                }

            }

            else

            {

                lblMessage.Text = "Your account is inactive. Please contact the administrator.";

            }

        }

        else

        {

            lblMessage.Text = "Invalid email or password. Please try again.";

        }

    }
    }


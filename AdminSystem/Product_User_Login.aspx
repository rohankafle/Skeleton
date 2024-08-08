<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product_User_Login.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(135deg, #71b7e6, #9b59b6);
            height: 100vh;
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .login-container {
            background: rgba(255, 255, 255, 0.8);
            border-radius: 16px;
            box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
            backdrop-filter: blur(10px);
            -webkit-backdrop-filter: blur(10px);
            border: 1px solid rgba(255, 255, 255, 0.3);
            padding: 30px;
            max-width: 400px;
            width: 100%;
            text-align: center;
        }
        .login-container h2 {
            margin-bottom: 20px;
        }
        .login-container table {
            width: 100%;
            margin: 0 auto;
        }
        .login-container table td {
            padding: 10px 0;
        }
        .login-container table td:first-child {
            text-align: right;
            padding-right: 10px;
        }
        .login-container table td:last-child {
            text-align: left;
        }
        .login-container table td input[type="text"],
        .login-container table td input[type="password"] {
            width: 100%;
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .login-container table td input[type="button"] {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            background-color: #007bff;
            color: white;
            cursor: pointer;
        }
        .login-container table td input[type="button"]:hover {
            background-color: #0056b3;
        }
        .login-container .message {
            margin-top: 10px;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            <table>
                <tr>
                    <td>Email:</td>
                    <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserPanel.aspx.cs" Inherits="_1_ConfirmDelete" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Panel - Browse Products</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(135deg, #f6d365 0%, #fda085 100%);
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }

        .container {
            max-width: 1000px;
            width: 100%;
            padding: 20px;
            background: rgba(255, 255, 255, 0.1);
            border-radius: 15px;
            box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
            backdrop-filter: blur(10px);
            -webkit-backdrop-filter: blur(10px);
            border: 1px solid rgba(255, 255, 255, 0.3);
            color: #333;
            position: relative;
        }

        .logout-button {
            position: absolute;
            top: 20px;
            right: 20px;
            padding: 10px 20px;
            background-color: #ff4d4d;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .logout-button:hover {
            background-color: #e60000;
        }

        h2 {
            text-align: center;
            color: #444;
            margin-bottom: 20px;
        }

        fieldset {
            border: none;
            margin-bottom: 20px;
        }

        legend {
            font-size: 1.2em;
            margin-bottom: 10px;
            color: #444;
        }

        label {
            display: block;
            margin-bottom: 5px;
            color: #666;
        }

        input[type="text"],
        input[type="number"],
        input[type="password"],
        input[type="email"],
        textarea {
            width: calc(100% - 22px);
            padding: 10px;
            margin-bottom: 10px;
            border: none;
            border-radius: 5px;
            background: rgba(255, 255, 255, 0.7);
            box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.1);
        }

        input[type="text"]:focus,
        input[type="number"]:focus,
        input[type="password"]:focus,
        input[type="email"]:focus,
        textarea:focus {
            outline: none;
            background: rgba(255, 255, 255, 0.9);
        }

        button,
        input[type="submit"],
        input[type="button"] {
            display: inline-block;
            padding: 10px 20px;
            margin-top: 10px;
            border: none;
            border-radius: 5px;
            background-color: #4CAF50;
            color: white;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        button:hover,
        input[type="submit"]:hover,
        input[type="button"]:hover {
            background-color: #45a049;
        }

        .gridview-container {
            margin-top: 20px;
        }

        .gridview-container table {
            width: 100%;
            border-collapse: collapse;
            border-radius: 10px;
            overflow: hidden;
        }

        .gridview-container th,
        .gridview-container td {
            padding: 10px;
            text-align: left;
            background: rgba(255, 255, 255, 0.5);
            backdrop-filter: blur(10px);
            -webkit-backdrop-filter: blur(10px);
            border-bottom: 1px solid rgba(255, 255, 255, 0.3);
        }

        .gridview-container th {
            background-color: rgba(0, 123, 255, 0.5);
            color: white;
        }

        .gridview-container tr:hover td {
            background-color: rgba(0, 123, 255, 0.2);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Logout Button -->
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="logout-button" OnClick="btnLogout_Click" />

            <h2>Browse Products</h2>
            
            <!-- Filter/Search Section -->
            <fieldset>
                <legend>Search Products</legend>
                <label for="txtSearch">Search by Name:</label>
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter" OnClick="btnClearFilter_Click" />
            </fieldset>

            <!-- Products Grid -->
            <div class="gridview-container">
                <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductId">
                    <Columns>
                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" ReadOnly="True" />
                        <asp:BoundField DataField="CategoryId" HeaderText="Category ID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPanel.aspx.cs" Inherits="_1Viewer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Panel - Manage Products</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: linear-gradient(135deg, #c3cfe2 0%, #c3cfe2 100%);
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
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


        .container {
            max-width: 900px;
            width: 100%;
            padding: 20px;
            background: rgba(255, 255, 255, 0.1);
            border-radius: 15px;
            box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
            backdrop-filter: blur(10px);
            -webkit-backdrop-filter: blur(10px);
            border: 1px solid rgba(255, 255, 255, 0.3);
            color: #333;
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
    <script type="text/javascript">
        function confirmDelete() {
            return confirm('Are you sure you want to delete this product?');
        }

        function confirmLogout() {
            return confirm('Are you sure you want to log out?');
        }
    </script>
</head>
<body>

    <form id="form1" runat="server">
       <div class="container">
             <!-- Logout Button -->
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="logout-button" OnClientClick="return confirmLogout();" OnClick="btnLogout_Click" />

            <h2>Manage Products</h2>
            
            <!-- Add/Edit Product Section -->
            <fieldset>
                <legend>Add or Update Product</legend>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                <br /><br />
                <label for="CategoryId">Category ID:</label>
                <asp:TextBox ID="txtCategoryId" runat="server"></asp:TextBox>
                <br /><br />
                <label for="Name">Product Name:</label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <br /><br />
                <label for="Description">Description:</label>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                <br /><br />
                <label for="Price">Price:</label>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                <br /><br />
                <label for="Quantity">Quantity:</label>
                <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                <br /><br />
                <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" />
                <asp:Button ID="btnUpdateProduct" runat="server" Text="Update Product" OnClick="btnUpdateProduct_Click" Visible="False" />
                <asp:HiddenField ID="hfProductId" runat="server" />
            </fieldset>
            <br />

            <!-- Filter Section -->
            <fieldset>
                <legend>Find/Filter Products</legend>
                <label for="txtSearch">Search by Name:</label>
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                <asp:Button ID="btnClearFilter" runat="server" Text="Clear Filter" OnClick="btnClearFilter_Click" />
            </fieldset>
            <br />

            <!-- Products Grid -->
          <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductId"
                    OnRowEditing="gvProducts_RowEditing" 
                    OnRowCancelingEdit="gvProducts_RowCancelingEdit" 
                    OnRowDeleting="gvProducts_RowDeleting" 
                    OnClientClick="return confirmDelete();">
                    <Columns>
                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" ReadOnly="True" />
                        <asp:BoundField DataField="CategoryId" HeaderText="Category ID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>


        </div>
    </form>
</body>
</html>
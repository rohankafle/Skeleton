using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ClsProductsCollection
    {
        // Private data member for the list
        private List<ClsProducts> mProductsList = new List<ClsProducts>();
        // Private data member for ThisProduct
        private ClsProducts mThisProduct = new ClsProducts();

        // Public property for the ProductsList
        public List<ClsProducts> ProductsList
        {
            get { return mProductsList; }
            set { mProductsList = value; }
        }

        // Public property for Count
        public int Count
        {
            get { return mProductsList.Count; }
        }

        // Public property for ThisProduct
        public ClsProducts ThisProduct
        {
            get { return mThisProduct; }
            set { mThisProduct = value; }
        }

        // Constructor for the class
        public ClsProductsCollection()
        {
            // Object for the data connection
            clsDataConnection DB = new clsDataConnection();
            // Execute the stored procedure to get all products
            DB.Execute("sproc_tblProducts_SelectAll");
            // Populate the array list with the data table
            PopulateArray(DB);
        }

        // Method to populate the array list based on the data table in the parameter DB
        void PopulateArray(clsDataConnection DB)
        {
            int Index = 0;
            int RecordCount = DB.Count;
            mProductsList = new List<ClsProducts>();

            while (Index < RecordCount)
            {
                ClsProducts AProduct = new ClsProducts();
                AProduct.ProductId = Convert.ToInt32(DB.DataTable.Rows[Index]["ProductId"]);
                AProduct.CategoryId = Convert.ToInt32(DB.DataTable.Rows[Index]["CategoryId"]);
                AProduct.Name = Convert.ToString(DB.DataTable.Rows[Index]["Name"]);
                AProduct.Description = Convert.ToString(DB.DataTable.Rows[Index]["Description"]);
                AProduct.Price = Convert.ToDecimal(DB.DataTable.Rows[Index]["Price"]);
                AProduct.Quantity = Convert.ToInt32(DB.DataTable.Rows[Index]["Quantity"]);
                mProductsList.Add(AProduct);
                Index++;
            }
        }

        // Method to add a new product
        public int Add()
        {
            // Create an instance of the data connection class
            clsDataConnection DB = new clsDataConnection();

            // Add parameters for the stored procedure
            DB.AddParameter("@CategoryId", mThisProduct.CategoryId);
            DB.AddParameter("@Name", mThisProduct.Name);
            DB.AddParameter("@Description", mThisProduct.Description);
            DB.AddParameter("@Price", mThisProduct.Price);
            DB.AddParameter("@Quantity", mThisProduct.Quantity);

            // Execute the stored procedure and return the ProductId
            return Convert.ToInt32(DB.Execute("sproc_tblProducts_Insert"));
        }

        // Method to update an existing product
        public void Update()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@ProductId", mThisProduct.ProductId);
            DB.AddParameter("@CategoryId", mThisProduct.CategoryId);
            DB.AddParameter("@Name", mThisProduct.Name);
            DB.AddParameter("@Description", mThisProduct.Description);
            DB.AddParameter("@Price", mThisProduct.Price);
            DB.AddParameter("@Quantity", mThisProduct.Quantity);
            DB.Execute("sproc_tblProducts_Update");
        }
        public void FilterByName(string keyword)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Keyword", "%" + keyword + "%");
            DB.Execute("sproc_tblProducts_FilterByName");  // Ensure you create this stored procedure in SQL Server
            PopulateArray(DB);
        }


        // Method to delete a product by ProductId
        public void Delete(int productId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@ProductId", productId);
            DB.Execute("sproc_tblProducts_Delete");
        }
    }
}
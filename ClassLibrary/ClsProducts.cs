using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ClsProducts
    {
        // Private data members
        private int mProductId;
        private int mCategoryId;
        private string mName;
        private string mDescription;
        private decimal mPrice;
        private int mQuantity;

        // Public properties
        public int ProductId
        {
            get { return mProductId; }
            set { mProductId = value; }
        }

        public int CategoryId
        {
            get { return mCategoryId; }
            set { mCategoryId = value; }
        }

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        public decimal Price
        {
            get { return mPrice; }
            set { mPrice = value; }
        }

        public int Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }

        // Method to find a product by ProductId
        public bool Find(int productId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@ProductId", productId);
            DB.Execute("sproc_tblProducts_FindByProductId");

            if (DB.Count == 1)
            {
                mProductId = Convert.ToInt32(DB.DataTable.Rows[0]["ProductId"]);
                mCategoryId = Convert.ToInt32(DB.DataTable.Rows[0]["CategoryId"]);
                mName = Convert.ToString(DB.DataTable.Rows[0]["Name"]);
                mDescription = Convert.ToString(DB.DataTable.Rows[0]["Description"]);
                mPrice = Convert.ToDecimal(DB.DataTable.Rows[0]["Price"]);
                mQuantity = Convert.ToInt32(DB.DataTable.Rows[0]["Quantity"]);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Validation method for the product details
        public string Valid(string name, string description, string price, string quantity)
        {
            string Error = "";

            // Name validation
            if (string.IsNullOrEmpty(name))
            {
                Error += "The Name cannot be blank. ";
            }
            else if (name.Length > 100)
            {
                Error += "The Name must be less than 100 characters. ";
            }

            // Price validation
            decimal priceValue;
            if (!decimal.TryParse(price, out priceValue) || priceValue < 0)
            {
                Error += "The Price must be a positive decimal value. ";
            }

            // Quantity validation
            int quantityValue;
            if (!int.TryParse(quantity, out quantityValue) || quantityValue < 0)
            {
                Error += "The Quantity must be a positive integer value. ";
            }

            return Error;
        }
    }
}
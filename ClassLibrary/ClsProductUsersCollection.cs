using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary
{
    public class ClsProductUsersCollection
    {
        // Private data member for the list
        private List<ClsProductUsers> mUsersList = new List<ClsProductUsers>();
        // Private data member for ThisUser
        private ClsProductUsers mThisUser = new ClsProductUsers();

        // Public property for the UsersList
        public List<ClsProductUsers> UsersList
        {
            get { return mUsersList; }
            set { mUsersList = value; }
        }

        // Public property for Count
        public int Count
        {
            get { return mUsersList.Count; }
        }

        // Public property for ThisUser
        public ClsProductUsers ThisUser
        {
            get { return mThisUser; }
            set { mThisUser = value; }
        }

        // Constructor for the class
        public ClsProductUsersCollection()
        {
            // Object for the data connection
            clsDataConnection DB = new clsDataConnection();
            // Execute the stored procedure to get all users
            DB.Execute("sproc_tblProductUsers_SelectAll");
            // Populate the array list with the data table
            PopulateArray(DB);
        }

        // Method to populate the array list based on the data table in the parameter DB
        void PopulateArray(clsDataConnection DB)
        {
            int Index = 0;
            int RecordCount = DB.Count;
            mUsersList = new List<ClsProductUsers>();

            while (Index < RecordCount)
            {
                ClsProductUsers AUser = new ClsProductUsers();
                AUser.UserId = Convert.ToInt32(DB.DataTable.Rows[Index]["UserId"]);
                AUser.FirstName = Convert.ToString(DB.DataTable.Rows[Index]["FirstName"]);
                AUser.LastName = Convert.ToString(DB.DataTable.Rows[Index]["LastName"]);
                AUser.Email = Convert.ToString(DB.DataTable.Rows[Index]["Email"]);
                AUser.Address = Convert.ToString(DB.DataTable.Rows[Index]["Address"]);
                AUser.Password = Convert.ToString(DB.DataTable.Rows[Index]["Password"]);
                AUser.Role = Convert.ToString(DB.DataTable.Rows[Index]["Role"]);
                AUser.IsActive = Convert.ToBoolean(DB.DataTable.Rows[Index]["IsActive"]);
                mUsersList.Add(AUser);
                Index++;
            }
        }

        // Method to filter users by name
        public void FilterByName(string keyword)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Keyword", "%" + keyword + "%");
            DB.Execute("sproc_tblProductUsers_FilterByName");
            PopulateArray(DB);
        }

        // Method to check if an email is already registered
        public bool IsEmailRegistered(string email)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Email", email);
            DB.Execute("sproc_tblProductUsers_FindByEmail");
            return DB.Count == 1;
        }

        // Method to add a new user
        public int Add()
        {
            // Create an instance of the data connection class
            clsDataConnection DB = new clsDataConnection();

            // Add parameters for the stored procedure
            DB.AddParameter("@FirstName", mThisUser.FirstName);
            DB.AddParameter("@LastName", mThisUser.LastName);
            DB.AddParameter("@Email", mThisUser.Email);
            DB.AddParameter("@Address", mThisUser.Address);
            DB.AddParameter("@Password", mThisUser.Password);
            DB.AddParameter("@Role", mThisUser.Role);
            DB.AddParameter("@IsActive", mThisUser.IsActive);

            // Execute the stored procedure and return the UserId
            return Convert.ToInt32(DB.Execute("sproc_tblProductUsers_Insert"));
        }
       



        // Method to delete a user by UserId
        public void Delete(int userId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.Execute("sproc_tblProductUsers_Delete");
        }

        // Method to update an existing user
        public void Update()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", mThisUser.UserId);
            DB.AddParameter("@FirstName", mThisUser.FirstName);
            DB.AddParameter("@LastName", mThisUser.LastName);
            DB.AddParameter("@Email", mThisUser.Email);
            DB.AddParameter("@Address", mThisUser.Address);
            DB.AddParameter("@Password", mThisUser.Password);
            DB.AddParameter("@Role", mThisUser.Role);
            DB.AddParameter("@IsActive", mThisUser.IsActive);
            DB.Execute("sproc_tblProductUsers_Update");
        }
    }
}
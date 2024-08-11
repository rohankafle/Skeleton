using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ClsProductUsers
    {
        // Private data members
        private int mUserId;
        private string mFirstName;
        private string mLastName;
        private string mEmail;
        private string mAddress;
        private string mPassword;
        private string mRole;
        private bool mIsActive;

        // Public properties
        public int UserId
        {
            get { return mUserId; }
            set { mUserId = value; }
        }

        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value; }
        }

        public string LastName
        {
            get { return mLastName; }
            set { mLastName = value; }
        }

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }

        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public string Role
        {
            get { return mRole; }
            set { mRole = value; }
        }

        public bool IsActive
        {
            get { return mIsActive; }
            set { mIsActive = value; }
        }

        // Method to find a user by UserId
        public bool Find(int userId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@UserId", userId);
            DB.Execute("sproc_tblProductUsers_FindByUserId");

            if (DB.Count == 1)
            {
                mUserId = Convert.ToInt32(DB.DataTable.Rows[0]["UserId"]);
                mFirstName = Convert.ToString(DB.DataTable.Rows[0]["FirstName"]);
                mLastName = Convert.ToString(DB.DataTable.Rows[0]["LastName"]);
                mEmail = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mAddress = Convert.ToString(DB.DataTable.Rows[0]["Address"]);
                mPassword = Convert.ToString(DB.DataTable.Rows[0]["Password"]);
                mRole = Convert.ToString(DB.DataTable.Rows[0]["Role"]);
                mIsActive = Convert.ToBoolean(DB.DataTable.Rows[0]["IsActive"]);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method to find a user by Email and Password
        public bool FindUser(string email, string password)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@Email", email);
            DB.AddParameter("@Password", password);
            DB.Execute("sproc_tblProductUsers_FindByEmailAndPassword");

            if (DB.Count == 1)
            {
                mUserId = Convert.ToInt32(DB.DataTable.Rows[0]["UserId"]);
                mFirstName = Convert.ToString(DB.DataTable.Rows[0]["FirstName"]);
                mLastName = Convert.ToString(DB.DataTable.Rows[0]["LastName"]);
                mEmail = Convert.ToString(DB.DataTable.Rows[0]["Email"]);
                mAddress = Convert.ToString(DB.DataTable.Rows[0]["Address"]);
                mPassword = Convert.ToString(DB.DataTable.Rows[0]["Password"]);
                mRole = Convert.ToString(DB.DataTable.Rows[0]["Role"]);
                mIsActive = Convert.ToBoolean(DB.DataTable.Rows[0]["IsActive"]);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Validation method
        public string Valid(string firstName, string lastName, string email, string address, string password, string role, string isActive)
        {
            string Error = "";

            // Existing validation rules

            // Role must be either 'Admin' or 'User'
            if (role != "Admin" && role != "User")
            {
                Error += "The role must be either 'Admin' or 'User'. ";
            }

            // IsActive must be either 'true' or 'false'
            bool isActiveBool;
            if (!bool.TryParse(isActive, out isActiveBool))
            {
                Error += "The active status must be either 'true' or 'false'. ";
            }

            return Error;
        }
    }
}
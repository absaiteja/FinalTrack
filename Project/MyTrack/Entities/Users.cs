using SqlConnectors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MyTrack.Entities
{
    public class Users
    {
        [Display(Name = "UserID", Description = "PrimaryKey")]
        public int UserID { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "ContactNumber")]
        public string ContactNumber { get; set; }

        [Display(Name = "EmailID")]
        public string EmailID { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }



        public bool Create(object[] strValues)
        {
            bool blnResult = true;
            string strQuery = @"INSERT INTO [Users]
                              ([UserName] ,[ContactNumber],[EmailID],[Password],[Gender]) VALUES
                               (@UserName,@ContactNumber,@EmailID,@Password,@Gender)";
            string[] strParameters = { "UserName", "ContactNumber", "EmailID", "Password", "Gender" };
            object[] strParametersValues = strValues;
            SqlConnectors.DBOperations objparameteres = new SqlConnectors.DBOperations(Properties.Settings.Default.Connection);
            blnResult = objparameteres.ExecuteQuery(strQuery, strParameters, strParametersValues);
            return blnResult;
        }
        public bool Update(object[] strValues)
        {
            string strQuery = @" UPDATE [Users]
                               SET [UserName] = @UserName
                                  ,[ContactNumber] = @ContactNumber, 
                                  ,[EmailID] = @EmailID,
                                  ,[Password] = @Password,
                                  ,[Gender] = @Gender
                                   WHERE UserID = @UserID";
            string[] strParameters = { "UserName", "ContactNumber", "EmailID", "Password", "Gender" };
            object[] strParametersValues = strValues;
            DBOperations objparameteres = new DBOperations(Properties.Settings.Default.Connection);
            objparameteres.ExecuteQuery(strQuery, strParameters, strParametersValues);
            return true;
        }
        public static Users Get(string strParameterValues)
        {
            string strQuery = @"SELECT [UserID]
                                      ,[UserName]
                                      ,[ContactNumber]
                                      ,[Password]
                                      ,[Gender]
                                      ,[EmailID]
                                  FROM [Users] 
                                  WHERE EmailID = @EmailID ";
            Users objUsers = new Users();
            string strConnection = Properties.Settings.Default.Connection;
            string[] strparameters = { "EmailID" };
            object[] strArrParameterValues = { strParameterValues };
            DataTable dtRetval = new DataTable();
            int intTemp = 0;
            dtRetval = DBOperations.ExecuteQueryForAll(strConnection, strQuery, strparameters, strArrParameterValues);
            if (dtRetval.Rows.Count > 0)
            {
                int.TryParse(dtRetval.Rows[0]["UserID"].ToString(), out intTemp);
                objUsers.UserID = intTemp;
                objUsers.UserName = dtRetval.Rows[0]["UserName"] != null ? dtRetval.Rows[0]["UserName"].ToString() : string.Empty;
                objUsers.ContactNumber = dtRetval.Rows[0]["ContactNumber"] != null ? dtRetval.Rows[0]["ContactNumber"].ToString() : string.Empty;
                objUsers.Password = dtRetval.Rows[0]["Password"] != null ? dtRetval.Rows[0]["Password"].ToString() : string.Empty;
                objUsers.Gender = dtRetval.Rows[0]["Gender"] != null ? dtRetval.Rows[0]["Gender"].ToString() : string.Empty;
                objUsers.Gender = dtRetval.Rows[0]["EmailID"] != null ? dtRetval.Rows[0]["EmailID"].ToString() : string.Empty;
            }
            return objUsers;
        }
        public static List<Users> GetAll()
        {
            List<Users> lstUsers = new List<Users>();
            Users objUsers = new Users();
            string strQuery = @"SELECT [UserID]
                                      ,[UserName]
                                      ,[ContactNumber]
                                      ,[EmailID]
                                      ,[Password]
                                      ,[Gender]
                                  FROM [Users]";
            string strConnection = Properties.Settings.Default.Connection;
            DataTable dtRetval = new DataTable();
            int intTemp = 0;
            dtRetval = DBOperations.ExecuteQueryForAll(strConnection, strQuery, new string[] { }, new object[] { });
            if (dtRetval.Rows.Count > 0)
            {
                for (int i = 0; i < dtRetval.Rows.Count; i++)
                {
                    objUsers = new Users();
                    int.TryParse(dtRetval.Rows[i]["UserID"].ToString(), out intTemp);
                    objUsers.UserID = intTemp;
                    objUsers.UserName = dtRetval.Rows[i]["UserName"] != null ? dtRetval.Rows[i]["UserName"].ToString() : string.Empty;
                    objUsers.ContactNumber = dtRetval.Rows[i]["ContactNumber"] != null ? dtRetval.Rows[i]["ContactNumber"].ToString() : string.Empty;
                    objUsers.EmailID = dtRetval.Rows[i]["EmailID"] != null ? dtRetval.Rows[i]["EmailID"].ToString() : string.Empty;
                    objUsers.Password = dtRetval.Rows[i]["Password"] != null ? dtRetval.Rows[i]["Password"].ToString() : string.Empty;
                    objUsers.Gender = dtRetval.Rows[i]["Gender"] != null ? dtRetval.Rows[i]["Gender"].ToString() : string.Empty;
                    lstUsers.Add(objUsers);
                }
            }
            return lstUsers;
        }
    }
}
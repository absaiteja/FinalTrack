using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyTrack
{
    /// <summary>
    /// Summary description for Users
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Users : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string GetPassword(string strEmailId)
        {
            Entities.Users objUsers = new Entities.Users();
            objUsers = Entities.Users.Get(strEmailId);
            return objUsers.Password;
        }
         [WebMethod]
        public bool CreateService(object[] obj)
        {
            Entities.Users objUsers = new Entities.Users();
            bool blnresult = objUsers.Create(obj);
            return blnresult;
        }
        [WebMethod]

        //Methd for updating the users

        public bool UpdateService(object[] data)
        {
            Entities.Users objUsers = new Entities.Users();
            bool blnresult = objUsers.Update(data);
            return blnresult;
        }
        [WebMethod] 

        // Method for getting all the users

        public bool GetAll()
        {
            List<Entities.Users> lstUsers = new List<Entities.Users>();
            lstUsers = Entities.Users.GetAll();
            if (lstUsers.Count < 0)
            {
                return false;
            }
            else
                return true;
        }
        // Method For getting Unique Users login
        [WebMethod]
        public bool GetUserSDetails(object[] objGetTrainDetails)
        {
            Entities.Users objUsers = new Entities.Users();
            objUsers = Entities.Users.Get(objGetTrainDetails[0].ToString());
            if ( objUsers.Password == (objGetTrainDetails[1].ToString()))
            {
                return true;
            }
            return false;
        }
    }
}
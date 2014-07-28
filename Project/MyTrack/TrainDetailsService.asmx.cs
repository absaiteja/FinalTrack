using MyTrack.Entities;
using MyTrack.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

namespace MyTrack
{
    /// <summary>
    /// Summary description for TrainDetailsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TrainDetailsService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public bool GetPassword(object[] EmailID)
        {
            Entities.Users objUsers = new Entities.Users();
            objUsers = Entities.Users.Get(EmailID[0].ToString());
            MailMessage Msg = new MailMessage();
            Msg.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
            // Sender e-mail address.
            Msg.From = new MailAddress("vani409.dasari@gmail.com");
            // Recipient e-mail address.
            Msg.To.Add("vamsee431@gmail.com");
          
            Msg.Subject = "Password";
            Msg.Body = objUsers.Password; 

            // your remote SMTP server IP.
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("vani409.dasari@gmail.com", "mummydaddy");
            smtp.EnableSsl = true;
            smtp.Send(Msg);
            return true;
        }
        [WebMethod]
        public Response CreateTrainService(object[] obj)
        {
            TrainDetails objTD = new Entities.TrainDetails();
            Response objResponse = objTD.CreateTrain(obj);
            if (objResponse.id == Properties.Settings.Default.SuccessId)
                return objResponse;
            else
                return objResponse;
        }
        [WebMethod]
        public Response UpdateTrainService(object[] objUpdatedTrains)
        {
            TrainDetails objTD = new TrainDetails();

            Response objResponse = objTD.UpdateTrain(objUpdatedTrains);
            if (objResponse.id == Properties.Settings.Default.SuccessId)
                return objResponse;
            else
                return objResponse;
        }
        [WebMethod]
        public object GetTrainService(object[] objGetTrainDetails)
        {
            Entities.TrainDetails objTD = new Entities.TrainDetails();
            int intTrainNumber = Convert.ToInt32(objGetTrainDetails[0]);
            objTD = TrainDetails.Get(intTrainNumber);
            return objTD;
        }
        [WebMethod]
        public Response DeleteTrainService(object[] objDeleteTrainDetails)
        {
            TrainDetails objTD = new TrainDetails();
            Response objResponse = objTD.DeleteTrain(objDeleteTrainDetails);
            if (objResponse.id == Properties.Settings.Default.SuccessId)
                return objResponse;
            else
                return objResponse;
        }
      
        [WebMethod]
        public List<TrainDetails> GetAllTrainsService()
        {
            Entities.TrainDetails objTD = new Entities.TrainDetails();
            List<Entities.TrainDetails> lstTD = new List<Entities.TrainDetails>();
            lstTD = objTD.GetAllTrains();
            return lstTD;
        }
    }
}

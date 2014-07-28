using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.Services;

namespace MyTrack
{
    /// <summary>
    /// Summary description for MailService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MailService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public void SendHTMLMail()
        {
            //StreamReader reader = new StreamReader(Server.MapPath("~/PrintTicket.aspx"));
            //string readFile = reader.ReadToEnd();
            //string myString = "";
            //myString = readFile;
            ////myString = myString.Replace("$$Admin$$", "Suresh Dasari");
            ////myString = myString.Replace("$$CompanyName$$", "Dasari Group");
            ////myString = myString.Replace("$$Email$$", "suresh@gmail.com");
            ////myString = myString.Replace("$$Website$$", "http://www.aspdotnet-suresh.com");
            //System.Web.Mail.MailMessage Msg = new System.Web.Mail.MailMessage();
            //MailAddress fromMail = new MailAddress("vani@gmail.com");
            //// Sender e-mail address.
            //Msg.From = Convert.ToString(fromMail);
            //// Recipient e-mail address.
            //Msg.To.Add(new MailAddress("vamsee431@gmail.com"));
            //// Subject of e-mail
            //Msg.Subject = "Send Mail with HTML File";
            //Msg.Body = myString.ToString();
            //Msg.IsBodyHtml = 
            //string sSmtpServer = "";
            //sSmtpServer = "10.2.69.121";
            //SmtpClient a = new SmtpClient();
            //a.Host = sSmtpServer;
            //a.Send(Msg);
            //reader.Dispose();
        }

    }
}

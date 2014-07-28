using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyTrack.Entities;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace MyTrack
{
    public partial class Ticket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strPnr = Session["Pnr"].ToString();
            Entities.Ticket objEnt = Entities.Ticket.GetFromPnr(strPnr);
            List<Entities.Passengers> lstPass = Entities.Passengers.GetAllPassengersByPnr(strPnr);
            lblDispTrainName.Text = objEnt.TrainName;
            lblPnr.Text = strPnr;
            lblTrainId.Text = objEnt.TicketNumber.ToString();
            lblTransactionId.Text = "34436";
            lblDateOfBooking.Text = objEnt.DateOfBooking;
            lblClass.Text = "First AC";
            lblFromNew.Text = objEnt.Source;
            lblDojNew.Text = objEnt.DateOfJourney;
            lblDoj.Text = objEnt.DateOfJourney;
            lblFrom.Text = objEnt.Source;
            lblToNew.Text = objEnt.Destination;
            lblTo.Text = objEnt.Destination;
            lblDistance.Text = "600";
            lblNoOfPassengers.Text = Convert.ToString(objEnt.NoOfPassengers);
            lblMobile.Text = "9985555554";
            lblEmailId.Text = objEnt.EmailId;
            lblFare.Text = objEnt.Fare.ToString();
            lblNameNew.Text = lstPass[0].Name;
            lblAgeNew.Text = lstPass[0].Age.ToString();
            lblGender.Text = lstPass[0].Gender;
            lblSeatNumber.Text = lstPass[0].SeatNumber.ToString();
            if (lstPass.Count == 2)
            {
                lblNameNew.Text = lstPass[1].Name;
                lblAgeNew.Text = lstPass[1].Age.ToString();
                lblGender.Text = lstPass[1].Gender;
                lblSeatNumber.Text = lstPass[1].SeatNumber.ToString();
            }
            if (lstPass.Count == 3)
            {
                lblNameNew.Text = lstPass[2].Name;
                lblAgeNew.Text = lstPass[2].Age.ToString();
                lblGender.Text = lstPass[2].Gender;
                lblSeatNumber.Text = lstPass[2].SeatNumber.ToString();
            }
            if (lstPass.Count == 4)
            {
                lblNameNew.Text = lstPass[3].Name;
                lblAgeNew.Text = lstPass[3].Age.ToString();
                lblGender.Text = lstPass[3].Gender;
                lblSeatNumber.Text = lstPass[3].SeatNumber.ToString();
            }



        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            MailMessage Msg = new MailMessage();
            Msg.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
            // Sender e-mail address.
            Msg.From = new MailAddress("vani409.dasari@gmail.com");
            // Recipient e-mail address.
            Msg.To.Add("vamsee431@gmail.com");
            StreamReader reader = new StreamReader(Server.MapPath("~/PrintTicket.aspx"));
            string readFile = reader.ReadToEnd();

            Msg.Subject = "Enquiry";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(readFile, null, "text/html");

            // your remote SMTP server IP.
            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("vani409.dasari@gmail.com", "mummydaddy");
            Msg.AlternateViews.Add(htmlView);

            smtp.EnableSsl = true;
            smtp.Send(Msg);
        }
       
    }
}
using MyTrack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyTrack
{
    public partial class UsersHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //string strTemp="<label>Test Date Of Journey Test Test:<span>*</span></label>";
            //lblDisplayHtml.Text = strTemp;
          
            //if (Page.Request.QueryString["GetTrains"] != null)
            //{
                
            //    Response.Write(GetAllTrains());
            //    Response.End();
                
              
            //}
        }
        public string GenerateRandomNumber()
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < 11; i++)
            {
                r += random.Next(0, 9).ToString();
            }
            return r;
        }

        protected void btnPnr_Click(object sender, EventArgs e)
        {
            Session["Pnr"] = GenerateRandomNumber();
            hdnPnr.Value = Session["Pnr"].ToString();
        }
        //private string GetAllTrains()
        //{
        //    TrainDetails objTrainDeatils = new TrainDetails();
        //    List<TrainDetails> lstTrainDetails = objTrainDeatils.GetAllTrains();
        //    JavaScriptSerializer objJs = new JavaScriptSerializer();
        //    string strTrains = objJs.Serialize(lstTrainDetails);
        //    return strTrains;
        //}
    }
}
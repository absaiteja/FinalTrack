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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          string  strTrainId = Page.Request.QueryString["Train"];
            if (Page.Request.QueryString["GetTrains"] != null)
            {
                Response.Write(GetAllTrains());
                Response.End();
            }
        }
        private string GetAllTrains()
        {
            TrainDetails objTrainDeatils = new TrainDetails();
            List<TrainDetails> lstTrainDetails = objTrainDeatils.GetAllTrains();
            JavaScriptSerializer objJs = new JavaScriptSerializer();
            string strTrains = objJs.Serialize(lstTrainDetails);
            return strTrains;
        }
    }
}
using MyTrack.Entities;
using MyTrack.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyTrack
{
    /// <summary>
    /// Summary description for FaresService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class FaresService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public Fares GetFareService(string objFaresValues)
        {
            Fares objFares = new Fares();
            int intTrainId = Convert.ToInt32(objFaresValues);
            objFares = Fares.Get(intTrainId);
            return objFares;
        }
        [WebMethod]
        public Response UpdateFareService(object[] objUpdatedFares)
        {
            Fares objFares = new Fares();
            Response objResponse = objFares.Update(objUpdatedFares);
            if (objResponse.id == Properties.Settings.Default.SuccessId)
                return objResponse;
            else
                return objResponse;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MyTrack.Entities;
using MyTrack.Utilities;

namespace MyTrack
{
    /// <summary>
    /// Summary description for UsersTrainDetailsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UsersTrainDetailsService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public List<Entities.UserTrainDetails> GetAllTrainsService()
        {
            Entities.UserTrainDetails objTD = new Entities.UserTrainDetails();
            List<Entities.UserTrainDetails> lstTD = new List<Entities.UserTrainDetails>();
            lstTD = objTD.GetAllTrains();
            return lstTD;
        }

        [WebMethod]
        public List<Entities.UserTrainDetails> GetSpecificTrainsbyFromToService()
        {
            Entities.UserTrainDetails objTD = new Entities.UserTrainDetails();
            List<Entities.UserTrainDetails> lstTD = new List<Entities.UserTrainDetails>();
            lstTD = objTD.GetAllTrains();
            return lstTD;
        }

        [WebMethod]
        public Utilities.Response CreateTrainService()
        {
            Entities.UserTrainDetails objtd = new Entities.UserTrainDetails();
            objtd.TrainName = "duronto";
            objtd.TrainNumber = 1;
            objtd.Source = "delhi";
            objtd.Destination = "hyderabad";
            objtd.Distance = 800;
            objtd.DepartureTime = "20:00";
            objtd.ArrivalTime = "12:00";
            Utilities.Response objres = objtd.CreateTrain();
            return objres;
        }

        [WebMethod]
        public Utilities.Response CreateTicketService(object[] obj)
        {
            Entities.Ticket objtk = new Entities.Ticket();
            Utilities.Response objres = objtk.CreateTicket(obj);
            return objres;
        }

        [WebMethod]
        public Utilities.Response CreatePassengerService(object[] objPs)
        {
            Entities.Passengers obPass= new Entities.Passengers();
            Utilities.Response objres = obPass.CreatePassengers(objPs);
            return objres;
        }
    }
}

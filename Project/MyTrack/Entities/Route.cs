using MyTrack.Utilities;
using SqlConnectors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MyTrack.Entities
{
    public class Route
    {
        const string Success_MSG = "Successfully {0} a Route";
        const string Failure_MSG = "Unable to {0} a Route";

        [Display(Name = "SNo")]
        public int SNo { get; set; }

        [Display(Name = "RouteId", Description = "Primarykey")]
        public int RouteId { get; set; }

        [Display(Name = "StationId")]
        public int StationId { get; set; }

        [Display(Name = "StationName")]
        public string StationName { get; set; }

        [Display(Name = "Fare")]
        public double Fare { get; set; }

        public bool Create()
        {
            string strConnection = Properties.Settings.Default.Connection;
            string[] strArrParameterName = { "StationId", "StationName", "Fare"};
            object[] objArrParameterValue = { this.StationId, this.StationName, this.Fare };
            string strQuery = @"INSERT INTO [Route]
                             ([StationId] ,[StationName] ,[Fare]) VALUES
                             (@StationId,@StationName,@Fare)";
            SqlConnectors.DBOperations objDBOperations = new SqlConnectors.DBOperations(strConnection);
            bool blnResult = objDBOperations.ExecuteQuery(strQuery, strArrParameterName, objArrParameterValue);
            if (!blnResult)
            {
                objDBOperations.CloseConnection();
                return true;
            }
            objDBOperations.CloseConnection();
            return false;


        }

        public Response Update()
        {
            string strConnection = Properties.Settings.Default.Connection;
            string strQuery = @"UPDATE [Route] SET [StationId] = @StationId,[StationName]= @StationName,
                                                           [Fare]=@Fare
                                                      WHERE RouteId = @RouteId";
            string[] strArrParameterName = { "RouteId", "StationId", "StationName", "Fare" };
            object[] objArrParameterValue = { this.RouteId, this.StationId, this.StationName, this.Fare };
            SqlConnectors.DBOperations objDBOperations = new SqlConnectors.DBOperations(strConnection);
            bool blnResult = objDBOperations.ExecuteQuery(strQuery, strArrParameterName, objArrParameterValue);

            if (!blnResult)
            {
                objDBOperations.CloseConnection();
                return new Response(9999, string.Format(Failure_MSG, "update"));
            }
            objDBOperations.CloseConnection();
            return new Response(5555, string.Format(Success_MSG, "updated"));
        }
        
       public Response Delete()
        {
            string strConnection = Properties.Settings.Default.Connection;
            string strQuery = @"DELETE FROM [Route]
                              WHERE RouteId = @RouteId";
            string[] strArrParameterName = { "RouteId", "StationId", "StationName", "Fare" };
            object[] objArrParameterValue = { this.RouteId, this.StationId, this.StationName, this.Fare };
            DBOperations objDBOperations = new DBOperations(strConnection);
            bool blnResult = objDBOperations.ExecuteQuery(strQuery, strArrParameterName, objArrParameterValue);

            if (!blnResult)
            {
                objDBOperations.CloseConnection();
                return new Response(9999, string.Format(Failure_MSG, "delete"));
            }
            objDBOperations.CloseConnection();
            return new Response(5555, string.Format(Success_MSG, "deleted"));
        }

        public static Route Get(int RouteId)
        {
            Route objRoute = new Route();
            string strQuery = @"SELECT [StationId], [StationName] ,[Fare] FROM [Route] WHERE RouteId = @RouteId";
            string[] strArrParameterName = {"RouteId"};
            object[] objArrParameterValue = { RouteId};
            DataTable dtRetVal = new DataTable();
            DBOperations objoperations = new DBOperations(Properties.Settings.Default.Connection);
            dtRetVal = DBOperations.ExecuteQueryForAll(Properties.Settings.Default.Connection, strQuery, strArrParameterName, objArrParameterValue);
            int intStationId;
            double dblFare;
            if (dtRetVal.Rows.Count > 0)
            {
                int.TryParse(dtRetVal.Rows[0]["StationId"].ToString(), out intStationId);
                objRoute.StationId = intStationId;
                objRoute.StationName = dtRetVal.Rows[0]["StationName"] != null ? dtRetVal.Rows[0]["StationName"].ToString() : string.Empty;
                double.TryParse(dtRetVal.Rows[0]["Fare"].ToString(), out dblFare);
                objRoute.Fare = dblFare;
            }
            objoperations.CloseConnection();
            return objRoute;
        }

        public static List<Route> GetAllDetails()
        {
            List<Route> lstRoute = new List<Route>();
            Route objRoute = null;

            string strQuery =  @"SELECT [StationId], [StationName] ,[Fare] FROM [Route]";
            string[] strArrColNames = new string[] { };
            object[] objArrColValue = new object[] { };
            DataTable dtRetVal = new DataTable();
            DBOperations objoperations = new DBOperations(Properties.Settings.Default.Connection);
            string str=Properties.Settings.Default.Connection;
            dtRetVal = DBOperations.ExecuteQueryForAll(str, strQuery, strArrColNames, objArrColValue);
            int intStationId;
            double dblFare;
            for (int i = 0; i < dtRetVal.Rows.Count; i++)
            {
                objRoute = new Route();

                int.TryParse(dtRetVal.Rows[i]["StationId"].ToString(), out intStationId);
                objRoute.StationId = intStationId;
                objRoute.StationName = dtRetVal.Rows[i]["StationName"] != null ? dtRetVal.Rows[i]["StationName"].ToString() : string.Empty;
                double.TryParse(dtRetVal.Rows[i]["Fare"].ToString(), out dblFare);
                objRoute.Fare = dblFare;

               lstRoute.Add(objRoute);
            }
            return lstRoute;
        }

        
    }
}



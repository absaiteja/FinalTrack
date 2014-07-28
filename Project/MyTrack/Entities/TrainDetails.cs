using SqlConnectors;
using MyTrack.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyTrack.Entities
{
    public class TrainDetails
    {
        DataTable dtTrainDetails = new DataTable();
        const string Message_Success = "Successfully {0} Train Details";
        const string Message_Failure = "Unable to {0} Train Details";

        public int TrainNumber { get; set; }
        public string TrainName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Distance { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }

        public Response CreateTrain(object[] ParameterValues)
        {
            bool blnInsertStatus;
            DBOperations objSqlDbEx = new DBOperations(Properties.Settings.Default.Connection);
            string[] strArrParamNames = { "TrainName", "Source", "Destination", "Distance", "ArrivalTime", "DepartureTime" };
            object[] objArrParamValues = ParameterValues;

            blnInsertStatus = objSqlDbEx.ExecuteQuery(@"INSERT INTO [TrainDetails]
                                                       ([TrainName]
                                                       ,[Source]
                                                       ,[Destination]
                                                       ,[Distance]
                                                       ,[ArrivalTime]
                                                       ,[DepartureTime])
                                                 VALUES
                                                       (@TrainName
                                                       ,@Source
                                                       ,@Destination
                                                       ,@Distance
                                                       ,@ArrivalTime
                                                       ,@DepartureTime)", strArrParamNames, objArrParamValues);
            if (blnInsertStatus == false)
            {
                return new Response(Properties.Settings.Default.FailureId, string.Format(Message_Failure, "create"));
               
            }
            return new Response(Properties.Settings.Default.SuccessId, string.Format(Message_Success, "created"));
        }

        public Response UpdateTrain(object[] objTrainDetails)
        {
            bool blnUpdateStatus;
            DBOperations objSqlDbEx = new DBOperations(Properties.Settings.Default.Connection);
            string[] strArrParamNames = { "TrainNumber", "TrainName", "Source", "Destination", "Distance", "ArrivalTime", "DepartureTime" };
            object[] objArrParamValues = objTrainDetails ;

            blnUpdateStatus = objSqlDbEx.ExecuteQuery(@"UPDATE [TrainDetails]
                                                       SET [TrainName] = @TrainName
                                                          ,[Source] = @Source
                                                          ,[Destination] = @Destination
                                                          ,[Distance] = @Distance
                                                          ,[ArrivalTime] = @ArrivalTime
                                                          ,[DepartureTime] = @DepartureTime
                                                     WHERE [TrainNumber] = @TrainNumber", strArrParamNames, objArrParamValues);
            if (blnUpdateStatus == false)
            {
                return new Response(Properties.Settings.Default.FailureId, string.Format(Message_Failure, "update"));
            }
            return new Response(Properties.Settings.Default.SuccessId, string.Format(Message_Success, "updated"));
        }
        public Response DeleteTrain(object[] objTrainDetails)
        {
            string strConnection = Properties.Settings.Default.Connection;
            string strQuery = @"DELETE FROM [TrainDetails] WHERE TrainNumber = @TrainNumber";
            string[] strArrParamNames = { "TrainNumber"};
            object[] objArrParamValues = { objTrainDetails[0]}; 
            DBOperations objDBOperations = new DBOperations(strConnection);
            bool blnResult = objDBOperations.ExecuteQuery(strQuery, strArrParamNames, objArrParamValues);

            if (!blnResult)
            {
                objDBOperations.CloseConnection();
                return new Response(Properties.Settings.Default.FailureId, string.Format(Message_Failure, "delete"));
            }
            objDBOperations.CloseConnection();
            return new Response(Properties.Settings.Default.SuccessId, string.Format(Message_Success, "deleted"));
        }
        public List<TrainDetails> GetAllTrains()
        {
            List<TrainDetails> lstTrainDetails = new List<TrainDetails>();
            TrainDetails objTD = null;

           
            string strQuery = @"SELECT [TrainNumber]
                                                                ,[TrainName]
                                                                ,[Source]
                                                                ,[Destination]
                                                                ,[Distance]
                                                                ,[ArrivalTime]
                                                                ,[DepartureTime]
                                                                 FROM [TrainDetails]";
            string[] strArrColNames = new string[] { };
            object[] objArrColValue = new object[] { };
            DataTable dtRetVal = new DataTable();
            DBOperations objoperations = new DBOperations(Properties.Settings.Default.Connection);
            string str = Properties.Settings.Default.Connection;
            dtRetVal = DBOperations.ExecuteQueryForAll(str, strQuery, strArrColNames, objArrColValue);
            for (int i = 0; i < dtRetVal.Rows.Count; i++)
            {
              
                int intTemp = int.MinValue;
                objTD = new TrainDetails();
                int.TryParse(dtRetVal.Rows[i]["TrainNumber"].ToString(), out intTemp);
                objTD.TrainNumber = intTemp;
                objTD.Source = dtRetVal.Rows[i]["Source"].ToString();
                objTD.Destination = dtRetVal.Rows[i]["Destination"].ToString();
                objTD.TrainName = Convert.ToString(dtRetVal.Rows[i]["TrainName"]);
                int.TryParse(dtRetVal.Rows[i]["Distance"].ToString(), out intTemp);
                objTD.Distance = intTemp;
                objTD.ArrivalTime = Convert.ToString(dtRetVal.Rows[i]["ArrivalTime"]);
                objTD.DepartureTime = Convert.ToString(dtRetVal.Rows[i]["DepartureTime"]);
                lstTrainDetails.Add(objTD);
            }
            return lstTrainDetails;
        }

        public static TrainDetails Get(int TrainNumber)
        {
            TrainDetails objTrainDetails = new TrainDetails();
            string strQuery = @"SELECT [SNo],[TicketId],[PNRNumber]
                              ,[Source],[Destination],[DateOfJourney]
                              ,[DateOfBooking],[NoOfPassengers],[Name]
                              ,[Age],[Gender],[BerthPreference],[Fare]
                              FROM [Ticket] TicketId = @TicketId";
            string[] strArrParameterName = { "TrainNumber" };
            object[] objArrparameterValue = { TrainNumber };
            DataTable dtRetVal = new DataTable();
            DBOperations objoperations = new DBOperations(Properties.Settings.Default.Connection);
            dtRetVal = DBOperations.ExecuteQueryForAll(Properties.Settings.Default.Connection, strQuery, strArrParameterName, objArrparameterValue);
         

            if (dtRetVal.Rows.Count > 0)
            {
                int intTemp = int.MinValue;
                objTrainDetails = new TrainDetails();
                int.TryParse(dtRetVal.Rows[0]["TrainNumber"].ToString(), out intTemp);
                objTrainDetails.TrainNumber = intTemp;
                objTrainDetails.Source = dtRetVal.Rows[0]["Source"].ToString();
                objTrainDetails.Destination = dtRetVal.Rows[0]["Destination"].ToString();
                objTrainDetails.TrainName = Convert.ToString(dtRetVal.Rows[0]["TrainName"]);
                int.TryParse(dtRetVal.Rows[0]["Distance"].ToString(), out intTemp);
                objTrainDetails.Distance = intTemp;
                objTrainDetails.ArrivalTime = Convert.ToString(dtRetVal.Rows[0]["ArrivalTime"]);
                objTrainDetails.DepartureTime = Convert.ToString(dtRetVal.Rows[0]["DepartureTime"]);
                
            }
            objoperations.CloseConnection();
            return objTrainDetails;
        }

    }
}
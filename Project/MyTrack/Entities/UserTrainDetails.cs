using SqlConnectors;
using MyTrack.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web; 

namespace MyTrack.Entities
{
    public class UserTrainDetails
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

        public Response CreateTrain()
        {
            bool blnInsertStatus;
            DBOperations objSqlDbEx = new DBOperations(Properties.Settings.Default.Connection);
            string[] strArrParamNames = { "TrainNumber", "TrainName", "Source", "Destination", "Distance", "ArrivalTime", "DepartureTime" };
            object[] objArrParamValues = { this.TrainNumber, this.TrainName, this.Source, this.Destination, this.Distance, this.ArrivalTime, this.DepartureTime };

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

        public Response UpdateTrain()
        {
            bool blnUpdateStatus;
            DBOperations objSqlDbEx = new DBOperations(Properties.Settings.Default.Connection);
            string[] strArrParamNames = { "TrainNumber", "TrainName", "Source", "Destination", "Distance", "ArrivalTime", "DepartureTime" };
            object[] objArrParamValues = { this.TrainNumber, this.TrainName, this.Source, this.Destination, this.Distance, this.ArrivalTime, this.DepartureTime };

            blnUpdateStatus = objSqlDbEx.ExecuteQuery(@"UPDATE [TrainDetails]
                                                       SET [TrainName] = @TrainName
                                                          ,[Source] = @Source
                                                          ,[Destination] = @Destination
                                                          ,[Distance] = @Distance
                                                          ,[ArrivalTime] = @ArrivalTime
                                                          ,[DepartureTime] = @DepartureTime
                                                     WHERE [TrainNumber] = @TrainNumbere", strArrParamNames, objArrParamValues);
            if (blnUpdateStatus == false)
            {
                return new Response(Properties.Settings.Default.FailureId, string.Format(Message_Failure, "update"));
            }
            return new Response(Properties.Settings.Default.SuccessId, string.Format(Message_Success, "updated"));
        }

        public List<UserTrainDetails> GetAllTrains()
        {
            DBOperations objSqlDbEx = new DBOperations(Properties.Settings.Default.Connection);
            string[] strArrParamNames = new string[] { };
            object[] objArrParamValues = new object[] { };
            List<UserTrainDetails> lstWT = new List<UserTrainDetails>();
            dtTrainDetails = DBOperations.ExecuteQueryForAll(Properties.Settings.Default.Connection,@"SELECT [TrainNumber]
                                                                ,[TrainName]
                                                                ,[Source]
                                                                ,[Destination]
                                                                ,[Distance]
                                                                ,[ArrivalTime]
                                                                ,[DepartureTime]
                                                                 FROM [TrainDetails]", strArrParamNames, objArrParamValues);
            for (int i = 0; i < dtTrainDetails.Rows.Count; i++)
            {
                int intTemp = int.MinValue;
                UserTrainDetails objTD = new UserTrainDetails();
                int.TryParse(dtTrainDetails.Rows[i]["TrainNumber"].ToString(), out intTemp);
                objTD.TrainNumber = intTemp;
                objTD.Source = dtTrainDetails.Rows[i]["Source"].ToString();
                objTD.Destination = dtTrainDetails.Rows[i]["Destination"].ToString();
                objTD.TrainName = Convert.ToString(dtTrainDetails.Rows[i]["TrainName"]);
                int.TryParse(dtTrainDetails.Rows[i]["Distance"].ToString(), out intTemp);
                objTD.Distance = intTemp;
                objTD.ArrivalTime = Convert.ToString(dtTrainDetails.Rows[i]["ArrivalTime"]);
                objTD.DepartureTime = Convert.ToString(dtTrainDetails.Rows[i]["DepartureTime"]);
                lstWT.Add(objTD);
            }
            return lstWT;
        }

        public UserTrainDetails GetSpecificTrain()
        {
            UserTrainDetails objTD = new UserTrainDetails();
            DBOperations objSqlDbEx = new DBOperations(Properties.Settings.Default.Connection);
            string[] strArrParamNames = { "TrainNumber" };
            object[] objArrParamValues = { this.TrainNumber };
            List<UserTrainDetails> lstWT = new List<UserTrainDetails>();
            dtTrainDetails = DBOperations.ExecuteQueryForAll(Properties.Settings.Default.Connection,@"SELECT [TrainNumber]
                                                                ,[TrainName]
                                                                ,[Source]
                                                                ,[Destination]
                                                                ,[Distance]
                                                                ,[ArrivalTime]
                                                                ,[DepartureTime]
                                                                 FROM [TrainDetails] WHERE [TrainNumber] = @TrainNumber", strArrParamNames, objArrParamValues);
            for (int i = 0; i < dtTrainDetails.Rows.Count; i++)
            {
                
                int intTemp = int.MinValue;
                int.TryParse(dtTrainDetails.Rows[i]["TrainNumber"].ToString(), out intTemp);
                objTD.TrainNumber = intTemp;
                objTD.TrainName = dtTrainDetails.Rows[i]["Source"].ToString();
                objTD.Source = dtTrainDetails.Rows[i]["Destination"].ToString();
                objTD.Destination = Convert.ToString(dtTrainDetails.Rows[i]["Worker_WType_Id"]);
                int.TryParse(dtTrainDetails.Rows[i]["TrainNumber"].ToString(), out intTemp);
                objTD.Distance = intTemp;
                objTD.ArrivalTime = Convert.ToString(dtTrainDetails.Rows[i]["ArrivalTime"]);
                objTD.DepartureTime = Convert.ToString(dtTrainDetails.Rows[i]["DepartureTime"]);
            }
            return objTD;
        }

        public List<UserTrainDetails> GetSpecificTrainsbyFromTo()
        {
           
            DBOperations objSqlDbEx = new DBOperations(Properties.Settings.Default.Connection);
            string[] strArrParamNames = { "Source", "Destination" };
            object[] objArrParamValues = { this.Source,this.Destination };
            List<UserTrainDetails> lstWT = new List<UserTrainDetails>();
            dtTrainDetails = DBOperations.ExecuteQueryForAll(Properties.Settings.Default.Connection, @"SELECT [TrainNumber]
                                                                                                      ,[TrainName]
                                                                                                      ,[Source]
                                                                                                      ,[Destination]
                                                                                                      ,[Distance]
                                                                                                      ,[ArrivalTime]
                                                                                                      ,[DepartureTime]
                                                                                                  FROM [TrainDetails] where 
                                                                                                  [Source]=@Source and [Destination]=@Destination", strArrParamNames, objArrParamValues);
            for (int i = 0; i < dtTrainDetails.Rows.Count; i++)
            {
                UserTrainDetails objTD = new UserTrainDetails();
                int intTemp = int.MinValue;
                int.TryParse(dtTrainDetails.Rows[i]["TrainNumber"].ToString(), out intTemp);
                objTD.TrainNumber = intTemp;
                objTD.TrainName = dtTrainDetails.Rows[i]["Source"].ToString();
                objTD.Source = dtTrainDetails.Rows[i]["Destination"].ToString();
                objTD.Destination = Convert.ToString(dtTrainDetails.Rows[i]["Worker_WType_Id"]);
                int.TryParse(dtTrainDetails.Rows[i]["TrainNumber"].ToString(), out intTemp);
                objTD.Distance = intTemp;
                objTD.ArrivalTime = Convert.ToString(dtTrainDetails.Rows[i]["ArrivalTime"]);
                objTD.DepartureTime = Convert.ToString(dtTrainDetails.Rows[i]["DepartureTime"]);
                lstWT.Add(objTD);
            }
            return lstWT;
        }
    }
}
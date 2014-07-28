using SqlConnectors;
using MyTrack.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MyTrack.Entities
{
    public class Ticket
    {
        const string Success_MSG = "Successfully {0} a Ticket";
        const string Failure_MSG = "Unable to {0} a Ticket";

        [Display(Name = "TicketNumber", Description = "Primarykey")]
        public int TicketNumber { get; set; }

        [Display(Name = "TrainName")]
        public string TrainName { get; set; }

        [Display(Name = "PNRNumber")]
        public string PNRNumber { get; set; }

        [Display(Name = "Source")]
        public string Source { get; set; }

        [Display(Name = "Destination")]
        public string Destination { get; set; }

        [Display(Name = "DateOfJourney")]
        public string DateOfJourney { get; set; }

        [Display(Name = "DateOfBooking")]
        public string DateOfBooking { get; set; }

        [Display(Name = "NoOfPassengers")]
        public string NoOfPassengers { get; set; }

         [Display(Name = "EmailId")]
        public string EmailId { get; set; }
        
        [Display(Name = "Class")]
        public string Class { get; set; }

        [Display(Name = "Distance")]
        public int Distance { get; set; }

        [Display(Name = "ArrivalTime")]
        public string ArrivalTime { get; set; }

        [Display(Name = "DepartureTime")]
        public string DepartureTime { get; set; }

        [Display(Name = "TransactionId")]
        public int TransactionId { get; set; }

        [Display(Name = "Fare")]
        public double Fare { get; set; }

        public Response CreateTicket(object[] objCreateTicket)
        {
            string strConnection = Properties.Settings.Default.Connection;
            string[] strArrParameterName = {  "TrainName","PNRNumber",
                                            "Source","Destination","DateOfJourney","DateOfBooking","Class","Distance"
                                            ,"NoOfPassengers", "EmailId",
                                            "ArrivalTime","DepartureTime","TransactionId","Fare" };
            object[] objArrParameterValue = objCreateTicket;

            string strQuery = @"INSERT INTO [Ticket]
                                ([TrainName] ,[PNRNumber] ,[Source],[Destination],[DateOfJourney],[DateOfBooking]
                                  ,[Class],[Distance] ,[NoOfPassengers],[EmailId],[ArrivalTime],[DepartureTime],[TransactionId],[Fare])
                                VALUES (@TrainName,@PNRNumber, @Source,  @Destination, @DateOfJourney, @DateOfBooking,
                                         @Class, @Distance, @NoOfPassengers,@EmailId, @ArrivalTime,@DepartureTime, @TransactionId, @Fare)";
            DBOperations objDBOperations = new DBOperations(strConnection);
            bool blnResult = objDBOperations.ExecuteQuery(strQuery, strArrParameterName, objArrParameterValue);


            if (!blnResult)
            {
                objDBOperations.CloseConnection();
                return new Response(9999, string.Format(Failure_MSG, "add"));
            }
            objDBOperations.CloseConnection();
            return new Response(5555, string.Format(Success_MSG, "added"));


        }

        public Response Update(object[] objUpdateTicket)
        {
            string strConnection = Properties.Settings.Default.Connection;
            string strQuery = @"UPDATE [Ticket]
                               SET [TrainName] = @TrainName,
                                  [PNRNumber] = @PNRNumber,
                                  [Source] = @Source,
                                  [Destination] = @Destination,
                                  [DateOfJourney] = @DateOfJourney,
                                  [DateOfBooking] = @DateOfBooking,
                                  [Class] = @Class,
                                  [Distance] = @Distance,
                                  [NoOfPassengers] = @NoOfPassengers,
                                  [EmailId]=@EmailId,
                                  [ArrivalTime] = @ArrivalTime,
                                  [DepartureTime] = @DepartureTime,
                                  [TransactionId] = @TransactionId,
                                  [Fare] = @Fare
                                   WHERE PNRNumber = @PNRNumber ";
            string[] strArrParameterName = { "TrainName","PNRNumber",
                                            "Source","Destination","DateOfJourney","DateOfBooking","Class","Distance"
                                            ,"NoOfPassengers","EmailId",
                                            "ArrivalTime","DepartureTime","TransactionId","Fare" };
            object[] objArrParameterValue = objUpdateTicket;
            DBOperations objDBOperations = new DBOperations(strConnection);
            bool blnResult = objDBOperations.ExecuteQuery(strQuery, strArrParameterName, objArrParameterValue);

            if (!blnResult)
            {
                objDBOperations.CloseConnection();
                return new Response(9999, string.Format(Failure_MSG, "update"));
            }
            objDBOperations.CloseConnection();
            return new Response(5555, string.Format(Success_MSG, "updated"));
        }

        public Response Delete(string PNRNumber)
        {
            string strConnection = Properties.Settings.Default.Connection;
            string strQuery = @"DELETE FROM [Ticket] WHERE PNRNumber = @PNRNumber";
            string[] strArrParameterName = { "PNRNumber" };
            object[] objArrParameterValue = { PNRNumber };
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

        public static Ticket GetFromPnr(string PNRNumber)
        {
            Ticket objTicket = new Ticket();
            string strQuery = @"SELECT [TicketNumber],[TrainName],[PNRNumber],[Source] ,[Destination]
                                         ,[DateOfJourney],[DateOfBooking],[Class],[Distance],[NoOfPassengers],[EmailId]
                                          ,[ArrivalTime] ,[DepartureTime],[TransactionId],[Fare]
                                        FROM [Ticket]
                                    WHERE  PNRNumber = @PNRNumber";
            string[] strArrParameterName = { "PNRNumber" };
            object[] objArrparameterValue = { PNRNumber };
            DataTable dtRetVal = new DataTable();
            DBOperations objoperations = new DBOperations(Properties.Settings.Default.Connection);
            dtRetVal = DBOperations.ExecuteQueryForAll(Properties.Settings.Default.Connection, strQuery, strArrParameterName, objArrparameterValue);
            int intSId;
            int intTicketNumber;
            int intDistance;
            int intTransactionId;
            double dblFare;

            if (dtRetVal.Rows.Count > 0)
            {
                int.TryParse(dtRetVal.Rows[0]["TicketNumber"].ToString(), out intTicketNumber);
                objTicket.TicketNumber = intTicketNumber;
                objTicket.TrainName = dtRetVal.Rows[0]["TrainName"] != null ? dtRetVal.Rows[0]["TrainName"].ToString() : string.Empty;
                objTicket.PNRNumber = dtRetVal.Rows[0]["PNRNumber"] != null ? dtRetVal.Rows[0]["PNRNumber"].ToString() : string.Empty;
                objTicket.Source = dtRetVal.Rows[0]["Source"] != null ? dtRetVal.Rows[0]["Source"].ToString() : string.Empty;
                objTicket.Destination = dtRetVal.Rows[0]["Destination"] != null ? dtRetVal.Rows[0]["Destination"].ToString() : string.Empty;
                objTicket.DateOfJourney = dtRetVal.Rows[0]["DateOfJourney"] != null ? dtRetVal.Rows[0]["DateOfJourney"].ToString() : string.Empty;
                objTicket.DateOfBooking = dtRetVal.Rows[0]["DateOfBooking"] != null ? dtRetVal.Rows[0]["DateOfBooking"].ToString() : string.Empty;
                objTicket.NoOfPassengers = dtRetVal.Rows[0]["NoOfPassengers"] != null ? dtRetVal.Rows[0]["NoOfPassengers"].ToString() : string.Empty;
                objTicket.EmailId = dtRetVal.Rows[0]["EmailId"] != null ? dtRetVal.Rows[0]["EmailId"].ToString() : string.Empty;
                objTicket.Class = dtRetVal.Rows[0]["Class"] != null ? dtRetVal.Rows[0]["Class"].ToString() : string.Empty;
                int.TryParse(dtRetVal.Rows[0]["Distance"].ToString(), out intDistance);
                objTicket.Distance = intDistance;
                objTicket.ArrivalTime = dtRetVal.Rows[0]["ArrivalTime"] != null ? dtRetVal.Rows[0]["ArrivalTime"].ToString() : string.Empty;
                objTicket.DepartureTime = dtRetVal.Rows[0]["DepartureTime"] != null ? dtRetVal.Rows[0]["DepartureTime"].ToString() : string.Empty;
                int.TryParse(dtRetVal.Rows[0]["TransactionId"].ToString(), out intTransactionId);
                objTicket.TransactionId = intTransactionId;
                double.TryParse(dtRetVal.Rows[0]["Fare"].ToString(), out dblFare);
                objTicket.Fare = dblFare;
            }
            objoperations.CloseConnection();
            return objTicket;
        }

       

        public static List<Ticket> GetAllDetails()
        {
            List<Ticket> lstTicket = new List<Ticket>();
            Ticket objTicket = null;

            string strQuery = @"SELECT [TicketNumber],[TrainName],[PNRNumber],[Source] ,[Destination]
                                         ,[DateOfJourney],[DateOfBooking],[Class],[Distance],[NoOfPassengers],[EmailId]
                                          ,[ArrivalTime] ,[DepartureTime],[TransactionId],[Fare]
                                        FROM [Ticket]
                                        WHERE PNRNumber = @PNRNumber";
            string[] strArrColNames = new string[] { };
            object[] objArrColValue = new object[] { };
            DataTable dtRetVal = new DataTable();
            DBOperations objoperations = new DBOperations(Properties.Settings.Default.Connection);
            string str = Properties.Settings.Default.Connection;
            dtRetVal = DBOperations.ExecuteQueryForAll(str, strQuery, strArrColNames, objArrColValue);
            int intTicketNumber;
            int intDistance;
            int intTransactionId;
            double dblFare;
            for (int i = 0; i < dtRetVal.Rows.Count; i++)
            {
                objTicket = new Ticket();
                objTicket = new Ticket();
                int.TryParse(dtRetVal.Rows[i]["TicketNumbers"].ToString(), out intTicketNumber);
                objTicket.TicketNumber = intTicketNumber;
                objTicket.TrainName = dtRetVal.Rows[i]["TrainName"] != null ? dtRetVal.Rows[i]["TrainName"].ToString() : string.Empty;
                objTicket.PNRNumber = dtRetVal.Rows[i]["PNRNumber"] != null ? dtRetVal.Rows[i]["PNRNumber"].ToString() : string.Empty;
                objTicket.Source = dtRetVal.Rows[i]["Source"] != null ? dtRetVal.Rows[i]["Source"].ToString() : string.Empty;
                objTicket.Destination = dtRetVal.Rows[i]["Destination"] != null ? dtRetVal.Rows[i]["Destination"].ToString() : string.Empty;
                objTicket.DateOfJourney = dtRetVal.Rows[i]["DateOfJourney"] != null ? dtRetVal.Rows[i]["DateOfJourney"].ToString() : string.Empty;
                objTicket.DateOfBooking = dtRetVal.Rows[i]["DateOfBooking"] != null ? dtRetVal.Rows[i]["DateOfBooking"].ToString() : string.Empty;
                objTicket.NoOfPassengers = dtRetVal.Rows[i]["NoOfPassengers"] != null ? dtRetVal.Rows[i]["NoOfPassengers"].ToString() : string.Empty;
                objTicket.EmailId = dtRetVal.Rows[0]["EmailId"] != null ? dtRetVal.Rows[0]["EmailId"].ToString() : string.Empty;
                objTicket.Class = dtRetVal.Rows[i]["Class"] != null ? dtRetVal.Rows[i]["Class"].ToString() : string.Empty;
                int.TryParse(dtRetVal.Rows[i]["Distance"].ToString(), out intDistance);
                objTicket.Distance = intDistance;
                objTicket.ArrivalTime = dtRetVal.Rows[i]["ArrivalTime"] != null ? dtRetVal.Rows[i]["ArrivalTime"].ToString() : string.Empty;
                objTicket.DepartureTime = dtRetVal.Rows[i]["DepartureTime"] != null ? dtRetVal.Rows[i]["DepartureTime"].ToString() : string.Empty;
                int.TryParse(dtRetVal.Rows[i]["TransactionId"].ToString(), out intTransactionId);
                objTicket.TransactionId = intTransactionId;
                double.TryParse(dtRetVal.Rows[i]["Fare"].ToString(), out dblFare);
                objTicket.Fare = dblFare;
                lstTicket.Add(objTicket);
            }
            return lstTicket;
        }


    }
}



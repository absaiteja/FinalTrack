using MyTrack.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MyTrack.Entities
{
    public class Passengers
    {
        const string Message_Success = "Successfully {0} a Passenger";
        const string Message_Failure = "Unable to {0} a Passenger";

        [Display(Name = "PNRNumber")]
        public string PNRNumber { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "SeatNumber")]
        public int SeatNumber { get; set; }

        [Display(Name = "BerthPreference")]
        public string BerthPreference { get; set; }

        public Response CreatePassengers(object[] strValues)
        {
            bool blnResult = true;
            string strQuery = @"INSERT INTO [Passengers]
                            ([PNRNumber],[Name],[Age] ,[Gender],[BerthPreference],[SeatNumber])
                             VALUES  (@PNRNumber,@Name,@Age,@Gender,@BerthPreference,@SeatNumber)";
            string[] strParameters = { "PNRNumber","Name", "Age", "Gender", "BerthPreference", "SeatNumber" };
            object[] strParametersValues = strValues;
            SqlConnectors.DBOperations objparameteres = new SqlConnectors.DBOperations(Properties.Settings.Default.Connection);
            blnResult = objparameteres.ExecuteQuery(strQuery, strParameters, strParametersValues);
            if (blnResult == false)
            {
                return new Response(Properties.Settings.Default.FailureId, string.Format(Message_Failure, "add"));
            }
            return new Response(Properties.Settings.Default.SuccessId, string.Format(Message_Success, "added"));

        }
        public bool UpdatePassengers(object[] strValues)
        {
            string strQuery = @" UPDATE [Passengers]
                                   SET [PNRNumber] = @PNRNumber,
                                      [Name] = @Name,
                                      [Age] = @Age,
                                      [Gender] = @Gender,
                                      [BerthPreference] = @BerthPreference,
                                      [SeatNumber] = @SeatNumber
                                 WHERE PNRNumber = @PNRNumber ";
            string[] strParameters = { "PNRNumber", "Name", "Age", "Gender", "BerthPreference", "SeatNumber" };
            object[] strParametersValues = strValues;
            SqlConnectors.DBOperations objparameteres = new SqlConnectors.DBOperations(Properties.Settings.Default.Connection);
            objparameteres.ExecuteQuery(strQuery, strParameters, strParametersValues);
            return true;
        }
        public static Passengers GetPassengersByPnr(string strPNRNumber)
        {
            Passengers objPassengers = new Passengers();
            string strQuery = @"SELECT [PNRNumber]
                                      ,[Name]
                                      ,[Age]
                                      ,[Gender]
                                      ,[BerthPreference]
                                      ,[SeatNumber]
                                  FROM [Passengers]
                                  WHERE PNRNumber = @PNRNumber ";
            string strConnection = Properties.Settings.Default.Connection;
            DataTable dtRetval = new DataTable();
            string[] strArrParameterName = { "PNRNumber" };
            object[] objArrparameterValue = { strPNRNumber };
            int intAge;
            int intSeatNumber;
            dtRetval = SqlConnectors.DBOperations.ExecuteQueryForAll(strConnection, strQuery, new string[] { }, new object[] { });
            if (dtRetval.Rows.Count > 0)
            {
                for (int i = 0; i < dtRetval.Rows.Count; i++)
                {
                    objPassengers = new Passengers();
                    objPassengers.PNRNumber = dtRetval.Rows[i]["PNRNumber"] != null ? dtRetval.Rows[i]["PNRNumber"].ToString() : string.Empty;
                    objPassengers.Name = dtRetval.Rows[i]["Name"] != null ? dtRetval.Rows[i]["Name"].ToString() : string.Empty;
                    int.TryParse(dtRetval.Rows[i]["Age"].ToString(), out intAge);
                    objPassengers.Age = intAge;
                    objPassengers.Gender = dtRetval.Rows[i]["Gender"] != null ? dtRetval.Rows[i]["Gender"].ToString() : string.Empty;
                    objPassengers.BerthPreference = dtRetval.Rows[i]["BerthPreference"] != null ? dtRetval.Rows[i]["BerthPreference"].ToString() : string.Empty;
                    int.TryParse(dtRetval.Rows[i]["SeatNumber"].ToString(), out intSeatNumber);
                    objPassengers.SeatNumber = intSeatNumber;
                }
            }
            return objPassengers;
        }
        public static List<Passengers> GetAllPassengers()
        {
            List<Passengers> lstPassengers = new List<Passengers>();
            Passengers objPassengers = new Passengers();
            string strQuery = @"SELECT [PNRNumber]
                                      ,[Name]
                                      ,[Age]
                                      ,[Gender]
                                      ,[BerthPreference]
                                      ,[SeatNumber]
                                  FROM [Passengers]";
            string strConnection = Properties.Settings.Default.Connection;
            DataTable dtRetval = new DataTable();
            string[] strArrParameters = new string[] { };
            object[] strArrParameterValues = new object[] { };
            int intAge;
            int intSeatNumber;
            dtRetval = SqlConnectors.DBOperations.ExecuteQueryForAll(strConnection, strQuery, new string[] { }, new object[] { });
            if (dtRetval.Rows.Count > 0)
            {
                for (int i = 0; i < dtRetval.Rows.Count; i++)
                {
                    objPassengers = new Passengers();
                    objPassengers.PNRNumber = dtRetval.Rows[i]["PNRNumber"] != null ? dtRetval.Rows[i]["PNRNumber"].ToString() : string.Empty;
                    objPassengers.Name = dtRetval.Rows[i]["Name"] != null ? dtRetval.Rows[i]["Name"].ToString() : string.Empty;
                    int.TryParse(dtRetval.Rows[i]["Age"].ToString(), out intAge);
                    objPassengers.Age = intAge;
                    objPassengers.Gender = dtRetval.Rows[i]["Gender"] != null ? dtRetval.Rows[i]["Gender"].ToString() : string.Empty;
                    objPassengers.BerthPreference = dtRetval.Rows[i]["BerthPreference"] != null ? dtRetval.Rows[i]["BerthPreference"].ToString() : string.Empty;
                    int.TryParse(dtRetval.Rows[i]["SeatNumber"].ToString(), out intSeatNumber);
                    objPassengers.SeatNumber = intSeatNumber;
                }
            }
            return lstPassengers;
        }
        public static List<Passengers> GetAllPassengersByPnr(string PNRNumber)
        {
            List<Passengers> lstPassengers = new List<Passengers>();
            Passengers objPassengers = new Passengers();
            string strQuery = @"SELECT [PNRNumber]
                                      ,[Name]
                                      ,[Age]
                                      ,[Gender]
                                      ,[BerthPreference]
                                      ,[SeatNumber]
                                  FROM [Passengers]
                                WHERE PNRNumber = @PNRNumber ";
            string strConnection = Properties.Settings.Default.Connection;
            DataTable dtRetval = new DataTable();
            string[] strArrParameterName = { "PNRNumber" };
            object[] objArrparameterValue = { PNRNumber };
            int intAge;
            int intSeatNumber;
            dtRetval = SqlConnectors.DBOperations.ExecuteQueryForAll(strConnection, strQuery, strArrParameterName, objArrparameterValue);
            if (dtRetval.Rows.Count > 0)
            {
                for (int i = 0; i < dtRetval.Rows.Count; i++)
                {
                    objPassengers = new Passengers();
                    objPassengers.PNRNumber = dtRetval.Rows[i]["PNRNumber"] != null ? dtRetval.Rows[i]["PNRNumber"].ToString() : string.Empty;
                    objPassengers.Name = dtRetval.Rows[i]["Name"] != null ? dtRetval.Rows[i]["Name"].ToString() : string.Empty;
                    int.TryParse(dtRetval.Rows[i]["Age"].ToString(), out intAge);
                    objPassengers.Age = intAge;
                    objPassengers.Gender = dtRetval.Rows[i]["Gender"] != null ? dtRetval.Rows[i]["Gender"].ToString() : string.Empty;
                    objPassengers.BerthPreference = dtRetval.Rows[i]["BerthPreference"] != null ? dtRetval.Rows[i]["BerthPreference"].ToString() : string.Empty;
                    int.TryParse(dtRetval.Rows[i]["SeatNumber"].ToString(), out intSeatNumber);
                    objPassengers.SeatNumber = intSeatNumber;
                    lstPassengers.Add(objPassengers);
                }
                return lstPassengers;
            }
            return lstPassengers;
        }
    }
}
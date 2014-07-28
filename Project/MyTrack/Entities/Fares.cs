using MyTrack.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MyTrack.Entities
{
    public class Fares
    {
        const string Message_Success = "Successfully {0} Train Details";
        const string Message_Failure = "Unable to {0} Train Details";

        [Display(Name = "FareID", Description = "PrimaryKey")]
        public int FareID { get; set; }

        [Display(Name = "Station_From")]
        public string Station_From { get; set; }

        [Display(Name = "Station_To")]
        public string Station_To { get; set; }

        [Display(Name = "Fare")]
        public float Fare { get; set; }

        [Display(Name = "TrainNumber")]
        public int TrainNumber { get; set; }

        public Response Create(object[] strValues)
        {
            bool blnResult = true;
            string strQuery = @"INSERT INTO [Fares]
                                   ([Station_From],[Station_To] ,[Fare],[TrainNumber])
                             VALUES(@Station_From,@Station_To,@Fare,@TrainNumber ";
            string[] strParameters = { "Station_From", "Station_To", "Fare","TrainNumber" };
            object[] strParametersValues = strValues;
            SqlConnectors.DBOperations objparameteres = new SqlConnectors.DBOperations(Properties.Settings.Default.Connection);
            blnResult = objparameteres.ExecuteQuery(strQuery, strParameters, strParametersValues);
            if (blnResult == false)
            {
                return new Response(Properties.Settings.Default.FailureId, string.Format(Message_Failure, "create"));
            }
            return new Response(Properties.Settings.Default.SuccessId, string.Format(Message_Success, "created"));

        }
        public Response Update(object[] strValues)
        {
            string strQuery = @" UPDATE [Fares]
                                   SET
                                       [Fare] = @Fare
                                   WHERE [TrainNumber]=@TrainNumber";
            string[] strParameters = { "TrainNumber", "Fare" };
            object[] strParametersValues = {strValues[0],strValues[1]};
            SqlConnectors.DBOperations objparameteres = new SqlConnectors.DBOperations(Properties.Settings.Default.Connection);
           bool blnUpdatedStatus= objparameteres.ExecuteQuery(strQuery, strParameters, strParametersValues);
           if (blnUpdatedStatus == false)
            {
                return new Response(Properties.Settings.Default.FailureId, string.Format(Message_Failure, "update"));
            }
            return new Response(Properties.Settings.Default.SuccessId, string.Format(Message_Success, "updated"));
        }
        public static Fares Get(int intTrainNumber)
        {
            Fares objFares = new Fares();
            string strQuery = @"SELECT [FareID]
                                      ,[Station_From]
                                      ,[Station_To]
                                      ,[Fare]
                                      ,[TrainNumber]
                                  FROM [Fares] 
                                  WHERE TrainNumber = @TrainNumber ";
            string strConnection = Properties.Settings.Default.Connection;
            DataTable dtRetval = new DataTable();
            //int intTemp = 0;
            float fltTemp = 0;
            int intTrainId = 0;
            string[] strArrParameters = { "TrainNumber" };
            object[] strArrParameterValues = { intTrainNumber };
            dtRetval = SqlConnectors.DBOperations.ExecuteQueryForAll(strConnection, strQuery, strArrParameters, strArrParameterValues);
            if (dtRetval.Rows.Count > 0)
            {
                objFares = new Fares();
                float.TryParse(dtRetval.Rows[0]["Fare"].ToString(), out fltTemp);
                objFares.Fare = fltTemp;
                int.TryParse(dtRetval.Rows[0]["TrainNumber"].ToString(), out intTrainId);
                objFares.TrainNumber = intTrainId;
            }
            return objFares;
        }
        public static List<Fares> GetAll()
        {
            List<Fares> lstFares = new List<Fares>();
            Fares objFares = new Fares();
            string strQuery = @"SELECT [FareID]
                                      ,[Station_From]
                                      ,[Station_To]
                                      ,[Fare]
                                      ,[TrainNumber]
                                  FROM [Fares]";
            string strConnection = Properties.Settings.Default.Connection;
            DataTable dtRetval = new DataTable();
            int intTemp = 0;
            float fltTemp = 0;
            int intTrainNumber = 0;
            dtRetval = SqlConnectors.DBOperations.ExecuteQueryForAll(strConnection, strQuery, new string[] { }, new object[] { });
            if (dtRetval.Rows.Count > 0)
            {
                for (int i = 0; i < dtRetval.Rows.Count; i++)
                {
                    objFares = new Fares();
                    int.TryParse(dtRetval.Rows[i]["FareID"].ToString(), out intTemp);
                    objFares.FareID = intTemp;
                    objFares.Station_From = dtRetval.Rows[i]["Station_From"] != null ? dtRetval.Rows[i]["Station_From"].ToString() : string.Empty;
                    objFares.Station_To = dtRetval.Rows[i]["Station_To"] != null ? dtRetval.Rows[i]["Station_To"].ToString() : string.Empty;
                    float.TryParse(dtRetval.Rows[i]["Fare"].ToString(), out fltTemp);
                    objFares.Fare = fltTemp;
                    int.TryParse(dtRetval.Rows[i]["TrainNumber"].ToString(), out intTrainNumber);
                    objFares.TrainNumber = intTrainNumber;
                    lstFares.Add(objFares);
                }
            }
            return lstFares;
        }
    }
}
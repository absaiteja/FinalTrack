using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqlConnectors
{
    public class DBOperations
    {
        SqlConnection _Obsc = null;
        string _strConnectionString = string.Empty;
        public DBOperations(string strConnectionString)
        {
            _Obsc = new SqlConnection(strConnectionString);
        }
        public void OpenConnection()
        {
            if (_Obsc == null)
            {
                _Obsc = new SqlConnection(_strConnectionString);
            }
            _Obsc.Open();
        }
        public void CloseConnection()
        {
            if (_Obsc != null)
            {
                _Obsc.Close();
                _Obsc.Dispose();
            }
        }
        public bool ExecuteQuery(string strQuery, string[] strArrParameterName, object[] objArrParameterValues)
        {
            bool blnRetVal = false;
            if(strArrParameterName.Length != objArrParameterValues.Length)
            {
                return false;
            }
            OpenConnection();
            SqlCommand objsqlcmd = new SqlCommand(strQuery, _Obsc);
            for (int i = 0; i < strArrParameterName.Length; i++)
            {
                objsqlcmd.Parameters.AddWithValue(strArrParameterName[i],objArrParameterValues[i]);
            }
            if (objsqlcmd.ExecuteNonQuery() < 1)
            {
                blnRetVal = false;
            }
            else
            {
                blnRetVal = true;
            }
            CloseConnection();
            return blnRetVal;
        }
        public static DataTable ExecuteQueryForAll(string strConnectionString, string strQuery, string[] strArrParameterName, object[] objArrParameterValues)
        {
            if (strArrParameterName.Length != objArrParameterValues.Length)
            {
                return null;
            }
            SqlConnection objSc = new SqlConnection(strConnectionString);
            SqlCommand objsqlcmd = new SqlCommand(strQuery, objSc);
            for (int i = 0; i < strArrParameterName.Length; i++)
            {
                objsqlcmd.Parameters.AddWithValue(strArrParameterName[i], objArrParameterValues[i]);
            }
            SqlDataAdapter sdaExecute = new SqlDataAdapter(objsqlcmd);
            DataTable dtRetVal = new DataTable();
            sdaExecute.Fill(dtRetVal); 
            objSc.Close();
            objSc.Dispose();
            return dtRetVal;
        }

    }
}

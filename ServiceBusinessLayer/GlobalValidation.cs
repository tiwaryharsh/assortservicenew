using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web.UI;


namespace ServiceBusinessLayer
{
    class GlobalValidation
    {
        private static readonly string CLASS_NAME = "ClientConfigBusinessLayer";
        string FUNCTION_NAME;
        public bool Success { get; set; }

        public int ResponseCode { get; set; }

        public string ResponseMessage { get; set; }

        public string LogMessage { get; set; }

        #region GetContentsFormDictonaryOrList
        public static string GetContents(object DictOrList)
        {
            //string s = string.Join(";", myDict.Select(x => x.Key + "=" + x.Value).ToArray());
            string Data = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(DictOrList);
            return Data;
        }
        #endregion EOR_GetContentsFormDictonaryOrList

        public void validateDBResponse(DataSet ds_Result, int totalTableCnt, int contentTableIndex)
        {

            try
            {
                if (ds_Result.Tables.Count == 0)
                {
                    // there may be some error in SPROC
                    Success = false;
                    ResponseCode = 1;
                    ResponseMessage = "Could not retrieve data from Server";
                    LogMessage = "No result were returned from the DB SProc";
                    return;
                }
                // set default
                Success = true;
                ResponseCode = 0;
                ResponseMessage = "Data retrived successfully";
                LogMessage = "Response received from server successfully";
                //
                // parse through each table to check for success ResponseCode
                //for (int i = 0; i < ds_Result.Tables.Count; i++)
                foreach (DataTable dt in ds_Result.Tables)
                {
                    // check if table contains ResponseCode column
                    if (dt.Columns.Contains("ResponseCode"))
                    {
                        ResponseCode = Convert.ToInt32(dt.Rows[0]["ResponseCode"].ToString());
                        ResponseMessage = dt.Rows[0]["ResponseMessage"].ToString();
                        //
                        if (dt.Columns.Contains("LogMessage"))
                            LogMessage = dt.Rows[0]["LogMessage"].ToString();
                        else
                            LogMessage = dt.Rows[0]["ResponseMessage"].ToString();
                        //
                        if (Convert.ToInt32(dt.Rows[0]["ResponseCode"].ToString()) != 0)
                        {
                            Success = false;
                            return;
                        }
                    }
                }
                // check if the result table count meets the required tables
                if (ds_Result.Tables.Count != totalTableCnt)
                {
                    Success = false;
                    ResponseCode = 1;
                    ResponseMessage = "Could not retrieve data from Server";
                    LogMessage = "No proper result received from SProc";
                    return;
                }
                // check if the main table contains records, only for listing or details querys
                //if (contentTableIndex != 0 && ds_Result.Tables[contentTableIndex].Rows.Count == 0)
                if (ds_Result.Tables[contentTableIndex].Rows.Count == 0)
                {
                    Success = false;
                    ResponseCode = 1;
                    ResponseMessage = "There were no records found for the given inputs";
                    LogMessage = "No records found from SPROC for the given inputs";
                    return;
                }
            }
            catch (Exception EX)
            {
                Success = false;
                ResponseCode = 1;
                ResponseMessage = "Could not retrieve data from Server";
                LogMessage = EX.ToString();

            }

        }

        public static DataTable ConvertToDatatable<T>(List<T> data)
        {

            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            try
            {
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                    else
                        table.Columns.Add(prop.Name, prop.PropertyType);
                }
                object[] values = new object[props.Count];

                foreach (T item in data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
            }
            catch (Exception EX)
            {

            }

            return table;
        }

        public static DataTable ConvertToDatatype<T>(List<T> data)
        {

            string FUNCTION_NAME = "ConvertToDatatype";


            PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            try
            {
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                    else
                        table.Columns.Add(prop.Name, prop.PropertyType);
                }
                object[] values = new object[props.Count];

                foreach (T item in data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
            }
            catch (Exception EX)
            {

            }

            return table;
        }

        public DataTable GenerateTransposedTable(DataTable inputTable)
        {


            DataTable outputTable = new DataTable();
            try
            {
                //o Add columns by looping rows

                // Header row's first column is same as in inputTable
                outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

                // Header row's second column onwards, 'inputTable's first column taken
                foreach (DataRow inRow in inputTable.Rows)
                {
                    string newColName = inRow[0].ToString();
                    outputTable.Columns.Add(newColName);
                }

                // Add rows by looping columns        
                for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
                {
                    DataRow newRow = outputTable.NewRow();

                    // First column is inputTable's Header row's second column
                    newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                    for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                    {
                        string colValue = inputTable.Rows[cCount][rCount].ToString();
                        newRow[cCount + 1] = colValue;
                    }
                    outputTable.Rows.Add(newRow);
                }
            }
            catch (Exception EX)
            {

            }

            return outputTable;
        }
    }
}

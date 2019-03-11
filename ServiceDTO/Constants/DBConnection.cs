using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDTO
{
    public class DBConnection
    {

        #region GetDBConnection ..........................................
        public static string GetDBConnection()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["InvestFundaCon"].ConnectionString;
            }
            catch (Exception EX)
            {

                return "Unable to connect to DB"+EX.Message;
            }
        }
        #endregion
    }
}

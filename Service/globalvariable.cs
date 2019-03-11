namespace Service
{
    namespace GlobalVariables
    {

        public static class Globals
        {
            // parameterless constructor required for static class

            static Globals()
            {

                GlobalInt = 1000;
                GlobalIntID = 1000;
                GlobalClientCode = 100;
                GlobalCurrentDate = "2017|01|19";
            } // default value

            // public get, and private set for strict access control
            public static int GlobalInt { get; private set; }

            public static int GlobalIntID { get; private set; }
            public static int GlobalClientCode { get; private set; }
            public static string GlobalCurrentDate { get; private set; }

            // GlobalInt can be changed only via this method
            public static void SetGlobalInt(int newInt)
            {
                GlobalInt = newInt;
            }

            public static void SetGlobalIntID(int newInt)
            {
                GlobalIntID = newInt;
            }
            public static void SetGlobalClientCode(int newInt)
            {
                GlobalClientCode = newInt;
            }
            public static void SetGlobalDate(string Date)
            {
                GlobalCurrentDate = Date;
            }
        }
    }
    public class globalvariable
    {


    }
}
namespace GetYearToDate
{
    public class Config
    {
        public static string GetDbConfig()
        {
            string connection = System.Configuration.ConfigurationSettings.AppSettings["BucketListDbConnStrProd"];

            return connection;
        }
    }
}

using System;
using System.Linq;
using System.Text;

namespace Shared
{
    public class Utilities
    {
        public static string GetAppSetting(string key)
        {
            string value = string.Empty;
            string appSetting = System.Configuration.ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrEmpty(appSetting))
                value = appSetting;

            return value;
        }
        public static string GetDbSetting()
        {
            string Environment = Utilities.GetAppSetting(Constants.ENVIRONMENT);
            string dbConn = string.Empty;

            if (!string.IsNullOrEmpty(Environment) && Environment.Equals(Constants.ENVIRONMENT_PRODUCTION))
                dbConn = Utilities.GetAppSetting(Constants.DB_PROD);
            else
                dbConn = Utilities.GetAppSetting(Constants.DB_TEST);

            return dbConn;
        }
        public static string DecodeClientBase64String(string encodedString)
        {
            string decodedString = string.Empty;

            if (!string.IsNullOrEmpty(encodedString))
            {
                byte[] data = Convert.FromBase64String(encodedString);
                decodedString = Encoding.UTF8.GetString(data);
            }

            return decodedString;
        }
        public static string EncodeClientBase64String(string val)
        {
            string encodedString = string.Empty;

            if (!string.IsNullOrEmpty(val))
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(val);
                encodedString = Convert.ToBase64String(data);
            }

            return encodedString;
        }
        public static string GenerateToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());

            return token;
        }
        public static string[] GetInValidTokenResponse()
        {
            string[] result = null;

            result = new string[1];
            result[0] = Error.ERR_000002 + "-" + ErrorMsg.ERR_MSG_000002;

            return result;
        }
        public static string[] GetValidTokenResponse()
        {
            string[] result = null;

            result = new string[1];
            result[0] = Shared.Constants.TOKEN_VALID;

            return result;
        }
        public static bool ValidUserToRegistration(string user, string email, string password)
        {
            bool valid = true;

            if (string.IsNullOrEmpty(user) || user.Equals("null"))
                valid = false;
            else if (string.IsNullOrEmpty(email) || email.Equals("null"))
                valid = false;
            else if (string.IsNullOrEmpty(password) || password.Equals("null"))
                valid = false;
            else if (user.Length < Shared.Constants.REGISTRATION_VALUE_LENGTH)
                valid = false;
            else if (password.Length < Shared.Constants.REGISTRATION_VALUE_LENGTH)
                valid = false;
            else if (!ContainsOneNumber(password))
                valid = false;
            else if (email.IndexOf(Shared.Constants.EMAIL_AT_SIGN) < 1)
                valid = false;

            return valid;
        }
        public static bool ContainsOneNumber(string password)
        {
            char[] charArray = password.ToArray();
            var numberFound = false;

            for (var i = 0; i < charArray.Length; i++)
            {
                string curChar = charArray[i].ToString();

                int j;
                if (Int32.TryParse(curChar, out j))
                {
                    numberFound = true;
                    break;
                }
            }

            return numberFound;
        }
    }
}

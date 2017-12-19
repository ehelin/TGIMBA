using System;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GetYearToDate
{
    public class GetDailyPrice
    {
        private Database db = null;

        public GetDailyPrice()
        {
            db = new Database();
        }

        public bool GetDailySpreadsheet(bool isNasdaq)
        {
            string spreadSheetContents = getDailySpreadsheet(true);
            parseSpreadSheet(spreadSheetContents);

            return true;
        }

        private void save(string currentStockPriceRow, DateTime date)
        {
            try
            {
                string[] stringSeparatorsV2 = new string[] { "\",\"" };
                string[] currentRow = currentStockPriceRow.Split(stringSeparatorsV2, StringSplitOptions.None);

                string stockSymbol = currentRow[0].Replace("\"", "");
                decimal price = Convert.ToDecimal(currentRow[2].Replace("\"", ""));

                Console.WriteLine("inserting daily price: " + date.ToString() + "-" + stockSymbol + "-" + price.ToString());

                db.InsertDailyPrice(stockSymbol, date, price);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error (moving on): " + e.Message);
            }
        }

        private void parseSpreadSheet(string contents)
        {
            string[] stringSeparators = new string[] { "\r\n" };
            string[] rows = contents.Split(stringSeparators, StringSplitOptions.None);

            DateTime date = DateTime.Parse(DateTime.Now.ToString("MMMM dd, yyyy"));

            Console.WriteLine("Writing file for " + date.ToString());

            int ctr = 0;
            foreach (string row in rows)
            {
                if (ctr > 0)
                {
                    save(row, date);
                    string[] stringSeparatorsV2 = new string[] { "\",\"" };
                    string[] currentRow = row.Split(stringSeparatorsV2, StringSplitOptions.None);

                    string stockSymbol = currentRow[0].Replace("\"", "");
                    decimal price = Convert.ToDecimal(currentRow[2].Replace("\"", ""));

                    Console.WriteLine("inserting daily price: " + date.ToString() + "-" + stockSymbol + "-" + price.ToString());

                    db.InsertDailyPrice(stockSymbol, date, price);
                }

                ctr++;
            }
        }
        private string setUrl(bool isNasdaq)
        {
            string url = Constants.DOWNLOAD_NASDAQ_NYSE_SPREADSHEET_URL_PREFIX;

            if (isNasdaq)
            {
                url += Constants.NASDAQ + Constants.DOWNLOAD_NASDAQ_NYSE_SPREADSHEET_URL_SUFFIX;
            }
            else
            {
                url += Constants.NYSE + Constants.DOWNLOAD_NASDAQ_NYSE_SPREADSHEET_URL_SUFFIX;
            }

            return url;
        }
        private string getDailySpreadsheet(bool isNasdaq)
        {
            WebResponse response = null;
            Stream dataStream = null;
            StreamReader reader = null;
            string ytd = string.Empty;
            string fileContents = string.Empty;

            try
            {
                string url = setUrl(isNasdaq);
                Console.WriteLine("HTTPGet: " + url);

                WebRequest request = WebRequest.Create(url);

                response = request.GetResponse();
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);

                fileContents = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseObjects(response, dataStream, reader);
            }

            return fileContents;
        }
        private void CloseObjects(
            WebResponse response,
            Stream dataStream,
            StreamReader reader)
        {
            if (dataStream != null)
            {
                dataStream.Close();
                dataStream.Dispose();
            }

            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }

            if (response != null)
            {
                response.Close();
                response.Dispose();
            }
        }
    }
}

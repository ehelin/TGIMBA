namespace GetYearToDate
{
    public class Constants
    {
        public const string NASDAQ = "nasdaq";
        public const string NYSE = "nyse";
        public const string DOWNLOAD_NASDAQ_NYSE_SPREADSHEET_URL_PREFIX = "http://www.nasdaq.com/screening/companies-by-name.aspx?letter=0&exchange=";
        public const string DOWNLOAD_NASDAQ_NYSE_SPREADSHEET_URL_SUFFIX = "&render=download";

        public const string INSERT_DAILY_PRICE = "declare @StockId bigint  "
                                             + "  select @StockId = StockId  "
                                             + "  from Investments.Stock  "
                                             + "  where StockSymbol = @StockSymbol  "
                                             + "    "
                                             + "  insert into Investments.StockPrice  "
                                             + "  select @StockId, 8, @price, @date, getdate(), 'script', getdate(), 'script' ";
    }
}

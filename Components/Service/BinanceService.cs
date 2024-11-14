namespace tokero_DCA_calculator.Components.Service
{
    public class BinanceService
    {
        private readonly HttpClient _httpClient;

        public BinanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetCryptoPriceAsync(string symbol, DateTime date)
        {
            // Construct the URL dynamically based on the symbol provided
            var dateString = date.ToString("yyyy-MM-dd");  // Format the date as "yyyy-MM-dd"
            //Get the price of a currency at a given day
            var url = $"https://api.binance.com/api/v3/klines?symbol={symbol}&interval=1d&startTime={new DateTimeOffset(date).ToUnixTimeMilliseconds()}&endTime={new DateTimeOffset(date.AddDays(1)).ToUnixTimeMilliseconds()}";

            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<List<object>>>(url);
                if (result != null && result.Any())
                {
                    // Get the closing price from the first data point (open, high, low, close, volume, etc.)
                    var closingPrice = result[0][4];  // The 5th element in the returned array is the closing price

                    if (decimal.TryParse(closingPrice.ToString(), out decimal price))
                        return price;
                    else
                    {
                        Console.WriteLine("Error parsing closing price.");
                        return 0;
                    }
                }
                else
                {
                    Console.WriteLine("No historical data found for the specified date.");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching price for {symbol}: {ex.Message}");
                return 0;
            }
        }
    }
}

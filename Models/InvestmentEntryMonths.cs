namespace tokero_DCA_calculator.Models
{
    public class InvestmentEntryMonths
    {
        public string Id { get; set; } = GenerateId();
        public DateTime StartDate { get; set; }
        public string Cryptocurrency { get; set; }
        public decimal InvestedAmount { get; set; }
        public decimal CryptocurrencyAmount { get; set; }
        public decimal valueAtDate { get; set; }
        public decimal ROI { get; set; }
        public decimal CryptoAmount { get; set; }
        public decimal PercentageInvestedAmount { get; set; }
        private static string GenerateId()
        {
            return Guid.NewGuid().ToString("N"); // Generates a unique 32-character ID
        }
    }
}

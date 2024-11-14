namespace tokero_DCA_calculator.Models
{
    public class InvestmentEntry
    {
        public DateTime StartDate { get; set; }
        public string Cryptocurrency { get; set; }
        public decimal InvestedAmount { get; set; }
        public decimal CryptocurrencyAmount { get; set; }
        public decimal valueAtDate { get; set; }
        public decimal ROI { get; set; }

        public decimal CryptoAmount { get; set; }

        public decimal PercentageInvestedAmount { get; set; }
        public List<PriceEntry> PriceEntries { get; set; }
    }
}

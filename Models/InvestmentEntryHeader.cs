namespace tokero_DCA_calculator.Models
{
    public class InvestmentEntryHeader
    {
        public string Id { get; set; } = GenerateId();
        public DateTime StartDate { get; set; }
        public string Cryptocurrency { get; set; }
        public decimal InvestedAmount { get; set; }
        public decimal PercentageInvestedAmount { get; set; }

        public static string GenerateId()
        {
            return Guid.NewGuid().ToString("N"); // Generates a unique 32-character ID
        }

    }
}

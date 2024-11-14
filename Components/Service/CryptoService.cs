using Microsoft.EntityFrameworkCore;
using tokero_DCA_calculator.Models;

namespace tokero_DCA_calculator.Components.Service
{
    public class CryptoService
    {
        private readonly CryptoContext _context;

        public CryptoService(CryptoContext context)
        {
            _context = context;
        }


        public Task<List<CryptoValue>> GetCryptocurrenciesAsync()
        {
            List<CryptoValue> result = new List<CryptoValue>();
            foreach (CryptoValue entry in _context.Cryptocurrencies)
            {
                result.Add(entry);
            }
            return Task.FromResult(result);
        }

        public Task<List<InvestmentEntryHeader>> GetInvestmentEntriesHeadersAsync()
        {
            List<InvestmentEntryHeader> result = new List<InvestmentEntryHeader>();
            foreach (InvestmentEntryHeader entry in _context.InvestmentEntriesHeaders)
            {
                result.Add(entry);
            }
            var sorted = result.OrderBy(entry => entry.Cryptocurrency).ToList();
            return Task.FromResult(sorted);
        }
        public async Task SaveInvestmentEntriesHeadersAsync(List<InvestmentEntryHeader> investmentEntries)
        {
            foreach (var entry in investmentEntries)
            {
                _context.InvestmentEntriesHeaders.Add(entry);
            }
            await _context.SaveChangesAsync();
        }

        public Task<List<InvestmentEntryMonths>> GetInvestmentEntriesForMonthsAsync()
        {
            List<InvestmentEntryMonths> result = new List<InvestmentEntryMonths>();
            foreach (InvestmentEntryMonths entry in _context.InvestmentEntriesMonths)
            {
                result.Add(entry); 
            }
            return Task.FromResult(result);
        }

        public async Task SaveInvestmentEntriesForMonthsAsync(List<InvestmentEntryMonths> investmentEntries)
        {
            foreach (var entry in investmentEntries)
            {
                _context.InvestmentEntriesMonths.Add(entry);
            }
            await _context.SaveChangesAsync();
        }


    }
}

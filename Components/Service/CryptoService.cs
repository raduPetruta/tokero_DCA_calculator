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

        public Task<List<CryptoValue>> GetCryptoValues()
        {
            List<CryptoValue> result = new List<CryptoValue>();
            
            foreach (CryptoValue crypto in _context.CryptoValues)
            {
                result.Add(crypto); 
            }
            
            return Task.FromResult(result);
        }


    }
}

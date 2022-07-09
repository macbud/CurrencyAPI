using CurrencyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyAPI.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly CurrencyContext _context;
        public CurrencyRepository(CurrencyContext context)
        {
            this._context = context;
        }
        public async Task<Currency> Create(Currency currency)
        {
            _context.Currencies.Add(currency);
            await _context.SaveChangesAsync();

            return currency;
        }

        public async Task Delete(int id)
        {
            var currencyToDelete = await _context.Currencies.FindAsync(id);
            _context.Currencies.Remove(currencyToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Currency>> Get()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currency> Get(int id)
        {
            return await _context.Currencies.FindAsync(id);
        }

        public async Task Update(Currency currency)
        {
            _context.Entry(currency).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
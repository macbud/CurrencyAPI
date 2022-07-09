using CurrencyAPI.Models;

namespace CurrencyAPI.Repositories
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> Get();
        Task<Currency> Get(int id);
        Task<Currency> Create(Currency currency);

        Task Update(Currency currency);
        Task Delete(int id);
    }
}

using CurrencyAPI.Models;
using CurrencyAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrenciesController(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            return await _currencyRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> GetCurrencies(int id)
        {
            return await _currencyRepository.Get(id);
        }
             
    }
}

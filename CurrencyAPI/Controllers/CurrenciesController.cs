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

        [HttpPost]
        public async Task<ActionResult<Currency>> PostCurrency([FromBody] Currency currency)
        {
            var newCurrency = await _currencyRepository.Create(currency);
            return CreatedAtAction(nameof(GetCurrencies), new { id = newCurrency.id }, newCurrency);
        }

        
        [HttpPut]
        public async Task<ActionResult<Currency>> PutCurrency(int id, [FromBody] Currency currency)
        {
            if(id != currency.id)
            {
                return BadRequest();
            }
            
            await _currencyRepository.Update(currency);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Currency>> DeleteCurrency(int id)
        {
            var currencyToDelete = await _currencyRepository.Get(id);
            if(currencyToDelete == null)
            {
                return NotFound();
            }
            await _currencyRepository.Delete(currencyToDelete.id);

            return NoContent();
        }
        
    }
}

using DbOperationWithEFcore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEFcore.Controllers
{
    [Route("api/Currency")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly appDbContext appDbContext;
        public CurrencyController(appDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        [HttpGet]
        public IActionResult GetAllCurrency()
        {
            var currencyList = appDbContext.Currency.ToList();
            return Ok(currencyList);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllCurrencyByIdAsync([FromRoute] int id)
        {
            var currencyList = await appDbContext.Currency.FindAsync(id);
            return Ok(currencyList);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetAllCurrencyByNameAsync([FromRoute] string name)
        {
            var currencyList = await appDbContext.Currency.Where(x => x.Title == name).FirstOrDefaultAsync();
            return Ok(currencyList);
        }

        [HttpGet("{name}/{Description}")]
        public async Task<IActionResult> GetAllCurrencyByNameAsync([FromRoute] string name, [FromRoute] string? Description)
        {
            var currencyList = await appDbContext.Currency.FirstOrDefaultAsync(x=> x.Title==name && x.Description==Description);
            return Ok(currencyList);
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetAllCurrencyByIdsAsync([FromBody] List<int> ids)
        {
            var currencyList = await appDbContext.Currency
                .Where(x=> ids.Contains(x.ID)).ToListAsync();
            return Ok(currencyList);
        }
    }
}

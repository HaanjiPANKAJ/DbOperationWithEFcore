using DbOperationWithEFcore.Data;
using DbOperationWithEFcore.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEFcore.Controllers
{
    [Route("api/Currency")]
    [CustomActionFilter]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly appDbContext appDbContext;
        private readonly IConfiguration configuration;

        public CurrencyController(appDbContext _appDbContext, IConfiguration  configuration)
        {
            appDbContext = _appDbContext;
            this.configuration = configuration;
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
            var x=configuration["Logging:LogLevel:Default"];
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

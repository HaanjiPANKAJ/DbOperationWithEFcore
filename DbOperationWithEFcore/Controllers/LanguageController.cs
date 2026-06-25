using DbOperationWithEFcore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEFcore.Controllers
{
    [Route("api/Language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly appDbContext _appDbContext;
        public LanguageController(appDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLanguage()
        {
            var languageList =await _appDbContext.Language.ToListAsync();
            return Ok(languageList);
        }
    }
}

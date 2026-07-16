using DbOperationWithEFcore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbOperationWithEFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly appDbContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(appDbContext appDbContext, ILogger<BooksController> logger)
        {
            _context = appDbContext;
            _logger = logger;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] Books book)
        {
            _logger.LogInformation("Adding new book");
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPost("Bulk")]
        public async Task<IActionResult> AddNewBooks([FromBody] List<Books> books)
        {
            await _context.Books.AddRangeAsync(books);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

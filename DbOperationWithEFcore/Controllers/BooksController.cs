using DbOperationWithEFcore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbOperationWithEFcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(appDbContext appDbContext) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] Books book)
        {
            appDbContext.Books.AddAsync(book);
            await appDbContext.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPost("Bulk")]
        public async Task<IActionResult> AddNewBooks([FromBody] List<Books> books)
        {
            appDbContext.Books.AddRangeAsync(books);
            await appDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace DbOperationWithEFcore.Data
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options)
        {

        }
    }
}

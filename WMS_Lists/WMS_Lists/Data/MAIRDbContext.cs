using Microsoft.EntityFrameworkCore;

namespace WMS_Lists.Data
{
    public class MAIRDbContext : DbContext
    {
        public MAIRDbContext(DbContextOptions<MAIRDbContext> options)
            : base(options)
        {
        }
    }
}

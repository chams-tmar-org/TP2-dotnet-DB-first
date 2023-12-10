using Microsoft.EntityFrameworkCore;

namespace ASPCoreApplication2023DBfirst.Models

{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
      
    }
}

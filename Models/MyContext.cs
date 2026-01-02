using Microsoft.EntityFrameworkCore;

namespace Webapinew.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext>options): base(options)
        {
                
        }
        public DbSet<Users> Users { get; set; }

    }


}

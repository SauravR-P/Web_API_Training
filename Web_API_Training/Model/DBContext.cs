using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Web_API_Training.Model
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            
        }
        public DbSet<Books> Books { get; set; }
    }
}

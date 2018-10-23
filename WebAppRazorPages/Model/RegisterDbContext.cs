using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppRazorPages.Model
{
    public class RegisterDbContext:DbContext
    {
        public RegisterDbContext(DbContextOptions<RegisterDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        
        public DbSet<User> Users { get; set; }
        
    }
}

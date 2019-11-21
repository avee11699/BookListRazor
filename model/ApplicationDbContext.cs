using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListrazor.model
{
    public class ApplicationDbContext: DbContext
    {
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }

        public DbSet<books> Books { get; set; }

    }
}

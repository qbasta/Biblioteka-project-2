using Biblioteka_project_2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka_project_2.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Authors> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Borrow> Borrows { get; set; }


    }
}
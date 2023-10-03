using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyWebAPINet6.Data
{
    public class BookStoreContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> opt) : base(opt) 
        {
            
        }

        #region DBSet
        public DbSet<Book>? Books { get; set; }
        #endregion
    }
}

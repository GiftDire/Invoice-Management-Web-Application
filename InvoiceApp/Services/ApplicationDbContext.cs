using Microsoft.EntityFrameworkCore;

//this class and package above is gonna  help us connect to our database

namespace InvoiceApp.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

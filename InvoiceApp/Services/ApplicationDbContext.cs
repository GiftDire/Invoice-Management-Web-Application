using InvoiceApp.Models;
using Microsoft.EntityFrameworkCore;


//this class and package above is gonna  help us connect to our database

namespace InvoiceApp.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; } = null!;
        //this where yo can to add the migration after getting done with the model
        //How Database Migrations Work in Entity Framework Core

        //Migrations in Entity Framework Core(EF Core) are a way to manage database schema changes over time.They allow you to create, update,
        //and maintain your database schema in sync with your C# model classes.
    }
}

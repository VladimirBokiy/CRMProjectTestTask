using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>().HasData(
            new Contact[]
            {
                new Contact{Name = "Ivan", Surname = "Ivanov", BirthDate = new DateTime(2000, 1, 1), 
                    JobTitle = "Trainee", MobilePhone = "+375291111111", ContactId = 1},
                new Contact{Name = "Petr", Surname = "Petrov", BirthDate = new DateTime(2001, 2, 2), 
                    JobTitle = "Intern", MobilePhone = "+375292222222", ContactId = 2},
            });
    }
}
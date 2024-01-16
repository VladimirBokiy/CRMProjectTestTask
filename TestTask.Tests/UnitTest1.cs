using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Services.Implementations;
using TestTask.Services.Interfaces;

namespace TestTask.Tests;

public class Tests
{
    private IContactService _contactService;
    [SetUp]
    public void Setup()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=contacts-db;User Id=sa;Password=pass12344321!;TrustServerCertificate=True");
        _contactService = new ContactService(new ApplicationContext(optionsBuilder.Options));
    }

    [Test]
    public void Test1()
    {
        var result = _contactService.GetContact(1);
        Assert.Equals(result.Name, "Ivan");
    }
}
using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class ContactService : IContactService
{
    private ApplicationContext _applicationContext;

    public ContactService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public List<Contact> GetContacts()
    {
        return _applicationContext.Contacts.ToList();
    }

    public Contact GetContact(int contactId)
    {
        return _applicationContext.Contacts.Find(contactId);
    }

    public void CreateContact(Contact contact)
    {
        _applicationContext.AddAsync(contact);
        _applicationContext.SaveChangesAsync();
    }

    public void UpdateContact(Contact contact)
    {
        var dbContact = _applicationContext.Contacts.Find(contact.ContactId);
        if (dbContact != null)
        {
            dbContact.Name = contact.Name;
            dbContact.Surname = contact.Surname;
            dbContact.JobTitle = contact.JobTitle;
            dbContact.BirthDate = contact.BirthDate;
            dbContact.MobilePhone = contact.MobilePhone;
            _applicationContext.Update(dbContact);
            _applicationContext.SaveChanges();
        }
    }

    public bool DeleteContact(int contactId)
    {
        var contact = _applicationContext.Contacts.Find(contactId);
        if (contact!= null)
        {
            _applicationContext.Contacts.Remove(contact);
            _applicationContext.SaveChanges();
            return true;
        }

        return false;
    }
}
using TestTask.Data;

namespace TestTask.Services.Interfaces;

public interface IContactService
{
    public List<Contact> GetContacts();

    public Contact GetContact(int contactId);

    public void CreateContact(Contact contact);
    
    public void UpdateContact(Contact contact);

    public bool DeleteContact(int contactId);
}
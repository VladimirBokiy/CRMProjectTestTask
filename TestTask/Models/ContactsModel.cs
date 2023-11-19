using TestTask.Data;

namespace TestTask.Models;

public class ContactsModel
{
    public IEnumerable<Contact> Contacts { get; set; } 
    
    public Contact Contact { get; set; }
    public ContactsModel(IEnumerable<Contact> contacts, Contact contact)
    {
        Contacts = contacts;
        Contact = contact;
    }
    
    
}
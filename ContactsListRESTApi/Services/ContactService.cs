using ContactsListRESTApi.Models;

namespace ContactsListRESTApi.Services;

public static class ContactService
{
    static List<Contact> Contacts { get; }
    static int nextId = 0;

    static ContactService()
    {
        Contacts = new List<Contact>
        {
        };
    }

    public static List<Contact> GetAll() => Contacts;

    public static Contact? Get(int id) => Contacts.FirstOrDefault(c => c.Id == id);

    public static void Add(Contact c)
    {
        c.Id = nextId++;
        Contacts.Add(c);
    }

    public static void Delete(int id)
    {
        var contact = Get(id);
        if (contact is null) return;
        Contacts.Remove(contact);
    }

    public static void Update(Contact c)
    {
        var index = Contacts.FindIndex(contact => c.Id == contact.Id);
        if (index == -1) return;
        Contacts[index] = c;

    }

}
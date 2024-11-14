using model = RSystem.Contact.Model;

namespace RSystem.Contact.Business
{
    public interface IContactService
    {
        IEnumerable<model.Contact> GetContacts();
        model.Contact GetContact(int id);
        bool SaveContact(model.Contact contact);
        bool UpdateContact(int id, model.Contact contact);
        bool DeleteContact(int id);
    }
}

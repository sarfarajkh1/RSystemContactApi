using RSystem.Contact.Business;
using RSystem.Contact.Data.FileSystem.DataHelper;

namespace RSystem.Contact.Data.FileSystem
{
    public class ContactService : IContactService
    {
        public bool DeleteContact(int id)
        {
            return JsonFileHelper.DeleteContact(id);
        }

        public Model.Contact GetContact(int id)
        {
            return JsonFileHelper.GetContact(id);
        }

        public IEnumerable<Model.Contact> GetContacts()
        {
            return JsonFileHelper.GetContacts();
        }

        public bool SaveContact(Model.Contact contact)
        {
            return JsonFileHelper.SaveContact(contact);
        }

        public bool UpdateContact(int id, Model.Contact contact)
        {
            return JsonFileHelper.UpdateContact(id, contact);
        }
    }
}

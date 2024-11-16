using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RSystem.Contact.Data.FileSystem.DataHelper
{
    public class JsonFileHelper
    {
        private const string filePath = @"bin\Debug\net8.0\Data\Contact.json";
        public static IEnumerable<Model.Contact> GetContacts()
        {
            var emptyData = new List<Model.Contact>();
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<IEnumerable<Model.Contact>>(json) ?? emptyData;
            }
            catch (Exception)
            {
                return emptyData;
            }
            
        }

        public static Model.Contact GetContact(int id)
        {
            try
            {
                var contacts = GetContects();
                var existingContact = contacts.FirstOrDefault(c => c["Id"]?.Value<int>() == id);
                if (existingContact != null)
                    return existingContact.ToObject<Model.Contact>();
                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static bool SaveContact(Model.Contact contact)
        {
            try
            {
                var contacts = GetContects();
                var maxId = contacts.Max(c => c["Id"]?.Value<int>()) ?? 0;
                contact.Id = maxId + 1;
                contacts.Add(JObject.FromObject(contact));
                Save(contacts);
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public static bool UpdateContact(int id, Model.Contact contact)
        {
            try
            {
                var contacts = GetContects();
                var existingContact = contacts.FirstOrDefault(c => c["Id"]?.Value<int>() == id);
                if (existingContact != null)
                {
                    existingContact["FirstName"] = contact.FirstName;
                    existingContact["LastName"] = contact.LastName;
                    existingContact["EmailId"] = contact.EmailId;
                    Save(contacts);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteContact(int id)
        {
            try
            {
                var contacts = GetContects();
                var existingContact = contacts.FirstOrDefault(c => c["Id"]?.Value<int>() == id);
                if (existingContact != null)
                {
                    contacts.Remove(existingContact);
                    Save(contacts);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static JArray GetContects()
        {
            var json = File.ReadAllText(filePath);
            return JArray.Parse(json);
        }

        private static void Save(JArray contacts)
        {
            string newJsonResult = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(filePath, newJsonResult);
        }
    }
}

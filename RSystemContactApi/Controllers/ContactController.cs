using Microsoft.AspNetCore.Mvc;
using RSystem.Contact.Business;
using RSystem.Contact.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RSystemContactApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(IContactService contactService) : ControllerBase
    {
        private readonly IContactService _contactService = contactService;

        [HttpGet]
        [Route("get")]
        public IEnumerable<Contact> Get()
        {
            return _contactService.GetContacts();
        }

        [HttpGet()]
        [Route("get/{id}")]
        public Contact Get(int id)
        {
            return _contactService.GetContact(id);
        }

        [HttpPost]
        [Route("save")]
        public bool Post([FromBody] Contact contact)
        {
            return _contactService.SaveContact(contact);
        }

        [HttpPut()]
        [Route("update/{id}")]
        public bool Put(int id, [FromBody] Contact contact)
        {
            return _contactService.UpdateContact(id, contact);
        }

        [HttpDelete()]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            return _contactService.DeleteContact(id);
        }
    }
}

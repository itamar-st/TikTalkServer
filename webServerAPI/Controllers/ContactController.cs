using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Services;
using Domain;
using System.Text.Json.Nodes;
using webServerAPI.Controllers;

namespace ChatServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //controller for the Contact model
    public class contactsController : ControllerBase
    {
        private static IContactService _contactService;

        public contactsController()
        {
            _contactService = new ContactService();
        }
        [HttpGet]
        // GET: api/contacts
        public IActionResult Index(string user)
        {
            List<Contact> contacts = _contactService.GetAll(user);
            if (contacts == null)
            {
                return BadRequest();
            }
            return Ok(contacts);
        }
        [HttpGet("{contactId}")]
        // GET: api/contacts/{id} 
        public IActionResult Details(string user, string contactId)
        {
            Contact contact = _contactService.Get(user, contactId);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
        // POST: api/contacts
        [HttpPost]
        public IActionResult Create(string user, [Bind("Id, Name, Server")] Contact contact)
        { 
            if(_contactService.Create(user, contact) == false)
            {
                return BadRequest();
            }
            return Created("api/contacts", "");
        }
        [HttpPut("{contactId}")]
        //PUT: api/contacts/{id}
        public IActionResult Edit(string user, string contactId, [FromBody] JsonObject content)
        {
            if (_contactService.Edit(user, contactId, content) == false) {
                return BadRequest();
            }
            return NoContent();

        }
        [HttpDelete("{contactId}")]
        // DELETE: api/contacts/{id}
        public IActionResult Delete(string user, string contactId)
        {
            if(_contactService.Delete(user, contactId) == false)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}

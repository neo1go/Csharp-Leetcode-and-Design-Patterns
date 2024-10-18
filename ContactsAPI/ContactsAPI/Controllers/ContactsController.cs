using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]            //andere Variante anstatt ("api/contacts")
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;

        public ContactsController(ContactsAPIDbContext dbContext)  //DI von ContactsAPIDbContext into ContactsController
        {
            this.dbContext = dbContext;
        }

        [HttpGet]//wird in URL ausgeführt, Rückgabetyp ist ein Objekt com Typ IActionResult 
                 //IActionResult stellt nur einen Task bereit um alle HTTP Requests zu behandeln
        public async Task<IActionResult> GetAllContacts()            //Methode
        {
                                    //Contacts ist die Property die bei DBSet Queries einleiten kann
            return Ok(await dbContext.Contacts.ToListAsync());  //Hier wird DBSet ausgelöst von der Property Contacts
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound("Dieser Kontakt existiert nicht");
            }
            return Ok(contact);
        }

        [HttpPost]//Wird im Body ausgeführt
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                FullName = addContactRequest.FullName,
                Email = addContactRequest.Email,
                Telefon = addContactRequest.Telefon,

            };


            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            return Ok(contact);
        }


        [HttpPut]  //Attribute,auch Annotations also z.B. Metadaten genannt, in diesem Fall Routensteuerung im WebAPI-Projekt
        [Route("{id:guid}")]//Guid ist schon vorhanden und wird auch nicht verändert beim Update
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactRequest updateContactRequest)
        //Die Bezeichnung id muß identisch sein mit route
        {
            var contact = await dbContext.Contacts.FindAsync(id);    
            if (contact != null)
            {
                contact.FullName = updateContactRequest.FullName;
                contact.Email = updateContactRequest.Email;
                contact.Telefon = updateContactRequest.Telefon;
                contact.Address = updateContactRequest.Address;

                await dbContext.SaveChangesAsync();

                return Ok(contact);
            }

            return NotFound("Kein bestehender Eintrag zum Updaten vorhanden.");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);

            if (contact != null)
            {
                dbContext.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok("Kontakt erfolgreich gelöscht.");
            }
            return NotFound("Dieser Kontakt existiert nicht.");
        }

    }
}

using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//Hierbei handelt es sich um eine Anwendung zur Datenbankverwaltung.
//Das Framework ist ASP.NET.Core, also eine Desktopanwendung für MS Rechner mit
//Entity Framework Core als Datenbank-ORM zur Datenverwaltung.
//Durch ORM (object relational mapping) wird ind diesem Fall code-first eine Datenbank erstellt und die C#-Objekte werden
//in Datenbanktabellen umgewandelt.

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
                 //IActionResult stellt nur einen Task bereit um alle HTTP-Requests zu behandeln.
        public async Task<IActionResult> GetAllContacts()            //Methode
        {
                                    //Contacts ist die Property, die bei DBSet dann Queries einleiten kann.
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

        //Attribute,auch Annotations also z.B. Metadaten genannt, in diesem Fall Routensteuerung im WebAPI-Projekt
        [HttpPut]  //Update
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

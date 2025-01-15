using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Dies ist die PresentationLayer PL mit integriertem BuisnessLogicLayer BLL und dem DataAccesLayer DAL.
// (Sonderfall: bei größeren Anwendungen wird dies alles getrennt.)
// PL - Nimmt HTTP-Anfragen entgegen und gibt HTTP-Antworten zurück -> ContactsController
// BLL - Geschäftslogik -> AddContact, UpdateContact , gehört normalerweise in eine Service-Klasse.
// DAL - dbContext.Contacts.ToListAsync() wird normalerweise in eine repository Klasse ausgelagert.


// Hier werden die eingehenden HTTP-Anfragen verarbeitet und entsprechende Antworten gesendet
// Es wird mit DBContext kommuniziert um die Daten zu laden oder zu speichern (GET,POST,PUT,DELETE).
// Hier werden Geschäftslogik sowie API-Endpunkte implementiert.


namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]            //andere Variante anstatt ("api/contacts")
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;   // DI 

        public ContactsController(ContactsAPIDbContext dbContext)  //Übergabe von ContactsAPIDbContext into ContactsController
        {
            this.dbContext = dbContext;
        }

        [HttpGet]//wird in URL ausgeführt, Rückgabetyp ist ein Objekt com Typ IActionResult 
                 //IActionResult stellt nur einen Task bereit, um alle HTTP-Requests zu behandeln.
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

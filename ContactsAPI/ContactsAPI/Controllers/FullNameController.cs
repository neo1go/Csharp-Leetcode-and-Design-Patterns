using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

// Dies ist die presentation Layer
// Hier werden die eingehenden HTTP-Anfragen verarbeitet und entsprechende Antworten gesendet
// Es wird mit DBContext kommuniziert um die Daten zu laden oder zu speichern (GET,POST,PUT,DELETE).
// Hier werden Geschäftslogik sowie API-Endpunkte implementiert.

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]       //Achtung, unten sollte man Route nicht nochmal nutzen.
    public class FullNameController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;

        public FullNameController(ContactsAPIDbContext dbContext)  //Dies ist DI von DBContext
        {
            this.dbContext = dbContext;
        }


        //Das stored Procedure wird hier angesteuert

        [HttpGet("dbo.GetCustomerByFullName")]
        public async Task<IActionResult> GetCustomerByFullName(string fullName)
        {

            if (string.IsNullOrEmpty(fullName))
            {
                return BadRequest("Vollständiger Name ist erforderlich.");
            }
            Console.WriteLine($"Received fullName: {fullName}");

            try
            {
                var contacts = await dbContext.Set<FullNameContactRequest>()
                    .FromSqlRaw("EXEC dbo.GetCustomerByFullName @FullName = {0}",new SqlParameter("@FullName",fullName))
                    .ToListAsync();//Um alle Treffer zu bekommen

                if (contacts.Count == 0 )
                {
                    return NotFound("Dieser Kontakt existiert nicht.");
                }
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                return StatusCode(500, "Interner Serverfehler. Bitte versuchen Sie es später noch einmal.");
            }
        }
    }
}

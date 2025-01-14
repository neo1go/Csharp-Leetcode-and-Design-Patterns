
// Dies ist ein DTO
// hier wird nur angezeigt was benötigt wird, solange es vom SP auch abgefragt wird.
// Ich lasse zwar vom SP alle Tabellen (FullName,Email,Telefon,Address) abfragen und übertragen;
// es werden aber nur die Tabellen, die in diesem DTO verlangt werden, ausgelesen und angezeigt.
// Dies kann natürlich zu overhead führen.
// Man könnte natürlich auch das SP(stored procedure) entsprechend anpassen und nur die Daten senden lassen,
// die wirklich benötigt werden.

namespace ContactsAPI.Models
{
    public class FullNameContactRequest
    {
        public string? FullName { get; set; }
      //  public string? Email { get; set; }
      //  public string? Telefon { get; set; }
        public string? Address { get; set; }
    }
}

using ContactsAPI.Data;
using Microsoft.EntityFrameworkCore;

//Hierbei handelt es sich um eine Anwendung zur Datenbankverwaltung.
//Das Framework ist ASP.NET.Core, also eine Desktopanwendung für MS Rechner mit
//Entity Framework Core als Datenbank-ORM zur Datenverwaltung.
//Durch ORM (object relational mapping) wird ind diesem Fall code-first eine Datenbank erstellt und die C#-Objekte werden
//in Datenbanktabellen umgewandelt.


//Mittels dieses Codes in der EF Core CLI wird der CodeFirst-Ansatz ausgeführt
//dotnet ef migrations add InitialCreate

//Hiermit wird die bestehende DB geupated:
//dotnet ef database update

//Hiermit wird ausgelesen, ob schon eine DB erstellt wurde:
//dotnet ef migrations list

//Hiermit werden neue Tabellen oder Spalten hinzugefügt:
//dotnet ef migrations add AddNewTableOrColumn

//Danach wieder mit 'dotnet ef database update' die Migration erneuern.


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Neu hinzugefügt für inMemory um nicht die db zu nutzen z.B.
//builder.Services.AddDbContext<ContactsAPIDbContext>(options => options.UseInMemoryDatabase("ContactsDb"));



//neu mit Microsoft SQL Server Magagement Studio SSMS verbinden
//Hier wird also die Anwendung tatsächlich mit der Datenbank verbunden.
builder.Services.AddDbContext<ContactsAPIDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsApiConnectionString"))); //String aus appsettings.json
                                                                              //der die Zugangsdaten und Beechtigungen enthält.



var app = builder.Build();  //die Grundvariable auf der die ganzen Abfragen im Moment ruhen.

// Configure the HTTP request pipeline.
//IsDevelopment kann dann auch umgestellt werden
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Bin mir nicht sicher ob ich hier auch die Authorisierung komplett für Übungszwecke abschalten kann wenn ich
//auskommentiere (in appsettings.json müsste dann die Zeile geändert werden für "ContactsApiConnectionString"
app.UseAuthorization();

app.MapControllers();

app.Run();

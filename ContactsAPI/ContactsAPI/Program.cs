using ContactsAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Neu hinzugefügt für inMemory um nicht die db zu nutzen z.B.
//builder.Services.AddDbContext<ContactsAPIDbContext>(options => options.UseInMemoryDatabase("ContactsDb"));



//neu mit Microsoft SQL Server Magagement Studio SSMS verbinden
builder.Services.AddDbContext<ContactsAPIDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsApiConnectionString"))); //String aus appsettings.json
                                                                              //der die Zugangsdaten und Beechtigungen enthält



var app = builder.Build();  //die Grundvariable auf der die ganzen Abfragen im Moment ruhen

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

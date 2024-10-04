using DependencyInjectionBlazorDemo;
using DependencyInjectionBlazorDemo.Logic;


var builder = WebApplication.CreateBuilder(args);              //Neue Instanz des WebApp Builders

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<IDemoLogic, DemoLogic>();
//builder.Services.AddTransient<IDemoLogic, BetterDemoLogic>();
//builder.Services.AddSingleton<IDemoLogic, DemoLogic>();
builder.Services.AddSingleton<CounterService>();

//Der Klassentyp wird für dependecy injection den Services' hinzugefügt
//Transient => erzeugt jedesmal eine neue Instanz bei Seitenaufruf
//Singleton => diesselbe Instanz bleibt bestehen während der ganzen Laufzeit
//Scoped =>  jeder Tab oder jeder Neuaufruf erzeugt eine neue Instanz
//die dann aber lokal gleichbleibt und nicht mehr verändert wird


//In der Debug-Ausgabe sind nun bei der Neuinstanziierung immer zwei Zeilen für die Erzeugung zu sehen
//einmal serverseitig und einmal clientseitig. Dies sollte beibehalten werden





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

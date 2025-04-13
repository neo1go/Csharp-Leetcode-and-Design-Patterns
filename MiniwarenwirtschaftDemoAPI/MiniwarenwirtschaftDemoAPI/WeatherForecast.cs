using MiniwarenwirtschaftDemoAPI.Repository;
using MiniwarenwirtschaftDemoAPI.Data;
using MiniwarenwirtschaftDemoAPI.Service;


{


    var builder = WebApplication.CreateBuilder(args);

    // Datenbank einrichten (SQLite für Einfachheit)
    builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=mini_wawi.db"));

    // Services und Repositories registrieren
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IProductService, ProductService>();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Migration bei Bedarf
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

















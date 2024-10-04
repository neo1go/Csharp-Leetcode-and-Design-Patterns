var builder = WebApplication.CreateBuilder(args);

//dies ist di, also dependency injection
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//in einer minimal Api gibt es keine Controller

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//hier wird ein Endpoint gemappt. Dies ist der gleiche Code wie im WeatherForecastController
//Es gibt auch MapGet, MapDelete, MapPut etc.
app.MapGet("/testing", () => "Hello World");


app.Run();


using PokemonLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });

    options.AddPolicy(name: "AllowOnlyHost",
                      policy =>
                      {
                          policy.WithOrigins("https://hill-pokemonapi.azurewebsites.net")
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();
builder.Services.AddSingleton<PokemonsRepository>(new PokemonsRepository());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseCors("AllowOnlyHost");
app.UseAuthorization();
app.MapControllers();
app.Run();

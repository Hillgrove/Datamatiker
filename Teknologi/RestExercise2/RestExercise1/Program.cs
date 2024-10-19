using PokemonLib;

const string ALLOW_ALL_POLICY = "AllowAll";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: ALLOW_ALL_POLICY,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
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

app.UseCors(ALLOW_ALL_POLICY);
app.UseAuthorization();
app.MapControllers();
app.Run();

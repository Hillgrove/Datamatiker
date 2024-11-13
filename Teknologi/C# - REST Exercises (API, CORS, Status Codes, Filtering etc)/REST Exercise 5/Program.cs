using PokemonLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("OpenGetPolicy", policy => policy.AllowAnyOrigin().WithMethods("GET").AllowAnyHeader());
    //policy.WithOrigins("https://trusted-site.com", "https://another-site.com");
    options.AddPolicy("RestrictedPolicy", policy => policy.WithOrigins("http://zealand.dk").AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<PokemonsRepository>(new PokemonsRepository());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("OpenGetPolicy"); // always before app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.Run();

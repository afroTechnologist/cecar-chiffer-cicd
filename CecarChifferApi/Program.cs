using CecarChifferApi.Interfaces;
using CecarChifferApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Lägg till tjänster
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrera CipherService
builder.Services.AddScoped<ICipherService, CipherService>();

var app = builder.Build();

// Konfigurera HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
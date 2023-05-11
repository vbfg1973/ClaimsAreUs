using ClaimsAreUs.Api.Extensions;
using ClaimsAreUs.Data;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.ConfigureApp();
builder.ConfigureLogging();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabase(appSettings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase<ClaimsAreUsContext>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

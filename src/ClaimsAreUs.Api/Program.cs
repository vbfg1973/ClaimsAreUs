using ClaimsAreUs.Api.Extensions;
using ClaimsAreUs.Api.Support;
using ClaimsAreUs.Data;
using ClaimsAreUs.Domain.Features.Companies.Commands.ClaimUpdate;
using ClaimsAreUs.Domain.Support;
using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.ConfigureApp();
builder.ConfigureLogging();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<DomainAssemblyReference>();
builder.Services.AddSwaggerAndConfig();
builder.Services.AddVersioning();
builder.Services.AddDatabase(appSettings);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(DomainAssemblyReference.Assembly));
builder.Services.AddAutoMapper(DomainAssemblyReference.Assembly, ApiAssemblyReference.Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase<ClaimsAreUsContext>();
app.UseCorrelationId();
app.UseCustomExceptionHandler();
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

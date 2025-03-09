using HomeBillings.Core.Identidade;
using HomeBillings.Entradas.API.Data.Context;
using HomeBillings.Entradas.API.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EntryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddDependencyInjectionRegister();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJwtConfiguration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

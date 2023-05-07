using DiscoveryService.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = ProgramHelper.ConfigureLoggign(builder.Environment.IsDevelopment());
builder.Host.UseSerilog(logger);
Log.Logger = logger;

builder = ProgramHelper.ConfigureServices(builder);

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
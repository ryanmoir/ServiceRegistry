namespace DiscoveryService.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc.Versioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using DiscoveryService.Entity;
    using Serilog;
    using Serilog.Core;
    using System;

    public static class ProgramHelper
    {
        public static WebApplicationBuilder ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                o.ReportApiVersions = true;
                o.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("ver"));
            });

            var optionBuilder = new DbContextOptionsBuilder<DataContext>();
            optionBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=TemplateToScaffold;Trusted_Connection=True;");
            builder.Services.AddSingleton(x => new DataContextFactory(optionBuilder.Options));

            return builder;
        }

        public static Logger ConfigureLoggign(bool isDev)
        {
            var jsonFile = "appsettings.json";
            if (isDev)
            {
                jsonFile = "appsettings.development.json";
            }

            var config = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile(jsonFile).Build();

            return new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}

namespace ServiceRegistory.Api
{
    using ServiceRegistory.Api.Helper;
    using ServiceRegistory.Api.Helpers.Interface;
    using ServiceRegistory.Business.Services.Implmentation;
    using ServiceRegistory.Business.Services.Interface;
    using ServiceRegistory.Entity;
    using ServiceRegistory.EntityAcceess.Repository.Implmentation;
    using ServiceRegistory.EntityAcceess.Repository.Interface;
    using ServiceRegistory.EntityAcceess.UnitOfWork.Implmentation;
    using ServiceRegistory.EntityAcceess.UnitOfWork.Interface;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc.Versioning;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
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
            optionBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=ServiceRegistory;TrustServerCertificate=Yes;Integrated Security=False;User ID=test;Password=password;");
            optionBuilder.EnableSensitiveDataLogging();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(x => new UnitOfWork(new DataContextFactory(optionBuilder.Options)));
            builder.Services.AddScoped<IDiscoveryRespository, DiscoveryRespository>();
            builder.Services.AddScoped<IRegistoryRepository, RegistoryRespository>();

            builder.Services.AddScoped<IControllerHelper, ControllerHelper>(x => new ControllerHelper());

            builder.Services.AddScoped<IDiscoveryService, DiscoveryService>();
            builder.Services.AddScoped<IRegistoryService, RegistoryService>();
            builder.Services.AddScoped<IRequestService, RequestService>();

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

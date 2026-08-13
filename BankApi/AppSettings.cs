using BankApi.Data;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation.AspNetCore;
using BankApi.Services;
using BankApi.Models;

namespace BankApi
{
    public static class AppSettings
    {
        public static IServiceCollection AddProgramSettings(
            this IServiceCollection services,ConfigurationManager configuration) {
            services.AddConnectionString(configuration);
            services.AddMapping();
            services.AddServices();
            services.UseValidation();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IEmployee,EmployeeService>();
            service.AddScoped<IParty,PartyService>();
            service.AddScoped<IContract,ContractService>();
            service.AddScoped<ICurrency,CurrencyService>();
            service.AddScoped<IFacility,FacilityService>();
            service.AddScoped<IDisbursement,DisbursementService>();
            service.AddScoped<IBank,BankService>();
            service.AddScoped<IFileService,FileService>();
            return service;
        }
        public static IServiceCollection AddConnectionString(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            string connectionString = configuration["ConnectionStrings:DefaultConnection"]??"";
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
        public static IServiceCollection AddMapping(this IServiceCollection services) {
            services.AddMapster();//cs01061
            TypeAdapterConfig config= TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            return services;
                }

        public static IServiceCollection UseValidation(this IServiceCollection service)
        {
            service.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); //cs01061
            return service;
        }
    }
}

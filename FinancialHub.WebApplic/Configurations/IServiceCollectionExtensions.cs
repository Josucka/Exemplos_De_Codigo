using FinancialHub.Domain.Interfaces.Repositories;
using FinancialHub.Domain.Interfaces.Services;
using FinancialHub.Service.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using FinancialHub.Domain.Interfaces.Mappers;
using FinancialHub.Service.Mappers;
using FluentValidation;
using FinancialHub.Domain.Models;
using FinancialHub.Data.Repositories;
using FinancialHub.WebApplic.Validators;

namespace FinancialHub.WebApplic.Configurations
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddApiConfigurations(this IServiceCollection service)
        {
            service.AddControllers();
            service.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            return service;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ITransactionRepository, TransactionsRepository>();

            services.AddScoped<IBalancesRepository, BalancesRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(FinancialHubAutoMapperProfile));
            services.AddScoped<IMapperWrapper, FinancialHubMapperWrapper>();

            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            //services.AddScoped<ITransactionsService, TransactionsService>();
            services.AddScoped<IBalancesService, BalancesService>();

            services.AddScoped<IAccountBalanceService, AccountBalanceService>();
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            //services.AddFluentValidation(x =>
            //{
            //    x.AutomaticValidationEnabled = true;
            //    x.DisableDataAnnotationsValidation = true;
            //});
            services.AddScoped<IValidator<AccountModel>, AccountValidator>();
            services.AddScoped<IValidator<CategoryModel>, CategoryValidator>();
            services.AddScoped<IValidator<TransactionModel>, TransactionValidator>();
            return services;
        }
    }
}

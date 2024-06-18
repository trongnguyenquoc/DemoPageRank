using System.Reflection;
using DemoPageRank.API.Application.Commands;
using DemoPageRank.API.Validations;
using DemoPageRank.Domain.Interfaces;
using DemoPageRank.Infrastructure;
using DemoPageRank.Infrastructure.Repositories;
using FluentValidation;

namespace DemoPageRank.API.Extensions;

public static class ApplicationExtensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddDbContext<PageRankDbContext>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddHttpClient();

        // Register for validators
        services.AddSingleton<IValidator<SearchPageRankCommand>, SearchPageRankCommandValidation>();

        // Register for services
        services.AddScoped<IPageRankRepository, PageRankRepository>();
    }
}

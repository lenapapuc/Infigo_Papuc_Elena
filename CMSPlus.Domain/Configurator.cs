using CMSPlus.Domain.Interfaces;
using CMSPlus.Domain.Persistance;
using CMSPlus.Domain.Repositories;
using CMSPlus.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CMSPlus.Domain;

public static class Configurator
{
    public static void AddDomain(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddScoped<ITopicRepository, TopicRepository>();
        services.AddScoped<ICommentaryRepository, CommentaryRepository>();
    }

    public static void AddMigrations(this IServiceCollection services, string? connectionString)
    {
        services.AddSingleton<IMigrationService>(new MigrationService(connectionString));
        using (ServiceProvider serviceProvider = services.BuildServiceProvider())
        {
            var migrationService = serviceProvider.GetRequiredService<IMigrationService>();
            migrationService.Migrate();
        }
    }
}
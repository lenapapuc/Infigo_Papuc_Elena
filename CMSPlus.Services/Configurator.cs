using CMSPlus.Services.Interfaces;
using CMSPlus.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CMSPlus.Services;

public static class Configurator
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<ICommentaryService, CommentaryService>();

    }
}
using CMSPlus.Domain.Models.CommentaryModels;
using CMSPlus.Domain.Models.TopicModels;
using CMSPlus.Domain.Persistance;
using CMSPlus.Presentation.AutoMapperProfiles;
using CMSPlus.Presentation.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMSPlus.Presentation;

public static class Configurator
{
    public static void AddPresentation(this IServiceCollection services)
    {
        services.AddRazorPages().AddRazorRuntimeCompilation();
        services.AddScoped<TopicValidatorHelpers>();
        services.AddScoped<IValidator<TopicCreateModel>, TopicCreateModelValidator>();
        services.AddScoped<IValidator<TopicEditModel>, TopicEditModelValidator>();
        services.AddScoped<IValidator<CommentaryCreateModel>, CommentaryCreateModelValidator>();
        //Added clearing automatic model validation as the error messages doubled 
        services.AddControllersWithViews(options => options.ModelValidatorProviders.Clear());
        services.AddValidatorsFromAssemblyContaining<TopicEditModelValidator>();
        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddDatabaseDeveloperPageExceptionFilter();
        services.AddControllersWithViews(options => options.ModelValidatorProviders.Clear());
       
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            //todo read via reflection
            cfg.AddProfile<TopicProfile>();
           
        }, typeof(Program).Assembly);

        services.AddAutoMapper(cfg =>
        {
            //todo read via reflection
     
            cfg.AddProfile<CommentaryProfile>();
        }, typeof(Program).Assembly);

    }
}
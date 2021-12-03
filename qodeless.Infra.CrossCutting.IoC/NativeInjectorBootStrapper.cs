using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using qodeless.application;
using qodeless.domain.Interfaces;
using qodeless.domain.Interfaces.Repositories;
using qodeless.domain.Repositories;
using qodeless.Infra.CrossCutting.Identity.Authorization;
using qodeless.Infra.CrossCutting.Identity.Data;
using qodeless.Infra.CrossCutting.Identity.Entities;
using qodeless.Infra.CrossCutting.Identity.Repositories;
using qodeless.Infra.CrossCutting.Identity.Services;

namespace qodeless.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();

            // Data - Repository
            services.AddScoped<IAccountRepository, AccountRepository>();

            // Application - Services
            services.AddScoped<IAccountAppService, AccountAppService>();

            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IAppDbContext, ApplicationDbContext>();
        }
    }
}

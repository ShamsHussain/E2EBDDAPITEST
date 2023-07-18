using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using WorkflowBddFramework.Configuration;
using WorkflowBddFramework.Helpers;
using WorkflowBddFramework.Core;
using System.Net.NetworkInformation;
using FluentAssertions;
using WorkflowBddFramework.Models.Payload;
using ProceduresBDDFramework.Core;

namespace WorkflowBddFramework
{
    public static class StartUp
    {
        [ScenarioDependencies]
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .Build();

            services.AddSingleton(configuration.GetSection("SpecFlow").Get<SpecFlowConfig>());
            services.AddSingleton(configuration.GetSection("Auth").Get<AuthConfig>());
            services.AddSingleton(services.BuildServiceProvider());
            services.AddScoped<CreatePayload>();
            services.AddScoped<BusinessUtilsAPI>();
            services.AddScoped<RequestAndResponse>();
            services.AddScoped<Helper>();
            services.AddScoped<RoleUser>();
            services.AddScoped<Workflow>();
            return services;
        }
    }
}

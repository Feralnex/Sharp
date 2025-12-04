using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Sharp
{
    public static partial class Settings
    {
        private static readonly Gate _gate;

        public static IServiceCollection ConfigureSettings<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TSettings>(this IServiceCollection services, IConfigurationSection section)
            where TSettings : class
        {
            _gate.IfClosed(OnClosed, services);

            services.Configure<TSettings>(section);

            return services.AddTransient<ISettings, Instance<TSettings>>();
        }

        private static void OnClosed(IServiceCollection services)
        {
            services.AddHostedService<Service>();

            _gate.Open();
        }
    }
}

using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sharp
{
    public static partial class Settings
    {
        private class Service : IHostedService
        {
            public Service(IEnumerable<ISettings> settings)
            {
                foreach (ISettings setting in settings)
                    TryAdd(setting);
            }

            public Task StartAsync(CancellationToken cancellationToken)
                => Task.CompletedTask;

            public Task StopAsync(CancellationToken cancellationToken)
            {
                _gate.Close();

                return Task.CompletedTask;
            }
        }
    }
}

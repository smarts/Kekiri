using Kekiri.Xunit;
using System.Threading.Tasks;
using Kekiri.IoC;

namespace Kekiri.Examples.Xunit
{
    public class ExampleScenarios : Scenarios
    {
        protected override Task BeforeAsync()
        {
            return BootstrapHelper.EnsureBootstrapped();
        }
    }

    public class ExampleScenariosTyped<T> : Scenarios<T>
    {
        protected override Task BeforeAsync()
        {
            return BootstrapHelper.EnsureBootstrapped();
        }
    }

    public static class BootstrapHelper
    {
        static readonly object _lockObject = new object();
        static bool _isInitialized = false;

        public static Task EnsureBootstrapped()
        {
            if (!_isInitialized)
            {
                lock (_lockObject)
                {
                    if (!_isInitialized)
                    {
                        var services = new ServiceProviderBootstrapper()
                            .UseStartup<WebApp.Startup>()
                            .OverrideServicesWithTypesFromAssemblyOf<ExampleScenarios>()
                            .BuildServiceProvider();

                        ServiceProviderBootstrapper.Initialize(services);
                        _isInitialized = true;
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}
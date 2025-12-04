using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sharp.Tests
{
    public class SettingsTests : IDisposable
    {
        public void Dispose()
        {
            Settings.Clear();
        }

        [Fact]
        public void TryAdd_WhenSettingsWereAdded_ShouldReturnTrue()
        {
            // Arrange
            long expectedTimeout = 10000;
            TestSettings settings = new TestSettings()
            {
                IsEnabled = true,
                Timeout = expectedTimeout
            };

            // Act
            bool wasAdded = Settings.TryAdd(settings);
            bool wasRetrieved = Settings.TryGet(out TestSettings? retrievedSettings);

            // Assert
            Assert.True(wasAdded);
            Assert.True(wasRetrieved);
            Assert.True(retrievedSettings!.IsEnabled);
            Assert.Equal(expectedTimeout, retrievedSettings.Timeout);
        }

        [Fact]
        public void TryAdd_WhenSettingsAlreadyExist_ShouldReturnFalse()
        {
            // Arrange
            long expectedTimeout = 10000;
            TestSettings settings = new TestSettings()
            {
                IsEnabled = true,
                Timeout = expectedTimeout
            };
            TestSettings duplicateSettings = new TestSettings()
            {
                IsEnabled = true,
                Timeout = expectedTimeout
            };

            // Act
            bool wasAdded = Settings.TryAdd(settings);
            bool wasDuplicateAdded = Settings.TryAdd(duplicateSettings);

            // Assert
            Assert.True(wasAdded);
            Assert.False(wasDuplicateAdded);
        }

        [Fact]
        public void TryRemove_WhenSettingsWereRemoved_ShouldReturnTrue()
        {
            // Arrange
            long expectedTimeout = 10000;
            TestSettings settings = new TestSettings()
            {
                IsEnabled = true,
                Timeout = expectedTimeout
            };

            // Act
            bool wasAdded = Settings.TryAdd(settings);
            bool wasRemoved = Settings.TryRemove<TestSettings>();

            // Assert
            Assert.True(wasAdded);
            Assert.True(wasRemoved);
        }

        [Fact]
        public void TryRemove_WhenSettingsDoNotExist_ShouldReturnFalse()
        {
            // Arrange
            long expectedTimeout = 10000;
            TestSettings settings = new TestSettings()
            {
                IsEnabled = true,
                Timeout = expectedTimeout
            };

            // Act
            bool wasRemoved = Settings.TryRemove<TestSettings>();

            // Assert
            Assert.False(wasRemoved);
        }

        [Fact]
        public async Task Contains_WhenConfiguredSettings_ShouldInjectSettingsProviders()
        {
            // Arrange
            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.ConfigureSettings<TestSettings>(context.Configuration.GetSection(nameof(TestSettings)));
                })
                .Build();

            // Act
            await host.StartAsync();

            bool result = Settings.Contains<TestSettings>();

            await host.StopAsync();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task TryGet_WhenTypeMatches_ShouldReturnTrueAndAssignSetting()
        {
            // Arrange
            long expectedTimeout = 100000;

            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.ConfigureSettings<TestSettings>(context.Configuration.GetSection(nameof(TestSettings)));
                })
                .Build();

            // Act
            await host.StartAsync();

            bool result = Settings.TryGet(out TestSettings? retrievedSettings);

            await host.StopAsync();

            // Assert
            Assert.True(result);
            Assert.NotNull(retrievedSettings);
            Assert.True(retrievedSettings.IsEnabled);
            Assert.Equal(expectedTimeout, retrievedSettings.Timeout);
        }

        [Fact]
        public async Task TryGet_WhenTypeMismatches_ShouldReturnFalseAndAssignDefaultSetting()
        {
            // Arrange
            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.ConfigureSettings<TestSettings>(context.Configuration.GetSection(nameof(TestSettings)));
                })
                .Build();

            // Act
            await host.StartAsync();

            bool result = Settings.TryGet(out object? retrievedSettings);

            await host.StopAsync();

            // Assert
            Assert.False(result);
            Assert.Null(retrievedSettings);
        }

        [Fact]
        public async Task DangerousTryGet_WhenTypeMatches_ShouldReturnTrueAndAssignSetting()
        {
            // Arrange
            long expectedTimeout = 100000;

            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.ConfigureSettings<TestSettings>(context.Configuration.GetSection(nameof(TestSettings)));
                })
                .Build();

            // Act
            await host.StartAsync();

            bool result = Settings.DangerousTryGet(out TestSettings? retrievedSettings);

            await host.StopAsync();

            // Assert
            Assert.True(result);
            Assert.NotNull(retrievedSettings);
            Assert.True(retrievedSettings.IsEnabled);
            Assert.Equal(expectedTimeout, retrievedSettings.Timeout);
        }

        [Fact]
        public async Task DangerousTryGet_WhenTypeMismatches_ShouldReturnFalseAndAssignDefaultSetting()
        {
            // Arrange
            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.ConfigureSettings<TestSettings>(context.Configuration.GetSection(nameof(TestSettings)));
                })
                .Build();

            // Act
            await host.StartAsync();

            bool result = Settings.DangerousTryGet(out object? retrievedSettings);

            await host.StopAsync();

            // Assert
            Assert.False(result);
            Assert.Null(retrievedSettings);
        }

        [Fact]
        public void Clear_WhenThereAreSomeSettings_ShouldRemoveAllSettings()
        {
            // Arrange
            long expectedTimeout = 10000;
            TestSettings settings = new TestSettings()
            {
                IsEnabled = true,
                Timeout = expectedTimeout
            };

            // Act
            bool wasAdded = Settings.TryAdd(settings);

            Settings.Clear();

            bool result = Settings.Contains<TestSettings>();

            // Assert
            Assert.True(wasAdded);
            Assert.False(result);
        }
    }
}

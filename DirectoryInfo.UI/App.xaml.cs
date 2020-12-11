using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DirectoryInfo.Api.Domain.DirectoryInfoAggregate;
using DirectoryInfo.Api.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryInfo.UI
{
    public class App : Application
    {
        public static ServiceProvider _serviceProvider;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            InitalizeServiceProvider();
        }
        
        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();                
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void InitalizeServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            App._serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDirectoryService, DirectoryService>();
        }
   }
}
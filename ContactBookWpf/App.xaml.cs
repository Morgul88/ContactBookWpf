using ContactBookWpf.Mvvm.Services;
using ContactBookWpf.Mvvm.ViewModels;
using ContactBookWpf.Mvvm.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ContactBookWpf
{
    public partial class App : Application
    {
        private IHost? builder;

        public App()
        {
            builder = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<ContactServices>();
                    services.AddTransient<ContactListViewModel>();
                    services.AddTransient<ContactListView>();
                    services.AddTransient<ContactAddView>();
                    services.AddTransient<ContactAddViewModel>();
                    services.AddSingleton<FileService>();
                })
                .Build();


        }

        protected override void OnStartup(StartupEventArgs e)
        {
            builder!.Start();

            var mainWindow = builder!.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}

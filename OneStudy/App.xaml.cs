using Microsoft.AspNetCore.SignalR.Client;
using OneStudy.ViewModels;
using OneStudy.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OneStudy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            HubConnection _hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7035/chat").Build();

            MainWindow window = new MainWindow
            {
                DataContext = MainViewModel.CreateMainViewModel(new Services.SignalRService(_hubConnection))
                  
            };

            window.Show();
        }

        

    }
}

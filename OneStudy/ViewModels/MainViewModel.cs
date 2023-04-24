using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using OneStudy.Infrastructure.Commands;
using OneStudy.Services;
using SignalRModels.Models;



namespace OneStudy.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private string messageToSend;
        public string MessageToSend
        {
            get { return messageToSend; }
            set { messageToSend = value; OnPropertyChanged(); }
        }



        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Message> Messages { get; set; } 

        public SendMessageCommand SendMessageCommand { get; set; }  


        public MainViewModel(SignalRService signalRService)
        {
            Messages = new ObservableCollection<Message>();
            SendMessageCommand = new SendMessageCommand(this, signalRService);

            signalRService.MessageReceivedEvent += SignalRService_MessageReceivedEvent;

        }



        public static MainViewModel CreateMainViewModel(SignalRService signalRService)
        {
            MainViewModel viewModel = new MainViewModel(signalRService);

            signalRService.Connect();
            return viewModel;

        }




        private void SignalRService_MessageReceivedEvent(Message obj)
        {
            Messages.Add(obj);  
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {

            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

       


    }
}

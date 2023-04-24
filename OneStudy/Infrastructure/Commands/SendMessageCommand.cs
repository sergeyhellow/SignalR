using OneStudy.Services;
using OneStudy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneStudy.Infrastructure.Commands
{
    public class SendMessageCommand : ICommand
    {

        public event EventHandler? CanExecuteChanged;

        private readonly MainViewModel _viewModel;
        private readonly SignalRService _signalRService;

        public SendMessageCommand (MainViewModel viewModel, SignalRService signalRService)
        {
            _viewModel = viewModel;
            _signalRService = signalRService;
        }       


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            await _signalRService.SendMessage(new SignalRModels.Models.Message
            {
                DateOfSend = DateTime.Now,
                Text = _viewModel.MessageToSend,
                User = new SignalRModels.Models.User() {Name =_viewModel.UserName }

            });
        }
    }
}

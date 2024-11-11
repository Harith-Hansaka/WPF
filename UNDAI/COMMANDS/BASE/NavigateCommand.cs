using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.SERVICES;
using UNDAI.STORES;
using UNDAI.VIEWMODELS;
using UNDAI.VIEWMODELS.MASTER;

namespace UNDAI.COMMANDS.BASE
{
    public class NavigateCommand : CommandBase
    {
        public readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}

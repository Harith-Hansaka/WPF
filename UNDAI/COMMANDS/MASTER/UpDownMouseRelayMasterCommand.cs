using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS.MASTER;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.COMMANDS.BASE;

namespace UNDAI.COMMANDS.MASTER
{
    public class UpDownMouseRelayMasterCommand : CommandBase
    {
        MainPageMasterViewModel _mainPageMasterViewModel;
        int _commandNo;

        public UpDownMouseRelayMasterCommand(MainPageMasterViewModel mainPageMasterViewModel, int commandNo) 
        {
            _mainPageMasterViewModel = mainPageMasterViewModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            _mainPageMasterViewModel.MainPageMasterCommands.Execute(_commandNo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS.SLAVE;
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.COMMANDS.BASE;

namespace UNDAI.COMMANDS.SLAVE  
{
    public class UpDownMouseRelaySlaveCommand : CommandBase
    {
        MainPageSlaveViewModel _mainPageSlaveViewModel;
        int _commandNo;

        public UpDownMouseRelaySlaveCommand(MainPageSlaveViewModel mainPageSlaveViewModel, int commandNo) 
        {
            _mainPageSlaveViewModel = mainPageSlaveViewModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            _mainPageSlaveViewModel.MainPageSlaveCommands.Execute(_commandNo);
        }
    }
}

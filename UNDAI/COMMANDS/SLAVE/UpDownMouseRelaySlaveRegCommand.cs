using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS.MASTER;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.COMMANDS.BASE;
using UNDAI.VIEWMODELS.SLAVE;

namespace UNDAI.COMMANDS.MASTER
{
    public class UpDownMouseRelaySlaveRegCommand : CommandBase
    {
        SelfRegPageSlaveViewModel _selfRegPageSlaveViewModel;

        public UpDownMouseRelaySlaveRegCommand(SelfRegPageSlaveViewModel selfRegPageSlaveViewModel)
        {
            _selfRegPageSlaveViewModel = selfRegPageSlaveViewModel;
        }

        public override void Execute(object? parameter)
        {
            _selfRegPageSlaveViewModel.SelfRegPageSlaveCommand.Execute(parameter);
        }
    }
}

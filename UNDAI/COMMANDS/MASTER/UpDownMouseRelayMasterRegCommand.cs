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
    public class UpDownMouseRelayMasterRegCommand : CommandBase
    {
        SelfRegPageMasterViewModel _selfRegPageMasterViewModel;

        public UpDownMouseRelayMasterRegCommand(SelfRegPageMasterViewModel selfRegPageMasterViewModel)
        {
            _selfRegPageMasterViewModel = selfRegPageMasterViewModel;
        }

        public override void Execute(object? parameter)
        {
            _selfRegPageMasterViewModel.SelfRegPageMasterCommand.Execute(parameter);
        }
    }
}

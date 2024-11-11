using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS.SLAVE;
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.COMMANDS.BASE;
using UNDAI.VIEWMODELS.SLAVE;

namespace UNDAI.COMMANDS.SLAVE
{
    public class UpDownMouseRelaySlaveSystemSettingResetCommand : CommandBase
    {
        SystemResetSettingSlaveViewModel _systemResetSettingSlaveViewModel;
        SystemResetSettingSlaveModel _systemResetSettingSlaveModel;
        int _commandNo;

        public UpDownMouseRelaySlaveSystemSettingResetCommand(SystemResetSettingSlaveViewModel systemResetSettingSlaveViewModel, int commandNo)
        {
            _systemResetSettingSlaveViewModel = systemResetSettingSlaveViewModel;
            _systemResetSettingSlaveModel = _systemResetSettingSlaveViewModel._systemResetSettingSlaveModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            _systemResetSettingSlaveModel.ButtonClick(_commandNo);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS.SLAVE;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.COMMANDS.BASE;
using UNDAI.VIEWMODELS.SLAVE;

namespace UNDAI.COMMANDS.SLAVE
{
    public class UpDownMouseRelaySlaveSystemSettingCommand : CommandBase
    {
        SystemSettingSlaveViewModel _systemSettingSlaveViewModel;
        SystemSettingSlaveModel _systemSettingSlaveModel;
        int _commandNo;

        public UpDownMouseRelaySlaveSystemSettingCommand(SystemSettingSlaveViewModel systemSettingSlaveViewModel, int commandNo)
        {
            _systemSettingSlaveViewModel = systemSettingSlaveViewModel;
            _systemSettingSlaveModel = _systemSettingSlaveViewModel._systemSettingSlaveModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            _systemSettingSlaveModel.ButtonClick(_commandNo);
        }
    }
}

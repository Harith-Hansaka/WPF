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
    public class UpDownMouseRelayMasterSystemSettingResetCommand : CommandBase
    {
        SystemResetSettingMasterViewModel _systemResetSettingMasterViewModel;
        SystemResetSettingMasterModel _systemResetSettingMasterModel;
        int _commandNo;

        public UpDownMouseRelayMasterSystemSettingResetCommand(SystemResetSettingMasterViewModel systemResetSettingMasterViewModel, int commandNo)
        {
            _systemResetSettingMasterViewModel = systemResetSettingMasterViewModel;
            _systemResetSettingMasterModel = _systemResetSettingMasterViewModel._systemResetSettingMasterModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            _systemResetSettingMasterModel.ButtonClick(_commandNo);
        }
    }
}

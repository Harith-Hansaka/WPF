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
    public class UpDownMouseRelayMasterSystemSettingCommand : CommandBase
    {
        SystemSettingMasterViewModel _systemSettingMasterViewModel;
        SystemSettingMasterModel _systemSettingMasterModel;
        int _commandNo;

        public UpDownMouseRelayMasterSystemSettingCommand(SystemSettingMasterViewModel systemSettingMasterViewModel, int commandNo)
        {
            _systemSettingMasterViewModel = systemSettingMasterViewModel;
            _systemSettingMasterModel = _systemSettingMasterViewModel._systemSettingMasterModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            _systemSettingMasterModel.ButtonClick(_commandNo);
        }
    }
}

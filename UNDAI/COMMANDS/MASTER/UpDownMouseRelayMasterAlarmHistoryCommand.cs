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
    public class UpDownMouseRelayMasterAlarmHistoryCommand : CommandBase
    {
        AlarmHistoryMasterViewModel _alarmHistoryMasterViewModel;
        int _commandNo;

        public UpDownMouseRelayMasterAlarmHistoryCommand(AlarmHistoryMasterViewModel alarmHistoryMasterViewModel, int commandNo)
        {
            _alarmHistoryMasterViewModel = alarmHistoryMasterViewModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            if (_commandNo == 1)
            {
                _alarmHistoryMasterViewModel.DeleteSelectedItem();
                _alarmHistoryMasterViewModel.CanDeleteSelectedItem();
            }
            else if (_commandNo == 2)
            {
                _alarmHistoryMasterViewModel.ExportAlarmHistoryModelMasterToCsv(_alarmHistoryMasterViewModel.AlarmHistoryMasterModel);
            }
        }
    }
}

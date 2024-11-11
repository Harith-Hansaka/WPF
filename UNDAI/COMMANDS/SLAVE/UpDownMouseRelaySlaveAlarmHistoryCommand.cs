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
    public class UpDownMouseRelaySlaveAlarmHistoryCommand : CommandBase
    {
        AlarmHistorySlaveViewModel _alarmHistorySlaveViewModel;
        int _commandNo;

        public UpDownMouseRelaySlaveAlarmHistoryCommand(AlarmHistorySlaveViewModel alarmHistorySlaveViewModel, int commandNo)
        {
            _alarmHistorySlaveViewModel = alarmHistorySlaveViewModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            if (_commandNo == 1)
            {
                _alarmHistorySlaveViewModel.DeleteSelectedItem();
                _alarmHistorySlaveViewModel.CanDeleteSelectedItem();
            }
            else if (_commandNo == 2)
            {
                _alarmHistorySlaveViewModel.ExportAlarmHistoryModelSlaveToCsv(_alarmHistorySlaveViewModel.AlarmHistorySlaveModel);
            }
        }
    }
}

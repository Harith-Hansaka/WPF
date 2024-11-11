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

namespace UNDAI.COMMANDS.SLAVE
{
    public class UpDownMouseRelaySlaveStationDBCommand : CommandBase
    {
        StationDBPageSlaveViewModel _stationDBPageSlaveViewModel;
        int _commandNo;

        public UpDownMouseRelaySlaveStationDBCommand(StationDBPageSlaveViewModel stationDBPageSlaveViewModel, int commandNo)
        {
            _stationDBPageSlaveViewModel = stationDBPageSlaveViewModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            if(_commandNo == 1)
            {
                _stationDBPageSlaveViewModel.DeleteSelectedItem();
                _stationDBPageSlaveViewModel.CanDeleteSelectedItem();
            }
            else if(_commandNo == 2)
            {
                _stationDBPageSlaveViewModel.ExportStationDBPageModelSlaveToCsv(_stationDBPageSlaveViewModel.StationDBPageModelSlave);
            }
            else if(_commandNo == 3)
            {
                _stationDBPageSlaveViewModel.EditedDataGridSend();
            }
            else if (_commandNo == 4)
            {
                _stationDBPageSlaveViewModel.RegistrationDataGridSend();
            }
        }
    }
}

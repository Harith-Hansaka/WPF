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
    public class UpDownMouseRelayMasterStationDBCommand : CommandBase
    {
        StationDBPageMasterViewModel _stationDBPageMasterViewModel;
        int _commandNo;

        public UpDownMouseRelayMasterStationDBCommand(StationDBPageMasterViewModel stationDBPageMasterViewModel, int commandNo)
        {
            _stationDBPageMasterViewModel = stationDBPageMasterViewModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            if(_commandNo == 1)
            {
                _stationDBPageMasterViewModel.DeleteSelectedItem();
                _stationDBPageMasterViewModel.CanDeleteSelectedItem();
            }
            else if(_commandNo == 2)
            {
                _stationDBPageMasterViewModel.ExportStationDBPageModelMasterToCsv(_stationDBPageMasterViewModel.StationDBPageModelMaster);
            }
            else if(_commandNo == 3)
            {
                _stationDBPageMasterViewModel.EditedDataGridSend();
            }
            else if (_commandNo == 4)
            {
                _stationDBPageMasterViewModel.RegistrationDataGridSend();
            }
        }
    }
}

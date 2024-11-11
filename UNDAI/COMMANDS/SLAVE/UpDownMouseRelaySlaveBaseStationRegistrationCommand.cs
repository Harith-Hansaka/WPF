using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS.SLAVE;
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.COMMANDS.BASE;
using UNDAI.MODELS.SLAVE;

namespace UNDAI.COMMANDS.SLAVE
{
    public class UpDownMouseRelaySlaveBaseStationRegistrationCommand : CommandBase
    {
        BaseStationRegistrationSlaveViewModel _baseStationRegistrationSlaveViewModel;
        int _commandNo;

        public UpDownMouseRelaySlaveBaseStationRegistrationCommand(BaseStationRegistrationSlaveViewModel baseStationRegistrationSlaveViewModel, int commandNo)
        {
            _baseStationRegistrationSlaveViewModel = baseStationRegistrationSlaveViewModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            if (_commandNo == 1)
            {
                _baseStationRegistrationSlaveViewModel.DeleteSelectedItem();
                _baseStationRegistrationSlaveViewModel.CanDeleteSelectedItem();
            }
            else if (_commandNo == 2)
            {
                _baseStationRegistrationSlaveViewModel.ExportBaseStationRegistrationPageSlaveModelToCsv(_baseStationRegistrationSlaveViewModel.BaseStationRegistrationPageSlaveModel);
            }
            else if (_commandNo == 3)
            {
                _baseStationRegistrationSlaveViewModel.EditedDataGridSend();
            }
            else if (_commandNo == 4)
            {
                _baseStationRegistrationSlaveViewModel.RegistrationDataGridSend();
            }
        }
    }
}

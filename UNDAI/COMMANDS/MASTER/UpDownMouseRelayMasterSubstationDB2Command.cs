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
    public class UpDownMouseRelayMasterSubstationDB2Command : CommandBase
    {
        SubstationDB2MasterViewModel _substationDB2MasterViewModel;
        int _commandNo;

        public UpDownMouseRelayMasterSubstationDB2Command(SubstationDB2MasterViewModel substationDB2MasterViewModel, int commandNo)
        {
            _substationDB2MasterViewModel = substationDB2MasterViewModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            if (_commandNo == 1)
            {
                _substationDB2MasterViewModel.DeleteSelectedItem();
                _substationDB2MasterViewModel.CanDeleteSelectedItem();
            }
            else if (_commandNo == 2)
            {
                _substationDB2MasterViewModel.ExportStationDBPageModelMasterToCsv(_substationDB2MasterViewModel.SubstationDB2MasterModel);
            }
            else if (_commandNo == 3)
            {
                _substationDB2MasterViewModel.EditedDataGridSend();
            }
            else if (_commandNo == 4)
            {
                _substationDB2MasterViewModel.RegistrationDataGridSend();
            }
        }
    }
}

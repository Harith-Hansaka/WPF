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
    public class UpDownMouseRelayMasterSubstationDB1Command : CommandBase
    {
        SubstationDB1MasterViewModel _substationDB1MasterViewModel;
        int _commandNo;

        public UpDownMouseRelayMasterSubstationDB1Command(SubstationDB1MasterViewModel substationDB1MasterViewModel, int commandNo)
        {
            _substationDB1MasterViewModel = substationDB1MasterViewModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            if (_commandNo == 1)
            {
                _substationDB1MasterViewModel.DeleteSelectedItem();
                _substationDB1MasterViewModel.CanDeleteSelectedItem();
            }
            else if (_commandNo == 2)
            {
                _substationDB1MasterViewModel.ExportStationDBPageModelMasterToCsv(_substationDB1MasterViewModel.SubstationDB1MasterModel);
            }
            else if (_commandNo == 3)
            {
                _substationDB1MasterViewModel.EditedDataGridSend();
            }
            else if (_commandNo == 4)
            {
                _substationDB1MasterViewModel.RegistrationDataGridSend();
            }
        }
    }
}

﻿using System;
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
    public class UpDownMouseRelayMasterSubstationDB4Command : CommandBase
    {
        SubstationDB4MasterViewModel _substationDB4MasterViewModel;
        int _commandNo;

        public UpDownMouseRelayMasterSubstationDB4Command(SubstationDB4MasterViewModel substationDB4MasterViewModel, int commandNo)
        {
            _substationDB4MasterViewModel = substationDB4MasterViewModel;
            _commandNo = commandNo;
        }

        public override void Execute(object? parameter)
        {
            if (_commandNo == 1)
            {
                _substationDB4MasterViewModel.DeleteSelectedItem();
                _substationDB4MasterViewModel.CanDeleteSelectedItem();
            }
            else if (_commandNo == 2)
            {
                _substationDB4MasterViewModel.ExportStationDBPageModelMasterToCsv(_substationDB4MasterViewModel.SubstationDB4MasterModel);
            }
            else if (_commandNo == 3)
            {
                _substationDB4MasterViewModel.EditedDataGridSend();
            }
            else if (_commandNo == 4)
            {
                _substationDB4MasterViewModel.RegistrationDataGridSend();
            }
        }
    }
}
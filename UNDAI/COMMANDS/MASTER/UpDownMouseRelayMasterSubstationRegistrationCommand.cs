using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNDAI.MODELS.MASTER;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.COMMANDS.BASE;
using System.Windows;

namespace UNDAI.COMMANDS.MASTER
{
    public class UpDownMouseRelayMasterSubstationRegistrationCommand : CommandBase
    {
        SubstationRegistrationMasterViewModel _substationRegistrationMasterViewModel;
        MainPageMasterViewModel _mainPageMasterViewModel;
        App app;
        int _commandNo;

        public UpDownMouseRelayMasterSubstationRegistrationCommand(SubstationRegistrationMasterViewModel substationRegistrationMasterViewModel, int commandNo)
        {
            _substationRegistrationMasterViewModel = substationRegistrationMasterViewModel;
            _commandNo = commandNo; 
            app = (App)Application.Current;
            if (_substationRegistrationMasterViewModel._mainPageMasterViewModel != null)
            {
                _mainPageMasterViewModel = _substationRegistrationMasterViewModel._mainPageMasterViewModel;
            }
        }

        public override async void Execute(object? parameter)
        {
            if (_commandNo == 1)
            {
                _substationRegistrationMasterViewModel.SlaveDataRegisterMaster();
            }
            if (_mainPageMasterViewModel == null) 
            {
                await CreateAppClassAfterDelay();
            }
            if (_mainPageMasterViewModel != null) 
            {
                if (_commandNo == 2) 
                {
                    _substationRegistrationMasterViewModel.firstLatitude   = _mainPageMasterViewModel._stationDBPageMasterViewModel.LatitudeMaster;
                    _substationRegistrationMasterViewModel.firstLongitude  = _mainPageMasterViewModel._stationDBPageMasterViewModel.LongitudeMaster;
                    _substationRegistrationMasterViewModel.secondLatitude  = _mainPageMasterViewModel._substationDB1MasterViewModel.LatitudeSlave1;
                    _substationRegistrationMasterViewModel.secondLongitude = _mainPageMasterViewModel._substationDB1MasterViewModel.LongitudeSlave1;

                    _substationRegistrationMasterViewModel.ShowElevationProfile
                    (
                        _substationRegistrationMasterViewModel.firstLatitude,
                        _substationRegistrationMasterViewModel.firstLongitude,
                        _substationRegistrationMasterViewModel.secondLatitude,
                        _substationRegistrationMasterViewModel.secondLongitude
                    );
                }
            }
        }

        private async Task CreateAppClassAfterDelay()
        {
            await Task.Delay(100);
            if (_mainPageMasterViewModel == null)
            {
                // Access properties directly
                _mainPageMasterViewModel = app._mainPageMasterViewModel;
            }
        }
    }
}

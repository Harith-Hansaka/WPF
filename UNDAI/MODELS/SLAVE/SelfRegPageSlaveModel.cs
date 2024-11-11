using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UNDAI.COMMANDS.BASE;
using UNDAI.MODELS.MASTER;
using UNDAI.SERVICES;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWMODELS.SLAVE;

namespace UNDAI.MODELS.SLAVE
{
    public class SelfRegPageSlaveModel
    {
        private SelfRegPageSlaveViewModel _selfRegPageSlaveViewModel;
        private MainPageSlaveViewModel _mainPageSlaveViewModel;
        private ConnectionSlave _connectionSlave;
        private int _commandNo;
        public MainPageSlaveModel _mainPageSlaveModel;
        string _message;
        public NavigationService _mainPageNavigationService;

        public SelfRegPageSlaveModel
        (
            SelfRegPageSlaveViewModel selfRegPageSlaveViewModel,
            ConnectionSlave connectionSlave,
            MainPageSlaveModel mainPageSlaveModel,
            NavigationService mainPageNavigationService
        )
        {
            _selfRegPageSlaveViewModel = selfRegPageSlaveViewModel;
            _connectionSlave = connectionSlave;
            _mainPageSlaveModel = mainPageSlaveModel;
            _mainPageNavigationService = mainPageNavigationService;
        }

        public async void Button_Click()
        {
            _message =
                "DM," +
                _selfRegPageSlaveViewModel.SlaveName + "," +
                _selfRegPageSlaveViewModel.LatitudeSlave + "," +
                _selfRegPageSlaveViewModel.LongitudeSlave + "," +
                _selfRegPageSlaveViewModel.ElevationSlave+ "," +
                _selfRegPageSlaveViewModel.PoleHeight + "," +
                _selfRegPageSlaveViewModel.InstallationOrientation + "," +
                DateTime.Now.Date.ToString("yyyy-MM-dd") + "," +
                DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss") + ",\n";

            NavigateCommand navigateCommand = new NavigateCommand(_mainPageNavigationService);

            if
            (
                _selfRegPageSlaveViewModel.SlaveName == "" ||
                _selfRegPageSlaveViewModel.PoleHeight == "" ||
                _selfRegPageSlaveViewModel.InstallationOrientation == "" ||
                _selfRegPageSlaveViewModel.HeadIPAddress == "" ||
                _selfRegPageSlaveViewModel.LatitudeSlave == "" ||
                _selfRegPageSlaveViewModel.LongitudeSlave == "" ||
                _selfRegPageSlaveViewModel.ElevationSlave == "" ||
                _selfRegPageSlaveViewModel.SlaveAntennaIPAddress == ""
            )
            {

                if (MessageBox.Show("Please fill all, try again?",
                        "Not Complete",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    // Optionally, do something here if the user clicks "Yes"

                }
                else
                {
                    // Optionally, do something here if the user clicks "No"
                    navigateCommand.Execute(null);
                }

            }
            else if(!MainPageMasterModel.IsValidIPAddress(_selfRegPageSlaveViewModel.HeadIPAddress))
            {
                if (MessageBox.Show("Please reenter, try again?",
                        "INVALID UNDAI IPADDRESS",
                        MessageBoxButton.OK,
                        MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    // Optionally, do something here if the user clicks "OK"
                }
            }
            else if(!MainPageMasterModel.IsValidIPAddress(_selfRegPageSlaveViewModel.SlaveAntennaIPAddress))
            {
                if (MessageBox.Show("Please reenter, try again?",
                        "INVALID ANTENNA IPADDRESS",
                        MessageBoxButton.OK,
                        MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    // Optionally, do something here if the user clicks "OK"
                }
            }
            else
            {
                _mainPageSlaveModel.MessageSend(_message);
                navigateCommand.Execute(null);
            }
        }
    }
}

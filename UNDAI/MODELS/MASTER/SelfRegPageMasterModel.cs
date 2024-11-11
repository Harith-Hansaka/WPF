using System.Windows;
using UNDAI.COMMANDS.BASE;
using UNDAI.SERVICES;
using UNDAI.VIEWMODELS.MASTER;

namespace UNDAI.MODELS.MASTER
{
    public class SelfRegPageMasterModel
    {
        private SelfRegPageMasterViewModel _selfRegPageMasterViewModel;
        private MainPageMasterViewModel _mainPageMasterViewModel;
        private ConnectionMaster _connectionMaster;
        private int _commandNo;
        public MainPageMasterModel _mainPageMasterModel;
        string _message;
        public NavigationService _mainPageNavigationService;

        public SelfRegPageMasterModel
        (
            SelfRegPageMasterViewModel selfRegPageMasterViewModel,
            ConnectionMaster connectionMaster,
            MainPageMasterModel mainPageMasterModel,
            NavigationService mainPageNavigationService
        )

        {
            _selfRegPageMasterViewModel = selfRegPageMasterViewModel;
            _connectionMaster = connectionMaster;
            _mainPageMasterModel = mainPageMasterModel;
            _mainPageNavigationService = mainPageNavigationService;
        }

        public async void Button_Click()
        {
            _message =
                "DM," +
                _selfRegPageMasterViewModel.MasterName + "," +
                _selfRegPageMasterViewModel.LatitudeMaster + "," +
                _selfRegPageMasterViewModel.LongitudeMaster + "," +
                _selfRegPageMasterViewModel.ElevationMaster + "," +
                _selfRegPageMasterViewModel.PoleHeight + "," +
                _selfRegPageMasterViewModel.InstallationOrientation + "," +
                DateTime.Now.Date.ToString("yyyy-MM-dd") + "," +
                DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss") + ",\n";

            NavigateCommand navigateCommand = new NavigateCommand(_mainPageNavigationService);

            if
            (
                _selfRegPageMasterViewModel.MasterName == "" || 
                _selfRegPageMasterViewModel.PoleHeight == "" ||
                _selfRegPageMasterViewModel.InstallationOrientation== "" ||
                _selfRegPageMasterViewModel.HeadIPAddress== "" ||
                _selfRegPageMasterViewModel.LatitudeMaster == "" ||
                _selfRegPageMasterViewModel.LongitudeMaster == "" ||
                _selfRegPageMasterViewModel.ElevationMaster == "" || 
                _selfRegPageMasterViewModel.MasterAntennaIPAddress == ""
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
            else if
            (!MainPageMasterModel.IsValidIPAddress(_selfRegPageMasterViewModel.HeadIPAddress))
            {
                if (MessageBox.Show("Please reenter, try again?",
                        "INVALID UNDAI IPADDRESS",
                        MessageBoxButton.OK,
                        MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    // Optionally, do something here if the user clicks "OK"
                }
            }
            else if
            (!MainPageMasterModel.IsValidIPAddress(_selfRegPageMasterViewModel.MasterAntennaIPAddress))
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
                _mainPageMasterModel.MessageSend(_message);
                navigateCommand.Execute(null);
            }
        }
    }
}
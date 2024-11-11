using System.Windows;
using System.Windows.Input;
using UNDAI.COMMANDS.BASE;
using UNDAI.COMMANDS.MASTER;
using UNDAI.MODELS.MASTER;
using UNDAI.SERVICES;

namespace UNDAI.VIEWMODELS.MASTER
{
    public class SystemResetSettingMasterViewModel : ViewModelBase
    {
        bool defaultBtnPressed = false;

        public SystemResetSettingMasterModel _systemResetSettingMasterModel;
        public ConnectionMaster _connectionMaster;

        public ICommand SystemSettingReset {  get; }

        public ICommand mainPageNavigateCommand;
        public ICommand MainPageNavigateCommand
        {
            get 
            {
                defaultBtnPressed = false;
                OnPropertyChanged(nameof(ResetUndaiImg));
                return mainPageNavigateCommand; 
            }
        }

        public SystemResetSettingMasterViewModel
        (
            ConnectionMaster connectionMaster,
            NavigationService mainPageMasterNavigationService,
            NavigationService mainPageSlaveNavigationService
        )
        {
            _connectionMaster = connectionMaster;
            mainPageNavigateCommand = new NavigateCommand(mainPageMasterNavigationService);
            _systemResetSettingMasterModel = new SystemResetSettingMasterModel(this);
            SystemSettingReset = new UpDownMouseRelayMasterSystemSettingResetCommand(this, 1);
        }

        private string currentIPAddress;
        public string CurrentIPAddress
        {
            get
            {
                currentIPAddress = _connectionMaster.currentServerIP;
                return currentIPAddress;
            }
            set
            {
                currentIPAddress = value;
                OnPropertyChanged(nameof(CurrentIPAddress));
                defaultBtnPressed = true;
                OnPropertyChanged(nameof(ResetUndaiImg));
                if (MessageBox.Show("RESET UNDAI AS WELL!",
                        "RESET UNDAI",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    // Optionally, do something here if the user clicks "Yes"

                }
            }
        }

        private string defaultIPAddress;
        public string DefaultIPAddress
        {
            get
            {
                defaultIPAddress = _connectionMaster.defaultServerIP;
                return defaultIPAddress;
            }
        }

        private string resetUndaiImg = "Hidden";
        public string ResetUndaiImg
        {
            get
            {
                if (defaultBtnPressed)
                {
                    resetUndaiImg = "Visible";
                }
                else
                {
                    resetUndaiImg = "Hidden";
                }
                return resetUndaiImg;
            }
            set
            {
                if (defaultBtnPressed)
                {
                    resetUndaiImg = "Visible";
                }
                else
                {
                    resetUndaiImg = "Hidden";
                }
                OnPropertyChanged(nameof(ResetUndaiImg));
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UNDAI.COMMANDS.BASE;
using UNDAI.COMMANDS.SLAVE;
using UNDAI.MODELS.MASTER;
using UNDAI.MODELS.SLAVE;
using UNDAI.SERVICES;
using UNDAI.VIEWMODELS.MASTER;

namespace UNDAI.VIEWMODELS.SLAVE
{
    public class SystemResetSettingSlaveViewModel : ViewModelBase
    {
        bool defaultBtnPressed = false;

        public SystemResetSettingSlaveModel _systemResetSettingSlaveModel;
        public ConnectionSlave _connectionSlave;

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

        public SystemResetSettingSlaveViewModel
        (
            ConnectionSlave connectionSlave,
            NavigationService mainPageSlaveNavigationService,
            NavigationService mainPageMasterNavigationService
        )
        {
            _connectionSlave = connectionSlave;
            mainPageNavigateCommand = new NavigateCommand(mainPageSlaveNavigationService);
            _systemResetSettingSlaveModel = new SystemResetSettingSlaveModel(this);
            SystemSettingReset = new UpDownMouseRelaySlaveSystemSettingResetCommand(this, 1);
        }

        private string currentIPAddress;
        public string CurrentIPAddress
        {
            get
            {
                currentIPAddress = _connectionSlave.currentServerIP;
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
                defaultIPAddress = _connectionSlave.defaultServerIP;
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
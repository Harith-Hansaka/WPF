using System.Configuration;
using System.Data;
using System.Runtime.Serialization;
using System.Windows;
using UNDAI.SERVICES;
using UNDAI.STORES;
using UNDAI.VIEWMODELS.BASE;
using UNDAI.MODELS.MASTER;
using UNDAI.MODELS.SLAVE;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.VIEWS.SLAVE;
using System.Runtime.InteropServices;
namespace UNDAI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex _mutex;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        public readonly ConnectionMaster _connectionMaster;
        public readonly ConnectionSlave _connectionSlave;
        private readonly NavigationStore _navigationStore;
        public readonly MainPageSlaveViewModel _mainPageSlaveViewModel;
        public readonly SystemSettingMasterViewModel _systemSettingMasterViewModel;
        public readonly SubstationDB1MasterViewModel _stationDB1MasterViewModel;
        public readonly SubstationDB2MasterViewModel _stationDB2MasterViewModel;
        public readonly SubstationDB3MasterViewModel _stationDB3MasterViewModel;
        public readonly SubstationDB4MasterViewModel _stationDB4MasterViewModel;
        public readonly SelfRegPageSlaveViewModel _selfRegPageSlaveViewModel;
        public readonly StationDBPageSlaveViewModel _stationDBPageSlaveViewModel;
        public readonly SystemSettingSlaveViewModel _systemSettingSlaveViewModel;
        public readonly BaseStationRegistrationSlaveViewModel _baseStationRegistrationSlaveViewModel;
        public readonly SubstationRegistrationMasterViewModel _substationRegistrationMasterViewModel;
        public MainPageMasterViewModel _mainPageMasterViewModel;
        public readonly SelfRegPageMasterViewModel _selfRegPageMasterViewModel;
        public readonly StationDBPageMasterViewModel _stationDBPageMasterViewModel;
        public readonly AlarmHistoryMasterViewModel _alarmHistoryMasterViewModel;
        public readonly AlarmHistorySlaveViewModel _alarmHistorySlaveViewModel;
        private readonly SystemResetSettingMasterViewModel _systemResetSettingMasterViewModel;
        private readonly SystemResetSettingSlaveViewModel _systemResetSettingSlaveViewModel;

        public App()
        {
            _navigationStore = new NavigationStore();
            _connectionMaster = new ConnectionMaster();
            _connectionSlave = new ConnectionSlave();

            _systemResetSettingMasterViewModel = new SystemResetSettingMasterViewModel
            (
                _connectionMaster,
                new NavigationService(_navigationStore, CreateMainPageMasterViewModel),
                new NavigationService(_navigationStore, CreateMainPageSlaveViewModel)
            );

            _systemResetSettingSlaveViewModel = new SystemResetSettingSlaveViewModel
            (
                _connectionSlave,
                new NavigationService(_navigationStore, CreateMainPageSlaveViewModel),
                new NavigationService(_navigationStore, CreateMainPageMasterViewModel)
            );

            _stationDB1MasterViewModel = new SubstationDB1MasterViewModel
            (
                _connectionMaster,
                new NavigationService(_navigationStore, CreateMainPageMasterViewModel),
                new NavigationService(_navigationStore, CreateSubstationRegistrationMasterViewModel)
            );

            _alarmHistoryMasterViewModel = new AlarmHistoryMasterViewModel
            (
                new NavigationService(_navigationStore, CreateMainPageMasterViewModel),
                new NavigationService(_navigationStore, CreateSystemSettingMasterViewModel)
            );

            _alarmHistorySlaveViewModel = new AlarmHistorySlaveViewModel
            (
                new NavigationService(_navigationStore, CreateMainPageSlaveViewModel),
                new NavigationService(_navigationStore, CreateSystemSettingSlaveViewModel)
            );

            _stationDB2MasterViewModel = new SubstationDB2MasterViewModel
            (
                _connectionMaster,
                new NavigationService(_navigationStore, CreateMainPageMasterViewModel),
                new NavigationService(_navigationStore, CreateSubstationRegistrationMasterViewModel)
            );

            _stationDB3MasterViewModel = new SubstationDB3MasterViewModel
            (
                _connectionMaster,
                new NavigationService(_navigationStore, CreateMainPageMasterViewModel),
                new NavigationService(_navigationStore, CreateSubstationRegistrationMasterViewModel)
            );

            _stationDB4MasterViewModel = new SubstationDB4MasterViewModel
            (
                _connectionMaster,
                new NavigationService(_navigationStore, CreateMainPageMasterViewModel),
                new NavigationService(_navigationStore, CreateSubstationRegistrationMasterViewModel)
            );

            _stationDBPageMasterViewModel = new StationDBPageMasterViewModel
            (
                //_selfRegPageMasterViewModel,
                new NavigationService(_navigationStore, CreateMainPageMasterViewModel),
                new NavigationService(_navigationStore, CreateSelfRegPageMasterViewModel)
            );

            _substationRegistrationMasterViewModel = new SubstationRegistrationMasterViewModel
            (
                _connectionMaster,
                new NavigationService(_navigationStore, CreateMainPageMasterViewModel),
                new NavigationService(_navigationStore, CreateSubstationDB1MasterViewModel),
                new NavigationService(_navigationStore, CreateSubstationDB2MasterViewModel),
                new NavigationService(_navigationStore, CreateSubstationDB3MasterViewModel),
                new NavigationService(_navigationStore, CreateSubstationDB4MasterViewModel)
            );

            _systemSettingMasterViewModel = new SystemSettingMasterViewModel
            (
                _connectionMaster,
                new NavigationService(_navigationStore, CreateMainPageMasterViewModel),
                new NavigationService(_navigationStore, CreateMainPageSlaveViewModel),
                new NavigationService(_navigationStore, CreateAlarmHistoryMasterViewModel)
            );

            _mainPageMasterViewModel = new MainPageMasterViewModel
            (
                _connectionMaster,
                _systemSettingMasterViewModel,
                _stationDBPageMasterViewModel,
                _substationRegistrationMasterViewModel,
                _stationDB1MasterViewModel,
                _stationDB2MasterViewModel,
                _stationDB3MasterViewModel,
                _stationDB4MasterViewModel, 
                _alarmHistoryMasterViewModel,
                _systemResetSettingMasterViewModel,
                new NavigationService(_navigationStore, CreateSelfRegPageMasterViewModel),
                new NavigationService(_navigationStore, CreateStationDBPageMasterViewModel),
                new NavigationService(_navigationStore, CreateMainPageSlaveViewModel),
                new NavigationService(_navigationStore, CreateSystemSettingMasterViewModel),
                new NavigationService(_navigationStore, CreateSubstationDB1MasterViewModel),
                new NavigationService(_navigationStore, CreateSubstationDB2MasterViewModel),
                new NavigationService(_navigationStore, CreateSubstationDB3MasterViewModel),
                new NavigationService(_navigationStore, CreateSubstationDB4MasterViewModel),
                new NavigationService(_navigationStore, CreateSubstationRegistrationMasterViewModel),
                new NavigationService(_navigationStore, CreateSystemResetSettingMasterViewModel)
            );

            _selfRegPageMasterViewModel = new SelfRegPageMasterViewModel
            (
                _connectionMaster,
                _mainPageMasterViewModel,
                new NavigationService(_navigationStore, CreateMainPageMasterViewModel),
                new NavigationService(_navigationStore, CreateStationDBPageMasterViewModel)
            );

            _stationDBPageSlaveViewModel = new StationDBPageSlaveViewModel
            (
                new NavigationService(_navigationStore, CreateMainPageSlaveViewModel),
                new NavigationService(_navigationStore, CreateSelfRegPageSlaveViewModel)
            );

            _systemSettingSlaveViewModel = new SystemSettingSlaveViewModel
            (
                _connectionSlave,
                new NavigationService(_navigationStore, CreateMainPageMasterViewModel),
                new NavigationService(_navigationStore, CreateMainPageSlaveViewModel),
                new NavigationService(_navigationStore, CreateAlarmHistorySlaveViewModel)
            );

            _baseStationRegistrationSlaveViewModel = new BaseStationRegistrationSlaveViewModel
            (
                _connectionSlave,
                new NavigationService(_navigationStore, CreateMainPageSlaveViewModel)
            );

            _mainPageSlaveViewModel = new MainPageSlaveViewModel(
                _connectionSlave,
                _systemSettingSlaveViewModel,
                _stationDBPageSlaveViewModel,
                _alarmHistorySlaveViewModel,
                _baseStationRegistrationSlaveViewModel,
                _systemResetSettingSlaveViewModel,
                new NavigationService(_navigationStore, CreateSelfRegPageSlaveViewModel),
                new NavigationService(_navigationStore, CreateStationDBPageSlaveViewModel),
                new NavigationService(_navigationStore, CreateMainPageMasterViewModel),
                new NavigationService(_navigationStore, CreateSystemSettingSlaveViewModel),
                new NavigationService(_navigationStore, CreateBaseStationRegistrationSlaveViewModel),
                new NavigationService(_navigationStore, CreateSystemResetSettingSlaveViewModel)
            );

            _selfRegPageSlaveViewModel = new SelfRegPageSlaveViewModel
            (
                _connectionSlave,
                _mainPageSlaveViewModel,
                new NavigationService(_navigationStore, CreateMainPageSlaveViewModel),
                new NavigationService(_navigationStore, CreateStationDBPageSlaveViewModel)
            );
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            const string appName = "MKS.UNDAI";  // Ensure this is unique for your app
            bool createdNew;

            _mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                // Bring existing instance to the foreground
                IntPtr existingAppWindow = FindWindow(null, "UNDAI"); // Replace with your main window's title
                if (existingAppWindow != IntPtr.Zero)
                {
                    SetForegroundWindow(existingAppWindow);
                }

                // Close this instance
                Shutdown();
                return; // Prevent further execution
            }

            _navigationStore.CurrentViewModel = CreateMainPageMasterViewModel();
            //_navigationStore.CurrentViewModel = CreateMainPageSlaveViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _mutex?.ReleaseMutex();
            base.OnExit(e);
        }

        private MainPageMasterViewModel CreateMainPageMasterViewModel()
        {
            return _mainPageMasterViewModel;
        }
        private SelfRegPageMasterViewModel CreateSelfRegPageMasterViewModel() 
        {
            return _selfRegPageMasterViewModel;
        }
        private StationDBPageMasterViewModel CreateStationDBPageMasterViewModel()
        {
            return _stationDBPageMasterViewModel;
        }
        private MainPageSlaveViewModel CreateMainPageSlaveViewModel()
        {
            return _mainPageSlaveViewModel;
        }
        private SystemSettingMasterViewModel CreateSystemSettingMasterViewModel()
        {
            return _systemSettingMasterViewModel;
        }
        private SubstationDB1MasterViewModel CreateSubstationDB1MasterViewModel()
        {
            return _stationDB1MasterViewModel;
        }
        private SubstationDB2MasterViewModel CreateSubstationDB2MasterViewModel()
        {
            return _stationDB2MasterViewModel;
        }
        private SubstationDB3MasterViewModel CreateSubstationDB3MasterViewModel()
        {
            return _stationDB3MasterViewModel;
        }
        private SubstationDB4MasterViewModel CreateSubstationDB4MasterViewModel()
        {
            return _stationDB4MasterViewModel;
        }
        private SubstationRegistrationMasterViewModel CreateSubstationRegistrationMasterViewModel()
        {
            return _substationRegistrationMasterViewModel;
        }
        private SelfRegPageSlaveViewModel CreateSelfRegPageSlaveViewModel()
        {
            return _selfRegPageSlaveViewModel;
        }
        private SystemSettingSlaveViewModel CreateSystemSettingSlaveViewModel()
        {
            return _systemSettingSlaveViewModel;
        }
        private BaseStationRegistrationSlaveViewModel CreateBaseStationRegistrationSlaveViewModel()
        {
            return _baseStationRegistrationSlaveViewModel;
        }
        private StationDBPageSlaveViewModel CreateStationDBPageSlaveViewModel()
        { 
            return _stationDBPageSlaveViewModel;
        }
        private AlarmHistoryMasterViewModel CreateAlarmHistoryMasterViewModel()
        {
            return _alarmHistoryMasterViewModel;
        }
        private AlarmHistorySlaveViewModel CreateAlarmHistorySlaveViewModel()
        {
            return _alarmHistorySlaveViewModel;
        }
        private SystemResetSettingMasterViewModel CreateSystemResetSettingMasterViewModel()
        {
            return _systemResetSettingMasterViewModel;
        }
        private SystemResetSettingSlaveViewModel CreateSystemResetSettingSlaveViewModel()
        {
            return _systemResetSettingSlaveViewModel;
        }
    }
}
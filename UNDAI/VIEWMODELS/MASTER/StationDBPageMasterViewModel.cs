using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UNDAI.COMMANDS.BASE;
using UNDAI.COMMANDS.MASTER;
using UNDAI.MODELS.MASTER;
using UNDAI.SERVICES;

namespace UNDAI.VIEWMODELS.MASTER
{
    public class StationDBPageMasterViewModel : ViewModelBase
    {
        StationDBPageModelMaster newStationDBPageModelMaster;
        MainPageMasterViewModel mainPageMasterViewModel;
        SelfRegPageMasterViewModel selfRegPageMasterViewModel;
        int stationDBPageModelMasterCount = 0;
        App app;
        string _message;

        public ICommand mainPageMasterNavigateCommand { get; }
        public ICommand stationDBPageMasterNavigateCommand { get; }
        public ICommand DBExportCommand { get; }
        public ICommand DeleteSelectedItemCommand { get; }
        public ICommand EditDataGridCommand { get; }
        public ICommand RegistrationDataGridCommand { get; }

        public StationDBPageMasterViewModel(NavigationService mainPageMasterNavigationService, NavigationService stationDBPageMasterNavigationService) 
        {
            mainPageMasterNavigateCommand = new NavigateCommand(mainPageMasterNavigationService);
            stationDBPageMasterNavigateCommand = new NavigateCommand(stationDBPageMasterNavigationService);
            StationDBPageModelMaster = new ObservableCollection<StationDBPageModelMaster>();
            DeleteSelectedItemCommand = new UpDownMouseRelayMasterStationDBCommand(this, 1);
            DBExportCommand = new UpDownMouseRelayMasterStationDBCommand(this, 2);
            EditDataGridCommand = new UpDownMouseRelayMasterStationDBCommand(this, 3);
            RegistrationDataGridCommand = new UpDownMouseRelayMasterStationDBCommand(this, 4);
            app = (App)Application.Current;
            CreateAppClassAfterDelay();
            for (int i = 0; i < 15; i++)
            {
                AddStationDBPage
                (
                    "", "", "", "", "", "", "", "","",""
                );
            }
        }

        private async void CreateAppClassAfterDelay()
        {
            await Task.Delay(50);
            if (mainPageMasterViewModel == null || selfRegPageMasterViewModel == null)
            {
                // Access properties directly
                mainPageMasterViewModel = app._mainPageMasterViewModel;
                selfRegPageMasterViewModel = app._selfRegPageMasterViewModel;
            }
        }

        private ObservableCollection<StationDBPageModelMaster> stationDBPageModelMaster;
        public ObservableCollection<StationDBPageModelMaster> StationDBPageModelMaster
        {
            get { return stationDBPageModelMaster; }
            set
            {
                stationDBPageModelMaster = value;
                OnPropertyChanged(nameof(StationDBPageModelMaster));
            }
        }

        private StationDBPageModelMaster _selectedStationDBPageModelMaster;
        public StationDBPageModelMaster SelectedStationDBPageModelMaster
        {
            get { return _selectedStationDBPageModelMaster; }
            set
            {
                _selectedStationDBPageModelMaster = value;
                if(SelectedStationDBPageModelMaster != null)
                {
                    SelectedMasterName = SelectedStationDBPageModelMaster.Name;
                    SelectedLatitudeMaster = SelectedStationDBPageModelMaster.Latitude;
                    SelectedLongitudeMaster = SelectedStationDBPageModelMaster.Longitude;
                    SelectedElevationMaster = SelectedStationDBPageModelMaster.Elevation;
                    SelectedPoleHeight = SelectedStationDBPageModelMaster.PoleLength;
                    SelectedInstallationOrientation = SelectedStationDBPageModelMaster.InstallationOrientation;
                    SelectedHeadIPAddress = SelectedStationDBPageModelMaster.MasterIPAddress;
                    selectedMasterAntennaIPAddress = SelectedStationDBPageModelMaster.MasterAntennaIPAddress;
                }
                OnPropertyChanged(nameof(SelectedStationDBPageModelMaster));
            }
        }

        private bool isLatLongEnabled;
        public bool IsLatLongEnabled
        {
            get => isLatLongEnabled;
            set
            {
                isLatLongEnabled = value;
                LatLongEnable = value;
                if (!isLatLongEnabled)
                {
                    LatitudeMaster = mainPageMasterViewModel.Latitude102;
                    LongitudeMaster = mainPageMasterViewModel.Longitude103;
                }
                OnPropertyChanged(nameof(IsLatLongEnabled));
                OnPropertyChanged(nameof(LatLongInabilityShow));
            }
        }

        private string latLongInabilityShow;
        public string LatLongInabilityShow
        {
            get => IsLatLongEnabled ? "#FFFFFF" : "#50FFFFFF";
        }

        private string elevationInabilityShow;
        public string ElevationInabilityShow
        {
            get => IsElevationEnabled ? "#FFFFFF" : "#50FFFFFF";
        }

        private bool isElevationEnabled;
        public bool IsElevationEnabled
        {
            get => isElevationEnabled;
            set
            {
                isElevationEnabled = value;
                ElevationEnable = value;
                if (!isElevationEnabled)
                {
                    ElevationMaster = mainPageMasterViewModel.Elevation104;
                }
                OnPropertyChanged(nameof(IsElevationEnabled));
                OnPropertyChanged(nameof(ElevationInabilityShow));
            }
        }

        private bool latLongEnable;
        public bool LatLongEnable
        {
            get => latLongEnable;
            set
            {
                latLongEnable = value;
                OnPropertyChanged(nameof(LatLongEnable));
            }
        }

        private bool elevationEnable;
        public bool ElevationEnable
        {
            get => elevationEnable;
            set
            {
                elevationEnable = value;
                OnPropertyChanged(nameof(ElevationEnable));
            }
        }

        private string latitudeMaster = "";
        public string LatitudeMaster
        {
            get
            {
                return latitudeMaster;
            }

            set
            {
                latitudeMaster = value;
                OnPropertyChanged(nameof(LatitudeMaster));
            }
        }

        private string longitudeMaster = "";
        public string LongitudeMaster
        {
            get
            {
                return longitudeMaster;
            }
            set
            {
                longitudeMaster = value;
                OnPropertyChanged(nameof(LongitudeMaster));
            }
        }

        private string elevationMaster = "";
        public string ElevationMaster
        {
            get
            {
                return elevationMaster;
            }
            set
            {
                elevationMaster = value;
                OnPropertyChanged(nameof(ElevationMaster));
            }
        }

        private string masterName = "";
        public string MasterName
        {
            get
            {
                return masterName;
            }
            set
            {
                masterName = value;
                OnPropertyChanged(nameof(MasterName));
            }
        }

        private string poleHeight = "";
        public string PoleHeight
        {
            get
            {
                return poleHeight;
            }
            set
            {
                poleHeight = value;
                OnPropertyChanged(nameof(PoleHeight));
            }
        }

        private string installationOrientation = "";
        public string InstallationOrientation
        {
            get
            {
                return installationOrientation;
            }
            set
            {
                installationOrientation = value;
                OnPropertyChanged(nameof(InstallationOrientation));
            }
        }

        private string headIPAddress = "";
        public string HeadIPAddress
        {
            get
            {
                if (mainPageMasterViewModel == null || selfRegPageMasterViewModel == null)
                {
                    // Access properties directly
                    mainPageMasterViewModel = app._mainPageMasterViewModel;
                    selfRegPageMasterViewModel = app._selfRegPageMasterViewModel;
                }
                headIPAddress = mainPageMasterViewModel._systemSettingMasterViewModel.UndaiIPAddress;
                return headIPAddress;
            }
            set
            {
                headIPAddress = value;
                OnPropertyChanged(nameof(HeadIPAddress));
            }
        }

        private string masterAntennaIPAddress = "";
        public string MasterAntennaIPAddress
        {
            get
            {
                if (mainPageMasterViewModel == null || selfRegPageMasterViewModel == null)
                {
                    // Access properties directly
                    mainPageMasterViewModel = app._mainPageMasterViewModel;
                    selfRegPageMasterViewModel = app._selfRegPageMasterViewModel;
                }
                masterAntennaIPAddress = mainPageMasterViewModel._systemSettingMasterViewModel.MasterAntennaIPAddress;
                return masterAntennaIPAddress;
            }
            set
            {
                masterAntennaIPAddress = value;
                OnPropertyChanged(nameof(MasterAntennaIPAddress));
            }
        }

        private string selectedMasterName = "";
        public string SelectedMasterName
        {
            get
            {
                return selectedMasterName;
            }
            set
            {
                selectedMasterName = value;
                OnPropertyChanged(nameof(SelectedMasterName));
            }
        }

        private string selectedElevationMaster = "";
        public string SelectedElevationMaster
        {
            get
            {
                return selectedElevationMaster;
            }
            set
            {
                selectedElevationMaster = value;
                OnPropertyChanged(nameof(SelectedElevationMaster));
            }
        }

        private string selectedLongitudeMaster = "";
        public string SelectedLongitudeMaster
        {
            get
            {
                return selectedLongitudeMaster;
            }
            set
            {
                selectedLongitudeMaster = value;
                OnPropertyChanged(nameof(SelectedLongitudeMaster));
            }
        }

        private string selectedLatitudeMaster = "";
        public string SelectedLatitudeMaster
        {
            get
            {
                return selectedLatitudeMaster;
            }
            set
            {
                selectedLatitudeMaster = value;
                OnPropertyChanged(nameof(SelectedLatitudeMaster));
            }
        }

        private string selectedPoleHeight = "";
        public string SelectedPoleHeight
        {
            get
            {
                return selectedPoleHeight;
            } 
            set
            {
                selectedPoleHeight = value;
                OnPropertyChanged(nameof(SelectedPoleHeight));
            }
        }

        private string selectedInstallationOrientation = "";
        public string SelectedInstallationOrientation
        {
            get
            {
                return selectedInstallationOrientation;
            }
            set
            {
                selectedInstallationOrientation = value;
                OnPropertyChanged(nameof(SelectedInstallationOrientation));
            }
        }

        private string selectedHeadIPAddress = "";
        public string SelectedHeadIPAddress
        {
            get
            {
                return selectedHeadIPAddress;
            }
            set
            {
                selectedHeadIPAddress = value;
                OnPropertyChanged(nameof(SelectedHeadIPAddress));
            }
        }

        private string selectedMasterAntennaIPAddress = "";
        public string SelectedMasterAntennaIPAddress
        {
            get
            {
                return selectedMasterAntennaIPAddress;
            }
            set
            {
                selectedMasterAntennaIPAddress = value;
                OnPropertyChanged(nameof(SelectedMasterAntennaIPAddress));
            }
        }

        public bool IsIPAddressShow
        {
            get
            {
                return mainPageMasterViewModel.IsIPAddressShow;
            }
            set
            {
                mainPageMasterViewModel.IsIPAddressShow = value;
                OnPropertyChanged(nameof(IsIPAddressShow));
            }
        }

        public void AddStationDBPage
        (
            string Name, 
            string Latitude, 
            string Longitude, 
            string Elevation, 
            string PoleLength, 
            string InstallationOrientation, 
            string MasterIPAddress, 
            string MasterAntennaIPAddress,
            string Date,
            String Time
        )
        {
            if (stationDBPageModelMasterCount < 15 || stationDBPageModelMaster.Count < 15)
            {
                if 
                (
                    Name == "" & 
                    Latitude == "" & 
                    Longitude == "" & 
                    Elevation == "" & 
                    PoleLength == "" & 
                    InstallationOrientation == "" & 
                    MasterIPAddress == "" & 
                    MasterAntennaIPAddress == "" &
                    Date == "" &
                    Time == ""
                )
                {
                    newStationDBPageModelMaster = new StationDBPageModelMaster
                    {
                        ID = null,
                        Name = Name,
                        Latitude = Latitude,
                        Longitude = Longitude,
                        Elevation = Elevation,
                        PoleLength = PoleLength,
                        InstallationOrientation = InstallationOrientation,
                        MasterIPAddress = MasterIPAddress,
                        MasterAntennaIPAddress = MasterAntennaIPAddress,
                        Date = Date,
                        Time = Time
                    };

                    stationDBPageModelMasterCount++;
                    StationDBPageModelMaster.Add(newStationDBPageModelMaster);
                }
                else
                {
                    newStationDBPageModelMaster = new StationDBPageModelMaster
                    {
                        ID = stationDBPageModelMasterCount + 1,
                        Name = Name,
                        Latitude = Latitude,
                        Longitude = Longitude,
                        Elevation = Elevation,
                        PoleLength = PoleLength,
                        InstallationOrientation = InstallationOrientation,
                        MasterIPAddress = MasterIPAddress,
                        MasterAntennaIPAddress = MasterAntennaIPAddress,
                        Date = Date,
                        Time = Time
                    };

                    stationDBPageModelMasterCount++;
                    StationDBPageModelMaster.Add(newStationDBPageModelMaster);
                }
            }
            else 
            {
                // Update the existing item at the current index
                int indexToUpdate = stationDBPageModelMasterCount % 15;

                StationDBPageModelMaster[indexToUpdate] = new StationDBPageModelMaster
                {
                    ID = indexToUpdate + 1,  // Update ID to match the new entry position
                    Name = Name,
                    Latitude = Latitude,
                    Longitude = Longitude,
                    Elevation = Elevation,
                    PoleLength = PoleLength,
                    InstallationOrientation = InstallationOrientation,
                    MasterIPAddress = MasterIPAddress,
                    MasterAntennaIPAddress = MasterAntennaIPAddress,
                    Date = Date,
                    Time = Time
                };

                stationDBPageModelMasterCount++;
            }
        }

        public void DeleteSelectedItem()
        {
            if (SelectedStationDBPageModelMaster != null)
            {
                StationDBPageModelMaster.Remove(SelectedStationDBPageModelMaster);
                AddStationDBPage
                (
                    "", "", "", "", "", "", "", "", "",""
                );
            }
        }

        public bool CanDeleteSelectedItem()
        {
            return SelectedStationDBPageModelMaster != null;
        }

        public void ExportStationDBPageModelMasterToCsv(ObservableCollection<StationDBPageModelMaster> stationDBPageModelMasters)
        {
            // Specify the file path for the CSV output
            string baseDirectory = AppContext.BaseDirectory;
            string filePath = baseDirectory + "MasterStationDBExport.csv";
            var sb = new StringBuilder();

            // Define the column headers based on the properties of StationDBPageModelMaster
            sb.AppendLine
                (
                    "ID," +
                    "Name," +
                    "Latitude," +
                    "Longitude," +
                    "Elevation," +
                    "PoleLength," +
                    "InstallationOrientation," +
                    "MasterIPAddress," +
                    "MasterAntennaIPAddress," +
                    "Date," +
                    "Time"
                );

            // Iterate over the collection to get the row data
            foreach (var station in stationDBPageModelMasters)
            {
                sb.AppendLine
                    (
                        $"{station.ID}," +
                        $"{station.Name}," +
                        $"{station.Latitude}," +
                        $"{station.Longitude}," +
                        $"{station.Elevation}," +
                        $"{station.PoleLength}," +
                        $"{station.InstallationOrientation}," +
                        $"{station.MasterIPAddress}," +
                        $"{station.MasterAntennaIPAddress}," +
                        $"{station.Date}," +
                        $"{station.Time}"
                    );
            }

            // Write the CSV content to a file
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);

            // Show a confirmation message
            MessageBoxResult exportSuccessfulMessageBox = MessageBox.Show(
                "Database export successful",
                "EXPORT SUCCESSFUL",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );

            // Check the user's choice
            if (exportSuccessfulMessageBox == MessageBoxResult.OK)
            {
            }
        }

        public void EditedDataGridSend()
        {
            if(mainPageMasterViewModel == null || selfRegPageMasterViewModel == null)
            {
                // Access properties directly
                mainPageMasterViewModel = app._mainPageMasterViewModel;
                selfRegPageMasterViewModel = app._selfRegPageMasterViewModel;
            }
            _message =
                "DM," +
                SelectedMasterName +
                "," +
                SelectedLatitudeMaster +
                "," +
                SelectedLongitudeMaster +
                "," +
                SelectedElevationMaster +
                "," +
                SelectedPoleHeight +
                "," +
                SelectedInstallationOrientation +
                "," +
                DateTime.Now.Date.ToString("yyyy-MM-dd") + 
                "," +
                DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss") +
                ",\n";

            if
            (
                SelectedMasterName == "" || SelectedMasterName == null ||
                SelectedLatitudeMaster == "" || SelectedLatitudeMaster == null ||
                SelectedLongitudeMaster == "" || SelectedLongitudeMaster == null ||
                SelectedElevationMaster == "" || SelectedElevationMaster == null ||
                SelectedPoleHeight == "" || SelectedPoleHeight == null ||
                SelectedInstallationOrientation == "" || SelectedInstallationOrientation == null ||
                SelectedHeadIPAddress == "" || SelectedHeadIPAddress == null ||
                SelectedMasterAntennaIPAddress == "" || SelectedMasterAntennaIPAddress == null
            )
            {
                if (MessageBox.Show("Please fill all, try again?",
                        "Not Complete",
                        MessageBoxButton.OK,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    // Optionally, do something here if the user clicks "Yes"

                }
            }
            else if(!MainPageMasterModel.IsValidIPAddress(SelectedHeadIPAddress))
            {
                if (MessageBox.Show("Please reenter, try again?",
                        "INVALID UNDAI IPADDRESS",
                        MessageBoxButton.OK,
                        MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    // Optionally, do something here if the user clicks "OK"
                }
            }
            else if(!MainPageMasterModel.IsValidIPAddress(SelectedMasterAntennaIPAddress))
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
                mainPageMasterViewModel.MainPageMasterModel.MessageSend(_message);
            }
            //mainPageMasterNavigateCommand.Execute(null);

        }

        public void RegistrationDataGridSend()
        {
            _message =
                "DM," +
                MasterName +
                "," +
                LatitudeMaster +
                "," +
                LongitudeMaster +
                "," +
                ElevationMaster +
                "," +
                PoleHeight +
                "," +
                InstallationOrientation +
                "," +
                DateTime.Now.Date.ToString("yyyy-MM-dd") +
                "," +
                DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss") +
                ",\n";

            if
            (
                LatitudeMaster == "" || LatitudeMaster == null ||
                LongitudeMaster == "" || LongitudeMaster == null ||
                ElevationMaster == "" || ElevationMaster == null ||
                PoleHeight == "" || PoleHeight == null ||
                InstallationOrientation == "" || InstallationOrientation == null ||
                HeadIPAddress == "" || HeadIPAddress == null ||
                MasterAntennaIPAddress == "" || MasterAntennaIPAddress == null
            )
            {
                if (MessageBox.Show("Please fill all, try again?",
                        "Not Complete",
                        MessageBoxButton.OK,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    // Optionally, do something here if the user clicks "Yes"
                }
            }
            else if
            (!MainPageMasterModel.IsValidIPAddress(HeadIPAddress))
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
            (!MainPageMasterModel.IsValidIPAddress(MasterAntennaIPAddress))
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
                mainPageMasterViewModel.MainPageMasterModel.MessageSend(_message);
            }
            //mainPageMasterNavigateCommand.Execute(null);
        }
    }
}
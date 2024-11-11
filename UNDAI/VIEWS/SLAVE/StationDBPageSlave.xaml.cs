using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.VIEWS.BASE;

namespace UNDAI.VIEWS.SLAVE
{
    /// <summary>
    /// Interaction logic for StationDBPageSlave.xaml
    /// </summary>
    public partial class StationDBPageSlave : UserControl
    {
        NumericKeyboardWindowStationDBSlave _numericKeyboardWindowStationDB;
        int textBoxNo;
        string backupString;
        bool isTextboxClicked = false;
        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;
        App app;

        private StationDBPageSlaveViewModel? ViewModel => DataContext as StationDBPageSlaveViewModel;

        public StationDBPageSlave()
        {
            InitializeComponent();
            InitializeDebounceTimer(); // Initialize debounce logic
            app = (App)Application.Current;
            CreateAppClassAfterDelay();

            if (ViewModel != null)
            {
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBSlave(0, ViewModel, "");
            }
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._stationDBPageSlaveViewModel;
            }
        }

        private void LatitudeSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsLatLongEnabled)
                {
                    LatitudeSlaveTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LatitudeSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsLatLongEnabled)
                {
                    LatitudeSlaveTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LatitudeSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsLatLongEnabled)
                {
                    LatitudeSlaveTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsLatLongEnabled)
                {
                    LongitudeSlaveTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsLatLongEnabled)
                {
                    LongitudeSlaveTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsLatLongEnabled)
                {
                    LongitudeSlaveTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlaveTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlaveTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlaveTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleHeightSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PoleHeightSlaveTextBox();
        }

        private void PoleHeightSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PoleHeightSlaveTextBox();
        }

        private void PoleHeightSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PoleHeightSlaveTextBox();
        }

        private void InstallationOrientationSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InstallationOrientationSlaveTextBox();
        }

        private void InstallationOrientationSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            InstallationOrientationSlaveTextBox();
        }

        private void InstallationOrientationSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            InstallationOrientationSlaveTextBox();
        }

        private void HeadIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            HeadIPAddressSlaveTextBox();
        }

        private void HeadIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            HeadIPAddressSlaveTextBox();
        }

        private void HeadIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            HeadIPAddressSlaveTextBox();
        }

        private void SelectedLatitudeSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedLatitudeSlaveTextBox();
        }

        private void SelectedLatitudeSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedLatitudeSlaveTextBox();
        }

        private void SelectedLatitudeSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedLatitudeSlaveTextBox();
        }

        private void SelectedPoleHeightSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedPoleHeightSlaveTextBox();
        }

        private void SelectedPoleHeightSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedPoleHeightSlaveTextBox();
        }

        private void SelectedPoleHeightSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedPoleHeightSlaveTextBox();
        }

        private void SelectedHeadIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedHeadIPAddressSlaveTextBox();
        }

        private void SelectedHeadIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedHeadIPAddressSlaveTextBox();
        }

        private void SelectedHeadIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedHeadIPAddressSlaveTextBox();
        }

        private void SelectedInstallationOrientationSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedInstallationOrientationSlaveTextBox();
        }

        private void SelectedInstallationOrientationSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedInstallationOrientationSlaveTextBox();
        }

        private void SelectedInstallationOrientationSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedInstallationOrientationSlaveTextBox();
        }

        private void SelectedLongitudeSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedLongitudeSlaveTextBox();
        }

        private void SelectedLongitudeSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedLongitudeSlaveTextBox();
        }

        private void SelectedLongitudeSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedLongitudeSlaveTextBox();
        }

        private void SelectedElevationSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedElevationSlaveTextBox();
        }

        private void SelectedElevationSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedElevationSlaveTextBox();
        }

        private void SelectedElevationSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedElevationSlaveTextBox();
        }

        private void EditDataGridCommandSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            EditDataGridCommandSlaveBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(1);
            SlaveNameTxtBox.Focusable = false;
        }

        private void EditDataGridCommandSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            EditDataGridCommandSlaveBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(1);
            SlaveNameTxtBox.Focusable = false;
        }

        private void EditDataGridCommandSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            EditDataGridCommandSlaveBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(1);
            SlaveNameTxtBox.Focusable = false;
        }

        private void StationDBPageSlaveNavigate_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(2);
            SlaveNameTxtBox.Focusable = false;
        }

        private void StationDBPageSlaveNavigate_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(2);
            SlaveNameTxtBox.Focusable = false;
        }

        private void StationDBPageSlaveNavigate_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(2);
            SlaveNameTxtBox.Focusable = false;
        }

        private void DBExportCommandSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(3);
            SlaveNameTxtBox.Focusable = false;
        }

        private void DBExportCommandSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(3);
            SlaveNameTxtBox.Focusable = false;
        }

        private void DBExportCommandSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(3);
            SlaveNameTxtBox.Focusable = false;
        }

        private void DeleteSelectedItem_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(4);
            SlaveNameTxtBox.Focusable = false;
        }

        private void DeleteSelectedItem_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(4);
            SlaveNameTxtBox.Focusable = false;
        }

        private void DeleteSelectedItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(4);
            SlaveNameTxtBox.Focusable = false;
        }

        private void MainPageSlaveNavigate_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(5);
            SlaveNameTxtBox.Focusable = false;
        }

        private void MainPageSlaveNavigate_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(5);
            SlaveNameTxtBox.Focusable = false;
        }

        private void MainPageSlaveNavigate_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(5);
            SlaveNameTxtBox.Focusable = false;
        }

        private void SlaveNameTxtBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SlaveNameTxtBox.Focusable = true;
        }

        private void SlaveNameTxtBox_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SlaveNameTxtBox.Focusable = true;
        }

        private void SlaveNameTxtBox_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SlaveNameTxtBox.Focusable = true;
        }

        private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isTextboxClicked)
            {
                KeypadClose();
                isTextboxClicked = false;
            }
            SlaveNameTxtBox.Focusable = false;
        }

        private void UserControl_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (isTextboxClicked)
            {
                KeypadClose();
                isTextboxClicked = false;
            }
            SlaveNameTxtBox.Focusable = false;
        }

        private void UserControl_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (isTextboxClicked)
            {
                KeypadClose();
                isTextboxClicked = false;
            }
            SlaveNameTxtBox.Focusable = false;
        }

        // Common method for processing number input
        private void ProcessNumberInput(int index)
        {
            if (ViewModel != null)
            {
                switch (index)
                {
                    case 1:
                        if (canProcessInput)
                        {
                            ViewModel?.EditDataGridCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer

                            TempWindow tW = new TempWindow();
                        }
                        break;

                    case 2:
                        if (canProcessInput)
                        {
                            ViewModel?.stationDBPageSlaveNavigateCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer

                            TempWindow tW = new TempWindow();
                        }
                        break;

                    case 3:
                        if (canProcessInput)
                        {
                            ViewModel?.DBExportCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer
                        }
                        break;

                    case 4:
                        if (canProcessInput)
                        {
                            ViewModel?.DeleteSelectedItemCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer
                        }
                        break;

                    case 5:
                        if (canProcessInput)
                        {
                            ViewModel?.mainPageSlaveNavigateCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer

                            TempWindow tW = new TempWindow();
                        }
                        break;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        // Initialize the debounce timer
        private void InitializeDebounceTimer()
        {
            debounceTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(200) // Set debounce time (200ms in this case)
            };
            debounceTimer.Tick += (s, e) =>
            {
                canProcessInput = true; // Reset the input flag after debounce period
                debounceTimer.Stop(); // Stop the timer after reset
            };
        }

        private void LatitudeSlaveTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 1;
                isTextboxClicked = true;
                backupString = ViewModel.LatitudeSlave;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.LatitudeSlave;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LatitudeSlave.Length > 0)
                        {
                            ViewModel.LatitudeSlave = ViewModel.LatitudeSlave.Substring(0, ViewModel.LatitudeSlave.Length - 1);
                        }
                        else
                        {
                            ViewModel.LatitudeSlave = ViewModel.LatitudeSlave;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LatitudeSlave.Length > 0)
                        {
                            if (ViewModel.LatitudeSlave[0] == '-')
                            {
                                ViewModel.LatitudeSlave = ViewModel.LatitudeSlave.Substring(1);
                            }
                            else
                            {
                                ViewModel.LatitudeSlave = '-' + ViewModel.LatitudeSlave;
                            }
                        }
                        else
                        {
                            ViewModel.LatitudeSlave = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LatitudeSlave.Length == 0)
                        {
                            ViewModel.LatitudeSlave = "0.";
                        }
                        else if (ViewModel.LatitudeSlave.Contains("."))
                        {
                            ViewModel.LatitudeSlave = ViewModel.LatitudeSlave;
                        }
                        else if (ViewModel.LatitudeSlave.Length == 1 && ViewModel.LatitudeSlave[0] == '-')
                        {
                            ViewModel.LatitudeSlave = "-0.";
                        }
                        else
                        {
                            ViewModel.LatitudeSlave = ViewModel.LatitudeSlave + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LatitudeSlave.Length == 1 && ViewModel.LatitudeSlave[0] == '0')
                        {
                            ViewModel.LatitudeSlave = "";
                        }
                        ViewModel.LatitudeSlave += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.LatitudeSlave.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeSlaveTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 2;
                isTextboxClicked = true;
                backupString = ViewModel.LongitudeSlave;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.LongitudeSlave;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LongitudeSlave.Length > 0)
                        {
                            ViewModel.LongitudeSlave = ViewModel.LongitudeSlave.Substring(0, ViewModel.LongitudeSlave.Length - 1);
                        }
                        else
                        {
                            ViewModel.LongitudeSlave = ViewModel.LongitudeSlave;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LongitudeSlave.Length > 0)
                        {
                            if (ViewModel.LongitudeSlave[0] == '-')
                            {
                                ViewModel.LongitudeSlave = ViewModel.LongitudeSlave.Substring(1);
                            }
                            else
                            {
                                ViewModel.LongitudeSlave = '-' + ViewModel.LongitudeSlave;
                            }
                        }
                        else
                        {
                            ViewModel.LongitudeSlave = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LongitudeSlave.Length == 0)
                        {
                            ViewModel.LongitudeSlave = "0.";
                        }
                        else if (ViewModel.LongitudeSlave.Contains("."))
                        {
                            ViewModel.LongitudeSlave = ViewModel.LongitudeSlave;
                        }
                        else if (ViewModel.LongitudeSlave.Length == 1 && ViewModel.LongitudeSlave[0] == '-')
                        {
                            ViewModel.LongitudeSlave = "-0.";
                        }
                        else
                        {
                            ViewModel.LongitudeSlave = ViewModel.LongitudeSlave + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LongitudeSlave.Length == 1 && ViewModel.LongitudeSlave[0] == '0')
                        {
                            ViewModel.LongitudeSlave = "";
                        }
                        ViewModel.LongitudeSlave += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.LongitudeSlave.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlaveTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 3;
                isTextboxClicked = true;
                backupString = ViewModel.ElevationSlave;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.ElevationSlave;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationSlave.Length > 0)
                        {
                            ViewModel.ElevationSlave = ViewModel.ElevationSlave.Substring(0, ViewModel.ElevationSlave.Length - 1);
                        }
                        else
                        {
                            ViewModel.ElevationSlave = ViewModel.ElevationSlave;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.ElevationSlave.Length > 0)
                        {
                            if (ViewModel.ElevationSlave[0] == '-')
                            {
                                ViewModel.ElevationSlave = ViewModel.ElevationSlave.Substring(1);
                            }
                            else
                            {
                                ViewModel.ElevationSlave = '-' + ViewModel.ElevationSlave;
                            }
                        }
                        else
                        {
                            ViewModel.ElevationSlave = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.ElevationSlave.Length == 0)
                        {
                            ViewModel.ElevationSlave = "0.";
                        }
                        else if (ViewModel.ElevationSlave.Contains("."))
                        {
                            ViewModel.ElevationSlave = ViewModel.ElevationSlave;
                        }
                        else if (ViewModel.ElevationSlave.Length == 1 && ViewModel.ElevationSlave[0] == '-')
                        {
                            ViewModel.ElevationSlave = "-0.";
                        }
                        else
                        {
                            ViewModel.ElevationSlave = ViewModel.ElevationSlave + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.ElevationSlave.Length == 1 && ViewModel.ElevationSlave[0] == '0')
                        {
                            ViewModel.ElevationSlave = "";
                        }
                        ViewModel.ElevationSlave += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.ElevationSlave.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleHeightSlaveTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 4;
                isTextboxClicked = true;
                backupString = ViewModel.PoleHeight;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.PoleHeight;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.PoleHeight.Length > 0)
                        {
                            ViewModel.PoleHeight = ViewModel.PoleHeight.Substring(0, ViewModel.PoleHeight.Length - 1);
                        }
                        else
                        {
                            ViewModel.PoleHeight = ViewModel.PoleHeight;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.PoleHeight.Length > 0)
                        {
                            if (ViewModel.PoleHeight[0] == '-')
                            {
                                ViewModel.PoleHeight = ViewModel.PoleHeight.Substring(1);
                            }
                            else
                            {
                                ViewModel.PoleHeight = '-' + ViewModel.PoleHeight;
                            }
                        }
                        else
                        {
                            ViewModel.PoleHeight = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.PoleHeight.Length == 0)
                        {
                            ViewModel.PoleHeight = "0.";
                        }
                        else if (ViewModel.PoleHeight.Contains("."))
                        {
                            ViewModel.PoleHeight = ViewModel.PoleHeight;
                        }
                        else if (ViewModel.PoleHeight.Length == 1 && ViewModel.PoleHeight[0] == '-')
                        {
                            ViewModel.PoleHeight = "-0.";
                        }
                        else
                        {
                            ViewModel.PoleHeight = ViewModel.PoleHeight + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.PoleHeight.Length == 1 && ViewModel.PoleHeight[0] == '0')
                        {
                            ViewModel.PoleHeight = "";
                        }
                        ViewModel.PoleHeight += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.PoleHeight.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void InstallationOrientationSlaveTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 5;
                isTextboxClicked = true;
                backupString = ViewModel.InstallationOrientation;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.InstallationOrientation;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.InstallationOrientation.Length > 0)
                        {
                            ViewModel.InstallationOrientation = ViewModel.InstallationOrientation.Substring(0, ViewModel.InstallationOrientation.Length - 1);
                        }
                        else
                        {
                            ViewModel.InstallationOrientation = ViewModel.InstallationOrientation;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.InstallationOrientation.Length > 0)
                        {
                            if (ViewModel.InstallationOrientation[0] == '-')
                            {
                                ViewModel.InstallationOrientation = ViewModel.InstallationOrientation.Substring(1);
                            }
                            else
                            {
                                ViewModel.InstallationOrientation = '-' + ViewModel.InstallationOrientation;
                            }
                        }
                        else
                        {
                            ViewModel.InstallationOrientation = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.InstallationOrientation.Length == 0)
                        {
                            ViewModel.InstallationOrientation = "0.";
                        }
                        else if (ViewModel.InstallationOrientation.Contains("."))
                        {
                            ViewModel.InstallationOrientation = ViewModel.InstallationOrientation;
                        }
                        else if (ViewModel.InstallationOrientation.Length == 1 && ViewModel.InstallationOrientation[0] == '-')
                        {
                            ViewModel.InstallationOrientation = "-0.";
                        }
                        else
                        {
                            ViewModel.InstallationOrientation = ViewModel.InstallationOrientation + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.InstallationOrientation.Length == 1 && ViewModel.InstallationOrientation[0] == '0')
                        {
                            ViewModel.InstallationOrientation = "";
                        }
                        ViewModel.InstallationOrientation += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.InstallationOrientation.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void HeadIPAddressSlaveTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 6;
                isTextboxClicked = true;
                backupString = ViewModel.HeadIPAddress;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.HeadIPAddress;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.HeadIPAddress.Length > 0)
                        {
                            ViewModel.HeadIPAddress = ViewModel.HeadIPAddress.Substring(0, ViewModel.HeadIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.HeadIPAddress = ViewModel.HeadIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.HeadIPAddress = ViewModel.HeadIPAddress;
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.HeadIPAddress.Length == 0)
                        {
                            ViewModel.HeadIPAddress = "0.";
                        }
                        else if (ViewModel.HeadIPAddress.Length == 1 && ViewModel.HeadIPAddress[0] == '-')
                        {
                            ViewModel.HeadIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.HeadIPAddress = ViewModel.HeadIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.HeadIPAddress.Length == 1 && ViewModel.HeadIPAddress[0] == '0')
                        {
                            ViewModel.HeadIPAddress = "";
                        }
                        ViewModel.HeadIPAddress += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.HeadIPAddress.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedLatitudeSlaveTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 8;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedLatitudeSlave;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedLatitudeSlave;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedLatitudeSlave.Length > 0)
                        {
                            ViewModel.SelectedLatitudeSlave = ViewModel.SelectedLatitudeSlave.Substring(0, ViewModel.SelectedLatitudeSlave.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave = ViewModel.SelectedLatitudeSlave;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedLatitudeSlave.Length > 0)
                        {
                            if (ViewModel.SelectedLatitudeSlave[0] == '-')
                            {
                                ViewModel.SelectedLatitudeSlave = ViewModel.SelectedLatitudeSlave.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedLatitudeSlave = '-' + ViewModel.SelectedLatitudeSlave;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedLatitudeSlave.Length == 0)
                        {
                            ViewModel.SelectedLatitudeSlave = "0.";
                        }
                        else if (ViewModel.SelectedLatitudeSlave.Contains("."))
                        {
                            ViewModel.SelectedLatitudeSlave = ViewModel.SelectedLatitudeSlave;
                        }
                        else if (ViewModel.SelectedLatitudeSlave.Length == 1 && ViewModel.SelectedLatitudeSlave[0] == '-')
                        {
                            ViewModel.SelectedLatitudeSlave = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave = ViewModel.SelectedLatitudeSlave + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedLatitudeSlave.Length == 1 && ViewModel.SelectedLatitudeSlave[0] == '0')
                        {
                            ViewModel.SelectedLatitudeSlave = "";
                        }
                        ViewModel.SelectedLatitudeSlave += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedLatitudeSlave.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedLongitudeSlaveTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 9;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedLongitudeSlave;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedLongitudeSlave;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedLongitudeSlave.Length > 0)
                        {
                            ViewModel.SelectedLongitudeSlave = ViewModel.SelectedLongitudeSlave.Substring(0, ViewModel.SelectedLongitudeSlave.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeSlave = ViewModel.SelectedLongitudeSlave;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedLongitudeSlave.Length > 0)
                        {
                            if (ViewModel.SelectedLongitudeSlave[0] == '-')
                            {
                                ViewModel.SelectedLongitudeSlave = ViewModel.SelectedLongitudeSlave.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedLongitudeSlave = '-' + ViewModel.SelectedLongitudeSlave;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeSlave = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedLongitudeSlave.Length == 0)
                        {
                            ViewModel.SelectedLongitudeSlave = "0.";
                        }
                        else if (ViewModel.SelectedLongitudeSlave.Contains("."))
                        {
                            ViewModel.SelectedLongitudeSlave = ViewModel.SelectedLongitudeSlave;
                        }
                        else if (ViewModel.SelectedLongitudeSlave.Length == 1 && ViewModel.SelectedLongitudeSlave[0] == '-')
                        {
                            ViewModel.SelectedLongitudeSlave = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeSlave = ViewModel.SelectedLongitudeSlave + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedLongitudeSlave.Length == 1 && ViewModel.SelectedLongitudeSlave[0] == '0')
                        {
                            ViewModel.SelectedLongitudeSlave = "";
                        }
                        ViewModel.SelectedLongitudeSlave += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedLongitudeSlave.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedElevationSlaveTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 10;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedElevationSlave;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedElevationSlave;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedElevationSlave.Length > 0)
                        {
                            ViewModel.SelectedElevationSlave = ViewModel.SelectedElevationSlave.Substring(0, ViewModel.SelectedElevationSlave.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedElevationSlave = ViewModel.SelectedElevationSlave;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedElevationSlave.Length > 0)
                        {
                            if (ViewModel.SelectedElevationSlave[0] == '-')
                            {
                                ViewModel.SelectedElevationSlave = ViewModel.SelectedElevationSlave.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedElevationSlave = '-' + ViewModel.SelectedElevationSlave;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedElevationSlave = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedElevationSlave.Length == 0)
                        {
                            ViewModel.SelectedElevationSlave = "0.";
                        }
                        else if (ViewModel.SelectedElevationSlave.Contains("."))
                        {
                            ViewModel.SelectedElevationSlave = ViewModel.SelectedElevationSlave;
                        }
                        else if (ViewModel.SelectedElevationSlave.Length == 1 && ViewModel.SelectedElevationSlave[0] == '-')
                        {
                            ViewModel.SelectedElevationSlave = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedElevationSlave = ViewModel.SelectedElevationSlave + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedElevationSlave.Length == 1 && ViewModel.SelectedElevationSlave[0] == '0')
                        {
                            ViewModel.SelectedElevationSlave = "";
                        }
                        ViewModel.SelectedElevationSlave += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedElevationSlave.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedPoleHeightSlaveTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 11;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedPoleHeight;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedPoleHeight;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedPoleHeight.Length > 0)
                        {
                            ViewModel.SelectedPoleHeight = ViewModel.SelectedPoleHeight.Substring(0, ViewModel.SelectedPoleHeight.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedPoleHeight = ViewModel.SelectedPoleHeight;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedPoleHeight.Length > 0)
                        {
                            if (ViewModel.SelectedPoleHeight[0] == '-')
                            {
                                ViewModel.SelectedPoleHeight = ViewModel.SelectedPoleHeight.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedPoleHeight = '-' + ViewModel.SelectedPoleHeight;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedPoleHeight = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedPoleHeight.Length == 0)
                        {
                            ViewModel.SelectedPoleHeight = "0.";
                        }
                        else if (ViewModel.SelectedPoleHeight.Contains("."))
                        {
                            ViewModel.SelectedPoleHeight = ViewModel.SelectedPoleHeight;
                        }
                        else if (ViewModel.SelectedPoleHeight.Length == 1 && ViewModel.SelectedPoleHeight[0] == '-')
                        {
                            ViewModel.SelectedPoleHeight = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedPoleHeight = ViewModel.SelectedPoleHeight + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedPoleHeight.Length == 1 && ViewModel.SelectedPoleHeight[0] == '0')
                        {
                            ViewModel.SelectedPoleHeight = "";
                        }
                        ViewModel.SelectedPoleHeight += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedPoleHeight.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedInstallationOrientationSlaveTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 12;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedInstallationOrientation;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedInstallationOrientation;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedInstallationOrientation.Length > 0)
                        {
                            ViewModel.SelectedInstallationOrientation = ViewModel.SelectedInstallationOrientation.Substring(0, ViewModel.SelectedInstallationOrientation.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedInstallationOrientation = ViewModel.SelectedInstallationOrientation;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedInstallationOrientation.Length > 0)
                        {
                            if (ViewModel.SelectedInstallationOrientation[0] == '-')
                            {
                                ViewModel.SelectedInstallationOrientation = ViewModel.SelectedInstallationOrientation.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedInstallationOrientation = '-' + ViewModel.SelectedInstallationOrientation;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedInstallationOrientation = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedInstallationOrientation.Length == 0)
                        {
                            ViewModel.SelectedInstallationOrientation = "0.";
                        }
                        else if (ViewModel.SelectedInstallationOrientation.Contains("."))
                        {
                            ViewModel.SelectedInstallationOrientation = ViewModel.SelectedInstallationOrientation;
                        }
                        else if (ViewModel.SelectedInstallationOrientation.Length == 1 && ViewModel.SelectedInstallationOrientation[0] == '-')
                        {
                            ViewModel.SelectedInstallationOrientation = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedInstallationOrientation = ViewModel.SelectedInstallationOrientation + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedInstallationOrientation.Length == 1 && ViewModel.SelectedInstallationOrientation[0] == '0')
                        {
                            ViewModel.SelectedInstallationOrientation = "";
                        }
                        ViewModel.SelectedInstallationOrientation += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedInstallationOrientation.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedHeadIPAddressSlaveTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 13;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedHeadIPAddress;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedHeadIPAddress;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedHeadIPAddress.Length > 0)
                        {
                            ViewModel.SelectedHeadIPAddress = ViewModel.SelectedHeadIPAddress.Substring(0, ViewModel.SelectedHeadIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedHeadIPAddress = ViewModel.SelectedHeadIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.SelectedHeadIPAddress = ViewModel.SelectedHeadIPAddress;
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedHeadIPAddress.Length == 0)
                        {
                            ViewModel.SelectedHeadIPAddress = "0.";
                        }
                        else if (ViewModel.SelectedHeadIPAddress.Length == 1 && ViewModel.SelectedHeadIPAddress[0] == '-')
                        {
                            ViewModel.SelectedHeadIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedHeadIPAddress = ViewModel.SelectedHeadIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedHeadIPAddress.Length == 1 && ViewModel.SelectedHeadIPAddress[0] == '0')
                        {
                            ViewModel.SelectedHeadIPAddress = "";
                        }
                        ViewModel.SelectedHeadIPAddress += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedHeadIPAddress.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void KeypadClose()
        {
            if (ViewModel != null)
            {
                _numericKeyboardWindowStationDB.Close();
                Keyboard.ClearFocus();
                if (textBoxNo == 1 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.LatitudeSlave = backupString;

                }
                else if (textBoxNo == 2 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.LongitudeSlave = backupString;
                }
                else if (textBoxNo == 3 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.ElevationSlave = backupString;
                }
                else if (textBoxNo == 4 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.PoleHeight = backupString;
                }
                else if (textBoxNo == 5 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.InstallationOrientation = backupString;
                }
                else if (textBoxNo == 6 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.HeadIPAddress = backupString;
                }
                else if (textBoxNo == 8 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.SelectedLatitudeSlave = backupString;
                }
                else if (textBoxNo == 9 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.SelectedLongitudeSlave = backupString;
                }
                else if (textBoxNo == 10 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.SelectedElevationSlave = backupString;
                }
                else if (textBoxNo == 11 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.SelectedPoleHeight = backupString;
                }
                else if (textBoxNo == 12 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.SelectedInstallationOrientation = backupString;
                }
                else if (textBoxNo == 13 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.SelectedHeadIPAddress = backupString;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SlaveNameTxtBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SlaveNameTxtBox.Focusable = false;
        }

        private void SlaveNameTxtBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SlaveNameTxtBox.Focusable = false;
        }

        private void EditDataGridCommandSlave_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            EditDataGridCommandSlaveBtn.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
        }

        private void EditDataGridCommandSlave_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            EditDataGridCommandSlaveBtn.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
        }

        private void EditDataGridCommandSlave_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            EditDataGridCommandSlaveBtn.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
        }
    }
}

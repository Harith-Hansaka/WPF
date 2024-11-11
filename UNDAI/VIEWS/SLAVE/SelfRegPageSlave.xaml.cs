using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.VIEWS.BASE;

namespace UNDAI.VIEWS.SLAVE
{
    /// <summary>
    /// Interaction logic for SelfRegPageSlave.xaml
    /// </summary>
    public partial class SelfRegPageSlave : UserControl
    {
        NumericKeyboardWindowSelfRegSlave _numericKeyboardWindowSelfReg;
        int textBoxNo;
        string backupString;
        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;
        App app;

        private SelfRegPageSlaveViewModel? ViewModel => DataContext as SelfRegPageSlaveViewModel;

        public SelfRegPageSlave()
        {
            InitializeComponent();
            InitializeDebounceTimer(); // Initialize debounce logic
            app = (App)Application.Current;
            CreateAppClassAfterDelay();

            if (ViewModel != null)
            {
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegSlave(0, ViewModel, "");
            }
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._selfRegPageSlaveViewModel;
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
        private void PoleHeightSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PoleHeightSlaveTextBox();
        }

        private void PoleHeightSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PoleHeightSlaveTextBox();
        }

        private void PoleHeightSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PoleHeightSlaveTextBox();
        }

        private void InstallationOrientationSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InstallationOrientationSlaveTextBox();
        }

        private void InstallationOrientationSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            InstallationOrientationSlaveTextBox();
        }

        private void InstallationOrientationSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            InstallationOrientationSlaveTextBox();
        }

        private void HeadIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            HeadIPAddressSlaveTextBox();
        }

        private void HeadIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            HeadIPAddressSlaveTextBox();
        }

        private void HeadIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            HeadIPAddressSlaveTextBox();
        }

        private void LatitudeSlaveTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 1;
                backupString = ViewModel.LatitudeSlave;
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSelfReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.LatitudeSlave;
                _numericKeyboardWindowSelfReg.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.LatitudeSlave.ToString();
                };
                _numericKeyboardWindowSelfReg.Show();
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
                backupString = ViewModel.LongitudeSlave;
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSelfReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.LongitudeSlave;
                _numericKeyboardWindowSelfReg.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.LongitudeSlave.ToString();
                };
                _numericKeyboardWindowSelfReg.Show();
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
                backupString = ViewModel.ElevationSlave;
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSelfReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.ElevationSlave;
                _numericKeyboardWindowSelfReg.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.ElevationSlave.ToString();
                };
                _numericKeyboardWindowSelfReg.Show();
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
                backupString = ViewModel.PoleHeight;
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSelfReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.PoleHeight;
                _numericKeyboardWindowSelfReg.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.PoleHeight.ToString();
                };
                _numericKeyboardWindowSelfReg.Show();
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
                backupString = ViewModel.InstallationOrientation;
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSelfReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.InstallationOrientation;
                _numericKeyboardWindowSelfReg.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.InstallationOrientation.ToString();
                };
                _numericKeyboardWindowSelfReg.Show();
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
                backupString = ViewModel.HeadIPAddress;
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSelfReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.HeadIPAddress;
                _numericKeyboardWindowSelfReg.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.HeadIPAddress.ToString();
                };
                _numericKeyboardWindowSelfReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void BaseStationDBPageSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(3);
        }

        private void BaseStationDBPageSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(3);
        }

        private void BaseStationDBPageSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(3);
        }

        private void SlaveDataRegistration_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void SlaveDataRegistration_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void SlaveDataRegistration_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void NavigateCommandSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void NavigateCommandSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void NavigateCommandSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(2);
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
                            ViewModel?.SlaveDataRegistrationCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer

                            TempWindow tW = new TempWindow();
                        }
                        break;
                    case 2:
                        if (canProcessInput)
                        {
                            ViewModel?.NavigateCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer

                            TempWindow tW = new TempWindow();
                        }
                        break;
                    case 3:
                        if (canProcessInput)
                        {
                            ViewModel?.BaseStationDBPageSlaveNavigateCommand?.Execute(null);
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

        private void KeypadClose()
        {
            if (ViewModel != null)
            {
                _numericKeyboardWindowSelfReg.Close();
                Keyboard.ClearFocus();
                if (textBoxNo == 1 && _numericKeyboardWindowSelfReg._status != 1)
                {
                    ViewModel.LatitudeSlave = backupString;

                }
                else if (textBoxNo == 2 && _numericKeyboardWindowSelfReg._status != 1)
                {
                    ViewModel.LongitudeSlave = backupString;
                }
                else if (textBoxNo == 3 && _numericKeyboardWindowSelfReg._status != 1)
                {
                    ViewModel.ElevationSlave = backupString;
                }
                else if (textBoxNo == 4 && _numericKeyboardWindowSelfReg._status != 1)
                {
                    ViewModel.PoleHeight = backupString;
                }
                else if (textBoxNo == 5 && _numericKeyboardWindowSelfReg._status != 1)
                {
                    ViewModel.InstallationOrientation = backupString;
                }
                else if (textBoxNo == 6 && _numericKeyboardWindowSelfReg._status != 1)
                {
                    ViewModel.HeadIPAddress = backupString;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            KeypadClose();
            SlaveNameTxtBox.Focusable = false;
        }

        private void UserControl_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            KeypadClose();
            SlaveNameTxtBox.Focusable = false;
        }

        private void UserControl_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            KeypadClose();
            SlaveNameTxtBox.Focusable = false;
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

        private void SlaveNameTxtBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SlaveNameTxtBox.Focusable = false;
        }

        private void SlaveNameTxtBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SlaveNameTxtBox.Focusable = false;
        }
    }
}
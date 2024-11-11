using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWS.BASE;

namespace UNDAI.VIEWS.MASTER
{
    /// <summary>
    /// Interaction logic for SelfRegPageMaster.xaml
    /// </summary>
    public partial class SelfRegPageMaster : UserControl
    {
        NumericKeyboardWindowSelfRegMaster _numericKeyboardWindowSelfReg;
        int textBoxNo;
        string backupString;
        Process[] processes; 
        Process theTouchKeyboardProcess = null;
        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;
        App app;

        private SelfRegPageMasterViewModel? ViewModel => DataContext as SelfRegPageMasterViewModel;

        public SelfRegPageMaster()
        {
            InitializeComponent();
            InitializeDebounceTimer(); // Initialize debounce logic
            app = (App)Application.Current;
            CreateAppClassAfterDelay();

            if (ViewModel != null)
            {
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegMaster(0, ViewModel, "");
            }
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._selfRegPageMasterViewModel;
            }
        }

        private void LatitudeMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null) 
            {
                if (ViewModel.IsLatLongEnabled)
                {
                    LatitudeMasterTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LatitudeMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsLatLongEnabled)
                {
                    LatitudeMasterTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LatitudeMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsLatLongEnabled)
                {
                    LatitudeMasterTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsLatLongEnabled)
                {
                    LongitudeMasterTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsLatLongEnabled)
                {
                    LongitudeMasterTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsLatLongEnabled)
                {
                    LongitudeMasterTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationMasterTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationMasterTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }
        private void ElevationMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationMasterTextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }
        private void PoleHeightMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PoleHeightMasterTextBox();
        }

        private void PoleHeightMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PoleHeightMasterTextBox();
        }

        private void PoleHeightMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PoleHeightMasterTextBox();
        }

        private void InstallationOrientationMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InstallationOrientationMasterTextBox();
        }

        private void InstallationOrientationMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            InstallationOrientationMasterTextBox();
        }

        private void InstallationOrientationMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            InstallationOrientationMasterTextBox();
        }

        private void HeadIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            HeadIPAddressMasterTextBox();
        }

        private void HeadIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            HeadIPAddressMasterTextBox();
        }

        private void HeadIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            HeadIPAddressMasterTextBox();
        }

        private void LatitudeMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 1;
                backupString = ViewModel.LatitudeMaster;
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSelfReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.LatitudeMaster;
                _numericKeyboardWindowSelfReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LatitudeMaster.Length > 0)
                        {
                            ViewModel.LatitudeMaster = ViewModel.LatitudeMaster.Substring(0, ViewModel.LatitudeMaster.Length - 1);
                        }
                        else
                        {
                            ViewModel.LatitudeMaster = "";
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LatitudeMaster.Length > 0)
                        {
                            if (ViewModel.LatitudeMaster[0] == '-')
                            {
                                ViewModel.LatitudeMaster = ViewModel.LatitudeMaster.Substring(1);
                            }
                            else
                            {
                                ViewModel.LatitudeMaster = '-' + ViewModel.LatitudeMaster;
                            }
                        }
                        else
                        {
                            ViewModel.LatitudeMaster = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LatitudeMaster.Length == 0)
                        {
                            ViewModel.LatitudeMaster = "0.";
                        }
                        else if (ViewModel.LatitudeMaster.Contains("."))
                        {
                            ViewModel.LatitudeMaster = ViewModel.LatitudeMaster;
                        }
                        else if (ViewModel.LatitudeMaster.Length == 1 && ViewModel.LatitudeMaster[0] == '-')
                        {
                            ViewModel.LatitudeMaster = "-0.";
                        }
                        else
                        {
                            ViewModel.LatitudeMaster = ViewModel.LatitudeMaster + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LatitudeMaster.Length == 1 && ViewModel.LatitudeMaster[0] == '0')
                        {
                            ViewModel.LatitudeMaster = "";
                        }
                        ViewModel.LatitudeMaster += key;
                    };
                    _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.LatitudeMaster.ToString();
                };
                _numericKeyboardWindowSelfReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 2;
                backupString = ViewModel.LongitudeMaster;
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSelfReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.LongitudeMaster;
                _numericKeyboardWindowSelfReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LongitudeMaster.Length > 0)
                        {
                            ViewModel.LongitudeMaster = ViewModel.LongitudeMaster.Substring(0, ViewModel.LongitudeMaster.Length - 1);
                        }
                        else
                        {
                            ViewModel.LongitudeMaster = "";
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LongitudeMaster.Length > 0)
                        {
                            if (ViewModel.LongitudeMaster[0] == '-')
                            {
                                ViewModel.LongitudeMaster = ViewModel.LongitudeMaster.Substring(1);
                            }
                            else
                            {
                                ViewModel.LongitudeMaster = '-' + ViewModel.LongitudeMaster;
                            }
                        }
                        else
                        {
                            ViewModel.LongitudeMaster = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LongitudeMaster.Length == 0)
                        {
                            ViewModel.LongitudeMaster = "0.";
                        }
                        else if (ViewModel.LongitudeMaster.Contains("."))
                        {
                            ViewModel.LongitudeMaster = ViewModel.LongitudeMaster;
                        }
                        else if (ViewModel.LongitudeMaster.Length == 1 && ViewModel.LongitudeMaster[0] == '-')
                        {
                            ViewModel.LongitudeMaster = "-0.";
                        }
                        else
                        {
                            ViewModel.LongitudeMaster = ViewModel.LongitudeMaster + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LongitudeMaster.Length == 1 && ViewModel.LongitudeMaster[0] == '0')
                        {
                            ViewModel.LongitudeMaster = "";
                        }
                        ViewModel.LongitudeMaster += key;
                    };
                    _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.LongitudeMaster.ToString();
                };
                _numericKeyboardWindowSelfReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 3;
                backupString = ViewModel.ElevationMaster;
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSelfReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.ElevationMaster;
                _numericKeyboardWindowSelfReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationMaster.Length > 0)
                        {
                            ViewModel.ElevationMaster = ViewModel.ElevationMaster.Substring(0, ViewModel.ElevationMaster.Length - 1);
                        }
                        else
                        {
                            ViewModel.ElevationMaster = "";
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.ElevationMaster.Length > 0)
                        {
                            if (ViewModel.ElevationMaster[0] == '-')
                            {
                                ViewModel.ElevationMaster = ViewModel.ElevationMaster.Substring(1);
                            }
                            else
                            {
                                ViewModel.ElevationMaster = '-' + ViewModel.ElevationMaster;
                            }
                        }
                        else
                        {
                            ViewModel.ElevationMaster = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.ElevationMaster.Length == 0)
                        {
                            ViewModel.ElevationMaster = "0.";
                        }
                        else if (ViewModel.ElevationMaster.Contains("."))
                        {
                            ViewModel.ElevationMaster = ViewModel.ElevationMaster;
                        }
                        else if (ViewModel.ElevationMaster.Length == 1 && ViewModel.ElevationMaster[0] == '-')
                        {
                            ViewModel.ElevationMaster = "-0.";
                        }
                        else
                        {
                            ViewModel.ElevationMaster = ViewModel.ElevationMaster + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.ElevationMaster.Length == 1 && ViewModel.ElevationMaster[0] == '0')
                        {
                            ViewModel.ElevationMaster = "";
                        }
                        ViewModel.ElevationMaster += key;
                    };
                    _numericKeyboardWindowSelfReg.KeyPad.Text = ViewModel.ElevationMaster.ToString();
                };
                _numericKeyboardWindowSelfReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleHeightMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 4;
                backupString = ViewModel.PoleHeight;
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegMaster(textBoxNo, ViewModel, backupString);
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
                            ViewModel.PoleHeight = "";
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

        private void InstallationOrientationMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 5;
                backupString = ViewModel.InstallationOrientation;
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegMaster(textBoxNo, ViewModel, backupString);
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
                            ViewModel.InstallationOrientation = "";
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

        private void HeadIPAddressMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 6;
                backupString = ViewModel.HeadIPAddress;
                _numericKeyboardWindowSelfReg = new NumericKeyboardWindowSelfRegMaster(textBoxNo, ViewModel, backupString);
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
                            ViewModel.HeadIPAddress = "";
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

        private void KeypadClose()
        {
            if (ViewModel != null)
            {
                _numericKeyboardWindowSelfReg.Close();
                Keyboard.ClearFocus();
                if (textBoxNo == 1 && _numericKeyboardWindowSelfReg._status != 1)
                {
                    ViewModel.LatitudeMaster = backupString;
                }
                else if (textBoxNo == 2 && _numericKeyboardWindowSelfReg._status != 1)
                {
                    ViewModel.LongitudeMaster = backupString;
                }
                else if (textBoxNo == 3 && _numericKeyboardWindowSelfReg._status != 1)
                {
                    ViewModel.ElevationMaster = backupString;
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
        }

        private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            KeypadClose();
            MasterNameTxtBox.Focusable = false;
        }

        private void UserControl_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            KeypadClose();
            MasterNameTxtBox.Focusable = false;
        }

        private void UserControl_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            KeypadClose();
            MasterNameTxtBox.Focusable = false;
        }

        private void MasterDataRegistration_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            RegisterBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(2);
            MasterNameTxtBox.Focusable = false;
        }

        private void MasterDataRegistration_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            RegisterBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(2);
            MasterNameTxtBox.Focusable = false;
        }

        private void MasterDataRegistration_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(2);
            MasterNameTxtBox.Focusable = false;
        }

        private void NavigateCommandMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(1);
            MasterNameTxtBox.Focusable = false;
        }

        private void NavigateCommandMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(1);
            MasterNameTxtBox.Focusable = false;
        }

        private void NavigateCommandMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(1);
            MasterNameTxtBox.Focusable = false;
        }

        private void StationDBPageMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(3);
            MasterNameTxtBox.Focusable = false;
        }

        private void StationDBPageMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(3);
            MasterNameTxtBox.Focusable = false;
        }

        private void StationDBPageMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(3);
            MasterNameTxtBox.Focusable = false;
        }

        private void MasterNameTxtBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MasterNameTxtBox.Focusable = true;
        }

        private void MasterNameTxtBox_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            MasterNameTxtBox.Focusable = true;
        }

        private void MasterNameTxtBox_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            MasterNameTxtBox.Focusable = true;
        }

        private void MasterNameTxtBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            MasterNameTxtBox.Focusable = false;
        }

        private void MasterNameTxtBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            MasterNameTxtBox.Focusable = false;
        }

        private void ProcessNumberInput(int index)
        {
            switch (index)
            {
                case 1:
                    if (canProcessInput)
                    {
                        ViewModel?.NavigateCommand?.Execute(null);
                        canProcessInput = false; // Prevent further input until debounce resets
                        debounceTimer.Start(); // Start debounce timer

                        TempWindow tW = new TempWindow();
                    }
                    break;
                case 2:
                    if (canProcessInput)
                    {
                        ViewModel?.MasterDataRegistrationCommand?.Execute(null);
                        canProcessInput = false; // Prevent further input until debounce resets
                        debounceTimer.Start(); // Start debounce timer

                        TempWindow tW = new TempWindow();
                    }
                    break;
                case 3:
                    if (canProcessInput)
                    {
                        ViewModel?.StationDBPageMasterNavigateCommand?.Execute(null);
                        canProcessInput = false; // Prevent further input until debounce resets
                        debounceTimer.Start(); // Start debounce timer

                        TempWindow tW = new TempWindow();
                    }
                    break;
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

        private void MasterDataRegistration_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            RegisterBtn.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd)); // Reset to the original color
        }

        private void MasterDataRegistration_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            RegisterBtn.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd)); // Reset to the original color
        }

        private void MasterDataRegistration_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            RegisterBtn.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd)); // Reset to the original color
        }
    }
}
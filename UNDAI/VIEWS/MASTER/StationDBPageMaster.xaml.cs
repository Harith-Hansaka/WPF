using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWS.BASE;

namespace UNDAI.VIEWS.MASTER
{
    /// <summary>
    /// Interaction logic for StationDBPageMaster.xaml
    /// </summary>
    public partial class StationDBPageMaster : UserControl
    {
        NumericKeyboardWindowStationDBMaster _numericKeyboardWindowStationDB;
        int textBoxNo;
        string backupString;
        bool isTextboxClicked = false;
        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;
        App app;

        private StationDBPageMasterViewModel? ViewModel => DataContext as StationDBPageMasterViewModel;

        public StationDBPageMaster()
        {
            InitializeComponent();
            InitializeDebounceTimer(); // Initialize debounce logic
            app = (App)Application.Current;
            CreateAppClassAfterDelay();

            if (ViewModel != null)
            {
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBMaster(0, ViewModel, "");
            }
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._stationDBPageMasterViewModel;
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

        private void PoleHeightMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PoleHeightMasterTextBox();
        }

        private void PoleHeightMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PoleHeightMasterTextBox();
        }

        private void PoleHeightMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PoleHeightMasterTextBox();
        }

        private void InstallationOrientationMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InstallationOrientationMasterTextBox();
        }

        private void InstallationOrientationMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            InstallationOrientationMasterTextBox();
        }

        private void InstallationOrientationMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            InstallationOrientationMasterTextBox();
        }

        private void HeadIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            HeadIPAddressMasterTextBox();
        }

        private void HeadIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            HeadIPAddressMasterTextBox();
        }

        private void HeadIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            HeadIPAddressMasterTextBox();
        }

        private void SelectedLatitudeMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedLatitudeMasterTextBox();
        }

        private void SelectedLatitudeMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedLatitudeMasterTextBox();
        }

        private void SelectedLatitudeMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedLatitudeMasterTextBox();
        }

        private void SelectedPoleHeightMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedPoleHeightMasterTextBox();
        }

        private void SelectedPoleHeightMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedPoleHeightMasterTextBox();
        }

        private void SelectedPoleHeightMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedPoleHeightMasterTextBox();
        }

        private void SelectedHeadIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedHeadIPAddressMasterTextBox();
        }

        private void SelectedHeadIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedHeadIPAddressMasterTextBox();
        }

        private void SelectedHeadIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedHeadIPAddressMasterTextBox();
        }

        private void SelectedInstallationOrientationMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedInstallationOrientationMasterTextBox();
        }

        private void SelectedInstallationOrientationMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedInstallationOrientationMasterTextBox();
        }

        private void SelectedInstallationOrientationMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedInstallationOrientationMasterTextBox();
        }

        private void SelectedLongitudeMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedLongitudeMasterTextBox();
        }

        private void SelectedLongitudeMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedLongitudeMasterTextBox();
        }

        private void SelectedLongitudeMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedLongitudeMasterTextBox();
        }

        private void SelectedElevationMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedElevationMasterTextBox();
        }

        private void SelectedElevationMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedElevationMasterTextBox();
        }

        private void SelectedElevationMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedElevationMasterTextBox();
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

        private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isTextboxClicked) 
            {
                KeypadClose();
                isTextboxClicked = false;
            }
            MasterNameTxtBox.Focusable = false;
        }

        private void UserControl_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (isTextboxClicked)
            {
                KeypadClose();
                isTextboxClicked = false;
            }
            MasterNameTxtBox.Focusable = false;
        }

        private void UserControl_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (isTextboxClicked)
            {
                KeypadClose();
                isTextboxClicked = false;
            }
            MasterNameTxtBox.Focusable = false;
        }

        private void LatitudeMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 1;
                isTextboxClicked = true;
                backupString = ViewModel.LatitudeMaster;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.LatitudeMaster;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LatitudeMaster.Length > 0)
                        {
                            ViewModel.LatitudeMaster = ViewModel.LatitudeMaster.Substring(0, ViewModel.LatitudeMaster.Length - 1);
                        }
                        else
                        {
                            ViewModel.LatitudeMaster = ViewModel.LatitudeMaster;
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
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.LatitudeMaster.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
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
                isTextboxClicked = true;
                backupString = ViewModel.LongitudeMaster;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.LongitudeMaster;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LongitudeMaster.Length > 0)
                        {
                            ViewModel.LongitudeMaster = ViewModel.LongitudeMaster.Substring(0, ViewModel.LongitudeMaster.Length - 1);
                        }
                        else
                        {
                            ViewModel.LongitudeMaster = ViewModel.LongitudeMaster;
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
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.LongitudeMaster.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
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
                isTextboxClicked = true;
                backupString = ViewModel.ElevationMaster;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.ElevationMaster;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationMaster.Length > 0)
                        {
                            ViewModel.ElevationMaster = ViewModel.ElevationMaster.Substring(0, ViewModel.ElevationMaster.Length - 1);
                        }
                        else
                        {
                            ViewModel.ElevationMaster = ViewModel.ElevationMaster;
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
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.ElevationMaster.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
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
                isTextboxClicked = true;
                backupString = ViewModel.PoleHeight;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBMaster(textBoxNo, ViewModel, backupString);
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
        private void InstallationOrientationMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 5;
                isTextboxClicked = true;
                backupString = ViewModel.InstallationOrientation;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBMaster(textBoxNo, ViewModel, backupString);
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

        private void HeadIPAddressMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 6;
                isTextboxClicked = true;
                backupString = ViewModel.HeadIPAddress;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBMaster(textBoxNo, ViewModel, backupString);
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

        private void SelectedLatitudeMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 8;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedLatitudeMaster;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedLatitudeMaster;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedLatitudeMaster.Length > 0)
                        {
                            ViewModel.SelectedLatitudeMaster = ViewModel.SelectedLatitudeMaster.Substring(0, ViewModel.SelectedLatitudeMaster.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeMaster = ViewModel.SelectedLatitudeMaster;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedLatitudeMaster.Length > 0)
                        {
                            if (ViewModel.SelectedLatitudeMaster[0] == '-')
                            {
                                ViewModel.SelectedLatitudeMaster = ViewModel.SelectedLatitudeMaster.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedLatitudeMaster = '-' + ViewModel.SelectedLatitudeMaster;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeMaster = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedLatitudeMaster.Length == 0)
                        {
                            ViewModel.SelectedLatitudeMaster = "0.";
                        }
                        else if (ViewModel.SelectedLatitudeMaster.Contains("."))
                        {
                            ViewModel.SelectedLatitudeMaster = ViewModel.SelectedLatitudeMaster;
                        }
                        else if (ViewModel.SelectedLatitudeMaster.Length == 1 && ViewModel.SelectedLatitudeMaster[0] == '-')
                        {
                            ViewModel.SelectedLatitudeMaster = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeMaster = ViewModel.SelectedLatitudeMaster + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedLatitudeMaster.Length == 1 && ViewModel.SelectedLatitudeMaster[0] == '0')
                        {
                            ViewModel.SelectedLatitudeMaster = "";
                        }
                        ViewModel.SelectedLatitudeMaster += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedLatitudeMaster.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedLongitudeMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 9;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedLongitudeMaster;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedLongitudeMaster;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedLongitudeMaster.Length > 0)
                        {
                            ViewModel.SelectedLongitudeMaster = ViewModel.SelectedLongitudeMaster.Substring(0, ViewModel.SelectedLongitudeMaster.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeMaster = ViewModel.SelectedLongitudeMaster;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedLongitudeMaster.Length > 0)
                        {
                            if (ViewModel.SelectedLongitudeMaster[0] == '-')
                            {
                                ViewModel.SelectedLongitudeMaster = ViewModel.SelectedLongitudeMaster.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedLongitudeMaster = '-' + ViewModel.SelectedLongitudeMaster;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeMaster = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedLongitudeMaster.Length == 0)
                        {
                            ViewModel.SelectedLongitudeMaster = "0.";
                        }
                        else if (ViewModel.SelectedLongitudeMaster.Contains("."))
                        {
                            ViewModel.SelectedLongitudeMaster = ViewModel.SelectedLongitudeMaster;
                        }
                        else if (ViewModel.SelectedLongitudeMaster.Length == 1 && ViewModel.SelectedLongitudeMaster[0] == '-')
                        {
                            ViewModel.SelectedLongitudeMaster = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeMaster = ViewModel.SelectedLongitudeMaster + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedLongitudeMaster.Length == 1 && ViewModel.SelectedLongitudeMaster[0] == '0')
                        {
                            ViewModel.SelectedLongitudeMaster = "";
                        }
                        ViewModel.SelectedLongitudeMaster += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedLongitudeMaster.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedElevationMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 10;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedElevationMaster;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowStationDB.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedElevationMaster;
                _numericKeyboardWindowStationDB.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedElevationMaster.Length > 0)
                        {
                            ViewModel.SelectedElevationMaster = ViewModel.SelectedElevationMaster.Substring(0, ViewModel.SelectedElevationMaster.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedElevationMaster = ViewModel.SelectedElevationMaster;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedElevationMaster.Length > 0)
                        {
                            if (ViewModel.SelectedElevationMaster[0] == '-')
                            {
                                ViewModel.SelectedElevationMaster = ViewModel.SelectedElevationMaster.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedElevationMaster = '-' + ViewModel.SelectedElevationMaster;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedElevationMaster = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedElevationMaster.Length == 0)
                        {
                            ViewModel.SelectedElevationMaster = "0.";
                        }
                        else if (ViewModel.SelectedElevationMaster.Contains("."))
                        {
                            ViewModel.SelectedElevationMaster = ViewModel.SelectedElevationMaster;
                        }
                        else if (ViewModel.SelectedElevationMaster.Length == 1 && ViewModel.SelectedElevationMaster[0] == '-')
                        {
                            ViewModel.SelectedElevationMaster = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedElevationMaster = ViewModel.SelectedElevationMaster + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedElevationMaster.Length == 1 && ViewModel.SelectedElevationMaster[0] == '0')
                        {
                            ViewModel.SelectedElevationMaster = "";
                        }
                        ViewModel.SelectedElevationMaster += key;
                    };
                    _numericKeyboardWindowStationDB.KeyPad.Text = ViewModel.SelectedElevationMaster.ToString();
                };
                _numericKeyboardWindowStationDB.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedPoleHeightMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 11;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedPoleHeight;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBMaster(textBoxNo, ViewModel, backupString);
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

        private void SelectedInstallationOrientationMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 12;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedInstallationOrientation;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBMaster(textBoxNo, ViewModel, backupString);
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

        private void SelectedHeadIPAddressMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 13;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedHeadIPAddress;
                _numericKeyboardWindowStationDB = new NumericKeyboardWindowStationDBMaster(textBoxNo, ViewModel, backupString);
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
                    ViewModel.LatitudeMaster = backupString;

                }
                else if (textBoxNo == 2 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.LongitudeMaster = backupString;
                }
                else if (textBoxNo == 3 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.ElevationMaster = backupString;
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
                    ViewModel.SelectedLatitudeMaster = backupString;
                }
                else if (textBoxNo == 9 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.SelectedLongitudeMaster = backupString;
                }
                else if (textBoxNo == 10 && _numericKeyboardWindowStationDB._status != 1)
                {
                    ViewModel.SelectedElevationMaster = backupString;
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

        private void EditDataGridCommandMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            EditDataGridCommandMasterBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(1);
            MasterNameTxtBox.Focusable = false;
        }

        private void EditDataGridCommandMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            EditDataGridCommandMasterBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(1);
            MasterNameTxtBox.Focusable = false;
        }

        private void EditDataGridCommandMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            EditDataGridCommandMasterBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(1);
            MasterNameTxtBox.Focusable = false;
        }

        private void StationDBPageMasterNavigate_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(2);
            MasterNameTxtBox.Focusable = false;
        }

        private void StationDBPageMasterNavigate_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(2);
            MasterNameTxtBox.Focusable = false;
        }

        private void StationDBPageMasterNavigate_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(2);
            MasterNameTxtBox.Focusable = false;
        }

        private void DBExportCommandMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(3);
            MasterNameTxtBox.Focusable = false;
        }

        private void DBExportCommandMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(3);
            MasterNameTxtBox.Focusable = false;
        }

        private void DBExportCommandMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(3);
            MasterNameTxtBox.Focusable = false;
        }

        private void DeleteSelectedItem_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(4);
            MasterNameTxtBox.Focusable = false;
        }

        private void DeleteSelectedItem_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(4);
            MasterNameTxtBox.Focusable = false;
        }

        private void DeleteSelectedItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(4);
            MasterNameTxtBox.Focusable = false;
        }

        private void MainPageMasterNavigate_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(5);
            MasterNameTxtBox.Focusable = false;
        }

        private void MainPageMasterNavigate_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(5);
            MasterNameTxtBox.Focusable = false;
        }

        private void MainPageMasterNavigate_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(5);
            MasterNameTxtBox.Focusable = false;
        }

        // Common method for processing number input
        private void ProcessNumberInput(int index)
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
                        ViewModel?.stationDBPageMasterNavigateCommand?.Execute(null);
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
                        ViewModel?.mainPageMasterNavigateCommand?.Execute(null);
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

        private void MasterNameTxtBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            MasterNameTxtBox.Focusable = false;
        }

        private void MasterNameTxtBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            MasterNameTxtBox.Focusable = false;
        }

        private void EditDataGridCommandMaster_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            EditDataGridCommandMasterBtn.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
        }

        private void EditDataGridCommandMaster_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            EditDataGridCommandMasterBtn.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
        }

        private void EditDataGridCommandMaster_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            EditDataGridCommandMasterBtn.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
        }
    }
}
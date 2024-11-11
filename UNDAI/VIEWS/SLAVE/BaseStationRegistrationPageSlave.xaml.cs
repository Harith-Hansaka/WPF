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
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.VIEWS.BASE;

namespace UNDAI.VIEWS.SLAVE
{
    /// <summary>
    /// Interaction logic for BaseStationRegistrationPageSlave.xaml
    /// </summary>
    public partial class BaseStationRegistrationPageSlave : UserControl
    {
        NumericKeyboardWindowBaseStationRegistrationSlave _numericKeyboardWindowBaseStationRegistrationSlave;
        int textBoxNo;
        string backupString;
        bool isTextboxClicked = false;
        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;
        App app;

        private BaseStationRegistrationSlaveViewModel? ViewModel => DataContext as BaseStationRegistrationSlaveViewModel;

        public BaseStationRegistrationPageSlave()
        {
            InitializeComponent();
            InitializeDebounceTimer(); // Initialize debounce logic
            app = (App)Application.Current;
            CreateAppClassAfterDelay();

            if (ViewModel != null)
            {
                _numericKeyboardWindowBaseStationRegistrationSlave = new NumericKeyboardWindowBaseStationRegistrationSlave(0, ViewModel, "");
            }
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._baseStationRegistrationSlaveViewModel;
            }
        }

        private void LatitudeMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LatitudeMasterTextBox();
        }

        private void LatitudeMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LatitudeMasterTextBox();
        }

        private void LatitudeMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LatitudeMasterTextBox();
        }

        private void LongitudeMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LongitudeMasterTextBox();
        }

        private void LongitudeMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LongitudeMasterTextBox();
        }

        private void LongitudeMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LongitudeMasterTextBox();
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

        private void MasterAntennaIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MasterAntennaIPAddressTextBox();
        }

        private void MasterAntennaIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            MasterAntennaIPAddressTextBox();
        }

        private void MasterAntennaIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            MasterAntennaIPAddressTextBox();
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

        private void SelectedMasterAntennaIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedMasterAntennaIPAddressTextBox();
        }

        private void SelectedMasterAntennaIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedMasterAntennaIPAddressTextBox();
        }

        private void SelectedMasterAntennaIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedMasterAntennaIPAddressTextBox();
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

        private void SelectedMasterNameTxtBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedMasterNameTxtBox.Focusable = true;
        }

        private void SelectedMasterNameTxtBox_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedMasterNameTxtBox.Focusable = true;
        }

        private void SelectedMasterNameTxtBox_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedMasterNameTxtBox.Focusable = true;
        }

        private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            KeypadClose();
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void UserControl_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            KeypadClose();
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void UserControl_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            KeypadClose();
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void DBExportCommandSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(5);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void DBExportCommandSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(5);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void DBExportCommandSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(5);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void DeleteSelectedItemCommandSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(4);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void DeleteSelectedItemCommandSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(4);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void DeleteSelectedItemCommandSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(4);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void MainPageSlaveNavigateCommandSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(3);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void MainPageSlaveNavigateCommandSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(3);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void MainPageSlaveNavigateCommandSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(3);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void EditDataGridCommandSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            EditDataGridCommandSlaveBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(2);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void EditDataGridCommandSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            EditDataGridCommandSlaveBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(2);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void EditDataGridCommandSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            EditDataGridCommandSlaveBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(2);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void RegistrationDataGrid_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            RegistrationDataGridBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(1);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void RegistrationDataGrid_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            RegistrationDataGridBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(1);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void RegistrationDataGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            RegistrationDataGridBtn.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(1);
            MasterNameTxtBox.Focusable = false;
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void LatitudeMasterTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 1;
                isTextboxClicked = true;
                backupString = ViewModel.LatitudeMaster;
                _numericKeyboardWindowBaseStationRegistrationSlave = new NumericKeyboardWindowBaseStationRegistrationSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowBaseStationRegistrationSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.LatitudeMaster;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.LatitudeMaster.ToString();
                };
                _numericKeyboardWindowBaseStationRegistrationSlave.Show();
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
                _numericKeyboardWindowBaseStationRegistrationSlave = new NumericKeyboardWindowBaseStationRegistrationSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowBaseStationRegistrationSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.LongitudeMaster;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.LongitudeMaster.ToString();
                };
                _numericKeyboardWindowBaseStationRegistrationSlave.Show();
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
                _numericKeyboardWindowBaseStationRegistrationSlave = new NumericKeyboardWindowBaseStationRegistrationSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowBaseStationRegistrationSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.ElevationMaster;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.ElevationMaster.ToString();
                };
                _numericKeyboardWindowBaseStationRegistrationSlave.Show();
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
                _numericKeyboardWindowBaseStationRegistrationSlave = new NumericKeyboardWindowBaseStationRegistrationSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowBaseStationRegistrationSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.PoleHeight;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.PoleHeight.ToString();
                };
                _numericKeyboardWindowBaseStationRegistrationSlave.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void MasterAntennaIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 5;
                isTextboxClicked = true;
                backupString = ViewModel.MasterAntennaIPAddress;
                _numericKeyboardWindowBaseStationRegistrationSlave = new NumericKeyboardWindowBaseStationRegistrationSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowBaseStationRegistrationSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.MasterAntennaIPAddress;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.MasterAntennaIPAddress.Length > 0)
                        {
                            ViewModel.MasterAntennaIPAddress = ViewModel.MasterAntennaIPAddress.Substring(0, ViewModel.MasterAntennaIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.MasterAntennaIPAddress = ViewModel.MasterAntennaIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.MasterAntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.MasterAntennaIPAddress[0] == '-')
                            {
                                ViewModel.MasterAntennaIPAddress = ViewModel.MasterAntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.MasterAntennaIPAddress = '-' + ViewModel.MasterAntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.MasterAntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.MasterAntennaIPAddress.Length == 0)
                        {
                            ViewModel.MasterAntennaIPAddress = "0.";
                        }
                        else if (ViewModel.MasterAntennaIPAddress.Length == 1 && ViewModel.MasterAntennaIPAddress[0] == '-')
                        {
                            ViewModel.MasterAntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.MasterAntennaIPAddress = ViewModel.MasterAntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.MasterAntennaIPAddress.Length == 1 && ViewModel.MasterAntennaIPAddress[0] == '0')
                        {
                            ViewModel.MasterAntennaIPAddress = "";
                        }
                        ViewModel.MasterAntennaIPAddress += key;
                    };
                    _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.MasterAntennaIPAddress.ToString();
                };
                _numericKeyboardWindowBaseStationRegistrationSlave.Show();
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
                _numericKeyboardWindowBaseStationRegistrationSlave = new NumericKeyboardWindowBaseStationRegistrationSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowBaseStationRegistrationSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.SelectedLatitudeMaster;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.SelectedLatitudeMaster.ToString();
                };
                _numericKeyboardWindowBaseStationRegistrationSlave.Show();
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
                _numericKeyboardWindowBaseStationRegistrationSlave = new NumericKeyboardWindowBaseStationRegistrationSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowBaseStationRegistrationSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.SelectedLongitudeMaster;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.SelectedLongitudeMaster.ToString();
                };
                _numericKeyboardWindowBaseStationRegistrationSlave.Show();
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
                _numericKeyboardWindowBaseStationRegistrationSlave = new NumericKeyboardWindowBaseStationRegistrationSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowBaseStationRegistrationSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.SelectedElevationMaster;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.SelectedElevationMaster.ToString();
                };
                _numericKeyboardWindowBaseStationRegistrationSlave.Show();
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
                _numericKeyboardWindowBaseStationRegistrationSlave = new NumericKeyboardWindowBaseStationRegistrationSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowBaseStationRegistrationSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.SelectedPoleHeight;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.SelectedPoleHeight.ToString();
                };
                _numericKeyboardWindowBaseStationRegistrationSlave.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedMasterAntennaIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 12;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedMasterAntennaIPAddress;
                _numericKeyboardWindowBaseStationRegistrationSlave = new NumericKeyboardWindowBaseStationRegistrationSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowBaseStationRegistrationSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.SelectedMasterAntennaIPAddress;
                _numericKeyboardWindowBaseStationRegistrationSlave.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedMasterAntennaIPAddress.Length > 0)
                        {
                            ViewModel.SelectedMasterAntennaIPAddress = ViewModel.SelectedMasterAntennaIPAddress.Substring(0, ViewModel.SelectedMasterAntennaIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedMasterAntennaIPAddress = ViewModel.SelectedMasterAntennaIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedMasterAntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.SelectedMasterAntennaIPAddress[0] == '-')
                            {
                                ViewModel.SelectedMasterAntennaIPAddress = ViewModel.SelectedMasterAntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedMasterAntennaIPAddress = '-' + ViewModel.SelectedMasterAntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedMasterAntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedMasterAntennaIPAddress.Length == 0)
                        {
                            ViewModel.SelectedMasterAntennaIPAddress = "0.";
                        }
                        else if (ViewModel.SelectedMasterAntennaIPAddress.Length == 1 && ViewModel.SelectedMasterAntennaIPAddress[0] == '-')
                        {
                            ViewModel.SelectedMasterAntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedMasterAntennaIPAddress = ViewModel.SelectedMasterAntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedMasterAntennaIPAddress.Length == 1 && ViewModel.SelectedMasterAntennaIPAddress[0] == '0')
                        {
                            ViewModel.SelectedMasterAntennaIPAddress = "";
                        }
                        ViewModel.SelectedMasterAntennaIPAddress += key;
                    };
                    _numericKeyboardWindowBaseStationRegistrationSlave.KeyPad.Text = ViewModel.SelectedMasterAntennaIPAddress.ToString();
                };
                _numericKeyboardWindowBaseStationRegistrationSlave.Show();
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
                _numericKeyboardWindowBaseStationRegistrationSlave.Close();
                Keyboard.ClearFocus();
                if (textBoxNo == 1 && _numericKeyboardWindowBaseStationRegistrationSlave._status != 1)
                {
                    ViewModel.LatitudeMaster = backupString;

                }
                else if (textBoxNo == 2 && _numericKeyboardWindowBaseStationRegistrationSlave._status != 1)
                {
                    ViewModel.LongitudeMaster = backupString;
                }
                else if (textBoxNo == 3 && _numericKeyboardWindowBaseStationRegistrationSlave._status != 1)
                {
                    ViewModel.ElevationMaster = backupString;
                }
                else if (textBoxNo == 4 && _numericKeyboardWindowBaseStationRegistrationSlave._status != 1)
                {
                    ViewModel.PoleHeight = backupString;
                }
                else if (textBoxNo == 5 && _numericKeyboardWindowBaseStationRegistrationSlave._status != 1)
                {
                    ViewModel.MasterAntennaIPAddress = backupString;
                }
                else if (textBoxNo == 8 && _numericKeyboardWindowBaseStationRegistrationSlave._status != 1)
                {
                    ViewModel.SelectedLatitudeMaster = backupString;
                }
                else if (textBoxNo == 9 && _numericKeyboardWindowBaseStationRegistrationSlave._status != 1)
                {
                    ViewModel.SelectedLongitudeMaster = backupString;
                }
                else if (textBoxNo == 10 && _numericKeyboardWindowBaseStationRegistrationSlave._status != 1)
                {
                    ViewModel.SelectedElevationMaster = backupString;
                }
                else if (textBoxNo == 11 && _numericKeyboardWindowBaseStationRegistrationSlave._status != 1)
                {
                    ViewModel.SelectedPoleHeight = backupString;
                }
                else if (textBoxNo == 12 && _numericKeyboardWindowBaseStationRegistrationSlave._status != 1)
                {
                    ViewModel.SelectedMasterAntennaIPAddress = backupString;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void MasterNameTxtBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            MasterNameTxtBox.Focusable = false;
        }

        private void MasterNameTxtBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            MasterNameTxtBox.Focusable = false;
        }

        private void SelectedMasterNameTxtBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelectedMasterNameTxtBox.Focusable = false;
        }

        private void SelectedMasterNameTxtBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelectedMasterNameTxtBox.Focusable = false;
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

        // Common method for processing number input
        private void ProcessNumberInput(int index)
        {
            switch (index)
            {
                case 1:
                    if (canProcessInput)
                    {
                        ViewModel?.RegistrationDataGridCommand?.Execute(null);
                        canProcessInput = false; // Prevent further input until debounce resets
                        debounceTimer.Start(); // Start debounce timer
                    }
                    break;

                case 2:
                    if (canProcessInput)
                    {
                        ViewModel?.EditDataGridCommand?.Execute(null);
                        canProcessInput = false; // Prevent further input until debounce resets
                        debounceTimer.Start(); // Start debounce timer
                    }
                    break;

                case 3:
                    if (canProcessInput)
                    {
                        ViewModel?.MainPageSlaveNavigateCommand?.Execute(null);
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
                        ViewModel?.DBExportCommand?.Execute(null);
                        canProcessInput = false; // Prevent further input until debounce resets
                        debounceTimer.Start(); // Start debounce timer
                    }
                    break;
            }
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

        private void RegistrationDataGrid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationDataGridBtn.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
        }

        private void RegistrationDataGrid_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            RegistrationDataGridBtn.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
        }

        private void RegistrationDataGrid_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            RegistrationDataGridBtn.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
        }
    }
}

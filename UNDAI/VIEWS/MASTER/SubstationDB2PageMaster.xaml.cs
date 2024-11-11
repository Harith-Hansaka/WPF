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
    /// Interaction logic for SubstationDB2PageMaster.xaml
    /// </summary>
    public partial class SubstationDB2PageMaster : UserControl
    {
        NumericKeyboardWindowSubstationDB2 _numericKeyboardWindowSubstationDB2;
        int textBoxNo;
        string backupString;
        bool isTextboxClicked = false;
        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;
        App app;

        private SubstationDB2MasterViewModel? ViewModel => DataContext as SubstationDB2MasterViewModel;

        public SubstationDB2PageMaster()
        {
            InitializeComponent();
            InitializeDebounceTimer(); // Initialize debounce logic
            app = (App)Application.Current;
            CreateAppClassAfterDelay();

            if (ViewModel != null)
            {
                _numericKeyboardWindowSubstationDB2 = new NumericKeyboardWindowSubstationDB2(0, ViewModel, "");
            }
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._stationDB2MasterViewModel;
            }
        }

        // Event Handlers for Slave 2

        private void LatitudeSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LatitudeSlave2TextBox();
        }

        private void LatitudeSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LatitudeSlave2TextBox();
        }

        private void LatitudeSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LatitudeSlave2TextBox();
        }

        private void LongitudeSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LongitudeSlave2TextBox();
        }

        private void LongitudeSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LongitudeSlave2TextBox();
        }

        private void LongitudeSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LongitudeSlave2TextBox();
        }

        private void ElevationSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlave2TextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlave2TextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlave2TextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleHeightSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PoleHeightSlave2TextBox();
        }

        private void PoleHeightSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PoleHeightSlave2TextBox();
        }

        private void PoleHeightSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PoleHeightSlave2TextBox();
        }

        private void Slave2AntennaIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Slave2AntennaIPAddressTextBox();
        }

        private void Slave2AntennaIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            Slave2AntennaIPAddressTextBox();
        }

        private void Slave2AntennaIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            Slave2AntennaIPAddressTextBox();
        }

        private void SelectedLatitudeSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedLatitudeSlave2TextBox();
        }

        private void SelectedLatitudeSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedLatitudeSlave2TextBox();
        }

        private void SelectedLatitudeSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedLatitudeSlave2TextBox();
        }

        private void SelectedPoleHeightSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedPoleHeightSlave2TextBox();
        }

        private void SelectedPoleHeightSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedPoleHeightSlave2TextBox();
        }

        private void SelectedPoleHeightSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedPoleHeightSlave2TextBox();
        }

        private void SelectedSlave2AntennaIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedSlave2AntennaIPAddressTextBox();
        }

        private void SelectedSlave2AntennaIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedSlave2AntennaIPAddressTextBox();
        }

        private void SelectedSlave2AntennaIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedSlave2AntennaIPAddressTextBox();
        }

        private void SelectedLongitudeSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedLongitudeSlave2TextBox();
        }

        private void SelectedLongitudeSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedLongitudeSlave2TextBox();
        }

        private void SelectedLongitudeSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedLongitudeSlave2TextBox();
        }

        private void SelectedElevationSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedElevationSlave2TextBox();
        }

        private void SelectedElevationSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedElevationSlave2TextBox();
        }

        private void SelectedElevationSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedElevationSlave2TextBox();
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

        private void SelectedSlaveNameTxtBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedSlaveNameTxtBox.Focusable = true;
        }

        private void SelectedSlaveNameTxtBox_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedSlaveNameTxtBox.Focusable = true;
        }

        private void SelectedSlaveNameTxtBox_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedSlaveNameTxtBox.Focusable = true;
        }

        private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            KeypadClose();
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void UserControl_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            KeypadClose();
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void UserControl_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            KeypadClose();
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void LatitudeSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 1;
            isTextboxClicked = true;
            backupString = ViewModel.LatitudeSlave2;
            _numericKeyboardWindowSubstationDB2 = new NumericKeyboardWindowSubstationDB2(textBoxNo, ViewModel, backupString);
            _numericKeyboardWindowSubstationDB2.Owner = Application.Current.MainWindow;
            _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.LatitudeSlave2;
            _numericKeyboardWindowSubstationDB2.KeyPressed += (s, key) =>
            {
                if (key == "Backspace")
                {
                    if (ViewModel.LatitudeSlave2.Length > 0)
                    {
                        ViewModel.LatitudeSlave2 = ViewModel.LatitudeSlave2.Substring(0, ViewModel.LatitudeSlave2.Length - 1);
                    }
                }
                else if (key == "+/-")
                {
                    if (ViewModel.LatitudeSlave2.Length > 0)
                    {
                        if (ViewModel.LatitudeSlave2[0] == '-')
                        {
                            ViewModel.LatitudeSlave2 = ViewModel.LatitudeSlave2.Substring(1);
                        }
                        else
                        {
                            ViewModel.LatitudeSlave2 = '-' + ViewModel.LatitudeSlave2;
                        }
                    }
                    else
                    {
                        ViewModel.LatitudeSlave2 = "-";
                    }
                }
                else if (key == ".")
                {
                    if (ViewModel.LatitudeSlave2.Length == 0)
                    {
                        ViewModel.LatitudeSlave2 = "0.";
                    }
                    else if (ViewModel.LatitudeSlave2.Contains("."))
                    {
                        ViewModel.LatitudeSlave2 = ViewModel.LatitudeSlave2;
                    }
                    else if (ViewModel.LatitudeSlave2.Length == 1 && ViewModel.LatitudeSlave2[0] == '-')
                    {
                        ViewModel.LatitudeSlave2 = "-0.";
                    }
                    else
                    {
                        ViewModel.LatitudeSlave2 = ViewModel.LatitudeSlave2 + ".";
                    }
                }
                else
                {
                    if (ViewModel.LatitudeSlave2.Length == 1 && ViewModel.LatitudeSlave2[0] == '0')
                    {
                        ViewModel.LatitudeSlave2 = "";
                    }
                    ViewModel.LatitudeSlave2 += key;
                };
                _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.LatitudeSlave2.ToString();
            };
            _numericKeyboardWindowSubstationDB2.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 2;
                isTextboxClicked = true;
                backupString = ViewModel.LongitudeSlave2;
                _numericKeyboardWindowSubstationDB2 = new NumericKeyboardWindowSubstationDB2(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB2.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.LongitudeSlave2;
                _numericKeyboardWindowSubstationDB2.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LongitudeSlave2.Length > 0)
                        {
                            ViewModel.LongitudeSlave2 = ViewModel.LongitudeSlave2.Substring(0, ViewModel.LongitudeSlave2.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LongitudeSlave2.Length > 0)
                        {
                            if (ViewModel.LongitudeSlave2[0] == '-')
                            {
                                ViewModel.LongitudeSlave2 = ViewModel.LongitudeSlave2.Substring(1);
                            }
                            else
                            {
                                ViewModel.LongitudeSlave2 = '-' + ViewModel.LongitudeSlave2;
                            }
                        }
                        else
                        {
                            ViewModel.LongitudeSlave2 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LongitudeSlave2.Length == 0)
                        {
                            ViewModel.LongitudeSlave2 = "0.";
                        }
                        else if (ViewModel.LongitudeSlave2.Contains("."))
                        {
                            ViewModel.LongitudeSlave2 = ViewModel.LongitudeSlave2;
                        }
                        else if (ViewModel.LongitudeSlave2.Length == 1 && ViewModel.LongitudeSlave2[0] == '-')
                        {
                            ViewModel.LongitudeSlave2 = "-0.";
                        }
                        else
                        {
                            ViewModel.LongitudeSlave2 = ViewModel.LongitudeSlave2 + ".";
                        }
                }
                else
                {
                    if (ViewModel.LongitudeSlave2.Length == 1 && ViewModel.LongitudeSlave2[0] == '0')
                    {
                        ViewModel.LongitudeSlave2 = "";
                    }
                    ViewModel.LongitudeSlave2 += key;
                };
                _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.LongitudeSlave2.ToString();
            };
            _numericKeyboardWindowSubstationDB2.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 3;
                isTextboxClicked = true;
                backupString = ViewModel.ElevationSlave2;
                _numericKeyboardWindowSubstationDB2 = new NumericKeyboardWindowSubstationDB2(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB2.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.ElevationSlave2;
                _numericKeyboardWindowSubstationDB2.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationSlave2.Length > 0)
                        {
                            ViewModel.ElevationSlave2 = ViewModel.ElevationSlave2.Substring(0, ViewModel.ElevationSlave2.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.ElevationSlave2.Length > 0)
                        {
                            if (ViewModel.ElevationSlave2[0] == '-')
                            {
                                ViewModel.ElevationSlave2 = ViewModel.ElevationSlave2.Substring(1);
                            }
                            else
                            {
                                ViewModel.ElevationSlave2 = '-' + ViewModel.ElevationSlave2;
                            }
                        }
                        else
                        {
                            ViewModel.ElevationSlave2 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.ElevationSlave2.Length == 0)
                        {
                            ViewModel.ElevationSlave2 = "0.";
                        }
                        else if (ViewModel.ElevationSlave2.Contains("."))
                        {
                            ViewModel.ElevationSlave2 = ViewModel.ElevationSlave2;
                        }
                        else if (ViewModel.ElevationSlave2.Length == 1 && ViewModel.ElevationSlave2[0] == '-')
                        {
                            ViewModel.ElevationSlave2 = "-0.";
                        }
                        else
                        {
                            ViewModel.ElevationSlave2 = ViewModel.ElevationSlave2 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.ElevationSlave2.Length == 1 && ViewModel.ElevationSlave2[0] == '0')
                        {
                            ViewModel.ElevationSlave2 = "";
                        }
                        ViewModel.ElevationSlave2 += key;
                    };
                    _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.ElevationSlave2.ToString();
                };
                _numericKeyboardWindowSubstationDB2.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleHeightSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 4;
                isTextboxClicked = true;
                backupString = ViewModel.PoleHeight;
                _numericKeyboardWindowSubstationDB2 = new NumericKeyboardWindowSubstationDB2(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB2.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.PoleHeight;
                _numericKeyboardWindowSubstationDB2.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.PoleHeight.Length > 0)
                        {
                            ViewModel.PoleHeight = ViewModel.PoleHeight.Substring(0, ViewModel.PoleHeight.Length - 1);
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
                    _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.PoleHeight.ToString();
                };
                _numericKeyboardWindowSubstationDB2.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void Slave2AntennaIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 5;
                isTextboxClicked = true;
                backupString = ViewModel.Slave2AntennaIPAddress;
                _numericKeyboardWindowSubstationDB2 = new NumericKeyboardWindowSubstationDB2(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB2.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.Slave2AntennaIPAddress;
                _numericKeyboardWindowSubstationDB2.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.Slave2AntennaIPAddress.Length > 0)
                        {
                            ViewModel.Slave2AntennaIPAddress = ViewModel.Slave2AntennaIPAddress.Substring(0, ViewModel.Slave2AntennaIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.Slave2AntennaIPAddress = ViewModel.Slave2AntennaIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.Slave2AntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.Slave2AntennaIPAddress[0] == '-')
                            {
                                ViewModel.Slave2AntennaIPAddress = ViewModel.Slave2AntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.Slave2AntennaIPAddress = '-' + ViewModel.Slave2AntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.Slave2AntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.Slave2AntennaIPAddress.Length == 0)
                        {
                            ViewModel.Slave2AntennaIPAddress = "0.";
                        }
                        else if (ViewModel.Slave2AntennaIPAddress.Length == 1 && ViewModel.Slave2AntennaIPAddress[0] == '-')
                        {
                            ViewModel.Slave2AntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.Slave2AntennaIPAddress = ViewModel.Slave2AntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.Slave2AntennaIPAddress.Length == 1 && ViewModel.Slave2AntennaIPAddress[0] == '0')
                        {
                            ViewModel.Slave2AntennaIPAddress = "";
                        }
                        ViewModel.Slave2AntennaIPAddress += key;
                    }
                    _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.Slave2AntennaIPAddress.ToString();
            };
            _numericKeyboardWindowSubstationDB2.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedLatitudeSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 8;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedLatitudeSlave2;
                _numericKeyboardWindowSubstationDB2 = new NumericKeyboardWindowSubstationDB2(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB2.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.SelectedLatitudeSlave2;
                _numericKeyboardWindowSubstationDB2.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedLatitudeSlave2.Length > 0)
                        {
                            ViewModel.SelectedLatitudeSlave2 = ViewModel.SelectedLatitudeSlave2.Substring(0, ViewModel.SelectedLatitudeSlave2.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave2 = ViewModel.SelectedLatitudeSlave2;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedLatitudeSlave2.Length > 0)
                        {
                            if (ViewModel.SelectedLatitudeSlave2[0] == '-')
                            {
                                ViewModel.SelectedLatitudeSlave2 = ViewModel.SelectedLatitudeSlave2.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedLatitudeSlave2 = '-' + ViewModel.SelectedLatitudeSlave2;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave2 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedLatitudeSlave2.Length == 0)
                        {
                            ViewModel.SelectedLatitudeSlave2 = "0.";
                        }
                        else if (ViewModel.SelectedLatitudeSlave2.Contains("."))
                        {
                            ViewModel.SelectedLatitudeSlave2 = ViewModel.SelectedLatitudeSlave2;
                        }
                        else if (ViewModel.SelectedLatitudeSlave2.Length == 1 && ViewModel.SelectedLatitudeSlave2[0] == '-')
                        {
                            ViewModel.SelectedLatitudeSlave2 = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave2 = ViewModel.SelectedLatitudeSlave2 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedLatitudeSlave2.Length == 1 && ViewModel.SelectedLatitudeSlave2[0] == '0')
                        {
                            ViewModel.SelectedLatitudeSlave2 = "";
                        }
                        ViewModel.SelectedLatitudeSlave2 += key;
                    }
                    _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.SelectedLatitudeSlave2.ToString();
            };
            _numericKeyboardWindowSubstationDB2.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedLongitudeSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 9;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedLongitudeSlave2;
                _numericKeyboardWindowSubstationDB2 = new NumericKeyboardWindowSubstationDB2(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB2.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.SelectedLongitudeSlave2;
                _numericKeyboardWindowSubstationDB2.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedLongitudeSlave2.Length > 0)
                        {
                            ViewModel.SelectedLongitudeSlave2 = ViewModel.SelectedLongitudeSlave2.Substring(0, ViewModel.SelectedLongitudeSlave2.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedLongitudeSlave2.Length > 0)
                        {
                            if (ViewModel.SelectedLongitudeSlave2[0] == '-')
                            {
                                ViewModel.SelectedLongitudeSlave2 = ViewModel.SelectedLongitudeSlave2.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedLongitudeSlave2 = '-' + ViewModel.SelectedLongitudeSlave2;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeSlave2 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedLongitudeSlave2.Length == 0)
                        {
                            ViewModel.SelectedLongitudeSlave2 = "0.";
                        }
                        else if (ViewModel.SelectedLongitudeSlave2.Contains("."))
                        {
                            ViewModel.SelectedLongitudeSlave2 = ViewModel.SelectedLongitudeSlave2;
                        }
                        else if (ViewModel.SelectedLongitudeSlave2.Length == 1 && ViewModel.SelectedLongitudeSlave2[0] == '-')
                        {
                            ViewModel.SelectedLongitudeSlave2 = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeSlave2 = ViewModel.SelectedLongitudeSlave2 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedLongitudeSlave2.Length == 1 && ViewModel.SelectedLongitudeSlave2[0] == '0')
                        {
                            ViewModel.SelectedLongitudeSlave2 = "";
                        }
                        ViewModel.SelectedLongitudeSlave2 += key;
                    }
                    _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.SelectedLongitudeSlave2.ToString();
            };
            _numericKeyboardWindowSubstationDB2.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedElevationSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 10;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedElevationSlave2;
                _numericKeyboardWindowSubstationDB2 = new NumericKeyboardWindowSubstationDB2(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB2.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.SelectedElevationSlave2;
                _numericKeyboardWindowSubstationDB2.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedElevationSlave2.Length > 0)
                        {
                            ViewModel.SelectedElevationSlave2 = ViewModel.SelectedElevationSlave2.Substring(0, ViewModel.SelectedElevationSlave2.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedElevationSlave2.Length > 0)
                        {
                            if (ViewModel.SelectedElevationSlave2[0] == '-')
                            {
                                ViewModel.SelectedElevationSlave2 = ViewModel.SelectedElevationSlave2.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedElevationSlave2 = '-' + ViewModel.SelectedElevationSlave2;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedElevationSlave2 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedElevationSlave2.Length == 0)
                        {
                            ViewModel.SelectedElevationSlave2 = "0.";
                        }
                        else if (ViewModel.SelectedElevationSlave2.Contains("."))
                        {
                            ViewModel.SelectedElevationSlave2 = ViewModel.SelectedElevationSlave2;
                        }
                        else if (ViewModel.SelectedElevationSlave2.Length == 1 && ViewModel.SelectedElevationSlave2[0] == '-')
                        {
                            ViewModel.SelectedElevationSlave2 = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedElevationSlave2 = ViewModel.SelectedElevationSlave2 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedElevationSlave2.Length == 1 && ViewModel.SelectedElevationSlave2[0] == '0')
                        {
                            ViewModel.SelectedElevationSlave2 = "";
                        }
                        ViewModel.SelectedElevationSlave2 += key;
                    }
                    _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.SelectedElevationSlave2.ToString();
                };
            _numericKeyboardWindowSubstationDB2.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedPoleHeightSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 11;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedPoleHeight;
                _numericKeyboardWindowSubstationDB2 = new NumericKeyboardWindowSubstationDB2(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB2.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.SelectedPoleHeight;
                _numericKeyboardWindowSubstationDB2.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedPoleHeight.Length > 0)
                        {
                            ViewModel.SelectedPoleHeight = ViewModel.SelectedPoleHeight.Substring(0, ViewModel.SelectedPoleHeight.Length - 1);
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
                    }
                    _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.SelectedPoleHeight.ToString();
                };
                _numericKeyboardWindowSubstationDB2.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedSlave2AntennaIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 12;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedSlave2AntennaIPAddress;
                _numericKeyboardWindowSubstationDB2 = new NumericKeyboardWindowSubstationDB2(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB2.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.SelectedSlave2AntennaIPAddress;
                _numericKeyboardWindowSubstationDB2.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedSlave2AntennaIPAddress.Length > 0)
                        {
                            ViewModel.SelectedSlave2AntennaIPAddress = ViewModel.SelectedSlave2AntennaIPAddress.Substring(0, ViewModel.SelectedSlave2AntennaIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedSlave2AntennaIPAddress = ViewModel.SelectedSlave2AntennaIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedSlave2AntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.SelectedSlave2AntennaIPAddress[0] == '-')
                            {
                                ViewModel.SelectedSlave2AntennaIPAddress = ViewModel.SelectedSlave2AntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedSlave2AntennaIPAddress = '-' + ViewModel.SelectedSlave2AntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedSlave2AntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedSlave2AntennaIPAddress.Length == 0)
                        {
                            ViewModel.SelectedSlave2AntennaIPAddress = "0.";
                        }
                        else if (ViewModel.SelectedSlave2AntennaIPAddress.Length == 1 && ViewModel.SelectedSlave2AntennaIPAddress[0] == '-')
                        {
                            ViewModel.SelectedSlave2AntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedSlave2AntennaIPAddress = ViewModel.SelectedSlave2AntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedSlave2AntennaIPAddress.Length == 1 && ViewModel.SelectedSlave2AntennaIPAddress[0] == '0')
                        {
                            ViewModel.SelectedSlave2AntennaIPAddress = "";
                        }
                        ViewModel.SelectedSlave2AntennaIPAddress += key;
                    }
                    _numericKeyboardWindowSubstationDB2.KeyPad.Text = ViewModel.SelectedSlave2AntennaIPAddress.ToString();
            };
            _numericKeyboardWindowSubstationDB2.Show();
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
                _numericKeyboardWindowSubstationDB2.Close();
            Keyboard.ClearFocus();
            if (textBoxNo == 1 && _numericKeyboardWindowSubstationDB2._status != 1)
            {
                ViewModel.LatitudeSlave2 = backupString;

            }
            else if (textBoxNo == 2 && _numericKeyboardWindowSubstationDB2._status != 1)
            {
                ViewModel.LongitudeSlave2 = backupString;
            }
            else if (textBoxNo == 3 && _numericKeyboardWindowSubstationDB2._status != 1)
            {
                ViewModel.ElevationSlave2 = backupString;
            }
            else if (textBoxNo == 4 && _numericKeyboardWindowSubstationDB2._status != 1)
            {
                ViewModel.PoleHeight = backupString;
            }
            else if (textBoxNo == 5 && _numericKeyboardWindowSubstationDB2._status != 1)
            {
                ViewModel.Slave2AntennaIPAddress = backupString;
            }
            else if (textBoxNo == 8 && _numericKeyboardWindowSubstationDB2._status != 1)
            {
                ViewModel.SelectedLatitudeSlave2 = backupString;
            }
            else if (textBoxNo == 9 && _numericKeyboardWindowSubstationDB2._status != 1)
            {
                ViewModel.SelectedLongitudeSlave2 = backupString;
            }
            else if (textBoxNo == 10 && _numericKeyboardWindowSubstationDB2._status != 1)
            {
                ViewModel.SelectedElevationSlave2 = backupString;
            }
            else if (textBoxNo == 11 && _numericKeyboardWindowSubstationDB2._status != 1)
            {
                ViewModel.SelectedPoleHeight = backupString;
            }
            else if (textBoxNo == 12 && _numericKeyboardWindowSubstationDB2._status != 1)
            {
                ViewModel.SelectedSlave2AntennaIPAddress = backupString;
            }
            textBoxNo = 0;
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void RegistrationDataGridCommandMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(1);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void RegistrationDataGridCommandMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(1);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void RegistrationDataGridCommandMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(1);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void EditDataGridCommandMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(2);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void EditDataGridCommandMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(2);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void EditDataGridCommandMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(2);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void MainPageMasterNavigateCommandMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(3);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void MainPageMasterNavigateCommandMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(3);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void MainPageMasterNavigateCommandMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(3);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void DeleteSelectedItemCommandMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(4);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void DeleteSelectedItemCommandMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(4);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void DeleteSelectedItemCommandMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(4);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void DBExportCommandMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(5);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void DBExportCommandMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(5);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void DBExportCommandMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(5);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void SubstationRegistrationMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(6);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void SubstationRegistrationMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(6);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void SubstationRegistrationMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(6);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
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
                        ViewModel?.MainPageMasterNavigateCommand?.Execute(null);
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

                case 6:
                    if (canProcessInput)
                    {
                        ViewModel?.SubstationRegistrationMasterNavigateCommand?.Execute(null);
                        canProcessInput = false; // Prevent further input until debounce resets
                        debounceTimer.Start(); // Start debounce timer
                    }
                    break;
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

        private void SelectedSlaveNameTxtBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void SelectedSlaveNameTxtBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelectedSlaveNameTxtBox.Focusable = false;
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
    }
}
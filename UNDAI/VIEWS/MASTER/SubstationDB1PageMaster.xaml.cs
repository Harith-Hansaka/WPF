using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for SubstationDB1PageMaster.xaml
    /// </summary>
    public partial class SubstationDB1PageMaster : UserControl
    {
        NumericKeyboardWindowSubstationDB1 _numericKeyboardWindowSubstationDB1;
        int textBoxNo;
        string backupString;
        bool isTextboxClicked = false;
        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;
        App app;

        private SubstationDB1MasterViewModel? ViewModel => DataContext as SubstationDB1MasterViewModel;

        public SubstationDB1PageMaster()
        {
            InitializeComponent();
            InitializeDebounceTimer(); // Initialize debounce logic
            app = (App)Application.Current;
            CreateAppClassAfterDelay();

            if (ViewModel != null)
            {
                _numericKeyboardWindowSubstationDB1 = new NumericKeyboardWindowSubstationDB1(0, ViewModel, "");
            }
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._stationDB1MasterViewModel;
            }
        }

        private void LatitudeSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LatitudeSlave1TextBox();
        }

        private void LatitudeSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LatitudeSlave1TextBox();
        }

        private void LatitudeSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LatitudeSlave1TextBox();
        }

        private void LongitudeSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LongitudeSlave1TextBox();
        }

        private void LongitudeSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LongitudeSlave1TextBox();
        }

        private void LongitudeSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LongitudeSlave1TextBox();
        }

        private void ElevationSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlave1TextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlave1TextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
            {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlave1TextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleHeightSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PoleHeightSlave1TextBox();
        }

        private void PoleHeightSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PoleHeightSlave1TextBox();
        }

        private void PoleHeightSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PoleHeightSlave1TextBox();
        }

        private void Slave1AntennaIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Slave1AntennaIPAddressTextBox();
        }

        private void Slave1AntennaIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            Slave1AntennaIPAddressTextBox();
        }

        private void Slave1AntennaIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            Slave1AntennaIPAddressTextBox();
        }

        private void SelectedLatitudeSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedLatitudeSlave1TextBox();
        }

        private void SelectedLatitudeSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedLatitudeSlave1TextBox();
        }

        private void SelectedLatitudeSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedLatitudeSlave1TextBox();
        }

        private void SelectedPoleHeightSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedPoleHeightSlave1TextBox();
        }

        private void SelectedPoleHeightSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedPoleHeightSlave1TextBox();
        }

        private void SelectedPoleHeightSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedPoleHeightSlave1TextBox();
        }

        private void SelectedSlave1AntennaIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedSlave1AntennaIPAddressTextBox();
        }

        private void SelectedSlave1AntennaIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedSlave1AntennaIPAddressTextBox();
        }

        private void SelectedSlave1AntennaIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedSlave1AntennaIPAddressTextBox();
        }

        private void SelectedLongitudeSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedLongitudeSlave1TextBox();
        }

        private void SelectedLongitudeSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedLongitudeSlave1TextBox();
        }

        private void SelectedLongitudeSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedLongitudeSlave1TextBox();
        }

        private void SelectedElevationSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedElevationSlave1TextBox();
        }

        private void SelectedElevationSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedElevationSlave1TextBox();
        }

        private void SelectedElevationSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedElevationSlave1TextBox();
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

        private void LatitudeSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 1;
                isTextboxClicked = true;
                backupString = ViewModel.LatitudeSlave1;
                _numericKeyboardWindowSubstationDB1 = new NumericKeyboardWindowSubstationDB1(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB1.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.LatitudeSlave1;
                _numericKeyboardWindowSubstationDB1.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LatitudeSlave1.Length > 0)
                        {
                            ViewModel.LatitudeSlave1 = ViewModel.LatitudeSlave1.Substring(0, ViewModel.LatitudeSlave1.Length - 1);
                        }
                        else
                        {
                            ViewModel.LatitudeSlave1 = ViewModel.LatitudeSlave1;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LatitudeSlave1.Length > 0)
                        {
                            if (ViewModel.LatitudeSlave1[0] == '-')
                            {
                                ViewModel.LatitudeSlave1 = ViewModel.LatitudeSlave1.Substring(1);
                            }
                            else
                            {
                                ViewModel.LatitudeSlave1 = '-' + ViewModel.LatitudeSlave1;
                            }
                        }
                        else
                        {
                            ViewModel.LatitudeSlave1 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LatitudeSlave1.Length == 0)
                        {
                            ViewModel.LatitudeSlave1 = "0.";
                        }
                        else if (ViewModel.LatitudeSlave1.Contains("."))
                        {
                            ViewModel.LatitudeSlave1 = ViewModel.LatitudeSlave1;
                        }
                        else if (ViewModel.LatitudeSlave1.Length == 1 && ViewModel.LatitudeSlave1[0] == '-')
                        {
                            ViewModel.LatitudeSlave1 = "-0.";
                        }
                        else
                        {
                            ViewModel.LatitudeSlave1 = ViewModel.LatitudeSlave1 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LatitudeSlave1.Length == 1 && ViewModel.LatitudeSlave1[0] == '0')
                        {
                            ViewModel.LatitudeSlave1 = "";
                        }
                        ViewModel.LatitudeSlave1 += key;
                    };
                    _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.LatitudeSlave1.ToString();
                };
                _numericKeyboardWindowSubstationDB1.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 2;
                isTextboxClicked = true;
                backupString = ViewModel.LongitudeSlave1;
                _numericKeyboardWindowSubstationDB1 = new NumericKeyboardWindowSubstationDB1(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB1.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.LongitudeSlave1;
                _numericKeyboardWindowSubstationDB1.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LongitudeSlave1.Length > 0)
                        {
                            ViewModel.LongitudeSlave1 = ViewModel.LongitudeSlave1.Substring(0, ViewModel.LongitudeSlave1.Length - 1);
                        }
                        else
                        {
                            ViewModel.LongitudeSlave1 = ViewModel.LongitudeSlave1;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LongitudeSlave1.Length > 0)
                        {
                            if (ViewModel.LongitudeSlave1[0] == '-')
                            {
                                ViewModel.LongitudeSlave1 = ViewModel.LongitudeSlave1.Substring(1);
                            }
                            else
                            {
                                ViewModel.LongitudeSlave1 = '-' + ViewModel.LongitudeSlave1;
                            }
                        }
                        else
                        {
                            ViewModel.LongitudeSlave1 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LongitudeSlave1.Length == 0)
                        {
                            ViewModel.LongitudeSlave1 = "0.";
                        }
                        else if (ViewModel.LongitudeSlave1.Contains("."))
                        {
                            ViewModel.LongitudeSlave1 = ViewModel.LongitudeSlave1;
                        }
                        else if (ViewModel.LongitudeSlave1.Length == 1 && ViewModel.LongitudeSlave1[0] == '-')
                        {
                            ViewModel.LongitudeSlave1 = "-0.";
                        }
                        else
                        {
                            ViewModel.LongitudeSlave1 = ViewModel.LongitudeSlave1 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LongitudeSlave1.Length == 1 && ViewModel.LongitudeSlave1[0] == '0')
                        {
                            ViewModel.LongitudeSlave1 = "";
                        }
                        ViewModel.LongitudeSlave1 += key;
                    };
                    _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.LongitudeSlave1.ToString();
                };
                _numericKeyboardWindowSubstationDB1.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 3;
                isTextboxClicked = true;
                backupString = ViewModel.ElevationSlave1;
                _numericKeyboardWindowSubstationDB1 = new NumericKeyboardWindowSubstationDB1(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB1.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.ElevationSlave1;
                _numericKeyboardWindowSubstationDB1.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationSlave1.Length > 0)
                        {
                            ViewModel.ElevationSlave1 = ViewModel.ElevationSlave1.Substring(0, ViewModel.ElevationSlave1.Length - 1);
                        }
                        else
                        {
                            ViewModel.ElevationSlave1 = ViewModel.ElevationSlave1;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.ElevationSlave1.Length > 0)
                        {
                            if (ViewModel.ElevationSlave1[0] == '-')
                            {
                                ViewModel.ElevationSlave1 = ViewModel.ElevationSlave1.Substring(1);
                            }
                            else
                            {
                                ViewModel.ElevationSlave1 = '-' + ViewModel.ElevationSlave1;
                            }
                        }
                        else
                        {
                            ViewModel.ElevationSlave1 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.ElevationSlave1.Length == 0)
                        {
                            ViewModel.ElevationSlave1 = "0.";
                        }
                        else if (ViewModel.ElevationSlave1.Contains("."))
                        {
                            ViewModel.ElevationSlave1 = ViewModel.ElevationSlave1;
                        }
                        else if (ViewModel.ElevationSlave1.Length == 1 && ViewModel.ElevationSlave1[0] == '-')
                        {
                            ViewModel.ElevationSlave1 = "-0.";
                        }
                        else
                        {
                            ViewModel.ElevationSlave1 = ViewModel.ElevationSlave1 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.ElevationSlave1.Length == 1 && ViewModel.ElevationSlave1[0] == '0')
                        {
                            ViewModel.ElevationSlave1 = "";
                        }
                        ViewModel.ElevationSlave1 += key;
                    };
                    _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.ElevationSlave1.ToString();
                };
                _numericKeyboardWindowSubstationDB1.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleHeightSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 4;
                isTextboxClicked = true;
                backupString = ViewModel.PoleHeight;
                _numericKeyboardWindowSubstationDB1 = new NumericKeyboardWindowSubstationDB1(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB1.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.PoleHeight;
                _numericKeyboardWindowSubstationDB1.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.PoleHeight.ToString();
                };
                _numericKeyboardWindowSubstationDB1.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void Slave1AntennaIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 5;
                isTextboxClicked = true;
                backupString = ViewModel.Slave1AntennaIPAddress;
                _numericKeyboardWindowSubstationDB1 = new NumericKeyboardWindowSubstationDB1(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB1.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.Slave1AntennaIPAddress;
                _numericKeyboardWindowSubstationDB1.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.Slave1AntennaIPAddress.Length > 0)
                        {
                            ViewModel.Slave1AntennaIPAddress = ViewModel.Slave1AntennaIPAddress.Substring(0, ViewModel.Slave1AntennaIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.Slave1AntennaIPAddress = ViewModel.Slave1AntennaIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.Slave1AntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.Slave1AntennaIPAddress[0] == '-')
                            {
                                ViewModel.Slave1AntennaIPAddress = ViewModel.Slave1AntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.Slave1AntennaIPAddress = '-' + ViewModel.Slave1AntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.Slave1AntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.Slave1AntennaIPAddress.Length == 0)
                        {
                            ViewModel.Slave1AntennaIPAddress = "0.";
                        }
                        else if (ViewModel.Slave1AntennaIPAddress.Length == 1 && ViewModel.Slave1AntennaIPAddress[0] == '-')
                        {
                            ViewModel.Slave1AntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.Slave1AntennaIPAddress = ViewModel.Slave1AntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.Slave1AntennaIPAddress.Length == 1 && ViewModel.Slave1AntennaIPAddress[0] == '0')
                        {
                            ViewModel.Slave1AntennaIPAddress = "";
                        }
                        ViewModel.Slave1AntennaIPAddress += key;
                    };
                    _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.Slave1AntennaIPAddress.ToString();
                };
                _numericKeyboardWindowSubstationDB1.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedLatitudeSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 8;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedLatitudeSlave1;
                _numericKeyboardWindowSubstationDB1 = new NumericKeyboardWindowSubstationDB1(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB1.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.SelectedLatitudeSlave1;
                _numericKeyboardWindowSubstationDB1.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedLatitudeSlave1.Length > 0)
                        {
                            ViewModel.SelectedLatitudeSlave1 = ViewModel.SelectedLatitudeSlave1.Substring(0, ViewModel.SelectedLatitudeSlave1.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave1 = ViewModel.SelectedLatitudeSlave1;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedLatitudeSlave1.Length > 0)
                        {
                            if (ViewModel.SelectedLatitudeSlave1[0] == '-')
                            {
                                ViewModel.SelectedLatitudeSlave1 = ViewModel.SelectedLatitudeSlave1.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedLatitudeSlave1 = '-' + ViewModel.SelectedLatitudeSlave1;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave1 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedLatitudeSlave1.Length == 0)
                        {
                            ViewModel.SelectedLatitudeSlave1 = "0.";
                        }
                        else if (ViewModel.SelectedLatitudeSlave1.Contains("."))
                        {
                            ViewModel.SelectedLatitudeSlave1 = ViewModel.SelectedLatitudeSlave1;
                        }
                        else if (ViewModel.SelectedLatitudeSlave1.Length == 1 && ViewModel.SelectedLatitudeSlave1[0] == '-')
                        {
                            ViewModel.SelectedLatitudeSlave1 = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave1 = ViewModel.SelectedLatitudeSlave1 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedLatitudeSlave1.Length == 1 && ViewModel.SelectedLatitudeSlave1[0] == '0')
                        {
                            ViewModel.SelectedLatitudeSlave1 = "";
                        }
                        ViewModel.SelectedLatitudeSlave1 += key;
                    };
                    _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.SelectedLatitudeSlave1.ToString();
                };
                _numericKeyboardWindowSubstationDB1.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedLongitudeSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 9;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedLongitudeSlave1;
                _numericKeyboardWindowSubstationDB1 = new NumericKeyboardWindowSubstationDB1(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB1.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.SelectedLongitudeSlave1;
                _numericKeyboardWindowSubstationDB1.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedLongitudeSlave1.Length > 0)
                        {
                            ViewModel.SelectedLongitudeSlave1 = ViewModel.SelectedLongitudeSlave1.Substring(0, ViewModel.SelectedLongitudeSlave1.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeSlave1 = ViewModel.SelectedLongitudeSlave1;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedLongitudeSlave1.Length > 0)
                        {
                            if (ViewModel.SelectedLongitudeSlave1[0] == '-')
                            {
                                ViewModel.SelectedLongitudeSlave1 = ViewModel.SelectedLongitudeSlave1.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedLongitudeSlave1 = '-' + ViewModel.SelectedLongitudeSlave1;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeSlave1 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedLongitudeSlave1.Length == 0)
                        {
                            ViewModel.SelectedLongitudeSlave1 = "0.";
                        }
                        else if (ViewModel.SelectedLongitudeSlave1.Contains("."))
                        {
                            ViewModel.SelectedLongitudeSlave1 = ViewModel.SelectedLongitudeSlave1;
                        }
                        else if (ViewModel.SelectedLongitudeSlave1.Length == 1 && ViewModel.SelectedLongitudeSlave1[0] == '-')
                        {
                            ViewModel.SelectedLongitudeSlave1 = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeSlave1 = ViewModel.SelectedLongitudeSlave1 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedLongitudeSlave1.Length == 1 && ViewModel.SelectedLongitudeSlave1[0] == '0')
                        {
                            ViewModel.SelectedLongitudeSlave1 = "";
                        }
                        ViewModel.SelectedLongitudeSlave1 += key;
                    };
                    _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.SelectedLongitudeSlave1.ToString();
                };
                _numericKeyboardWindowSubstationDB1.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedElevationSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 10;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedElevationSlave1;
                _numericKeyboardWindowSubstationDB1 = new NumericKeyboardWindowSubstationDB1(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB1.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.SelectedElevationSlave1;
                _numericKeyboardWindowSubstationDB1.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedElevationSlave1.Length > 0)
                        {
                            ViewModel.SelectedElevationSlave1 = ViewModel.SelectedElevationSlave1.Substring(0, ViewModel.SelectedElevationSlave1.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedElevationSlave1 = ViewModel.SelectedElevationSlave1;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedElevationSlave1.Length > 0)
                        {
                            if (ViewModel.SelectedElevationSlave1[0] == '-')
                            {
                                ViewModel.SelectedElevationSlave1 = ViewModel.SelectedElevationSlave1.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedElevationSlave1 = '-' + ViewModel.SelectedElevationSlave1;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedElevationSlave1 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedElevationSlave1.Length == 0)
                        {
                            ViewModel.SelectedElevationSlave1 = "0.";
                        }
                        else if (ViewModel.SelectedElevationSlave1.Contains("."))
                        {
                            ViewModel.SelectedElevationSlave1 = ViewModel.SelectedElevationSlave1;
                        }
                        else if (ViewModel.SelectedElevationSlave1.Length == 1 && ViewModel.SelectedElevationSlave1[0] == '-')
                        {
                            ViewModel.SelectedElevationSlave1 = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedElevationSlave1 = ViewModel.SelectedElevationSlave1 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedElevationSlave1.Length == 1 && ViewModel.SelectedElevationSlave1[0] == '0')
                        {
                            ViewModel.SelectedElevationSlave1 = "";
                        }
                        ViewModel.SelectedElevationSlave1 += key;
                    };
                    _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.SelectedElevationSlave1.ToString();
                };
                _numericKeyboardWindowSubstationDB1.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedPoleHeightSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 11;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedPoleHeight;
                _numericKeyboardWindowSubstationDB1 = new NumericKeyboardWindowSubstationDB1(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB1.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.SelectedPoleHeight;
                _numericKeyboardWindowSubstationDB1.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.SelectedPoleHeight.ToString();
                };
                _numericKeyboardWindowSubstationDB1.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedSlave1AntennaIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 12;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedSlave1AntennaIPAddress;
                _numericKeyboardWindowSubstationDB1 = new NumericKeyboardWindowSubstationDB1(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB1.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.SelectedSlave1AntennaIPAddress;
                _numericKeyboardWindowSubstationDB1.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedSlave1AntennaIPAddress.Length > 0)
                        {
                            ViewModel.SelectedSlave1AntennaIPAddress = ViewModel.SelectedSlave1AntennaIPAddress.Substring(0, ViewModel.SelectedSlave1AntennaIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedSlave1AntennaIPAddress = ViewModel.SelectedSlave1AntennaIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedSlave1AntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.SelectedSlave1AntennaIPAddress[0] == '-')
                            {
                                ViewModel.SelectedSlave1AntennaIPAddress = ViewModel.SelectedSlave1AntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedSlave1AntennaIPAddress = '-' + ViewModel.SelectedSlave1AntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedSlave1AntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedSlave1AntennaIPAddress.Length == 0)
                        {
                            ViewModel.SelectedSlave1AntennaIPAddress = "0.";
                        }
                        else if (ViewModel.SelectedSlave1AntennaIPAddress.Length == 1 && ViewModel.SelectedSlave1AntennaIPAddress[0] == '-')
                        {
                            ViewModel.SelectedSlave1AntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedSlave1AntennaIPAddress = ViewModel.SelectedSlave1AntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedSlave1AntennaIPAddress.Length == 1 && ViewModel.SelectedSlave1AntennaIPAddress[0] == '0')
                        {
                            ViewModel.SelectedSlave1AntennaIPAddress = "";
                        }
                        ViewModel.SelectedSlave1AntennaIPAddress += key;
                    };
                    _numericKeyboardWindowSubstationDB1.KeyPad.Text = ViewModel.SelectedSlave1AntennaIPAddress.ToString();
                };
                _numericKeyboardWindowSubstationDB1.Show();
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
                _numericKeyboardWindowSubstationDB1.Close();
                Keyboard.ClearFocus();
                if (textBoxNo == 1 && _numericKeyboardWindowSubstationDB1._status != 1)
                {
                    ViewModel.LatitudeSlave1 = backupString;
                }
                else if (textBoxNo == 2 && _numericKeyboardWindowSubstationDB1._status != 1)
                {
                    ViewModel.LongitudeSlave1 = backupString;
                }
                else if (textBoxNo == 3 && _numericKeyboardWindowSubstationDB1._status != 1)
                {
                    ViewModel.ElevationSlave1 = backupString;
                }
                else if (textBoxNo == 4 && _numericKeyboardWindowSubstationDB1._status != 1)
                {
                    ViewModel.PoleHeight = backupString;
                }
                else if (textBoxNo == 5 && _numericKeyboardWindowSubstationDB1._status != 1)
                {
                    ViewModel.Slave1AntennaIPAddress = backupString;
                }
                else if (textBoxNo == 8 && _numericKeyboardWindowSubstationDB1._status != 1)
                {
                    ViewModel.SelectedLatitudeSlave1 = backupString;
                }
                else if (textBoxNo == 9 && _numericKeyboardWindowSubstationDB1._status != 1)
                {
                    ViewModel.SelectedLongitudeSlave1 = backupString;
                }
                else if (textBoxNo == 10 && _numericKeyboardWindowSubstationDB1._status != 1)
                {
                    ViewModel.SelectedElevationSlave1 = backupString;
                }
                else if (textBoxNo == 11 && _numericKeyboardWindowSubstationDB1._status != 1)
                {
                    ViewModel.SelectedPoleHeight = backupString;
                }
                else if (textBoxNo == 12 && _numericKeyboardWindowSubstationDB1._status != 1)
                {
                    ViewModel.SelectedSlave1AntennaIPAddress = backupString;
                }
                textBoxNo = 0;
            }
            else
            {
                CreateAppClassAfterDelay();
            }
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

        private void RegistrationDataGrid_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(1);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void RegistrationDataGrid_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(1);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void RegistrationDataGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(1);
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

        private void SelectedSlaveNameTxtBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void SelectedSlaveNameTxtBox_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelectedSlaveNameTxtBox.Focusable = false;
        }
    }
}
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
    /// Interaction logic for SubstationDB3PageMaster.xaml
    /// </summary>
    public partial class SubstationDB3PageMaster : UserControl
    {

        NumericKeyboardWindowSubstationDB3 _numericKeyboardWindowSubstationDB3;
        int textBoxNo;
        string backupString;
        bool isTextboxClicked = false;
        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;
        App app;

        private SubstationDB3MasterViewModel? ViewModel => DataContext as SubstationDB3MasterViewModel;

        public SubstationDB3PageMaster()
        {
            InitializeComponent();
            InitializeDebounceTimer(); // Initialize debounce logic
            app = (App)Application.Current;
            CreateAppClassAfterDelay();

            if (ViewModel != null)
            {
                _numericKeyboardWindowSubstationDB3 = new NumericKeyboardWindowSubstationDB3(0, ViewModel, "");
            }
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._stationDB3MasterViewModel;
            }
        }

        private void LatitudeSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LatitudeSlave3TextBox();
        }

        private void LatitudeSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LatitudeSlave3TextBox();
        }

        private void LatitudeSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LatitudeSlave3TextBox();
        }

        private void LongitudeSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LongitudeSlave3TextBox();
        }

        private void LongitudeSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LongitudeSlave3TextBox();
        }

        private void LongitudeSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LongitudeSlave3TextBox();
        }

        private void ElevationSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlave3TextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlave3TextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlave3TextBox();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleHeightSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PoleHeightSlave3TextBox();
        }

        private void PoleHeightSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PoleHeightSlave3TextBox();
        }

        private void PoleHeightSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PoleHeightSlave3TextBox();
        }

        private void Slave3AntennaIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Slave3AntennaIPAddressTextBox();
        }

        private void Slave3AntennaIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            Slave3AntennaIPAddressTextBox();
        }

        private void Slave3AntennaIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            Slave3AntennaIPAddressTextBox();
        }

        private void SelectedLatitudeSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedLatitudeSlave3TextBox();
        }

        private void SelectedLatitudeSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedLatitudeSlave3TextBox();
        }

        private void SelectedLatitudeSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedLatitudeSlave3TextBox();
        }

        private void SelectedPoleHeightSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedPoleHeightSlave3TextBox();
        }

        private void SelectedPoleHeightSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedPoleHeightSlave3TextBox();
        }

        private void SelectedPoleHeightSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedPoleHeightSlave3TextBox();
        }

        private void SelectedSlave3AntennaIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedSlave3AntennaIPAddressTextBox();
        }

        private void SelectedSlave3AntennaIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedSlave3AntennaIPAddressTextBox();
        }

        private void SelectedSlave3AntennaIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedSlave3AntennaIPAddressTextBox();
        }

        private void SelectedLongitudeSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedLongitudeSlave3TextBox();
        }

        private void SelectedLongitudeSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedLongitudeSlave3TextBox();
        }

        private void SelectedLongitudeSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedLongitudeSlave3TextBox();
        }

        private void SelectedElevationSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedElevationSlave3TextBox();
        }

        private void SelectedElevationSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedElevationSlave3TextBox();
        }

        private void SelectedElevationSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedElevationSlave3TextBox();
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

        private void LatitudeSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 1;
                isTextboxClicked = true;
                backupString = ViewModel.LatitudeSlave3;
                _numericKeyboardWindowSubstationDB3 = new NumericKeyboardWindowSubstationDB3(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB3.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.LatitudeSlave3;
                _numericKeyboardWindowSubstationDB3.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LatitudeSlave3.Length > 0)
                        {
                            ViewModel.LatitudeSlave3 = ViewModel.LatitudeSlave3.Substring(0, ViewModel.LatitudeSlave3.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LatitudeSlave3.Length > 0)
                        {
                            if (ViewModel.LatitudeSlave3[0] == '-')
                            {
                                ViewModel.LatitudeSlave3 = ViewModel.LatitudeSlave3.Substring(1);
                            }
                            else
                            {
                                ViewModel.LatitudeSlave3 = '-' + ViewModel.LatitudeSlave3;
                            }
                        }
                        else
                        {
                            ViewModel.LatitudeSlave3 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LatitudeSlave3.Length == 0)
                        {
                            ViewModel.LatitudeSlave3 = "0.";
                        }
                        else if (ViewModel.LatitudeSlave3.Contains("."))
                        {
                            ViewModel.LatitudeSlave3 = ViewModel.LatitudeSlave3;
                        }
                        else if (ViewModel.LatitudeSlave3.Length == 1 && ViewModel.LatitudeSlave3[0] == '-')
                        {
                            ViewModel.LatitudeSlave3 = "-0.";
                        }
                        else
                        {
                            ViewModel.LatitudeSlave3 = ViewModel.LatitudeSlave3 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LatitudeSlave3.Length == 1 && ViewModel.LatitudeSlave3[0] == '0')
                        {
                            ViewModel.LatitudeSlave3 = "";
                        }
                        ViewModel.LatitudeSlave3 += key;
                    }
                    _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.LatitudeSlave3.ToString();
                };
                _numericKeyboardWindowSubstationDB3.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 2;
                isTextboxClicked = true;
                backupString = ViewModel.LongitudeSlave3;
                _numericKeyboardWindowSubstationDB3 = new NumericKeyboardWindowSubstationDB3(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB3.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.LongitudeSlave3;
                _numericKeyboardWindowSubstationDB3.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LongitudeSlave3.Length > 0)
                        {
                            ViewModel.LongitudeSlave3 = ViewModel.LongitudeSlave3.Substring(0, ViewModel.LongitudeSlave3.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LongitudeSlave3.Length > 0)
                        {
                            if (ViewModel.LongitudeSlave3[0] == '-')
                            {
                                ViewModel.LongitudeSlave3 = ViewModel.LongitudeSlave3.Substring(1);
                            }
                            else
                            {
                                ViewModel.LongitudeSlave3 = '-' + ViewModel.LongitudeSlave3;
                            }
                        }
                        else
                        {
                            ViewModel.LongitudeSlave3 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LongitudeSlave3.Length == 0)
                        {
                            ViewModel.LongitudeSlave3 = "0.";
                        }
                        else if (ViewModel.LongitudeSlave3.Contains("."))
                        {
                            ViewModel.LongitudeSlave3 = ViewModel.LongitudeSlave3;
                        }
                        else if (ViewModel.LongitudeSlave3.Length == 1 && ViewModel.LongitudeSlave3[0] == '-')
                        {
                            ViewModel.LongitudeSlave3 = "-0.";
                        }
                        else
                        {
                            ViewModel.LongitudeSlave3 = ViewModel.LongitudeSlave3 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LongitudeSlave3.Length == 1 && ViewModel.LongitudeSlave3[0] == '0')
                        {
                            ViewModel.LongitudeSlave3 = "";
                        }
                        ViewModel.LongitudeSlave3 += key;
                    }
                    _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.LongitudeSlave3.ToString();
                };
                _numericKeyboardWindowSubstationDB3.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 3;
                isTextboxClicked = true;
                backupString = ViewModel.ElevationSlave3;
                _numericKeyboardWindowSubstationDB3 = new NumericKeyboardWindowSubstationDB3(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB3.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.ElevationSlave3;
                _numericKeyboardWindowSubstationDB3.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationSlave3.Length > 0)
                        {
                            ViewModel.ElevationSlave3 = ViewModel.ElevationSlave3.Substring(0, ViewModel.ElevationSlave3.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.ElevationSlave3.Length > 0)
                        {
                            if (ViewModel.ElevationSlave3[0] == '-')
                            {
                                ViewModel.ElevationSlave3 = ViewModel.ElevationSlave3.Substring(1);
                            }
                            else
                            {
                                ViewModel.ElevationSlave3 = '-' + ViewModel.ElevationSlave3;
                            }
                        }
                        else
                        {
                            ViewModel.ElevationSlave3 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.ElevationSlave3.Length == 0)
                        {
                            ViewModel.ElevationSlave3 = "0.";
                        }
                        else if (ViewModel.ElevationSlave3.Contains("."))
                        {
                            ViewModel.ElevationSlave3 = ViewModel.ElevationSlave3;
                        }
                        else if (ViewModel.ElevationSlave3.Length == 1 && ViewModel.ElevationSlave3[0] == '-')
                        {
                            ViewModel.ElevationSlave3 = "-0.";
                        }
                        else
                        {
                            ViewModel.ElevationSlave3 = ViewModel.ElevationSlave3 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.ElevationSlave3.Length == 1 && ViewModel.ElevationSlave3[0] == '0')
                        {
                            ViewModel.ElevationSlave3 = "";
                        }
                        ViewModel.ElevationSlave3 += key;
                    }
                    _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.ElevationSlave3.ToString();
                };
                _numericKeyboardWindowSubstationDB3.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleHeightSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 4;
                isTextboxClicked = true;
                backupString = ViewModel.PoleHeight;
                _numericKeyboardWindowSubstationDB3 = new NumericKeyboardWindowSubstationDB3(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB3.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.PoleHeight;
                _numericKeyboardWindowSubstationDB3.KeyPressed += (s, key) =>
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
                    }
                    _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.PoleHeight.ToString();
                };
                _numericKeyboardWindowSubstationDB3.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void Slave3AntennaIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 5;
                isTextboxClicked = true;
                backupString = ViewModel.Slave3AntennaIPAddress;
                _numericKeyboardWindowSubstationDB3 = new NumericKeyboardWindowSubstationDB3(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB3.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.Slave3AntennaIPAddress;
                _numericKeyboardWindowSubstationDB3.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.Slave3AntennaIPAddress.Length > 0)
                        {
                            ViewModel.Slave3AntennaIPAddress = ViewModel.Slave3AntennaIPAddress.Substring(0, ViewModel.Slave3AntennaIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.Slave3AntennaIPAddress = ViewModel.Slave3AntennaIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.Slave3AntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.Slave3AntennaIPAddress[0] == '-')
                            {
                                ViewModel.Slave3AntennaIPAddress = ViewModel.Slave3AntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.Slave3AntennaIPAddress = '-' + ViewModel.Slave3AntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.Slave3AntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.Slave3AntennaIPAddress.Length == 0)
                        {
                            ViewModel.Slave3AntennaIPAddress = "0.";
                        }
                        else if (ViewModel.Slave3AntennaIPAddress.Length == 1 && ViewModel.Slave3AntennaIPAddress[0] == '-')
                        {
                            ViewModel.Slave3AntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.Slave3AntennaIPAddress = ViewModel.Slave3AntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.Slave3AntennaIPAddress.Length == 1 && ViewModel.Slave3AntennaIPAddress[0] == '0')
                        {
                            ViewModel.Slave3AntennaIPAddress = "";
                        }
                        ViewModel.Slave3AntennaIPAddress += key;
                    }
                    _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.Slave3AntennaIPAddress.ToString();
                };
                _numericKeyboardWindowSubstationDB3.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedLatitudeSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 8;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedLatitudeSlave3;
                _numericKeyboardWindowSubstationDB3 = new NumericKeyboardWindowSubstationDB3(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB3.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.SelectedLatitudeSlave3;
                _numericKeyboardWindowSubstationDB3.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedLatitudeSlave3.Length > 0)
                        {
                            ViewModel.SelectedLatitudeSlave3 = ViewModel.SelectedLatitudeSlave3.Substring(0, ViewModel.SelectedLatitudeSlave3.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave3 = ViewModel.SelectedLatitudeSlave3;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedLatitudeSlave3.Length > 0)
                        {
                            if (ViewModel.SelectedLatitudeSlave3[0] == '-')
                            {
                                ViewModel.SelectedLatitudeSlave3 = ViewModel.SelectedLatitudeSlave3.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedLatitudeSlave3 = '-' + ViewModel.SelectedLatitudeSlave3;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave3 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedLatitudeSlave3.Length == 0)
                        {
                            ViewModel.SelectedLatitudeSlave3 = "0.";
                        }
                        else if (ViewModel.SelectedLatitudeSlave3.Contains("."))
                        {
                            ViewModel.SelectedLatitudeSlave3 = ViewModel.SelectedLatitudeSlave3;
                        }
                        else if (ViewModel.SelectedLatitudeSlave3.Length == 1 && ViewModel.SelectedLatitudeSlave3[0] == '-')
                        {
                            ViewModel.SelectedLatitudeSlave3 = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave3 = ViewModel.SelectedLatitudeSlave3 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedLatitudeSlave3.Length == 1 && ViewModel.SelectedLatitudeSlave3[0] == '0')
                        {
                            ViewModel.SelectedLatitudeSlave3 = "";
                        }
                        ViewModel.SelectedLatitudeSlave3 += key;
                    }
                    _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.SelectedLatitudeSlave3.ToString();
                };
                _numericKeyboardWindowSubstationDB3.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedLongitudeSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 9;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedLongitudeSlave3;
                _numericKeyboardWindowSubstationDB3 = new NumericKeyboardWindowSubstationDB3(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB3.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.SelectedLongitudeSlave3;
                _numericKeyboardWindowSubstationDB3.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedLongitudeSlave3.Length > 0)
                        {
                            ViewModel.SelectedLongitudeSlave3 = ViewModel.SelectedLongitudeSlave3.Substring(0, ViewModel.SelectedLongitudeSlave3.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedLongitudeSlave3.Length > 0)
                        {
                            if (ViewModel.SelectedLongitudeSlave3[0] == '-')
                            {
                                ViewModel.SelectedLongitudeSlave3 = ViewModel.SelectedLongitudeSlave3.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedLongitudeSlave3 = '-' + ViewModel.SelectedLongitudeSlave3;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeSlave3 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedLongitudeSlave3.Length == 0)
                        {
                            ViewModel.SelectedLongitudeSlave3 = "0.";
                        }
                        else if (ViewModel.SelectedLongitudeSlave3.Contains("."))
                        {
                            ViewModel.SelectedLongitudeSlave3 = ViewModel.SelectedLongitudeSlave3;
                        }
                        else if (ViewModel.SelectedLongitudeSlave3.Length == 1 && ViewModel.SelectedLongitudeSlave3[0] == '-')
                        {
                            ViewModel.SelectedLongitudeSlave3 = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeSlave3 = ViewModel.SelectedLongitudeSlave3 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedLongitudeSlave3.Length == 1 && ViewModel.SelectedLongitudeSlave3[0] == '0')
                        {
                            ViewModel.SelectedLongitudeSlave3 = "";
                        }
                        ViewModel.SelectedLongitudeSlave3 += key;
                    }
                    _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.SelectedLongitudeSlave3.ToString();
                };
                _numericKeyboardWindowSubstationDB3.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedElevationSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 10;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedElevationSlave3;
                _numericKeyboardWindowSubstationDB3 = new NumericKeyboardWindowSubstationDB3(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB3.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.SelectedElevationSlave3;
                _numericKeyboardWindowSubstationDB3.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedElevationSlave3.Length > 0)
                        {
                            ViewModel.SelectedElevationSlave3 = ViewModel.SelectedElevationSlave3.Substring(0, ViewModel.SelectedElevationSlave3.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedElevationSlave3.Length > 0)
                        {
                            if (ViewModel.SelectedElevationSlave3[0] == '-')
                            {
                                ViewModel.SelectedElevationSlave3 = ViewModel.SelectedElevationSlave3.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedElevationSlave3 = '-' + ViewModel.SelectedElevationSlave3;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedElevationSlave3 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedElevationSlave3.Length == 0)
                        {
                            ViewModel.SelectedElevationSlave3 = "0.";
                        }
                        else if (ViewModel.SelectedElevationSlave3.Contains("."))
                        {
                            ViewModel.SelectedElevationSlave3 = ViewModel.SelectedElevationSlave3;
                        }
                        else if (ViewModel.SelectedElevationSlave3.Length == 1 && ViewModel.SelectedElevationSlave3[0] == '-')
                        {
                            ViewModel.SelectedElevationSlave3 = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedElevationSlave3 = ViewModel.SelectedElevationSlave3 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedElevationSlave3.Length == 1 && ViewModel.SelectedElevationSlave3[0] == '0')
                        {
                            ViewModel.SelectedElevationSlave3 = "";
                        }
                        ViewModel.SelectedElevationSlave3 += key;
                    }
                    _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.SelectedElevationSlave3.ToString();
                };
                _numericKeyboardWindowSubstationDB3.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedPoleHeightSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 11;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedPoleHeight;
                _numericKeyboardWindowSubstationDB3 = new NumericKeyboardWindowSubstationDB3(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB3.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.SelectedPoleHeight;
                _numericKeyboardWindowSubstationDB3.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.SelectedPoleHeight.ToString();
                };
                _numericKeyboardWindowSubstationDB3.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedSlave3AntennaIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 12;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedSlave3AntennaIPAddress;
                _numericKeyboardWindowSubstationDB3 = new NumericKeyboardWindowSubstationDB3(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB3.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.SelectedSlave3AntennaIPAddress;
                _numericKeyboardWindowSubstationDB3.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedSlave3AntennaIPAddress.Length > 0)
                        {
                            ViewModel.SelectedSlave3AntennaIPAddress = ViewModel.SelectedSlave3AntennaIPAddress.Substring(0, ViewModel.SelectedSlave3AntennaIPAddress.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedSlave3AntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.SelectedSlave3AntennaIPAddress[0] == '-')
                            {
                                ViewModel.SelectedSlave3AntennaIPAddress = ViewModel.SelectedSlave3AntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedSlave3AntennaIPAddress = '-' + ViewModel.SelectedSlave3AntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedSlave3AntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedSlave3AntennaIPAddress.Length == 0)
                        {
                            ViewModel.SelectedSlave3AntennaIPAddress = "0.";
                        }
                        else if (ViewModel.SelectedSlave3AntennaIPAddress.Length == 1 && ViewModel.SelectedSlave3AntennaIPAddress[0] == '-')
                        {
                            ViewModel.SelectedSlave3AntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedSlave3AntennaIPAddress = ViewModel.SelectedSlave3AntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedSlave3AntennaIPAddress.Length == 1 && ViewModel.SelectedSlave3AntennaIPAddress[0] == '0')
                        {
                            ViewModel.SelectedSlave3AntennaIPAddress = "";
                        }
                        ViewModel.SelectedSlave3AntennaIPAddress += key;
                    }
                    _numericKeyboardWindowSubstationDB3.KeyPad.Text = ViewModel.SelectedSlave3AntennaIPAddress.ToString();
                };
                _numericKeyboardWindowSubstationDB3.Show();
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
                _numericKeyboardWindowSubstationDB3.Close();
                Keyboard.ClearFocus();
                if (textBoxNo == 1 && _numericKeyboardWindowSubstationDB3._status != 1)
                {
                    ViewModel.LatitudeSlave3 = backupString;
                }
                else if (textBoxNo == 2 && _numericKeyboardWindowSubstationDB3._status != 1)
                {
                    ViewModel.LongitudeSlave3 = backupString;
                }
                else if (textBoxNo == 3 && _numericKeyboardWindowSubstationDB3._status != 1)
                {
                    ViewModel.ElevationSlave3 = backupString;
                }
                else if (textBoxNo == 4 && _numericKeyboardWindowSubstationDB3._status != 1)
                {
                    ViewModel.PoleHeight = backupString;
                }
                else if (textBoxNo == 5 && _numericKeyboardWindowSubstationDB3._status != 1)
                {
                    ViewModel.Slave3AntennaIPAddress = backupString;
                }
                else if (textBoxNo == 8 && _numericKeyboardWindowSubstationDB3._status != 1)
                {
                    ViewModel.SelectedLatitudeSlave3 = backupString;
                }
                else if (textBoxNo == 9 && _numericKeyboardWindowSubstationDB3._status != 1)
                {
                    ViewModel.SelectedLongitudeSlave3 = backupString;
                }
                else if (textBoxNo == 10 && _numericKeyboardWindowSubstationDB3._status != 1)
                {
                    ViewModel.SelectedElevationSlave3 = backupString;
                }
                else if (textBoxNo == 11 && _numericKeyboardWindowSubstationDB3._status != 1)
                {
                    ViewModel.SelectedPoleHeight = backupString;
                }
                else if (textBoxNo == 12 && _numericKeyboardWindowSubstationDB3._status != 1)
                {
                    ViewModel.SelectedSlave3AntennaIPAddress = backupString;
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
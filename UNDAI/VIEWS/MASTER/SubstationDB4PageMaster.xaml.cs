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
    /// Interaction logic for SubstationDB4PageMaster.xaml
    /// </summary>
    public partial class SubstationDB4PageMaster : UserControl
    {
        NumericKeyboardWindowSubstationDB4 _numericKeyboardWindowSubstationDB4;
        int textBoxNo;
        string backupString;
        bool isTextboxClicked = false;
        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;
        App app;

        private SubstationDB4MasterViewModel? ViewModel => DataContext as SubstationDB4MasterViewModel;

        public SubstationDB4PageMaster()
        {
            InitializeComponent();
            InitializeDebounceTimer(); // Initialize debounce logic
            app = (App)Application.Current;
            CreateAppClassAfterDelay();

            if (ViewModel != null)
            {
                _numericKeyboardWindowSubstationDB4 = new NumericKeyboardWindowSubstationDB4(0, ViewModel, "");
            }
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._stationDB4MasterViewModel;
            }
        }

        private void LatitudeSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LatitudeSlave4TextBox();
        }

        private void LatitudeSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LatitudeSlave4TextBox();
        }

        private void LatitudeSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LatitudeSlave4TextBox();
        }

        private void LongitudeSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LongitudeSlave4TextBox();
        }

        private void LongitudeSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LongitudeSlave4TextBox();
        }

        private void LongitudeSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LongitudeSlave4TextBox();
        }

        private void ElevationSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlave4TextBox();
                }
            }
        }

        private void ElevationSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
            {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlave4TextBox();
                }
            }
        }

        private void ElevationSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
                {
            if (ViewModel != null)
            {
                if (ViewModel.IsElevationEnabled)
                {
                    ElevationSlave4TextBox();
                }
            }
        }

        private void PoleHeightSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PoleHeightSlave4TextBox();
        }

        private void PoleHeightSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PoleHeightSlave4TextBox();
        }

        private void PoleHeightSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PoleHeightSlave4TextBox();
        }

        private void Slave4AntennaIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Slave4AntennaIPAddressTextBox();
        }

        private void Slave4AntennaIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            Slave4AntennaIPAddressTextBox();
        }

        private void Slave4AntennaIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            Slave4AntennaIPAddressTextBox();
        }

        private void SelectedLatitudeSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedLatitudeSlave4TextBox();
        }

        private void SelectedLatitudeSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedLatitudeSlave4TextBox();
        }

        private void SelectedLatitudeSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedLatitudeSlave4TextBox();
        }

        private void SelectedPoleHeightSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedPoleHeightSlave4TextBox();
        }

        private void SelectedPoleHeightSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedPoleHeightSlave4TextBox();
        }

        private void SelectedPoleHeightSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedPoleHeightSlave4TextBox();
        }

        private void SelectedSlave4AntennaIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedSlave4AntennaIPAddressTextBox();
        }

        private void SelectedSlave4AntennaIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedSlave4AntennaIPAddressTextBox();
        }

        private void SelectedSlave4AntennaIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedSlave4AntennaIPAddressTextBox();
        }

        private void SelectedLongitudeSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedLongitudeSlave4TextBox();
        }

        private void SelectedLongitudeSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedLongitudeSlave4TextBox();
        }

        private void SelectedLongitudeSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedLongitudeSlave4TextBox();
        }

        private void SelectedElevationSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectedElevationSlave4TextBox();
        }

        private void SelectedElevationSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SelectedElevationSlave4TextBox();
        }

        private void SelectedElevationSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SelectedElevationSlave4TextBox();
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

        private void LatitudeSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 1;
                isTextboxClicked = true;
                backupString = ViewModel.LatitudeSlave4;
                _numericKeyboardWindowSubstationDB4 = new NumericKeyboardWindowSubstationDB4(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB4.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.LatitudeSlave4;
                _numericKeyboardWindowSubstationDB4.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LatitudeSlave4.Length > 0)
                        {
                            ViewModel.LatitudeSlave4 = ViewModel.LatitudeSlave4.Substring(0, ViewModel.LatitudeSlave4.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LatitudeSlave4.Length > 0)
                        {
                            if (ViewModel.LatitudeSlave4[0] == '-')
                            {
                                ViewModel.LatitudeSlave4 = ViewModel.LatitudeSlave4.Substring(1);
                            }
                            else
                            {
                                ViewModel.LatitudeSlave4 = '-' + ViewModel.LatitudeSlave4;
                            }
                        }
                        else
                        {
                            ViewModel.LatitudeSlave4 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LatitudeSlave4.Length == 0)
                        {
                            ViewModel.LatitudeSlave4 = "0.";
                        }
                        else if (ViewModel.LatitudeSlave4.Contains("."))
                        {
                            ViewModel.LatitudeSlave4 = ViewModel.LatitudeSlave4;
                        }
                        else if (ViewModel.LatitudeSlave4.Length == 1 && ViewModel.LatitudeSlave4[0] == '-')
                        {
                            ViewModel.LatitudeSlave4 = "-0.";
                        }
                        else
                        {
                            ViewModel.LatitudeSlave4 = ViewModel.LatitudeSlave4 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LatitudeSlave4.Length == 1 && ViewModel.LatitudeSlave4[0] == '0')
                        {
                            ViewModel.LatitudeSlave4 = "";
                        }
                        ViewModel.LatitudeSlave4 += key;
                    }
                    _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.LatitudeSlave4.ToString();
                };
                _numericKeyboardWindowSubstationDB4.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 2;
                isTextboxClicked = true;
                backupString = ViewModel.LongitudeSlave4;
                _numericKeyboardWindowSubstationDB4 = new NumericKeyboardWindowSubstationDB4(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB4.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.LongitudeSlave4;
                _numericKeyboardWindowSubstationDB4.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LongitudeSlave4.Length > 0)
                        {
                            ViewModel.LongitudeSlave4 = ViewModel.LongitudeSlave4.Substring(0, ViewModel.LongitudeSlave4.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LongitudeSlave4.Length > 0)
                        {
                            if (ViewModel.LongitudeSlave4[0] == '-')
                            {
                                ViewModel.LongitudeSlave4 = ViewModel.LongitudeSlave4.Substring(1);
                            }
                            else
                            {
                                ViewModel.LongitudeSlave4 = '-' + ViewModel.LongitudeSlave4;
                            }
                        }
                        else
                        {
                            ViewModel.LongitudeSlave4 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LongitudeSlave4.Length == 0)
                        {
                            ViewModel.LongitudeSlave4 = "0.";
                        }
                        else if (ViewModel.LongitudeSlave4.Contains("."))
                        {
                            ViewModel.LongitudeSlave4 = ViewModel.LongitudeSlave4;
                        }
                        else if (ViewModel.LongitudeSlave4.Length == 1 && ViewModel.LongitudeSlave4[0] == '-')
                        {
                            ViewModel.LongitudeSlave4 = "-0.";
                        }
                        else
                        {
                            ViewModel.LongitudeSlave4 = ViewModel.LongitudeSlave4 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LongitudeSlave4.Length == 1 && ViewModel.LongitudeSlave4[0] == '0')
                        {
                            ViewModel.LongitudeSlave4 = "";
                        }
                        ViewModel.LongitudeSlave4 += key;
                    }
                    _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.LongitudeSlave4.ToString();
                };
                _numericKeyboardWindowSubstationDB4.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 3;
                isTextboxClicked = true;
                backupString = ViewModel.ElevationSlave4;
                _numericKeyboardWindowSubstationDB4 = new NumericKeyboardWindowSubstationDB4(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB4.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.ElevationSlave4;
                _numericKeyboardWindowSubstationDB4.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationSlave4.Length > 0)
                        {
                            ViewModel.ElevationSlave4 = ViewModel.ElevationSlave4.Substring(0, ViewModel.ElevationSlave4.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.ElevationSlave4.Length > 0)
                        {
                            if (ViewModel.ElevationSlave4[0] == '-')
                            {
                                ViewModel.ElevationSlave4 = ViewModel.ElevationSlave4.Substring(1);
                            }
                            else
                            {
                                ViewModel.ElevationSlave4 = '-' + ViewModel.ElevationSlave4;
                            }
                        }
                        else
                        {
                            ViewModel.ElevationSlave4 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.ElevationSlave4.Length == 0)
                        {
                            ViewModel.ElevationSlave4 = "0.";
                        }
                        else if (ViewModel.ElevationSlave4.Contains("."))
                        {
                            ViewModel.ElevationSlave4 = ViewModel.ElevationSlave4;
                        }
                        else if (ViewModel.ElevationSlave4.Length == 1 && ViewModel.ElevationSlave4[0] == '-')
                        {
                            ViewModel.ElevationSlave4 = "-0.";
                        }
                        else
                        {
                            ViewModel.ElevationSlave4 = ViewModel.ElevationSlave4 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.ElevationSlave4.Length == 1 && ViewModel.ElevationSlave4[0] == '0')
                        {
                            ViewModel.ElevationSlave4 = "";
                        }
                        ViewModel.ElevationSlave4 += key;
                    }
                    _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.ElevationSlave4.ToString();
                };
                _numericKeyboardWindowSubstationDB4.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleHeightSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 4;
                isTextboxClicked = true;
                backupString = ViewModel.PoleHeight;
                _numericKeyboardWindowSubstationDB4 = new NumericKeyboardWindowSubstationDB4(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB4.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.PoleHeight;
                _numericKeyboardWindowSubstationDB4.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.PoleHeight.ToString();
                };
                _numericKeyboardWindowSubstationDB4.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void Slave4AntennaIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 5;
                isTextboxClicked = true;
                backupString = ViewModel.Slave4AntennaIPAddress;
                _numericKeyboardWindowSubstationDB4 = new NumericKeyboardWindowSubstationDB4(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB4.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.Slave4AntennaIPAddress;
                _numericKeyboardWindowSubstationDB4.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.Slave4AntennaIPAddress.Length > 0)
                        {
                            ViewModel.Slave4AntennaIPAddress = ViewModel.Slave4AntennaIPAddress.Substring(0, ViewModel.Slave4AntennaIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.Slave4AntennaIPAddress = ViewModel.Slave4AntennaIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.Slave4AntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.Slave4AntennaIPAddress[0] == '-')
                            {
                                ViewModel.Slave4AntennaIPAddress = ViewModel.Slave4AntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.Slave4AntennaIPAddress = '-' + ViewModel.Slave4AntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.Slave4AntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.Slave4AntennaIPAddress.Length == 0)
                        {
                            ViewModel.Slave4AntennaIPAddress = "0.";
                        }
                        else if (ViewModel.Slave4AntennaIPAddress.Length == 1 && ViewModel.Slave4AntennaIPAddress[0] == '-')
                        {
                            ViewModel.Slave4AntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.Slave4AntennaIPAddress = ViewModel.Slave4AntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.Slave4AntennaIPAddress.Length == 1 && ViewModel.Slave4AntennaIPAddress[0] == '0')
                        {
                            ViewModel.Slave4AntennaIPAddress = "";
                        }
                        ViewModel.Slave4AntennaIPAddress += key;
                    }
                    _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.Slave4AntennaIPAddress.ToString();
                };
                _numericKeyboardWindowSubstationDB4.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedLatitudeSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 8;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedLatitudeSlave4;
                _numericKeyboardWindowSubstationDB4 = new NumericKeyboardWindowSubstationDB4(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB4.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.SelectedLatitudeSlave4;
                _numericKeyboardWindowSubstationDB4.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedLatitudeSlave4.Length > 0)
                        {
                            ViewModel.SelectedLatitudeSlave4 = ViewModel.SelectedLatitudeSlave4.Substring(0, ViewModel.SelectedLatitudeSlave4.Length - 1);
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave4 = ViewModel.SelectedLatitudeSlave4;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedLatitudeSlave4.Length > 0)
                        {
                            if (ViewModel.SelectedLatitudeSlave4[0] == '-')
                            {
                                ViewModel.SelectedLatitudeSlave4 = ViewModel.SelectedLatitudeSlave4.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedLatitudeSlave4 = '-' + ViewModel.SelectedLatitudeSlave4;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave4 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedLatitudeSlave4.Length == 0)
                        {
                            ViewModel.SelectedLatitudeSlave4 = "0.";
                        }
                        else if (ViewModel.SelectedLatitudeSlave4.Contains("."))
                        {
                            ViewModel.SelectedLatitudeSlave4 = ViewModel.SelectedLatitudeSlave4;
                        }
                        else if (ViewModel.SelectedLatitudeSlave4.Length == 1 && ViewModel.SelectedLatitudeSlave4[0] == '-')
                        {
                            ViewModel.SelectedLatitudeSlave4 = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedLatitudeSlave4 = ViewModel.SelectedLatitudeSlave4 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedLatitudeSlave4.Length == 1 && ViewModel.SelectedLatitudeSlave4[0] == '0')
                        {
                            ViewModel.SelectedLatitudeSlave4 = "";
                        }
                        ViewModel.SelectedLatitudeSlave4 += key;
                    }
                    _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.SelectedLatitudeSlave4.ToString();
                };
                _numericKeyboardWindowSubstationDB4.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedLongitudeSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 9;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedLongitudeSlave4;
                _numericKeyboardWindowSubstationDB4 = new NumericKeyboardWindowSubstationDB4(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB4.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.SelectedLongitudeSlave4;
                _numericKeyboardWindowSubstationDB4.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedLongitudeSlave4.Length > 0)
                        {
                            ViewModel.SelectedLongitudeSlave4 = ViewModel.SelectedLongitudeSlave4.Substring(0, ViewModel.SelectedLongitudeSlave4.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedLongitudeSlave4.Length > 0)
                        {
                            if (ViewModel.SelectedLongitudeSlave4[0] == '-')
                            {
                                ViewModel.SelectedLongitudeSlave4 = ViewModel.SelectedLongitudeSlave4.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedLongitudeSlave4 = '-' + ViewModel.SelectedLongitudeSlave4;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeSlave4 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedLongitudeSlave4.Length == 0)
                        {
                            ViewModel.SelectedLongitudeSlave4 = "0.";
                        }
                        else if (ViewModel.SelectedLongitudeSlave4.Contains("."))
                        {
                            ViewModel.SelectedLongitudeSlave4 = ViewModel.SelectedLongitudeSlave4;
                        }
                        else if (ViewModel.SelectedLongitudeSlave4.Length == 1 && ViewModel.SelectedLongitudeSlave4[0] == '-')
                        {
                            ViewModel.SelectedLongitudeSlave4 = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedLongitudeSlave4 = ViewModel.SelectedLongitudeSlave4 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedLongitudeSlave4.Length == 1 && ViewModel.SelectedLongitudeSlave4[0] == '0')
                        {
                            ViewModel.SelectedLongitudeSlave4 = "";
                        }
                        ViewModel.SelectedLongitudeSlave4 += key;
                    }
                    _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.SelectedLongitudeSlave4.ToString();
                };
                _numericKeyboardWindowSubstationDB4.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedElevationSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 10;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedElevationSlave4;
                _numericKeyboardWindowSubstationDB4 = new NumericKeyboardWindowSubstationDB4(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB4.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.SelectedElevationSlave4;
                _numericKeyboardWindowSubstationDB4.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedElevationSlave4.Length > 0)
                        {
                            ViewModel.SelectedElevationSlave4 = ViewModel.SelectedElevationSlave4.Substring(0, ViewModel.SelectedElevationSlave4.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedElevationSlave4.Length > 0)
                        {
                            if (ViewModel.SelectedElevationSlave4[0] == '-')
                            {
                                ViewModel.SelectedElevationSlave4 = ViewModel.SelectedElevationSlave4.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedElevationSlave4 = '-' + ViewModel.SelectedElevationSlave4;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedElevationSlave4 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedElevationSlave4.Length == 0)
                        {
                            ViewModel.SelectedElevationSlave4 = "0.";
                        }
                        else if (ViewModel.SelectedElevationSlave4.Contains("."))
                        {
                            ViewModel.SelectedElevationSlave4 = ViewModel.SelectedElevationSlave4;
                        }
                        else if (ViewModel.SelectedElevationSlave4.Length == 1 && ViewModel.SelectedElevationSlave4[0] == '-')
                        {
                            ViewModel.SelectedElevationSlave4 = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedElevationSlave4 = ViewModel.SelectedElevationSlave4 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedElevationSlave4.Length == 1 && ViewModel.SelectedElevationSlave4[0] == '0')
                        {
                            ViewModel.SelectedElevationSlave4 = "";
                        }
                        ViewModel.SelectedElevationSlave4 += key;
                    }
                    _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.SelectedElevationSlave4.ToString();
                };
                _numericKeyboardWindowSubstationDB4.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedPoleHeightSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 11;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedPoleHeight;
                _numericKeyboardWindowSubstationDB4 = new NumericKeyboardWindowSubstationDB4(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB4.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.SelectedPoleHeight;
                _numericKeyboardWindowSubstationDB4.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.SelectedPoleHeight.ToString();
                };
                _numericKeyboardWindowSubstationDB4.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SelectedSlave4AntennaIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 12;
                isTextboxClicked = true;
                backupString = ViewModel.SelectedSlave4AntennaIPAddress;
                _numericKeyboardWindowSubstationDB4 = new NumericKeyboardWindowSubstationDB4(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationDB4.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.SelectedSlave4AntennaIPAddress;
                _numericKeyboardWindowSubstationDB4.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SelectedSlave4AntennaIPAddress.Length > 0)
                        {
                            ViewModel.SelectedSlave4AntennaIPAddress = ViewModel.SelectedSlave4AntennaIPAddress.Substring(0, ViewModel.SelectedSlave4AntennaIPAddress.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.SelectedSlave4AntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.SelectedSlave4AntennaIPAddress[0] == '-')
                            {
                                ViewModel.SelectedSlave4AntennaIPAddress = ViewModel.SelectedSlave4AntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.SelectedSlave4AntennaIPAddress = '-' + ViewModel.SelectedSlave4AntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.SelectedSlave4AntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SelectedSlave4AntennaIPAddress.Length == 0)
                        {
                            ViewModel.SelectedSlave4AntennaIPAddress = "0.";
                        }
                        else if (ViewModel.SelectedSlave4AntennaIPAddress.Length == 1 && ViewModel.SelectedSlave4AntennaIPAddress[0] == '-')
                        {
                            ViewModel.SelectedSlave4AntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.SelectedSlave4AntennaIPAddress = ViewModel.SelectedSlave4AntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SelectedSlave4AntennaIPAddress.Length == 1 && ViewModel.SelectedSlave4AntennaIPAddress[0] == '0')
                        {
                            ViewModel.SelectedSlave4AntennaIPAddress = "";
                        }
                        ViewModel.SelectedSlave4AntennaIPAddress += key;
                    }
                    _numericKeyboardWindowSubstationDB4.KeyPad.Text = ViewModel.SelectedSlave4AntennaIPAddress.ToString();
                };
                _numericKeyboardWindowSubstationDB4.Show();
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
                _numericKeyboardWindowSubstationDB4.Close();
                Keyboard.ClearFocus();
                if (textBoxNo == 1 && _numericKeyboardWindowSubstationDB4._status != 1)
                {
                    ViewModel.LatitudeSlave4 = backupString;
                }
                else if (textBoxNo == 2 && _numericKeyboardWindowSubstationDB4._status != 1)
                {
                    ViewModel.LongitudeSlave4 = backupString;
                }
                else if (textBoxNo == 3 && _numericKeyboardWindowSubstationDB4._status != 1)
                {
                    ViewModel.ElevationSlave4 = backupString;
                }
                else if (textBoxNo == 4 && _numericKeyboardWindowSubstationDB4._status != 1)
                {
                    ViewModel.PoleHeight = backupString;
                }
                else if (textBoxNo == 5 && _numericKeyboardWindowSubstationDB4._status != 1)
                {
                    ViewModel.Slave4AntennaIPAddress = backupString;
                }
                else if (textBoxNo == 8 && _numericKeyboardWindowSubstationDB4._status != 1)
                {
                    ViewModel.SelectedLatitudeSlave4 = backupString;
                }
                else if (textBoxNo == 9 && _numericKeyboardWindowSubstationDB4._status != 1)
                {
                    ViewModel.SelectedLongitudeSlave4 = backupString;
                }
                else if (textBoxNo == 10 && _numericKeyboardWindowSubstationDB4._status != 1)
                {
                    ViewModel.SelectedElevationSlave4 = backupString;
                }
                else if (textBoxNo == 11 && _numericKeyboardWindowSubstationDB4._status != 1)
                {
                    ViewModel.SelectedPoleHeight = backupString;
                }
                else if (textBoxNo == 12 && _numericKeyboardWindowSubstationDB4._status != 1)
                {
                    ViewModel.SelectedSlave4AntennaIPAddress = backupString;
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

        private void RegistrationDataGridMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(1);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void RegistrationDataGridMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(1);
            SlaveNameTxtBox.Focusable = false;
            SelectedSlaveNameTxtBox.Focusable = false;
        }

        private void RegistrationDataGridMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
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
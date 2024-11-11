using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UNDAI.VIEWMODELS.MASTER;

namespace UNDAI.VIEWS.BASE
{
    /// <summary>
    /// Interaction logic for NumericKeyboardWindowSubstationReg.xaml
    /// </summary>
    public partial class NumericKeyboardWindowSubstationReg : Window
    {
        public event EventHandler<string> KeyPressed;
        public int _textBoxNo;
        public int _status = 0;
        string _backupString;
        private SubstationRegistrationMasterViewModel _substationRegistrationMasterViewModel;

        public NumericKeyboardWindowSubstationReg
        (
            int TextBoxNo, 
            SubstationRegistrationMasterViewModel substationRegistrationMasterViewModel, 
            string backupString
        )
        {
            InitializeComponent();
            //Loaded += OnWindowLoaded;
            _textBoxNo = TextBoxNo;
            _backupString = backupString;
            _substationRegistrationMasterViewModel = substationRegistrationMasterViewModel;
        }

        // Handle mouse left button down event to initiate drag
        private void TopBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove(); // Move the window
            }
        }

        // Handle touch down event to initiate drag
        private void TopBorder_TouchDown(object sender, TouchEventArgs e)
        {
            DragMove(); // Move the window
        }

        // Handle stylus down event to initiate drag
        private void TopBorder_StylusDown(object sender, StylusDownEventArgs e)
        {
            DragMove(); // Move the window
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            // Get the main window
            var mainWindow = Application.Current.MainWindow;

            // Calculate the position relative to the main window
            // Offset the window to appear below and to the right of the main window
            if (_textBoxNo == 1)
            {
                this.Left = mainWindow.Left + 500;  // X coordinate relative to MainWindow
                this.Top = mainWindow.Top + 200;    // Y coordinate relative to MainWindow
            }
            else if (_textBoxNo == 2)
            {
                this.Left = mainWindow.Left + 200;  // X coordinate relative to MainWindow
                this.Top = mainWindow.Top + 200;    // Y coordinate relative to MainWindow
            }
        }

        private void NumericButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                KeyPressed?.Invoke(this, button.Content.ToString());
            }
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            KeyPressed?.Invoke(this, "Backspace");
        }

        private void SignChangeButton_Click(object sender, RoutedEventArgs e)
        {
            KeyPressed?.Invoke(this, "+/-");
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            // Handling for Slave 1
            if (_textBoxNo == 1 && _substationRegistrationMasterViewModel.LatitudeSlave1.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.LatitudeSlave1[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.LatitudeSlave1 += "0";
                }
            }
            else if (_textBoxNo == 2 && _substationRegistrationMasterViewModel.LongitudeSlave1.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.LongitudeSlave1[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.LongitudeSlave1 += "0";
                }
            }
            else if (_textBoxNo == 3 && _substationRegistrationMasterViewModel.ElevationSlave1.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.ElevationSlave1[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.ElevationSlave1 += "0";
                }
            }
            else if (_textBoxNo == 4 && _substationRegistrationMasterViewModel.PoleLengthSlave1.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.PoleLengthSlave1[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.PoleLengthSlave1 += "0";
                }
            }
            else if (_textBoxNo == 5 && _substationRegistrationMasterViewModel.Slave1AntennaIPAddress.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.Slave1AntennaIPAddress[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.Slave1AntennaIPAddress += "0";
                }
            }
            else if (_textBoxNo == 25 && _substationRegistrationMasterViewModel.AntennaNameSlave1.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.AntennaNameSlave1[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.AntennaNameSlave1 += "0";
                }
            }

            // Handling for Slave 2
            else if (_textBoxNo == 7 && _substationRegistrationMasterViewModel.LatitudeSlave2.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.LatitudeSlave2[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.LatitudeSlave2 += "0";
                }
            }
            else if (_textBoxNo == 8 && _substationRegistrationMasterViewModel.LongitudeSlave2.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.LongitudeSlave2[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.LongitudeSlave2 += "0";
                }
            }
            else if (_textBoxNo == 9 && _substationRegistrationMasterViewModel.ElevationSlave2.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.ElevationSlave2[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.ElevationSlave2 += "0";
                }
            }
            else if (_textBoxNo == 10 && _substationRegistrationMasterViewModel.PoleLengthSlave2.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.PoleLengthSlave2[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.PoleLengthSlave2 += "0";
                }
            }
            else if (_textBoxNo == 11 && _substationRegistrationMasterViewModel.Slave2AntennaIPAddress.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.Slave2AntennaIPAddress[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.Slave2AntennaIPAddress += "0";
                }
            }
            else if (_textBoxNo == 26 && _substationRegistrationMasterViewModel.AntennaNameSlave2.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.AntennaNameSlave2[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.AntennaNameSlave2 += "0";
                }
            }

            // Handling for Slave 3
            else if (_textBoxNo == 13 && _substationRegistrationMasterViewModel.LatitudeSlave3.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.LatitudeSlave3[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.LatitudeSlave3 += "0";
                }
            }
            else if (_textBoxNo == 14 && _substationRegistrationMasterViewModel.LongitudeSlave3.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.LongitudeSlave3[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.LongitudeSlave3 += "0";
                }
            }
            else if (_textBoxNo == 15 && _substationRegistrationMasterViewModel.ElevationSlave3.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.ElevationSlave3[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.ElevationSlave3 += "0";
                }
            }
            else if (_textBoxNo == 16 && _substationRegistrationMasterViewModel.PoleLengthSlave3.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.PoleLengthSlave3[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.PoleLengthSlave3 += "0";
                }
            }
            else if (_textBoxNo == 17 && _substationRegistrationMasterViewModel.Slave3AntennaIPAddress.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.Slave3AntennaIPAddress[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.Slave3AntennaIPAddress += "0";
                }
            }
            else if (_textBoxNo == 27 && _substationRegistrationMasterViewModel.AntennaNameSlave3.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.AntennaNameSlave3[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.AntennaNameSlave3 += "0";
                }
            }

            // Handling for Slave 4
            else if (_textBoxNo == 19 && _substationRegistrationMasterViewModel.LatitudeSlave4.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.LatitudeSlave4[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.LatitudeSlave4 += "0";
                }
            }
            else if (_textBoxNo == 20 && _substationRegistrationMasterViewModel.LongitudeSlave4.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.LongitudeSlave4[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.LongitudeSlave4 += "0";
                }
            }
            else if (_textBoxNo == 21 && _substationRegistrationMasterViewModel.ElevationSlave4.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.ElevationSlave4[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.ElevationSlave4 += "0";
                }
            }
            else if (_textBoxNo == 22 && _substationRegistrationMasterViewModel.PoleLengthSlave4.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.PoleLengthSlave4[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.PoleLengthSlave4 += "0";
                }
            }
            else if (_textBoxNo == 23 && _substationRegistrationMasterViewModel.Slave4AntennaIPAddress.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.Slave4AntennaIPAddress[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.Slave4AntennaIPAddress += "0";
                }
            }
            else if (_textBoxNo == 28 && _substationRegistrationMasterViewModel.AntennaNameSlave4.Length > 0)
            {
                if (_substationRegistrationMasterViewModel.AntennaNameSlave4[^1] == '.')
                {
                    _substationRegistrationMasterViewModel.AntennaNameSlave4 += "0";
                }
            }

            this.Close();
            _status = 1;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Handling for Slave 1
            if (_textBoxNo == 1)
            {
                _substationRegistrationMasterViewModel.LatitudeSlave1 = _backupString;
            }
            else if (_textBoxNo == 2)
            {
                _substationRegistrationMasterViewModel.LongitudeSlave1 = _backupString;
            }
            else if (_textBoxNo == 3)
            {
                _substationRegistrationMasterViewModel.ElevationSlave1 = _backupString;
            }
            else if (_textBoxNo == 4)
            {
                _substationRegistrationMasterViewModel.PoleLengthSlave1 = _backupString;
            }
            else if (_textBoxNo == 5)
            {
                _substationRegistrationMasterViewModel.Slave1AntennaIPAddress = _backupString;
            }
            else if (_textBoxNo == 25)
            {
                _substationRegistrationMasterViewModel.AntennaNameSlave1 = _backupString;
            }

            // Handling for Slave 2
            else if (_textBoxNo == 7)
            {
                _substationRegistrationMasterViewModel.LatitudeSlave2 = _backupString;
            }
            else if (_textBoxNo == 8)
            {
                _substationRegistrationMasterViewModel.LongitudeSlave2 = _backupString;
            }
            else if (_textBoxNo == 9)
            {
                _substationRegistrationMasterViewModel.ElevationSlave2 = _backupString;
            }
            else if (_textBoxNo == 10)
            {
                _substationRegistrationMasterViewModel.PoleLengthSlave2 = _backupString;
            }
            else if (_textBoxNo == 11)
            {
                _substationRegistrationMasterViewModel.Slave2AntennaIPAddress = _backupString;
            }
            else if (_textBoxNo == 26)
            {
                _substationRegistrationMasterViewModel.AntennaNameSlave2 = _backupString;
            }

            // Handling for Slave 3
            else if (_textBoxNo == 13)
            {
                _substationRegistrationMasterViewModel.LatitudeSlave3 = _backupString;
            }
            else if (_textBoxNo == 14)
            {
                _substationRegistrationMasterViewModel.LongitudeSlave3 = _backupString;
            }
            else if (_textBoxNo == 15)
            {
                _substationRegistrationMasterViewModel.ElevationSlave3 = _backupString;
            }
            else if (_textBoxNo == 16)
            {
                _substationRegistrationMasterViewModel.PoleLengthSlave3 = _backupString;
            }
            else if (_textBoxNo == 17)
            {
                _substationRegistrationMasterViewModel.Slave3AntennaIPAddress = _backupString;
            }
            else if (_textBoxNo == 27)
            {
                _substationRegistrationMasterViewModel.AntennaNameSlave3 = _backupString;
            }

            // Handling for Slave 4
            else if (_textBoxNo == 19)
            {
                _substationRegistrationMasterViewModel.LatitudeSlave4 = _backupString;
            }
            else if (_textBoxNo == 20)
            {
                _substationRegistrationMasterViewModel.LongitudeSlave4 = _backupString;
            }
            else if (_textBoxNo == 21)
            {
                _substationRegistrationMasterViewModel.ElevationSlave4 = _backupString;
            }
            else if (_textBoxNo == 22)
            {
                _substationRegistrationMasterViewModel.PoleLengthSlave4 = _backupString;
            }
            else if (_textBoxNo == 23)
            {
                _substationRegistrationMasterViewModel.Slave4AntennaIPAddress = _backupString;
            }
            else if (_textBoxNo == 28)
            {
                _substationRegistrationMasterViewModel.AntennaNameSlave4 = _backupString;
            }

            _status = 0;
            this.Close();
            Keyboard.ClearFocus();
        }

    }

}
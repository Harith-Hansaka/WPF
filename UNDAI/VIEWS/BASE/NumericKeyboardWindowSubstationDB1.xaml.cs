using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UNDAI.VIEWMODELS.MASTER;

namespace UNDAI.VIEWS.BASE
{
    /// <summary>
    /// Interaction logic for NumericKeyboardWindowSubstationDB1.xaml
    /// </summary>
    public partial class NumericKeyboardWindowSubstationDB1 : Window
    {
        public event EventHandler<string> KeyPressed;
        public int _textBoxNo;
        public int _status = 0;
        string _backupString;
        private SubstationDB1MasterViewModel _substationDB1MasterViewModel;

        public NumericKeyboardWindowSubstationDB1(int TextBoxNo, SubstationDB1MasterViewModel substationDB1MasterViewModel, string backupString)
        {
            InitializeComponent();
            //Loaded += OnWindowLoaded;
            _textBoxNo = TextBoxNo;
            _backupString = backupString;
            _substationDB1MasterViewModel = substationDB1MasterViewModel;
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

            // Calculate the center of the main window
            this.Left = mainWindow.Left + (mainWindow.Width - this.Width) / 2;
            this.Top = mainWindow.Top + (mainWindow.Height - this.Height) / 2;
        }

        private void NumericButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                KeyPressed?.Invoke(this, button.Content.ToString());
            }
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (_textBoxNo == 1 && _substationDB1MasterViewModel.LatitudeSlave1.Length > 0)
            {
                if (_substationDB1MasterViewModel.LatitudeSlave1[_substationDB1MasterViewModel.LatitudeSlave1.Length - 1] == '.')
                {
                    _substationDB1MasterViewModel.LatitudeSlave1 = _substationDB1MasterViewModel.LatitudeSlave1 + "0";
                }
            }
            else if (_textBoxNo == 2 && _substationDB1MasterViewModel.LongitudeSlave1.Length > 0)
            {
                if (_substationDB1MasterViewModel.LongitudeSlave1[_substationDB1MasterViewModel.LongitudeSlave1.Length - 1] == '.')
                {
                    _substationDB1MasterViewModel.LongitudeSlave1 = _substationDB1MasterViewModel.LongitudeSlave1 + "0";
                }
            }
            else if (_textBoxNo == 3 && _substationDB1MasterViewModel.ElevationSlave1.Length > 0)
            {
                if (_substationDB1MasterViewModel.ElevationSlave1[_substationDB1MasterViewModel.ElevationSlave1.Length - 1] == '.')
                {
                    _substationDB1MasterViewModel.ElevationSlave1 = _substationDB1MasterViewModel.ElevationSlave1 + "0";
                }
            }
            else if (_textBoxNo == 4 && _substationDB1MasterViewModel.PoleHeight.Length > 0)
            {
                if (_substationDB1MasterViewModel.PoleHeight[_substationDB1MasterViewModel.PoleHeight.Length - 1] == '.')
                {
                    _substationDB1MasterViewModel.PoleHeight = _substationDB1MasterViewModel.PoleHeight + "0";
                }
            }
            else if (_textBoxNo == 5 && _substationDB1MasterViewModel.Slave1AntennaIPAddress.Length > 0)
            {
                if (_substationDB1MasterViewModel.Slave1AntennaIPAddress[_substationDB1MasterViewModel.Slave1AntennaIPAddress.Length - 1] == '.')
                {
                    _substationDB1MasterViewModel.Slave1AntennaIPAddress = _substationDB1MasterViewModel.Slave1AntennaIPAddress + "0";
                }
            }
            this.Close();
            _status = 1;
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            KeyPressed?.Invoke(this, "Backspace");
        }

        private void SignChangeButton_Click(object sender, RoutedEventArgs e)
        {
            KeyPressed?.Invoke(this, "+/-");
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_textBoxNo == 1)
            {
                _substationDB1MasterViewModel.LatitudeSlave1 = _backupString;
            }
            else if (_textBoxNo == 2)
            {
                _substationDB1MasterViewModel.LongitudeSlave1 = _backupString;
            }
            else if (_textBoxNo == 3)
            {
                _substationDB1MasterViewModel.ElevationSlave1 = _backupString;
            }
            else if (_textBoxNo == 4)
            {
                _substationDB1MasterViewModel.PoleHeight = _backupString;
            }
            else if (_textBoxNo == 5)
            {
                _substationDB1MasterViewModel.Slave1AntennaIPAddress = _backupString;
            }
            _status = 0;
            this.Close();
            Keyboard.ClearFocus();
        }

    }

}
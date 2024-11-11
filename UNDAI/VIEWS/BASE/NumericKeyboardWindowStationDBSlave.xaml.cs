using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.VIEWS.SLAVE;

namespace UNDAI.VIEWS.BASE
{
    /// <summary>
    /// Interaction logic for NumericKeyboardWindowStationDBSlave.xaml
    /// </summary>
    public partial class NumericKeyboardWindowStationDBSlave : Window
    {
        public event EventHandler<string> KeyPressed;
        public int _textBoxNo;
        public int _status = 0;
        string _backupString;
        private StationDBPageSlaveViewModel _stationDBPageSlaveViewModel;

        public NumericKeyboardWindowStationDBSlave(int TextBoxNo, StationDBPageSlaveViewModel stationDBPageSlaveViewModel, string backupString)
        {
            InitializeComponent();
            //Loaded += OnWindowLoaded;
            _textBoxNo = TextBoxNo;
            _backupString = backupString;
            _stationDBPageSlaveViewModel = stationDBPageSlaveViewModel;
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
            //if (_textBoxNo == 1)
            //{
            //    this.Left = mainWindow.Left + 500;  // X coordinate relative to MainWindow
            //    this.Top = mainWindow.Top + 200;    // Y coordinate relative to MainWindow
            //}
            //else if (_textBoxNo == 2)
            //{
            //    this.Left = mainWindow.Left + 200;  // X coordinate relative to MainWindow
            //    this.Top = mainWindow.Top + 200;    // Y coordinate relative to MainWindow
            //}

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
            if (_textBoxNo == 1 && _stationDBPageSlaveViewModel.LatitudeSlave.Length >0)
            {
                if (_stationDBPageSlaveViewModel.LatitudeSlave[_stationDBPageSlaveViewModel.LatitudeSlave.Length - 1] == '.')
                {
                    _stationDBPageSlaveViewModel.LatitudeSlave = _stationDBPageSlaveViewModel.LatitudeSlave + "0";
                }
            }
            else if (_textBoxNo == 2 && _stationDBPageSlaveViewModel.LongitudeSlave.Length > 0)
            {
                if (_stationDBPageSlaveViewModel.LongitudeSlave[_stationDBPageSlaveViewModel.LongitudeSlave.Length - 1] == '.')
                {
                    _stationDBPageSlaveViewModel.LongitudeSlave = _stationDBPageSlaveViewModel.LongitudeSlave + "0";
                }
            }
            else if (_textBoxNo == 3 && _stationDBPageSlaveViewModel.ElevationSlave.Length > 0)
            {
                if (_stationDBPageSlaveViewModel.ElevationSlave[_stationDBPageSlaveViewModel.ElevationSlave.Length - 1] == '.')
                {
                    _stationDBPageSlaveViewModel.ElevationSlave = _stationDBPageSlaveViewModel.ElevationSlave + "0";
                }
            }
            else if (_textBoxNo == 4 && _stationDBPageSlaveViewModel.PoleHeight.Length > 0)
            {
                if (_stationDBPageSlaveViewModel.PoleHeight[_stationDBPageSlaveViewModel.PoleHeight.Length - 1] == '.')
                {
                    _stationDBPageSlaveViewModel.PoleHeight = _stationDBPageSlaveViewModel.PoleHeight + "0";
                }
            }
            else if (_textBoxNo == 5 && _stationDBPageSlaveViewModel.InstallationOrientation.Length > 0)
            {
                if (_stationDBPageSlaveViewModel.InstallationOrientation[_stationDBPageSlaveViewModel.InstallationOrientation.Length - 1] == '.')
                {
                    _stationDBPageSlaveViewModel.InstallationOrientation = _stationDBPageSlaveViewModel.InstallationOrientation + "0";
                }
            }
            else if (_textBoxNo == 6 && _stationDBPageSlaveViewModel.HeadIPAddress.Length > 0)
            {
                if (_stationDBPageSlaveViewModel.HeadIPAddress[_stationDBPageSlaveViewModel.HeadIPAddress.Length - 1] == '.')
                {
                    _stationDBPageSlaveViewModel.HeadIPAddress = _stationDBPageSlaveViewModel.HeadIPAddress + "0";
                }
            }
            this.Close();
            _status = 1;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_textBoxNo == 1)
            {
                _stationDBPageSlaveViewModel.LatitudeSlave = _backupString;
            }
            else if (_textBoxNo == 2)
            {
                _stationDBPageSlaveViewModel.LongitudeSlave = _backupString;
            }
            else if (_textBoxNo == 3)
            {
                _stationDBPageSlaveViewModel.ElevationSlave = _backupString;
            }
            else if (_textBoxNo == 4)
            {
                _stationDBPageSlaveViewModel.PoleHeight = _backupString;
            }
            else if (_textBoxNo == 5)
            {
                _stationDBPageSlaveViewModel.InstallationOrientation = _backupString;
            }
            else if (_textBoxNo == 6)
            {
                _stationDBPageSlaveViewModel.HeadIPAddress = _backupString;
            }
            _status = 0;
            this.Close();
            Keyboard.ClearFocus();
        }

    }

}
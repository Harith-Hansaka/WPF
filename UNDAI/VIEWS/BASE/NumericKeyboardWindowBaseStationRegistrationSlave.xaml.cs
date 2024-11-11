using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWMODELS.SLAVE;

namespace UNDAI.VIEWS.BASE
{
    /// <summary>
    /// Interaction logic for NumericKeyboardWindowBaseStationRegistrationSlave.xaml
    /// </summary>
    public partial class NumericKeyboardWindowBaseStationRegistrationSlave : Window
    {
        public event EventHandler<string> KeyPressed;
        public int _textBoxNo;
        public int _status = 0;
        string _backupString;
        private BaseStationRegistrationSlaveViewModel _baseStationRegistrationSlaveViewModel;

        public NumericKeyboardWindowBaseStationRegistrationSlave(int TextBoxNo, BaseStationRegistrationSlaveViewModel baseStationRegistrationSlaveViewModel, string backupString)
        {
            InitializeComponent();
            //Loaded += OnWindowLoaded;
            _textBoxNo = TextBoxNo;
            _backupString = backupString;
            _baseStationRegistrationSlaveViewModel = baseStationRegistrationSlaveViewModel;
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
            if (_textBoxNo == 1 && _baseStationRegistrationSlaveViewModel.LatitudeMaster.Length > 0)
            {
                if (_baseStationRegistrationSlaveViewModel.LatitudeMaster[_baseStationRegistrationSlaveViewModel.LatitudeMaster.Length - 1] == '.')
                {
                    _baseStationRegistrationSlaveViewModel.LatitudeMaster = _baseStationRegistrationSlaveViewModel.LatitudeMaster + "0";
                }
            }
            else if (_textBoxNo == 2 && _baseStationRegistrationSlaveViewModel.LongitudeMaster.Length > 0)
            {
                if (_baseStationRegistrationSlaveViewModel.LongitudeMaster[_baseStationRegistrationSlaveViewModel.LongitudeMaster.Length - 1] == '.')
                {
                    _baseStationRegistrationSlaveViewModel.LongitudeMaster = _baseStationRegistrationSlaveViewModel.LongitudeMaster + "0";
                }
            }
            else if (_textBoxNo == 3 && _baseStationRegistrationSlaveViewModel.ElevationMaster.Length > 0)
            {
                if (_baseStationRegistrationSlaveViewModel.ElevationMaster[_baseStationRegistrationSlaveViewModel.ElevationMaster.Length - 1] == '.')
                {
                    _baseStationRegistrationSlaveViewModel.ElevationMaster = _baseStationRegistrationSlaveViewModel.ElevationMaster + "0";
                }
            }
            else if (_textBoxNo == 4 && _baseStationRegistrationSlaveViewModel.PoleHeight.Length > 0)
            {
                if (_baseStationRegistrationSlaveViewModel.PoleHeight[_baseStationRegistrationSlaveViewModel.PoleHeight.Length - 1] == '.')
                {
                    _baseStationRegistrationSlaveViewModel.PoleHeight = _baseStationRegistrationSlaveViewModel.PoleHeight + "0";
                }
            }
            else if (_textBoxNo == 5 && _baseStationRegistrationSlaveViewModel.MasterAntennaName.Length > 0)
            {
                if (_baseStationRegistrationSlaveViewModel.MasterAntennaName[_baseStationRegistrationSlaveViewModel.MasterAntennaName.Length - 1] == '.')
                {
                    _baseStationRegistrationSlaveViewModel.MasterAntennaName = _baseStationRegistrationSlaveViewModel.MasterAntennaName + "0";
                }
            }
            this.Close();
            _status = 1;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_textBoxNo == 1)
            {
                _baseStationRegistrationSlaveViewModel.LatitudeMaster = _backupString;
            }
            else if (_textBoxNo == 2)
            {
                _baseStationRegistrationSlaveViewModel.LongitudeMaster = _backupString;
            }
            else if (_textBoxNo == 3)
            {
                _baseStationRegistrationSlaveViewModel.ElevationMaster = _backupString;
            }
            else if (_textBoxNo == 4)
            {
                _baseStationRegistrationSlaveViewModel.PoleHeight = _backupString;
            }
            else if (_textBoxNo == 5)
            {
                _baseStationRegistrationSlaveViewModel.MasterAntennaName = _backupString;
            }
            _status = 0;
            this.Close();
            Keyboard.ClearFocus();
        }
    }
}
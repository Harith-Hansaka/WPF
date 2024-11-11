using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UNDAI.VIEWMODELS.SLAVE;

namespace UNDAI.VIEWS.BASE
{
    /// <summary>
    /// Interaction logic for NumericKeyboardWindowSelfRegSlave.xaml
    /// </summary>
    public partial class NumericKeyboardWindowSelfRegSlave : Window
    {
        public event EventHandler<string> KeyPressed;
        public int _textBoxNo;
        public int _status = 0;
        string _backupString;
        private SelfRegPageSlaveViewModel _selfRegPageSlaveViewModel;

        public NumericKeyboardWindowSelfRegSlave(int TextBoxNo, SelfRegPageSlaveViewModel selfRegPageSlaveViewModel, string backupString)
        {
            InitializeComponent();
            //Loaded += OnWindowLoaded;
            _textBoxNo = TextBoxNo;
            _backupString = backupString;
            _selfRegPageSlaveViewModel = selfRegPageSlaveViewModel;
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
            if (_textBoxNo == 1 && _selfRegPageSlaveViewModel.LatitudeSlave.Length > 0)
            {
                if (_selfRegPageSlaveViewModel.LatitudeSlave[_selfRegPageSlaveViewModel.LatitudeSlave.Length - 1] == '.')
                {
                    _selfRegPageSlaveViewModel.LatitudeSlave = _selfRegPageSlaveViewModel.LatitudeSlave + "0";
                }
            }
            else if (_textBoxNo == 2 && _selfRegPageSlaveViewModel.LongitudeSlave.Length > 0)
            {
                if (_selfRegPageSlaveViewModel.LongitudeSlave[_selfRegPageSlaveViewModel.LongitudeSlave.Length - 1] == '.')
                {
                    _selfRegPageSlaveViewModel.LongitudeSlave = _selfRegPageSlaveViewModel.LongitudeSlave + "0";
                }
            }
            else if (_textBoxNo == 3 && _selfRegPageSlaveViewModel.ElevationSlave.Length > 0)
            {
                if (_selfRegPageSlaveViewModel.ElevationSlave[_selfRegPageSlaveViewModel.ElevationSlave.Length - 1] == '.')
                {
                    _selfRegPageSlaveViewModel.ElevationSlave = _selfRegPageSlaveViewModel.ElevationSlave + "0";
                }
            }
            else if (_textBoxNo == 4 && _selfRegPageSlaveViewModel.PoleHeight.Length > 0)
            {
                if (_selfRegPageSlaveViewModel.PoleHeight[_selfRegPageSlaveViewModel.PoleHeight.Length - 1] == '.')
                {
                    _selfRegPageSlaveViewModel.PoleHeight = _selfRegPageSlaveViewModel.PoleHeight + "0";
                }
            }
            else if (_textBoxNo == 5 && _selfRegPageSlaveViewModel.InstallationOrientation.Length > 0)
            {
                if (_selfRegPageSlaveViewModel.InstallationOrientation[_selfRegPageSlaveViewModel.InstallationOrientation.Length - 1] == '.')
                {
                    _selfRegPageSlaveViewModel.InstallationOrientation = _selfRegPageSlaveViewModel.InstallationOrientation + "0";
                }
            }
            else if (_textBoxNo == 6 && _selfRegPageSlaveViewModel.HeadIPAddress.Length > 0)
            {
                if (_selfRegPageSlaveViewModel.HeadIPAddress[_selfRegPageSlaveViewModel.HeadIPAddress.Length - 1] == '.')
                {
                    _selfRegPageSlaveViewModel.HeadIPAddress = _selfRegPageSlaveViewModel.HeadIPAddress + "0";
                }
            }
            this.Close();
            _status = 1;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_textBoxNo == 1)
            {
                _selfRegPageSlaveViewModel.LatitudeSlave = _backupString;
            }
            else if (_textBoxNo == 2)
            {
                _selfRegPageSlaveViewModel.LongitudeSlave = _backupString;
            }
            else if (_textBoxNo == 3)
            {
                _selfRegPageSlaveViewModel.ElevationSlave = _backupString;
            }
            else if (_textBoxNo == 4)
            {
                _selfRegPageSlaveViewModel.PoleHeight = _backupString;
            }
            else if (_textBoxNo == 5)
            {
                _selfRegPageSlaveViewModel.InstallationOrientation = _backupString;
            }
            else if (_textBoxNo == 6)
            {
                _selfRegPageSlaveViewModel.HeadIPAddress = _backupString;
            }
            _status = 0;
            this.Close();
            Keyboard.ClearFocus();
        }

    }

}
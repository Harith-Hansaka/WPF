using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UNDAI.VIEWMODELS.MASTER;

namespace UNDAI.VIEWS.BASE
{
    /// <summary>
    /// Interaction logic for NumericKeyboardWindowSelfRegMaster.xaml
    /// </summary>
    public partial class NumericKeyboardWindowSelfRegMaster : Window
    {
        public event EventHandler<string> KeyPressed;
        public int _textBoxNo;
        public int _status = 0;
        string _backupString;
        private SelfRegPageMasterViewModel _selfRegPageMasterViewModel;

        public NumericKeyboardWindowSelfRegMaster(int TextBoxNo, SelfRegPageMasterViewModel selfRegPageMasterViewModel, string backupString)
        {
            InitializeComponent();
            //Loaded += OnWindowLoaded;
            _textBoxNo = TextBoxNo;
            _backupString = backupString;
            _selfRegPageMasterViewModel = selfRegPageMasterViewModel;
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
            if (_textBoxNo == 1 && _selfRegPageMasterViewModel.LatitudeMaster.Length > 0)
            {
                if (_selfRegPageMasterViewModel.LatitudeMaster[_selfRegPageMasterViewModel.LatitudeMaster.Length - 1] == '.')
                {
                    _selfRegPageMasterViewModel.LatitudeMaster = _selfRegPageMasterViewModel.LatitudeMaster + "0";
                }
            }
            else if (_textBoxNo == 2 && _selfRegPageMasterViewModel.LongitudeMaster.Length > 0)
            {
                if (_selfRegPageMasterViewModel.LongitudeMaster[_selfRegPageMasterViewModel.LongitudeMaster.Length - 1] == '.')
                {
                    _selfRegPageMasterViewModel.LongitudeMaster = _selfRegPageMasterViewModel.LongitudeMaster + "0";
                }
            }
            else if (_textBoxNo == 3 && _selfRegPageMasterViewModel.ElevationMaster.Length > 0)
            {
                if (_selfRegPageMasterViewModel.ElevationMaster[_selfRegPageMasterViewModel.ElevationMaster.Length - 1] == '.')
                {
                    _selfRegPageMasterViewModel.ElevationMaster = _selfRegPageMasterViewModel.ElevationMaster + "0";
                }
            }
            else if (_textBoxNo == 4 && _selfRegPageMasterViewModel.PoleHeight.Length > 0)
            {
                if (_selfRegPageMasterViewModel.PoleHeight[_selfRegPageMasterViewModel.PoleHeight.Length - 1] == '.')
                {
                    _selfRegPageMasterViewModel.PoleHeight = _selfRegPageMasterViewModel.PoleHeight + "0";
                }
            }
            else if (_textBoxNo == 5 && _selfRegPageMasterViewModel.InstallationOrientation.Length > 0)
            {
                if (_selfRegPageMasterViewModel.InstallationOrientation[_selfRegPageMasterViewModel.InstallationOrientation.Length - 1] == '.')
                {
                    _selfRegPageMasterViewModel.InstallationOrientation = _selfRegPageMasterViewModel.InstallationOrientation + "0";
                }
            }
            else if (_textBoxNo == 6 && _selfRegPageMasterViewModel.HeadIPAddress.Length > 0)
            {
                if (_selfRegPageMasterViewModel.HeadIPAddress[_selfRegPageMasterViewModel.HeadIPAddress.Length - 1] == '.')
                {
                    _selfRegPageMasterViewModel.HeadIPAddress = _selfRegPageMasterViewModel.HeadIPAddress + "0";
                }
            }
            this.Close();
            _status = 1;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_textBoxNo == 1)
            {
                _selfRegPageMasterViewModel.LatitudeMaster = _backupString;
            }
            else if (_textBoxNo == 2)
            {
                _selfRegPageMasterViewModel.LongitudeMaster = _backupString;
            }
            else if (_textBoxNo == 3)
            {
                _selfRegPageMasterViewModel.ElevationMaster = _backupString;
            }
            else if (_textBoxNo == 4)
            {
                _selfRegPageMasterViewModel.PoleHeight = _backupString;
            }
            else if (_textBoxNo == 5)
            {
                _selfRegPageMasterViewModel.InstallationOrientation = _backupString;
            }
            else if (_textBoxNo == 6)
            {
                _selfRegPageMasterViewModel.HeadIPAddress = _backupString;
            }
            _status = 0;
            this.Close();
            Keyboard.ClearFocus();
        }

    }

}
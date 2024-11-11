using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using UNDAI.VIEWMODELS;
using UNDAI.VIEWMODELS.MASTER;

namespace UNDAI.VIEWS.BASE
{
    /// <summary>
    /// Interaction logic for NumericKeyboardWindowMainMaster.xaml
    /// </summary>
    public partial class NumericKeyboardWindowMainMaster : Window
    {
        public event EventHandler<string> KeyPressed;
        public int _textBoxNo;
        public int _status = 0;
        string _backupString;
        private MainPageMasterViewModel _mainPageMasterViewModel;

        public NumericKeyboardWindowMainMaster(int TextBoxNo, MainPageMasterViewModel mainPageMasterViewModel, string backupString)
        {
            InitializeComponent();
            Loaded += OnWindowLoaded;
            _textBoxNo = TextBoxNo;
            _backupString = backupString;
            _mainPageMasterViewModel = mainPageMasterViewModel;
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
            //this.Left = mainWindow.Left + (mainWindow.Width - this.Width) / 2;
            //this.Top = mainWindow.Top + (mainWindow.Height - this.Height) / 2;
            if (_textBoxNo == 2)
            {
                this.Left = mainWindow.Left + 200;  // X coordinate relative to MainWindow
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
            if (_textBoxNo == 1 && _mainPageMasterViewModel.ElevationAngleInputMaster.Length > 0)
            {
                if (_mainPageMasterViewModel.ElevationAngleInputMaster[_mainPageMasterViewModel.ElevationAngleInputMaster.Length - 1] == '.')
                {
                    _mainPageMasterViewModel.ElevationAngleInputMaster = _mainPageMasterViewModel.ElevationAngleInputMaster + "0";
                }
            }
            else if (_textBoxNo == 2 && _mainPageMasterViewModel.AzimuthAngleInputMaster.Length > 0)
            {
                if (_mainPageMasterViewModel.AzimuthAngleInputMaster[_mainPageMasterViewModel.AzimuthAngleInputMaster.Length - 1] == '.')
                {
                    _mainPageMasterViewModel.AzimuthAngleInputMaster = _mainPageMasterViewModel.AzimuthAngleInputMaster + "0";
                }
            }
            else if (_textBoxNo == 3 && _mainPageMasterViewModel.SystemUnlockPIN.Length > 0)
            {
                if (_mainPageMasterViewModel.SystemUnlockPIN[^1] == '.')
                {
                    _mainPageMasterViewModel.SystemUnlockPIN =
                        _mainPageMasterViewModel.SystemUnlockPIN.Remove(_mainPageMasterViewModel.SystemUnlockPIN.Length - 1);
                }
                _mainPageMasterViewModel.PINKeyboardClose = true;
                _mainPageMasterViewModel.MainPageMasterModel.PINCheck(_mainPageMasterViewModel.SystemUnlockPIN);
            }
            this.Close();
            _status = 1;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_textBoxNo == 1)
            {
                _mainPageMasterViewModel.ElevationAngleInputMaster = _backupString;
            }
            else if (_textBoxNo == 2)
            {
                _mainPageMasterViewModel.AzimuthAngleInputMaster = _backupString;
            }
            _status = 0;
            this.Close();
            Keyboard.ClearFocus();
        }

    }

}
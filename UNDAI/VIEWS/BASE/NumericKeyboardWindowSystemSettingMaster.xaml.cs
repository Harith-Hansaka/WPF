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
    /// Interaction logic for NumericKeyboardWindowSystemSettingMaster.xaml
    /// </summary>
    public partial class NumericKeyboardWindowSystemSettingMaster : Window
    {
        public event EventHandler<string> KeyPressed;
        public int _textBoxNo;
        public int _status = 0;
        string _backupString;
        private SystemSettingMasterViewModel _systemSettingMasterViewModel;

        public NumericKeyboardWindowSystemSettingMaster
        (
            int TextBoxNo,
            SystemSettingMasterViewModel systemSettingMasterViewModel,
            string backupString
        )
        {
            InitializeComponent();
            //Loaded += OnWindowLoaded;
            _textBoxNo = TextBoxNo;
            _backupString = backupString;
            _systemSettingMasterViewModel = systemSettingMasterViewModel;
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
            //if (_textBoxNo == 1 || _textBoxNo == 19 || _textBoxNo == 20 || _textBoxNo == 21)
            //{
            //    this.Left = mainWindow.Left + 1200;  // X coordinate relative to MainWindow
            //    this.Top = mainWindow.Top + 100;    // Y coordinate relative to MainWindow
            //}
            //else if (_textBoxNo == 3 || _textBoxNo == 5 || _textBoxNo == 7 || _textBoxNo == 9)
            //{
            //    this.Left = mainWindow.Left + 200;  // X coordinate relative to MainWindow
            //    this.Top = mainWindow.Top + 200;    // Y coordinate relative to MainWindow
            //}
            //else if (_textBoxNo == 2 || _textBoxNo == 4 || _textBoxNo == 6 || _textBoxNo == 8)
            //{
            //    this.Left = mainWindow.Left + 800;  // X coordinate relative to MainWindow
            //    this.Top = mainWindow.Top + 200;    // Y coordinate relative to MainWindow
            //}
            //else if (_textBoxNo == 18)
            //{
            //    // Calculate the center of the main window
            //    this.Left = mainWindow.Left + (mainWindow.Width - this.Width) / 2;
            //    this.Top = mainWindow.Top - 150 +(mainWindow.Height - this.Height) / 2;
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
            if (_textBoxNo == 1 && _systemSettingMasterViewModel.UndaiIPAddress.Length > 0)
            {
                if (_systemSettingMasterViewModel.UndaiIPAddress[^1] == '.')
                {
                    _systemSettingMasterViewModel.UndaiIPAddress += "0";
                }
            }
            else if (_textBoxNo == 2 && _systemSettingMasterViewModel.OriginOffsetAzimuth.Length > 0)
            {
                if (_systemSettingMasterViewModel.OriginOffsetAzimuth[^1] == '.')
                {
                    _systemSettingMasterViewModel.OriginOffsetAzimuth += "0";
                }
            }
            if (_textBoxNo == 3 && _systemSettingMasterViewModel.OriginOffsetElevation.Length > 0)
            {
                if (_systemSettingMasterViewModel.OriginOffsetElevation[^1] == '.')
                {
                    _systemSettingMasterViewModel.OriginOffsetElevation += "0";
                }
            }
            if (_textBoxNo == 4 && _systemSettingMasterViewModel.HighSpeedSetAzimuth.Length > 0)
            {
                if (_systemSettingMasterViewModel.HighSpeedSetAzimuth[^1] == '.')
                {
                    _systemSettingMasterViewModel.HighSpeedSetAzimuth += "0";
                }
            }
            else if (_textBoxNo == 5 && _systemSettingMasterViewModel.HighSpeedSetElevation.Length > 0)
            {
                if (_systemSettingMasterViewModel.HighSpeedSetElevation[^1] == '.')
                {
                    _systemSettingMasterViewModel.HighSpeedSetElevation += "0";
                }
            }
            else if (_textBoxNo == 6 && _systemSettingMasterViewModel.LowSpeedSetAzimuth.Length > 0)
            {
                if (_systemSettingMasterViewModel.LowSpeedSetAzimuth[^1] == '.')
                {
                    _systemSettingMasterViewModel.LowSpeedSetAzimuth += "0";
                }
            }
            if (_textBoxNo == 7 && _systemSettingMasterViewModel.LowSpeedSetElevation.Length > 0)
            {
                if (_systemSettingMasterViewModel.LowSpeedSetElevation[^1] == '.')
                {
                    _systemSettingMasterViewModel.LowSpeedSetElevation += "0";
                }
            }
            else if (_textBoxNo == 8 && _systemSettingMasterViewModel.InchingSpeedSetAzimuth.Length > 0)
            {
                if (_systemSettingMasterViewModel.InchingSpeedSetAzimuth[^1] == '.')
                {
                    _systemSettingMasterViewModel.InchingSpeedSetAzimuth += "0";
                }
            }
            else if (_textBoxNo == 9 && _systemSettingMasterViewModel.InchingSpeedSetElevation.Length > 0)
            {
                if (_systemSettingMasterViewModel.InchingSpeedSetElevation[^1] == '.')
                {
                    _systemSettingMasterViewModel.InchingSpeedSetElevation += "0";
                }
            }
            else if (_textBoxNo == 10 && _systemSettingMasterViewModel.PeakSearchSpeed.Length > 0)
            {
                if (_systemSettingMasterViewModel.PeakSearchSpeed[^1] == '.')
                {
                    _systemSettingMasterViewModel.PeakSearchSpeed += "0";
                }
            }
            else if (_textBoxNo == 11 && _systemSettingMasterViewModel.PeakSearchAzimuth.Length > 0)
            {
                if (_systemSettingMasterViewModel.PeakSearchAzimuth[^1] == '.')
                {
                    _systemSettingMasterViewModel.PeakSearchAzimuth += "0";
                }
            }
            else if (_textBoxNo == 12 && _systemSettingMasterViewModel.PeakSearchElevation.Length > 0)
            {
                if (_systemSettingMasterViewModel.PeakSearchElevation[^1] == '.')
                {
                    _systemSettingMasterViewModel.PeakSearchElevation += "0";
                }
            }
            if (_textBoxNo == 13 && _systemSettingMasterViewModel.PeakSearchRSSILevel.Length > 0)
            {
                if (_systemSettingMasterViewModel.PeakSearchRSSILevel[^1] == '.')
                {
                    _systemSettingMasterViewModel.PeakSearchRSSILevel += "0";
                }
            }
            else if (_textBoxNo == 14 && _systemSettingMasterViewModel.DetailedPeakSearchStepAngle.Length > 0)
            {
                if (_systemSettingMasterViewModel.DetailedPeakSearchStepAngle[^1] == '.')
                {
                    _systemSettingMasterViewModel.DetailedPeakSearchStepAngle += "0";
                }
            }
            else if (_textBoxNo == 15 && _systemSettingMasterViewModel.DetailedPeakSearchRSSILevel.Length > 0)
            {
                if (_systemSettingMasterViewModel.DetailedPeakSearchRSSILevel[^1] == '.')
                {
                    _systemSettingMasterViewModel.DetailedPeakSearchRSSILevel += "0";
                }
            }
            else if (_textBoxNo == 16 && _systemSettingMasterViewModel.StepStability.Length > 0)
            {
                if (_systemSettingMasterViewModel.StepStability[^1] == '.')
                {
                    _systemSettingMasterViewModel.StepStability += "0";
                }
            }
            else if (_textBoxNo == 17 && _systemSettingMasterViewModel.ContinuousOperationTime.Length > 0)
            {
                if (_systemSettingMasterViewModel.ContinuousOperationTime[^1] == '.')
                {
                    _systemSettingMasterViewModel.ContinuousOperationTime += "0";
                }
            }
            if (_textBoxNo == 18 && _systemSettingMasterViewModel.SystemUnlockPIN.Length > 0)
            {
                if (_systemSettingMasterViewModel.SystemUnlockPIN[^1] == '.')
                {
                    _systemSettingMasterViewModel.SystemUnlockPIN =
                        _systemSettingMasterViewModel.SystemUnlockPIN.Remove(_systemSettingMasterViewModel.SystemUnlockPIN.Length - 1);
                }
                _systemSettingMasterViewModel.PINKeyboardClose = true;
                _systemSettingMasterViewModel._systemSettingMasterModel.PINCheck(_systemSettingMasterViewModel.SystemUnlockPIN);
                _systemSettingMasterViewModel.SystemUnlockPIN = new string('*', _systemSettingMasterViewModel.SystemUnlockPIN.Length);

            }
            else if (_textBoxNo == 19 && _systemSettingMasterViewModel.UndaiSubnet.Length > 0)
            {
                if (_systemSettingMasterViewModel.UndaiSubnet[^1] == '.')
                {
                    _systemSettingMasterViewModel.UndaiSubnet += "0";
                }
            }
            else if (_textBoxNo == 20 && _systemSettingMasterViewModel.DefaultGateway.Length > 0)
            {
                if (_systemSettingMasterViewModel.DefaultGateway[^1] == '.')
                {
                    _systemSettingMasterViewModel.DefaultGateway += "0";
                }
            }
            else if (_textBoxNo == 21 && _systemSettingMasterViewModel.MasterAntennaIPAddress.Length > 0)
            {
                if (_systemSettingMasterViewModel.MasterAntennaIPAddress[^1] == '.')
                {
                    _systemSettingMasterViewModel.MasterAntennaIPAddress += "0";
                }
            }
            else if (_textBoxNo == 22 && _systemSettingMasterViewModel.PeakSearchRSSITurnLevel.Length > 0)
            {
                if (_systemSettingMasterViewModel.PeakSearchRSSITurnLevel[^1] == '.')
                {
                    _systemSettingMasterViewModel.PeakSearchRSSITurnLevel += "0";
                }
            }
            else if (_textBoxNo == 23 && _systemSettingMasterViewModel.PeakSearchRSSIDelay.Length > 0)
            {
                if (_systemSettingMasterViewModel.PeakSearchRSSIDelay[^1] == '.')
                {
                    _systemSettingMasterViewModel.PeakSearchRSSIDelay += "0";
                }
            }
            else if (_textBoxNo == 24 && _systemSettingMasterViewModel.UpDownSearchAngle.Length > 0)
            {
                if (_systemSettingMasterViewModel.UpDownSearchAngle[^1] == '.')
                {
                    _systemSettingMasterViewModel.UpDownSearchAngle += "0";
                }
            }
            else if (_textBoxNo == 25 && _systemSettingMasterViewModel.RSSITurnbackThresholdLevel.Length > 0)
            {
                if (_systemSettingMasterViewModel.RSSITurnbackThresholdLevel[^1] == '.')
                {
                    _systemSettingMasterViewModel.RSSITurnbackThresholdLevel += "0";
                }
            }

            this.Close();
            _status = 1;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_textBoxNo == 1)
            {
                _systemSettingMasterViewModel.UndaiIPAddress = _backupString;
            }
            else if (_textBoxNo == 2)
            {
                _systemSettingMasterViewModel.OriginOffsetAzimuth = _backupString;
            }
            else if (_textBoxNo == 3)
            {
                _systemSettingMasterViewModel.OriginOffsetElevation = _backupString;
            }
            else if (_textBoxNo == 4)
            {
                _systemSettingMasterViewModel.HighSpeedSetAzimuth = _backupString;
            }
            else if (_textBoxNo == 5)
            {
                _systemSettingMasterViewModel.HighSpeedSetElevation = _backupString;
            }
            else if (_textBoxNo == 6)
            {
                _systemSettingMasterViewModel.LowSpeedSetAzimuth = _backupString;
            }
            else if (_textBoxNo == 7)
            {
                _systemSettingMasterViewModel.LowSpeedSetElevation = _backupString;
            }
            else if (_textBoxNo == 8)
            {
                _systemSettingMasterViewModel.InchingSpeedSetAzimuth = _backupString;
            }
            else if (_textBoxNo == 9)
            {
                _systemSettingMasterViewModel.InchingSpeedSetElevation = _backupString;
            }
            else if (_textBoxNo == 10)
            {
                _systemSettingMasterViewModel.PeakSearchSpeed = _backupString;
            }
            else if (_textBoxNo == 11)
            {
                _systemSettingMasterViewModel.PeakSearchAzimuth = _backupString;
            }
            else if (_textBoxNo == 12)
            {
                _systemSettingMasterViewModel.PeakSearchElevation = _backupString;
            }
            else if (_textBoxNo == 13)
            {
                _systemSettingMasterViewModel.PeakSearchRSSILevel = _backupString;
            }
            else if (_textBoxNo == 14)
            {
                _systemSettingMasterViewModel.DetailedPeakSearchStepAngle = _backupString;
            }
            else if (_textBoxNo == 15)
            {
                _systemSettingMasterViewModel.DetailedPeakSearchRSSILevel = _backupString;
            }
            else if (_textBoxNo == 16)
            {
                _systemSettingMasterViewModel.StepStability = _backupString;
            }
            else if (_textBoxNo == 17)
            {
                _systemSettingMasterViewModel.ContinuousOperationTime = _backupString;
            }
            else if (_textBoxNo == 19)
            {
                _systemSettingMasterViewModel.UndaiSubnet = _backupString;
            }
            else if (_textBoxNo == 20)
            {
                _systemSettingMasterViewModel.DefaultGateway = _backupString;
            }
            else if (_textBoxNo == 21)
            {
                _systemSettingMasterViewModel.MasterAntennaIPAddress = _backupString;
            }
            else if (_textBoxNo == 22)
            {
                _systemSettingMasterViewModel.PeakSearchRSSITurnLevel = _backupString;
            }
            else if (_textBoxNo == 23)
            {
                _systemSettingMasterViewModel.PeakSearchRSSIDelay = _backupString;
            }
            else if (_textBoxNo == 24)
            {
                _systemSettingMasterViewModel.UpDownSearchAngle = _backupString;
            }
            else if (_textBoxNo == 25)
            {
                _systemSettingMasterViewModel.RSSITurnbackThresholdLevel = _backupString;
            }

            _status = 0;
            this.Close();
            Keyboard.ClearFocus();
        }
    }
}
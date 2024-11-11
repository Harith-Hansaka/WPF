using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWMODELS.SLAVE;

namespace UNDAI.VIEWS.BASE
{
    /// <summary>
    /// Interaction logic for NumericKeyboardWindowSystemSettingSlave.xaml
    /// </summary>
    public partial class NumericKeyboardWindowSystemSettingSlave : Window
    {
        public event EventHandler<string> KeyPressed;
        public int _textBoxNo;
        public int _status = 0;
        string _backupString;
        private SystemSettingSlaveViewModel _systemSettingSlaveViewModel;

        public NumericKeyboardWindowSystemSettingSlave
        (
            int TextBoxNo,
            SystemSettingSlaveViewModel systemSettingSlaveViewModel, 
            string backupString
        )
        {
            InitializeComponent();
            //Loaded += OnWindowLoaded;
            _textBoxNo = TextBoxNo;
            _backupString = backupString;
            _systemSettingSlaveViewModel = systemSettingSlaveViewModel;
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
            if (_textBoxNo == 1 && _systemSettingSlaveViewModel.UndaiIPAddress.Length > 0)
            {
                if (_systemSettingSlaveViewModel.UndaiIPAddress[^1] == '.')
                {
                    _systemSettingSlaveViewModel.UndaiIPAddress += "0";
                }
            }
            else if (_textBoxNo == 2 && _systemSettingSlaveViewModel.OriginOffsetAzimuth.Length > 0)
            {
                if (_systemSettingSlaveViewModel.OriginOffsetAzimuth[^1] == '.')
                {
                    _systemSettingSlaveViewModel.OriginOffsetAzimuth += "0";
                }
            }
            if (_textBoxNo == 3 && _systemSettingSlaveViewModel.OriginOffsetElevation.Length > 0)
            {
                if (_systemSettingSlaveViewModel.OriginOffsetElevation[^1] == '.')
                {
                    _systemSettingSlaveViewModel.OriginOffsetElevation += "0";
                }
            }
            if (_textBoxNo == 4 && _systemSettingSlaveViewModel.HighSpeedSetAzimuth.Length > 0)
            {
                if (_systemSettingSlaveViewModel.HighSpeedSetAzimuth[^1] == '.')
                {
                    _systemSettingSlaveViewModel.HighSpeedSetAzimuth += "0";
                }
            }
            else if (_textBoxNo == 5 && _systemSettingSlaveViewModel.HighSpeedSetElevation.Length > 0)
            {
                if (_systemSettingSlaveViewModel.HighSpeedSetElevation[^1] == '.')
                {
                    _systemSettingSlaveViewModel.HighSpeedSetElevation += "0";
                }
            }
            else if (_textBoxNo == 6 && _systemSettingSlaveViewModel.LowSpeedSetAzimuth.Length > 0)
            {
                if (_systemSettingSlaveViewModel.LowSpeedSetAzimuth[^1] == '.')
                {
                    _systemSettingSlaveViewModel.LowSpeedSetAzimuth += "0";
                }
            }
            if (_textBoxNo == 7 && _systemSettingSlaveViewModel.LowSpeedSetElevation.Length > 0)
            {
                if (_systemSettingSlaveViewModel.LowSpeedSetElevation[^1] == '.')
                {
                    _systemSettingSlaveViewModel.LowSpeedSetElevation += "0";
                }
            }
            else if (_textBoxNo == 8 && _systemSettingSlaveViewModel.InchingSpeedSetAzimuth.Length > 0)
            {
                if (_systemSettingSlaveViewModel.InchingSpeedSetAzimuth[^1] == '.')
                {
                    _systemSettingSlaveViewModel.InchingSpeedSetAzimuth += "0";
                }
            }
            else if (_textBoxNo == 9 && _systemSettingSlaveViewModel.InchingSpeedSetElevation.Length > 0)
            {
                if (_systemSettingSlaveViewModel.InchingSpeedSetElevation[^1] == '.')
                {
                    _systemSettingSlaveViewModel.InchingSpeedSetElevation += "0";
                }
            }
            else if (_textBoxNo == 10 && _systemSettingSlaveViewModel.PeakSearchSpeed.Length > 0)
            {
                if (_systemSettingSlaveViewModel.PeakSearchSpeed[^1] == '.')
                {
                    _systemSettingSlaveViewModel.PeakSearchSpeed += "0";
                }
            }
            else if (_textBoxNo == 11 && _systemSettingSlaveViewModel.PeakSearchAzimuth.Length > 0)
            {
                if (_systemSettingSlaveViewModel.PeakSearchAzimuth[^1] == '.')
                {
                    _systemSettingSlaveViewModel.PeakSearchAzimuth += "0";
                }
            }
            else if (_textBoxNo == 12 && _systemSettingSlaveViewModel.PeakSearchElevation.Length > 0)
            {
                if (_systemSettingSlaveViewModel.PeakSearchElevation[^1] == '.')
                {
                    _systemSettingSlaveViewModel.PeakSearchElevation += "0";
                }
            }
            if (_textBoxNo == 13 && _systemSettingSlaveViewModel.PeakSearchRSSILevel.Length > 0)
            {
                if (_systemSettingSlaveViewModel.PeakSearchRSSILevel[^1] == '.')
                {
                    _systemSettingSlaveViewModel.PeakSearchRSSILevel += "0";
                }
            }
            else if (_textBoxNo == 14 && _systemSettingSlaveViewModel.DetailedPeakSearchStepAngle.Length > 0)
            {
                if (_systemSettingSlaveViewModel.DetailedPeakSearchStepAngle[^1] == '.')
                {
                    _systemSettingSlaveViewModel.DetailedPeakSearchStepAngle += "0";
                }
            }
            else if (_textBoxNo == 15 && _systemSettingSlaveViewModel.DetailedPeakSearchRSSILevel.Length > 0)
            {
                if (_systemSettingSlaveViewModel.DetailedPeakSearchRSSILevel[^1] == '.')
                {
                    _systemSettingSlaveViewModel.DetailedPeakSearchRSSILevel += "0";
                }
            }
            else if (_textBoxNo == 16 && _systemSettingSlaveViewModel.StepStability.Length > 0)
            {
                if (_systemSettingSlaveViewModel.StepStability[^1] == '.')
                {
                    _systemSettingSlaveViewModel.StepStability += "0";
                }
            }
            else if (_textBoxNo == 17 && _systemSettingSlaveViewModel.ContinuousOperationTime.Length > 0)
            {
                if (_systemSettingSlaveViewModel.ContinuousOperationTime[^1] == '.')
                {
                    _systemSettingSlaveViewModel.ContinuousOperationTime += "0";
                }
            }
            if (_textBoxNo == 18 && _systemSettingSlaveViewModel.SystemUnlockPIN.Length > 0)
            {
                if (_systemSettingSlaveViewModel.SystemUnlockPIN[^1] == '.')
                {
                    _systemSettingSlaveViewModel.SystemUnlockPIN =
                        _systemSettingSlaveViewModel.SystemUnlockPIN.Remove(_systemSettingSlaveViewModel.SystemUnlockPIN.Length - 1);
                }
                _systemSettingSlaveViewModel.PINKeyboardClose = true;
                _systemSettingSlaveViewModel._systemSettingSlaveModel.PINCheck(_systemSettingSlaveViewModel.SystemUnlockPIN);
                _systemSettingSlaveViewModel.SystemUnlockPIN = new string('*', _systemSettingSlaveViewModel.SystemUnlockPIN.Length);
                    
            }
            else if (_textBoxNo == 19 && _systemSettingSlaveViewModel.UndaiSubnet.Length > 0)
            {
                if (_systemSettingSlaveViewModel.UndaiSubnet[^1] == '.')
                {
                    _systemSettingSlaveViewModel.UndaiSubnet += "0";
                }
            }
            else if (_textBoxNo == 20 && _systemSettingSlaveViewModel.DefaultGateway.Length > 0)
            {
                if (_systemSettingSlaveViewModel.DefaultGateway[^1] == '.')
                {
                    _systemSettingSlaveViewModel.DefaultGateway += "0";
                }
            }
            else if (_textBoxNo == 21 && _systemSettingSlaveViewModel.SlaveAntennaIPAddress.Length > 0)
            {
                if (_systemSettingSlaveViewModel.SlaveAntennaIPAddress[^1] == '.')
                {
                    _systemSettingSlaveViewModel.SlaveAntennaIPAddress += "0";
                }
            }
            else if (_textBoxNo == 22 && _systemSettingSlaveViewModel.PeakSearchRSSITurnLevel.Length > 0)
            {
                if (_systemSettingSlaveViewModel.PeakSearchRSSITurnLevel[^1] == '.')
                {
                    _systemSettingSlaveViewModel.PeakSearchRSSITurnLevel += "0";
                }
            }
            else if (_textBoxNo == 23 && _systemSettingSlaveViewModel.PeakSearchRSSIDelay.Length > 0)
            {
                if (_systemSettingSlaveViewModel.PeakSearchRSSIDelay[^1] == '.')
                {
                    _systemSettingSlaveViewModel.PeakSearchRSSIDelay += "0";
                }
            }
            else if (_textBoxNo == 24 && _systemSettingSlaveViewModel.UpDownSearchAngle.Length > 0)
            {
                if (_systemSettingSlaveViewModel.UpDownSearchAngle[^1] == '.')
                {
                    _systemSettingSlaveViewModel.UpDownSearchAngle += "0";
                }
            }
            else if (_textBoxNo == 25 && _systemSettingSlaveViewModel.RSSITurnbackThresholdLevel.Length > 0)
            {
                if (_systemSettingSlaveViewModel.RSSITurnbackThresholdLevel[^1] == '.')
                {
                    _systemSettingSlaveViewModel.RSSITurnbackThresholdLevel += "0";
                }
            }
            else if (_textBoxNo == 26 && _systemSettingSlaveViewModel.ElevationStepValue.Length > 0)
            {
                if (_systemSettingSlaveViewModel.ElevationStepValue[^1] == '.')
                {
                    _systemSettingSlaveViewModel.ElevationStepValue += "0";
                }
            }
            else if (_textBoxNo == 27 && _systemSettingSlaveViewModel.AzimuthStepValue.Length > 0)
            {
                if (_systemSettingSlaveViewModel.AzimuthStepValue[^1] == '.')
                {
                    _systemSettingSlaveViewModel.AzimuthStepValue += "0";
                }
            }
            else if (_textBoxNo == 28 && _systemSettingSlaveViewModel.DetailedPeakSearchSpeed.Length > 0)
            {
                if (_systemSettingSlaveViewModel.DetailedPeakSearchSpeed[^1] == '.')
                {
                    _systemSettingSlaveViewModel.DetailedPeakSearchSpeed += "0";
                }
            }
            else if (_textBoxNo == 29 && _systemSettingSlaveViewModel.DetailedPeakSearchAzimuth.Length > 0)
            {
                if (_systemSettingSlaveViewModel.DetailedPeakSearchAzimuth[^1] == '.')
                {
                    _systemSettingSlaveViewModel.DetailedPeakSearchAzimuth += "0";
                }
            }

            this.Close();
            _status = 1;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_textBoxNo == 1)
            {
                _systemSettingSlaveViewModel.UndaiIPAddress = _backupString;
            }
            else if (_textBoxNo == 2)
            {
                _systemSettingSlaveViewModel.OriginOffsetAzimuth = _backupString;
            }
            else if (_textBoxNo == 3)
            {
                _systemSettingSlaveViewModel.OriginOffsetElevation = _backupString;
            }
            else if (_textBoxNo == 4)
            {
                _systemSettingSlaveViewModel.HighSpeedSetAzimuth = _backupString;
            }
            else if (_textBoxNo == 5)
            {
                _systemSettingSlaveViewModel.HighSpeedSetElevation = _backupString;
            }
            else if (_textBoxNo == 6)
            {
                _systemSettingSlaveViewModel.LowSpeedSetAzimuth = _backupString;
            }
            else if (_textBoxNo == 7)
            {
                _systemSettingSlaveViewModel.LowSpeedSetElevation = _backupString;
            }
            else if (_textBoxNo == 8)
            {
                _systemSettingSlaveViewModel.InchingSpeedSetAzimuth = _backupString;
            }
            else if (_textBoxNo == 9)
            {
                _systemSettingSlaveViewModel.InchingSpeedSetElevation = _backupString;
            }
            else if (_textBoxNo == 10)
            {
                _systemSettingSlaveViewModel.PeakSearchSpeed = _backupString;
            }
            else if (_textBoxNo == 11)
            {
                _systemSettingSlaveViewModel.PeakSearchAzimuth = _backupString;
            }
            else if (_textBoxNo == 12)
            {
                _systemSettingSlaveViewModel.PeakSearchElevation = _backupString;
            }
            else if (_textBoxNo == 13)
            {
                _systemSettingSlaveViewModel.PeakSearchRSSILevel = _backupString;
            }
            else if (_textBoxNo == 14)
            {
                _systemSettingSlaveViewModel.DetailedPeakSearchStepAngle = _backupString;
            }
            else if (_textBoxNo == 15)
            {
                _systemSettingSlaveViewModel.DetailedPeakSearchRSSILevel = _backupString;
            }
            else if (_textBoxNo == 16)
            {
                _systemSettingSlaveViewModel.StepStability = _backupString;
            }
            else if (_textBoxNo == 17)
            {
                _systemSettingSlaveViewModel.ContinuousOperationTime = _backupString;
            }
            else if (_textBoxNo == 19)
            {
                _systemSettingSlaveViewModel.UndaiSubnet = _backupString;
            }
            else if (_textBoxNo == 20)
            {
                _systemSettingSlaveViewModel.DefaultGateway = _backupString;
            }
            else if (_textBoxNo == 21)
            {
                _systemSettingSlaveViewModel.SlaveAntennaIPAddress = _backupString;
            }
            else if (_textBoxNo == 22)
            {
                _systemSettingSlaveViewModel.PeakSearchRSSITurnLevel = _backupString;
            }
            else if (_textBoxNo == 23)
            {
                _systemSettingSlaveViewModel.PeakSearchRSSIDelay = _backupString;
            }
            else if (_textBoxNo == 24)
            {
                _systemSettingSlaveViewModel.UpDownSearchAngle = _backupString;
            }
            else if (_textBoxNo == 25)
            {
                _systemSettingSlaveViewModel.RSSITurnbackThresholdLevel = _backupString;
            }
            else if (_textBoxNo == 26)
            {
                _systemSettingSlaveViewModel.ElevationStepValue = _backupString;
            }
            else if (_textBoxNo == 27)
            {
                _systemSettingSlaveViewModel.AzimuthStepValue = _backupString;
            }
            else if (_textBoxNo == 28)
            {
                _systemSettingSlaveViewModel.DetailedPeakSearchSpeed = _backupString;
            }
            else if (_textBoxNo == 29)
            {
                _systemSettingSlaveViewModel.DetailedPeakSearchAzimuth = _backupString;
            }

            _status = 0;
            this.Close();
            Keyboard.ClearFocus();
        }

    }

}
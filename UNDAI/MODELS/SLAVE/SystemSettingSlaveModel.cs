using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using UNDAI.MODELS.MASTER;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWMODELS.SLAVE;

namespace UNDAI.MODELS.SLAVE
{
    public class SystemSettingSlaveModel
    {
        private int _commandNo;
        MainPageSlaveViewModel _mainPageSlaveViewModel;
        MainPageSlaveModel _mainPageSlaveModel;
        SystemSettingSlaveViewModel _systemSettingSlaveViewModel;
        App app;

        public SystemSettingSlaveModel(SystemSettingSlaveViewModel systemSettingSlaveViewModel)
        {
            _systemSettingSlaveViewModel = systemSettingSlaveViewModel;
            _mainPageSlaveViewModel = _systemSettingSlaveViewModel._mainPageSlaveViewModel;
            app = (App)Application.Current;
            CreateAppClassAfterDelay();;
        }

        private async void CreateAppClassAfterDelay()
        {
            await Task.Delay(100);
            if (_mainPageSlaveViewModel == null || _mainPageSlaveModel == null)
            {
                // Access properties directly
                _mainPageSlaveViewModel = app._mainPageSlaveViewModel;
                _mainPageSlaveModel = _mainPageSlaveViewModel.MainPageSlaveModel;
            }
        }

        public void PINCheck(string EnteredPIN)
        {
            string PIN = "1234";
            if (_systemSettingSlaveViewModel.PINKeyboardClose)
            {
                if (EnteredPIN == PIN)
                {
                    _systemSettingSlaveViewModel.SystemSettingUnlock = true;
                    _systemSettingSlaveViewModel.PINKeyboardClose = false;
                    _systemSettingSlaveViewModel.GridVisibility = "Visible";
                }
                else
                {
                    _systemSettingSlaveViewModel.SystemSettingUnlock = false;
                    _systemSettingSlaveViewModel.PINKeyboardClose = false;
                    _systemSettingSlaveViewModel.GridVisibility = "Hidden";
                }
            }
        }

        public void ButtonClick(int _commandNo)
        {
            switch (_commandNo)
            {
                case 1:
                    // UP ARROW MOUSE PRESSED - SY,1\n
                    _mainPageSlaveModel.MessageSend("I," + (38).ToString() + "\n");
                    break;
                case 2:
                    // UP ARROW MOUSE RELEASED - SY,2\n
                    _mainPageSlaveModel.MessageSend("I," + (0).ToString() + "\n");
                    break;
                case 3:
                    // DOWN ARROW MOUSE PRESSED - SY,3\n
                    _mainPageSlaveModel.MessageSend("I," + (39).ToString() + "\n");
                    break;
                case 4:
                    // DOWN ARROW MOUSE RELEASED - SY,4\n
                    _mainPageSlaveModel.MessageSend("I," + (0).ToString() + "\n");
                    break;
                case 5:
                    // CCW ARROW MOUSE PRESSED - SY,5\n
                    _mainPageSlaveModel.MessageSend("I," + (36).ToString() + "\n");
                    break;
                case 6:
                    // CCW ARROW MOUSE RELEASED - SY,6\n
                    _mainPageSlaveModel.MessageSend("I," + (0).ToString() + "\n");
                    break;
                case 7:
                    // CW ARROW MOUSE PRESSED - SY,7\n
                    _mainPageSlaveModel.MessageSend("I," + (37).ToString() + "\n");
                    break;
                case 8:
                    // CW ARROW MOUSE RELEASED - SY,8\n
                    _mainPageSlaveModel.MessageSend("I," + (0).ToString() + "\n");
                    break;
                case 9:
                    // Elevation Encorder Reset Command - SY,9\n
                    _mainPageSlaveModel.MessageSend("I," + (16).ToString() + "\n");
                    break;
                case 10:
                    // Azimuth Encorder Reset Command - SY,10\n
                    _mainPageSlaveModel.MessageSend("I," + (15).ToString() + "\n");
                    break;
                case 11:
                    int MasterSlaveCheckNum = 0;
                    if (_systemSettingSlaveViewModel.MasterChecked)
                    {
                        MasterSlaveCheckNum = 1;
                    }
                    else if (_systemSettingSlaveViewModel.SlaveChecked)
                    {
                        MasterSlaveCheckNum = 2;
                    }
                    if (!MainPageMasterModel.IsValidIPAddress(_systemSettingSlaveViewModel.UndaiIPAddress))
                    {
                        if (MessageBox.Show("Please Re-enter, Try Again?",
                                "INVALID UNDAI IPADDRESS",
                                MessageBoxButton.OK,
                                MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            // Optionally, do something here if the user clicks "OK"
                            break;
                        }
                    }
                    else if (!MainPageMasterModel.IsValidIPAddress(_systemSettingSlaveViewModel.SlaveAntennaIPAddress))
                    {
                        if (MessageBox.Show("Please Re-enter, Try Again?",
                                "INVALID ANTENNA IPADDRESS",
                                MessageBoxButton.OK,
                                MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            // Optionally, do something here if the user clicks "OK"
                            break;
                        }
                    }
                    else if (!MainPageMasterModel.IsValidSubnetMask(_systemSettingSlaveViewModel.UndaiSubnet))
                    {
                        if (MessageBox.Show("Please Re-enter, Try Again?",
                                "INVALID SUBNET",
                                MessageBoxButton.OK,
                                MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            // Optionally, do something here if the user clicks "OK"
                            break;
                        }
                    }
                    else if (!MainPageMasterModel.IsValidIPAddress(_systemSettingSlaveViewModel.DefaultGateway))
                    {
                        if (MessageBox.Show("Please reenter, try again?",
                                "INVALID GATEWAY ADDRESS",
                                MessageBoxButton.OK,
                                MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            // Optionally, do something here if the user clicks "OK"
                            break;
                        }
                    }
                    else if(_systemSettingSlaveViewModel.RSSITurnbackThresholdLevel == "-")
                    {
                        if (MessageBox.Show("Please reenter, try again?",
                                "INVALID RSSI Turnback Threshold Level",
                                MessageBoxButton.OK,
                                MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            // Optionally, do something here if the user clicks "OK"
                            break;
                        }
                    }
                    else if (_systemSettingSlaveViewModel.DetailedPeakSearchRSSILevel == "-")
                    {
                        if (MessageBox.Show("Please reenter, try again?",
                                "INVALID Detailed Peak Search RSSI Level",
                                MessageBoxButton.OK,
                                MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            // Optionally, do something here if the user clicks "OK"
                            break;
                        }
                    }
                    else if (_systemSettingSlaveViewModel.PeakSearchRSSITurnLevel == "-")
                    {
                        if (MessageBox.Show("Please reenter, try again?",
                                "INVALID Peak Search RSSI Turn Level",
                                MessageBoxButton.OK,
                                MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            // Optionally, do something here if the user clicks "OK"
                            break;
                        }
                    }
                    else if (_systemSettingSlaveViewModel.PeakSearchRSSILevel == "-")
                    {
                        if (MessageBox.Show("Please reenter, try again?",
                                "INVALID Peak Search RSSI Level",
                                MessageBoxButton.OK,
                                MessageBoxImage.Question) == MessageBoxResult.OK)
                        {
                            // Optionally, do something here if the user clicks "OK"
                            break;
                        }
                    }
                    if (_systemSettingSlaveViewModel.SelectedMode == 1)
                    {
                        // System Setting Send Command - SY,11\n
                        _mainPageSlaveModel.MessageSend(
                            "SY,11," +
                            MasterSlaveCheckNum + "," +                                     // 1
                            _systemSettingSlaveViewModel.UndaiIPAddress + "," +             // 2
                            _systemSettingSlaveViewModel.UndaiSubnet + "," +                // 3
                            _systemSettingSlaveViewModel.DefaultGateway + "," +             // 4
                            _systemSettingSlaveViewModel.SlaveAntennaIPAddress + "," +      // 5
                            _systemSettingSlaveViewModel.OriginOffsetAzimuth + "," +        // 6
                            _systemSettingSlaveViewModel.OriginOffsetElevation + "," +      // 7
                            _systemSettingSlaveViewModel.HighSpeedSetAzimuth + "," +        // 8
                            _systemSettingSlaveViewModel.HighSpeedSetElevation + "," +      // 9
                            _systemSettingSlaveViewModel.LowSpeedSetAzimuth + "," +         // 10
                            _systemSettingSlaveViewModel.LowSpeedSetElevation + "," +       // 11
                            _systemSettingSlaveViewModel.InchingSpeedSetAzimuth + "," +     // 12
                            _systemSettingSlaveViewModel.InchingSpeedSetElevation + "," +   // 13
                            "\n"
                        );
                    }
                    else if (_systemSettingSlaveViewModel.SelectedMode == 2)
                    {
                        // System Setting Send Command - SY,11\n
                        _mainPageSlaveModel.MessageSend(
                            "SY,11," +
                            MasterSlaveCheckNum + "," +                                     // 1
                            _systemSettingSlaveViewModel.UndaiIPAddress + "," +             // 2
                            _systemSettingSlaveViewModel.UndaiSubnet + "," +                // 3
                            _systemSettingSlaveViewModel.DefaultGateway + "," +             // 4
                            _systemSettingSlaveViewModel.SlaveAntennaIPAddress + "," +      // 5
                            _systemSettingSlaveViewModel.OriginOffsetAzimuth + "," +        // 6
                            _systemSettingSlaveViewModel.OriginOffsetElevation + "," +      // 7
                            _systemSettingSlaveViewModel.HighSpeedSetAzimuth + "," +        // 8
                            _systemSettingSlaveViewModel.HighSpeedSetElevation + "," +      // 9
                            _systemSettingSlaveViewModel.LowSpeedSetAzimuth + "," +         // 10
                            _systemSettingSlaveViewModel.LowSpeedSetElevation + "," +       // 11
                            _systemSettingSlaveViewModel.InchingSpeedSetAzimuth + "," +     // 12
                            _systemSettingSlaveViewModel.InchingSpeedSetElevation + "," +   // 13
                            _systemSettingSlaveViewModel.PeakSearchSpeed + "," +            // 14
                            _systemSettingSlaveViewModel.PeakSearchAzimuth + "," +          // 15
                            _systemSettingSlaveViewModel.PeakSearchElevation + "," +        // 16
                            _systemSettingSlaveViewModel.PeakSearchRSSILevel + "," +        // 17
                            _systemSettingSlaveViewModel.PeakSearchRSSITurnLevel + "," +    // 18
                            _systemSettingSlaveViewModel.PeakSearchRSSIDelay + "," +        // 19
                            _systemSettingSlaveViewModel.DetailedPeakSearchSpeed + "," +    // 20
                            _systemSettingSlaveViewModel.DetailedPeakSearchStepAngle + "," +// 21
                            _systemSettingSlaveViewModel.UpDownSearchAngle + "," +          // 22
                            _systemSettingSlaveViewModel.DetailedPeakSearchAzimuth + "," +  // 23
                            _systemSettingSlaveViewModel.DetailedPeakSearchRSSILevel + "," +// 24
                            _systemSettingSlaveViewModel.StepStability + "," +              // 25
                            _systemSettingSlaveViewModel.RSSITurnbackThresholdLevel + "," + // 26
                            _systemSettingSlaveViewModel.ElevationStepValue + "," +         // 27
                            _systemSettingSlaveViewModel.AzimuthStepValue + "," +           // 28
                            "\n"
                        );
                    }
                    break;
                case 12:
                    // Continuous Operation Time Command - I,11\n
                    _systemSettingSlaveViewModel.continuousOperationTimerStart = true;
                    _mainPageSlaveModel.MessageSend("I," + (11).ToString() + ",\n");
                    _systemSettingSlaveViewModel.ContinuousOperationTimerStart(_systemSettingSlaveViewModel.ContinuousOperationTime);
                    break;
                case 13:
                    // Continuous Operation Time Stop Command - I,30\n
                    _mainPageSlaveModel.MessageSend("I," + (30).ToString() + ",\n");
                    _systemSettingSlaveViewModel.continuousOperationTimerStart = false;
                    break;
                case 14:
                    // Alarm Reset Command - SYI,14\n
                    _mainPageSlaveModel.MessageSend("SYI," + (_commandNo).ToString() + "," + "\n");
                    break;
            }
        }

        object SlaveSender;
        RoutedEventArgs SlaveE;
        object MasterSender;
        RoutedEventArgs MasterE;

        public void MasterRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            MasterSender = sender;
            MasterE = e;
            MasterRadioButtonColor();
        }

        public void SlaveRadioButtonChecked(object sender, RoutedEventArgs e)
        {
            SlaveSender = sender;
            SlaveE = e;
            SlaveRadioButtonColor();
        }

        public Color MasterSelectedColor()
        {
            Color selectedColor = Color.FromRgb(0, 153, 204);
            if (_systemSettingSlaveViewModel.SelectedMode == 1)
            {
                selectedColor = Color.FromRgb(0, 153, 204);
            }
            return selectedColor;
        }

        public Color SlaveSelectedColor()
        {
            Color selectedColor = Color.FromRgb(0, 153, 204);
            if (_systemSettingSlaveViewModel.SelectedMode == 2)
            {
                selectedColor = Color.FromRgb(0, 153, 204);
            }
            return selectedColor;
        }

        public void MasterRadioButtonColor()
        {
            object sender = MasterSender;
            RoutedEventArgs e = MasterE;
            var rb = sender as RadioButton;
            if (rb == null) return;

            // Find the Ellipse inside the RadioButton's template
            var ellipse = FindVisualChildren<Ellipse>(rb).FirstOrDefault();
            if (ellipse != null)
            {
                // Change the fill color to a custom color
                ellipse.Fill = new SolidColorBrush(MasterSelectedColor());
            }
        }

        public void SlaveRadioButtonColor()
        {
            object sender = SlaveSender;
            RoutedEventArgs e = SlaveE;
            var rb = sender as RadioButton;
            if (rb == null) return;

            // Find the Ellipse inside the RadioButton's template
            var ellipse = FindVisualChildren<Ellipse>(rb).FirstOrDefault();
            if (ellipse != null)
            {
                // Change the fill color to a custom color
                ellipse.Fill = new SolidColorBrush(SlaveSelectedColor());
            }
        }

        // Method to find all children of a specific type in the visual tree
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield break;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;

                if (ithChild is T t)
                {
                    yield return t;
                }

                foreach (T childOfChild in FindVisualChildren<T>(ithChild))
                {
                    yield return childOfChild;
                }
            }
        }


    }
}

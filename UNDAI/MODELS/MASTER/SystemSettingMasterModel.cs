using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using UNDAI.COMMANDS.BASE;
using UNDAI.VIEWMODELS.MASTER;

namespace UNDAI.MODELS.MASTER
{
    public class SystemSettingMasterModel
    {
        private int _commandNo;
        MainPageMasterViewModel _mainPageMasterViewModel;
        MainPageMasterModel _mainPageMasterModel;
        SystemSettingMasterViewModel _systemSettingMasterViewModel;
        App app;
        public Color selectedColorMaster;
        public Color selectedColorSlave;

        public SystemSettingMasterModel(SystemSettingMasterViewModel systemSettingMasterViewModel)
        {
            _systemSettingMasterViewModel = systemSettingMasterViewModel;
            _mainPageMasterViewModel = _systemSettingMasterViewModel._mainPageMasterViewModel;
            app = (App)Application.Current;
            CreateAppClassAfterDelay();;
        }

        private async void CreateAppClassAfterDelay()
        {
            if (_mainPageMasterViewModel == null)
            {
                await Task.Delay(50);
                // Access properties directly
                _mainPageMasterViewModel = app._mainPageMasterViewModel;
                if (_mainPageMasterViewModel != null)
                {
                    _mainPageMasterModel = _mainPageMasterViewModel.MainPageMasterModel;
                }
            }
        }

        public void PINCheck(string EnteredPIN)
        {
            string PIN = "1234";
            if (_systemSettingMasterViewModel.PINKeyboardClose)
            {
                if (EnteredPIN == PIN)
                {
                    _systemSettingMasterViewModel.SystemSettingUnlock = true;
                    _systemSettingMasterViewModel.PINKeyboardClose = false;
                    _systemSettingMasterViewModel.GridVisibility = "Visible";
                }
                else
                {
                    _systemSettingMasterViewModel.SystemSettingUnlock = false;
                    _systemSettingMasterViewModel.PINKeyboardClose = false;
                    _systemSettingMasterViewModel.GridVisibility = "Hidden";
                }
            }
        }

        public void ButtonClick(int _commandNo)
        {
            if (_mainPageMasterViewModel == null || _mainPageMasterModel == null)
            {
                CreateAppClassAfterDelay();
            }
            if(_mainPageMasterViewModel != null && _mainPageMasterModel != null)
            {
                switch (_commandNo)
                {
                    case 1:
                        // UP ARROW MOUSE PRESSED - SY,1\n
                        _mainPageMasterModel.MessageSend("I," + (38).ToString() + "\n");
                        break;
                    case 2:
                        // UP ARROW MOUSE RELEASED - SY,2\n
                        _mainPageMasterModel.MessageSend("I," + (0).ToString() + "\n");
                        break;
                    case 3:
                        // DOWN ARROW MOUSE PRESSED - SY,3\n
                        _mainPageMasterModel.MessageSend("I," + (39).ToString() + "\n");
                        break;
                    case 4:
                        // DOWN ARROW MOUSE RELEASED - SY,4\n
                        _mainPageMasterModel.MessageSend("I," + (0).ToString() + "\n");
                        break;
                    case 5:
                        // CCW ARROW MOUSE PRESSED - SY,5\n
                        _mainPageMasterModel.MessageSend("I," + (36).ToString() + "\n");
                        break;
                    case 6:
                        // CCW ARROW MOUSE RELEASED - SY,6\n
                        _mainPageMasterModel.MessageSend("I," + (0).ToString() + "\n");
                        break;
                    case 7:
                        // CW ARROW MOUSE PRESSED - SY,7\n
                        _mainPageMasterModel.MessageSend("I," + (37).ToString() + "\n");
                        break;
                    case 8:
                        // CW ARROW MOUSE RELEASED - SY,8\n
                        _mainPageMasterModel.MessageSend("I," + (0).ToString() + "\n");
                        break;
                    case 9:
                        // Elevation Encorder Reset Command - SY,9\n
                        _mainPageMasterModel.MessageSend("I," + (16).ToString() + "\n");
                        break;
                    case 10:
                        // Azimuth Encorder Reset Command - SY,10\n
                        _mainPageMasterModel.MessageSend("I," + (15).ToString() + "\n");
                        break;
                    case 11:
                        if (_mainPageMasterViewModel == null || _mainPageMasterModel == null)
                        {
                            CreateAppClassAfterDelay();
                        }
                        int MasterSlaveCheckNum = 0;
                        if (_systemSettingMasterViewModel.MasterChecked)
                        {
                            MasterSlaveCheckNum = 1;
                        }
                        else if (_systemSettingMasterViewModel.SlaveChecked)
                        {
                            MasterSlaveCheckNum = 2;
                        }
                        if(!MainPageMasterModel.IsValidIPAddress(_systemSettingMasterViewModel.UndaiIPAddress))
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
                        else if(!MainPageMasterModel.IsValidIPAddress(_systemSettingMasterViewModel.MasterAntennaIPAddress))
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
                        else if(!MainPageMasterModel.IsValidSubnetMask(_systemSettingMasterViewModel.UndaiSubnet))
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
                        else if(!MainPageMasterModel.IsValidIPAddress(_systemSettingMasterViewModel.DefaultGateway))
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
                        if(_systemSettingMasterViewModel.SelectedMode == 1)
                        {
                            // System Setting Send Command - SY,11\n
                            _mainPageMasterModel.MessageSend(
                                "SY,11," +
                                MasterSlaveCheckNum + "," +                                      // 1
                                _systemSettingMasterViewModel.UndaiIPAddress + "," +             // 2
                                _systemSettingMasterViewModel.UndaiSubnet + "," +                // 3
                                _systemSettingMasterViewModel.DefaultGateway + "," +             // 4
                                _systemSettingMasterViewModel.MasterAntennaIPAddress + "," +     // 5
                                _systemSettingMasterViewModel.OriginOffsetAzimuth + "," +        // 6
                                _systemSettingMasterViewModel.OriginOffsetElevation + "," +      // 7
                                _systemSettingMasterViewModel.HighSpeedSetAzimuth + "," +        // 8
                                _systemSettingMasterViewModel.HighSpeedSetElevation + "," +      // 9
                                _systemSettingMasterViewModel.LowSpeedSetAzimuth + "," +         // 10
                                _systemSettingMasterViewModel.LowSpeedSetElevation + "," +       // 11
                                _systemSettingMasterViewModel.InchingSpeedSetAzimuth + "," +     // 12
                                _systemSettingMasterViewModel.InchingSpeedSetElevation + "," +   // 13
                                "\n"
                            );
                        }
                        else if (_systemSettingMasterViewModel.SelectedMode == 2)
                        {
                            // System Setting Send Command - SY,11\n
                            _mainPageMasterModel.MessageSend(
                                "SY,11," +
                                MasterSlaveCheckNum + "," +                                      // 1
                                _systemSettingMasterViewModel.UndaiIPAddress + "," +             // 2
                                _systemSettingMasterViewModel.UndaiSubnet + "," +                // 3
                                _systemSettingMasterViewModel.DefaultGateway + "," +             // 4
                                _systemSettingMasterViewModel.MasterAntennaIPAddress + "," +     // 5
                                _systemSettingMasterViewModel.OriginOffsetAzimuth + "," +        // 6
                                _systemSettingMasterViewModel.OriginOffsetElevation + "," +      // 7
                                _systemSettingMasterViewModel.HighSpeedSetAzimuth + "," +        // 8
                                _systemSettingMasterViewModel.HighSpeedSetElevation + "," +      // 9
                                _systemSettingMasterViewModel.LowSpeedSetAzimuth + "," +         // 10
                                _systemSettingMasterViewModel.LowSpeedSetElevation + "," +       // 11
                                _systemSettingMasterViewModel.InchingSpeedSetAzimuth + "," +     // 12
                                _systemSettingMasterViewModel.InchingSpeedSetElevation + "," +   // 13
                                _systemSettingMasterViewModel.PeakSearchSpeed + "," +            // 14
                                _systemSettingMasterViewModel.PeakSearchAzimuth + "," +          // 15
                                _systemSettingMasterViewModel.PeakSearchElevation + "," +        // 16
                                _systemSettingMasterViewModel.PeakSearchRSSILevel + "," +        // 17
                                _systemSettingMasterViewModel.PeakSearchRSSITurnLevel + "," +    // 18
                                _systemSettingMasterViewModel.PeakSearchRSSIDelay + "," +        // 19
                                _systemSettingMasterViewModel.DetailedPeakSearchStepAngle + "," +// 20
                                _systemSettingMasterViewModel.UpDownSearchAngle + "," +          // 21
                                _systemSettingMasterViewModel.DetailedPeakSearchRSSILevel + "," +// 22
                                _systemSettingMasterViewModel.StepStability + "," +              // 23
                                _systemSettingMasterViewModel.RSSITurnbackThresholdLevel + "," + // 24
                                "\n"
                            );
                        }
                        break;
                    case 12:
                        // Continuous Operation Time Command - I,11,Time,\n
                        _systemSettingMasterViewModel.continuousOperationTimerStart = true;
                        _mainPageMasterModel.MessageSend("I," + (11).ToString() + ",\n");
                        _systemSettingMasterViewModel.ContinuousOperationTimerStart(_systemSettingMasterViewModel.ContinuousOperationTime);
                        break;
                    case 13:
                        // Continuous Operation Time Stop Command - I,30\n
                        _mainPageMasterModel.MessageSend("I," + (30).ToString() + ",\n");
                        _systemSettingMasterViewModel.continuousOperationTimerStart = false;
                        break;
                    case 14:
                        // Alarm Reset Command - SYI,14\n
                        _mainPageMasterModel.MessageSend("SYI," + (_commandNo).ToString() + "," + "\n");
                        break;

                }
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
            selectedColorMaster = Color.FromRgb(0, 153, 204);
            if (_systemSettingMasterViewModel.SelectedMode == 1)
            {
                selectedColorMaster = Color.FromRgb(0, 153, 204);
            }
            return selectedColorMaster;
        }

        public Color SlaveSelectedColor()
        {
            selectedColorSlave = Color.FromRgb(0, 153, 204);
            if (_systemSettingMasterViewModel.SelectedMode == 2)
            {
                selectedColorSlave = Color.FromRgb(0, 153, 204);
            }
            return selectedColorSlave;
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

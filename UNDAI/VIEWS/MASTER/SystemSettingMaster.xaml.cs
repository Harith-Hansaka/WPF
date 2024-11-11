using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWS.BASE;

namespace UNDAI.VIEWS.MASTER
{
    /// <summary>
    /// Interaction logic for SystemSettingMaster.xaml
    /// </summary>
    public partial class SystemSettingMaster : UserControl
    {
        NumericKeyboardWindowSystemSettingMaster _numericKeyboardWindowSystemSettingMaster;
        SystemSettingAccessPIN systemSettingAccessPIN;

        int textBoxNo;
        string backupString;
        bool isTextboxClicked = false;
        bool mouseReleased = true;
        bool touchReleased = true;
        bool stylusReleased = true;
        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;
        App app;

        private SystemSettingMasterViewModel? ViewModel => DataContext as SystemSettingMasterViewModel;

        public SystemSettingMaster()
        {
            InitializeComponent();
            InitializeDebounceTimer(); // Initialize debounce logic
            app = (App)Application.Current;
            CreateAppClassAfterDelay();

            if (ViewModel != null)
            {
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(0, ViewModel, "");
            }
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._systemSettingMasterViewModel;
            }
        }

        private void btnUpArrowMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (mouseReleased)
            {
                // Capture the mouse input to ensure it is handled by this element
                (sender as UIElement)?.CaptureMouse();
                // Prevent further processing
                e.Handled = true;
                // Execute the ViewModel command
                ViewModel?.BtnUpArrowMainPageMouseDownCommand.Execute(e);
                mouseReleased = false;
            }
        }

        private void btnUpArrowMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!mouseReleased)
            {
                // Release the mouse capture
                (sender as UIElement)?.ReleaseMouseCapture();
                // Prevent further processing
                e.Handled = true;
                // Execute the ViewModel command
                ViewModel?.BtnUpArrowMainPageMouseUpCommand.Execute(e);
                mouseReleased = true;
            }
        }

        private void btnUpArrowMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (touchReleased)
            {
                // Capture the touch input to ensure it is handled by this element
                (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                // Prevent further processing
                e.Handled = true;
                // Execute the ViewModel command
                ViewModel?.BtnUpArrowMainPageMouseDownCommand.Execute(e);
                touchReleased = false;
            }
        }

        private void btnUpArrowMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (!stylusReleased)
            {
                // Release the stylus capture
                (sender as UIElement)?.ReleaseStylusCapture();
                // Prevent further processing
                e.Handled = true;
                // Execute the ViewModel command
                ViewModel?.BtnUpArrowMainPageMouseUpCommand.Execute(e);
                stylusReleased = true;
            }
        }

        private void btnUpArrowMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (stylusReleased)
            {
                // Capture the stylus input to ensure it is handled by this element
                (sender as UIElement)?.CaptureStylus();
                // Prevent further processing
                e.Handled = true;
                // Execute the ViewModel command
                ViewModel?.BtnUpArrowMainPageMouseDownCommand.Execute(e);
                stylusReleased = false;
            }
        }

        private void btnUpArrowMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            if (!stylusReleased)
            {
                // Release the stylus capture
                (sender as UIElement)?.ReleaseStylusCapture();
                // Prevent further processing
                e.Handled = true;
                // Execute the ViewModel command
                ViewModel?.BtnUpArrowMainPageMouseUpCommand.Execute(e);
                stylusReleased = true;
            }
        }

        private void btnUpArrowMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnUpArrowMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnUpArrowMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnDownArrowMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (mouseReleased)
            {
                (sender as UIElement)?.CaptureMouse();
                e.Handled = true;
                ViewModel?.BtnDownArrowMainPageMouseDownCommand.Execute(e);
                mouseReleased = false;
            }
        }

        private void btnDownArrowMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!mouseReleased)
            {
                (sender as UIElement)?.ReleaseMouseCapture();
                e.Handled = true;
                ViewModel?.BtnDownArrowMainPageMouseUpCommand.Execute(e);
                mouseReleased = true;
            }
        }

        private void btnDownArrowMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (stylusReleased)
            {
                (sender as UIElement)?.CaptureStylus();
                e.Handled = true;
                ViewModel?.BtnDownArrowMainPageMouseDownCommand.Execute(e);
                stylusReleased = false;
            }
        }

        private void btnDownArrowMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            if (!stylusReleased)
            {
                (sender as UIElement)?.ReleaseStylusCapture();
                e.Handled = true;
                ViewModel?.BtnDownArrowMainPageMouseUpCommand.Execute(e);
                stylusReleased = true;
            }
        }

        private void btnDownArrowMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (touchReleased)
            {
                (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                e.Handled = true;
                ViewModel?.BtnDownArrowMainPageMouseDownCommand.Execute(e);
                touchReleased = false;
            }
        }

        private void btnDownArrowMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (!touchReleased)
            {
                (sender as UIElement)?.ReleaseTouchCapture(e.TouchDevice);
                e.Handled = true;
                ViewModel?.BtnDownArrowMainPageMouseUpCommand.Execute(e);
                touchReleased = true;
            }
        }

        private void btnDownArrowMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnDownArrowMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnDownArrowMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnCWArrowMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (mouseReleased)
            {
                (sender as UIElement)?.CaptureMouse();
                e.Handled = true;
                ViewModel?.BtnCWMainPageMouseDownCommand.Execute(e);
                mouseReleased = false;
            }
        }

        private void btnCWArrowMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!mouseReleased)
            {
                (sender as UIElement)?.ReleaseMouseCapture();
                e.Handled = true;
                ViewModel?.BtnCWMainPageMouseUpCommand.Execute(e);
                mouseReleased = true;
            }
        }

        private void btnCWArrowMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (stylusReleased)
            {
                (sender as UIElement)?.CaptureStylus();
                e.Handled = true;
                ViewModel?.BtnCWMainPageMouseDownCommand.Execute(e);
                stylusReleased = false;
            }
        }

        private void btnCWArrowMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            if (!stylusReleased)
            {
                (sender as UIElement)?.ReleaseStylusCapture();
                e.Handled = true;
                ViewModel?.BtnCWMainPageMouseUpCommand.Execute(e);
                stylusReleased = true;
            }
        }

        private void btnCWArrowMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (touchReleased)
            {
                (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                e.Handled = true;
                ViewModel?.BtnCWMainPageMouseDownCommand.Execute(e);
                touchReleased = false;
            }
        }

        private void btnCWArrowMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (!touchReleased)
            {
                (sender as UIElement)?.ReleaseTouchCapture(e.TouchDevice);
                e.Handled = true;
                ViewModel?.BtnCWMainPageMouseUpCommand.Execute(e);
                touchReleased = true;
            }
        }

        private void btnCWArrowMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }
        
        private void btnCWArrowMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnCWArrowMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnCCWArrowMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (mouseReleased)
            {
                (sender as UIElement)?.CaptureMouse();
                e.Handled = true;
                ViewModel?.BtnCCWMainPageMouseDownCommand.Execute(e);
                mouseReleased = false;
            }
        }

        private void btnCCWArrowMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!mouseReleased)
            {
                (sender as UIElement)?.ReleaseMouseCapture();
                e.Handled = true;
                ViewModel?.BtnCCWMainPageMouseUpCommand.Execute(e);
                mouseReleased = true;
            }
        }

        private void btnCCWArrowMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (stylusReleased)
            {
                (sender as UIElement)?.CaptureStylus();
                e.Handled = true;
                ViewModel?.BtnCCWMainPageMouseDownCommand.Execute(e);
                stylusReleased = false;
            }
        }

        private void btnCCWArrowMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            if (!stylusReleased)
            {
                (sender as UIElement)?.ReleaseStylusCapture();
                e.Handled = true;
                ViewModel?.BtnCCWMainPageMouseUpCommand.Execute(e);
                stylusReleased = true;
            }
        }

        private void btnCCWArrowMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (touchReleased)
            {
                (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                e.Handled = true;
                ViewModel?.BtnCCWMainPageMouseDownCommand.Execute(e);
                touchReleased = false;
            }
        }

        private void btnCCWArrowMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (!touchReleased)
            {
                (sender as UIElement)?.ReleaseTouchCapture(e.TouchDevice);
                e.Handled = true;
                ViewModel?.BtnCCWMainPageMouseUpCommand.Execute(e);
                touchReleased = true;
            }
        }

        private void SystemSettingRegister_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SystemSettingRegister.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(3);
        }

        private void SystemSettingRegister_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SystemSettingRegister.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(3);
        }

        private void SystemSettingRegister_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SystemSettingRegister.Background = new SolidColorBrush(Color.FromRgb(0x5a, 0x5a, 0x5a));
            ProcessNumberInput(3);
        }

        private void ContinuousOperationTimeCommand_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (mouseReleased && !ViewModel.continuousOperationTimerStart)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.ContinuousOperationTimeCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ContinuousOperationTimeCommand_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased && !ViewModel.continuousOperationTimerStart)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.ContinuousOperationTimeCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ContinuousOperationTimeCommand_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased && !ViewModel.continuousOperationTimerStart)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.ContinuousOperationTimeCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnCCWArrowMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }
        
        private void btnCCWArrowMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnCCWArrowMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void SystemUnlockPIN_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SystemUnlockPINTextBox();
        }

        private void SystemUnlockPIN_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SystemUnlockPINTextBox();
        }

        private void SystemUnlockPIN_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SystemUnlockPINTextBox();
        }

        // Common method for processing number input
        private void ProcessNumberInput(int index)
        {
            if (ViewModel != null)
            {
                if (index == 1)
                {
                    if (canProcessInput)
                    {
                        ViewModel?.MainPageNavigateCommand?.Execute(null);
                        canProcessInput = false; // Prevent further input until debounce resets
                        debounceTimer.Start(); // Start debounce timer
                    }
                }
                else if (index == 2)
                {
                    if (canProcessInput)
                    {
                        ViewModel?.AlarmHistoryMasterNavigateCommand?.Execute(null);
                        canProcessInput = false; // Prevent further input until debounce resets
                        debounceTimer.Start(); // Start debounce timer
                    }
                }
                else if (index == 3)
                {
                    if (canProcessInput)
                    {
                        ViewModel?.SystemSettingRegister?.Execute(null);
                        canProcessInput = false; // Prevent further input until debounce resets
                        debounceTimer.Start(); // Start debounce timer
                    }
                }
                else if (index == 4)
                {
                    if (canProcessInput)
                    {
                        ViewModel?.ElevationEncorderResetCommand?.Execute(null);
                        canProcessInput = false; // Prevent further input until debounce resets
                        debounceTimer.Start(); // Start debounce timer
                    }
                }
                else if (index == 5)
                {
                    if (canProcessInput)
                    {
                        ViewModel?.AzimuthEncorderResetCommand?.Execute(null);
                        canProcessInput = false; // Prevent further input until debounce resets
                        debounceTimer.Start(); // Start debounce timer
                    }
                }
                else if (index == 6)
                {
                    if (canProcessInput)
                    {
                        ViewModel?.AlarmResetCommand?.Execute(null);
                        canProcessInput = false; // Prevent further input until debounce resets
                        debounceTimer.Start(); // Start debounce timer
                    }
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        // Initialize the debounce timer
        private void InitializeDebounceTimer()
        {
            debounceTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(200) // Set debounce time (200ms in this case)
            };
            debounceTimer.Tick += (s, e) =>
            {
                canProcessInput = true; // Reset the input flag after debounce period
                debounceTimer.Stop(); // Stop the timer after reset
            };
        }

        private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isTextboxClicked)
            {
                KeypadClose();
                isTextboxClicked = false;
            }
        }

        private void UserControl_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (isTextboxClicked)
            {
                KeypadClose();
                isTextboxClicked = false;
            }
        }

        private void UserControl_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (isTextboxClicked)
            {
                KeypadClose();
                isTextboxClicked = false;
            }
        }

        private void ElevationEncorderReset_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(4);
        }

        private void ElevationEncorderReset_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(4);
        }

        private void ElevationEncorderReset_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(4);
        }

        private void AzimuthEncorderReset_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(5);
        }

        private void AzimuthEncorderReset_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(5);
        }

        private void AzimuthEncorderReset_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(5);
        }

        private void BtnAlarmReset_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(6);
        }

        private void BtnAlarmReset_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(6);
        }

        private void BtnAlarmReset_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(6);
        }

        private void ContinuousOperationTimerStopCommand_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.ContinuousOperationTimerStopCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ContinuousOperationTimerStopCommand_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.ContinuousOperationTimerStopCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ContinuousOperationTimerStopCommand_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.ContinuousOperationTimerStopCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void UndaiIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UndaiIPAddressTextBox();
        }

        private void UndaiIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            UndaiIPAddressTextBox();
        }

        private void UndaiIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            UndaiIPAddressTextBox();
        }

        private void OriginOffsetAzimuth_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            OriginOffsetAzimuthTextBox();
        }

        private void OriginOffsetAzimuth_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            OriginOffsetAzimuthTextBox();
        }

        private void OriginOffsetAzimuth_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            OriginOffsetAzimuthTextBox();
        }

        private void OriginOffsetElevation_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            OriginOffsetElevationTextBox();
        }

        private void OriginOffsetElevation_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            OriginOffsetElevationTextBox();
        }

        private void OriginOffsetElevation_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            OriginOffsetElevationTextBox();
        }

        private void HighSpeedSetAzimuth_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            HighSpeedSetAzimuthTextBox();
        }

        private void HighSpeedSetAzimuth_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            HighSpeedSetAzimuthTextBox();
        }

        private void HighSpeedSetAzimuth_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            HighSpeedSetAzimuthTextBox();
        }

        private void HighSpeedSetElevation_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            HighSpeedSetElevationTextBox();
        }

        private void HighSpeedSetElevation_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            HighSpeedSetElevationTextBox();
        }

        private void HighSpeedSetElevation_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            HighSpeedSetElevationTextBox();
        }

        private void LowSpeedSetAzimuth_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LowSpeedSetAzimuthTextBox();
        }

        private void LowSpeedSetAzimuth_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LowSpeedSetAzimuthTextBox();
        }

        private void LowSpeedSetAzimuth_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LowSpeedSetAzimuthTextBox();
        }

        private void LowSpeedSetElevation_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LowSpeedSetElevationTextBox();
        }

        private void LowSpeedSetElevation_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LowSpeedSetElevationTextBox();
        }

        private void LowSpeedSetElevation_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LowSpeedSetElevationTextBox();
        }

        private void InchingSpeedSetAzimuth_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InchingSpeedSetAzimuthTextBox();
        }

        private void InchingSpeedSetAzimuth_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            InchingSpeedSetAzimuthTextBox();
        }

        private void InchingSpeedSetAzimuth_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            InchingSpeedSetAzimuthTextBox();
        }

        private void InchingSpeedSetElevation_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InchingSpeedSetElevationTextBox();
        }

        private void InchingSpeedSetElevation_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            InchingSpeedSetElevationTextBox();
        }

        private void InchingSpeedSetElevation_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            InchingSpeedSetElevationTextBox();
        }

        private void PeakSearchSpeed_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PeakSearchSpeedTextBox();
        }

        private void PeakSearchSpeed_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PeakSearchSpeedTextBox();
        }

        private void PeakSearchSpeed_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PeakSearchSpeedTextBox();
        }

        private void PeakSearchAzimuth_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PeakSearchAzimuthTextBox();
        }

        private void PeakSearchAzimuth_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PeakSearchAzimuthTextBox();
        }

        private void PeakSearchAzimuth_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PeakSearchAzimuthTextBox();
        }

        private void PeakSearchElevation_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PeakSearchElevationTextBox();
        }

        private void PeakSearchElevation_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PeakSearchElevationTextBox();
        }

        private void PeakSearchElevation_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PeakSearchElevationTextBox();
        }

        private void PeakSearchRSSILevel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PeakSearchRSSILevelTextBox();
        }

        private void PeakSearchRSSILevel_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PeakSearchRSSILevelTextBox();
        }

        private void PeakSearchRSSILevel_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PeakSearchRSSILevelTextBox();
        }

        private void DetailedPeakSearchStepAngle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DetailedPeakSearchStepAngleTextBox();
        }

        private void DetailedPeakSearchStepAngle_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            DetailedPeakSearchStepAngleTextBox();
        }

        private void DetailedPeakSearchStepAngle_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            DetailedPeakSearchStepAngleTextBox();
        }

        private void DetailedPeakSearchRSSILevel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DetailedPeakSearchRSSILevelTextBox();
        }

        private void DetailedPeakSearchRSSILevel_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            DetailedPeakSearchRSSILevelTextBox();
        }

        private void DetailedPeakSearchRSSILevel_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            DetailedPeakSearchRSSILevelTextBox();
        }

        private void StepStability_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            StepStabilityTextBox();
        }

        private void StepStability_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            StepStabilityTextBox();
        }

        private void StepStability_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            StepStabilityTextBox();
        }

        private void ContinuousOperationTime_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ContinuousOperationTimeTextBox();
        }

        private void ContinuousOperationTime_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ContinuousOperationTimeTextBox();
        }

        private void ContinuousOperationTime_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ContinuousOperationTimeTextBox();
        }

        private void UndaiSubnet_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UndaiSubnetTextBox();
        }

        private void UndaiSubnet_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            UndaiSubnetTextBox();
        }

        private void UndaiSubnet_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            UndaiSubnetTextBox();
        }

        private void DefaultGateway_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DefaultGatewayTextBox();
        }

        private void DefaultGateway_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            DefaultGatewayTextBox();
        }

        private void DefaultGateway_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            DefaultGatewayTextBox();
        }

        private void MasterAntennaIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MasterAntennaIPAddressTextBox();
        }

        private void MasterAntennaIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            MasterAntennaIPAddressTextBox();
        }

        private void MasterAntennaIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            MasterAntennaIPAddressTextBox();
        }
        private void PeakSearchRSSITurnLevel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PeakSearchRSSITurnLevelTextBox();
        }

        private void PeakSearchRSSITurnLevel_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PeakSearchRSSITurnLevelTextBox();
        }

        private void PeakSearchRSSITurnLevel_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PeakSearchRSSITurnLevelTextBox();
        }

        private void PeakSearchRSSDelay_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PeakSearchRSSDelayTextBox();
        }

        private void PeakSearchRSSDelay_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PeakSearchRSSDelayTextBox();
        }

        private void PeakSearchRSSDelay_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PeakSearchRSSDelayTextBox();
        }

        private void UpDownSearchAngle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UpDownSearchAngleTextBox();
        }

        private void UpDownSearchAngle_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            UpDownSearchAngleTextBox();
        }

        private void UpDownSearchAngle_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            UpDownSearchAngleTextBox();
        }

        private void RSSITurnbackThresholdLevel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            RSSITurnbackThresholdLevelTextBox();
        }

        private void RSSITurnbackThresholdLevel_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            RSSITurnbackThresholdLevelTextBox();
        }

        private void RSSITurnbackThresholdLevel_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            RSSITurnbackThresholdLevelTextBox();
        }

        private void UndaiIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 1;
                isTextboxClicked = true;
                backupString = ViewModel.UndaiIPAddress;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.UndaiIPAddress;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.UndaiIPAddress.Length > 0)
                        {
                            ViewModel.UndaiIPAddress = ViewModel.UndaiIPAddress.Substring(0, ViewModel.UndaiIPAddress.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.UndaiIPAddress = ViewModel.UndaiIPAddress;
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.UndaiIPAddress.Length == 0)
                        {
                            ViewModel.UndaiIPAddress = "0.";
                        }
                        else if (ViewModel.UndaiIPAddress.Length == 1 && ViewModel.UndaiIPAddress[0] == '-')
                        {
                            ViewModel.UndaiIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.UndaiIPAddress = ViewModel.UndaiIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.UndaiIPAddress.Length == 1 && ViewModel.UndaiIPAddress[0] == '0')
                        {
                            ViewModel.UndaiIPAddress = "";
                        }
                        ViewModel.UndaiIPAddress += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.UndaiIPAddress.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void OriginOffsetAzimuthTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 2; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.OriginOffsetAzimuth;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.OriginOffsetAzimuth;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.OriginOffsetAzimuth.Length > 0)
                        {
                            ViewModel.OriginOffsetAzimuth = ViewModel.OriginOffsetAzimuth.Substring(0, ViewModel.OriginOffsetAzimuth.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.OriginOffsetAzimuth.Length > 0)
                        {
                            if (ViewModel.OriginOffsetAzimuth[0] == '-')
                            {
                                ViewModel.OriginOffsetAzimuth = ViewModel.OriginOffsetAzimuth.Substring(1);
                            }
                            else
                            {
                                ViewModel.OriginOffsetAzimuth = '-' + ViewModel.OriginOffsetAzimuth;
                            }
                        }
                        else
                        {
                            ViewModel.OriginOffsetAzimuth = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.OriginOffsetAzimuth.Length == 0)
                        {
                            ViewModel.OriginOffsetAzimuth = "0.";
                        }
                        else if (ViewModel.OriginOffsetAzimuth.Contains("."))
                        {
                            ViewModel.OriginOffsetAzimuth = ViewModel.OriginOffsetAzimuth;
                        }
                        else if (ViewModel.OriginOffsetAzimuth.Length == 1 && ViewModel.OriginOffsetAzimuth[0] == '-')
                        {
                            ViewModel.OriginOffsetAzimuth = "-0.";
                        }
                        else
                        {
                            ViewModel.OriginOffsetAzimuth = ViewModel.OriginOffsetAzimuth + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.OriginOffsetAzimuth.Length == 1 && ViewModel.OriginOffsetAzimuth[0] == '0')
                        {
                            ViewModel.OriginOffsetAzimuth = "";
                        }
                        ViewModel.OriginOffsetAzimuth += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.OriginOffsetAzimuth.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void OriginOffsetElevationTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 3; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.OriginOffsetElevation;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.OriginOffsetElevation;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.OriginOffsetElevation.Length > 0)
                        {
                            ViewModel.OriginOffsetElevation = ViewModel.OriginOffsetElevation.Substring(0, ViewModel.OriginOffsetElevation.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.OriginOffsetElevation.Length > 0)
                        {
                            if (ViewModel.OriginOffsetElevation[0] == '-')
                            {
                                ViewModel.OriginOffsetElevation = ViewModel.OriginOffsetElevation.Substring(1);
                            }
                            else
                            {
                                ViewModel.OriginOffsetElevation = '-' + ViewModel.OriginOffsetElevation;
                            }
                        }
                        else
                        {
                            ViewModel.OriginOffsetElevation = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.OriginOffsetElevation.Length == 0)
                        {
                            ViewModel.OriginOffsetElevation = "0.";
                        }
                        else if (ViewModel.OriginOffsetElevation.Contains("."))
                        {
                            ViewModel.OriginOffsetElevation = ViewModel.OriginOffsetElevation;
                        }
                        else if (ViewModel.OriginOffsetElevation.Length == 1 && ViewModel.OriginOffsetElevation[0] == '-')
                        {
                            ViewModel.OriginOffsetElevation = "-0.";
                        }
                        else
                        {
                            ViewModel.OriginOffsetElevation = ViewModel.OriginOffsetElevation + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.OriginOffsetElevation.Length == 1 && ViewModel.OriginOffsetElevation[0] == '0')
                        {
                            ViewModel.OriginOffsetElevation = "";
                        }
                        ViewModel.OriginOffsetElevation += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.OriginOffsetElevation.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void HighSpeedSetAzimuthTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 4; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.HighSpeedSetAzimuth;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.HighSpeedSetAzimuth;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.HighSpeedSetAzimuth.Length > 0)
                        {
                            ViewModel.HighSpeedSetAzimuth = ViewModel.HighSpeedSetAzimuth.Substring(0, ViewModel.HighSpeedSetAzimuth.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.HighSpeedSetAzimuth.Length > 0)
                        {
                            if (ViewModel.HighSpeedSetAzimuth[0] == '-')
                            {
                                ViewModel.HighSpeedSetAzimuth = ViewModel.HighSpeedSetAzimuth.Substring(1);
                            }
                            else
                            {
                                ViewModel.HighSpeedSetAzimuth = '-' + ViewModel.HighSpeedSetAzimuth;
                            }
                        }
                        else
                        {
                            ViewModel.HighSpeedSetAzimuth = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.HighSpeedSetAzimuth.Length == 0)
                        {
                            ViewModel.HighSpeedSetAzimuth = "0.";
                        }
                        else if (ViewModel.HighSpeedSetAzimuth.Contains("."))
                        {
                            ViewModel.HighSpeedSetAzimuth = ViewModel.HighSpeedSetAzimuth;
                        }
                        else if (ViewModel.HighSpeedSetAzimuth.Length == 1 && ViewModel.HighSpeedSetAzimuth[0] == '-')
                        {
                            ViewModel.HighSpeedSetAzimuth = "-0.";
                        }
                        else
                        {
                            ViewModel.HighSpeedSetAzimuth = ViewModel.HighSpeedSetAzimuth + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.HighSpeedSetAzimuth.Length == 1 && ViewModel.HighSpeedSetAzimuth[0] == '0')
                        {
                            ViewModel.HighSpeedSetAzimuth = "";
                        }
                        ViewModel.HighSpeedSetAzimuth += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.HighSpeedSetAzimuth.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void HighSpeedSetElevationTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 5; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.HighSpeedSetElevation;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.HighSpeedSetElevation;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.HighSpeedSetElevation.Length > 0)
                        {
                            ViewModel.HighSpeedSetElevation = ViewModel.HighSpeedSetElevation.Substring(0, ViewModel.HighSpeedSetElevation.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.HighSpeedSetElevation.Length > 0)
                        {
                            if (ViewModel.HighSpeedSetElevation[0] == '-')
                            {
                                ViewModel.HighSpeedSetElevation = ViewModel.HighSpeedSetElevation.Substring(1);
                            }
                            else
                            {
                                ViewModel.HighSpeedSetElevation = '-' + ViewModel.HighSpeedSetElevation;
                            }
                        }
                        else
                        {
                            ViewModel.HighSpeedSetElevation = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.HighSpeedSetElevation.Length == 0)
                        {
                            ViewModel.HighSpeedSetElevation = "0.";
                        }
                        else if (ViewModel.HighSpeedSetElevation.Contains("."))
                        {
                            ViewModel.HighSpeedSetElevation = ViewModel.HighSpeedSetElevation;
                        }
                        else if (ViewModel.HighSpeedSetElevation.Length == 1 && ViewModel.HighSpeedSetElevation[0] == '-')
                        {
                            ViewModel.HighSpeedSetElevation = "-0.";
                        }
                        else
                        {
                            ViewModel.HighSpeedSetElevation = ViewModel.HighSpeedSetElevation + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.HighSpeedSetElevation.Length == 1 && ViewModel.HighSpeedSetElevation[0] == '0')
                        {
                            ViewModel.HighSpeedSetElevation = "";
                        }
                        ViewModel.HighSpeedSetElevation += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.HighSpeedSetElevation.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LowSpeedSetAzimuthTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 6; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.LowSpeedSetAzimuth;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.LowSpeedSetAzimuth;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LowSpeedSetAzimuth.Length > 0)
                        {
                            ViewModel.LowSpeedSetAzimuth = ViewModel.LowSpeedSetAzimuth.Substring(0, ViewModel.LowSpeedSetAzimuth.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LowSpeedSetAzimuth.Length > 0)
                        {
                            if (ViewModel.LowSpeedSetAzimuth[0] == '-')
                            {
                                ViewModel.LowSpeedSetAzimuth = ViewModel.LowSpeedSetAzimuth.Substring(1);
                            }
                            else
                            {
                                ViewModel.LowSpeedSetAzimuth = '-' + ViewModel.LowSpeedSetAzimuth;
                            }
                        }
                        else
                        {
                            ViewModel.LowSpeedSetAzimuth = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LowSpeedSetAzimuth.Length == 0)
                        {
                            ViewModel.LowSpeedSetAzimuth = "0.";
                        }
                        else if (ViewModel.LowSpeedSetAzimuth.Contains("."))
                        {
                            ViewModel.LowSpeedSetAzimuth = ViewModel.LowSpeedSetAzimuth;
                        }
                        else if (ViewModel.LowSpeedSetAzimuth.Length == 1 && ViewModel.LowSpeedSetAzimuth[0] == '-')
                        {
                            ViewModel.LowSpeedSetAzimuth = "-0.";
                        }
                        else
                        {
                            ViewModel.LowSpeedSetAzimuth = ViewModel.LowSpeedSetAzimuth + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LowSpeedSetAzimuth.Length == 1 && ViewModel.LowSpeedSetAzimuth[0] == '0')
                        {
                            ViewModel.LowSpeedSetAzimuth = "";
                        }
                        ViewModel.LowSpeedSetAzimuth += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.LowSpeedSetAzimuth.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LowSpeedSetElevationTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 7; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.LowSpeedSetElevation;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.LowSpeedSetElevation;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LowSpeedSetElevation.Length > 0)
                        {
                            ViewModel.LowSpeedSetElevation = ViewModel.LowSpeedSetElevation.Substring(0, ViewModel.LowSpeedSetElevation.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LowSpeedSetElevation.Length > 0)
                        {
                            if (ViewModel.LowSpeedSetElevation[0] == '-')
                            {
                                ViewModel.LowSpeedSetElevation = ViewModel.LowSpeedSetElevation.Substring(1);
                            }
                            else
                            {
                                ViewModel.LowSpeedSetElevation = '-' + ViewModel.LowSpeedSetElevation;
                            }
                        }
                        else
                        {
                            ViewModel.LowSpeedSetElevation = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LowSpeedSetElevation.Length == 0)
                        {
                            ViewModel.LowSpeedSetElevation = "0.";
                        }
                        else if (ViewModel.LowSpeedSetElevation.Contains("."))
                        {
                            ViewModel.LowSpeedSetElevation = ViewModel.LowSpeedSetElevation;
                        }
                        else if (ViewModel.LowSpeedSetElevation.Length == 1 && ViewModel.LowSpeedSetElevation[0] == '-')
                        {
                            ViewModel.LowSpeedSetElevation = "-0.";
                        }
                        else
                        {
                            ViewModel.LowSpeedSetElevation = ViewModel.LowSpeedSetElevation + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LowSpeedSetElevation.Length == 1 && ViewModel.LowSpeedSetElevation[0] == '0')
                        {
                            ViewModel.LowSpeedSetElevation = "";
                        }
                        ViewModel.LowSpeedSetElevation += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.LowSpeedSetElevation.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void InchingSpeedSetAzimuthTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 8; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.InchingSpeedSetAzimuth;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.InchingSpeedSetAzimuth;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.InchingSpeedSetAzimuth.Length > 0)
                        {
                            ViewModel.InchingSpeedSetAzimuth = ViewModel.InchingSpeedSetAzimuth.Substring(0, ViewModel.InchingSpeedSetAzimuth.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.InchingSpeedSetAzimuth.Length > 0)
                        {
                            if (ViewModel.InchingSpeedSetAzimuth[0] == '-')
                            {
                                ViewModel.InchingSpeedSetAzimuth = ViewModel.InchingSpeedSetAzimuth.Substring(1);
                            }
                            else
                            {
                                ViewModel.InchingSpeedSetAzimuth = '-' + ViewModel.InchingSpeedSetAzimuth;
                            }
                        }
                        else
                        {
                            ViewModel.InchingSpeedSetAzimuth = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.InchingSpeedSetAzimuth.Length == 0)
                        {
                            ViewModel.InchingSpeedSetAzimuth = "0.";
                        }
                        else if (ViewModel.InchingSpeedSetAzimuth.Contains("."))
                        {
                            ViewModel.InchingSpeedSetAzimuth = ViewModel.InchingSpeedSetAzimuth;
                        }
                        else if (ViewModel.InchingSpeedSetAzimuth.Length == 1 && ViewModel.InchingSpeedSetAzimuth[0] == '-')
                        {
                            ViewModel.InchingSpeedSetAzimuth = "-0.";
                        }
                        else
                        {
                            ViewModel.InchingSpeedSetAzimuth = ViewModel.InchingSpeedSetAzimuth + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.InchingSpeedSetAzimuth.Length == 1 && ViewModel.InchingSpeedSetAzimuth[0] == '0')
                        {
                            ViewModel.InchingSpeedSetAzimuth = "";
                        }
                        ViewModel.InchingSpeedSetAzimuth += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.InchingSpeedSetAzimuth.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void InchingSpeedSetElevationTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 9; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.InchingSpeedSetElevation;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.InchingSpeedSetElevation;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.InchingSpeedSetElevation.Length > 0)
                        {
                            ViewModel.InchingSpeedSetElevation = ViewModel.InchingSpeedSetElevation.Substring(0, ViewModel.InchingSpeedSetElevation.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.InchingSpeedSetElevation.Length > 0)
                        {
                            if (ViewModel.InchingSpeedSetElevation[0] == '-')
                            {
                                ViewModel.InchingSpeedSetElevation = ViewModel.InchingSpeedSetElevation.Substring(1);
                            }
                            else
                            {
                                ViewModel.InchingSpeedSetElevation = '-' + ViewModel.InchingSpeedSetElevation;
                            }
                        }
                        else
                        {
                            ViewModel.InchingSpeedSetElevation = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.InchingSpeedSetElevation.Length == 0)
                        {
                            ViewModel.InchingSpeedSetElevation = "0.";
                        }
                        else if (ViewModel.InchingSpeedSetElevation.Contains("."))
                        {
                            ViewModel.InchingSpeedSetElevation = ViewModel.InchingSpeedSetElevation;
                        }
                        else if (ViewModel.InchingSpeedSetElevation.Length == 1 && ViewModel.InchingSpeedSetElevation[0] == '-')
                        {
                            ViewModel.InchingSpeedSetElevation = "-0.";
                        }
                        else
                        {
                            ViewModel.InchingSpeedSetElevation = ViewModel.InchingSpeedSetElevation + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.InchingSpeedSetElevation.Length == 1 && ViewModel.InchingSpeedSetElevation[0] == '0')
                        {
                            ViewModel.InchingSpeedSetElevation = "";
                        }
                        ViewModel.InchingSpeedSetElevation += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.InchingSpeedSetElevation.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PeakSearchSpeedTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 10; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.PeakSearchSpeed;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.PeakSearchSpeed;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.PeakSearchSpeed.Length > 0)
                        {
                            ViewModel.PeakSearchSpeed = ViewModel.PeakSearchSpeed.Substring(0, ViewModel.PeakSearchSpeed.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.PeakSearchSpeed.Length > 0)
                        {
                            if (ViewModel.PeakSearchSpeed[0] == '-')
                            {
                                ViewModel.PeakSearchSpeed = ViewModel.PeakSearchSpeed.Substring(1);
                            }
                            else
                            {
                                ViewModel.PeakSearchSpeed = '-' + ViewModel.PeakSearchSpeed;
                            }
                        }
                        else
                        {
                            ViewModel.PeakSearchSpeed = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.PeakSearchSpeed.Length == 0)
                        {
                            ViewModel.PeakSearchSpeed = "0.";
                        }
                        else if (ViewModel.PeakSearchSpeed.Contains("."))
                        {
                            ViewModel.PeakSearchSpeed = ViewModel.PeakSearchSpeed;
                        }
                        else if (ViewModel.PeakSearchSpeed.Length == 1 && ViewModel.PeakSearchSpeed[0] == '-')
                        {
                            ViewModel.PeakSearchSpeed = "-0.";
                        }
                        else
                        {
                            ViewModel.PeakSearchSpeed = ViewModel.PeakSearchSpeed + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.PeakSearchSpeed.Length == 1 && ViewModel.PeakSearchSpeed[0] == '0')
                        {
                            ViewModel.PeakSearchSpeed = "";
                        }
                        ViewModel.PeakSearchSpeed += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.PeakSearchSpeed.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PeakSearchAzimuthTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 11; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.PeakSearchAzimuth;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.PeakSearchAzimuth;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.PeakSearchAzimuth.Length > 0)
                        {
                            ViewModel.PeakSearchAzimuth = ViewModel.PeakSearchAzimuth.Substring(0, ViewModel.PeakSearchAzimuth.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.PeakSearchAzimuth.Length > 0)
                        {
                            if (ViewModel.PeakSearchAzimuth[0] == '-')
                            {
                                ViewModel.PeakSearchAzimuth = ViewModel.PeakSearchAzimuth.Substring(1);
                            }
                            else
                            {
                                ViewModel.PeakSearchAzimuth = '-' + ViewModel.PeakSearchAzimuth;
                            }
                        }
                        else
                        {
                            ViewModel.PeakSearchAzimuth = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.PeakSearchAzimuth.Length == 0)
                        {
                            ViewModel.PeakSearchAzimuth = "0.";
                        }
                        else if (ViewModel.PeakSearchAzimuth.Contains("."))
                        {
                            ViewModel.PeakSearchAzimuth = ViewModel.PeakSearchAzimuth;
                        }
                        else if (ViewModel.PeakSearchAzimuth.Length == 1 && ViewModel.PeakSearchAzimuth[0] == '-')
                        {
                            ViewModel.PeakSearchAzimuth = "-0.";
                        }
                        else
                        {
                            ViewModel.PeakSearchAzimuth = ViewModel.PeakSearchAzimuth + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.PeakSearchAzimuth.Length == 1 && ViewModel.PeakSearchAzimuth[0] == '0')
                        {
                            ViewModel.PeakSearchAzimuth = "";
                        }
                        ViewModel.PeakSearchAzimuth += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.PeakSearchAzimuth.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PeakSearchElevationTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 12; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.PeakSearchElevation;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.PeakSearchElevation;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.PeakSearchElevation.Length > 0)
                        {
                            ViewModel.PeakSearchElevation = ViewModel.PeakSearchElevation.Substring(0, ViewModel.PeakSearchElevation.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.PeakSearchElevation.Length > 0)
                        {
                            if (ViewModel.PeakSearchElevation[0] == '-')
                            {
                                ViewModel.PeakSearchElevation = ViewModel.PeakSearchElevation.Substring(1);
                            }
                            else
                            {
                                ViewModel.PeakSearchElevation = '-' + ViewModel.PeakSearchElevation;
                            }
                        }
                        else
                        {
                            ViewModel.PeakSearchElevation = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.PeakSearchElevation.Length == 0)
                        {
                            ViewModel.PeakSearchElevation = "0.";
                        }
                        else if (ViewModel.PeakSearchElevation.Contains("."))
                        {
                            ViewModel.PeakSearchElevation = ViewModel.PeakSearchElevation;
                        }
                        else if (ViewModel.PeakSearchElevation.Length == 1 && ViewModel.PeakSearchElevation[0] == '-')
                        {
                            ViewModel.PeakSearchElevation = "-0.";
                        }
                        else
                        {
                            ViewModel.PeakSearchElevation = ViewModel.PeakSearchElevation + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.PeakSearchElevation.Length == 1 && ViewModel.PeakSearchElevation[0] == '0')
                        {
                            ViewModel.PeakSearchElevation = "";
                        }
                        ViewModel.PeakSearchElevation += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.PeakSearchElevation.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PeakSearchRSSILevelTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 13; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.PeakSearchRSSILevel;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.PeakSearchRSSILevel;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.PeakSearchRSSILevel.Length > 0)
                        {
                            ViewModel.PeakSearchRSSILevel = ViewModel.PeakSearchRSSILevel.Substring(0, ViewModel.PeakSearchRSSILevel.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.PeakSearchRSSILevel.Length > 0)
                        {
                            if (ViewModel.PeakSearchRSSILevel[0] == '-')
                            {
                                ViewModel.PeakSearchRSSILevel = ViewModel.PeakSearchRSSILevel.Substring(1);
                            }
                            else
                            {
                                ViewModel.PeakSearchRSSILevel = '-' + ViewModel.PeakSearchRSSILevel;
                            }
                        }
                        else
                        {
                            ViewModel.PeakSearchRSSILevel = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.PeakSearchRSSILevel.Length == 0)
                        {
                            ViewModel.PeakSearchRSSILevel = "0.";
                        }
                        else if (ViewModel.PeakSearchRSSILevel.Contains("."))
                        {
                            ViewModel.PeakSearchRSSILevel = ViewModel.PeakSearchRSSILevel;
                        }
                        else if (ViewModel.PeakSearchRSSILevel.Length == 1 && ViewModel.PeakSearchRSSILevel[0] == '-')
                        {
                            ViewModel.PeakSearchRSSILevel = "-0.";
                        }
                        else
                        {
                            ViewModel.PeakSearchRSSILevel = ViewModel.PeakSearchRSSILevel + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.PeakSearchRSSILevel.Length == 1 && ViewModel.PeakSearchRSSILevel[0] == '0')
                        {
                            ViewModel.PeakSearchRSSILevel = "";
                        }
                        ViewModel.PeakSearchRSSILevel += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.PeakSearchRSSILevel.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void DetailedPeakSearchStepAngleTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 14; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.DetailedPeakSearchStepAngle;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.DetailedPeakSearchStepAngle;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.DetailedPeakSearchStepAngle.Length > 0)
                        {
                            ViewModel.DetailedPeakSearchStepAngle = ViewModel.DetailedPeakSearchStepAngle.Substring(0, ViewModel.DetailedPeakSearchStepAngle.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.DetailedPeakSearchStepAngle.Length > 0)
                        {
                            if (ViewModel.DetailedPeakSearchStepAngle[0] == '-')
                            {
                                ViewModel.DetailedPeakSearchStepAngle = ViewModel.DetailedPeakSearchStepAngle.Substring(1);
                            }
                            else
                            {
                                ViewModel.DetailedPeakSearchStepAngle = '-' + ViewModel.DetailedPeakSearchStepAngle;
                            }
                        }
                        else
                        {
                            ViewModel.DetailedPeakSearchStepAngle = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.DetailedPeakSearchStepAngle.Length == 0)
                        {
                            ViewModel.DetailedPeakSearchStepAngle = "0.";
                        }
                        else if (ViewModel.DetailedPeakSearchStepAngle.Contains("."))
                        {
                            ViewModel.DetailedPeakSearchStepAngle = ViewModel.DetailedPeakSearchStepAngle;
                        }
                        else if (ViewModel.DetailedPeakSearchStepAngle.Length == 1 && ViewModel.DetailedPeakSearchStepAngle[0] == '-')
                        {
                            ViewModel.DetailedPeakSearchStepAngle = "-0.";
                        }
                        else
                        {
                            ViewModel.DetailedPeakSearchStepAngle = ViewModel.DetailedPeakSearchStepAngle + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.DetailedPeakSearchStepAngle.Length == 1 && ViewModel.DetailedPeakSearchStepAngle[0] == '0')
                        {
                            ViewModel.DetailedPeakSearchStepAngle = "";
                        }
                        ViewModel.DetailedPeakSearchStepAngle += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.DetailedPeakSearchStepAngle.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void DetailedPeakSearchRSSILevelTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 15; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.DetailedPeakSearchRSSILevel;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.DetailedPeakSearchRSSILevel;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.DetailedPeakSearchRSSILevel.Length > 0)
                        {
                            ViewModel.DetailedPeakSearchRSSILevel = ViewModel.DetailedPeakSearchRSSILevel.Substring(0, ViewModel.DetailedPeakSearchRSSILevel.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.DetailedPeakSearchRSSILevel.Length > 0)
                        {
                            if (ViewModel.DetailedPeakSearchRSSILevel[0] == '-')
                            {
                                ViewModel.DetailedPeakSearchRSSILevel = ViewModel.DetailedPeakSearchRSSILevel.Substring(1);
                            }
                            else
                            {
                                ViewModel.DetailedPeakSearchRSSILevel = '-' + ViewModel.DetailedPeakSearchRSSILevel;
                            }
                        }
                        else
                        {
                            ViewModel.DetailedPeakSearchRSSILevel = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.DetailedPeakSearchRSSILevel.Length == 0)
                        {
                            ViewModel.DetailedPeakSearchRSSILevel = "0.";
                        }
                        else if (ViewModel.DetailedPeakSearchRSSILevel.Contains("."))
                        {
                            ViewModel.DetailedPeakSearchRSSILevel = ViewModel.DetailedPeakSearchRSSILevel;
                        }
                        else if (ViewModel.DetailedPeakSearchRSSILevel.Length == 1 && ViewModel.DetailedPeakSearchRSSILevel[0] == '-')
                        {
                            ViewModel.DetailedPeakSearchRSSILevel = "-0.";
                        }
                        else
                        {
                            ViewModel.DetailedPeakSearchRSSILevel = ViewModel.DetailedPeakSearchRSSILevel + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.DetailedPeakSearchRSSILevel.Length == 1 && ViewModel.DetailedPeakSearchRSSILevel[0] == '0')
                        {
                            ViewModel.DetailedPeakSearchRSSILevel = "";
                        }
                        ViewModel.DetailedPeakSearchRSSILevel += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.DetailedPeakSearchRSSILevel.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void StepStabilityTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 16; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.StepStability;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.StepStability;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.StepStability.Length > 0)
                        {
                            ViewModel.StepStability = ViewModel.StepStability.Substring(0, ViewModel.StepStability.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.StepStability.Length > 0)
                        {
                            if (ViewModel.StepStability[0] == '-')
                            {
                                ViewModel.StepStability = ViewModel.StepStability.Substring(1);
                            }
                            else
                            {
                                ViewModel.StepStability = '-' + ViewModel.StepStability;
                            }
                        }
                        else
                        {
                            ViewModel.StepStability = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.StepStability.Length == 0)
                        {
                            ViewModel.StepStability = "0.";
                        }
                        else if (ViewModel.StepStability.Contains("."))
                        {
                            ViewModel.StepStability = ViewModel.StepStability;
                        }
                        else if (ViewModel.StepStability.Length == 1 && ViewModel.StepStability[0] == '-')
                        {
                            ViewModel.StepStability = "-0.";
                        }
                        else
                        {
                            ViewModel.StepStability = ViewModel.StepStability + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.StepStability.Length == 1 && ViewModel.StepStability[0] == '0')
                        {
                            ViewModel.StepStability = "";
                        }
                        ViewModel.StepStability += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.StepStability.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ContinuousOperationTimeTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 17; // Assign the appropriate textbox number
            isTextboxClicked = true;
            backupString = ViewModel.ContinuousOperationTime;
                if (!ViewModel.continuousOperationTimerStart)
                {
                    _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                    _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.ContinuousOperationTime;
                    _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                    {
                        if (key == "Backspace")
                        {
                            if (ViewModel.ContinuousOperationTime.Length > 0)
                            {
                                ViewModel.ContinuousOperationTime = ViewModel.ContinuousOperationTime.Substring(0, ViewModel.ContinuousOperationTime.Length - 1);
                            }
                        }
                        else if (key == "+/-")
                        {
                            if (ViewModel.ContinuousOperationTime.Length > 0)
                            {
                                if (ViewModel.ContinuousOperationTime[0] == '-')
                                {
                                    ViewModel.ContinuousOperationTime = ViewModel.ContinuousOperationTime.Substring(1);
                                }
                                else
                                {
                                    ViewModel.ContinuousOperationTime = '-' + ViewModel.ContinuousOperationTime;
                                }
                            }
                            else
                            {
                                ViewModel.ContinuousOperationTime = "-";
                            }
                        }
                        else if (key == ".")
                        {
                            if (ViewModel.ContinuousOperationTime.Length == 0)
                            {
                                ViewModel.ContinuousOperationTime = "0.";
                            }
                            else if (ViewModel.ContinuousOperationTime.Contains("."))
                            {
                                ViewModel.ContinuousOperationTime = ViewModel.ContinuousOperationTime;
                            }
                            else if (ViewModel.ContinuousOperationTime.Length == 1 && ViewModel.ContinuousOperationTime[0] == '-')
                            {
                                ViewModel.ContinuousOperationTime = "-0.";
                            }
                            else
                            {
                                ViewModel.ContinuousOperationTime = ViewModel.ContinuousOperationTime + ".";
                            }
                        }
                        else
                        {
                            if (ViewModel.ContinuousOperationTime.Length == 1 && ViewModel.ContinuousOperationTime[0] == '0')
                            {
                                ViewModel.ContinuousOperationTime = "";
                            }
                            ViewModel.ContinuousOperationTime += key;
                        }
                        _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.ContinuousOperationTime.ToString();
                    };
                    _numericKeyboardWindowSystemSettingMaster.Show();
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SystemUnlockPINTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 18;
                isTextboxClicked = true;
                backupString = ViewModel.SystemUnlockPIN;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = string.Empty;
                ViewModel.SystemUnlockPIN = string.Empty;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SystemUnlockPIN.Length > 0)
                        {
                            ViewModel.SystemUnlockPIN = ViewModel.SystemUnlockPIN.Substring(0, ViewModel.SystemUnlockPIN.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.SystemUnlockPIN = ViewModel.SystemUnlockPIN;
                    }
                    else if (key == ".")
                    {
                        ViewModel.SystemUnlockPIN = ViewModel.SystemUnlockPIN;
                    }
                    else
                    {
                        if (ViewModel.SystemUnlockPIN.Length == 1 && ViewModel.SystemUnlockPIN[0] == '0')
                        {
                            ViewModel.SystemUnlockPIN = "";
                        }
                        ViewModel.SystemUnlockPIN += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.SystemUnlockPIN.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void UndaiSubnetTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 19;
                isTextboxClicked = true;
                backupString = ViewModel.UndaiSubnet;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.UndaiSubnet;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.UndaiSubnet.Length > 0)
                        {
                            ViewModel.UndaiSubnet = ViewModel.UndaiSubnet.Substring(0, ViewModel.UndaiSubnet.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.UndaiSubnet = ViewModel.UndaiSubnet;
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.UndaiSubnet.Length == 0)
                        {
                            ViewModel.UndaiSubnet = "0.";
                        }
                        else if (ViewModel.UndaiSubnet.Length == 1 && ViewModel.UndaiSubnet[0] == '-')
                        {
                            ViewModel.UndaiSubnet = "-0.";
                        }
                        else
                        {
                            ViewModel.UndaiSubnet = ViewModel.UndaiSubnet + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.UndaiSubnet.Length == 1 && ViewModel.UndaiSubnet[0] == '0')
                        {
                            ViewModel.UndaiSubnet = "";
                        }
                        ViewModel.UndaiSubnet += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.UndaiSubnet.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void DefaultGatewayTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 20;
                isTextboxClicked = true;
                backupString = ViewModel.DefaultGateway;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.DefaultGateway;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.DefaultGateway.Length > 0)
                        {
                            ViewModel.DefaultGateway = ViewModel.DefaultGateway.Substring(0, ViewModel.DefaultGateway.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.DefaultGateway = ViewModel.DefaultGateway;
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.DefaultGateway.Length == 0)
                        {
                            ViewModel.DefaultGateway = "0.";
                        }
                        else if (ViewModel.DefaultGateway.Length == 1 && ViewModel.DefaultGateway[0] == '-')
                        {
                            ViewModel.DefaultGateway = "-0.";
                        }
                        else
                        {
                            ViewModel.DefaultGateway = ViewModel.DefaultGateway + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.DefaultGateway.Length == 1 && ViewModel.DefaultGateway[0] == '0')
                        {
                            ViewModel.DefaultGateway = "";
                        }
                        ViewModel.DefaultGateway += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.DefaultGateway.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void MasterAntennaIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 21;
                isTextboxClicked = true;
                backupString = ViewModel.MasterAntennaIPAddress;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.MasterAntennaIPAddress;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.MasterAntennaIPAddress.Length > 0)
                        {
                            ViewModel.MasterAntennaIPAddress = ViewModel.MasterAntennaIPAddress.Substring(0, ViewModel.MasterAntennaIPAddress.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.MasterAntennaIPAddress = ViewModel.MasterAntennaIPAddress;
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.MasterAntennaIPAddress.Length == 0)
                        {
                            ViewModel.MasterAntennaIPAddress = "0.";
                        }
                        else if (ViewModel.MasterAntennaIPAddress.Length == 1 && ViewModel.MasterAntennaIPAddress[0] == '-')
                        {
                            ViewModel.MasterAntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.MasterAntennaIPAddress = ViewModel.MasterAntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.MasterAntennaIPAddress.Length == 1 && ViewModel.MasterAntennaIPAddress[0] == '0')
                        {
                            ViewModel.MasterAntennaIPAddress = "";
                        }
                        ViewModel.MasterAntennaIPAddress += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.MasterAntennaIPAddress.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PeakSearchRSSITurnLevelTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 22;
                isTextboxClicked = true;
                backupString = ViewModel.PeakSearchRSSITurnLevel;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.PeakSearchRSSITurnLevel;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.PeakSearchRSSITurnLevel.Length > 0)
                        {
                            ViewModel.PeakSearchRSSITurnLevel = ViewModel.PeakSearchRSSITurnLevel.Substring(0, ViewModel.PeakSearchRSSITurnLevel.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.PeakSearchRSSITurnLevel = ViewModel.PeakSearchRSSITurnLevel;
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.PeakSearchRSSITurnLevel.Length == 0)
                        {
                            ViewModel.PeakSearchRSSITurnLevel = "0.";
                        }
                        else if (ViewModel.PeakSearchRSSITurnLevel.Length == 1 && ViewModel.PeakSearchRSSITurnLevel[0] == '-')
                        {
                            ViewModel.PeakSearchRSSITurnLevel = "-0.";
                        }
                        else
                        {
                            ViewModel.PeakSearchRSSITurnLevel = ViewModel.PeakSearchRSSITurnLevel + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.PeakSearchRSSITurnLevel.Length == 1 && ViewModel.PeakSearchRSSITurnLevel[0] == '0')
                        {
                            ViewModel.PeakSearchRSSITurnLevel = "";
                        }
                        ViewModel.PeakSearchRSSITurnLevel += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.PeakSearchRSSITurnLevel.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
        }

        private void PeakSearchRSSDelayTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 23;
                isTextboxClicked = true;
                backupString = ViewModel.PeakSearchRSSIDelay;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.PeakSearchRSSIDelay;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.PeakSearchRSSIDelay.Length > 0)
                        {
                            ViewModel.PeakSearchRSSIDelay = ViewModel.PeakSearchRSSIDelay.Substring(0, ViewModel.PeakSearchRSSIDelay.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.PeakSearchRSSIDelay = ViewModel.PeakSearchRSSIDelay;
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.PeakSearchRSSIDelay.Length == 0)
                        {
                            ViewModel.PeakSearchRSSIDelay = "0.";
                        }
                        else if (ViewModel.PeakSearchRSSIDelay.Length == 1 && ViewModel.PeakSearchRSSIDelay[0] == '-')
                        {
                            ViewModel.PeakSearchRSSIDelay = "-0.";
                        }
                        else
                        {
                            ViewModel.PeakSearchRSSIDelay = ViewModel.PeakSearchRSSIDelay + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.PeakSearchRSSIDelay.Length == 1 && ViewModel.PeakSearchRSSIDelay[0] == '0')
                        {
                            ViewModel.PeakSearchRSSIDelay = "";
                        }
                        ViewModel.PeakSearchRSSIDelay += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.PeakSearchRSSIDelay.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void UpDownSearchAngleTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 24;
                isTextboxClicked = true;
                backupString = ViewModel.UpDownSearchAngle;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.UpDownSearchAngle;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.UpDownSearchAngle.Length > 0)
                        {
                            ViewModel.UpDownSearchAngle = ViewModel.UpDownSearchAngle.Substring(0, ViewModel.UpDownSearchAngle.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.UpDownSearchAngle = ViewModel.UpDownSearchAngle;
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.UpDownSearchAngle.Length == 0)
                        {
                            ViewModel.UpDownSearchAngle = "0.";
                        }
                        else if (ViewModel.UpDownSearchAngle.Length == 1 && ViewModel.UpDownSearchAngle[0] == '-')
                        {
                            ViewModel.UpDownSearchAngle = "-0.";
                        }
                        else
                        {
                            ViewModel.UpDownSearchAngle = ViewModel.UpDownSearchAngle + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.UpDownSearchAngle.Length == 1 && ViewModel.UpDownSearchAngle[0] == '0')
                        {
                            ViewModel.UpDownSearchAngle = "";
                        }
                        ViewModel.UpDownSearchAngle += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.UpDownSearchAngle.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void RSSITurnbackThresholdLevelTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 25;
                isTextboxClicked = true;
                backupString = ViewModel.RSSITurnbackThresholdLevel;
                _numericKeyboardWindowSystemSettingMaster = new NumericKeyboardWindowSystemSettingMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingMaster.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.RSSITurnbackThresholdLevel;
                _numericKeyboardWindowSystemSettingMaster.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.RSSITurnbackThresholdLevel.Length > 0)
                        {
                            ViewModel.RSSITurnbackThresholdLevel = ViewModel.RSSITurnbackThresholdLevel.Substring(0, ViewModel.RSSITurnbackThresholdLevel.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.RSSITurnbackThresholdLevel = ViewModel.RSSITurnbackThresholdLevel;
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.RSSITurnbackThresholdLevel.Length == 0)
                        {
                            ViewModel.RSSITurnbackThresholdLevel = "0.";
                        }
                        else if (ViewModel.RSSITurnbackThresholdLevel.Length == 1 && ViewModel.RSSITurnbackThresholdLevel[0] == '-')
                        {
                            ViewModel.RSSITurnbackThresholdLevel = "-0.";
                        }
                        else
                        {
                            ViewModel.RSSITurnbackThresholdLevel = ViewModel.RSSITurnbackThresholdLevel + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.RSSITurnbackThresholdLevel.Length == 1 && ViewModel.RSSITurnbackThresholdLevel[0] == '0')
                        {
                            ViewModel.RSSITurnbackThresholdLevel = "";
                        }
                        ViewModel.RSSITurnbackThresholdLevel += key;
                    }
                    _numericKeyboardWindowSystemSettingMaster.KeyPad.Text = ViewModel.RSSITurnbackThresholdLevel.ToString();
                };
                _numericKeyboardWindowSystemSettingMaster.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void KeypadClose()
        {
            if (ViewModel != null)
            {
                _numericKeyboardWindowSystemSettingMaster.Close();
                Keyboard.ClearFocus();

                if (textBoxNo == 1 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.UndaiIPAddress = backupString;
                }
                else if (textBoxNo == 2 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.OriginOffsetAzimuth = backupString;
                }
                else if (textBoxNo == 3 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.OriginOffsetElevation = backupString;
                }
                else if (textBoxNo == 4 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.HighSpeedSetAzimuth = backupString;
                }
                else if (textBoxNo == 5 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.HighSpeedSetElevation = backupString;
                }
                else if (textBoxNo == 6 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.LowSpeedSetAzimuth = backupString;
                }
                else if (textBoxNo == 7 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.LowSpeedSetElevation = backupString;
                }
                else if (textBoxNo == 8 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.InchingSpeedSetAzimuth = backupString;
                }
                else if (textBoxNo == 9 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.InchingSpeedSetElevation = backupString;
                }
                else if (textBoxNo == 10 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.PeakSearchSpeed = backupString;
                }
                else if (textBoxNo == 11 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.PeakSearchAzimuth = backupString;
                }
                else if (textBoxNo == 12 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.PeakSearchElevation = backupString;
                }
                else if (textBoxNo == 13 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.PeakSearchRSSILevel = backupString;
                }
                else if (textBoxNo == 14 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.DetailedPeakSearchStepAngle = backupString;
                }
                else if (textBoxNo == 15 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.DetailedPeakSearchRSSILevel = backupString;
                }
                else if (textBoxNo == 16 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.StepStability = backupString;
                }
                else if (textBoxNo == 17 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.ContinuousOperationTime = backupString;
                }
                else if (textBoxNo == 18 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.SystemUnlockPIN = backupString;
                    ViewModel.PINKeyboardClose = false;
                }
                else if (textBoxNo == 19 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.UndaiSubnet = backupString;
                }
                else if (textBoxNo == 20 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.DefaultGateway = backupString;
                }
                else if (textBoxNo == 21 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.MasterAntennaIPAddress = backupString;
                }
                else if (textBoxNo == 22 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.PeakSearchRSSITurnLevel = backupString;
                }
                else if (textBoxNo == 23 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.PeakSearchRSSIDelay = backupString;
                }
                else if (textBoxNo == 24 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.UpDownSearchAngle = backupString;
                }
                else if (textBoxNo == 25 && _numericKeyboardWindowSystemSettingMaster._status != 1)
                {
                    ViewModel.RSSITurnbackThresholdLevel = backupString;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void MasterRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (ViewModel != null)
            {
                ViewModel._systemSettingMasterModel.MasterRadioButtonChecked(sender, e);
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SlaveRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (ViewModel != null)
            {
                ViewModel._systemSettingMasterModel.SlaveRadioButtonChecked(sender, e);
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void AlarmHistoryMasterNavigateMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void AlarmHistoryMasterNavigateMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void AlarmHistoryMasterNavigateMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void MainPageNavigateMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void MainPageNavigateMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void MainPageNavigateMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void SystemSettingRegister_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            SystemSettingRegister.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
        }

        private void SystemSettingRegister_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            SystemSettingRegister.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
        }

        private void SystemSettingRegister_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            SystemSettingRegister.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
        }
    }
}
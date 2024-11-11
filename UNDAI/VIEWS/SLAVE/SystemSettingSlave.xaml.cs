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
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.VIEWS.BASE;

namespace UNDAI.VIEWS.SLAVE
{
    /// <summary>
    /// Interaction logic for SystemSettingSlave.xaml
    /// </summary>
    public partial class SystemSettingSlave : UserControl
    {
        NumericKeyboardWindowSystemSettingSlave _numericKeyboardWindowSystemSettingSlave;
        int textBoxNo;
        string backupString;
        bool isTextboxClicked = false;
        bool mouseReleased = true;
        bool touchReleased = true;
        bool stylusReleased = true;
        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;
        App app;

        private SystemSettingSlaveViewModel? ViewModel => DataContext as SystemSettingSlaveViewModel;

        public SystemSettingSlave()
        {
            InitializeComponent();
            InitializeDebounceTimer(); // Initialize debounce logic
            app = (App)Application.Current;
            CreateAppClassAfterDelay();

            if (ViewModel != null)
            {
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(0, ViewModel, "");
            }
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._systemSettingSlaveViewModel;
            }
        }

        private void btnUpArrowMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
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
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnUpArrowMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
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
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnUpArrowMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
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
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnUpArrowMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
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
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnUpArrowMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
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
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnUpArrowMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            if (ViewModel != null)
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
            else
            {
                CreateAppClassAfterDelay();
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
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.BtnDownArrowMainPageMouseDownCommand.Execute(e);
                    mouseReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnDownArrowMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!mouseReleased)
                {
                    (sender as UIElement)?.ReleaseMouseCapture();
                    e.Handled = true;
                    ViewModel?.BtnDownArrowMainPageMouseUpCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnDownArrowMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.BtnDownArrowMainPageMouseDownCommand.Execute(e);
                    stylusReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnDownArrowMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!stylusReleased)
                {
                    (sender as UIElement)?.ReleaseStylusCapture();
                    e.Handled = true;
                    ViewModel?.BtnDownArrowMainPageMouseUpCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnDownArrowMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.BtnDownArrowMainPageMouseDownCommand.Execute(e);
                    touchReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnDownArrowMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!touchReleased)
                {
                    (sender as UIElement)?.ReleaseTouchCapture(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.BtnDownArrowMainPageMouseUpCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
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
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.BtnCWMainPageMouseDownCommand.Execute(e);
                    mouseReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnCWArrowMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!mouseReleased)
                {
                    (sender as UIElement)?.ReleaseMouseCapture();
                    e.Handled = true;
                    ViewModel?.BtnCWMainPageMouseUpCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnCWArrowMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.BtnCWMainPageMouseDownCommand.Execute(e);
                    stylusReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnCWArrowMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!stylusReleased)
                {
                    (sender as UIElement)?.ReleaseStylusCapture();
                    e.Handled = true;
                    ViewModel?.BtnCWMainPageMouseUpCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnCWArrowMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.BtnCWMainPageMouseDownCommand.Execute(e);
                    touchReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnCWArrowMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!touchReleased)
                {
                    (sender as UIElement)?.ReleaseTouchCapture(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.BtnCWMainPageMouseUpCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
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
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.BtnCCWMainPageMouseDownCommand.Execute(e);
                    mouseReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnCCWArrowMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!mouseReleased)
                {
                    (sender as UIElement)?.ReleaseMouseCapture();
                    e.Handled = true;
                    ViewModel?.BtnCCWMainPageMouseUpCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnCCWArrowMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.BtnCCWMainPageMouseDownCommand.Execute(e);
                    stylusReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnCCWArrowMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!stylusReleased)
                {
                    (sender as UIElement)?.ReleaseStylusCapture();
                    e.Handled = true;
                    ViewModel?.BtnCCWMainPageMouseUpCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnCCWArrowMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.BtnCCWMainPageMouseDownCommand.Execute(e);
                    touchReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnCCWArrowMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!touchReleased)
                {
                    (sender as UIElement)?.ReleaseTouchCapture(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.BtnCCWMainPageMouseUpCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
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

        private void DetailedPeakSearchSpeed_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DetailedPeakSearchSpeedTextBox();
        }

        private void DetailedPeakSearchSpeed_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            DetailedPeakSearchSpeedTextBox();
        }

        private void DetailedPeakSearchSpeed_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            DetailedPeakSearchSpeedTextBox();
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

        private void SlaveAntennaIPAddress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            SlaveAntennaIPAddressTextBox();
        }

        private void SlaveAntennaIPAddress_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            SlaveAntennaIPAddressTextBox();
        }

        private void SlaveAntennaIPAddress_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            SlaveAntennaIPAddressTextBox();
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

        private void DetailedPeakSearchAzimuth_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DetailedPeakSearchAzimuthTextBox();
        }

        private void DetailedPeakSearchAzimuth_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            DetailedPeakSearchAzimuthTextBox();
        }

        private void DetailedPeakSearchAzimuth_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            DetailedPeakSearchAzimuthTextBox();
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

        private void MainPageNavigateSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void MainPageNavigateSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void MainPageNavigateSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void AlarmHistorySlaveNavigateSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void AlarmHistorySlaveNavigateSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void AlarmHistorySlaveNavigateSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void ElevationStepValue_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ElevationStepValueTextBox();
        }

        private void ElevationStepValue_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ElevationStepValueTextBox();
        }

        private void ElevationStepValue_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ElevationStepValueTextBox();
        }

        private void AzimuthStepValue_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AzimuthStepValueTextBox();
        }

        private void AzimuthStepValue_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            AzimuthStepValueTextBox();
        }

        private void AzimuthStepValue_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            AzimuthStepValueTextBox();
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
                        ViewModel?.AlarmHistorySlaveNavigateCommand?.Execute(null);
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

        private void UndaiIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 1;
                isTextboxClicked = true;
                backupString = ViewModel.UndaiIPAddress;
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.UndaiIPAddress;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.UndaiIPAddress.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.OriginOffsetAzimuth;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.OriginOffsetAzimuth.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.OriginOffsetElevation;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.OriginOffsetElevation.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.HighSpeedSetAzimuth;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.HighSpeedSetAzimuth.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.HighSpeedSetElevation;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.HighSpeedSetElevation.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.LowSpeedSetAzimuth;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.LowSpeedSetAzimuth.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.LowSpeedSetElevation;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.LowSpeedSetElevation.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.InchingSpeedSetAzimuth;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.InchingSpeedSetAzimuth.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.InchingSpeedSetElevation;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.InchingSpeedSetElevation.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.PeakSearchSpeed;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.PeakSearchSpeed.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.PeakSearchAzimuth;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.PeakSearchAzimuth.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.PeakSearchElevation;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.PeakSearchElevation.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.PeakSearchRSSILevel;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                                ViewModel.PeakSearchRSSILevel = ViewModel.PeakSearchRSSILevel;
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
                        if (ViewModel.PeakSearchRSSILevel.Length == 2 && ViewModel.PeakSearchRSSILevel[1] == '0')
                        {
                            ViewModel.PeakSearchRSSILevel = "-";
                        }
                        if (ViewModel.PeakSearchRSSILevel.Length == 0)
                        {
                            ViewModel.PeakSearchRSSILevel = "-";
                        }
                        ViewModel.PeakSearchRSSILevel += key;
                    }
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.PeakSearchRSSILevel.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void DetailedPeakSearchSpeedTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 28; // Assign the appropriate textbox number
                isTextboxClicked = true;
                backupString = ViewModel.DetailedPeakSearchSpeed;
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.DetailedPeakSearchSpeed;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.DetailedPeakSearchSpeed.Length > 0)
                        {
                            ViewModel.DetailedPeakSearchSpeed = ViewModel.DetailedPeakSearchSpeed.Substring(0, ViewModel.DetailedPeakSearchSpeed.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.DetailedPeakSearchSpeed.Length > 0)
                        {
                            if (ViewModel.DetailedPeakSearchSpeed[0] == '-')
                            {
                                ViewModel.DetailedPeakSearchSpeed = ViewModel.DetailedPeakSearchSpeed.Substring(1);
                            }
                            else
                            {
                                ViewModel.DetailedPeakSearchSpeed = '-' + ViewModel.DetailedPeakSearchSpeed;
                            }
                        }
                        else
                        {
                            ViewModel.DetailedPeakSearchSpeed = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.DetailedPeakSearchSpeed.Length == 0)
                        {
                            ViewModel.DetailedPeakSearchSpeed = "0.";
                        }
                        else if (ViewModel.DetailedPeakSearchSpeed.Contains("."))
                        {
                            ViewModel.DetailedPeakSearchSpeed = ViewModel.DetailedPeakSearchSpeed;
                        }
                        else if (ViewModel.DetailedPeakSearchSpeed.Length == 1 && ViewModel.DetailedPeakSearchSpeed[0] == '-')
                        {
                            ViewModel.DetailedPeakSearchSpeed = "-0.";
                        }
                        else
                        {
                            ViewModel.DetailedPeakSearchSpeed = ViewModel.DetailedPeakSearchSpeed + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.DetailedPeakSearchSpeed.Length == 1 && ViewModel.DetailedPeakSearchSpeed[0] == '0')
                        {
                            ViewModel.DetailedPeakSearchSpeed = "";
                        }
                        ViewModel.DetailedPeakSearchSpeed += key;
                    }
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.DetailedPeakSearchSpeed.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.DetailedPeakSearchStepAngle;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.DetailedPeakSearchStepAngle.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.DetailedPeakSearchRSSILevel;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                                ViewModel.DetailedPeakSearchRSSILevel = ViewModel.DetailedPeakSearchRSSILevel;
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
                        if (ViewModel.DetailedPeakSearchRSSILevel.Length == 2 && ViewModel.DetailedPeakSearchRSSILevel[1] == '0')
                        {
                            ViewModel.DetailedPeakSearchRSSILevel = "-";
                        }
                        if (ViewModel.DetailedPeakSearchRSSILevel.Length == 0)
                        {
                            ViewModel.DetailedPeakSearchRSSILevel = "-";
                        }
                        ViewModel.DetailedPeakSearchRSSILevel += key;
                    }
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.DetailedPeakSearchRSSILevel.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.StepStability;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.StepStability.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.ContinuousOperationTime;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.ContinuousOperationTime.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = string.Empty;
                ViewModel.SystemUnlockPIN = string.Empty;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.SystemUnlockPIN.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.UndaiSubnet;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.UndaiSubnet.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.DefaultGateway;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.DefaultGateway.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SlaveAntennaIPAddressTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 21;
                isTextboxClicked = true;
                backupString = ViewModel.SlaveAntennaIPAddress;
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.SlaveAntennaIPAddress;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.SlaveAntennaIPAddress.Length > 0)
                        {
                            ViewModel.SlaveAntennaIPAddress = ViewModel.SlaveAntennaIPAddress.Substring(0, ViewModel.SlaveAntennaIPAddress.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.SlaveAntennaIPAddress = ViewModel.SlaveAntennaIPAddress;
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.SlaveAntennaIPAddress.Length == 0)
                        {
                            ViewModel.SlaveAntennaIPAddress = "0.";
                        }
                        else if (ViewModel.SlaveAntennaIPAddress.Length == 1 && ViewModel.SlaveAntennaIPAddress[0] == '-')
                        {
                            ViewModel.SlaveAntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.SlaveAntennaIPAddress = ViewModel.SlaveAntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.SlaveAntennaIPAddress.Length == 1 && ViewModel.SlaveAntennaIPAddress[0] == '0')
                        {
                            ViewModel.SlaveAntennaIPAddress = "";
                        }
                        ViewModel.SlaveAntennaIPAddress += key;
                    }
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.SlaveAntennaIPAddress.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.PeakSearchRSSITurnLevel;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                        if (ViewModel.PeakSearchRSSITurnLevel.Length > 0)
                        {
                            if (ViewModel.PeakSearchRSSITurnLevel[0] == '-')
                            {
                                ViewModel.PeakSearchRSSITurnLevel = ViewModel.PeakSearchRSSITurnLevel;
                            }
                            else
                            {
                                ViewModel.PeakSearchRSSITurnLevel = '-' + ViewModel.PeakSearchRSSITurnLevel;
                            }
                        }
                        else
                        {
                            ViewModel.PeakSearchRSSITurnLevel = "-";
                        }
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
                        if (ViewModel.PeakSearchRSSITurnLevel.Length == 2 && ViewModel.PeakSearchRSSITurnLevel[1] == '0')
                        {
                            ViewModel.PeakSearchRSSITurnLevel = "-";
                        }
                        if (ViewModel.PeakSearchRSSITurnLevel.Length == 0)
                        {
                            ViewModel.PeakSearchRSSITurnLevel = "-";
                        }
                        ViewModel.PeakSearchRSSITurnLevel += key;
                    }
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.PeakSearchRSSITurnLevel.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PeakSearchRSSDelayTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 23;
                isTextboxClicked = true;
                backupString = ViewModel.PeakSearchRSSIDelay;
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.PeakSearchRSSIDelay;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.PeakSearchRSSIDelay.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.UpDownSearchAngle;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                        if (ViewModel.UpDownSearchAngle.Length > 0)
                        {
                            if (ViewModel.UpDownSearchAngle[0] == '-')
                            {
                                ViewModel.UpDownSearchAngle = ViewModel.UpDownSearchAngle.Substring(1);
                            }
                            else
                            {
                                ViewModel.UpDownSearchAngle = '-' + ViewModel.UpDownSearchAngle;
                            }
                        }
                        else
                        {
                            ViewModel.UpDownSearchAngle = "-";
                        }
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
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.UpDownSearchAngle.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void DetailedPeakSearchAzimuthTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 29;
                isTextboxClicked = true;
                backupString = ViewModel.DetailedPeakSearchAzimuth;
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.DetailedPeakSearchAzimuth;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.DetailedPeakSearchAzimuth.Length > 0)
                        {
                            ViewModel.DetailedPeakSearchAzimuth = ViewModel.DetailedPeakSearchAzimuth.Substring(0, ViewModel.DetailedPeakSearchAzimuth.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.DetailedPeakSearchAzimuth.Length > 0)
                        {
                            if (ViewModel.DetailedPeakSearchAzimuth[0] == '-')
                            {
                                ViewModel.DetailedPeakSearchAzimuth = ViewModel.DetailedPeakSearchAzimuth.Substring(1);
                            }
                            else
                            {
                                ViewModel.DetailedPeakSearchAzimuth = '-' + ViewModel.DetailedPeakSearchAzimuth;
                            }
                        }
                        else
                        {
                            ViewModel.DetailedPeakSearchAzimuth = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.DetailedPeakSearchAzimuth.Length == 0)
                        {
                            ViewModel.DetailedPeakSearchAzimuth = "0.";
                        }
                        else if (ViewModel.DetailedPeakSearchAzimuth.Length == 1 && ViewModel.DetailedPeakSearchAzimuth[0] == '-')
                        {
                            ViewModel.DetailedPeakSearchAzimuth = "-0.";
                        }
                        else
                        {
                            ViewModel.DetailedPeakSearchAzimuth = ViewModel.DetailedPeakSearchAzimuth + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.DetailedPeakSearchAzimuth.Length == 1 && ViewModel.DetailedPeakSearchAzimuth[0] == '0')
                        {
                            ViewModel.DetailedPeakSearchAzimuth = "";
                        }
                        ViewModel.DetailedPeakSearchAzimuth += key;
                    }
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.DetailedPeakSearchAzimuth.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.RSSITurnbackThresholdLevel;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
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
                        if (ViewModel.RSSITurnbackThresholdLevel.Length > 0)
                        {
                            if (ViewModel.RSSITurnbackThresholdLevel[0] == '-')
                            {
                                ViewModel.RSSITurnbackThresholdLevel = ViewModel.RSSITurnbackThresholdLevel;
                            }
                            else
                            {
                                ViewModel.RSSITurnbackThresholdLevel = '-' + ViewModel.RSSITurnbackThresholdLevel;
                            }
                        }
                        else
                        {
                            ViewModel.RSSITurnbackThresholdLevel = "-";
                        }
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
                        if (ViewModel.RSSITurnbackThresholdLevel.Length == 2 && ViewModel.RSSITurnbackThresholdLevel[1] == '0')
                        {
                            ViewModel.RSSITurnbackThresholdLevel = "-";
                        }
                        if (ViewModel.RSSITurnbackThresholdLevel.Length == 0)
                        {
                            ViewModel.RSSITurnbackThresholdLevel = "-";
                        }
                        ViewModel.RSSITurnbackThresholdLevel += key;
                    }
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.RSSITurnbackThresholdLevel.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationStepValueTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 26;
                isTextboxClicked = true;
                backupString = ViewModel.ElevationStepValue;
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.ElevationStepValue;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationStepValue.Length > 0)
                        {
                            ViewModel.ElevationStepValue = ViewModel.ElevationStepValue.Substring(0, ViewModel.ElevationStepValue.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.ElevationStepValue = ViewModel.ElevationStepValue;
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.ElevationStepValue.Length == 0)
                        {
                            ViewModel.ElevationStepValue = "0.";
                        }
                        else if (ViewModel.ElevationStepValue.Length == 1 && ViewModel.ElevationStepValue[0] == '-')
                        {
                            ViewModel.ElevationStepValue = "0.";
                        }
                        else
                        {
                            ViewModel.ElevationStepValue = ViewModel.ElevationStepValue + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.ElevationStepValue.Length == 1 && ViewModel.ElevationStepValue[0] == '0')
                        {
                            ViewModel.ElevationStepValue = "";
                        }
                        ViewModel.ElevationStepValue += key;
                    }
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.ElevationStepValue.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void AzimuthStepValueTextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 27;
                isTextboxClicked = true;
                backupString = ViewModel.AzimuthStepValue;
                _numericKeyboardWindowSystemSettingSlave = new NumericKeyboardWindowSystemSettingSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSystemSettingSlave.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.AzimuthStepValue;
                _numericKeyboardWindowSystemSettingSlave.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.AzimuthStepValue.Length > 0)
                        {
                            ViewModel.AzimuthStepValue = ViewModel.AzimuthStepValue.Substring(0, ViewModel.AzimuthStepValue.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        ViewModel.AzimuthStepValue = ViewModel.AzimuthStepValue;
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.AzimuthStepValue.Length == 0)
                        {
                            ViewModel.AzimuthStepValue = "0.";
                        }
                        else if (ViewModel.AzimuthStepValue.Length == 1 && ViewModel.AzimuthStepValue[0] == '-')
                        {
                            ViewModel.AzimuthStepValue = "0.";
                        }
                        else
                        {
                            ViewModel.AzimuthStepValue = ViewModel.AzimuthStepValue + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.AzimuthStepValue.Length == 1 && ViewModel.AzimuthStepValue[0] == '0')
                        {
                            ViewModel.AzimuthStepValue = "";
                        }
                        ViewModel.AzimuthStepValue += key;
                    }
                    _numericKeyboardWindowSystemSettingSlave.KeyPad.Text = ViewModel.AzimuthStepValue.ToString();
                };
                _numericKeyboardWindowSystemSettingSlave.Show();
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
                _numericKeyboardWindowSystemSettingSlave.Close();
                Keyboard.ClearFocus();

                if (textBoxNo == 1 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.UndaiIPAddress = backupString;
                }
                else if (textBoxNo == 2 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.OriginOffsetAzimuth = backupString;
                }
                else if (textBoxNo == 3 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.OriginOffsetElevation = backupString;
                }
                else if (textBoxNo == 4 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.HighSpeedSetAzimuth = backupString;
                }
                else if (textBoxNo == 5 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.HighSpeedSetElevation = backupString;
                }
                else if (textBoxNo == 6 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.LowSpeedSetAzimuth = backupString;
                }
                else if (textBoxNo == 7 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.LowSpeedSetElevation = backupString;
                }
                else if (textBoxNo == 8 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.InchingSpeedSetAzimuth = backupString;
                }
                else if (textBoxNo == 9 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.InchingSpeedSetElevation = backupString;
                }
                else if (textBoxNo == 10 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.PeakSearchSpeed = backupString;
                }
                else if (textBoxNo == 11 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.PeakSearchAzimuth = backupString;
                }
                else if (textBoxNo == 12 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.PeakSearchElevation = backupString;
                }
                else if (textBoxNo == 13 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.PeakSearchRSSILevel = backupString;
                }
                else if (textBoxNo == 14 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.DetailedPeakSearchStepAngle = backupString;
                }
                else if (textBoxNo == 15 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.DetailedPeakSearchRSSILevel = backupString;
                }
                else if (textBoxNo == 16 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.StepStability = backupString;
                }
                else if (textBoxNo == 17 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.ContinuousOperationTime = backupString;
                }
                else if (textBoxNo == 19 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.UndaiSubnet = backupString;
                }
                else if (textBoxNo == 20 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.DefaultGateway = backupString;
                }
                else if (textBoxNo == 21 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.SlaveAntennaIPAddress = backupString;
                }
                else if (textBoxNo == 22 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.PeakSearchRSSITurnLevel = backupString;
                }
                else if (textBoxNo == 23 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.PeakSearchRSSIDelay = backupString;
                }
                else if (textBoxNo == 24 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.UpDownSearchAngle = backupString;
                }
                else if (textBoxNo == 25 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.RSSITurnbackThresholdLevel = backupString;
                }
                else if (textBoxNo == 26 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.ElevationStepValue = backupString;
                }
                else if (textBoxNo == 27 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.AzimuthStepValue = backupString;
                }
                else if (textBoxNo == 28 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.DetailedPeakSearchSpeed = backupString;
                }
                else if (textBoxNo == 29 && _numericKeyboardWindowSystemSettingSlave._status != 1)
                {
                    ViewModel.DetailedPeakSearchAzimuth = backupString;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        public Color MasterSelectedColor()
        {
            Color selectedColor = Color.FromRgb(0, 153, 204);
            if (ViewModel != null)
            {
                if (ViewModel.SelectedMode == 1)
                {
                    selectedColor = Color.FromRgb(0, 153, 204);
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
            return selectedColor;
        }

        public Color SlaveSelectedColor()
        {
            Color selectedColor = Color.FromRgb(0, 153, 204);
            if (ViewModel != null)
            {
                if (ViewModel.SelectedMode == 2)
                {
                    selectedColor = Color.FromRgb(0, 153, 204);
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
            return selectedColor;
        }

        private void MasterRadioButton_Checked(object sender, RoutedEventArgs e)
        {
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

        private void SlaveRadioButton_Checked(object sender, RoutedEventArgs e)
        {
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
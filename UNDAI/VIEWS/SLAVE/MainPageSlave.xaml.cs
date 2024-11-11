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
using UNDAI.COMMANDS.SLAVE;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.VIEWS.BASE;

namespace UNDAI.VIEWS.SLAVE
{
    /// <summary>
    /// Interaction logic for MainPageSlave.xaml
    /// </summary>
    public partial class MainPageSlave : UserControl
    {
        bool mouseReleased = true;
        bool touchReleased = true;
        bool stylusReleased = true;
        NumericKeyboardWindowMainSlave _numericKeyboardWindow;
        bool isTextboxClicked = false;
        int textBoxNo;
        string backupString;
        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;
        App app;

        private MainPageSlaveViewModel? ViewModel => DataContext as MainPageSlaveViewModel;

        public MainPageSlave()
        {
            InitializeComponent();
            InitializeDebounceTimer(); // Initialize debounce logic
            app = (App)Application.Current;
            CreateAppClassAfterDelay();

            if (ViewModel != null)
            {
                _numericKeyboardWindow = new NumericKeyboardWindowMainSlave(0, ViewModel, "");
            }
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._mainPageSlaveViewModel;
            }
        }

        // CONNECT BUTTON
        private void btnConnect_PreviewMouseDown(object sender, MouseButtonEventArgs e)
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
                    ViewModel?.ConnectCommandMouseDownCommand.Execute(e);
                    mouseReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnConnect_PreviewMouseUp(object sender, MouseButtonEventArgs e)
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
                    ViewModel?.ConnectCommandMouseUpCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }


        private void btnConnect_PreviewTouchDown(object sender, TouchEventArgs e)
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
                    ViewModel?.ConnectCommandMouseDownCommand.Execute(e);
                    touchReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnConnect_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!touchReleased)
                {
                    // Release the touch capture
                    (sender as UIElement)?.ReleaseTouchCapture(e.TouchDevice);
                    // Prevent further processing
                    e.Handled = true;
                    // Execute the ViewModel command
                    ViewModel?.ConnectCommandMouseUpCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnConnect_PreviewStylusDown(object sender, StylusDownEventArgs e)
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
                    ViewModel?.ConnectCommandMouseDownCommand.Execute(e);
                    stylusReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnConnect_PreviewStylusUp(object sender, StylusEventArgs e)
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
                    ViewModel?.ConnectCommandMouseUpCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnConnect_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Allow mouse moves to propagate normally unless you have a specific reason to prevent it
        }

        private void btnConnect_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Allow touch moves to propagate normally unless necessary
        }

        private void btnConnect_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Allow stylus moves to propagate unless necessary
        }

        // UPARROW BUTTON
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
                if (!touchReleased)
                {
                    // Release the touch capture
                    (sender as UIElement)?.ReleaseTouchCapture(e.TouchDevice);
                    // Prevent further processing
                    e.Handled = true;
                    // Execute the ViewModel command
                    ViewModel?.BtnUpArrowMainPageMouseUpCommand.Execute(e);
                    touchReleased = true;
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

        // Optional: Handle MouseMove to prevent unintended behavior
        private void btnUpArrowMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Allow mouse moves to propagate normally unless you have a specific reason to prevent it
        }

        private void btnUpArrowMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Allow touch moves to propagate normally unless necessary
        }

        private void btnUpArrowMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Allow stylus moves to propagate unless necessary
        }

        // DOWN ARROW BUTTON
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
        private void btnDownArrowMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnDownArrowMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnDownArrowMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        // CCW ARROW BUTTON
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

        private void btnCCWArrowMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnCCWArrowMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnCCWArrowMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }


        // CW ARROW BUTTON
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

        private void btnCWArrowMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnCWArrowMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnCWArrowMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            KeypadClose();
        }

        private void UserControl_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            KeypadClose();
        }

        private void UserControl_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            KeypadClose();
        }

        private void KeypadClose()
        {
            if (ViewModel != null)
            {
                _numericKeyboardWindow.Close();
                Keyboard.ClearFocus();
                if (textBoxNo == 1 && _numericKeyboardWindow._status != 1)
                {
                    ViewModel.ElevationAngleInputSlave = backupString;

                }
                else if (textBoxNo == 2 && _numericKeyboardWindow._status != 1)
                {
                    ViewModel.AzimuthAngleInputSlave = backupString;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnSelfReg_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void btnSelfReg_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnSelfReg_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void btnSelfReg_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnSelfReg_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void btnSelfReg_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnStationDB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void btnStationDB_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnStationDB_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void btnStationDB_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnStationDB_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void btnStationDB_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnHighSpeedBtnMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.HighSpeedBtnSlaveCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnHighSpeedBtnMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.HighSpeedBtnSlaveCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnHighSpeedBtnMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.HighSpeedBtnSlaveCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnHighSpeedBtnMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnHighSpeedBtnMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnHighSpeedBtnMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnLowSpeedBtnMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.LowSpeedBtnSlaveCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnLowSpeedBtnMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.LowSpeedBtnSlaveCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnLowSpeedBtnMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.LowSpeedBtnSlaveCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnLowSpeedBtnMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnLowSpeedBtnMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnLowSpeedBtnMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnInchingSpeedBtnMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.InchingSpeedBtnSlaveCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnInchingSpeedBtnMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.InchingSpeedBtnSlaveCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnInchingSpeedBtnMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.InchingSpeedBtnSlaveCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnInchingSpeedBtnMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnInchingSpeedBtnMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnInchingSpeedBtnMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnElevationAngleSetSlaveMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.ElevationAngleSetSlaveCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnElevationAngleSetSlaveMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.ElevationAngleSetSlaveCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnElevationAngleSetSlaveMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.ElevationAngleSetSlaveCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnElevationAngleSetSlaveMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnElevationAngleSetSlaveMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnElevationAngleSetSlaveMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnAzimuthAngleSetSlaveMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.AzimuthAngleSetSlaveCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnAzimuthAngleSetSlaveMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.AzimuthAngleSetSlaveCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnAzimuthAngleSetSlaveMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.AzimuthAngleSetSlaveCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnAzimuthAngleSetSlaveMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnAzimuthAngleSetSlaveMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnAzimuthAngleSetSlaveMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }


        private void OnElevationAngleInputSlaveTextBoxGotFocus(object sender, MouseButtonEventArgs e)
        {
            ElevationAngleInputSlaveTextBox();
        }

        private void OnElevationAngleInputSlaveTextBoxGotFocus(object sender, TouchEventArgs e)
        {
            ElevationAngleInputSlaveTextBox();
        }

        private void OnElevationAngleInputSlaveTextBoxGotFocus(object sender, StylusDownEventArgs e)
        {
            ElevationAngleInputSlaveTextBox();
        }

        private void OnAzimuthAngleInputSlaveTextBoxGotFocus(object sender, MouseButtonEventArgs e)
        {
            AzimuthAngleInputSlaveTextBox();
        }

        private void OnAzimuthAngleInputSlaveTextBoxGotFocus(object sender, StylusDownEventArgs e)
        {
            AzimuthAngleInputSlaveTextBox();
        }

        private void OnAzimuthAngleInputSlaveTextBoxGotFocus(object sender, TouchEventArgs e)
        {
            AzimuthAngleInputSlaveTextBox();
        }

        public void ElevationAngleInputSlaveTextBox()
        {
            if (ViewModel != null)
            {
                //_numericKeyboardWindow.Close();
                Keyboard.ClearFocus();
                textBoxNo = 1;
                backupString = ViewModel.ElevationAngleInputSlave;
                _numericKeyboardWindow = new NumericKeyboardWindowMainSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindow.Owner = Application.Current.MainWindow;
                _numericKeyboardWindow.KeyPad.Text = ViewModel.ElevationAngleInputSlave;
                _numericKeyboardWindow.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationAngleInputSlave.Length > 0)
                        {
                            ViewModel.ElevationAngleInputSlave = ViewModel.ElevationAngleInputSlave.Substring(0, ViewModel.ElevationAngleInputSlave.Length - 1);
                        }
                        else
                        {
                            ViewModel.ElevationAngleInputSlave = ViewModel.ElevationAngleInputSlave;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.ElevationAngleInputSlave.Length > 0)
                        {
                            if (ViewModel.ElevationAngleInputSlave[0] == '-')
                            {
                                ViewModel.ElevationAngleInputSlave = ViewModel.ElevationAngleInputSlave.Substring(1);
                            }
                            else
                            {
                                ViewModel.ElevationAngleInputSlave = '-' + ViewModel.ElevationAngleInputSlave;
                            }
                        }
                        else
                        {
                            ViewModel.ElevationAngleInputSlave = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.ElevationAngleInputSlave.Length == 0)
                        {
                            ViewModel.ElevationAngleInputSlave = "0.";
                        }
                        else if (ViewModel.ElevationAngleInputSlave.Contains("."))
                        {
                            ViewModel.ElevationAngleInputSlave = ViewModel.ElevationAngleInputSlave;
                        }
                        else if (ViewModel.ElevationAngleInputSlave.Length == 1 && ViewModel.ElevationAngleInputSlave[0] == '-')
                        {
                            ViewModel.ElevationAngleInputSlave = "-0.";
                        }
                        else
                        {
                            ViewModel.ElevationAngleInputSlave = ViewModel.ElevationAngleInputSlave + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.ElevationAngleInputSlave.Length == 1 && ViewModel.ElevationAngleInputSlave[0] == '0')
                        {
                            ViewModel.ElevationAngleInputSlave = "";
                        }
                        ViewModel.ElevationAngleInputSlave += key;
                    };
                    _numericKeyboardWindow.KeyPad.Text = ViewModel.ElevationAngleInputSlave.ToString();
                };
                _numericKeyboardWindow.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        public void AzimuthAngleInputSlaveTextBox()
        {
            if (ViewModel != null)
            {
                //_numericKeyboardWindow.Close();
                Keyboard.ClearFocus();
                textBoxNo = 2;
                backupString = ViewModel.AzimuthAngleInputSlave;
                _numericKeyboardWindow = new NumericKeyboardWindowMainSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindow.Owner = Application.Current.MainWindow;
                _numericKeyboardWindow.KeyPad.Text = ViewModel.AzimuthAngleInputSlave;

                _numericKeyboardWindow.KeyPressed += (s, key) =>
                {

                    if (key == "Backspace")
                    {
                        if (ViewModel.AzimuthAngleInputSlave.Length > 0)
                        {
                            ViewModel.AzimuthAngleInputSlave = ViewModel.AzimuthAngleInputSlave.Substring(0, ViewModel.AzimuthAngleInputSlave.Length - 1);
                        }
                        else
                        {
                            ViewModel.AzimuthAngleInputSlave = ViewModel.AzimuthAngleInputSlave;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.AzimuthAngleInputSlave.Length > 0)
                        {
                            if (ViewModel.AzimuthAngleInputSlave[0] == '-')
                            {
                                ViewModel.AzimuthAngleInputSlave = ViewModel.AzimuthAngleInputSlave.Substring(1);
                            }
                            else
                            {
                                ViewModel.AzimuthAngleInputSlave = '-' + ViewModel.AzimuthAngleInputSlave;
                            }
                        }
                        else
                        {
                            ViewModel.AzimuthAngleInputSlave = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.AzimuthAngleInputSlave.Length == 0)
                        {
                            ViewModel.AzimuthAngleInputSlave = "0.";
                        }
                        else if (ViewModel.AzimuthAngleInputSlave.Length == 1 && ViewModel.AzimuthAngleInputSlave[0] == '-')
                        {
                            ViewModel.AzimuthAngleInputSlave = "-0.";
                        }
                        else if (ViewModel.AzimuthAngleInputSlave.Contains("."))
                        {
                            ViewModel.AzimuthAngleInputSlave = ViewModel.AzimuthAngleInputSlave;
                        }
                        else
                        {
                            ViewModel.AzimuthAngleInputSlave = ViewModel.AzimuthAngleInputSlave + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.AzimuthAngleInputSlave.Length == 1 && ViewModel.AzimuthAngleInputSlave[0] == '0')
                        {
                            ViewModel.AzimuthAngleInputSlave = "";
                        }
                        ViewModel.AzimuthAngleInputSlave += key;
                    }
                    _numericKeyboardWindow.KeyPad.Text = ViewModel.AzimuthAngleInputSlave.ToString();
                };
                _numericKeyboardWindow.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnSaveAngleMainPageSlaveMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            btnSaveAngleMainPage.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
            btnSaveAngleMainPage.Foreground = new SolidColorBrush(Colors.White);
            ProcessNumberInput(5);
        }

        private void btnSaveAngleMainPageSlaveMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            btnSaveAngleMainPage.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
            btnSaveAngleMainPage.Foreground = new SolidColorBrush(Colors.White);
            ProcessNumberInput(5);
        }

        private void btnSaveAngleMainPageSlaveMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            btnSaveAngleMainPage.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
            btnSaveAngleMainPage.Foreground = new SolidColorBrush(Colors.White);
            ProcessNumberInput(5);
        }

        private void btnSaveAngleMainPageSlaveMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnSaveAngleMainPageSlaveMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnSaveAngleMainPageSlaveMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnLoadLoadAngleMainPageSlaveMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            btnLoadAngleMainPage.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
            btnLoadAngleMainPage.Foreground = new SolidColorBrush(Colors.White);
            ProcessNumberInput(4);
        }

        private void btnLoadLoadAngleMainPageSlaveMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            btnLoadAngleMainPage.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
            btnLoadAngleMainPage.Foreground = new SolidColorBrush(Colors.White);
            ProcessNumberInput(4);
        }

        private void btnLoadLoadAngleMainPageSlaveMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            btnLoadAngleMainPage.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
            btnLoadAngleMainPage.Foreground = new SolidColorBrush(Colors.White);
            ProcessNumberInput(4);
        }

        private void btnLoadLoadAngleMainPageSlaveMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnLoadLoadAngleMainPageSlaveMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnLoadLoadAngleMainPageSlaveMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnHomePositionMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.HomePositionDownCommand.Execute(e);
                    mouseReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnHomePositionMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.HomePositionDownCommand.Execute(e);
                    stylusReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnHomePositionMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.HomePositionDownCommand.Execute(e);
                    touchReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnHomePositionMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!mouseReleased)
                {
                    (sender as UIElement)?.ReleaseMouseCapture();
                    e.Handled = true;
                    ViewModel?.HomePositionUpCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnHomePositionMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!stylusReleased)
                {
                    (sender as UIElement)?.ReleaseStylusCapture();
                    e.Handled = true;
                    ViewModel?.HomePositionUpCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnHomePositionMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!touchReleased)
                {
                    (sender as UIElement)?.ReleaseTouchCapture(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.HomePositionUpCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnHomePositionMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnHomePositionMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnHomePositionMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnDirectionSearchMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.DirectionSearchDownCommand.Execute(e);
                    mouseReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnDirectionSearchMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.DirectionSearchDownCommand.Execute(e);
                    stylusReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnDirectionSearchMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.DirectionSearchDownCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnDirectionSearchMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!mouseReleased)
                {
                    (sender as UIElement)?.ReleaseMouseCapture();
                    e.Handled = true;
                    ViewModel?.DirectionSearchUPCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnDirectionSearchMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!stylusReleased)
                {
                    (sender as UIElement)?.ReleaseStylusCapture();
                    e.Handled = true;
                    ViewModel?.DirectionSearchUPCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnDirectionSearchMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!touchReleased)
                {
                    (sender as UIElement)?.ReleaseTouchCapture(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.DirectionSearchUPCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnDirectionSearchMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnDirectionSearchMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnDirectionSearchMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnPeakSearchMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.PeakSearchDownCommand.Execute(e);
                    mouseReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnPeakSearchMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.PeakSearchDownCommand.Execute(e);
                    stylusReleased = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnPeakSearchMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.PeakSearchDownCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnPeakSearchMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!mouseReleased)
                {
                    (sender as UIElement)?.ReleaseMouseCapture();
                    e.Handled = true;
                    ViewModel?.PeakSearchUpCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnPeakSearchMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!stylusReleased)
                {
                    (sender as UIElement)?.ReleaseStylusCapture();
                    e.Handled = true;
                    ViewModel?.PeakSearchUpCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnPeakSearchMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (!touchReleased)
                {
                    (sender as UIElement)?.ReleaseTouchCapture(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.PeakSearchUpCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnPeakSearchMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnPeakSearchMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnPeakSearchMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void StopSlaveButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.StopCommand.Execute(e);
                    mouseReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void StopSlaveButton_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (touchReleased)
                {
                    (sender as UIElement)?.CaptureTouch(e.TouchDevice);
                    e.Handled = true;
                    ViewModel?.StopCommand.Execute(e);
                    touchReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void StopSlaveButton_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (stylusReleased)
                {
                    (sender as UIElement)?.CaptureStylus();
                    e.Handled = true;
                    ViewModel?.StopCommand.Execute(e);
                    stylusReleased = true;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void StopSlaveButton_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void StopSlaveButton_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void StopSlaveButton_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnSystemSetting_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel?.SystemSettingSlaveCommand != null)
                {
                    if (ViewModel?.Connected == "CONNECT")
                    {
                        ViewModel?.SystemSettingSlaveCommand.Execute(e);
                    }
                    else
                    {
                        SystemUnlockPINTextBox();
                    }
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnSystemSetting_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel?.SystemSettingSlaveCommand != null)
                {
                    if (ViewModel?.Connected == "CONNECT")
                    {
                        ViewModel?.SystemSettingSlaveCommand.Execute(e);
                    }
                    else
                    {
                        SystemUnlockPINTextBox();
                    }
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnSystemSetting_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel?.SystemSettingSlaveCommand != null)
                {
                    if (ViewModel?.Connected == "CONNECT")
                    {
                        ViewModel?.SystemSettingSlaveCommand.Execute(e);
                    }
                    else
                    {
                        SystemUnlockPINTextBox();
                    }
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void btnSystemSetting_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnSystemSetting_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnSystemSetting_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnBaseStationRegistration_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(3);
        }

        private void btnBaseStationRegistration_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(3);
        }

        private void btnBaseStationRegistration_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(3);
        }

        private void btnBaseStationRegistration_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnBaseStationRegistration_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnBaseStationRegistration_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void MainPageUnitChangeCommandSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.UnitMainSlaveCommand?.Execute(e);
        }

        private void MainPageUnitChangeCommandSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ViewModel?.UnitMainSlaveCommand?.Execute(e);
        }

        private void MainPageUnitChangeCommandSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ViewModel?.UnitMainSlaveCommand?.Execute(e);
        }

        // Common method for processing number input
        private void ProcessNumberInput(int index)
        {
            if (ViewModel != null)
            {
                switch (index)
                {
                    case 1:
                        if (canProcessInput)
                        {
                            ViewModel?.SelfRegSlaveCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer
                        }
                        break;

                    case 2:
                        if (canProcessInput)
                        {
                            ViewModel?.StationDBSlaveCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer
                        }
                        break;

                    case 3:
                        if (canProcessInput)
                        {
                            ViewModel?.BaseStationRegistrationSlaveCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer
                        }
                        break;

                    case 4:
                        if (canProcessInput)
                        {
                            ViewModel?.LoadLoadAngleMainPageSlaveCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer
                        }
                        break;

                    case 5:
                        if (canProcessInput)
                        {
                            ViewModel?.SaveAngleMainPageSlaveCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer
                        }
                        break;
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
                textBoxNo = 3;
                isTextboxClicked = true;
                backupString = ViewModel.SystemUnlockPIN;
                _numericKeyboardWindow = new NumericKeyboardWindowMainSlave(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindow.Owner = Application.Current.MainWindow;
                _numericKeyboardWindow.KeyPad.Text = string.Empty;
                ViewModel.SystemUnlockPIN = string.Empty;
                _numericKeyboardWindow.KeyPressed += (s, key) =>
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
                    _numericKeyboardWindow.KeyPad.Text = ViewModel.SystemUnlockPIN.ToString();
                };
                _numericKeyboardWindow.Show();
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

        private void btnSaveAngleMainPageSlaveMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            btnSaveAngleMainPage.Background = new SolidColorBrush(Colors.White); // Reset to the original color
            btnSaveAngleMainPage.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnSaveAngleMainPageSlaveMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            btnSaveAngleMainPage.Background = new SolidColorBrush(Colors.White); // Reset to the original color
            btnSaveAngleMainPage.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnSaveAngleMainPageSlaveMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            btnSaveAngleMainPage.Background = new SolidColorBrush(Colors.White); // Reset to the original color
            btnSaveAngleMainPage.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnLoadLoadAngleMainPageSlaveMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            btnLoadAngleMainPage.Background = new SolidColorBrush(Colors.White); // Reset to the original color
            btnLoadAngleMainPage.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnLoadLoadAngleMainPageSlaveMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            btnLoadAngleMainPage.Background = new SolidColorBrush(Colors.White); // Reset to the original color
            btnLoadAngleMainPage.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnLoadLoadAngleMainPageSlaveMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            btnLoadAngleMainPage.Background = new SolidColorBrush(Colors.White); // Reset to the original color
            btnLoadAngleMainPage.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}

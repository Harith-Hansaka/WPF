using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Resources;
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
using UNDAI.COMMANDS.MASTER;
using UNDAI.VIEWMODELS.BASE;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWS.BASE;
using Wpf.Ui.Controls;

namespace UNDAI.VIEWS.MASTER
{
    /// <summary>
    /// Interaction logic for MainPageMaster.xaml
    /// </summary>

    public partial class MainPageMaster : UserControl
    {
        bool mouseReleased = true;
        bool touchReleased = true;
        bool stylusReleased = true;
        bool isPINClickedSYS = false;
        NumericKeyboardWindowMainMaster _numericKeyboardWindow;
        int textBoxNo;
        bool isTextboxClicked = false;
        string backupString;
        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;
        App app;

        private MainPageMasterViewModel? ViewModel => DataContext as MainPageMasterViewModel;

        public MainPageMaster()
        {
            InitializeComponent();
            InitializeDebounceTimer(); // Initialize debounce logic
            app = (App)Application.Current;
            CreateAppClassAfterDelay();

            if (ViewModel != null)
            {
                _numericKeyboardWindow = new NumericKeyboardWindowMainMaster(0, ViewModel, "");
            }
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._mainPageMasterViewModel;
            }
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

        private void btnHighSpeedBtnMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (mouseReleased)
                {
                    (sender as UIElement)?.CaptureMouse();
                    e.Handled = true;
                    ViewModel?.HighSpeedBtnMasterCommand.Execute(e);
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
                    ViewModel?.HighSpeedBtnMasterCommand.Execute(e);
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
                    ViewModel?.HighSpeedBtnMasterCommand.Execute(e);
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
                    ViewModel?.LowSpeedBtnMasterCommand.Execute(e);
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
                    ViewModel?.LowSpeedBtnMasterCommand.Execute(e);
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
                    ViewModel?.LowSpeedBtnMasterCommand.Execute(e);
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
                    ViewModel?.InchingSpeedBtnMasterCommand.Execute(e);
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
                    ViewModel?.InchingSpeedBtnMasterCommand.Execute(e);
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
                    ViewModel?.InchingSpeedBtnMasterCommand.Execute(e);
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

        private void btnElevationAngleSetMasterMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(6);
        }

        private void btnElevationAngleSetMasterMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(6);
        }

        private void btnElevationAngleSetMasterMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(6);
        }

        private void btnElevationAngleSetMasterMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnElevationAngleSetMasterMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnElevationAngleSetMasterMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnAzimuthAngleSetMasterMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(7);
        }

        private void btnAzimuthAngleSetMasterMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(7);
        }

        private void btnAzimuthAngleSetMasterMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(7);
        }

        private void btnAzimuthAngleSetMasterMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnAzimuthAngleSetMasterMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnAzimuthAngleSetMasterMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnSaveAngleMainPageMasterMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            btnSaveAngleMainPage.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
            btnSaveAngleMainPage.Foreground = new SolidColorBrush(Colors.White);
            ProcessNumberInput(5);
        }

        private void btnSaveAngleMainPageMasterMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            btnSaveAngleMainPage.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
            btnSaveAngleMainPage.Foreground = new SolidColorBrush(Colors.White);
            ProcessNumberInput(5);
        }

        private void btnSaveAngleMainPageMasterMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            btnSaveAngleMainPage.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
            btnSaveAngleMainPage.Foreground = new SolidColorBrush(Colors.White);
            ProcessNumberInput(5);
        }

        private void btnSaveAngleMainPageMasterMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnSaveAngleMainPageMasterMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnSaveAngleMainPageMasterMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnLoadLoadAngleMainPageMasterMainPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            btnLoadAngleMainPage.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
            btnLoadAngleMainPage.Foreground = new SolidColorBrush(Colors.White);
            ProcessNumberInput(4);
        }

        private void btnLoadLoadAngleMainPageMasterMainPage_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            btnLoadAngleMainPage.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
            btnLoadAngleMainPage.Foreground = new SolidColorBrush(Colors.White);
            ProcessNumberInput(4);
        }

        private void btnLoadLoadAngleMainPageMasterMainPage_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            btnLoadAngleMainPage.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
            btnLoadAngleMainPage.Foreground = new SolidColorBrush(Colors.White);
            ProcessNumberInput(4);
        }

        private void btnLoadLoadAngleMainPageMasterMainPage_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnLoadLoadAngleMainPageMasterMainPage_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnLoadLoadAngleMainPageMasterMainPage_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void ElevationAngleInputMasterTextBox()
        {
            if (ViewModel != null)
            {
                //_numericKeyboardWindow.Close();
                Keyboard.ClearFocus();
                textBoxNo = 1;
                backupString = ViewModel.ElevationAngleInputMaster;
                _numericKeyboardWindow = new NumericKeyboardWindowMainMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindow.Owner = Application.Current.MainWindow;
                _numericKeyboardWindow.KeyPad.Text = ViewModel.ElevationAngleInputMaster;
                _numericKeyboardWindow.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationAngleInputMaster.Length > 0)
                        {
                            ViewModel.ElevationAngleInputMaster = ViewModel.ElevationAngleInputMaster.Substring(0, ViewModel.ElevationAngleInputMaster.Length - 1);
                        }
                        else
                        {
                            ViewModel.ElevationAngleInputMaster = ViewModel.ElevationAngleInputMaster;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.ElevationAngleInputMaster.Length > 0)
                        {
                            if (ViewModel.ElevationAngleInputMaster[0] == '-')
                            {
                                ViewModel.ElevationAngleInputMaster = ViewModel.ElevationAngleInputMaster.Substring(1);
                            }
                            else
                            {
                                ViewModel.ElevationAngleInputMaster = '-' + ViewModel.ElevationAngleInputMaster;
                            }
                        }
                        else
                        {
                            ViewModel.ElevationAngleInputMaster = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.ElevationAngleInputMaster.Length == 0)
                        {
                            ViewModel.ElevationAngleInputMaster = "0.";
                        }
                        else if (ViewModel.ElevationAngleInputMaster.Contains("."))
                        {
                            ViewModel.ElevationAngleInputMaster = ViewModel.ElevationAngleInputMaster;
                        }
                        else if (ViewModel.ElevationAngleInputMaster.Length == 1 && ViewModel.ElevationAngleInputMaster[0] == '-')
                        {
                            ViewModel.ElevationAngleInputMaster = "-0.";
                        }
                        else
                        {
                            ViewModel.ElevationAngleInputMaster = ViewModel.ElevationAngleInputMaster + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.ElevationAngleInputMaster.Length == 1 && ViewModel.ElevationAngleInputMaster[0] == '0')
                        {
                            ViewModel.ElevationAngleInputMaster = "";
                        }
                        ViewModel.ElevationAngleInputMaster += key;
                    };
                    _numericKeyboardWindow.KeyPad.Text = ViewModel.ElevationAngleInputMaster.ToString();
                };
                _numericKeyboardWindow.Show();
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
                _numericKeyboardWindow = new NumericKeyboardWindowMainMaster(textBoxNo, ViewModel, backupString);
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

        private void AzimuthAngleInputMasterTextBox()
        {
            if (ViewModel != null)
            {
                //_numericKeyboardWindow.Close();
                Keyboard.ClearFocus();
                textBoxNo = 2;
                backupString = ViewModel.AzimuthAngleInputMaster;
                _numericKeyboardWindow = new NumericKeyboardWindowMainMaster(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindow.Owner = Application.Current.MainWindow;
                _numericKeyboardWindow.KeyPad.Text = ViewModel.AzimuthAngleInputMaster;

                _numericKeyboardWindow.KeyPressed += (s, key) =>
                {

                    if (key == "Backspace")
                    {
                        if (ViewModel.AzimuthAngleInputMaster.Length > 0)
                        {
                            ViewModel.AzimuthAngleInputMaster = ViewModel.AzimuthAngleInputMaster.Substring(0, ViewModel.AzimuthAngleInputMaster.Length - 1);
                        }
                        else
                        {
                            ViewModel.AzimuthAngleInputMaster = ViewModel.AzimuthAngleInputMaster;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.AzimuthAngleInputMaster.Length > 0)
                        {
                            if (ViewModel.AzimuthAngleInputMaster[0] == '-')
                            {
                                ViewModel.AzimuthAngleInputMaster = ViewModel.AzimuthAngleInputMaster.Substring(1);
                            }
                            else
                            {
                                ViewModel.AzimuthAngleInputMaster = '-' + ViewModel.AzimuthAngleInputMaster;
                            }
                        }
                        else
                        {
                            ViewModel.AzimuthAngleInputMaster = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.AzimuthAngleInputMaster.Length == 0)
                        {
                            ViewModel.AzimuthAngleInputMaster = "0.";
                        }
                        else if (ViewModel.AzimuthAngleInputMaster.Length == 1 && ViewModel.AzimuthAngleInputMaster[0] == '-')
                        {
                            ViewModel.AzimuthAngleInputMaster = "-0.";
                        }
                        else if (ViewModel.AzimuthAngleInputMaster.Contains("."))
                        {
                            ViewModel.AzimuthAngleInputMaster = ViewModel.AzimuthAngleInputMaster;
                        }
                        else
                        {
                            ViewModel.AzimuthAngleInputMaster = ViewModel.AzimuthAngleInputMaster + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.AzimuthAngleInputMaster.Length == 1 && ViewModel.AzimuthAngleInputMaster[0] == '0')
                        {
                            ViewModel.AzimuthAngleInputMaster = "";
                        }
                        ViewModel.AzimuthAngleInputMaster += key;
                    }
                    _numericKeyboardWindow.KeyPad.Text = ViewModel.AzimuthAngleInputMaster.ToString();
                };
                _numericKeyboardWindow.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void OnElevationAngleInputMasterTextBoxGotFocus(object sender, MouseButtonEventArgs e)
        {
            ElevationAngleInputMasterTextBox();
        }

        private void OnElevationAngleInputMasterTextBoxGotFocus(object sender, TouchEventArgs e)
        {
            ElevationAngleInputMasterTextBox();
        }

        private void OnElevationAngleInputMasterTextBoxGotFocus(object sender, StylusDownEventArgs e)
        {
            ElevationAngleInputMasterTextBox();
        }

        private void OnAzimuthAngleInputMasterTextBoxGotFocus(object sender, MouseButtonEventArgs e)
        {
            AzimuthAngleInputMasterTextBox();
        }

        private void OnAzimuthAngleInputMasterTextBoxGotFocus(object sender, StylusDownEventArgs e)
        {
            AzimuthAngleInputMasterTextBox();
        }

        private void OnAzimuthAngleInputMasterTextBoxGotFocus(object sender, TouchEventArgs e)
        {
            AzimuthAngleInputMasterTextBox();
        }

        private void KeypadClose()
        {
            if (ViewModel != null)
            {
                _numericKeyboardWindow.Close();
                Keyboard.ClearFocus();
                if (textBoxNo == 1 && _numericKeyboardWindow._status != 1)
                {
                    ViewModel.ElevationAngleInputMaster = backupString;

                }
                else if (textBoxNo == 2 && _numericKeyboardWindow._status != 1)
                {
                    ViewModel.AzimuthAngleInputMaster = backupString;
                }
                else if (textBoxNo == 3 && _numericKeyboardWindow._status != 1)
                {
                    ViewModel.SystemUnlockPIN = backupString;
                    ViewModel.PINKeyboardClose = false;
                }
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void UserControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            KeypadClose();

            // Disable Focusable for all TextBox elements in the visual tree
            foreach (var textBox in FindVisualChildren<System.Windows.Controls.TextBox>(this))
            {
                textBox.Focusable = false;
            }
            MainPage_Activated();
        }

        private void UserControl_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            KeypadClose();

            // Disable Focusable for all TextBox elements in the visual tree
            foreach (var textBox in FindVisualChildren<System.Windows.Controls.TextBox>(this))
            {
                textBox.Focusable = false;
            }
            MainPage_Activated();
        }

        private void UserControl_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            KeypadClose();
            
            // Disable Focusable for all TextBox elements in the visual tree
            foreach (var textBox in FindVisualChildren<System.Windows.Controls.TextBox>(this))
            {
                textBox.Focusable = false;
            }
            MainPage_Activated();
        }

        private void btnSelfReg_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void btnSelfReg_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void btnSelfReg_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(1);
        }

        private void btnSelfReg_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnSelfReg_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnSelfReg_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnStationDB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void btnStationDB_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void btnStationDB_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(2);
        }

        private void btnStationDB_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void btnStationDB_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void btnStationDB_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void SubstationRegistrationMasterButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessNumberInput(3);
        }

        private void SubstationRegistrationMasterButton_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessNumberInput(3);
        }

        private void SubstationRegistrationMasterButton_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessNumberInput(3);
        }

        private void SubstationRegistrationMasterButton_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void SubstationRegistrationMasterButton_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void SubstationRegistrationMasterButton_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
        }

        private void btnSystemSetting_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
            {
                if (ViewModel?.SystemSettingMasterCommand != null)
                {
                    if (ViewModel?.Connected == "CONNECT")
                    {
                        ViewModel?.SystemSettingMasterCommand.Execute(e);
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
                if (ViewModel?.SystemSettingMasterCommand != null)
                {
                    if (ViewModel?.Connected == "CONNECT")
                    {
                        ViewModel?.SystemSettingMasterCommand.Execute(e);
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
                if (ViewModel?.SystemSettingMasterCommand != null)
                {
                    if (ViewModel?.Connected == "CONNECT")
                    {
                        ViewModel?.SystemSettingMasterCommand.Execute(e);
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

        private void StopMasterButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
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

        private void StopMasterButton_PreviewTouchDown(object sender, TouchEventArgs e)
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

        private void StopMasterButton_PreviewStylusDown(object sender, StylusDownEventArgs e)
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

        private void StopMasterButton_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent mouse moves
        }

        private void StopMasterButton_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent touch moves
        }

        private void StopMasterButton_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true; // Adjust if you need to prevent stylus moves
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
                            ViewModel?.SelfRegMasterCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer
                        }
                        break;

                    case 2:
                        if (canProcessInput)
                        {
                            ViewModel?.StationDBMasterCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer
                        }
                        break;

                    case 3:
                        if (canProcessInput)
                        {
                            ViewModel?.SubstationRegistrationMasterCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer
                        }
                        break;

                    case 4:
                        if (canProcessInput)
                        {
                            ViewModel?.LoadLoadAngleMainPageMasterCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer
                        }
                        break;

                    case 5:
                        if (canProcessInput)
                        {
                            btnSaveAngleMainPage.Background = new SolidColorBrush(Color.FromRgb(0x1d, 0x9d, 0xfd));
                            ViewModel?.SaveAngleMainPageMasterCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer
                        }
                        break;

                    case 6:
                        if (canProcessInput)
                        {
                            ViewModel?.ElevationAngleSetMasterCommand?.Execute(null);
                            canProcessInput = false; // Prevent further input until debounce resets
                            debounceTimer.Start(); // Start debounce timer
                        }
                        break;

                    case 7:
                        if (canProcessInput)
                        {
                            ViewModel?.AzimuthAngleSetMasterCommand?.Execute(null);
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

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T t)
                    {
                        yield return t;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void MainPage_Activated()
        {
            // Option 1: Set focus to the window itself
            this.Focus();

            // Option 2: Set focus to a specific non-text control
            // Assuming you have a button named 'mainFocusButton' in your XAML
            // mainFocusButton.Focus();

            // Option 3: Clear any keyboard focus to prevent keyboard from appearing
            Keyboard.ClearFocus();
        }

        private void btnSaveAngleMainPageMasterMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            btnSaveAngleMainPage.Background = new SolidColorBrush(Colors.White); // Reset to the original color
            btnSaveAngleMainPage.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnSaveAngleMainPageMasterMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            btnSaveAngleMainPage.Background = new SolidColorBrush(Colors.White); // Reset to the original color
            btnSaveAngleMainPage.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnSaveAngleMainPageMasterMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            btnSaveAngleMainPage.Background = new SolidColorBrush(Colors.White); // Reset to the original color
            btnSaveAngleMainPage.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnLoadLoadAngleMainPageMasterMainPage_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            btnLoadAngleMainPage.Background = new SolidColorBrush(Colors.White); // Reset to the original color
            btnLoadAngleMainPage.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnLoadLoadAngleMainPageMasterMainPage_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            btnLoadAngleMainPage.Background = new SolidColorBrush(Colors.White); // Reset to the original color
            btnLoadAngleMainPage.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void btnLoadLoadAngleMainPageMasterMainPage_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            btnLoadAngleMainPage.Background = new SolidColorBrush(Colors.White); // Reset to the original color
            btnLoadAngleMainPage.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}
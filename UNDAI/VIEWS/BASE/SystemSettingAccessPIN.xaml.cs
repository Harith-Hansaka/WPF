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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using UNDAI.VIEWMODELS.MASTER;

namespace UNDAI.VIEWS.BASE
{
    /// <summary>
    /// Interaction logic for SystemSettingAccessPIN.xaml
    /// </summary>
    public partial class SystemSettingAccessPIN : Window
    {
        string PIN;

        private bool canProcessInput = true;
        private DispatcherTimer debounceTimer;

        public SystemSettingAccessPIN(string pIN)
        {
            InitializeComponent();
            DataContext = this; // Set the DataContext to this class so the UI can bind to it
            PIN = pIN;
            InitializeDebounceTimer(); // Initialize debounce logic
            this.Closing += SystemSettingAccessPIN_Closing; // Subscribe to Closing event
        }

        public string SystemUnlockPIN
        {
            get => SystemUnlockPINText.Text;
            set
            {
                if (SystemUnlockPINText.Text.Length < 4)
                {
                    SystemUnlockPINText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0f8ce9"));
                    SystemUnlockPINText.Text = value;
                }
                if (SystemUnlockPINText.Text == PIN)
                {
                    DialogResult = true;  // Close the dialog and return true
                    Close();
                }
                if(SystemUnlockPINText.Text.Length == 4)
                {
                    SystemUnlockPINText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ED524F"));
                }
                OnPropertyChanged(nameof(SystemUnlockPIN)); // Notify the UI to update
            }
        }

        private void OkButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DialogResult = false;  // Close the dialog and return true
            Close();
        }

        private void OkButton_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            DialogResult = false;  // Close the dialog and return true
            Close();
        }

        private void OkButton_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            DialogResult = false;  // Close the dialog and return true
            Close();
        }

        // Mouse Input
        private void NumericButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                ProcessNumberInput(button);
            }
        }

        // Touch Input
        private void NumericButton_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            if (sender is Button button)
            {
                ProcessNumberInput(button);
            }
        }

        // Stylus Input
        private void NumericButton_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            if (sender is Button button)
            {
                ProcessNumberInput(button);
            }
        }

        // Common method for processing number input
        private void ProcessNumberInput(Button button)
        {
            if (canProcessInput)
            {
                SystemUnlockPIN += button.Content.ToString(); // Append the button content to the display text
                canProcessInput = false; // Prevent further input until debounce resets
                debounceTimer.Start(); // Start debounce timer
            }
        }

        private void BackspaceButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ProcessBackspaceInput();
        }

        private void BackspaceButton_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ProcessBackspaceInput();
        }

        private void BackspaceButton_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ProcessBackspaceInput();
        }

        // Common method for processing number input
        private void ProcessBackspaceInput()
        {
            if (canProcessInput)
            {
                if (!string.IsNullOrEmpty(SystemUnlockPIN))
                {
                    SystemUnlockPINText.Text = SystemUnlockPIN.Substring(0, SystemUnlockPIN.Length - 1); // Remove the last character
                    if (SystemUnlockPINText.Text.Length < 4)
                    {
                        SystemUnlockPINText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0f8ce9"));
                    }
                }
                canProcessInput = false; // Prevent further input until debounce resets
                debounceTimer.Start(); // Start debounce timer
            }
        }

        // Event for INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        private void SystemSettingAccessPIN_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Handle what happens when the window is closed via the upper right corner button (X)
            // Set DialogResult to false or any logic you'd like for the "X" close
            if (SystemUnlockPINText.Text == PIN)
            {
                DialogResult = true;  // Close the dialog and return true
            }
            else
            {
                DialogResult = false;
            }
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.Activate();
            mainWindow?.Focus();
        }
    }
}

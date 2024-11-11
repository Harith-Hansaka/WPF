using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UNDAI.MODELS;

namespace UNDAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        App app;

        public MainWindow()
        {
            app = (App)Application.Current;
            InitializeComponent();
            this.Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (app != null)
            {
                if(app._mainPageMasterViewModel.Connected != "CONNECT")
                {
                    if (app._mainPageMasterViewModel.HomePeakSelect != 2)
                    {
                        // Show a confirmation message
                        MessageBoxResult result = MessageBox.Show(
                            "UNDAI is not it's origin, Are you sure you want to exit?",
                            "Confirmation",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question
                        );

                        // Check the user's choice
                        if (result == MessageBoxResult.No)
                        {
                            // Cancel the closing if the user selects No
                            e.Cancel = true;
                        }
                        else
                        {
                            Application.Current.Shutdown(); // Ensure the application closes completely
                        }
                    }
                    else
                    {
                        Application.Current.Shutdown(); // Ensure the application closes completely
                    }
                }
                else if (app._mainPageSlaveViewModel.Connected != "CONNECT")
                {
                    if (app._mainPageSlaveViewModel.HomePeakSelect != 2)
                    {
                        // Show a confirmation message
                        MessageBoxResult result = MessageBox.Show(
                            "UNDAI is not it's origin, Are you sure you want to exit?",
                            "Confirmation",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question
                        );

                        // Check the user's choice
                        if (result == MessageBoxResult.No)
                        {
                            // Cancel the closing if the user selects No
                            e.Cancel = true;
                        }
                        else
                        {
                            Application.Current.Shutdown(); // Ensure the application closes completely
                        }
                    }
                    else
                    {
                        Application.Current.Shutdown(); // Ensure the application closes completely
                    }
                }
                else
                {
                    Application.Current.Shutdown(); // Ensure the application closes completely
                }
            }
            else
            {
                Application.Current.Shutdown(); // Ensure the application closes completely
            }
        }

    }
}
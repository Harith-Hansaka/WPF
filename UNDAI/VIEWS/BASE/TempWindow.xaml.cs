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
using System.Windows.Shapes;

namespace UNDAI.VIEWS.BASE
{
    /// <summary>
    /// Interaction logic for Temp.xaml
    /// </summary>
    public partial class TempWindow : Window
    {
        public TempWindow()
        {
            InitializeComponent();
            Run();
        }

        private void Run()
        {
            // Ensure the main window regains focus
            this.Activate();
            this.Focus();
            Thread.Sleep(10);
            Keyboard.ClearFocus();
            Application.Current.MainWindow.Focus();  // Ensure focus returns to main window
            Close();
        }
    }
}

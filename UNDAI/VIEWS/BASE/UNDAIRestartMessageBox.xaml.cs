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

namespace UNDAI.VIEWS.BASE
{
    /// <summary>
    /// Interaction logic for UNDAIRestartMessageBox.xaml
    /// </summary>
    public partial class UNDAIRestartMessageBox : Window
    {
        public UNDAIRestartMessageBox()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;  // Close the dialog and return true
            Close();
        }

        private void NumericButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

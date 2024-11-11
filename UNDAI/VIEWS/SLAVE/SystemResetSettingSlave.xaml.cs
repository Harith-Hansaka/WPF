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
using UNDAI.VIEWMODELS.SLAVE;
using UNDAI.VIEWS.BASE;

namespace UNDAI.VIEWS.SLAVE
{
    /// <summary>
    /// Interaction logic for SystemResetSettingSlave.xaml
    /// </summary>
    public partial class SystemResetSettingSlave : UserControl
    {
        private SystemResetSettingSlaveViewModel? ViewModel => DataContext as SystemResetSettingSlaveViewModel;

        public SystemResetSettingSlave()
        {
            InitializeComponent();
        }

        private void SystemSettingReset_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as UIElement)?.CaptureMouse();
            e.Handled = true;
            ViewModel?.SystemSettingReset.Execute(e); 
        }

        private void SystemSettingReset_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            (sender as UIElement)?.CaptureStylus();
            e.Handled = true;
            ViewModel?.SystemSettingReset.Execute(e);
        }

        private void SystemSettingReset_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            (sender as UIElement)?.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            ViewModel?.SystemSettingReset.Execute(e);
        }

        private void MainPageNavigateCommandSlave_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ViewModel?.MainPageNavigateCommand?.Execute(e);
        }

        private void MainPageNavigateCommandSlave_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ViewModel?.MainPageNavigateCommand?.Execute(e);
        }

        private void MainPageNavigateCommandSlave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.MainPageNavigateCommand?.Execute(e);
        }
    }
}
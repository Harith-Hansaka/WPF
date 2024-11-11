using System;
using System.Collections.Generic;
using System.Globalization;
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
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWS.BASE;

namespace UNDAI.VIEWS.MASTER
{
    /// <summary>
    /// Interaction logic for AlarmHistoryMaster.xaml
    /// </summary>
    public partial class AlarmHistoryMaster : UserControl
    {
        AlarmHistoryMasterViewModel? ViewModel => DataContext as AlarmHistoryMasterViewModel;

        public AlarmHistoryMaster()
        {
            InitializeComponent();
        }

        private void SystemSettingMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            (sender as UIElement)?.CaptureStylus();
            e.Handled = true;
            ViewModel?.SystemSettingMasterNavigateCommand?.Execute(e);
        }

        private void SystemSettingMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            (sender as UIElement)?.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            ViewModel?.SystemSettingMasterNavigateCommand?.Execute(e);
        }

        private void SystemSettingMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as UIElement)?.CaptureMouse();
            e.Handled = true;
            ViewModel?.SystemSettingMasterNavigateCommand?.Execute(e);
        }

        private void DeleteSelectedItem_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            (sender as UIElement)?.CaptureStylus();
            e.Handled = true;
            ViewModel?.DeleteSelectedItemCommand?.Execute(e);
        }

        private void DeleteSelectedItem_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            (sender as UIElement)?.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            ViewModel?.DeleteSelectedItemCommand?.Execute(e);
        }

        private void DeleteSelectedItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as UIElement)?.CaptureMouse();
            e.Handled = true;
            ViewModel?.DeleteSelectedItemCommand?.Execute(e);
        }

        private void AlarmHistoryExport_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            (sender as UIElement)?.CaptureStylus();
            e.Handled = true;
            ViewModel?.AlarmHistoryExportCommand?.Execute(e);
        }

        private void AlarmHistoryExport_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            (sender as UIElement)?.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            ViewModel?.AlarmHistoryExportCommand?.Execute(e);
        }

        private void AlarmHistoryExport_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as UIElement)?.CaptureMouse();
            e.Handled = true;
            ViewModel?.AlarmHistoryExportCommand?.Execute(e);
        }

        private void MainPageMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            (sender as UIElement)?.CaptureStylus();
            e.Handled = true;
            ViewModel?.MainPageMasterNavigateCommand?.Execute(e);
        }

        private void MainPageMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            (sender as UIElement)?.CaptureTouch(e.TouchDevice);
            e.Handled = true;
            ViewModel?.MainPageMasterNavigateCommand?.Execute(e);
        }

        private void MainPageMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as UIElement)?.CaptureMouse();
            e.Handled = true;
            ViewModel?.MainPageMasterNavigateCommand?.Execute(e);
        }
    }
}
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UNDAI.VIEWMODELS.MASTER;
using UNDAI.VIEWS.BASE;

namespace UNDAI.VIEWS.MASTER
{
    /// <summary>
    /// Interaction logic for SubstationRegistrationPageMaster.xaml
    /// </summary>
    public partial class SubstationRegistrationPageMaster : UserControl
    {
        NumericKeyboardWindowSubstationReg _numericKeyboardWindowSubstationReg;
        int textBoxNo;
        string backupString;
        bool isTextboxClicked = false;
        App app;

        private SubstationRegistrationMasterViewModel? ViewModel => DataContext as SubstationRegistrationMasterViewModel;

        public SubstationRegistrationPageMaster()
        {
            InitializeComponent();
            app = (App)Application.Current;
            CreateAppClassAfterDelay();
        }

        private void CreateAppClassAfterDelay()
        {
            Thread.Sleep(1);
            if (ViewModel == null)
            {
                // Access properties directly
                DataContext = app._substationRegistrationMasterViewModel;
            }
        }

        // Slave 1 Latitude
        private void LatitudeSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LatitudeSlave1TextBox();
        }

        private void LatitudeSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LatitudeSlave1TextBox();
        }

        private void LatitudeSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LatitudeSlave1TextBox();
        }

        private void LatitudeSlave1_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void LatitudeSlave1_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void LatitudeSlave1_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 2 Latitude
        private void LatitudeSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LatitudeSlave2TextBox();
        }

        private void LatitudeSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LatitudeSlave2TextBox();
        }

        private void LatitudeSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LatitudeSlave2TextBox();
        }

        private void LatitudeSlave2_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void LatitudeSlave2_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void LatitudeSlave2_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 3 Latitude
        private void LatitudeSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LatitudeSlave3TextBox();
        }

        private void LatitudeSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LatitudeSlave3TextBox();
        }

        private void LatitudeSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LatitudeSlave3TextBox();
        }

        private void LatitudeSlave3_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void LatitudeSlave3_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void LatitudeSlave3_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 4 Latitude
        private void LatitudeSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LatitudeSlave4TextBox();
        }

        private void LatitudeSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LatitudeSlave4TextBox();
        }

        private void LatitudeSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LatitudeSlave4TextBox();
        }

        private void LatitudeSlave4_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void LatitudeSlave4_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void LatitudeSlave4_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 1 Longitude
        private void LongitudeSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LongitudeSlave1TextBox();
        }

        private void LongitudeSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LongitudeSlave1TextBox();
        }

        private void LongitudeSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LongitudeSlave1TextBox();
        }

        private void LongitudeSlave1_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void LongitudeSlave1_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void LongitudeSlave1_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 2 Longitude
        private void LongitudeSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LongitudeSlave2TextBox();
        }

        private void LongitudeSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LongitudeSlave2TextBox();
        }

        private void LongitudeSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LongitudeSlave2TextBox();
        }

        private void LongitudeSlave2_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void LongitudeSlave2_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void LongitudeSlave2_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 3 Longitude
        private void LongitudeSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LongitudeSlave3TextBox();
        }

        private void LongitudeSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LongitudeSlave3TextBox();
        }

        private void LongitudeSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LongitudeSlave3TextBox();
        }

        private void LongitudeSlave3_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void LongitudeSlave3_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void LongitudeSlave3_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 4 Longitude
        private void LongitudeSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            LongitudeSlave4TextBox();
        }

        private void LongitudeSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LongitudeSlave4TextBox();
        }

        private void LongitudeSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            LongitudeSlave4TextBox();
        }

        private void LongitudeSlave4_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void LongitudeSlave4_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void LongitudeSlave4_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 1 Elevation
        private void ElevationSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ElevationSlave1TextBox();
        }

        private void ElevationSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ElevationSlave1TextBox();
        }

        private void ElevationSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ElevationSlave1TextBox();
        }

        private void ElevationSlave1_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void ElevationSlave1_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void ElevationSlave1_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 2 Elevation
        private void ElevationSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ElevationSlave2TextBox();
        }

        private void ElevationSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ElevationSlave2TextBox();
        }

        private void ElevationSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ElevationSlave2TextBox();
        }

        private void ElevationSlave2_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void ElevationSlave2_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void ElevationSlave2_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 3 Elevation
        private void ElevationSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ElevationSlave3TextBox();
        }

        private void ElevationSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ElevationSlave3TextBox();
        }

        private void ElevationSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ElevationSlave3TextBox();
        }

        private void ElevationSlave3_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void ElevationSlave3_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void ElevationSlave3_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 4 Elevation
        private void ElevationSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ElevationSlave4TextBox();
        }

        private void ElevationSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ElevationSlave4TextBox();
        }

        private void ElevationSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ElevationSlave4TextBox();
        }

        private void ElevationSlave4_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void ElevationSlave4_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void ElevationSlave4_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 1 PoleLength
        private void PoleLengthSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PoleLengthSlave1TextBox();
        }

        private void PoleLengthSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PoleLengthSlave1TextBox();
        }

        private void PoleLengthSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PoleLengthSlave1TextBox();
        }

        private void PoleLengthSlave1_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void PoleLengthSlave1_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void PoleLengthSlave1_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 2 PoleLength
        private void PoleLengthSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PoleLengthSlave2TextBox();
        }

        private void PoleLengthSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PoleLengthSlave2TextBox();
        }

        private void PoleLengthSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PoleLengthSlave2TextBox();
        }

        private void PoleLengthSlave2_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void PoleLengthSlave2_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void PoleLengthSlave2_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 3 PoleLength
        private void PoleLengthSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PoleLengthSlave3TextBox();
        }

        private void PoleLengthSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PoleLengthSlave3TextBox();
        }

        private void PoleLengthSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PoleLengthSlave3TextBox();
        }

        private void PoleLengthSlave3_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void PoleLengthSlave3_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void PoleLengthSlave3_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 4 PoleLength
        private void PoleLengthSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            PoleLengthSlave4TextBox();
        }

        private void PoleLengthSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            PoleLengthSlave4TextBox();
        }

        private void PoleLengthSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            PoleLengthSlave4TextBox();
        }

        private void PoleLengthSlave4_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void PoleLengthSlave4_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void PoleLengthSlave4_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 1 InstallationOrientation
        private void InstallationOrientationSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InstallationOrientationSlave1TextBox();
        }

        private void InstallationOrientationSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            InstallationOrientationSlave1TextBox();
        }

        private void InstallationOrientationSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            InstallationOrientationSlave1TextBox();
        }

        private void InstallationOrientationSlave1_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void InstallationOrientationSlave1_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void InstallationOrientationSlave1_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 2 InstallationOrientation
        private void InstallationOrientationSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InstallationOrientationSlave2TextBox();
        }

        private void InstallationOrientationSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            InstallationOrientationSlave2TextBox();
        }

        private void InstallationOrientationSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            InstallationOrientationSlave2TextBox();
        }

        private void InstallationOrientationSlave2_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void InstallationOrientationSlave2_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void InstallationOrientationSlave2_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 3 InstallationOrientation
        private void InstallationOrientationSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InstallationOrientationSlave3TextBox();
        }

        private void InstallationOrientationSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            InstallationOrientationSlave3TextBox();
        }

        private void InstallationOrientationSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            InstallationOrientationSlave3TextBox();
        }

        private void InstallationOrientationSlave3_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void InstallationOrientationSlave3_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void InstallationOrientationSlave3_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 4 InstallationOrientation
        private void InstallationOrientationSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            InstallationOrientationSlave4TextBox();
        }

        private void InstallationOrientationSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            InstallationOrientationSlave4TextBox();
        }

        private void InstallationOrientationSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            InstallationOrientationSlave4TextBox();
        }

        private void InstallationOrientationSlave4_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void InstallationOrientationSlave4_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void InstallationOrientationSlave4_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        private void HeadIPAddressSlave1_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void HeadIPAddressSlave1_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void HeadIPAddressSlave1_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        private void HeadIPAddressSlave2_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void HeadIPAddressSlave2_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void HeadIPAddressSlave2_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        private void HeadIPAddressSlave3_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void HeadIPAddressSlave3_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void HeadIPAddressSlave3_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        private void HeadIPAddressSlave4_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void HeadIPAddressSlave4_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void HeadIPAddressSlave4_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 1 AntennaIPAddress
        private void AntennaIPAddressSlave1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AntennaNameSlave1TextBox();
        }

        private void AntennaIPAddressSlave1_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            AntennaNameSlave1TextBox();
        }

        private void AntennaIPAddressSlave1_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            AntennaNameSlave1TextBox();
        }

        private void AntennaIPAddressSlave1_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void AntennaIPAddressSlave1_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void AntennaIPAddressSlave1_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 2 AntennaIPAddress
        private void AntennaIPAddressSlave2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AntennaIPAddressSlave2TextBox();
        }

        private void AntennaIPAddressSlave2_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            AntennaIPAddressSlave2TextBox();
        }

        private void AntennaIPAddressSlave2_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            AntennaIPAddressSlave2TextBox();
        }

        private void AntennaIPAddressSlave2_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void AntennaIPAddressSlave2_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void AntennaIPAddressSlave2_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 3 AntennaIPAddress
        private void AntennaIPAddressSlave3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AntennaIPAddressSlave3TextBox();
        }

        private void AntennaIPAddressSlave3_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            AntennaIPAddressSlave3TextBox();
        }

        private void AntennaIPAddressSlave3_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            AntennaIPAddressSlave3TextBox();
        }

        private void AntennaIPAddressSlave3_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void AntennaIPAddressSlave3_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void AntennaIPAddressSlave3_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }

        // Slave 4 AntennaIPAddress
        private void AntennaIPAddressSlave4_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AntennaIPAddressSlave4TextBox();
        }

        private void AntennaIPAddressSlave4_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            AntennaIPAddressSlave4TextBox();
        }

        private void AntennaIPAddressSlave4_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            AntennaIPAddressSlave4TextBox();
        }

        private void AntennaIPAddressSlave4_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;
        }

        private void AntennaIPAddressSlave4_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            e.Handled = true;
        }

        private void AntennaIPAddressSlave4_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            e.Handled = true;
        }


        //SLAVE 1
        private void LatitudeSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 1;
                isTextboxClicked = true;
                backupString = ViewModel.LatitudeSlave1;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LatitudeSlave1;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LatitudeSlave1.Length > 0)
                        {
                            ViewModel.LatitudeSlave1 = ViewModel.LatitudeSlave1.Substring(0, ViewModel.LatitudeSlave1.Length - 1);
                        }
                        else
                        {
                            ViewModel.LatitudeSlave1 = ViewModel.LatitudeSlave1;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LatitudeSlave1.Length > 0)
                        {
                            if (ViewModel.LatitudeSlave1[0] == '-')
                            {
                                ViewModel.LatitudeSlave1 = ViewModel.LatitudeSlave1.Substring(1);
                            }
                            else
                            {
                                ViewModel.LatitudeSlave1 = '-' + ViewModel.LatitudeSlave1;
                            }
                        }
                        else
                        {
                            ViewModel.LatitudeSlave1 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LatitudeSlave1.Length == 0)
                        {
                            ViewModel.LatitudeSlave1 = "0.";
                        }
                        else if (ViewModel.LatitudeSlave1.Contains("."))
                        {
                            ViewModel.LatitudeSlave1 = ViewModel.LatitudeSlave1;
                        }
                        else if (ViewModel.LatitudeSlave1.Length == 1 && ViewModel.LatitudeSlave1[0] == '-')
                        {
                            ViewModel.LatitudeSlave1 = "-0.";
                        }
                        else
                        {
                            ViewModel.LatitudeSlave1 = ViewModel.LatitudeSlave1 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LatitudeSlave1.Length == 1 && ViewModel.LatitudeSlave1[0] == '0')
                        {
                            ViewModel.LatitudeSlave1 = "";
                        }
                        ViewModel.LatitudeSlave1 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LatitudeSlave1.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 2;
                isTextboxClicked = true;
                backupString = ViewModel.LongitudeSlave1;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LongitudeSlave1;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LongitudeSlave1.Length > 0)
                        {
                            ViewModel.LongitudeSlave1 = ViewModel.LongitudeSlave1.Substring(0, ViewModel.LongitudeSlave1.Length - 1);
                        }
                        else
                        {
                            ViewModel.LongitudeSlave1 = ViewModel.LongitudeSlave1;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LongitudeSlave1.Length > 0)
                        {
                            if (ViewModel.LongitudeSlave1[0] == '-')
                            {
                                ViewModel.LongitudeSlave1 = ViewModel.LongitudeSlave1.Substring(1);
                            }
                            else
                            {
                                ViewModel.LongitudeSlave1 = '-' + ViewModel.LongitudeSlave1;
                            }
                        }
                        else
                        {
                            ViewModel.LongitudeSlave1 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LongitudeSlave1.Length == 0)
                        {
                            ViewModel.LongitudeSlave1 = "0.";
                        }
                        else if (ViewModel.LongitudeSlave1.Contains("."))
                        {
                            ViewModel.LongitudeSlave1 = ViewModel.LongitudeSlave1;
                        }
                        else if (ViewModel.LongitudeSlave1.Length == 1 && ViewModel.LongitudeSlave1[0] == '-')
                        {
                            ViewModel.LongitudeSlave1 = "-0.";
                        }
                        else
                        {
                            ViewModel.LongitudeSlave1 = ViewModel.LongitudeSlave1 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LongitudeSlave1.Length == 1 && ViewModel.LongitudeSlave1[0] == '0')
                        {
                            ViewModel.LongitudeSlave1 = "";
                        }
                        ViewModel.LongitudeSlave1 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LongitudeSlave1.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 3;
                isTextboxClicked = true;
                backupString = ViewModel.ElevationSlave1;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.ElevationSlave1;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationSlave1.Length > 0)
                        {
                            ViewModel.ElevationSlave1 = ViewModel.ElevationSlave1.Substring(0, ViewModel.ElevationSlave1.Length - 1);
                        }
                        else
                        {
                            ViewModel.ElevationSlave1 = ViewModel.ElevationSlave1;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.ElevationSlave1.Length > 0)
                        {
                            if (ViewModel.ElevationSlave1[0] == '-')
                            {
                                ViewModel.ElevationSlave1 = ViewModel.ElevationSlave1.Substring(1);
                            }
                            else
                            {
                                ViewModel.ElevationSlave1 = '-' + ViewModel.ElevationSlave1;
                            }
                        }
                        else
                        {
                            ViewModel.ElevationSlave1 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.ElevationSlave1.Length == 0)
                        {
                            ViewModel.ElevationSlave1 = "0.";
                        }
                        else if (ViewModel.ElevationSlave1.Contains("."))
                        {
                            ViewModel.ElevationSlave1 = ViewModel.ElevationSlave1;
                        }
                        else if (ViewModel.ElevationSlave1.Length == 1 && ViewModel.ElevationSlave1[0] == '-')
                        {
                            ViewModel.ElevationSlave1 = "-0.";
                        }
                        else
                        {
                            ViewModel.ElevationSlave1 = ViewModel.ElevationSlave1 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.ElevationSlave1.Length == 1 && ViewModel.ElevationSlave1[0] == '0')
                        {
                            ViewModel.ElevationSlave1 = "";
                        }
                        ViewModel.ElevationSlave1 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.ElevationSlave1.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleLengthSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 4;
                isTextboxClicked = true;
                backupString = ViewModel.PoleLengthSlave1;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.PoleLengthSlave1;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.PoleLengthSlave1.Length > 0)
                        {
                            ViewModel.PoleLengthSlave1 = ViewModel.PoleLengthSlave1.Substring(0, ViewModel.PoleLengthSlave1.Length - 1);
                        }
                        else
                        {
                            ViewModel.PoleLengthSlave1 = ViewModel.PoleLengthSlave1;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.PoleLengthSlave1.Length > 0)
                        {
                            if (ViewModel.PoleLengthSlave1[0] == '-')
                            {
                                ViewModel.PoleLengthSlave1 = ViewModel.PoleLengthSlave1.Substring(1);
                            }
                            else
                            {
                                ViewModel.PoleLengthSlave1 = '-' + ViewModel.PoleLengthSlave1;
                            }
                        }
                        else
                        {
                            ViewModel.PoleLengthSlave1 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.PoleLengthSlave1.Length == 0)
                        {
                            ViewModel.PoleLengthSlave1 = "0.";
                        }
                        else if (ViewModel.PoleLengthSlave1.Contains("."))
                        {
                            ViewModel.PoleLengthSlave1 = ViewModel.PoleLengthSlave1;
                        }
                        else if (ViewModel.PoleLengthSlave1.Length == 1 && ViewModel.PoleLengthSlave1[0] == '-')
                        {
                            ViewModel.PoleLengthSlave1 = "-0.";
                        }
                        else
                        {
                            ViewModel.PoleLengthSlave1 = ViewModel.PoleLengthSlave1 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.PoleLengthSlave1.Length == 1 && ViewModel.PoleLengthSlave1[0] == '0')
                        {
                            ViewModel.PoleLengthSlave1 = "";
                        }
                        ViewModel.PoleLengthSlave1 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.PoleLengthSlave1.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void InstallationOrientationSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 5;
                isTextboxClicked = true;
                backupString = ViewModel.Slave1AntennaIPAddress;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.Slave1AntennaIPAddress;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.Slave1AntennaIPAddress.Length > 0)
                        {
                            ViewModel.Slave1AntennaIPAddress = ViewModel.Slave1AntennaIPAddress.Substring(0, ViewModel.Slave1AntennaIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.Slave1AntennaIPAddress = ViewModel.Slave1AntennaIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.Slave1AntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.Slave1AntennaIPAddress[0] == '-')
                            {
                                ViewModel.Slave1AntennaIPAddress = ViewModel.Slave1AntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.Slave1AntennaIPAddress = '-' + ViewModel.Slave1AntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.Slave1AntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.Slave1AntennaIPAddress.Length == 0)
                        {
                            ViewModel.Slave1AntennaIPAddress = "0.";
                        }
                        else if (ViewModel.Slave1AntennaIPAddress.Contains("."))
                        {
                            ViewModel.Slave1AntennaIPAddress = ViewModel.Slave1AntennaIPAddress;
                        }
                        else if (ViewModel.Slave1AntennaIPAddress.Length == 1 && ViewModel.Slave1AntennaIPAddress[0] == '-')
                        {
                            ViewModel.Slave1AntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.Slave1AntennaIPAddress = ViewModel.Slave1AntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.Slave1AntennaIPAddress.Length == 1 && ViewModel.Slave1AntennaIPAddress[0] == '0')
                        {
                            ViewModel.Slave1AntennaIPAddress = "";
                        }
                        ViewModel.Slave1AntennaIPAddress += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.Slave1AntennaIPAddress.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void AntennaNameSlave1TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 25;
                isTextboxClicked = true;
                backupString = ViewModel.AntennaNameSlave1;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.AntennaNameSlave1;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.AntennaNameSlave1.Length > 0)
                        {
                            ViewModel.AntennaNameSlave1 = ViewModel.AntennaNameSlave1.Substring(0, ViewModel.AntennaNameSlave1.Length - 1);
                        }
                        else
                        {
                            ViewModel.AntennaNameSlave1 = ViewModel.AntennaNameSlave1;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.AntennaNameSlave1.Length > 0)
                        {
                            if (ViewModel.AntennaNameSlave1[0] == '-')
                            {
                                ViewModel.AntennaNameSlave1 = ViewModel.AntennaNameSlave1.Substring(1);
                            }
                            else
                            {
                                ViewModel.AntennaNameSlave1 = '-' + ViewModel.AntennaNameSlave1;
                            }
                        }
                        else
                        {
                            ViewModel.AntennaNameSlave1 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.AntennaNameSlave1.Length == 0)
                        {
                            ViewModel.AntennaNameSlave1 = "0.";
                        }
                        else if (ViewModel.AntennaNameSlave1.Contains("."))
                        {
                            ViewModel.AntennaNameSlave1 = ViewModel.AntennaNameSlave1;
                        }
                        else if (ViewModel.AntennaNameSlave1.Length == 1 && ViewModel.AntennaNameSlave1[0] == '-')
                        {
                            ViewModel.AntennaNameSlave1 = "-0.";
                        }
                        else
                        {
                            ViewModel.AntennaNameSlave1 = ViewModel.AntennaNameSlave1 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.AntennaNameSlave1.Length == 1 && ViewModel.AntennaNameSlave1[0] == '0')
                        {
                            ViewModel.AntennaNameSlave1 = "";
                        }
                        ViewModel.AntennaNameSlave1 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.AntennaNameSlave1.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        //SLAVE 2
        private void LatitudeSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 7;
                isTextboxClicked = true;
                backupString = ViewModel.LatitudeSlave2;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LatitudeSlave2;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LatitudeSlave2.Length > 0)
                        {
                            ViewModel.LatitudeSlave2 = ViewModel.LatitudeSlave2.Substring(0, ViewModel.LatitudeSlave2.Length - 1);
                        }
                        else
                        {
                            ViewModel.LatitudeSlave2 = ViewModel.LatitudeSlave2;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LatitudeSlave2.Length > 0)
                        {
                            if (ViewModel.LatitudeSlave2[0] == '-')
                            {
                                ViewModel.LatitudeSlave2 = ViewModel.LatitudeSlave2.Substring(1);
                            }
                            else
                            {
                                ViewModel.LatitudeSlave2 = '-' + ViewModel.LatitudeSlave2;
                            }
                        }
                        else
                        {
                            ViewModel.LatitudeSlave2 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LatitudeSlave2.Length == 0)
                        {
                            ViewModel.LatitudeSlave2 = "0.";
                        }
                        else if (ViewModel.LatitudeSlave2.Contains("."))
                        {
                            ViewModel.LatitudeSlave2 = ViewModel.LatitudeSlave2;
                        }
                        else if (ViewModel.LatitudeSlave2.Length == 1 && ViewModel.LatitudeSlave2[0] == '-')
                        {
                            ViewModel.LatitudeSlave2 = "-0.";
                        }
                        else
                        {
                            ViewModel.LatitudeSlave2 = ViewModel.LatitudeSlave2 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LatitudeSlave2.Length == 1 && ViewModel.LatitudeSlave2[0] == '0')
                        {
                            ViewModel.LatitudeSlave2 = "";
                        }
                        ViewModel.LatitudeSlave2 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LatitudeSlave2.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 8;
                isTextboxClicked = true;
                backupString = ViewModel.LongitudeSlave2;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LongitudeSlave2;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LongitudeSlave2.Length > 0)
                        {
                            ViewModel.LongitudeSlave2 = ViewModel.LongitudeSlave2.Substring(0, ViewModel.LongitudeSlave2.Length - 1);
                        }
                        else
                        {
                            ViewModel.LongitudeSlave2 = ViewModel.LongitudeSlave2;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LongitudeSlave2.Length > 0)
                        {
                            if (ViewModel.LongitudeSlave2[0] == '-')
                            {
                                ViewModel.LongitudeSlave2 = ViewModel.LongitudeSlave2.Substring(1);
                            }
                            else
                            {
                                ViewModel.LongitudeSlave2 = '-' + ViewModel.LongitudeSlave2;
                            }
                        }
                        else
                        {
                            ViewModel.LongitudeSlave2 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LongitudeSlave2.Length == 0)
                        {
                            ViewModel.LongitudeSlave2 = "0.";
                        }
                        else if (ViewModel.LongitudeSlave2.Contains("."))
                        {
                            ViewModel.LongitudeSlave2 = ViewModel.LongitudeSlave2;
                        }
                        else if (ViewModel.LongitudeSlave2.Length == 1 && ViewModel.LongitudeSlave2[0] == '-')
                        {
                            ViewModel.LongitudeSlave2 = "-0.";
                        }
                        else
                        {
                            ViewModel.LongitudeSlave2 = ViewModel.LongitudeSlave2 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LongitudeSlave2.Length == 1 && ViewModel.LongitudeSlave2[0] == '0')
                        {
                            ViewModel.LongitudeSlave2 = "";
                        }
                        ViewModel.LongitudeSlave2 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LongitudeSlave2.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 9;
                isTextboxClicked = true;
                backupString = ViewModel.ElevationSlave2;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.ElevationSlave2;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationSlave2.Length > 0)
                        {
                            ViewModel.ElevationSlave2 = ViewModel.ElevationSlave2.Substring(0, ViewModel.ElevationSlave2.Length - 1);
                        }
                        else
                        {
                            ViewModel.ElevationSlave2 = ViewModel.ElevationSlave2;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.ElevationSlave2.Length > 0)
                        {
                            if (ViewModel.ElevationSlave2[0] == '-')
                            {
                                ViewModel.ElevationSlave2 = ViewModel.ElevationSlave2.Substring(1);
                            }
                            else
                            {
                                ViewModel.ElevationSlave2 = '-' + ViewModel.ElevationSlave2;
                            }
                        }
                        else
                        {
                            ViewModel.ElevationSlave2 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.ElevationSlave2.Length == 0)
                        {
                            ViewModel.ElevationSlave2 = "0.";
                        }
                        else if (ViewModel.ElevationSlave2.Contains("."))
                        {
                            ViewModel.ElevationSlave2 = ViewModel.ElevationSlave2;
                        }
                        else if (ViewModel.ElevationSlave2.Length == 1 && ViewModel.ElevationSlave2[0] == '-')
                        {
                            ViewModel.ElevationSlave2 = "-0.";
                        }
                        else
                        {
                            ViewModel.ElevationSlave2 = ViewModel.ElevationSlave2 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.ElevationSlave2.Length == 1 && ViewModel.ElevationSlave2[0] == '0')
                        {
                            ViewModel.ElevationSlave2 = "";
                        }
                        ViewModel.ElevationSlave2 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.ElevationSlave2.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleLengthSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 10;
                isTextboxClicked = true;
                backupString = ViewModel.PoleLengthSlave2;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.PoleLengthSlave2;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.PoleLengthSlave2.Length > 0)
                        {
                            ViewModel.PoleLengthSlave2 = ViewModel.PoleLengthSlave2.Substring(0, ViewModel.PoleLengthSlave2.Length - 1);
                        }
                        else
                        {
                            ViewModel.PoleLengthSlave2 = ViewModel.PoleLengthSlave2;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.PoleLengthSlave2.Length > 0)
                        {
                            if (ViewModel.PoleLengthSlave2[0] == '-')
                            {
                                ViewModel.PoleLengthSlave2 = ViewModel.PoleLengthSlave2.Substring(1);
                            }
                            else
                            {
                                ViewModel.PoleLengthSlave2 = '-' + ViewModel.PoleLengthSlave2;
                            }
                        }
                        else
                        {
                            ViewModel.PoleLengthSlave2 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.PoleLengthSlave2.Length == 0)
                        {
                            ViewModel.PoleLengthSlave2 = "0.";
                        }
                        else if (ViewModel.PoleLengthSlave2.Contains("."))
                        {
                            ViewModel.PoleLengthSlave2 = ViewModel.PoleLengthSlave2;
                        }
                        else if (ViewModel.PoleLengthSlave2.Length == 1 && ViewModel.PoleLengthSlave2[0] == '-')
                        {
                            ViewModel.PoleLengthSlave2 = "-0.";
                        }
                        else
                        {
                            ViewModel.PoleLengthSlave2 = ViewModel.PoleLengthSlave2 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.PoleLengthSlave2.Length == 1 && ViewModel.PoleLengthSlave2[0] == '0')
                        {
                            ViewModel.PoleLengthSlave2 = "";
                        }
                        ViewModel.PoleLengthSlave2 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.PoleLengthSlave2.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void InstallationOrientationSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 11;
                isTextboxClicked = true;
                backupString = ViewModel.Slave2AntennaIPAddress;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.Slave2AntennaIPAddress;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.Slave2AntennaIPAddress.Length > 0)
                        {
                            ViewModel.Slave2AntennaIPAddress = ViewModel.Slave2AntennaIPAddress.Substring(0, ViewModel.Slave2AntennaIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.Slave2AntennaIPAddress = ViewModel.Slave2AntennaIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.Slave2AntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.Slave2AntennaIPAddress[0] == '-')
                            {
                                ViewModel.Slave2AntennaIPAddress = ViewModel.Slave2AntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.Slave2AntennaIPAddress = '-' + ViewModel.Slave2AntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.Slave2AntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.Slave2AntennaIPAddress.Length == 0)
                        {
                            ViewModel.Slave2AntennaIPAddress = "0.";
                        }
                        else if (ViewModel.Slave2AntennaIPAddress.Contains("."))
                        {
                            ViewModel.Slave2AntennaIPAddress = ViewModel.Slave2AntennaIPAddress;
                        }
                        else if (ViewModel.Slave2AntennaIPAddress.Length == 1 && ViewModel.Slave2AntennaIPAddress[0] == '-')
                        {
                            ViewModel.Slave2AntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.Slave2AntennaIPAddress = ViewModel.Slave2AntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.Slave2AntennaIPAddress.Length == 1 && ViewModel.Slave2AntennaIPAddress[0] == '0')
                        {
                            ViewModel.Slave2AntennaIPAddress = "";
                        }
                        ViewModel.Slave2AntennaIPAddress += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.Slave2AntennaIPAddress.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void AntennaIPAddressSlave2TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 26;
                isTextboxClicked = true;
                backupString = ViewModel.AntennaNameSlave2;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.AntennaNameSlave2;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.AntennaNameSlave2.Length > 0)
                        {
                            ViewModel.AntennaNameSlave2 = ViewModel.AntennaNameSlave2.Substring(0, ViewModel.AntennaNameSlave2.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.AntennaNameSlave2.Length > 0)
                        {
                            if (ViewModel.AntennaNameSlave2[0] == '-')
                            {
                                ViewModel.AntennaNameSlave2 = ViewModel.AntennaNameSlave2.Substring(1);
                            }
                            else
                            {
                                ViewModel.AntennaNameSlave2 = '-' + ViewModel.AntennaNameSlave2;
                            }
                        }
                        else
                        {
                            ViewModel.AntennaNameSlave2 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.AntennaNameSlave2.Length == 0)
                        {
                            ViewModel.AntennaNameSlave2 = "0.";
                        }
                        else if (!ViewModel.AntennaNameSlave2.Contains("."))
                        {
                            if (ViewModel.AntennaNameSlave2.Length == 1 && ViewModel.AntennaNameSlave2[0] == '-')
                            {
                                ViewModel.AntennaNameSlave2 = "-0.";
                            }
                            else
                            {
                                ViewModel.AntennaNameSlave2 += ".";
                            }
                        }
                    }
                    else
                    {
                        if (ViewModel.AntennaNameSlave2.Length == 1 && ViewModel.AntennaNameSlave2[0] == '0')
                        {
                            ViewModel.AntennaNameSlave2 = "";
                        }
                        ViewModel.AntennaNameSlave2 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.AntennaNameSlave2.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        //SLAVE 3
        private void LatitudeSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 13;
                isTextboxClicked = true;
                backupString = ViewModel.LatitudeSlave3;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LatitudeSlave3;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LatitudeSlave3.Length > 0)
                        {
                            ViewModel.LatitudeSlave3 = ViewModel.LatitudeSlave3.Substring(0, ViewModel.LatitudeSlave3.Length - 1);
                        }
                        else
                        {
                            ViewModel.LatitudeSlave3 = ViewModel.LatitudeSlave3;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LatitudeSlave3.Length > 0)
                        {
                            if (ViewModel.LatitudeSlave3[0] == '-')
                            {
                                ViewModel.LatitudeSlave3 = ViewModel.LatitudeSlave3.Substring(1);
                            }
                            else
                            {
                                ViewModel.LatitudeSlave3 = '-' + ViewModel.LatitudeSlave3;
                            }
                        }
                        else
                        {
                            ViewModel.LatitudeSlave3 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LatitudeSlave3.Length == 0)
                        {
                            ViewModel.LatitudeSlave3 = "0.";
                        }
                        else if (ViewModel.LatitudeSlave3.Contains("."))
                        {
                            ViewModel.LatitudeSlave3 = ViewModel.LatitudeSlave3;
                        }
                        else if (ViewModel.LatitudeSlave3.Length == 1 && ViewModel.LatitudeSlave3[0] == '-')
                        {
                            ViewModel.LatitudeSlave3 = "-0.";
                        }
                        else
                        {
                            ViewModel.LatitudeSlave3 = ViewModel.LatitudeSlave3 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LatitudeSlave3.Length == 1 && ViewModel.LatitudeSlave3[0] == '0')
                        {
                            ViewModel.LatitudeSlave3 = "";
                        }
                        ViewModel.LatitudeSlave3 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LatitudeSlave3.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 14;
                isTextboxClicked = true;
                backupString = ViewModel.LongitudeSlave3;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LongitudeSlave3;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LongitudeSlave3.Length > 0)
                        {
                            ViewModel.LongitudeSlave3 = ViewModel.LongitudeSlave3.Substring(0, ViewModel.LongitudeSlave3.Length - 1);
                        }
                        else
                        {
                            ViewModel.LongitudeSlave3 = ViewModel.LongitudeSlave3;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LongitudeSlave3.Length > 0)
                        {
                            if (ViewModel.LongitudeSlave3[0] == '-')
                            {
                                ViewModel.LongitudeSlave3 = ViewModel.LongitudeSlave3.Substring(1);
                            }
                            else
                            {
                                ViewModel.LongitudeSlave3 = '-' + ViewModel.LongitudeSlave3;
                            }
                        }
                        else
                        {
                            ViewModel.LongitudeSlave3 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LongitudeSlave3.Length == 0)
                        {
                            ViewModel.LongitudeSlave3 = "0.";
                        }
                        else if (ViewModel.LongitudeSlave3.Contains("."))
                        {
                            ViewModel.LongitudeSlave3 = ViewModel.LongitudeSlave3;
                        }
                        else if (ViewModel.LongitudeSlave3.Length == 1 && ViewModel.LongitudeSlave3[0] == '-')
                        {
                            ViewModel.LongitudeSlave3 = "-0.";
                        }
                        else
                        {
                            ViewModel.LongitudeSlave3 = ViewModel.LongitudeSlave3 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LongitudeSlave3.Length == 1 && ViewModel.LongitudeSlave3[0] == '0')
                        {
                            ViewModel.LongitudeSlave3 = "";
                        }
                        ViewModel.LongitudeSlave3 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LongitudeSlave3.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 15;
                isTextboxClicked = true;
                backupString = ViewModel.ElevationSlave3;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.ElevationSlave3;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationSlave3.Length > 0)
                        {
                            ViewModel.ElevationSlave3 = ViewModel.ElevationSlave3.Substring(0, ViewModel.ElevationSlave3.Length - 1);
                        }
                        else
                        {
                            ViewModel.ElevationSlave3 = ViewModel.ElevationSlave3;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.ElevationSlave3.Length > 0)
                        {
                            if (ViewModel.ElevationSlave3[0] == '-')
                            {
                                ViewModel.ElevationSlave3 = ViewModel.ElevationSlave3.Substring(1);
                            }
                            else
                            {
                                ViewModel.ElevationSlave3 = '-' + ViewModel.ElevationSlave3;
                            }
                        }
                        else
                        {
                            ViewModel.ElevationSlave3 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.ElevationSlave3.Length == 0)
                        {
                            ViewModel.ElevationSlave3 = "0.";
                        }
                        else if (ViewModel.ElevationSlave3.Contains("."))
                        {
                            ViewModel.ElevationSlave3 = ViewModel.ElevationSlave3;
                        }
                        else if (ViewModel.ElevationSlave3.Length == 1 && ViewModel.ElevationSlave3[0] == '-')
                        {
                            ViewModel.ElevationSlave3 = "-0.";
                        }
                        else
                        {
                            ViewModel.ElevationSlave3 = ViewModel.ElevationSlave3 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.ElevationSlave3.Length == 1 && ViewModel.ElevationSlave3[0] == '0')
                        {
                            ViewModel.ElevationSlave3 = "";
                        }
                        ViewModel.ElevationSlave3 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.ElevationSlave3.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleLengthSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 16;
                isTextboxClicked = true;
                backupString = ViewModel.PoleLengthSlave3;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.PoleLengthSlave3;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.PoleLengthSlave3.Length > 0)
                        {
                            ViewModel.PoleLengthSlave3 = ViewModel.PoleLengthSlave3.Substring(0, ViewModel.PoleLengthSlave3.Length - 1);
                        }
                        else
                        {
                            ViewModel.PoleLengthSlave3 = ViewModel.PoleLengthSlave3;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.PoleLengthSlave3.Length > 0)
                        {
                            if (ViewModel.PoleLengthSlave3[0] == '-')
                            {
                                ViewModel.PoleLengthSlave3 = ViewModel.PoleLengthSlave3.Substring(1);
                            }
                            else
                            {
                                ViewModel.PoleLengthSlave3 = '-' + ViewModel.PoleLengthSlave3;
                            }
                        }
                        else
                        {
                            ViewModel.PoleLengthSlave3 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.PoleLengthSlave3.Length == 0)
                        {
                            ViewModel.PoleLengthSlave3 = "0.";
                        }
                        else if (ViewModel.PoleLengthSlave3.Contains("."))
                        {
                            ViewModel.PoleLengthSlave3 = ViewModel.PoleLengthSlave3;
                        }
                        else if (ViewModel.PoleLengthSlave3.Length == 1 && ViewModel.PoleLengthSlave3[0] == '-')
                        {
                            ViewModel.PoleLengthSlave3 = "-0.";
                        }
                        else
                        {
                            ViewModel.PoleLengthSlave3 = ViewModel.PoleLengthSlave3 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.PoleLengthSlave3.Length == 1 && ViewModel.PoleLengthSlave3[0] == '0')
                        {
                            ViewModel.PoleLengthSlave3 = "";
                        }
                        ViewModel.PoleLengthSlave3 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.PoleLengthSlave3.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void InstallationOrientationSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 17;
                isTextboxClicked = true;
                backupString = ViewModel.Slave3AntennaIPAddress;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.Slave3AntennaIPAddress;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.Slave3AntennaIPAddress.Length > 0)
                        {
                            ViewModel.Slave3AntennaIPAddress = ViewModel.Slave3AntennaIPAddress.Substring(0, ViewModel.Slave3AntennaIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.Slave3AntennaIPAddress = ViewModel.Slave3AntennaIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.Slave3AntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.Slave3AntennaIPAddress[0] == '-')
                            {
                                ViewModel.Slave3AntennaIPAddress = ViewModel.Slave3AntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.Slave3AntennaIPAddress = '-' + ViewModel.Slave3AntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.Slave3AntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.Slave3AntennaIPAddress.Length == 0)
                        {
                            ViewModel.Slave3AntennaIPAddress = "0.";
                        }
                        else if (ViewModel.Slave3AntennaIPAddress.Contains("."))
                        {
                            ViewModel.Slave3AntennaIPAddress = ViewModel.Slave3AntennaIPAddress;
                        }
                        else if (ViewModel.Slave3AntennaIPAddress.Length == 1 && ViewModel.Slave3AntennaIPAddress[0] == '-')
                        {
                            ViewModel.Slave3AntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.Slave3AntennaIPAddress = ViewModel.Slave3AntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.Slave3AntennaIPAddress.Length == 1 && ViewModel.Slave3AntennaIPAddress[0] == '0')
                        {
                            ViewModel.Slave3AntennaIPAddress = "";
                        }
                        ViewModel.Slave3AntennaIPAddress += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.Slave3AntennaIPAddress.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void AntennaIPAddressSlave3TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 27;
                isTextboxClicked = true;
                backupString = ViewModel.AntennaNameSlave3;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.AntennaNameSlave3;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.AntennaNameSlave3.Length > 0)
                        {
                            ViewModel.AntennaNameSlave3 = ViewModel.AntennaNameSlave3.Substring(0, ViewModel.AntennaNameSlave3.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.AntennaNameSlave3.Length > 0)
                        {
                            if (ViewModel.AntennaNameSlave3[0] == '-')
                            {
                                ViewModel.AntennaNameSlave3 = ViewModel.AntennaNameSlave3.Substring(1);
                            }
                            else
                            {
                                ViewModel.AntennaNameSlave3 = '-' + ViewModel.AntennaNameSlave3;
                            }
                        }
                        else
                        {
                            ViewModel.AntennaNameSlave3 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.AntennaNameSlave3.Length == 0)
                        {
                            ViewModel.AntennaNameSlave3 = "0.";
                        }
                        else if (!ViewModel.AntennaNameSlave3.Contains("."))
                        {
                            if (ViewModel.AntennaNameSlave3.Length == 1 && ViewModel.AntennaNameSlave3[0] == '-')
                            {
                                ViewModel.AntennaNameSlave3 = "-0.";
                            }
                            else
                            {
                                ViewModel.AntennaNameSlave3 += ".";
                            }
                        }
                    }
                    else
                    {
                        if (ViewModel.AntennaNameSlave3.Length == 1 && ViewModel.AntennaNameSlave3[0] == '0')
                        {
                            ViewModel.AntennaNameSlave3 = "";
                        }
                        ViewModel.AntennaNameSlave3 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.AntennaNameSlave3.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        //SLAVE 4
        private void LatitudeSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 19;
                isTextboxClicked = true;
                backupString = ViewModel.LatitudeSlave4;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LatitudeSlave4;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LatitudeSlave4.Length > 0)
                        {
                            ViewModel.LatitudeSlave4 = ViewModel.LatitudeSlave4.Substring(0, ViewModel.LatitudeSlave4.Length - 1);
                        }
                        else
                        {
                            ViewModel.LatitudeSlave4 = ViewModel.LatitudeSlave4;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LatitudeSlave4.Length > 0)
                        {
                            if (ViewModel.LatitudeSlave4[0] == '-')
                            {
                                ViewModel.LatitudeSlave4 = ViewModel.LatitudeSlave4.Substring(1);
                            }
                            else
                            {
                                ViewModel.LatitudeSlave4 = '-' + ViewModel.LatitudeSlave4;
                            }
                        }
                        else
                        {
                            ViewModel.LatitudeSlave4 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LatitudeSlave4.Length == 0)
                        {
                            ViewModel.LatitudeSlave4 = "0.";
                        }
                        else if (ViewModel.LatitudeSlave4.Contains("."))
                        {
                            ViewModel.LatitudeSlave4 = ViewModel.LatitudeSlave4;
                        }
                        else if (ViewModel.LatitudeSlave4.Length == 1 && ViewModel.LatitudeSlave4[0] == '-')
                        {
                            ViewModel.LatitudeSlave4 = "-0.";
                        }
                        else
                        {
                            ViewModel.LatitudeSlave4 = ViewModel.LatitudeSlave4 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LatitudeSlave4.Length == 1 && ViewModel.LatitudeSlave4[0] == '0')
                        {
                            ViewModel.LatitudeSlave4 = "";
                        }
                        ViewModel.LatitudeSlave4 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LatitudeSlave4.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void LongitudeSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 20;
                isTextboxClicked = true;
                backupString = ViewModel.LongitudeSlave4;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LongitudeSlave4;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.LongitudeSlave4.Length > 0)
                        {
                            ViewModel.LongitudeSlave4 = ViewModel.LongitudeSlave4.Substring(0, ViewModel.LongitudeSlave4.Length - 1);
                        }
                        else
                        {
                            ViewModel.LongitudeSlave4 = ViewModel.LongitudeSlave4;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.LongitudeSlave4.Length > 0)
                        {
                            if (ViewModel.LongitudeSlave4[0] == '-')
                            {
                                ViewModel.LongitudeSlave4 = ViewModel.LongitudeSlave4.Substring(1);
                            }
                            else
                            {
                                ViewModel.LongitudeSlave4 = '-' + ViewModel.LongitudeSlave4;
                            }
                        }
                        else
                        {
                            ViewModel.LongitudeSlave4 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.LongitudeSlave4.Length == 0)
                        {
                            ViewModel.LongitudeSlave4 = "0.";
                        }
                        else if (ViewModel.LongitudeSlave4.Contains("."))
                        {
                            ViewModel.LongitudeSlave4 = ViewModel.LongitudeSlave4;
                        }
                        else if (ViewModel.LongitudeSlave4.Length == 1 && ViewModel.LongitudeSlave4[0] == '-')
                        {
                            ViewModel.LongitudeSlave4 = "-0.";
                        }
                        else
                        {
                            ViewModel.LongitudeSlave4 = ViewModel.LongitudeSlave4 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.LongitudeSlave4.Length == 1 && ViewModel.LongitudeSlave4[0] == '0')
                        {
                            ViewModel.LongitudeSlave4 = "";
                        }
                        ViewModel.LongitudeSlave4 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.LongitudeSlave4.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void ElevationSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 21;
                isTextboxClicked = true;
                backupString = ViewModel.ElevationSlave4;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.ElevationSlave4;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.ElevationSlave4.Length > 0)
                        {
                            ViewModel.ElevationSlave4 = ViewModel.ElevationSlave4.Substring(0, ViewModel.ElevationSlave4.Length - 1);
                        }
                        else
                        {
                            ViewModel.ElevationSlave4 = ViewModel.ElevationSlave4;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.ElevationSlave4.Length > 0)
                        {
                            if (ViewModel.ElevationSlave4[0] == '-')
                            {
                                ViewModel.ElevationSlave4 = ViewModel.ElevationSlave4.Substring(1);
                            }
                            else
                            {
                                ViewModel.ElevationSlave4 = '-' + ViewModel.ElevationSlave4;
                            }
                        }
                        else
                        {
                            ViewModel.ElevationSlave4 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.ElevationSlave4.Length == 0)
                        {
                            ViewModel.ElevationSlave4 = "0.";
                        }
                        else if (ViewModel.ElevationSlave4.Contains("."))
                        {
                            ViewModel.ElevationSlave4 = ViewModel.ElevationSlave4;
                        }
                        else if (ViewModel.ElevationSlave4.Length == 1 && ViewModel.ElevationSlave4[0] == '-')
                        {
                            ViewModel.ElevationSlave4 = "-0.";
                        }
                        else
                        {
                            ViewModel.ElevationSlave4 = ViewModel.ElevationSlave4 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.ElevationSlave4.Length == 1 && ViewModel.ElevationSlave4[0] == '0')
                        {
                            ViewModel.ElevationSlave4 = "";
                        }
                        ViewModel.ElevationSlave4 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.ElevationSlave4.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void PoleLengthSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 22;
                isTextboxClicked = true;
                backupString = ViewModel.PoleLengthSlave4;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.PoleLengthSlave4;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.PoleLengthSlave4.Length > 0)
                        {
                            ViewModel.PoleLengthSlave4 = ViewModel.PoleLengthSlave4.Substring(0, ViewModel.PoleLengthSlave4.Length - 1);
                        }
                        else
                        {
                            ViewModel.PoleLengthSlave4 = ViewModel.PoleLengthSlave4;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.PoleLengthSlave4.Length > 0)
                        {
                            if (ViewModel.PoleLengthSlave4[0] == '-')
                            {
                                ViewModel.PoleLengthSlave4 = ViewModel.PoleLengthSlave4.Substring(1);
                            }
                            else
                            {
                                ViewModel.PoleLengthSlave4 = '-' + ViewModel.PoleLengthSlave4;
                            }
                        }
                        else
                        {
                            ViewModel.PoleLengthSlave4 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.PoleLengthSlave4.Length == 0)
                        {
                            ViewModel.PoleLengthSlave4 = "0.";
                        }
                        else if (ViewModel.PoleLengthSlave4.Contains("."))
                        {
                            ViewModel.PoleLengthSlave4 = ViewModel.PoleLengthSlave4;
                        }
                        else if (ViewModel.PoleLengthSlave4.Length == 1 && ViewModel.PoleLengthSlave4[0] == '-')
                        {
                            ViewModel.PoleLengthSlave4 = "-0.";
                        }
                        else
                        {
                            ViewModel.PoleLengthSlave4 = ViewModel.PoleLengthSlave4 + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.PoleLengthSlave4.Length == 1 && ViewModel.PoleLengthSlave4[0] == '0')
                        {
                            ViewModel.PoleLengthSlave4 = "";
                        }
                        ViewModel.PoleLengthSlave4 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.PoleLengthSlave4.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void InstallationOrientationSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 23;
                isTextboxClicked = true;
                backupString = ViewModel.Slave4AntennaIPAddress;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.Slave4AntennaIPAddress;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.Slave4AntennaIPAddress.Length > 0)
                        {
                            ViewModel.Slave4AntennaIPAddress = ViewModel.Slave4AntennaIPAddress.Substring(0, ViewModel.Slave4AntennaIPAddress.Length - 1);
                        }
                        else
                        {
                            ViewModel.Slave4AntennaIPAddress = ViewModel.Slave4AntennaIPAddress;
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.Slave4AntennaIPAddress.Length > 0)
                        {
                            if (ViewModel.Slave4AntennaIPAddress[0] == '-')
                            {
                                ViewModel.Slave4AntennaIPAddress = ViewModel.Slave4AntennaIPAddress.Substring(1);
                            }
                            else
                            {
                                ViewModel.Slave4AntennaIPAddress = '-' + ViewModel.Slave4AntennaIPAddress;
                            }
                        }
                        else
                        {
                            ViewModel.Slave4AntennaIPAddress = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.Slave4AntennaIPAddress.Length == 0)
                        {
                            ViewModel.Slave4AntennaIPAddress = "0.";
                        }
                        else if (ViewModel.Slave4AntennaIPAddress.Contains("."))
                        {
                            ViewModel.Slave4AntennaIPAddress = ViewModel.Slave4AntennaIPAddress;
                        }
                        else if (ViewModel.Slave4AntennaIPAddress.Length == 1 && ViewModel.Slave4AntennaIPAddress[0] == '-')
                        {
                            ViewModel.Slave4AntennaIPAddress = "-0.";
                        }
                        else
                        {
                            ViewModel.Slave4AntennaIPAddress = ViewModel.Slave4AntennaIPAddress + ".";
                        }
                    }
                    else
                    {
                        if (ViewModel.Slave4AntennaIPAddress.Length == 1 && ViewModel.Slave4AntennaIPAddress[0] == '0')
                        {
                            ViewModel.Slave4AntennaIPAddress = "";
                        }
                        ViewModel.Slave4AntennaIPAddress += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.Slave4AntennaIPAddress.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void AntennaIPAddressSlave4TextBox()
        {
            if (ViewModel != null)
            {
                textBoxNo = 28;
                isTextboxClicked = true;
                backupString = ViewModel.AntennaNameSlave4;
                _numericKeyboardWindowSubstationReg = new NumericKeyboardWindowSubstationReg(textBoxNo, ViewModel, backupString);
                _numericKeyboardWindowSubstationReg.Owner = Application.Current.MainWindow;
                _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.AntennaNameSlave4;
                _numericKeyboardWindowSubstationReg.KeyPressed += (s, key) =>
                {
                    if (key == "Backspace")
                    {
                        if (ViewModel.AntennaNameSlave4.Length > 0)
                        {
                            ViewModel.AntennaNameSlave4 = ViewModel.AntennaNameSlave4.Substring(0, ViewModel.AntennaNameSlave4.Length - 1);
                        }
                    }
                    else if (key == "+/-")
                    {
                        if (ViewModel.AntennaNameSlave4.Length > 0)
                        {
                            if (ViewModel.AntennaNameSlave4[0] == '-')
                            {
                                ViewModel.AntennaNameSlave4 = ViewModel.AntennaNameSlave4.Substring(1);
                            }
                            else
                            {
                                ViewModel.AntennaNameSlave4 = '-' + ViewModel.AntennaNameSlave4;
                            }
                        }
                        else
                        {
                            ViewModel.AntennaNameSlave4 = "-";
                        }
                    }
                    else if (key == ".")
                    {
                        if (ViewModel.AntennaNameSlave4.Length == 0)
                        {
                            ViewModel.AntennaNameSlave4 = "0.";
                        }
                        else if (!ViewModel.AntennaNameSlave4.Contains("."))
                        {
                            if (ViewModel.AntennaNameSlave4.Length == 1 && ViewModel.AntennaNameSlave4[0] == '-')
                            {
                                ViewModel.AntennaNameSlave4 = "-0.";
                            }
                            else
                            {
                                ViewModel.AntennaNameSlave4 += ".";
                            }
                        }
                    }
                    else
                    {
                        if (ViewModel.AntennaNameSlave4.Length == 1 && ViewModel.AntennaNameSlave4[0] == '0')
                        {
                            ViewModel.AntennaNameSlave4 = "";
                        }
                        ViewModel.AntennaNameSlave4 += key;
                    };
                    _numericKeyboardWindowSubstationReg.KeyPad.Text = ViewModel.AntennaNameSlave4.ToString();
                };
                _numericKeyboardWindowSubstationReg.Show();
            }
            else
            {
                CreateAppClassAfterDelay();
            }
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

        private void KeypadClose()
        {
            if (ViewModel != null)
            {
                _numericKeyboardWindowSubstationReg.Close();
                Keyboard.ClearFocus();
                if (textBoxNo == 1 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.LatitudeSlave1 = backupString;
                }
                else if (textBoxNo == 2 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.LongitudeSlave1 = backupString;
                }
                else if (textBoxNo == 3 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.ElevationSlave1 = backupString;
                }
                else if (textBoxNo == 4 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.PoleLengthSlave1 = backupString;
                }
                else if (textBoxNo == 5 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.Slave1AntennaIPAddress = backupString;
                }
                else if (textBoxNo == 7 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.LatitudeSlave2 = backupString;
                }
                else if (textBoxNo == 8 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.LongitudeSlave2 = backupString;
                }
                else if (textBoxNo == 9 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.ElevationSlave2 = backupString;
                }
                else if (textBoxNo == 10 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.PoleLengthSlave2 = backupString;
                }
                else if (textBoxNo == 11 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.Slave2AntennaIPAddress = backupString;
                }
                else if (textBoxNo == 13 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.LatitudeSlave3 = backupString;
                }
                else if (textBoxNo == 14 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.LongitudeSlave3 = backupString;
                }
                else if (textBoxNo == 15 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.ElevationSlave3 = backupString;
                }
                else if (textBoxNo == 16 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.PoleLengthSlave3 = backupString;
                }
                else if (textBoxNo == 17 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.Slave3AntennaIPAddress = backupString;
                }
                else if (textBoxNo == 19 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.LatitudeSlave4 = backupString;
                }
                else if (textBoxNo == 20 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.LongitudeSlave4 = backupString;
                }
                else if (textBoxNo == 21 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.ElevationSlave4 = backupString;
                }
                else if (textBoxNo == 22 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.PoleLengthSlave4 = backupString;
                }
                else if (textBoxNo == 23 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.Slave4AntennaIPAddress = backupString;
                }
                else if (textBoxNo == 25 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.AntennaNameSlave1 = backupString;
                }
                else if (textBoxNo == 26 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.AntennaNameSlave2 = backupString;
                }
                else if (textBoxNo == 27 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.AntennaNameSlave3 = backupString;
                }
                else if (textBoxNo == 28 && _numericKeyboardWindowSubstationReg._status != 1)
                {
                    ViewModel.AntennaNameSlave4 = backupString;
                }

            }
            else
            {
                CreateAppClassAfterDelay();
            }
        }

        private void SubstationDB1PageMasterNavigateMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ViewModel?.SubstationDB1PageMasterNavigateCommand?.Execute(e);
        }

        private void SubstationDB1PageMasterNavigateMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ViewModel?.SubstationDB1PageMasterNavigateCommand?.Execute(e);
        }

        private void SubstationDB1PageMasterNavigateMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.SubstationDB1PageMasterNavigateCommand?.Execute(e);
        }

        private void SubstationDB2PageMasterNavigateMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ViewModel?.SubstationDB2PageMasterNavigateCommand?.Execute(e);
        }

        private void SubstationDB2PageMasterNavigateMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ViewModel?.SubstationDB2PageMasterNavigateCommand?.Execute(e);
        }

        private void SubstationDB2PageMasterNavigateMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.SubstationDB2PageMasterNavigateCommand?.Execute(e);
        }

        private void SubstationDB3PageMasterNavigateMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ViewModel?.SubstationDB3PageMasterNavigateCommand?.Execute(e);
        }

        private void SubstationDB3PageMasterNavigateMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ViewModel?.SubstationDB3PageMasterNavigateCommand?.Execute(e);
        }

        private void SubstationDB3PageMasterNavigateMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.SubstationDB3PageMasterNavigateCommand?.Execute(e);
        }

        private void SubstationDB4PageMasterNavigateMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ViewModel?.SubstationDB4PageMasterNavigateCommand?.Execute(e);
        }

        private void SubstationDB4PageMasterNavigateMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ViewModel?.SubstationDB4PageMasterNavigateCommand?.Execute(e);
        }

        private void SubstationDB4PageMasterNavigateMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.SubstationDB4PageMasterNavigateCommand?.Execute(e);
        }

        private void MainPageMasterNavigateMaster_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ViewModel?.MainPageMasterNavigateCommand?.Execute(e);
        }

        private void MainPageMasterNavigateMaster_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ViewModel?.MainPageMasterNavigateCommand?.Execute(e);
        }

        private void MainPageMasterNavigateMaster_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel?.MainPageMasterNavigateCommand?.Execute(e);
        }
    }
}
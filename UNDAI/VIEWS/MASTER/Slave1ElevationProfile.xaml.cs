using OxyPlot.Axes;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using UNDAI.MODELS.BASE;
using Wpf.Ui.Input;
using OxyPlot.Wpf;
using System.DirectoryServices.ActiveDirectory;

namespace UNDAI.VIEWS.MASTER
{
    /// <summary>
    /// Interaction logic for Slave1ElevationProfile.xaml
    /// </summary>
    public partial class Slave1ElevationProfile : Window
    {
        private CancellationTokenSource _cancellationTokenSource;
        private ElevationProfileGenerateModel _elevationProfileGenerateModel;
        GPSMapIntoCircle gPSMapIntoCircle;

        private string _firstLatitude;
        private string _firstLongitude;
        private string _secondLatitude;
        private string _secondLongitude;
        public bool plotGenerated = false;
        public LineSeries lineSeries;
        public LinearAxis xAxis;
        public LinearAxis yAxis;
        PlotModel plotModel;
        int circleRadius = 3000;
        float XCoordinate;
        float YCoordinate; 
        const int ScalingFactor = 100; // 1 km = 100 pixels
        const int CircleRadiusKm = 3; // Radius in kilometers
        float MasterInstallationOrientationTextBackup = 0;


        public List<float> elevation;
        public float distanceBetweenTwoPoints;

        public Slave1ElevationProfile(string lat1, string long1, string lat2, string long2, bool _plotGenerated, float _masterInstallationOrientationTextBackup, List<float> _elevation = null, float _distanceBetweenTwoPoints = 0)
        {
            InitializeComponent();

            _firstLatitude = lat1;
            _firstLongitude = long1;
            _secondLatitude = lat2;
            _secondLongitude = long2;
            plotGenerated = _plotGenerated;
            MasterInstallationOrientationTextBackup = _masterInstallationOrientationTextBackup;

            if (_elevation != null)
            {
                // Create a new plot model and series
                plotModel = new PlotModel
                {
                    Title = "標高プロファイル", TitleFontSize = 40,
                };
                lineSeries = new AreaSeries
                {
                    //Title = "Line Series",
                    //InterpolationAlgorithm = InterpolationAlgorithms.CanonicalSpline,  // Smooth curve
                    Color = OxyColor.Parse("#004b23"),   // Color of the line
                    Fill = OxyColor.Parse("#d5f89c"), // Fill color for the area under the graph
                };

                // Add a linear axis for X
                xAxis = new LinearAxis
                {
                    Position = AxisPosition.Bottom,
                    Title = "DISTANCE (km)",
                    Minimum = 1,  // Set the minimum value for the X axis
                    Maximum = 100,  // Set the maximum value for the X axis
                    IsZoomEnabled = false, // Disable zooming on the X-axis
                    IsPanEnabled = false, // Disable panning on the X-axis
                };
                plotModel.Axes.Add(xAxis);

                // Add a linear axis for Y
                yAxis = new LinearAxis
                {
                    Position = AxisPosition.Left,
                    Title = "ELEVATION (m)",
                    Minimum = 0,    // Set the minimum value for the Y axis
                    Maximum = 100,  // Set the maximum value for the Y axis
                    IsZoomEnabled = false, // Disable zooming on the Y-axis
                    IsPanEnabled = false, // Disable panning on the Y-axis
                };
                plotModel.Axes.Add(yAxis);

                // Add series to the model
                plotModel.Series.Add(lineSeries);
                // Assign the model to the PlotView
                plotView.Model = plotModel;

                elevation = new List<float>();
                elevation = _elevation;
                distanceBetweenTwoPoints = _distanceBetweenTwoPoints;
            }

            // Attach Loaded and Closed events
            Loaded += Slave1ElevationProfile_Loaded;
            Closed += Slave1ElevationProfile_Closed;
        }

        private async void Slave1ElevationProfile_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize cancellation token source
            _cancellationTokenSource = new CancellationTokenSource();

            if (!plotGenerated)
            {

                // Initialize and start elevation profile generation
                _elevationProfileGenerateModel = new ElevationProfileGenerateModel(plotView);
                try
                {
                    // Pass the cancellation token to the generation process
                    await Task.Run(() => _elevationProfileGenerateModel.ElevationProfileGenerator(_firstLatitude, _firstLongitude, _secondLatitude, _secondLongitude, _cancellationTokenSource.Token));

                    plotGenerated = _elevationProfileGenerateModel.plotGenerated;
                    if (plotGenerated)
                    {
                        elevation = new List<float>();
                        elevation = _elevationProfileGenerateModel.elevation;
                        distanceBetweenTwoPoints = _elevationProfileGenerateModel.distanceBetweenTwoPoints;
                        lineSeries = _elevationProfileGenerateModel._lineSeries;
                        xAxis = _elevationProfileGenerateModel.xAxis;
                        yAxis = _elevationProfileGenerateModel.yAxis;
                    }
                }
                catch (OperationCanceledException)
                {
                    // Handle the cancellation if needed
                    Console.WriteLine("Elevation profile generation was canceled.");
                    plotGenerated = _elevationProfileGenerateModel.plotGenerated;
                }
            }
            else
            {
                RePlotGraph();
            }
            PlotGpsPoints();
        }

        private void Slave1ElevationProfile_Closed(object sender, EventArgs e)
        {
            // Trigger cancellation when the window closes
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }

        private async void ExecuteCloseWindow(object obj)
        {
            // Close the window
            Close();
        }

        private async void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ExecuteCloseWindow(sender);
        }

        private async void Button_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            ExecuteCloseWindow(sender);
        }

        private async void Button_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            ExecuteCloseWindow(sender);
        }

        public void RePlotGraph()
        {
            try
            {
                ClearGraph();
                // Method to dynamically add points
                for (int i = 0; i < elevation.Count; i++)
                {
                    if (elevation[i] == -999.9f)
                    {
                        AddNewPoint(Math.Round(distanceBetweenTwoPoints * (i) / (elevation.Count), 2), 0);
                    }
                    else
                    {
                        AddNewPoint(Math.Round(distanceBetweenTwoPoints * (i) / (elevation.Count), 2), elevation[i]);
                    }
                }
                plotView.InvalidatePlot(true); // Refresh the plot view to show new data
                plotGenerated = true;
            }
            catch (OperationCanceledException)
            {
                // Handle the cancellation if needed
                Console.WriteLine("Elevation profile generation was canceled.");
                plotGenerated = false;
            }
        }

        // Method to dynamically add points
        public void AddNewPoint(double x, double y)
        {
            lineSeries.Points.Add(new DataPoint(x, y));

            // Optionally adjust the Y-axis limits dynamically
            double minY = lineSeries.Points.Min(point => point.Y);
            double maxY = lineSeries.Points.Max(point => point.Y);
            yAxis.Minimum = 0 ; // Adjust the minimum value of Y-axis
            yAxis.Maximum = maxY + 10; // Add some margin above the max value

            // Optionally adjust the X-axis limits dynamically
            double minX = lineSeries.Points.Min(point => point.X);
            double maxX = lineSeries.Points.Max(point => point.X);
            xAxis.Minimum = minX; // Adjust the minimum value of Y-axis
            xAxis.Maximum = maxX; // Add some margin above the max value
        }

        public void ClearGraph()
        {
            lineSeries.Points.Clear(); // Clear all points from the series
            plotView.InvalidatePlot(true); // Refresh the plot view to reflect the changes
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExecuteCloseWindow(sender);
        }

        public void PlotGpsPoints()
        {
            gPSMapIntoCircle = new GPSMapIntoCircle(_firstLatitude, _firstLongitude, _secondLatitude, _secondLongitude, circleRadius);
            XCoordinate = gPSMapIntoCircle.XCoordinate;
            YCoordinate = gPSMapIntoCircle.YCoordinate;

            float scaleFactor = (float)(circleRadius / (PlotCanvas.Width/2));

            // Center coordinates for Point1 on the Canvas
            float centerX = (float)(PlotCanvas.Width / 2);
            float centerY = (float)(PlotCanvas.Height / 2);

            // Draw the circle (representing the area within the radius)
            Ellipse circle = new Ellipse
            {
                Width = PlotCanvas.Width,
                Height = PlotCanvas.Width,
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };

            Canvas.SetLeft(circle, 0);
            Canvas.SetTop(circle, 0);
            PlotCanvas.Children.Add(circle);

            // Draw the 1km circle
            DrawDistanceCircle(centerX, centerY, 1, "1km");

            // Draw the 2km circle
            DrawDistanceCircle(centerX, centerY, 2, "2km");

            // Draw direction lines
            DrawDirectionLine(centerX, centerY, 0, -circleRadius / scaleFactor, "北");
            DrawDirectionLine(centerX, centerY, 0, circleRadius / scaleFactor, "南");
            DrawDirectionLine(centerX, centerY, circleRadius / scaleFactor, 0, "東");
            DrawDirectionLine(centerX, centerY, -circleRadius / scaleFactor, 0, "西");

            // Plot mapped Point2
            double point2X = centerX + XCoordinate / scaleFactor;
            double point2Y = centerY - YCoordinate / scaleFactor; // Invert Y because Canvas Y-axis is top-down

            // Plot Point1 (center)
            DrawPoint(centerX, centerY, Brushes.Red, "Master", 12);

            // Draw direction lines
            DrawRadialLines(centerX, centerY, circleRadius/scaleFactor);

            // Plot mapped Point2
            DrawPoint(point2X, point2Y, Brushes.Green, "Slave1 " + Math.Round(gPSMapIntoCircle.angle,2) + "° " + Math.Round(distanceBetweenTwoPoints, 2)+"km", 12);

            DrawArrow(centerX, centerY, MasterInstallationOrientationTextBackup, 30); // Draw an arrow 30 pixels long at 35 degrees from north
        }

        private void DrawDistanceCircle(double startX, double startY, double factor, string label) 
        {
            // Draw the distance circle
            Ellipse distanceCircle = new Ellipse
            {
                Width = factor * PlotCanvas.Width / 3,
                Height = factor * PlotCanvas.Width / 3,
                Stroke = Brushes.Black,
                StrokeThickness = 0.5,
                StrokeDashArray = new DoubleCollection { 2, 2 }
            };

            Canvas.SetLeft(distanceCircle, startX - distanceCircle.Width / 2);
            Canvas.SetTop(distanceCircle, startY - distanceCircle.Height / 2);
            PlotCanvas.Children.Add(distanceCircle);
            
            // Add label
            TextBlock text = new TextBlock
            {
                Text = label,
                FontSize = 12,
                Foreground = Brushes.Black
            };
            Canvas.SetLeft(text, startX + 5);
            Canvas.SetTop(text, startY - distanceCircle.Height/2 - 17);
            PlotCanvas.Children.Add(text);
        }

        private void DrawPoint(double x, double y, Brush color, string label, int size)
        {
            // Draw point
            Ellipse point = new Ellipse
            {
                Width = size,
                Height = size,
                Fill = color
            };
            Canvas.SetLeft(point, x - point.Width / 2);
            Canvas.SetTop(point, y - point.Height / 2);
            PlotCanvas.Children.Add(point);

            // Add label
            TextBlock text = new TextBlock
            {
                Text = label,
                FontSize = 12,
                Foreground = color
            };
            Canvas.SetLeft(text, x + 5);
            Canvas.SetTop(text, y + 5);
            PlotCanvas.Children.Add(text);
        }

        private void DrawDirectionLine(double startX, double startY, double offsetX, double offsetY, string label)
        {
            // Draw line
            Line directionLine = new Line
            {
                X1 = startX,
                Y1 = startY,
                X2 = startX + offsetX,
                Y2 = startY + offsetY,
                Stroke = Brushes.Black,
                StrokeThickness = 0.8
            };
            PlotCanvas.Children.Add(directionLine);

            // Add label
            TextBlock text = new TextBlock
            {
                Text = label,
                FontSize = 20,
                Foreground = Brushes.Black
            };
            
            // Adjust label position based on direction
            if (label == "北")
            {
                Canvas.SetLeft(text, startX - 10); // Center the text above the line
                Canvas.SetTop(text, startY + offsetY - 30); // Place above
            }
            else if (label == "南")
            {
                Canvas.SetLeft(text, startX - 10); // Center the text below the line
                Canvas.SetTop(text, startY + offsetY + 5); // Place below
            }
            else if (label == "東")
            {
                Canvas.SetLeft(text, startX + offsetX + 5); // Position right
                Canvas.SetTop(text, startY - 10); // Center vertically
            }
            else if (label == "西")
            {
                Canvas.SetLeft(text, startX + offsetX - 30); // Position left
                Canvas.SetTop(text, startY - 10); // Center vertically
            }

            PlotCanvas.Children.Add(text);
        }

        private void DrawRadialLines(double centerX, double centerY, double radius)
        {
            // Draw lines at 30-degree intervals
            for (int angle = 0; angle < 360; angle += 30)
            {
                if(angle == 0 || angle == 90 || angle == 180 || angle == 270)
                {
                    continue;
                }
                // Convert degrees to radians
                double angleRad = Math.PI * angle / 180.0;

                // Calculate the end point of each line
                double endX = centerX + radius * Math.Cos(angleRad);
                double endY = centerY - radius * Math.Sin(angleRad); // Subtract because Y axis is inverted on Canvas

                // Create and draw the line
                Line radialLine = new Line
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = endX,
                    Y2 = endY,
                    Stroke = Brushes.Gray,
                    StrokeThickness = 0.5,
                    StrokeDashArray = new DoubleCollection { 2, 2 }
                };

                PlotCanvas.Children.Add(radialLine);
            }
        }

        private void DrawPointLine(double startX, double startY, double endX, double endY, string label)
        {
            // Draw line
            Line directionLine = new Line
            {
                X1 = startX,
                Y1 = startY,
                X2 = endX,
                Y2 = endY,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };
            PlotCanvas.Children.Add(directionLine);

            // Add label if needed
            TextBlock text = new TextBlock
            {
                Text = label,
                FontSize = 12,
                Foreground = Brushes.Black
            };
            Canvas.SetLeft(text, (startX + endX) / 2);
            Canvas.SetTop(text, (startY + endY) / 2);
            PlotCanvas.Children.Add(text);
        }

        private void DrawArrow(double centerX, double centerY, double angleDegrees, double length)
        {
            // Convert angle to radians
            double angleRadians = Math.PI/2 - Math.PI * angleDegrees / 180.0;

            // Calculate end point based on angle and length
            double endX = centerX + length * Math.Cos(angleRadians);
            double endY = centerY - length * Math.Sin(angleRadians); // Invert Y because Canvas Y-axis is top-down

            // Draw the main line for the arrow
            Line arrowLine = new Line
            {
                X1 = centerX,
                Y1 = centerY,
                X2 = endX,
                Y2 = endY,
                Stroke = Brushes.Red,
                StrokeThickness = 1.5
            };
            PlotCanvas.Children.Add(arrowLine);

            // Draw arrowhead using a small triangle
            double arrowHeadSize = 20; // Size of the arrowhead
            double angleOffset = 15 * Math.PI / 180.0; // 15 degrees offset for the arrowhead wings

            // Calculate the points for the arrowhead triangle
            Point p1 = new Point(endX, endY);
            Point p2 = new Point(
                endX - arrowHeadSize * Math.Cos(angleRadians - angleOffset),
                endY + arrowHeadSize * Math.Sin(angleRadians - angleOffset)
            );
            Point p3 = new Point(
                endX - arrowHeadSize * Math.Cos(angleRadians + angleOffset),
                endY + arrowHeadSize * Math.Sin(angleRadians + angleOffset)
            );

            Polygon arrowHead = new Polygon
            {
                Points = new PointCollection { p1, p2, p3 },
                Fill = Brushes.Red
            };
            PlotCanvas.Children.Add(arrowHead);
        }

    }
}

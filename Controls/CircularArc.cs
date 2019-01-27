using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Controls
{
    public class CircularArc : Shape
    {
        static CircularArc()
        {
            Brush brush = new SolidColorBrush(Color.FromArgb(255, 6, 176, 37));

            StrokeProperty.OverrideMetadata(
                typeof(CircularArc),
                new FrameworkPropertyMetadata(brush));
            FillProperty.OverrideMetadata(
                typeof(CircularArc),
                new FrameworkPropertyMetadata(Brushes.Transparent));
            StrokeThicknessProperty.OverrideMetadata(
                typeof(CircularArc),
                new FrameworkPropertyMetadata(10.0));
        }

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register(
            "Angle",
            typeof(double),
            typeof(CircularArc),
            AngleMetadata);

        private static FrameworkPropertyMetadata AngleMetadata = new FrameworkPropertyMetadata(
                0.0,
                FrameworkPropertyMetadataOptions.AffectsRender,
                null,
                CoerceValue);

        private static object CoerceValue(DependencyObject obj, object value)
        {
            double val = (double)value;
            val = Math.Min(val, 360.0);
            val = Math.Max(val, 0.0);
            return val;
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                double startAngle = 90.0;
                double endAngle = 90.0 - Angle;

                double maxWidth = Math.Max(0.0, RenderSize.Width - StrokeThickness);
                double maxHeight = Math.Max(0.0, RenderSize.Height - StrokeThickness);

                double xStart = maxWidth / 2.0 * Math.Cos(startAngle * Math.PI / 180.0);
                double yStart = maxHeight / 2.0 * Math.Sin(startAngle * Math.PI / 180.0);

                double xEnd = maxWidth / 2.0 * Math.Cos(endAngle * Math.PI / 180.0);
                double yEnd = maxHeight / 2.0 * Math.Sin(endAngle * Math.PI / 180.0);

                StreamGeometry geometry = new StreamGeometry();
                using (StreamGeometryContext context = geometry.Open())
                {
                    context.BeginFigure(
                        new Point((RenderSize.Width / 2.0) + xStart,
                                  (RenderSize.Height / 2.0) - yStart),
                        true,  
                        false);
                    context.ArcTo(
                        new Point((RenderSize.Width / 2.0) + xEnd,
                                  (RenderSize.Height / 2.0) - yEnd),
                        new Size(maxWidth / 2.0, maxHeight / 2),
                        0.0,
                        (startAngle - endAngle) > 180,
                        SweepDirection.Clockwise,
                        true,
                        false);
                }

                return geometry;
            }
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;

namespace Controls
{
    /// <summary>
    /// Логика взаимодействия для Slider.xaml
    /// </summary>
    public partial class Slider : UserControl
    {
        public Slider()
        {
            InitializeComponent();
        }

        #region Value
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(double),
            typeof(Slider),
            new PropertyMetadata(0.0, new PropertyChangedCallback(ValueChanged)));

        private static void ValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var slider = obj as Slider;
            slider.ValueChanged();
        }

        private void ValueChanged()
        {
            var ratio = Maximum <= 0 ? 0.0 : Value / Maximum;
            if (ratio < 0)
                ratio = 0;
            if (ratio > 1)
                ratio = 1;
            LeftColumn.Width = new GridLength(ratio, GridUnitType.Star);
            RightColumn.Width = new GridLength(1 - ratio, GridUnitType.Star);
        }
        #endregion

        #region Maximum
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(
            "Maximum",
            typeof(double),
            typeof(Slider),
            new PropertyMetadata(100.0));
        #endregion
    }
}

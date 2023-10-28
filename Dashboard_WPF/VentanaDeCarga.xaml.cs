using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Dashboard_WPF
{
    public partial class VentanaDeCarga : Window
    {
        
        public VentanaDeCarga()
        {
            InitializeComponent();
        }

        private void MOVER(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        
    }
}

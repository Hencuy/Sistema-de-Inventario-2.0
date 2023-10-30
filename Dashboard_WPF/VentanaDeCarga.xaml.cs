using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Windows.Controls;

namespace Dashboard_WPF
{
    public partial class VentanaDeCarga : Window
    {
        private DispatcherTimer timer;
        private double carga = 0;

        public VentanaDeCarga(string nombreUsuario, string apellidosUsuario, string cargoUsuario)
        {
            InitializeComponent();
            txtCargarNombre.Content = nombreUsuario;
            txtCargarApellido.Content = apellidosUsuario;
            txtCargarCargos.Content = cargoUsuario;

            ProgressBarCarga = FindName("ProgressBarCarga") as ProgressBar;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100); // Ajusta el intervalo según tu preferencia
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void MOVER(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            carga += 1;
            if (carga <= ProgressBarCarga.Maximum)
            {
                ProgressBarCarga.Value = carga;
            }
            else
            {
                timer.Stop();
            }
        }
    }
}

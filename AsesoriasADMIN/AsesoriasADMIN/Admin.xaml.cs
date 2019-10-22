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

namespace AsesoriasADMIN
{
    /// <summary>
    /// Lógica de interacción para Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Alta w = new Alta();
            w.Show();
        }

        private void btnBaja_Click(object sender, RoutedEventArgs e)
        {
            int res;
            Usuario u;
            u = new Usuario(Int16.Parse(txtCU.Text));
            res = Usuario.baja(u);
            if (res > 0)
                lblMensaje.Content = "Se dio de baja";
            else
                lblMensaje.Content = "ERROR: No se dio de baja";
        }

        private void btnBusca_Click(object sender, RoutedEventArgs e)
        {
            dgMuestra.ItemsSource = Usuario.busca(txtCU.Text);
        }

        private void btSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

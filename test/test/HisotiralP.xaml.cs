using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ServiceReference1;

namespace Cliente
{
    /// <summary>
    /// Lógica de interacción para HisotiralP.xaml
    /// </summary>
    public partial class HisotiralP : Page
    {
        Service1Client cliente = new Service1Client();
        RemisionEntrada[] remisiones;
        RemisionEntrada remi;
        public HisotiralP()
        {
            InitializeComponent();
            datos();

        }

        private void datos()
        {
            remisiones = cliente.getRemisiones();
            dg.ItemsSource = remisiones;
        }
       

        private void dg_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            remi = dg.SelectedItem as RemisionEntrada;
            if (remi != null)
            {
                if(remi.Estado == 1)
                {
                    
                }
                input1.Text = Convert.ToString(remi.Codigo);
                input2.Text = Convert.ToString(remi.FechaDocumento);
                input3.Text = Convert.ToString(remi.IdProveedor);
                input4.Text = Convert.ToString(remi.IdAlmacen);
                
                switch (remi.Estado)
                {
                    case 1: input5.Text = "REGISTRADO";
                        conf.IsEnabled = true;
                        anu.IsEnabled = true;
                        break;
                    case 2:
                        input5.Text = "CONFIRMADO";
                        conf.IsEnabled = false;
                        anu.IsEnabled = false;
                        break;
                    case 3:
                        input5.Text = "ANULADO";
                        conf.IsEnabled = false;
                        anu.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void conf_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(cliente.updateEstado(remi.Id, 2));
            datos();
        }

        private void anu_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(cliente.updateEstado(remi.Id, 3));
            datos();
        }
    }
}

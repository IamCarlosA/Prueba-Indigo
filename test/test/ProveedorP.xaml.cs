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
    /// Lógica de interacción para ProveedorP.xaml
    /// </summary>
    public partial class ProveedorP : Page
    {
        Proveedor[] proveedores;
        Proveedor prov = new Proveedor();
        Service1Client cliente = new Service1Client();
        public ProveedorP()
        {
            InitializeComponent();
            getdata();
        }

        

        private void getdata()
        {
            proveedores = cliente.GetProveedores();
            dg.ItemsSource = proveedores;
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            prov = dg.SelectedItem as Proveedor;
            if (prov != null)
            {
                update.IsEnabled = true;
                delete.IsEnabled = true;
                input.Text = Convert.ToString(prov.Id);
                input2.Text = prov.Codigo;
                input3.Text = prov.Nombre;
                input4.Text = prov.Direccion;
                input5.Text = prov.Telefono;
            }


        }

        private void reset()
        {
            input.Clear();
            input2.Clear();
            input3.Clear();
            input4.Clear();
            input5.Clear();
            update.IsEnabled = false;
            delete.IsEnabled = false;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            prov = new Proveedor();
            prov.Codigo = input2.Text;
            prov.Nombre = input3.Text;
            prov.Direccion = input4.Text;
            prov.Telefono = input5.Text;


            if (validateData(prov))
            {
                MessageBox.Show(cliente.createProveedor(prov));
                reset();
                getdata();
            }
            else
            {
                MessageBox.Show("falta llenar todos los campos");
            }


        }
        private void update_Click(object sender, RoutedEventArgs e)
        {
            prov = new Proveedor();
            prov.Id = Convert.ToInt32(input.Text);
            prov.Codigo = input2.Text;
            prov.Nombre = input3.Text;
            prov.Direccion = input4.Text;
            prov.Telefono = input5.Text;
            MessageBox.Show(cliente.updateProveedor(prov));
            reset();
            getdata();
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            prov = new Proveedor();
            prov.Id = Convert.ToInt32(input.Text);
            MessageBox.Show(cliente.deleteProveedor(prov.Id));
            reset();
            getdata();
        }

        private bool validateData(Proveedor prov)
        {
            if ((prov.Codigo).Length > 0 && (prov.Nombre).Length > 0 && (prov.Direccion).Length > 0 && (prov.Telefono).Length > 0)
            {
                return true;
            }
            return false;
        }

    }
}

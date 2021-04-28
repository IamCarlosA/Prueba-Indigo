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

namespace test
{

    public partial class AlmacenP : Page
    {
        Almacen[] almacenes;
        Almacen alma = new Almacen();
        Service1Client cliente = new Service1Client();
        public AlmacenP()
        {
            InitializeComponent();
            getdata();
        }

        private void getdata()
        {
            almacenes = cliente.GetAlmacenes();
            dg.ItemsSource = almacenes;
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            alma = dg.SelectedItem as Almacen;
            if (alma != null)
            {
                update.IsEnabled = true;
                delete.IsEnabled = true;
                input.Text = Convert.ToString(alma.Id);
                input2.Text = alma.Codigo;
                input3.Text = alma.Nombre;
            }
            
            
        }

        private void reset()
        {
            input.Clear();
            input2.Clear();
            input3.Clear();
            update.IsEnabled = false;
            delete.IsEnabled = false;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            alma = new Almacen();
            alma.Codigo = input2.Text;
            alma.Nombre = input3.Text;


            if (validateData(alma))
            {
                MessageBox.Show(cliente.createAlmacen(alma));
                reset();
                getdata();
            } else
            {
                MessageBox.Show("falta llenar todos los campos");
            }
            
            
        }
        private void update_Click(object sender, RoutedEventArgs e)
        {
            alma = new Almacen();
            alma.Id = Convert.ToInt32(input.Text);
            alma.Codigo = input2.Text;
            alma.Nombre = input3.Text;
            MessageBox.Show(cliente.updateAlmacen(alma));
            reset();
            getdata();
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            alma = new Almacen();
            alma.Id = Convert.ToInt32(input.Text);
            MessageBox.Show(cliente.deleteAlmacen(alma.Id));
            reset();
            getdata();
        }

        private bool validateData(Almacen alma)
        {
            if((alma.Codigo).Length>0 && (alma.Nombre).Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}

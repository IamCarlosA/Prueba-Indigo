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
    /// <summary>
    /// Lógica de interacción para ProductosP.xaml
    /// </summary>
    public partial class ProductosP : Page
    {
        Producto[] productos;
        Producto prod = new Producto();
        Service1Client cliente = new Service1Client();
        public ProductosP()
        {
            InitializeComponent();
            getdata();
        }


        private void getdata()
        {
            productos = cliente.GetProductos();
            dg.ItemsSource = productos;
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            prod = dg.SelectedItem as Producto;
            if (prod != null)
            {
                update.IsEnabled = true;
                delete.IsEnabled = true;
                input.Text = Convert.ToString(prod.Id);
                input2.Text = prod.Codigo;
                input3.Text = prod.Nombre;
                input4.Text = prod.Descripcion;
                input5.Text = Convert.ToString(prod.PrecioVenta);
                input6.Text = Convert.ToString(prod.StockMinimo);
                input7.Text = Convert.ToString(prod.StockMaximo);
            }


        }

        private void reset()
        {
            input.Clear();
            input2.Clear();
            input3.Clear();
            input4.Clear();
            input5.Clear();
            input6.Clear();
            input7.Clear();
            update.IsEnabled = false;
            delete.IsEnabled = false;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            prod = new Producto();
            prod.Codigo = input2.Text;
            prod.Nombre = input3.Text;
            prod.Descripcion = input4.Text;
            prod.PrecioVenta = Convert.ToInt32(input5.Text);
            prod.StockMinimo = Convert.ToInt32(input6.Text);
            prod.StockMaximo = Convert.ToInt32(input7.Text);


            if (validateData(prod))
            {
                MessageBox.Show(cliente.createProducto(prod));
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
            prod = new Producto();
            prod.Id = Convert.ToInt32(input.Text);
            prod.Codigo = input2.Text;
            prod.Nombre = input3.Text;
            prod.Descripcion = input4.Text;
            prod.PrecioVenta = Convert.ToInt32(input5.Text);
            prod.StockMinimo = Convert.ToInt32(input6.Text);
            prod.StockMaximo = Convert.ToInt32(input7.Text);
            MessageBox.Show(cliente.updateProducto(prod));
            reset();
            getdata();
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            prod = new Producto();
            prod.Id = Convert.ToInt32(input.Text);
            MessageBox.Show(cliente.deleteProducto(prod.Id));
            reset();
            getdata();
        }

        private bool validateData(Producto prov)
        {
            if ((prov.Codigo).Length > 0 && (prov.Nombre).Length > 0 && (prov.Descripcion).Length > 0 && prod.PrecioVenta > 0 && prod.StockMinimo > 0 && prod.StockMaximo > 0)
            {
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para RemisionEntradaP.xaml
    /// </summary>
    public partial class RemisionEntradaP : Page
    {
        Service1Client cliente = new Service1Client();
        Proveedor[] provedores;
        Almacen[] almacenes;
        Producto[] productos;
        List<RemisionEntradaDetalle> rd = new List<RemisionEntradaDetalle>();



        public RemisionEntradaP()
        {
            InitializeComponent();
            getData();
            select3.ItemsSource = productos;
            select1.ItemsSource = provedores;
            select2.ItemsSource = almacenes;
            data();



        }

        private void getData()
        {
            provedores = cliente.GetProveedores();
            almacenes = cliente.GetAlmacenes();
            productos = cliente.GetProductos();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            RemisionEntrada remion = new RemisionEntrada();
            Proveedor pro2 = new Proveedor();
            Almacen alma = new Almacen();

           

            RemisionEntradaDetalle[] tes = new RemisionEntradaDetalle[rd.Count];
            for (int i = 0; i < tes.Length; i++)
            {
                tes[i] = rd[i];
            }
            pro2 = select1.SelectedItem as Proveedor;
            alma = select2.SelectedItem as Almacen;
            DateTime fecha = input2.DisplayDate; 
            remion.List = tes;
            remion.FechaDocumento = fecha;
            remion.Codigo = input1.Text;
            remion.IdProveedor = pro2.Id;
            remion.IdAlmacen = alma.Id;

            MessageBox.Show(cliente.createRemisionEntrada(remion));
        }
  


        private void savepro_Click(object sender, RoutedEventArgs e)
        {
            Producto t = select3.SelectedItem as Producto;
            RemisionEntradaDetalle n = new RemisionEntradaDetalle();
  
            if(t != null && (cantidad.Text).Length > 0)
            {
                
                n.Cantidad = Convert.ToInt32(cantidad.Text);
                n.IdProducto = t.Id;
                rd.Add(n);
                data();
                select3.SelectedIndex = -1;
                cantidad.Clear(); 
            }

        }

        private void data()
        {
            RemisionEntradaDetalle[] tes = new RemisionEntradaDetalle[rd.Count];
            for (int i = 0; i < tes.Length; i++)
            {
                tes[i] = rd[i];
            }
            dg.ItemsSource = tes;
        }

      

        
    }
}

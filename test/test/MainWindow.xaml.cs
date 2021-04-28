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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cliente;
using ServiceReference1;

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        public MainWindow()
        {
            InitializeComponent();
            contenido.NavigationService.Navigate(new RemisionEntradaP());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contenido.NavigationService.Navigate(new AlmacenP());
        }
        private void Button_Click_(object sender, RoutedEventArgs e)
        {
            contenido.NavigationService.Navigate(new HisotiralP());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            contenido.NavigationService.Navigate(new ProveedorP());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            contenido.NavigationService.Navigate(new ProductosP());
        }
        private void Button_Click0(object sender, RoutedEventArgs e)
        {
            contenido.NavigationService.Navigate(new RemisionEntradaP());
        }
    }
}

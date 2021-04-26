using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServidorWCF
{
    [DataContract]
    public class Producto
    {
        private int id;
        private string codigo;
        private string nombre;
        private string descripcion;
        private decimal precioVenta;
        private int stockMinimo;
        private int stockMaximo;

        public Producto()
        {
        }

        public Producto(int id, string codigo, string nombre ,string descripcion, decimal precioVenta, int stockMinimo, int stockMaximo)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.PrecioVenta = precioVenta;
            this.StockMinimo = stockMinimo;
            this.StockMaximo = stockMaximo;
        }
        [DataMember(Order = 1)]
        public int Id { get => id; set => id = value; }
        [DataMember(Order = 2)]
        public string Codigo { get => codigo; set => codigo = value; }
        [DataMember(Order = 3)]
        public string Nombre { get => nombre; set => nombre = value; }
        [DataMember(Order = 4)]
        public string Descripcion { get => descripcion; set => descripcion = value; }
        [DataMember(Order = 5)]
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        [DataMember(Order = 6)]
        public int StockMinimo { get => stockMinimo; set => stockMinimo = value; }
        [DataMember(Order = 7)]
        public int StockMaximo { get => stockMaximo; set => stockMaximo = value; }
        
    }
}
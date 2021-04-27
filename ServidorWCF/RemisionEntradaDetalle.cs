using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServidorWCF
{
    [DataContract]
    public class RemisionEntradaDetalle
    {
        private int id;
        private int idRemisionEntrada;
        private int idProducto;
        private int cantidad;

        public RemisionEntradaDetalle()
        {
        }

        public RemisionEntradaDetalle(int id, int idRemisionEntrada,int idProducto, int cantidad)
        {
            this.Id = id;
            this.IdRemisionEntrada = idRemisionEntrada;
            this.IdProducto = idProducto;
            this.Cantidad = cantidad;
        }

        [DataMember(Order = 1)]
        public int Id { get => id; set => id = value; }
        [DataMember(Order = 2)]
        public int IdRemisionEntrada { get => idRemisionEntrada; set => idRemisionEntrada = value; }
        [DataMember(Order = 3)]
        public int IdProducto { get => idProducto; set => idProducto = value; }
        [DataMember(Order = 4)]
        public int Cantidad { get => cantidad; set => cantidad = value; }
        
    }
}
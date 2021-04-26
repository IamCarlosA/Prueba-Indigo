using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServidorWCF
{
    [DataContract]
    public class Proveedor
    {
        private int id;
        private string codigo;
        private string nombre;
        private string direccion;
        private string telefono;

        public Proveedor()
        {
        }

        public Proveedor( int id, string codigo, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.codigo = codigo;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }
        [DataMember(Order = 1)]
        public int Id { get => id; set => id = value; }
        [DataMember(Order = 2)]
        public string Codigo { get => codigo; set => codigo = value; }
        [DataMember(Order = 3)]
        public string Nombre { get => nombre; set => nombre = value; }
        [DataMember(Order = 4)]
        public string Direccion { get => direccion; set => direccion = value; }
        [DataMember(Order = 5)]
        public string Telefono { get => telefono; set => telefono = value; }
        
    }
}
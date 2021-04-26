using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServidorWCF
{
    [DataContract]
    public class Almacen
    {
        private int id;
        private string codigo;
        private string nombre;

        public Almacen()
        {
        }

        public Almacen(int id, string codigo, string nombre)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.Nombre = nombre;
        }

        [DataMember(Order = 1)]
        public int Id { get => id; set => id = value; }
        [DataMember(Order = 2)]
        public string Codigo { get => codigo; set => codigo = value; }
        [DataMember(Order = 3)]
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
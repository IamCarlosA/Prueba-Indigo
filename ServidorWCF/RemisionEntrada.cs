using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServidorWCF
{
    [DataContract]
    public class RemisionEntrada
    {
        private int id;
        private string codigo;
        private DateTime fechaDocumento;
        private int idProveedor;
        private int idAlmacen;
        private int estado;
        private List<RemisionEntradaDetalle> list;

        public RemisionEntrada()
        {
        }

        public RemisionEntrada(int id, string codigo, DateTime fechaDocumento, int idProveedor, int idAlmacen, int estado, List<RemisionEntradaDetalle> list)
        {
            this.Id = id;
            this.Codigo = codigo;
            this.FechaDocumento = fechaDocumento;
            this.IdProveedor = idProveedor;
            this.IdAlmacen = idAlmacen;
            this.Estado = estado;
            this.List = list;
        }

        [DataMember(Order = 1)]
        public int Id { get => id; set => id = value; }
        [DataMember(Order = 2)]
        public string Codigo { get => codigo; set => codigo = value; }
        [DataMember(Order = 3)]
        public DateTime FechaDocumento { get => fechaDocumento; set => fechaDocumento = value; }
        [DataMember(Order = 4)]
        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
        [DataMember(Order = 5)]
        public int IdAlmacen { get => idAlmacen; set => idAlmacen = value; }
        [DataMember(Order = 6)]
        public int Estado { get => estado; set => estado = value; }
        [DataMember(Order = 7)]
        public List<RemisionEntradaDetalle> List { get => list; set => list = value; }
    }
}
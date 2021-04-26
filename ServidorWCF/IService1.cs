using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServidorWCF
{
    
    [ServiceContract]
    public interface IService1
    {
        //--------------------CRUD Proveedor-------------------
        [OperationContract]
        Proveedor getProveedor(int id);
        [OperationContract]
        string createProveedor(Proveedor proveedor);
        [OperationContract]
        string updateProveedor(Proveedor proveedor);
        [OperationContract]
        string deleteProveedor(int id);
        [OperationContract]
        List<Proveedor> GetProveedores();

        //---------------------CRUD Almacen--------------------
        [OperationContract]
        Almacen getAlmacen(int id);
        [OperationContract]
        string createAlmacen(Almacen almacen);
        [OperationContract]
        string updateAlmacen(Almacen almacen);
        [OperationContract]
        string deleteAlmacen(int id);
        [OperationContract]
        List<Almacen> GetAlmacenes();

        //---------------------CRUD Productos--------------------
        [OperationContract]
        Producto getProducto(int id);
        [OperationContract]
        string createProducto(Producto producto);
        [OperationContract]
        string updateProducto(Producto producto);
        [OperationContract]
        string deleteProducto(int id);
        [OperationContract]
        List<Producto> GetProductos();


    }


   
}

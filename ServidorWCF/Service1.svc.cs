using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient; //base de datos

namespace ServidorWCF
{
    public class Service1 : IService1
    {
        static string conexionString = "Server=DESKTOP-0UNV6LG;Database=MER;Trusted_Connection=True;";
        
        // -------------- imple Proveedores------------------
        public string createProveedor(Proveedor proveedor)
        {
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Proveedor(Codigo, Nombre, Direccion, Telefono) VALUES(@Codigo, @Nombre, @Direccion, @Telefono)", conexion);
            cmd.Parameters.AddWithValue("@Codigo", proveedor.Codigo);
            cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
            cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
            cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
            try
            {
                cmd.ExecuteNonQuery();
                return "Proveedor: "+ proveedor.Nombre+" creado correctamente";
            }
            catch (Exception e)
            {
                return (e is SqlException) ? "Codigo ya utilizado" : "Error interno del server";
            }
            finally
            {
                conexion.Close();
            }
        }

        public string deleteProveedor(int id)
        {
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Proveedor WHERE Id = @Id", conexion);
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {
                return (cmd.ExecuteNonQuery() == 1) ? "Proveedor: " + id + " Elimonado correctamente" : "Proveedor: " + id + " No existe";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error interno del server";
            }
            finally
            {
                conexion.Close();
            }
        }

        public Proveedor getProveedor(int id)
        {
            Proveedor proveedor = new Proveedor();
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Proveedor WHERE Id = @Id", conexion);
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        proveedor.Id = reader.GetInt32(0);
                        proveedor.Codigo = reader.GetString(1);
                        proveedor.Nombre = reader.GetString(2);
                        proveedor.Direccion = reader.GetString(3);
                        proveedor.Telefono = reader.GetString(4);
                    }
                }
                reader.Close();
                return proveedor;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return proveedor;
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Proveedor> GetProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Proveedor", conexion);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        proveedores.Add(new Proveedor(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4)));
                    }
                }
                reader.Close();
                return proveedores;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return proveedores;
            }
            finally
            {
                conexion.Close();
            }
        }

        public string updateProveedor(Proveedor proveedor)
        {
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Proveedor SET Codigo = @Codigo, Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono WHERE Id = @Id", conexion);
            cmd.Parameters.AddWithValue("@Id", proveedor.Id);
            cmd.Parameters.AddWithValue("@Codigo", proveedor.Codigo);
            cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
            cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
            cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
            try
            {
                return (cmd.ExecuteNonQuery() == 1) ? "Proveedor: " + proveedor.Nombre + " actualizado correctamente" : "Proveedor: " + proveedor.Nombre + " No existe";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error interno del server";
            }
            finally
            {
                conexion.Close();
            }
        }

        // --------------------------- impl Almacen --------------------------

        public string createAlmacen(Almacen almacen)
        {
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Almacen(Codigo, Nombre) VALUES(@Codigo, @Nombre)", conexion);
            cmd.Parameters.AddWithValue("@Codigo", almacen.Codigo);
            cmd.Parameters.AddWithValue("@Nombre", almacen.Nombre);
            try
            {
                cmd.ExecuteNonQuery();
                return "Almacen: " + almacen.Nombre + " creado correctamente";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return (e is SqlException) ? "Codigo ya utilizado" : "Error interno del server";
            }
            finally
            {
                conexion.Close();
            }
        }

        public string deleteAlmacen(int id)
        {
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Almacen WHERE Id = @Id", conexion);
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {
                return (cmd.ExecuteNonQuery() == 1) ? "Almacen: " + id + " Elimonado correctamente" : "Almacen: " + id + " No existe";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error interno del server";
            }
            finally
            {
                conexion.Close();
            }
        }

        public Almacen getAlmacen(int id)
        {
            Almacen almacen = new Almacen();
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Almacen WHERE Id = @Id", conexion);
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {   
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        almacen.Id = reader.GetInt32(0);
                        almacen.Codigo = reader.GetString(1);
                        almacen.Nombre = reader.GetString(2);
                    }
                }
                reader.Close();
                return almacen;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return almacen;
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Almacen> GetAlmacenes()
        {
            List<Almacen> almacenes = new List<Almacen>();
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Almacen", conexion);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        almacenes.Add(new Almacen(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                    }
                }
                reader.Close();
                return almacenes;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return almacenes;
            }
            finally
            {
                conexion.Close();
            }
        }

        public string updateAlmacen(Almacen almacen)
        {
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Almacen SET Codigo = @Codigo, Nombre = @Nombre WHERE Id = @Id", conexion);
            cmd.Parameters.AddWithValue("@Id", almacen.Id);
            cmd.Parameters.AddWithValue("@Codigo", almacen.Codigo);
            cmd.Parameters.AddWithValue("@Nombre", almacen.Nombre);
            try
            {
                return (cmd.ExecuteNonQuery() == 1) ? "Almacen: " + almacen.Nombre + " actualizado correctamente" : "Almacen: " + almacen.Nombre + " No existe";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error interno del server";
            }
            finally
            {
                conexion.Close();
            }
        }

        // -------------- imple Productos------------------
        public string createProducto(Producto producto)
        {
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Producto(Codigo, Nombre, Descripcion, PrecioVenta, StockMinimo, StockMaximo) VALUES(@Codigo, @Nombre, @Descripcion, @PrecioVenta, @StockMinimo, @StockMaximo)", conexion);
            cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
            cmd.Parameters.AddWithValue("@StockMinimo", producto.StockMinimo);
            cmd.Parameters.AddWithValue("@StockMaximo", producto.StockMaximo);
            try
            {
                cmd.ExecuteNonQuery();
                return "Producto: " + producto.Nombre + " creado correctamente";
            }
            catch (Exception e)
            {
                return (e is SqlException) ? "Codigo ya utilizado" : "Error interno del server";
            }
            finally
            {
                conexion.Close();
            }
        }

        public string deleteProducto(int id)
        {
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Producto WHERE Id = @Id", conexion);
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {
                return (cmd.ExecuteNonQuery() == 1) ? "Producto: " + id + " Elimonado correctamente" : "Producto: " + id + " No existe";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error interno del server";
            }
            finally
            {
                conexion.Close();
            }
        }

        public Producto getProducto(int id)
        {
            Producto producto = new Producto();
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Producto WHERE Id = @Id", conexion);
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        producto.Id = reader.GetInt32(0);
                        producto.Codigo = reader.GetString(1);
                        producto.Nombre = reader.GetString(2);
                        producto.Descripcion = reader.GetString(3);
                        producto.PrecioVenta = reader.GetDecimal(4);
                        producto.StockMinimo = reader.GetInt32(5);
                        producto.StockMaximo = reader.GetInt32(6);
                    }
                }
                reader.Close();
                return producto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return producto;
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Producto", conexion);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDecimal(4), reader.GetInt32(5), reader.GetInt32(6)));
                    }
                }
                reader.Close();
                return productos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return productos;
            }
            finally
            {
                conexion.Close();
            }
        }

        public string updateProducto(Producto producto)
        {
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Producto SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, PrecioVenta = @PrecioVenta, StockMinimo = @StockMinimo, StockMaximo = @StockMaximo WHERE Id = @Id", conexion);
            cmd.Parameters.AddWithValue("@Id", producto.Id);
            cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
            cmd.Parameters.AddWithValue("@StockMinimo", producto.StockMinimo);
            cmd.Parameters.AddWithValue("@StockMaximo", producto.StockMaximo);
            try
            {
                return (cmd.ExecuteNonQuery() == 1) ? "Producto: " + producto.Nombre + " actualizado correctamente" : "Producto: " + producto.Nombre + " No existe";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error interno del server";
            }
            finally
            {
                conexion.Close();
            }
        }


        //-------------------------- impl remision------------------------

        public string createRemisionEntrada(RemisionEntrada remision)
        {
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO RemisionEntrada(Codigo, FechaDocumento, IdProveedor, IdAlmacen, Estado) VALUES(@Codigo, @FechaDocumento, @IdProveedor, @IdAlmacen, @Estado); SELECT SCOPE_IDENTITY();", conexion);
            cmd.Parameters.AddWithValue("@Codigo", remision.Codigo);
            cmd.Parameters.AddWithValue("@FechaDocumento", remision.FechaDocumento);
            cmd.Parameters.AddWithValue("@IdProveedor", remision.IdProveedor);
            cmd.Parameters.AddWithValue("@IdAlmacen", remision.IdAlmacen);
            cmd.Parameters.AddWithValue("@Estado", 1);
            try
            {
                int idRemisionReturn;
                object idRemision = cmd.ExecuteScalar();
                if (idRemision != null)
                {
                    int.TryParse(idRemision.ToString(), out idRemisionReturn);

                    //ingresando detalles de remision

                    if (remision.List.Count > 0)
                    {

                        var hashset = new HashSet<int>();
                        foreach (var re in remision.List)
                        {
                            if (!hashset.Add(re.IdProducto))
                            {
                                return "Productos repetidos";

                            }
                        }
                        foreach (RemisionEntradaDetalle detalle in remision.List)
                        {
                            SqlCommand detalles = new SqlCommand("INSERT INTO RemisonEntradaDetalle ( IdRemisionEntrada, IdProducto, Cantidad) VALUES(@IdRemisionEntrada, @IdProducto, @Cantidad);", conexion);
                            detalles.Parameters.AddWithValue("@IdRemisionEntrada", idRemisionReturn);
                            detalles.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                            detalles.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                            detalles.ExecuteNonQuery();
                        }

                        return "Remision creada correctamente";
                    }else
                    {
                        return "Remision sin productos";
                    }

                }
                return "error al crear remision";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error interno del server";
            }
            finally
            {
                conexion.Close();
            }
        }

        public string updateEstado(int idRemision, int accion)
        {
            
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM RemisionEntrada WHERE Id = @Id", conexion);
            cmd.Parameters.AddWithValue("@Id", idRemision);

            try
            {
                RemisionEntrada remision = new RemisionEntrada();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        remision.Id = reader.GetInt32(0);
                        remision.Codigo = reader.GetString(1);
                        remision.FechaDocumento = reader.GetDateTime(2);
                        remision.IdProveedor = reader.GetInt32(3);
                        remision.IdAlmacen = reader.GetInt32(4);
                        remision.Estado = reader.GetInt32(5);
                    }

                    if (remision.Estado == 1)
                    {
                        List<RemisionEntradaDetalle> productos = new List<RemisionEntradaDetalle>();
                        productos= EntradaDetalle(idRemision);
                        if (productos.Count > 0)
                        {
                            switch (accion)
                            {
                                case 2:
                                    string num="";
                                    foreach (RemisionEntradaDetalle producto in productos)
                                    {
                                        num = inventario(remision, producto);
                                    }
                                    return "Remision Confirmada :"+ num;

                                case 3:
                                    SqlConnection conexion2 = new SqlConnection(conexionString);
                                    conexion2.Open();
                                    SqlCommand cmd2 = new SqlCommand("UPDATE RemisionEntrada SET Estado = 3  WHERE Id = @Id", conexion2);
                                    cmd2.Parameters.AddWithValue("@Id", remision.Id);
                                    cmd2.ExecuteNonQuery();

                                    return "Remision Anulada";
                                default:
                                    return "Accion no valida";
                            }
                        }
                        else
                        {
                            return "Remision sin productos";
                        }
                    }
                    return "No tiene permisos";
                }
                return "No encontro remision";
            }
            catch
            {
                return "error";
            }
            finally
            {
                conexion.Close();
                
            }
        }

        public List<RemisionEntradaDetalle> EntradaDetalle(int remision)
        {
            List<RemisionEntradaDetalle> productos = new List<RemisionEntradaDetalle>();
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM RemisonEntradaDetalle WHERE IdRemisionEntrada = @IdRemisionEntrada", conexion);
            cmd.Parameters.AddWithValue("@IdRemisionEntrada", remision);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productos.Add(new RemisionEntradaDetalle(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3)));
                    }
                }
                reader.Close();
                return productos;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }
            
        }

        public string inventario(RemisionEntrada remi, RemisionEntradaDetalle deta)
        {
            SqlConnection conexion = new SqlConnection(conexionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM InventarioFisico WHERE IdAlmacen = @IdAlmacen AND IdProducto = @IdProducto", conexion);
            cmd.Parameters.AddWithValue("@IdAlmacen", remi.IdAlmacen);
            cmd.Parameters.AddWithValue("@IdProducto", deta.IdProducto);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    SqlConnection conexion3 = new SqlConnection(conexionString);
                    conexion3.Open();
                    SqlCommand cmd3 = new SqlCommand("UPDATE InventarioFisico SET Cantidad = Cantidad + @Cantidad  WHERE IdAlmacen = @IdAlmacen AND IdProducto = @IdProducto; UPDATE RemisionEntrada SET Estado = 2  WHERE Id = @Id", conexion3);
                    cmd3.Parameters.AddWithValue("@IdAlmacen", remi.IdAlmacen);
                    cmd3.Parameters.AddWithValue("@IdProducto", deta.IdProducto);
                    cmd3.Parameters.AddWithValue("@Cantidad", deta.Cantidad);
                    cmd3.Parameters.AddWithValue("@Id", remi.Id);
                    cmd3.ExecuteNonQuery();
                    return "Inventario Actualizado";
                } else
                {
                    SqlConnection conexion2 = new SqlConnection(conexionString);
                    conexion2.Open();
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO InventarioFisico ( IdAlmacen, IdProducto, Cantidad) VALUES(@IdAlmacen, @IdProducto, @Cantidad); UPDATE RemisionEntrada SET Estado = 2  WHERE Id = @Id", conexion2);
                    cmd2.Parameters.AddWithValue("@IdAlmacen", remi.IdAlmacen);
                    cmd2.Parameters.AddWithValue("@IdProducto", deta.IdProducto);
                    cmd2.Parameters.AddWithValue("@Cantidad", deta.Cantidad);
                    cmd2.Parameters.AddWithValue("@Id", remi.Id);
                    cmd2.ExecuteNonQuery();
                    return "Inventario comfirmado y guardado";
                }
   
            }
            catch (Exception e)
            {

                throw e;
            } finally
            {
                conexion.Close();
            }
        }
    }
}

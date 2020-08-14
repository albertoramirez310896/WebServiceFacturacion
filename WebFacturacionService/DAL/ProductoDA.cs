using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFacturacionService.BussinessObjectsLayer;
using System.Data;
using System.Data.SqlClient;

namespace WebFacturacionService.DataAccessLayer
{
    public class ProductoDA
    {
        public static SqlConnection conn;
        #region Methods

        public static List<Producto> SeleccionaProductos(Int32? Id_Producto)
        {
            List<Producto> productoList = new List<Producto>();

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ConsultaProductos";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdProducto = new SqlParameter();
                parIdProducto.ParameterName = "@Id_Producto";
                parIdProducto.DbType = DbType.Int32;
                parIdProducto.Direction = ParameterDirection.Input;
                parIdProducto.Value = Id_Producto;
                cmd.Parameters.Add(parIdProducto);

                conn.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        //Estos valores deben ser deacuerdo a la base de datos
                        Producto dte = new Producto();
                        dte.id_Producto = Convert.ToInt32(dr["Id_Producto"]);
                        dte.DescripcionProducto = Convert.ToString(dr["Descripcion_Prod"]);
                        dte.PrecioProd = Convert.ToDouble(dr["Precio_Prod"]);
                        dte.FechaCaducidadProd = Convert.ToDateTime(dr["FechaCaducidad_Prod"]);
                        dte.CodigoBarras_Prod = Convert.ToString(dr["CodigBarras_Prod"]);
                        dte.Proveedor_Prod = Convert.ToString(dr["Proveedor_Prod"]);

                        productoList.Add(dte);
                    }
                }

                dr.Close();
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                conn.Close();
            }

            return productoList;
        }

        public static Int32 InsertarProducto(Producto pdo)
        {
            Int32 filasAfectadas = 0;

            try
            {        
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_AltaProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdProducto = new SqlParameter();
                parIdProducto.ParameterName = "@Id_Producto";
                parIdProducto.DbType = DbType.Int32;
                parIdProducto.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdProducto);

                SqlParameter parDescripcionProd = new SqlParameter();
                parDescripcionProd.ParameterName = "@Descripcion_Prod";
                parDescripcionProd.DbType = DbType.String;
                parDescripcionProd.Direction = ParameterDirection.Input;
                parDescripcionProd.Value = pdo.DescripcionProducto;
                cmd.Parameters.Add(parDescripcionProd);

                SqlParameter parPrecioProd = new SqlParameter();
                parPrecioProd.ParameterName = "@Precio_Prod";
                parPrecioProd.DbType = DbType.Double;
                parPrecioProd.Direction = ParameterDirection.Input;
                parPrecioProd.Value = pdo.PrecioProd;
                cmd.Parameters.Add(parPrecioProd);

                SqlParameter parFechaCaducidadProd = new SqlParameter();
                parFechaCaducidadProd.ParameterName = "@FechaCaducidad_Prod";
                parFechaCaducidadProd.DbType = DbType.DateTime;
                parFechaCaducidadProd.Direction = ParameterDirection.Input;
                parFechaCaducidadProd.Value = pdo.FechaCaducidadProd;
                cmd.Parameters.Add(parFechaCaducidadProd);

                SqlParameter parCodigoBarrasProd = new SqlParameter();
                parCodigoBarrasProd.ParameterName = "@CodigoBarras_Prod";
                parCodigoBarrasProd.DbType = DbType.String;
                parCodigoBarrasProd.Direction = ParameterDirection.Input;
                parCodigoBarrasProd.Value = pdo.FechaCaducidadProd;
                cmd.Parameters.Add(parCodigoBarrasProd);

                SqlParameter parProveedorProd = new SqlParameter();
                parProveedorProd.ParameterName = "@Proveedor_Prod";
                parProveedorProd.DbType = DbType.String;
                parProveedorProd.Direction = ParameterDirection.Input;
                parProveedorProd.Value = pdo.Proveedor_Prod;
                cmd.Parameters.Add(parProveedorProd);

                conn.Open();

                filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas != 0)
                {
                    pdo.id_Producto = Convert.ToInt32(cmd.Parameters["@Id_Producto"].Value);
                }

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                conn.Close();
            }

            return filasAfectadas;
        }

        public static Int32 ActualizaProducto(Producto prod)
        {
            Int32 filasAfectadas = 0;

            try
            {      
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ActualizaProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdProducto = new SqlParameter();
                parIdProducto.ParameterName = "@id_Prod";
                parIdProducto.DbType = DbType.Int32;
                parIdProducto.Direction = ParameterDirection.Input;
                parIdProducto.Value = prod.id_Producto;
                cmd.Parameters.Add(parIdProducto);

                SqlParameter parDescripcionProd = new SqlParameter();
                parDescripcionProd.ParameterName = "@Descripcion_Prod";
                parDescripcionProd.DbType = DbType.String;
                parDescripcionProd.Direction = ParameterDirection.Input;
                parDescripcionProd.Value = prod.DescripcionProducto;
                cmd.Parameters.Add(parDescripcionProd);

                SqlParameter parPrecioProd = new SqlParameter();
                parPrecioProd.ParameterName = "@Precio_Prod";
                parPrecioProd.DbType = DbType.Double;
                parPrecioProd.Direction = ParameterDirection.Input;
                parPrecioProd.Value = prod.PrecioProd;
                cmd.Parameters.Add(parPrecioProd);

                SqlParameter parFechaCaducidadProd = new SqlParameter();
                parFechaCaducidadProd.ParameterName = "@FechaCaducidad_Prod";
                parFechaCaducidadProd.DbType = DbType.DateTime;
                parFechaCaducidadProd.Direction = ParameterDirection.Input;
                parFechaCaducidadProd.Value = prod.FechaCaducidadProd;
                cmd.Parameters.Add(parFechaCaducidadProd);

                SqlParameter parCodigoBarrasProd = new SqlParameter();
                parCodigoBarrasProd.ParameterName = "@CodigoBarras_Prod";
                parCodigoBarrasProd.DbType = DbType.String;
                parCodigoBarrasProd.Direction = ParameterDirection.Input;
                parCodigoBarrasProd.Value = prod.CodigoBarras_Prod;
                cmd.Parameters.Add(parCodigoBarrasProd);

                SqlParameter parProveedorProd = new SqlParameter();
                parProveedorProd.ParameterName = "@Proveedor_Prod";
                parProveedorProd.DbType = DbType.String;
                parProveedorProd.Direction = ParameterDirection.Input;
                parProveedorProd.Value = prod.Proveedor_Prod;
                cmd.Parameters.Add(parProveedorProd);

                conn.Open();

                filasAfectadas = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                conn.Close();
            }

            return filasAfectadas;
        }

        public static Int32 EliminaProducto(Int32 Id_Producto)
        {
            Int32 filasAfectadas = 0;

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_BajaProducto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdProd = new SqlParameter();
                parIdProd.ParameterName = "@id_Prod";
                parIdProd.DbType = DbType.Int32;
                parIdProd.Direction = ParameterDirection.Input;
                parIdProd.Value = Id_Producto;
                cmd.Parameters.Add(parIdProd);

                conn.Open();

                filasAfectadas = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                conn.Close();
            }

            return filasAfectadas;
        }
        #endregion
    }
}
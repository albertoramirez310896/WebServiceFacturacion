using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFacturacionService.BussinessObjectsLayer;
using System.Data;
using System.Data.SqlClient;

namespace WebFacturacionService.DataAccessLayer
{

    public static class RelPrPrSuDA
        {

        public static SqlConnection conn;
        #region Methods

        public static List<RelPrPrSu> SeleccionaRelPrPrSu(Int32? id_Producto, Int32? id_Proveedor, Int32? id_Sucursal)
        {
            List<RelPrPrSu> relprprsuList = new List<RelPrPrSu>();

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_Consulta_RelPrPrSu";  // Consulta
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdProducto = new SqlParameter();
                parIdProducto.ParameterName = "@Id_Producto";
                parIdProducto.DbType = DbType.Int32;
                parIdProducto.Direction = ParameterDirection.Input;
                parIdProducto.Value = id_Producto;
                cmd.Parameters.Add(parIdProducto);                

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@ID_PROVEEDOR";
                parIdProveedor.DbType = DbType.Int32;
                parIdProveedor.Direction = ParameterDirection.Input;
                parIdProveedor.Value = id_Proveedor;
                cmd.Parameters.Add(parIdProveedor);             

                SqlParameter parIdSucursal = new SqlParameter();
                parIdSucursal.ParameterName = "@ID_SUCURSAL";
                parIdSucursal.DbType = DbType.Int32;
                parIdSucursal.Direction = ParameterDirection.Input;
                parIdSucursal.Value = id_Sucursal;
                cmd.Parameters.Add(parIdSucursal);                             

                conn.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        //Estos valores deben ser deacuerdo a la base de datos
                        RelPrPrSu relpps = new RelPrPrSu();
                        relpps.id_RelPrPrSu = Convert.ToInt32(dr["ID_RELACION"]);
                        relpps.Producto = Convert.ToString(dr["NOMBRE_PRODUCTO"]);
                        relpps.Proveedor = Convert.ToString(dr["NOMBRE_PROVEEDOR"]);
                        relpps.Sucursal = Convert.ToString(dr["NOMBRE_SUCURSAL"]);
                        relpps.id_Producto = Convert.ToInt32(dr["ID_PRODUCTO"]);
                        relpps.id_Proveedor = Convert.ToInt32(dr["ID_PROVEEDOR"]);
                        relpps.id_Sucursal = Convert.ToInt32(dr["ID_SUCURSAL"]);


                        relpps.Precio_Unitario = Convert.ToDouble(dr["Precio_Unitario"]);

                        relprprsuList.Add(relpps);
                    }
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                conn.Close();
            }

            return relprprsuList;
        }

        // Listo

        public static Int32 InsertarRelPrPrSu(RelPrPrSu relpps)
        {
            Int32 filasAfectadas = 0;

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_Alta_RelPrPrSu";   // Alta
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdrelpps = new SqlParameter();
                parIdrelpps.ParameterName = "@Id_RelPrPrSu";
                parIdrelpps.DbType = DbType.Int32;
                parIdrelpps.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdrelpps);

                SqlParameter parIdProducto = new SqlParameter();
                parIdProducto.ParameterName = "@ID_PRODUCTO";
                parIdProducto.DbType = DbType.Int32;
                parIdProducto.Direction = ParameterDirection.Input;
                parIdProducto.Value = relpps.id_Producto;
                cmd.Parameters.Add(parIdProducto);

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@ID_PROVEEDOR";
                parIdProveedor.DbType = DbType.Int32;
                parIdProveedor.Direction = ParameterDirection.Input;
                parIdProveedor.Value = relpps.id_Proveedor;
                cmd.Parameters.Add(parIdProveedor);

                SqlParameter parIdSucursal = new SqlParameter();
                parIdSucursal.ParameterName = "@ID_SUCURSAL";
                parIdSucursal.DbType = DbType.Int32;
                parIdSucursal.Direction = ParameterDirection.Input;
                parIdSucursal.Value = relpps.id_Sucursal;
                cmd.Parameters.Add(parIdSucursal);

                SqlParameter parPrecioUnitario = new SqlParameter();
                parPrecioUnitario.ParameterName = "@Precio_Unitario";
                parPrecioUnitario.DbType = DbType.Double;
                parPrecioUnitario.Direction = ParameterDirection.Input;
                parPrecioUnitario.Value = relpps.Precio_Unitario;
                cmd.Parameters.Add(parPrecioUnitario);

                conn.Open();

                filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas != 0)
                {
                    relpps.id_RelPrPrSu = Convert.ToInt32(cmd.Parameters["@Id_RelPrPrSu"].Value);
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
        // Listo
        public static Int32 ActualizaRelPrPrSu(RelPrPrSu relpps)
        {
            Int32 filasAfectadas = 0;

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_Actualizar_RelPrPrSu";   // Actulizar
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdrelpps = new SqlParameter();
                parIdrelpps.ParameterName = "@Id_RelPrPrSu";
                parIdrelpps.DbType = DbType.Int32;
                parIdrelpps.Direction = ParameterDirection.Input;
                parIdrelpps.Value = relpps.id_RelPrPrSu;
                cmd.Parameters.Add(parIdrelpps);

                SqlParameter parIdProducto = new SqlParameter();
                parIdProducto.ParameterName = "@Id_Producto";
                parIdProducto.DbType = DbType.Int32;
                parIdProducto.Direction = ParameterDirection.Input;
                parIdProducto.Value = relpps.id_Producto;
                cmd.Parameters.Add(parIdProducto);

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@ID_PROVEEDOR";
                parIdProveedor.DbType = DbType.Int32;
                parIdProveedor.Direction = ParameterDirection.Input;
                parIdProveedor.Value = relpps.id_Proveedor;
                cmd.Parameters.Add(parIdProveedor);

                SqlParameter parIdSucursal = new SqlParameter();
                parIdSucursal.ParameterName = "@ID_SUCURSAL";
                parIdSucursal.DbType = DbType.Int32;
                parIdSucursal.Direction = ParameterDirection.Input;
                parIdSucursal.Value = relpps.id_Sucursal;
                cmd.Parameters.Add(parIdSucursal);

                SqlParameter parPrecioUnitario = new SqlParameter();
                parPrecioUnitario.ParameterName = "@Precio_Unitario";
                parPrecioUnitario.DbType = DbType.Double;
                parPrecioUnitario.Direction = ParameterDirection.Input;
                parPrecioUnitario.Value = relpps.Precio_Unitario;
                cmd.Parameters.Add(parPrecioUnitario);

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

        public static Int32 EliminaRelPrPrSu(Int32 id_RelPrPrSu)
        {
            Int32 filasAfectadas = 0;

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_Baja_RelPrPrSu";   // Baja
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdrelpps = new SqlParameter();
                parIdrelpps.ParameterName = "@Id_RelPrPrSu";
                parIdrelpps.DbType = DbType.Int32;
                parIdrelpps.Direction = ParameterDirection.Input;
                parIdrelpps.Value = id_RelPrPrSu;
                cmd.Parameters.Add(parIdrelpps);

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
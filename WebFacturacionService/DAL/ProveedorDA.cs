using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFacturacionService.BussinessObjectsLayer;
using System.Data;
using System.Data.SqlClient;

namespace WebFacturacionService.DataAccessLayer
{

    public static class ProveedorDA
    {

        public static SqlConnection conn;
        #region Methods

        public static List<Proveedor> SeleccionaProveedor(Int32? id_Proveedor, String Nombre)
        {
            List<Proveedor> proveedorList = new List<Proveedor>();

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ConsultaProveedores";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@ID_PROVEEDOR";
                parIdProveedor.DbType = DbType.Int32;
                parIdProveedor.Direction = ParameterDirection.Input;
                parIdProveedor.Value = id_Proveedor;
                cmd.Parameters.Add(parIdProveedor);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@NOMBRE";
                parNombre.DbType = DbType.String;
                parNombre.Direction = ParameterDirection.Input;
                parNombre.Value = String.IsNullOrEmpty(Nombre) ? null : Nombre;
                cmd.Parameters.Add(parNombre);

                conn.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        //Estos valores deben ser deacuerdo a la base de datos
                        Proveedor proveedor = new Proveedor();
                        proveedor.id_Proveedor = Convert.ToInt32(dr["ID_PROVEEDOR"]);
                        proveedor.Nombre = Convert.ToString(dr["NOMBRE"]);
                        proveedor.Direccion = Convert.ToString(dr["DIRECCION"]);
                        proveedor.NombreCiudad = Convert.ToString(dr["NOM_CIUDAD"]);
                        proveedor.NombreEstado = Convert.ToString(dr["NOM_ESTADO"]);
                        proveedor.Telefono = Convert.ToString(dr["TELEFONO"]);
                        proveedor.Email = Convert.ToString(dr["EMAIL"]);
                        proveedor.CP = Convert.ToString(dr["CP"]);
                        proveedor.RFC = Convert.ToString(dr["RFC"]);
                        proveedor.id_Ciudad = Convert.ToInt32(dr["ID_CIUDAD"]);

                        proveedorList.Add(proveedor);
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

            return proveedorList;
        }

        public static Int32 InsertarProveedor(Proveedor proveedor)
        {
            Int32 filasAfectadas = 0;

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_AltaProveedor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@ID_PROVEEDOR";
                parIdProveedor.DbType = DbType.Int32;
                parIdProveedor.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdProveedor);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@NOMBRE";
                parNombre.DbType = DbType.String;
                parNombre.Direction = ParameterDirection.Input;
                parNombre.Value = proveedor.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@DIRECCION";
                parDireccion.DbType = DbType.String;
                parDireccion.Direction = ParameterDirection.Input;
                parDireccion.Value = proveedor.Direccion;
                cmd.Parameters.Add(parDireccion);

                SqlParameter parIdCiudad = new SqlParameter();
                parIdCiudad.ParameterName = "@ID_CIUDAD";
                parIdCiudad.DbType = DbType.Int32;
                parIdCiudad.Direction = ParameterDirection.Input;
                parIdCiudad.Value = proveedor.id_Ciudad;
                cmd.Parameters.Add(parIdCiudad);

                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@TELEFONO";
                parTelefono.DbType = DbType.String;
                parTelefono.Direction = ParameterDirection.Input;
                parTelefono.Value = proveedor.Telefono;
                cmd.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@EMAIL";
                parEmail.DbType = DbType.String;
                parEmail.Direction = ParameterDirection.Input;
                parEmail.Value = proveedor.Email;
                cmd.Parameters.Add(parEmail);

                SqlParameter parCP = new SqlParameter();
                parCP.ParameterName = "@CP";
                parCP.DbType = DbType.String;
                parCP.Direction = ParameterDirection.Input;
                parCP.Value = proveedor.CP;
                cmd.Parameters.Add(parCP);

                SqlParameter parRFC = new SqlParameter();
                parRFC.ParameterName = "@RFC";
                parRFC.DbType = DbType.String;
                parRFC.Direction = ParameterDirection.Input;
                parRFC.Value = proveedor.RFC;
                cmd.Parameters.Add(parRFC);

                conn.Open();

                filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas != 0)
                {
                    proveedor.id_Proveedor = Convert.ToInt32(cmd.Parameters["@ID_Proveedor"].Value);
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

        public static Int32 ActualizaProveedor(Proveedor proveedor)
        {
            Int32 filasAfectadas = 0;

            try
            {                
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ActualizaProveedor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@ID_PROVEEDOR";
                parIdProveedor.DbType = DbType.Int32;
                parIdProveedor.Direction = ParameterDirection.Input;
                parIdProveedor.Value = proveedor.id_Proveedor;
                cmd.Parameters.Add(parIdProveedor);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@NOMBRE";
                parNombre.DbType = DbType.String;
                parNombre.Direction = ParameterDirection.Input;
                parNombre.Value = proveedor.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@DIRECCION";
                parDireccion.DbType = DbType.String;
                parDireccion.Direction = ParameterDirection.Input;
                parDireccion.Value = proveedor.Direccion;
                cmd.Parameters.Add(parDireccion);

                SqlParameter parIdCiudad = new SqlParameter();
                parIdCiudad.ParameterName = "@ID_CIUDAD";
                parIdCiudad.DbType = DbType.Int32;
                parIdCiudad.Direction = ParameterDirection.Input;
                parIdCiudad.Value = proveedor.id_Ciudad;
                cmd.Parameters.Add(parIdCiudad);

                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@TELEFONO";
                parTelefono.DbType = DbType.String;
                parTelefono.Direction = ParameterDirection.Input;
                parTelefono.Value = proveedor.Telefono;
                cmd.Parameters.Add(parTelefono);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@EMAIL";
                parEmail.DbType = DbType.String;
                parEmail.Direction = ParameterDirection.Input;
                parEmail.Value = proveedor.Email;
                cmd.Parameters.Add(parEmail);

                SqlParameter parCP = new SqlParameter();
                parCP.ParameterName = "@CP";
                parCP.DbType = DbType.String;
                parCP.Direction = ParameterDirection.Input;
                parCP.Value = proveedor.CP;
                cmd.Parameters.Add(parCP);

                SqlParameter parRFC = new SqlParameter();
                parRFC.ParameterName = "@RFC";
                parRFC.DbType = DbType.String;
                parRFC.Direction = ParameterDirection.Input;
                parRFC.Value = proveedor.RFC;
                cmd.Parameters.Add(parRFC);

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

        public static Int32 EliminaProveedor(Int32 id_Proveedor)
        {
            Int32 filasAfectadas = 0;

            try
            {                
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_BajaProveedor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdProveedor = new SqlParameter();
                parIdProveedor.ParameterName = "@ID_PROVEEDOR";
                parIdProveedor.DbType = DbType.Int32;
                parIdProveedor.Direction = ParameterDirection.Input;
                parIdProveedor.Value = id_Proveedor;
                cmd.Parameters.Add(parIdProveedor);

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
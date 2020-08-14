using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFacturacionService.BussinessObjectsLayer;
using System.Data;
using System.Data.SqlClient;

namespace WebFacturacionService.DataAccessLayer
{

    public static class SucursalDA
    {

        public static SqlConnection conn;
        #region Methods

        public static List<Sucursal> SeleccionaSucursal(Int32? id_Sucursal, String Nombre)
        {
            List<Sucursal> sucursalList = new List<Sucursal>();

            try
            {                
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ConsultaSucursales";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdSucursal = new SqlParameter();
                parIdSucursal.ParameterName = "@ID_SUCURSAL";
                parIdSucursal.DbType = DbType.Int32;
                parIdSucursal.Direction = ParameterDirection.Input;
                parIdSucursal.Value = id_Sucursal;
                cmd.Parameters.Add(parIdSucursal);

                SqlParameter parNombreSucursal = new SqlParameter();
                parNombreSucursal.ParameterName = "@NOM_SUCURSAL";
                parNombreSucursal.DbType = DbType.String;
                parNombreSucursal.Direction = ParameterDirection.Input;
                parNombreSucursal.Value = String.IsNullOrEmpty(Nombre) ? null : Nombre;
                cmd.Parameters.Add(parNombreSucursal);

                conn.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        //Estos valores deben ser deacuerdo a la base de datos
                        Sucursal sucursal = new Sucursal();
                        sucursal.id_Sucursal = Convert.ToInt32(dr["ID_SUCURSAL"]);
                        sucursal.Nombre = Convert.ToString(dr["NOM_SUCURSAL"]);
                        sucursal.Telefono = Convert.ToString(dr["TEL_SUCURSAL"]);
                        sucursal.Direccion = Convert.ToString(dr["DIREC_SUCURSAL"]);
                        sucursal.id_Ciudad = Convert.ToInt32(dr["ID_CIUDAD"]);
                        sucursal.Ciudad = Convert.ToString(dr["NOM_CIUDAD"]);
                        sucursal.Estado = Convert.ToString(dr["NOM_ESTADO"]);

                        sucursalList.Add(sucursal);
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

            return sucursalList;
        }
        
        public static Int32 InsertarSucursal(Sucursal sucursal)
        {
            Int32 filasAfectadas = 0;

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_AltaSucursal";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdSucursal = new SqlParameter();
                parIdSucursal.ParameterName = "@ID_SUCURSAL";
                parIdSucursal.DbType = DbType.Int32;
                parIdSucursal.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdSucursal);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@NOM_SUCURSAL";
                parNombre.DbType = DbType.String;
                parNombre.Direction = ParameterDirection.Input;
                parNombre.Value = sucursal.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parSucursal = new SqlParameter();
                parSucursal.ParameterName = "@TEL_SUCURSAL";
                parSucursal.DbType = DbType.String;
                parSucursal.Direction = ParameterDirection.Input;
                parSucursal.Value = sucursal.Telefono;
                cmd.Parameters.Add(parSucursal);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@DIREC_SUCURSAL";
                parDireccion.DbType = DbType.String;
                parDireccion.Direction = ParameterDirection.Input;
                parDireccion.Value = sucursal.Direccion;
                cmd.Parameters.Add(parDireccion);

                SqlParameter parIdCiudad = new SqlParameter();
                parIdCiudad.ParameterName = "@ID_CIUDAD";
                parIdCiudad.DbType = DbType.Int32;
                parIdCiudad.Direction = ParameterDirection.Input;
                parIdCiudad.Value = sucursal.id_Ciudad;
                cmd.Parameters.Add(parIdCiudad);

                conn.Open();

                filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas != 0)
                {
                    sucursal.id_Sucursal = Convert.ToInt32(cmd.Parameters["@ID_Sucursal"].Value);
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

        public static Int32 ActualizaSucursal(Sucursal sucursal)
        {
            Int32 filasAfectadas = 0;

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ActualizaSucursal";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdSucursal = new SqlParameter();
                parIdSucursal.ParameterName = "@ID_SUCURSAL";
                parIdSucursal.DbType = DbType.Int32;
                parIdSucursal.Direction = ParameterDirection.Input;
                parIdSucursal.Value = sucursal.id_Sucursal;
                cmd.Parameters.Add(parIdSucursal);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@NOM_SUCURSAL";
                parNombre.DbType = DbType.String;
                parNombre.Direction = ParameterDirection.Input;
                parNombre.Value = sucursal.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@TEL_SUCURSAL";
                parTelefono.DbType = DbType.String;
                parTelefono.Direction = ParameterDirection.Input;
                parTelefono.Value = sucursal.Telefono;
                cmd.Parameters.Add(parTelefono);

                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@DIREC_SUCURSAL";
                parDireccion.DbType = DbType.String;
                parDireccion.Direction = ParameterDirection.Input;
                parDireccion.Value = sucursal.Telefono;
                cmd.Parameters.Add(parDireccion);

                SqlParameter parIdCiudad = new SqlParameter();
                parIdCiudad.ParameterName = "@ID_CIUDAD";
                parIdCiudad.DbType = DbType.String;
                parIdCiudad.Direction = ParameterDirection.Input;
                parIdCiudad.Value = sucursal.id_Ciudad;
                cmd.Parameters.Add(parIdCiudad);

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

        public static Int32 EliminaSucursal(Int32 id_Sucursal)
        {
            Int32 filasAfectadas = 0;

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_BajaSucursal";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdSucursal = new SqlParameter();
                parIdSucursal.ParameterName = "@ID_SUCURSAL";
                parIdSucursal.DbType = DbType.Int32;
                parIdSucursal.Direction = ParameterDirection.Input;
                parIdSucursal.Value = id_Sucursal;
                cmd.Parameters.Add(parIdSucursal);

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFacturacionService.BussinessObjectsLayer;
using System.Data;
using System.Data.SqlClient;

namespace WebFacturacionService.DataAccessLayer
{

    public static class VendedorDA
    {

        public static SqlConnection conn;
        #region Methods

        public static List<Vendedor> SeleccionaVendedor(String Nombre)
        {
            List<Vendedor> Vendedorlist = new List<Vendedor>();

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ConsultaVendedores";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter nombrevendedor = new SqlParameter();
                nombrevendedor.ParameterName = "@NOMBRE";
                nombrevendedor.DbType = DbType.String;
                nombrevendedor.Direction = ParameterDirection.Input;
                nombrevendedor.Value = String.IsNullOrEmpty(Nombre) ? null : Nombre;
                cmd.Parameters.Add(nombrevendedor);

                conn.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Vendedor Vendedor = new Vendedor();

                        Vendedor.id_Vendedor        = Convert.ToInt32(dr["ID_VENDEDOR"]);
                        Vendedor.Usuario            = Convert.ToString(dr["USUARIO"]);
                        Vendedor.Contraseña         = Convert.ToString(dr["CONTRASEÑA"]);
                        Vendedor.Nombre             = Convert.ToString(dr["NOMBRE"]);
                        Vendedor.Direccion          = Convert.ToString(dr["DIRECCION"]);
                        Vendedor.Telefono           = Convert.ToString(dr["TELEFONO"]);
                        Vendedor.id_sucursal        = Convert.ToInt32(dr["ID_SUCURSAL"]);

                        Vendedorlist.Add(Vendedor);
                    }
                }

                dr.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return Vendedorlist;
        }


        public static Int32 InsertaVendedor(Vendedor vendedor)
        { 
            Int32 filasAfectadas = 0;

            try
            { 
            
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_AltaVendedor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter idvendedor = new SqlParameter();
                idvendedor.ParameterName = "@ID_VENDEDOR";
                idvendedor.DbType = DbType.Int32;
                idvendedor.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(idvendedor);

                SqlParameter usuario = new SqlParameter();
                usuario.ParameterName = "@USUARIO";
                usuario.DbType = DbType.String;
                usuario.Direction = ParameterDirection.Input;
                usuario.Value = vendedor.Usuario;
                cmd.Parameters.Add(usuario);

                SqlParameter contra = new SqlParameter();
                contra.ParameterName = "@CONTRASEÑA";
                contra.DbType = DbType.String;
                contra.Direction = ParameterDirection.Input;
                contra.Value = vendedor.Contraseña;
                cmd.Parameters.Add(contra);

                SqlParameter nombre = new SqlParameter();
                nombre.ParameterName = "@NOMBRE";
                nombre.DbType = DbType.String;
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = vendedor.Nombre;
                cmd.Parameters.Add(nombre);

                SqlParameter direccion = new SqlParameter();
                direccion.ParameterName = "@DIRECCION";
                direccion.DbType = DbType.String;
                direccion.Direction = ParameterDirection.Input;
                direccion.Value = vendedor.Direccion;
                cmd.Parameters.Add(direccion);

                SqlParameter telefono = new SqlParameter();
                telefono.ParameterName = "@TELEFONO";
                telefono.DbType = DbType.String;
                telefono.Direction = ParameterDirection.Input;
                telefono.Value = vendedor.Telefono;
                cmd.Parameters.Add(telefono);

                SqlParameter ID_suc = new SqlParameter();
                ID_suc.ParameterName = "@ID_SUCURSAL";
                ID_suc.DbType = DbType.String;
                ID_suc.Direction = ParameterDirection.Input;
                ID_suc.Value = vendedor.id_sucursal;
                cmd.Parameters.Add(ID_suc);

                conn.Open();

                filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas != 0)
                {
                    vendedor.id_Vendedor = Convert.ToInt32(cmd.Parameters["@ID_VENDEDOR"].Value);

                }
            }
            catch (SqlException e)
            {
                throw (e);
            }
            finally
            {
                conn.Close();
            }

            return filasAfectadas;
        }


        public static Int32 ActualizaVendedor(Vendedor vendedor)
        {
            Int32 filasAfectadas = 0;

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ActualizaVendedor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter id_ven = new SqlParameter();
                id_ven.ParameterName = "@ID_VENDEDOR";
                id_ven.DbType = DbType.Int32;
                id_ven.Direction = ParameterDirection.Input;
                id_ven.Value = vendedor.id_Vendedor;
                cmd.Parameters.Add(id_ven);

                SqlParameter usuarioParam = new SqlParameter();
                usuarioParam.ParameterName = "@USUARIO";
                usuarioParam.DbType = DbType.String;
                usuarioParam.Direction = ParameterDirection.Input;
                usuarioParam.Value = vendedor.Usuario;
                cmd.Parameters.Add(usuarioParam);

                SqlParameter contra = new SqlParameter();
                contra.ParameterName = "@CONTRASEÑA";
                contra.DbType = DbType.String;
                contra.Direction = ParameterDirection.Input;
                contra.Value = vendedor.Contraseña;
                cmd.Parameters.Add(contra);

                SqlParameter nombre = new SqlParameter();
                nombre.ParameterName = "@NOMBRE";
                nombre.DbType = DbType.String;
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = vendedor.Nombre;
                cmd.Parameters.Add(nombre);

                SqlParameter direccion = new SqlParameter();
                direccion.ParameterName = "@DIRECCION";
                direccion.DbType = DbType.String;
                direccion.Direction = ParameterDirection.Input;
                direccion.Value = vendedor.Direccion;
                cmd.Parameters.Add(direccion);

                SqlParameter tel = new SqlParameter();
                tel.ParameterName = "@TELEFONO";
                tel.DbType = DbType.String;
                tel.Direction = ParameterDirection.Input;
                tel.Value = vendedor.Telefono;
                cmd.Parameters.Add(tel);

                SqlParameter id_suc = new SqlParameter();
                id_suc.ParameterName = "@ID_SUCURSAL";
                id_suc.DbType = DbType.Int32;
                id_suc.Direction = ParameterDirection.Input;
                id_suc.Value = vendedor.id_sucursal;
                cmd.Parameters.Add(id_suc);

                conn.Open();

                filasAfectadas = cmd.ExecuteNonQuery();

            }
            catch(SqlException e)
            {
                throw (e);
            }
            finally
            {
                conn.Close();
            }
           return filasAfectadas;
        }

        public static Int32 EliminarVendedor(Int32 id_vendedor)
        {
            Int32 filasAfectadas = 0;

            try
            {

                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_BajaVendedor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter  id_ven = new SqlParameter();
                id_ven.ParameterName = "@ID_VENDEDOR";
                id_ven.DbType = DbType.Int32;
                id_ven.Direction = ParameterDirection.Input;
                id_ven.Value = id_vendedor;
                cmd.Parameters.Add(id_ven);

                conn.Open();

                filasAfectadas = cmd.ExecuteNonQuery();

            } catch(SqlException e) {
                throw (e);
            }
            finally
            {
                conn.Close();
            }
            return filasAfectadas;
        }

    }
}
#endregion

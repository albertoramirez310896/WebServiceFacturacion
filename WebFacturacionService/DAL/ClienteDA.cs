using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFacturacionService.BussinessObjectsLayer;
using System.Data;
using System.Data.SqlClient;

namespace WebFacturacionService.DataAccessLayer
{

    public static class ClienteDA
    {

        public static SqlConnection conn;
        #region Methods

        public static List<Cliente> SeleccionaClientes(Int32? id_Cliente, String Nombre, String RFC)
        {
            List<Cliente> clienteList = new List<Cliente>();

            try
            {      
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ConsultaClientes";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdCte = new SqlParameter();
                parIdCte.ParameterName = "@id_cte";
                parIdCte.DbType = DbType.Int32;
                parIdCte.Direction = ParameterDirection.Input;
                parIdCte.Value = id_Cliente;
                cmd.Parameters.Add(parIdCte);

                SqlParameter parNombreCte = new SqlParameter();
                parNombreCte.ParameterName = "@nombre_cte";
                parNombreCte.DbType = DbType.String;
                parNombreCte.Direction = ParameterDirection.Input;
                parNombreCte.Value = String.IsNullOrEmpty ( Nombre) ? null : Nombre;
                cmd.Parameters.Add(parNombreCte);

                SqlParameter parRfcCte = new SqlParameter();
                parRfcCte.ParameterName = "@RFC_cte";
                parRfcCte.DbType = DbType.String;
                parRfcCte.Direction = ParameterDirection.Input;
                parRfcCte.Value = String.IsNullOrEmpty ( RFC) ? null : RFC;
                cmd.Parameters.Add(parRfcCte);

                conn.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        //Estos valores deben ser deacuerdo a la base de datos
                        Cliente cte = new Cliente();
                        cte.id_Cliente      = Convert.ToInt32(dr["id_cte"]);
                        cte.Nombre          = Convert.ToString(dr["nombre_cte"]);
                        cte.Direccion       = Convert.ToString(dr["Direccion_cte"]);
                        cte.Telefono        = Convert.ToString(dr["Tel_cte"]);
                        cte.Email           = Convert.ToString(dr["Email_cte"]);
                        cte.FechaNacimiento = Convert.ToDateTime(dr["FechaNac_cte"]);
                        cte.Rfc             = Convert.ToString(dr["RFC_cte"]);

                        clienteList.Add(cte);
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

            return clienteList;
        }

        public static Int32 InsertarCliente(Cliente cte) 
        {
            Int32 filasAfectadas = 0;

            try
            {                
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_AltaCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdCte = new SqlParameter();
                parIdCte.ParameterName = "@id_cte";
                parIdCte.DbType = DbType.Int32;
                parIdCte.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdCte);

                SqlParameter parNombreCte = new SqlParameter();
                parNombreCte.ParameterName = "@nombre_cte";
                parNombreCte.DbType = DbType.String;
                parNombreCte.Direction = ParameterDirection.Input;
                parNombreCte.Value = cte.Nombre;
                cmd.Parameters.Add(parNombreCte);

                SqlParameter parDireccionCte = new SqlParameter();
                parDireccionCte.ParameterName = "@direccion_cte";
                parDireccionCte.DbType = DbType.String;
                parDireccionCte.Direction = ParameterDirection.Input;
                parDireccionCte.Value = cte.Direccion;
                cmd.Parameters.Add(parDireccionCte);

                SqlParameter parTelefonoCte = new SqlParameter();
                parTelefonoCte.ParameterName = "@tel_cte";
                parTelefonoCte.DbType = DbType.String;
                parTelefonoCte.Direction = ParameterDirection.Input;
                parTelefonoCte.Value = cte.Telefono;
                cmd.Parameters.Add(parTelefonoCte);

                SqlParameter parEmailCte = new SqlParameter();
                parEmailCte.ParameterName = "@email_cte";
                parEmailCte.DbType = DbType.String;
                parEmailCte.Direction = ParameterDirection.Input;
                parEmailCte.Value = cte.Email;
                cmd.Parameters.Add(parEmailCte);

                SqlParameter parFechaNacCte = new SqlParameter();
                parFechaNacCte.ParameterName = "@fechaNac_cte";
                parFechaNacCte.DbType = DbType.DateTime;
                parFechaNacCte.Direction = ParameterDirection.Input;
                parFechaNacCte.Value = cte.FechaNacimiento;
                cmd.Parameters.Add(parFechaNacCte);

                SqlParameter parRfcCte = new SqlParameter();
                parRfcCte.ParameterName = "@rfc_cte";
                parRfcCte.DbType = DbType.String;
                parRfcCte.Direction = ParameterDirection.Input;
                parRfcCte.Value = cte.Rfc;
                cmd.Parameters.Add(parRfcCte);

                conn.Open();

                filasAfectadas = cmd.ExecuteNonQuery();
             
                if (filasAfectadas != 0)
                {
                    cte.id_Cliente = Convert.ToInt32(cmd.Parameters["@id_cte"].Value);
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

        public static Int32 ActualizaCliente(Cliente cte)
        {
            Int32 filasAfectadas = 0;

            try
            {                
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ActualizaCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdCte = new SqlParameter();
                parIdCte.ParameterName = "@id_cte";
                parIdCte.DbType = DbType.Int32;
                parIdCte.Direction = ParameterDirection.Input;
                parIdCte.Value = cte.id_Cliente;
                cmd.Parameters.Add(parIdCte);

                SqlParameter parNombreCte = new SqlParameter();
                parNombreCte.ParameterName = "@nombre_cte";
                parNombreCte.DbType = DbType.String;
                parNombreCte.Direction = ParameterDirection.Input;
                parNombreCte.Value = cte.Nombre;
                cmd.Parameters.Add(parNombreCte);

                SqlParameter parDireccionCte = new SqlParameter();
                parDireccionCte.ParameterName = "@direccion_cte";
                parDireccionCte.DbType = DbType.String;
                parDireccionCte.Direction = ParameterDirection.Input;
                parDireccionCte.Value = cte.Direccion;
                cmd.Parameters.Add(parDireccionCte);

                SqlParameter parTelefonoCte = new SqlParameter();
                parTelefonoCte.ParameterName = "@tel_cte";
                parTelefonoCte.DbType = DbType.String;
                parTelefonoCte.Direction = ParameterDirection.Input;
                parTelefonoCte.Value = cte.Telefono;
                cmd.Parameters.Add(parTelefonoCte);

                SqlParameter parEmailCte = new SqlParameter();
                parEmailCte.ParameterName = "@email_cte";
                parEmailCte.DbType = DbType.String;
                parEmailCte.Direction = ParameterDirection.Input;
                parEmailCte.Value = cte.Email;
                cmd.Parameters.Add(parEmailCte);

                SqlParameter parFechaNacCte = new SqlParameter();
                parFechaNacCte.ParameterName = "@fechaNac_cte";
                parFechaNacCte.DbType = DbType.DateTime;
                parFechaNacCte.Direction = ParameterDirection.Input;
                parFechaNacCte.Value = cte.FechaNacimiento;
                cmd.Parameters.Add(parFechaNacCte);

                SqlParameter parRfcCte = new SqlParameter();
                parRfcCte.ParameterName = "@rfc_cte";
                parRfcCte.DbType = DbType.String;
                parRfcCte.Direction = ParameterDirection.Input;
                parRfcCte.Value = cte.Rfc;
                cmd.Parameters.Add(parRfcCte);

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

        public static Int32 EliminaCliente(Int32 id_Cliente) 
        {
            Int32 filasAfectadas = 0;

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_BajaCliente";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parIdCte = new SqlParameter();
                parIdCte.ParameterName = "@id_cte";
                parIdCte.DbType = DbType.Int32;
                parIdCte.Direction = ParameterDirection.Input;
                parIdCte.Value = id_Cliente;
                cmd.Parameters.Add(parIdCte);

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
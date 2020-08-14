using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFacturacionService.BussinessObjectsLayer;
using System.Data;
using System.Data.SqlClient;

namespace WebFacturacionService.DataAccessLayer
{
    public class DetalleFacturaDA
    {

        public static SqlConnection conn;

        #region Methods

        public static List<DetalleFactura> SeleccionaDetalleFactura(Int32? Folio_Fact) {

            List<DetalleFactura> detalleFacturaList = new List<DetalleFactura>();

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ConsultaDetalleFacturas";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parFolioFact = new SqlParameter();
                parFolioFact.ParameterName = "@folio_fact";
                parFolioFact.DbType = DbType.Int32;
                parFolioFact.Direction = ParameterDirection.Input;
                parFolioFact.Value = Folio_Fact;
                cmd.Parameters.Add(parFolioFact);

                conn.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();


                if (dr != null)
                {
                    while (dr.Read())
                    {
                        //Estos valores deben ser deacuerdo a la base de datos
                        DetalleFactura dte  = new DetalleFactura();
                        dte.Folio_Fact      = Convert.ToInt32(dr["Folio_fact"]);
                        //dte.Consecutivo_Det = Convert.ToInt32(dr["Consecutivo_Det"]);
                        dte.Id_Prod         = Convert.ToInt32(dr["Id_Prod"]);
                        dte.Cantidad_Det    = Convert.ToInt32(dr["Cantidad_Det"]);
                        dte.Subtotal_Det    = Convert.ToDouble(dr["Subtotal_Det"]);
                        dte.Precio          = Convert.ToDouble(dr["Precio_Prod"]);
                        dte.Producto        = Convert.ToString(dr["Descripcion_Prod"]);                

                        detalleFacturaList.Add(dte);
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

            return detalleFacturaList;
        }

        public static Int32 InsertarDetalleFactura(DetalleFactura dte)
        {
            Int32 filasAfectadas = 0;

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_AltaDetalleFactura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parFolioFact = new SqlParameter();
                parFolioFact.ParameterName = "@folio_fact";
                parFolioFact.DbType = DbType.Int32;
                parFolioFact.Direction = ParameterDirection.Input;
                parFolioFact.Value = dte.Folio_Fact;
                cmd.Parameters.Add(parFolioFact);

                SqlParameter parIdProd = new SqlParameter();
                parIdProd.ParameterName = "@id_prod";
                parIdProd.DbType = DbType.Int32;
                parIdProd.Direction = ParameterDirection.Input;
                parIdProd.Value = dte.Id_Prod;
                cmd.Parameters.Add(parIdProd);

                SqlParameter parConsecutivoDet = new SqlParameter();
                parConsecutivoDet.ParameterName = "@consecutivo_det";
                parConsecutivoDet.DbType = DbType.Int32;
                parConsecutivoDet.Direction = ParameterDirection.Input;
                parConsecutivoDet.Value = dte.Consecutivo_Det;
                cmd.Parameters.Add(parConsecutivoDet);

                SqlParameter parCantidadDet = new SqlParameter();
                parCantidadDet.ParameterName = "@cantidad_det";
                parCantidadDet.DbType = DbType.Double;
                parCantidadDet.Direction = ParameterDirection.Input;
                parCantidadDet.Value = dte.Cantidad_Det;
                cmd.Parameters.Add(parCantidadDet);

                SqlParameter parSubTotalDet = new SqlParameter();
                parSubTotalDet.ParameterName = "@subtotal_det";
                parSubTotalDet.DbType = DbType.Double;
                parSubTotalDet.Direction = ParameterDirection.Input;
                parSubTotalDet.Value = dte.Subtotal_Det;
                cmd.Parameters.Add(parSubTotalDet);                

                conn.Open();

                filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas != 0) { 
                    
                    //dte.Folio_Fact = Convert.ToInt32(cmd.Parameters)
                
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

        public static Int32 ActualizaDetalleFactura(DetalleFactura dte) 
        {
            Int32 filasAfectadas = 0;

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ActualizaDetalleFactura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parFolioFact = new SqlParameter();
                parFolioFact.ParameterName = "@folio_fact";
                parFolioFact.DbType = DbType.Int32;
                parFolioFact.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parFolioFact);

                SqlParameter parIdProd = new SqlParameter();
                parIdProd.ParameterName = "@id_prod";
                parIdProd.DbType = DbType.Int32;
                parIdProd.Direction = ParameterDirection.Input;
                parIdProd.Value = dte.Id_Prod;
                cmd.Parameters.Add(parIdProd);

                SqlParameter parIdConsecutivo = new SqlParameter();
                parIdConsecutivo.ParameterName = "@id_consecutivo";
                parIdConsecutivo.DbType = DbType.Int32;
                parIdConsecutivo.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(parIdConsecutivo);

                SqlParameter parConsecutivoDet = new SqlParameter();
                parConsecutivoDet.ParameterName = "@consecutivo_det";
                parConsecutivoDet.DbType = DbType.Int32;
                parConsecutivoDet.Direction = ParameterDirection.Input;
                parConsecutivoDet.Value = dte.Consecutivo_Det;
                cmd.Parameters.Add(parConsecutivoDet);

                SqlParameter parCantidadDet = new SqlParameter();
                parCantidadDet.ParameterName = "@cantidad_det";
                parCantidadDet.DbType = DbType.Double;
                parCantidadDet.Direction = ParameterDirection.Input;
                parCantidadDet.Value = dte.Cantidad_Det;
                cmd.Parameters.Add(parCantidadDet);

                SqlParameter parSubTotalDet = new SqlParameter();
                parSubTotalDet.ParameterName = "@subtotal_det";
                parSubTotalDet.DbType = DbType.Double;
                parSubTotalDet.Direction = ParameterDirection.Input;
                parSubTotalDet.Value = dte.Subtotal_Det;
                cmd.Parameters.Add(parSubTotalDet);

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

        public static Int32 EliminaDetalleFactura(Int32 Folio_Fact, Int32 id_prod) 
        {
            Int32 filasAfectadas = 0;

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_BajaDetalleFactura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parFolioFact = new SqlParameter();
                parFolioFact.ParameterName = "@folio_fact";
                parFolioFact.DbType = DbType.Int32;
                parFolioFact.Direction = ParameterDirection.Input;
                parFolioFact.Value = Folio_Fact;
                cmd.Parameters.Add(parFolioFact);

                SqlParameter parid_prod = new SqlParameter();
                parid_prod.ParameterName = "@id_prod";
                parid_prod.DbType = DbType.Int32;
                parid_prod.Direction = ParameterDirection.Input;
                parid_prod.Value = id_prod ;
                cmd.Parameters.Add(parid_prod);
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
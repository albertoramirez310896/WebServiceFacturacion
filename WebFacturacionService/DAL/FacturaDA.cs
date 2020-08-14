using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFacturacionService.BussinessObjectsLayer;
using System.Data;
using System.Data.SqlClient;

namespace WebFacturacionService.DataAccessLayer
{
    public class FacturaDA
    {
        public static SqlConnection conn;
        #region Methods

        public static List<Factura> SeleccionaFacturas(Int32? Folio_Cte) 
        {
            List<Factura> facturaList = new List<Factura>();

            try
            {                
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ConsultaFacturas";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parFolioCte = new SqlParameter();
                parFolioCte.ParameterName = "@folio_cte";
                parFolioCte.DbType = DbType.Int32;
                parFolioCte.Direction = ParameterDirection.Input;
                parFolioCte.Value = Folio_Cte;
                cmd.Parameters.Add(parFolioCte);

                conn.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();


                if (dr != null)
                {
                    while (dr.Read())
                    {
                        //Estos valores deben ser deacuerdo a la base de datos
                        Factura cte = new Factura();
                        cte.Folio_cte = Convert.ToInt32(dr["Folio_cte"]);
                        cte.Id_cte = Convert.ToInt32(dr["Id_cte"]);
                        cte.Fecha_Fact = Convert.ToDateTime(dr["Fecha_Fact"]);
                        cte.Total_Fact = Convert.ToDouble(dr["Total_Fact"]);

                        facturaList.Add(cte);
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

            return facturaList;
        }

        public static Int32 InsertarFactura(Factura fta)
        {
            Int32 filasAfectadas = 0;

            try
            {                
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_AltaFactura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parFolioCte = new SqlParameter();
                parFolioCte.ParameterName = "@folio_fact";
                parFolioCte.DbType = DbType.Int32;
                parFolioCte.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parFolioCte);

                SqlParameter parIdCte = new SqlParameter();
                parIdCte.ParameterName = "@id_cte";
                parIdCte.DbType = DbType.Int32;
                parIdCte.Direction = ParameterDirection.Input;
                parIdCte.Value = fta.Id_cte;
                cmd.Parameters.Add(parIdCte);

                SqlParameter parFechaFact = new SqlParameter();
                parFechaFact.ParameterName = "@fecha_fact";
                parFechaFact.DbType = DbType.DateTime;
                parFechaFact.Direction = ParameterDirection.Input;
                parFechaFact.Value = fta.Fecha_Fact;
                cmd.Parameters.Add(parFechaFact);

                SqlParameter parTotalFact = new SqlParameter();
                parTotalFact.ParameterName = "@total_fact";
                parTotalFact.DbType = DbType.Double;
                parTotalFact.Direction = ParameterDirection.Input;
                parTotalFact.Value = fta.Total_Fact;
                cmd.Parameters.Add(parTotalFact);


                conn.Open();

                filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas != 0) {
                    filasAfectadas = Convert.ToInt32(cmd.Parameters["@folio_fact"].Value);
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

        public Int32 ActualizaFactura(Factura fra)
        {
            Int32 filasAfectadas = 0;

            try
            {                
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ActualizaFactura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parFolioCte = new SqlParameter();
                parFolioCte.ParameterName = "@FolioCte";
                parFolioCte.DbType = DbType.Int32;
                parFolioCte.Direction = ParameterDirection.Input;
                parFolioCte.Value = fra.Folio_cte;
                cmd.Parameters.Add(parFolioCte);

                SqlParameter parIdCte = new SqlParameter();
                parIdCte.ParameterName = "@Id_Cte";
                parIdCte.DbType = DbType.Int32;
                parIdCte.Direction = ParameterDirection.Input;
                parIdCte.Value = fra.Id_cte;
                cmd.Parameters.Add(parIdCte);

                SqlParameter parFechaFact = new SqlParameter();
                parFechaFact.ParameterName = "@Fecha_Fact";
                parFechaFact.DbType = DbType.DateTime;
                parFechaFact.Direction = ParameterDirection.Input;
                parFechaFact.Value = fra.Fecha_Fact;
                cmd.Parameters.Add(parFechaFact);

                SqlParameter parTotalFact = new SqlParameter();
                parTotalFact.ParameterName = "@Total_Fact";
                parTotalFact.DbType = DbType.Double;
                parTotalFact.Direction = ParameterDirection.Input;
                parTotalFact.Value = fra.Total_Fact;
                cmd.Parameters.Add(parTotalFact);

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

        public Int32 EliminaFactura(Int32 Folio_fact)
        {
            Int32 filasAfectadas = 0;

            try
            {                
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_BajaFactura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                SqlParameter parFolioFact = new SqlParameter();
                parFolioFact.ParameterName = "@folio_fact";
                parFolioFact.DbType = DbType.Int32;
                parFolioFact.Direction = ParameterDirection.Input;
                parFolioFact.Value = Folio_fact;
                cmd.Parameters.Add(parFolioFact);

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
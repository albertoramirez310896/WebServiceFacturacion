using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFacturacionService.BussinessObjectsLayer;
using System.Data;
using System.Data.SqlClient;

namespace WebFacturacionService.DataAccessLayer
{
    public static class CiudadDA
    {
        public static SqlConnection conn;
        #region Methods

        public static List<Ciudad> SeleccionaCiudades()
        {
            List<Ciudad> ciudadList = new List<Ciudad>();

            try
            {
                conn = new SqlConnection(DBContext.getConnectionString());
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "CATALOGOS_SP_ConsultaCiudades";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                conn.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        //Losvalores de la derecha deben ser deacuerdo a lo que regrese el SP
                        Ciudad ciudad = new Ciudad();
                        ciudad.id_Ciudad = Convert.ToInt32(dr["ID_CIUDAD"]);
                        ciudad.Nombre = Convert.ToString(dr["NOM_CIUDAD"]);
                        ciudad.id_Estado= Convert.ToInt32(dr["ID_ESTADO"]);                        

                        ciudadList.Add(ciudad);
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

            return ciudadList;
        }
    }
    #endregion
}
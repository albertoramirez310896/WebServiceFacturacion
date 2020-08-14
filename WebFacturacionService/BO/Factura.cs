using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFacturacionService.BussinessObjectsLayer
{
    public class Factura
    {

        #region Properties




        public Int32 Folio_cte 
        {
            get;
            set;
        }

        public Int32 Id_cte 
        {
            get;
            set;
        }

        public DateTime Fecha_Fact 
        {
            get;
            set;
        }

        public double Total_Fact 
        {
            get;
            set;

        }
        #endregion
    }
}
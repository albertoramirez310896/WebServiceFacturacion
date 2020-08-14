using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFacturacionService.BussinessObjectsLayer
{
    public class Producto
    {

        #region Producto

        public Int32 id_Producto 
        {
            get;
            set;
        }

        public string DescripcionProducto 
        {
            get;
            set;
        }

        public double PrecioProd
        {
            get;
            set;
        }

        public DateTime FechaCaducidadProd
        {
            get;
            set;
        }

        public string CodigoBarras_Prod
        {
            get;
            set;
        }
        public string Proveedor_Prod
        {
            get;
            set;
        }

        #endregion
    }
}
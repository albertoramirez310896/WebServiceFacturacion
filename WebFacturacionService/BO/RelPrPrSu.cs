using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFacturacionService.BussinessObjectsLayer
{
    public class RelPrPrSu
    {
        #region Properties

        public Int32 id_RelPrPrSu
        {
            get;
            set;
        }

        public Int32 id_Producto
        {
            get;
            set;
        }

        public Int32 id_Proveedor
        {
            get;
            set;
        }

        public Int32 id_Sucursal
        {
            get;
            set;
        }

        public Double Precio_Unitario
        {
            get;
            set;
        }

        public string Proveedor { get; set; }
        public string Sucursal { get; set; }
        public string Producto { get; set; }

        #endregion

    }
}
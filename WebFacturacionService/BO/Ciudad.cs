using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFacturacionService.BussinessObjectsLayer
{
    public class Ciudad
    {
        #region Properties
        public Int32 id_Ciudad { get; set; }
        public String Nombre { get; set; } 
        public Int32 id_Estado { get; set; }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFacturacionService.BussinessObjectsLayer
{
    public class Sucursal
    {
        public Int32 id_Sucursal { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }        
        public Int32 id_Ciudad { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
    }
}
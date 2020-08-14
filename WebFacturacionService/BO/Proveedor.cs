using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFacturacionService.BussinessObjectsLayer
{
    public class Proveedor
    {
        public Int32 id_Proveedor { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Int32 id_Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string CP { get; set; }
        public string RFC { get; set; }
        public string NombreCiudad { get; set; }
        public string NombreEstado { get; set; }
    }
}
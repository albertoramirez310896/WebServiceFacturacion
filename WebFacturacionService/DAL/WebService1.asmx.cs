using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebFacturacionService.BussinessObjectsLayer;
using WebFacturacionService.DataAccessLayer;

namespace WebFacturacionService.DAL
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public List<Factura> SeleccionaFactura(Int32 folio_factura)
        {
            List<Factura> facturas = new List<Factura>();

            try
            {
                facturas = FacturaDA.SeleccionaFacturas(folio_factura);
            }
            catch 
            {
            }

            return facturas;
        }

        [WebMethod]
        public List<DetalleFactura> SeleccionaDetalleFactura(Int32? Folio_Fact)
        {
            List<DetalleFactura> detalles = new List<DetalleFactura>();

            try
            {
                detalles = DetalleFacturaDA.SeleccionaDetalleFactura(Folio_Fact);
            }
            catch
            {
            }

            return detalles;
        }
    }
}

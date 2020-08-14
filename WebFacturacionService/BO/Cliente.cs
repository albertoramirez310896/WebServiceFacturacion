using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFacturacionService.BussinessObjectsLayer
{
    public class Cliente
    {
        #region Properties
        public Int32 id_Cliente 
        {
            get;
            set;
        }

        public string Nombre
        {
            get;
            set;
        }

        public string Direccion
        {
            get;
            set;
        }

        public string Telefono
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public DateTime FechaNacimiento
        {
            get;
            set;
        }

        public string Rfc
        {
            get;
            set;
        }






        #endregion


    }
}
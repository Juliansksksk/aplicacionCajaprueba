using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace aplicacionCaja
{
    class Class1
    {


        public class Cliente
        {
            public int IdCliente { get; set; }
            public string TipoIdentificacion { get; set; }
            public string NumeroIdentificacion { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Direccion { get; set; }
            public string TelefonoFijo { get; set; }
            public string TelefonoCelular { get; set; }
        }

        public class EntidadFinanciera
        {
            public int IdEntidadFinanciera { get; set; }
            public string NombreEntidad { get; set; }
            public string TipologiaDocumental { get; set; }
        }



        public class Caja
        {
            public int IdCaja { get; set; }
            public int IdEntidadFinanciera { get; set; }
            public int Zona { get; set; }
            public int Seccion { get; set; }
            public int Nivel { get; set; }
            public int Cara { get; set; }
            public string CodigoBarras { get; set; }
        }


        public class Carpeta
        {
            public int IdCarpeta { get; set; }
            public int IdCliente { get; set; }
            public int IdEntidadFinanciera { get; set; }
            public int IdCaja { get; set; }
            public string CodigoBarras { get; set; }
        }

        public class Folio
        {
            public int IdFolio { get; set; }
            public int IdCarpeta { get; set; }
            public string TipoDocumento { get; set; }
            public string Imagen { get; set; }
        }




        public class ImagenesServidor
        {
            public int IdImagen { get; set; }
            public int IdCliente { get; set; }
            public int IdEntidadFinanciera { get; set; }
            public string TipoDocumento { get; set; }
            public string RutaImagen { get; set; }
        }




    }
}
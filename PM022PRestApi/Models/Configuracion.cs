using System;
using System.Collections.Generic;
using System.Text;

namespace PM022PRestApi.Models
{
    public class Configuracion
    {
        public static String ipaddress = "192.168.0.7";  //IP public o DNS 
        public static String webapi = "pm022p";

        // Routing
        public static String getRoute = "Listalumnos.php";  //IP public o DNS 
        public static String postRoute = "CreateAlumno.php";  //IP public o DNS 

        //Format URL 
        public static String WebUrlApi = "http://{0}/{1}/{2}";


        //EndPoint
        public static String ApiGetListAlumn = string.Format(WebUrlApi, ipaddress, webapi, getRoute);
        public static String ApiPostAlumn = string.Format(WebUrlApi, ipaddress, webapi, postRoute);

    }
}

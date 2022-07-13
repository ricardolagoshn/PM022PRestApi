using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PM022PRestApi.Models;

namespace PM022PRestApi.Controllers
{
    public static class EmpleadosController
    {

        public async static Task<Models.Message> CreateAlumno(Models.Alumno alum)
        {
            Models.Message msg = new Models.Message();

            String jsonObject = JsonConvert.SerializeObject(alum);
            System.Net.Http.StringContent contenido = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage respuesta = await client.PostAsync(Configuracion.ApiPostAlumn, contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    var result = respuesta.Content.ReadAsStringAsync().Result;

                    msg =  JsonConvert.DeserializeObject<Models.Message>(result);
                }
            }

            return msg;
        }
        public async static Task<List<Empleado>> getEmple()
        {
            List<Empleado> listalibros = new List<Empleado>();

            using (HttpClient cliente = new HttpClient())
            {
                var respuesta = await cliente.GetAsync(Configuracion.ApiGetListAlumn);

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = respuesta.Content.ReadAsStringAsync().Result;

                    listalibros = JsonConvert.DeserializeObject<List<Empleado>>(contenido);
                }
            }
            return listalibros;
        }
    }
}

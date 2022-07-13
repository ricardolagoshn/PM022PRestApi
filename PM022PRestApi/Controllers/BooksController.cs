using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace PM022PRestApi.Controllers
{
    public static class BooksController
    {
        public async static Task<List<Models.Books>> getBooks()
        {
            List<Models.Books> listalibros = new List<Models.Books>();

            using (HttpClient cliente = new HttpClient())
            {
                var respuesta = await cliente.GetAsync("https://jsonplaceholder.typicode.com/posts");

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = respuesta.Content.ReadAsStringAsync().Result;

                    listalibros = JsonConvert.DeserializeObject<List<Models.Books>>(contenido);
                }
            }
            return listalibros;
        }
    }
}

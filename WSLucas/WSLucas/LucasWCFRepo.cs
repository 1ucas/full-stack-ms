using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace WSLucas
{
    public class LucasWCFRepo
    {
        public List<Lucas> Get()
        {
            string baseURL = "http://localhost:53706/LucasService.svc/";
            using (var client = new HttpClient()) // usado com using ao invés de static para fins educacionais
            {
                client.BaseAddress = new Uri(baseURL);
                List<Lucas> listaLucas = null;
                var response = client.GetAsync($"GetLucas").Result;
                if (response.IsSuccessStatusCode)
                {
                    listaLucas = JsonConvert.DeserializeObject<List<Lucas>>(response.Content.ReadAsStringAsync().Result);
                }
                return listaLucas;
            }
        }
    }
}
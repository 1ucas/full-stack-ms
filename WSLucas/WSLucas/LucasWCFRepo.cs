using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace WSLucas
{
    public class LucasWCFRepo
    {
        public Lucas GetById(int id)
        {
            string baseURL = "http://localhost:53706/LucasService.svc/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                Lucas lucas = null;
                var response = client.GetAsync($"GetLucas?id={id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    lucas = JsonConvert.DeserializeObject<Lucas>(response.Content.ReadAsStringAsync().Result);
                }
                return lucas;
            }
        }
    }
}
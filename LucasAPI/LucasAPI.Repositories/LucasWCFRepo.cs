using LucasAPI.Domain;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace LucasAPI.Repositories
{
    public class LucasWCFRepo
    {
        public void Criar(Lucas lucas)
        {
            string baseURL = "http://localhost:53706/LucasService.svc/";
            string result = null;
            using (var client = new HttpClient()) // usado com using ao invés de static para fins educacionais
            {
                client.BaseAddress = new Uri(baseURL);
                var json = JsonConvert.SerializeObject(lucas);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                var response = client.PostAsync($"CreateLucas", stringContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                }
                if (result != "OK") {
                    throw new OperationCanceledException();
                }
            }
        }
    }
}

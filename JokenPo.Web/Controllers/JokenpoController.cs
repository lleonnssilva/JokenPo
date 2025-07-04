using JokenPo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace JokenPo.Web.Controllers
{


    public class JokenpoController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public JokenpoController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("ApiUrl"); // Lê a URL da API do arquivo appsettings.json
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> JogarContraComputador(string escolhaJogador)
        {
            if (string.IsNullOrEmpty(escolhaJogador))
            {
                return View("Index");
            }

            var json = JsonConvert.SerializeObject(escolhaJogador);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_apiUrl + "/api/jokenpo/jogarContraComputador", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var jogo = JsonConvert.DeserializeObject<JogoModel>(result);
                return View("Resultado", jogo);
            }

            return View("Error");
        }
    }
}

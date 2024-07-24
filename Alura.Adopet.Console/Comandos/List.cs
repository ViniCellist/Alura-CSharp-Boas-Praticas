using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    internal class List:IComando
    {
        public async Task ExecutarAsync()
        {
            await this.ListaDadosPetsDaAPIAsync();
            
        }

        HttpClient client;
        public List()
        {
            Client = ConfiguraHttpClient("http://localhost:5057");
        }

        public HttpClient Client { get => client; set => client = value; }

        public async Task ListaDadosPetsDaAPIAsync()
        {
            IEnumerable<Pet>? pets = await ListaPetsAsync();
            System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }

        HttpClient ConfiguraHttpClient(string url)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);
            return _client;
        }

        async Task<IEnumerable<Pet>?> ListaPetsAsync()
        {
            HttpResponseMessage response = await Client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }
    }
}

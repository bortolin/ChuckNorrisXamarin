using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using ChuckNorris.Models;
using System.Linq;

namespace ChuckNorris.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<string>> GetCategories()
        {
            var categories = new List<string>();

            var uri = new Uri(string.Format(Constants.Categories));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    categories = JsonSerializer.Deserialize<List<string>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return categories;
        }

        public async Task<NorrisFact> GetRandomFact()
        {
            NorrisFact norrisfact = new NullNorrisFact();

            var uri = new Uri(string.Format(Constants.RandomFact));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    norrisfact = JsonSerializer.Deserialize<NorrisFact>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return norrisfact;
        }

        public async Task<List<NorrisFact>> QueryFacts(string search)
        {
            var facts = new List<NorrisFact>();

            var uri = new Uri(string.Format(Constants.Search,search));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var factsresult = JsonSerializer.Deserialize<NorrisFactQueryResult>(content);
                    if (factsresult.total > 0) facts = factsresult.result.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return facts;
        }

        public async Task<List<NorrisFact>> GetRandomFacts(int max)
        {
            var facts = new List<NorrisFact>();

            var uri = new Uri(string.Format(Constants.RandomFact));

            for (int i = 0; i < max; i++)
            {
                try
                {
                    var response = await _client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var fact = JsonSerializer.Deserialize<NorrisFact>(content);
                        facts.Add(fact);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"\tERROR {0}", ex.Message);
                }
            }
            

            return facts;
        }

    }
}

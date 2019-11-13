using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChuckNorris.Models;

namespace ChuckNorris.Services
{
    public interface IRestService
    {

        Task<List<string>> GetCategories();

        Task<NorrisFact> GetRandomFact();

        Task<List<NorrisFact>> GetRandomFacts(int max);

        Task<List<NorrisFact>> QueryFacts(string search);

    }
}

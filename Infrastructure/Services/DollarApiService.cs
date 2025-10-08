using Application.Interfaces;
using Domine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DollarApiService : IDollarApiService
    {
        private readonly HttpClient _httpClient;
        public DollarApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DollarRate> GetDollarRateAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<DollarRate>("dolares/oficial");
            return result!;
        }
    }
}

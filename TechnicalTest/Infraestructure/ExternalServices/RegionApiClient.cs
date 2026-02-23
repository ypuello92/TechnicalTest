using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Text.Json;
using TechnicalTest.Aplication.DTO_s;
using TechnicalTest.Aplication.Interface;

namespace TechnicalTest.Infraestructure.ExternalServices
{
    public class RegionApiClient : IRegionListClient
    {

        
        private readonly HttpClient _http;

        public RegionApiClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<IReadOnlyList<RegionListDTO>> GetRegionListAsync(string? sortBy, string? sortDirection, CancellationToken ct)
        {
            var urlApi = "api/v1/Region";

            var dataResponse = await _http.GetAsync(urlApi, ct);

            dataResponse.EnsureSuccessStatusCode();

            var data = await dataResponse.Content.ReadFromJsonAsync<List<RegionListDTO>>(ct);

            return data ?? [];
        }

        public async Task<RegionListDTO> GetRegionByIdAsync(int? id, CancellationToken ct)
        {
            var urlApi = $"api/v1/Region/{id}";

            var dataResponse = await _http.GetAsync(urlApi, ct);

            if (dataResponse.StatusCode == HttpStatusCode.NotFound)
                return null;

            dataResponse.EnsureSuccessStatusCode();

            var data = await dataResponse.Content.ReadFromJsonAsync<RegionListDTO>(ct);

            return data;
        }
    }
}

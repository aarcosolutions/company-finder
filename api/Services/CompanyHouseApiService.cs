using System;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Options;
using api.Models.Config;
using System.Text;

namespace api.Services
{
    public class CompanyHouseApiService : ICompanyHouseApiService
    {
        private IOptions<CompanyHouseConfig> companyHouseConfig { get; }
        public CompanyHouseApiService(IOptions<CompanyHouseConfig> options)
        {
            companyHouseConfig = options;
        }

        public async Task<string> InvokeSearchCompanyApi(string keyword)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    AddAuthorizationHeader(client);

                    client.BaseAddress = new Uri(companyHouseConfig.Value.BaseUrl);
                    var companySearchUrl = $"/search/companies?q={keyword}&items_per_page={companyHouseConfig.Value.ItemsPerPage}";
                    var response = await client.GetAsync(companySearchUrl);
                    response.EnsureSuccessStatusCode();
                    var searchData = await response.Content.ReadAsStringAsync();

                    return searchData;
                }
                catch
                {
                    throw;
                }
            }
        }

        private void AddAuthorizationHeader(HttpClient client)
        {
            var keyByteArray = Encoding.ASCII.GetBytes(companyHouseConfig.Value.ApiKey);
            var encodedString = Convert.ToBase64String(keyByteArray);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", encodedString);
        }
    }
}

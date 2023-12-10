using Newtonsoft.Json;
using Skladala.Core.Models;
using Skladala.Persistence.Models;
using System.Net.Http.Json;
using System.Text;

namespace Skladala.View.Services
{
    public class NonfoodProductServices
    {
        private readonly HttpClient _httpClient;

        public NonfoodProductServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<NonfoodProductsDto>> GetAsync()
        {
            try
            {
                var responce = await _httpClient.GetAsync($"/api/NonfoodProduct");
                if (responce.IsSuccessStatusCode)
                {
                    if (responce.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return new List<NonfoodProductsDto>();
                    }
                    return await responce.Content.ReadFromJsonAsync<List<NonfoodProductsDto>>();
                }
                else
                {
                    var message = await responce.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<bool> CreateAsync(NonfoodProducts foodProduct)
        {
            try
            {

                var stringContent = new StringContent(JsonConvert.SerializeObject(foodProduct), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"/api/NonfoodProduct", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

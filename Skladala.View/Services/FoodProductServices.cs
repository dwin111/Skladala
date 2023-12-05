using Skladala.Core.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;
using Skladala.Persistence.Models;

namespace Skladala.View.Services
{
    public class FoodProductServices
    {
        private readonly HttpClient _httpClient;

        public FoodProductServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FoodProductDto>> GetAsync()
        {
            try
            {
                var responce = await _httpClient.GetAsync($"/api/FoodProduct");
                if (responce.IsSuccessStatusCode)
                {
                    if (responce.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return new List<FoodProductDto>();
                    }
                    return await responce.Content.ReadFromJsonAsync<List<FoodProductDto>>();
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

        public async Task<bool> CreateAsync(FoodProduct foodProduct)
        {
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(foodProduct), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"/api/FoodProduct", stringContent);
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

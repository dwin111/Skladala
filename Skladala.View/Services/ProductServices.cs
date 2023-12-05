using Newtonsoft.Json;
using Skladala.Core.Models;
using Skladala.Persistence.Models;
using System.Net.Http.Json;
using System.Text;

namespace Skladala.View.Services
{
    public class ProductServices
    {
        private readonly HttpClient _httpClient;

        public ProductServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AllProductDto>> GetAsync()
        {
            try
            {
                var responce = await _httpClient.GetAsync($"/api/Product");
                if (responce.IsSuccessStatusCode)
                {
                    if (responce.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return new List<AllProductDto>();
                    }
                    return await responce.Content.ReadFromJsonAsync<List<AllProductDto>>();
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
        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Product/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
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
        public async Task<bool> UpdateAsync(AllProductDto productDto)
        {
            try
            {

                var stringContent = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"/api/Product", stringContent);
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

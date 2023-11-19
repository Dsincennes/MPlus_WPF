using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPFtest2
{
    class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Mplus> GetMplusInfo(string characterName)
        {
            try
            {
                string requestUri = $"http://localhost:5200/mplus/{characterName}";
                HttpResponseMessage response = await _httpClient.GetAsync(requestUri);

                if (!response.IsSuccessStatusCode)
                {
                    //TODO Handle non-success status
                }

                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Mplus>(responseContent);
            }
            catch (Exception ex)
            {
                //TODO Handle exceptions
                throw;
            }
        }
    }
}

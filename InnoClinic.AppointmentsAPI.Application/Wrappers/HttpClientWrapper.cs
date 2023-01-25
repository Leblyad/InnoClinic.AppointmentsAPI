using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace InnoClinic.AppointmentsAPI.Application.Wrappers
{
    public class HttpClientWrapper
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpClientWrapper(string accessToken, IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("Authorization", accessToken);

            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> GetEntities<T>(IEnumerable<Guid> ids)
        {
            var uri = _configuration.GetSection("Routes").GetSection(typeof(T).Name).Value;
            var request = new HttpRequestMessage(HttpMethod.Post, uri);

            var requestBody = JsonSerializer.Serialize(ids);
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<IEnumerable<T>>();
        }
    }
}

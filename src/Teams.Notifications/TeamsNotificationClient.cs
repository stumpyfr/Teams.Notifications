using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Teams.Notifications
{
    public class TeamsNotificationClient : IDisposable
    {
        private readonly Uri _uri;
        private readonly HttpClient _client = new();

        public TeamsNotificationClient(string url) => _uri = new Uri(url);

        public async Task PostMessageAsync(MessageCard message)
        {
            string json = JsonConvert.SerializeObject(message);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_uri, content).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        public void Dispose() => _client.Dispose();
    }
}

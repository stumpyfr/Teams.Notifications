using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Teams.Notifications
{
    public class TeamsNotificationClient: IDisposable
    {
        private readonly Uri uri;
        private readonly HttpClient client = new HttpClient();

        public TeamsNotificationClient(string url)
        {
            uri = new Uri(url);
        }

        public async Task PostMessage(MessageCard message)
        {
            var json = JsonConvert.SerializeObject(message);

            var response = await this.client.PostAsync(this.uri,
                new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            this.client?.Dispose();
        }
    }
}

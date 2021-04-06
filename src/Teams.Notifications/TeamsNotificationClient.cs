using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Teams.Notifications.Entities;

namespace Teams.Notifications
{
    public class TeamsNotificationClient : IDisposable
    {
        private readonly Uri _uri;
        private readonly HttpClient _client;

        public TeamsNotificationClient(string uri) : this(new(uri), new()) { }

        public TeamsNotificationClient(Uri uri) : this(uri, new()) { }

        public TeamsNotificationClient(Uri uri, HttpClient client)
            => (_uri, _client) = (uri ?? throw new ArgumentNullException(nameof(uri)), client ?? throw new ArgumentNullException(nameof(client)));

        public async ValueTask PostMessageAsync(MessageCard message)
        {
            byte[] utf8json = JsonSerializer.SerializeToUtf8Bytes(message);
            var content = new ByteArrayContent(utf8json);
            content.Headers.ContentType = new("application/json");

            var response = await _client.PostAsync(_uri, content).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        public void Dispose() => _client.Dispose();
    }
}

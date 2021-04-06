using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Nogic.Teams.Notifications.Entities;

namespace Nogic.Teams.Notifications
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
            var response = await _client.PostAsJsonAsync(_uri, message);
            response.EnsureSuccessStatusCode();
        }

        public void Dispose() => _client.Dispose();
    }
}

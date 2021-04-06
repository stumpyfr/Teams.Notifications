using System.Collections.Generic;
using System.Threading.Tasks;
using Nogic.Teams.Notifications.Entities;

namespace Nogic.Teams.Notifications.Client
{
    internal static class Program
    {
        private async static Task Main()
        {
            const string url = "";
            var client = new TeamsNotificationClient(url);

            var message = new MessageCard(
                Title: "title",
                Text: "text",
                ThemeColor: "f0ad4e",
                Sections: new List<MessageSection>
                {
                    new (
                        Title: "Context",
                        Facts: new List<MessageFact>
                        {
                            new ("Key", "Value")
                        }
                    )
                },
                PotentialActions: new List<OpenUriAction>
                {
                    new (
                        Name: "Open",
                        Targets: new List<OpenUriTarget>
                        {
                            new ("http://google.com")
                        }
                    )
                }
            );
            await client.PostMessageAsync(message).ConfigureAwait(false);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teams.Notifications.Client
{
    internal static class Program
    {
        private async static Task Main()
        {
            const string url = "";
            var client = new TeamsNotificationClient(url);

            var message = new MessageCard
            {
                Title = "title",
                Text = "text",
                Color = "f0ad4e",
                Sections = new List<MessageSection>
                {
                    new MessageSection()
                    {
                        Title = "Context",
                        Facts = new List<MessageFact>()
                        {
                            new MessageFact()
                            {
                                Name = "Key",
                                Value = "Value"
                            }
                        }
                    }
                },
                PotentialActions = new List<PotentialAction>
                {
                    new PotentialAction()
                    {
                        Name = "Open",
                        Targets = new List<PotentialActionLink>()
                        {
                            new PotentialActionLink()
                            {
                                Value = "http://google.com"
                            }
                        }
                    }
                }
            };
            await client.PostMessageAsync(message).ConfigureAwait(false);
        }
    }
}

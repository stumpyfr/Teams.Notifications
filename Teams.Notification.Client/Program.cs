using System;
using System.Collections.Generic;

namespace Teams.Notifications.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "";
            var client = new TeamsNotificationClient(url);

            var message = new MessageCard();
            message.Title = "title";
            message.Text = "text";
            message.Color = "f0ad4e";
            message.Sections = new List<MessageSection>();
            message.Sections.Add(new MessageSection()
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
            });
            message.PotentialActions = new List<PotentialAction>();
            message.PotentialActions.Add(new PotentialAction()
            {
                Name = "Open",
                Targets = new List<PotentialActionLink>()
                {
                    new PotentialActionLink()
                    {
                        Value = "http://google.com"
                    }
                }
            });
            client.PostMessage(message).GetAwaiter().GetResult();

        }
    }
}

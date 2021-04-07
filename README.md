# Teams Notification

[![.NET Core CI](https://github.com/nogic1008/Teams.Notifications/actions/workflows/dotnetcore.yml/badge.svg)](https://github.com/nogic1008/Teams.Notifications/actions/workflows/dotnetcore.yml)
[![last commit](https://img.shields.io/github/last-commit/nogic1008/Teams.Notifications "last commit")](https://github.com/nogic1008/Teams.Notifications/commits/master)
[![codecov](https://codecov.io/gh/nogic1008/Teams.Notifications/branch/master/graph/badge.svg?token=jqYZoyBoYq)](https://codecov.io/gh/nogic1008/Teams.Notifications)
[![CodeFactor](https://www.codefactor.io/repository/github/nogic1008/teams.notifications/badge)](https://www.codefactor.io/repository/github/nogic1008/teams.notifications)
[![License](https://img.shields.io/github/license/nogic1008/Teams.Notifications)](LICENSE)

## Introduction

Library to easily send notification to Microsoft Teams channels.

## Code Samples

```csharp
var url = "<INSERT WEBHOOK URL HERE>";
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
```

## Installation

```console
dotnet add package Teams.Notifications
```

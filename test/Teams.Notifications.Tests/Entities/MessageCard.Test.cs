using System.Text.Json;
using Nogic.Teams.Notifications.Entities;

namespace Nogic.Teams.Notifications.Tests.Entities;

/// <summary>
/// Unit test for <see cref="MessageCard"/>
/// </summary>
public class MessageCardTest
{
    private const string Type = "\"@type\":\"MessageCard\"";
    private const string Context = "\"@context\":\"http://schema.org/extensions\"";

    [Fact]
    public void CanSerializeJSON()
    {
        // Arrange
        const string summary = "Summary";
        const string title = "Title";
        const string text = "Text";
        const string color = "FF0000";
        var sut = new MessageCard(
            Summary: summary,
            ThemeColor: color,
            Title: title,
            Text: text,
            Sections: Array.Empty<MessageSection>()
        );

        // Act
        string json = JsonSerializer.Serialize(sut, JsonConfig.Default);

        // Assert
        json.Should().Contain(Type)
            .And.Contain(Context)
            .And.Contain("\"summary\":\"" + summary + "\"")
            .And.Contain("\"title\":\"" + title + "\"")
            .And.Contain("\"text\":\"" + text + "\"")
            .And.Contain("\"themeColor\":\"" + color + "\"")
            .And.Contain("\"sections\":[]")
            .And.NotContain("\"potentialActions\":");
    }

    /// <summary>
    /// Test data for <see cref="CanDeserializeJson(string, MessageCard)"/>
    /// </summary>
    public static object[][] TestData => new[] {
        new object[]
        {
            "{" + Type + "," + Context + ",\"title\":\"Simple Message\",\"text\":\"Message Body\"}",
            new MessageCard(Title: "Simple Message", Text: "Message Body"),
        },
        new object[]
        {
            "{" + Type + "," + Context + ",\"summary\":\"Array is Empty\",\"title\":\"Empty Array\","
            + "\"text\":\"Message Body\",\"themeColor\":\"FF0000\","
            + "\"sections\":[],\"potentialAction\":[]}",
            new MessageCard(
                Summary: "Array is Empty",
                ThemeColor: "FF0000",
                Title: "Empty Array",
                Text: "Message Body",
                Sections: Array.Empty<MessageSection>(),
                PotentialActions: Array.Empty<OpenUriAction>()
            ),
        },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void CanDeserializeJson(string json, MessageCard expected)
    {
        // Arrange - Act
        var card = JsonSerializer.Deserialize<MessageCard>(json);

        // Assert
        card!.Title.Should().Be(expected.Title);
        card.Text.Should().Be(expected.Text);
        card.ThemeColor.Should().Be(expected.ThemeColor);

        if (expected.Sections is null)
        {
            card.Sections.Should().BeNull();
        }
        else
        {
            card.Sections.Should().HaveCount(expected.Sections.Count)
                .And.ContainInOrder(expected.Sections);
        }

        if (expected.PotentialActions is null)
        {
            card.PotentialActions.Should().BeNull();
        }
        else
        {
            card.PotentialActions.Should().HaveCount(expected.PotentialActions.Count)
                .And.ContainInOrder(expected.PotentialActions);
        }
    }
}

using System;
using System.Text.Json;
using FluentAssertions;
using Teams.Notifications.Entities;
using Xunit;

namespace Teams.Notifications.Tests.Entities
{
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
            const string title = "Title";
            const string text = "Text";
            const string color = "FF0000";
            var sut = new MessageCard(title, text, color, Sections: Array.Empty<MessageSection>());

            // Act
            string json = JsonSerializer.Serialize(sut, JsonConfig.Default);

            // Assert
            json.Should().Contain(Type)
                .And.Contain(Context)
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
                new MessageCard("Simple Message", "Message Body"),
            },
            new object[]
            {
                "{" + Type + "," + Context + ",\"title\":\"Empty Array\","
                + "\"text\":\"Message Body\",\"themeColor\":\"FF0000\","
                + "\"sections\":[],\"potentialAction\":[]}",
                new MessageCard("Empty Array", "Message Body", "FF0000", Array.Empty<MessageSection>(), Array.Empty<OpenUriAction>()),
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
}

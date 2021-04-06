using System;
using System.Text.Json;
using FluentAssertions;
using Nogic.Teams.Notifications.Entities;
using Xunit;

namespace Nogic.Teams.Notifications.Tests.Entities
{
    /// <summary>
    /// Unit test for <see cref="MessageSection"/>
    /// </summary>
    public class MessageSectionTest
    {
        [Fact]
        public void CanSerializeJson()
        {
            // Arrange
            const string title = "Title";
            var facts = new[]
            {
                new MessageFact("Key1", "Value1"),
                new MessageFact("Key2", "Value2"),
            };
            var sut = new MessageSection(title, facts);

            // Act
            string json = JsonSerializer.Serialize(sut, JsonConfig.Default);

            // Assert
            const string fact1 = "{\"name\":\"Key1\",\"value\":\"Value1\"}";
            const string fact2 = "{\"name\":\"Key2\",\"value\":\"Value2\"}";
            json.Should().Be("{\"title\":\"" + title + "\",\"facts\":[" + fact1 + "," + fact2 + "]}");
        }

        /// <summary>
        /// Test data for <see cref="CanDeserializeJson(string, MessageSection)"/>
        /// </summary>
        public static object[][] TestData => new[]
        {
            new object[] { "{}", new MessageSection() },
            new object[] { "{\"title\":\"Empty\",\"facts\":[]}", new MessageSection("Empty", Array.Empty<MessageFact>()) },
            new object[] { "{\"title\":\"Multiple\",\"facts\":["
                + "{\"name\":\"Name1\",\"value\":\"Value1\"},"
                + "{\"name\":\"Name2\",\"value\":\"Value2\"}]}",
                new MessageSection("Multiple", new MessageFact[] { new("Name1", "Value1"), new("Name2", "Value2") })
            },
        };
        [Theory]
        [MemberData(nameof(TestData))]
        public void CanDeserializeJson(string json, MessageSection expected)
        {
            // Arrange - Act
            var section = JsonSerializer.Deserialize<MessageSection>(json);

            // Assert
            section!.Title.Should().Be(expected.Title);
            if (expected.Facts is null)
                section.Facts.Should().BeNull();
            else
                section.Facts.Should().HaveCount(expected.Facts.Count).And.ContainInOrder(expected.Facts);
        }
    }
}

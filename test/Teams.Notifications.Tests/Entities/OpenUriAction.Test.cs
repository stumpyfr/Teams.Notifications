using System;
using System.Text.Json;
using FluentAssertions;
using Nogic.Teams.Notifications.Entities;
using Xunit;

namespace Nogic.Teams.Notifications.Tests.Entities
{
    /// <summary>
    /// Unit test for <see cref="OpenUriAction"/>
    /// </summary>
    public class OpenUriActionTest
    {
        private const string Type = "\"@type\":\"OpenUri\"";

        [Fact]
        public void CanSerializeJson()
        {
            // Arrange
            const string name = "Name";
            var targets = new[]
            {
                new OpenUriTarget("http://example.com/", "default"),
            };
            var sut = new OpenUriAction(name, targets);

            // Act
            string json = JsonSerializer.Serialize(sut, JsonConfig.Default);

            // Assert
            json.Should().Contain(Type)
                .And.Contain("\"name\":\"" + name + "\"")
                .And.Contain("\"targets\":[{\"uri\":\"http://example.com/\",\"os\":\"default\"}]");
        }

        /// <summary>
        /// Test data for <see cref="CanDeserializeJson(string, OpenUriAction)"/>
        /// </summary>
        public static object[][] TestData => new[] {
            new object[]
            {
                "{" + Type + ",\"name\":\"Empty\",\"targets\":[]}",
                new OpenUriAction("Empty", Array.Empty<OpenUriTarget>())
            },
            new object[]
            {
                "{" + Type + ",\"name\":\"Single\",\"targets\":[{\"os\":\"default\",\"uri\":\"http://example.com/\"}]}",
                new OpenUriAction("Single", new[] { new OpenUriTarget("http://example.com/", "default") })
            },
            new object[]
            {
                "{" + Type + ",\"name\":\"Multiple\",\"targets\":["
                    + "{\"os\":\"default\",\"uri\":\"http://example.com/\"},"
                    + "{\"os\":\"iOS\",\"uri\":\"http://example.com/ios/\"},"
                    + "{\"os\":\"android\",\"uri\":\"http://example.com/android/\"}"+ "]}",
                new OpenUriAction("Multiple", new OpenUriTarget[]
                {
                    new("http://example.com/", "default"),
                    new("http://example.com/ios/", "iOS"),
                    new("http://example.com/android/", "android"),
                })
            },
        };
        [Theory]
        [MemberData(nameof(TestData))]
        public void CanDeserializeJson(string json, OpenUriAction expected)
        {
            // Arrange - Act
            var action = JsonSerializer.Deserialize<OpenUriAction>(json);

            // Assert
            action!.Type.Should().Be(expected.Type);
            action.Name.Should().Be(expected.Name);
            action.Targets.Should().ContainInOrder(expected.Targets);
        }
    }
}

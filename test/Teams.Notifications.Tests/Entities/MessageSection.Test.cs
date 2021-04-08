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
            var sut = new MessageSection(
                Title: "Title",
                StartGroup: true,
                ActivityImage: "http://example.com/activity-image.png",
                ActivityTitle: "Activity Title",
                ActivitySubtitle: "2021/01/01 01:23:45",
                ActivityText: "Activity Body",
                HeroImage: new("http://example.com/hero-image.png", "Hero"),
                Facts: new MessageFact[]
                {
                    new ("Key1", "Value1"),
                    new ("Key2", "Value2"),
                },
                Images: new[] { new SectionImage("http://example.com/image.png", "Image") },
                PotentialActions: Array.Empty<OpenUriAction>()
            );

            // Act
            string json = JsonSerializer.Serialize(sut, JsonConfig.Default);

            // Assert
            json.Should().Contain("\"title\":\"Title\"")
                .And.Contain("\"startGroup\":true")
                .And.Contain("\"activityImage\":\"http://example.com/activity-image.png\"")
                .And.Contain("\"activityTitle\":\"Activity Title\"")
                .And.Contain("\"activitySubtitle\":\"2021/01/01 01:23:45\"")
                .And.Contain("\"activityText\":\"Activity Body\"")
                .And.Contain("\"heroImage\":{\"image\":\"http://example.com/hero-image.png\",\"title\":\"Hero\"}")
                .And.Contain("\"facts\":[{\"name\":\"Key1\",\"value\":\"Value1\"},{\"name\":\"Key2\",\"value\":\"Value2\"}]")
                .And.Contain("\"images\":[{\"image\":\"http://example.com/image.png\",\"title\":\"Image\"}]")
                .And.Contain("\"potentialAction\":[]");
        }

        /// <summary>
        /// Test data for <see cref="CanDeserializeJson(string, MessageSection)"/>
        /// </summary>
        public static object[][] TestData => new[]
        {
            new object[] { "{}", new MessageSection() },
            new object[]
            {
                "{\"title\":\"SimpleSection\",\"text\":\"Simple\"}",
                new MessageSection(Title: "SimpleSection", Text: "Simple")
            },
            new object[]
            {
                "{\"title\":\"All\","
                + "\"startGroup\":true,"
                + "\"activityImage\":\"http://example.com/activity-image.png\","
                + "\"activityTitle\":\"Activity Title\","
                + "\"activitySubtitle\":\"2021/01/01 01:23:45\","
                + "\"activityText\":\"Activity Body\","
                + "\"heroImage\":{\"image\":\"http://example.com/hero-image.png\",\"title\":\"Hero\"},"
                + "\"facts\":[{\"name\":\"Name1\",\"value\":\"Value1\"},{\"name\":\"Name2\",\"value\":\"Value2\"}],"
                + "\"images\":[{\"image\":\"http://example.com/image.png\",\"title\":\"Image\"}],"
                + "\"potentialAction\":[]}",
                new MessageSection(
                    Title: "All",
                    StartGroup: true,
                    ActivityImage: "http://example.com/activity-image.png",
                    ActivityTitle: "Activity Title",
                    ActivitySubtitle: "2021/01/01 01:23:45",
                    ActivityText: "Activity Body",
                    HeroImage: new("http://example.com/hero-image.png", "Hero"),
                    Facts: new MessageFact[] { new("Name1", "Value1"), new("Name2", "Value2") },
                    Images: new[] { new SectionImage("http://example.com/image.png", "Image") },
                    PotentialActions: Array.Empty<OpenUriAction>()
                )
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
            section.StartGroup.Should().Be(expected.StartGroup);
            section.ActivityImage.Should().Be(expected.ActivityImage);
            section.ActivityTitle.Should().Be(expected.ActivityTitle);
            section.ActivitySubtitle.Should().Be(expected.ActivitySubtitle);
            section.ActivityText.Should().Be(expected.ActivityText);
            section.HeroImage.Should().Be(expected.HeroImage);
            if (expected.Facts is null)
                section.Facts.Should().BeNull();
            else
                section.Facts.Should().HaveCount(expected.Facts.Count).And.ContainInOrder(expected.Facts);
            if (expected.Images is null)
                section.Images.Should().BeNull();
            else
                section.Images.Should().HaveCount(expected.Images.Count).And.ContainInOrder(expected.Images);
            if (expected.PotentialActions is null)
                section.PotentialActions.Should().BeNull();
            else
                section.PotentialActions.Should().HaveCount(expected.PotentialActions.Count).And.ContainInOrder(expected.PotentialActions);
        }
    }
}

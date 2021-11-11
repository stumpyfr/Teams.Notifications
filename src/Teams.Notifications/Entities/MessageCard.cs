using System.Text.Json.Serialization;

namespace Nogic.Teams.Notifications.Entities;

/// <summary>
/// Entity class for Microsoft Teams message.
/// https://docs.microsoft.com/outlook/actionable-messages/message-card-reference#card-fields
/// </summary>
public record MessageCard(
    /// <summary>
    /// Required if <see cref="Text"/> is <c>null</c>, otherwise optional.
    /// This is typically displayed in the list view in Outlook, as a way to quickly determine what the card is all about.
    /// </summary>
    /// <remarks>
    /// **Do** always include a summary.
    /// **Don't** include details in the summary.
    /// For example, for a Twitter post, a summary might simply read "New tweet from @someuser" without mentioning the content of the tweet itself.
    /// </remarks>
    [property: JsonPropertyName("summary")] string? Summary = null,
    /// <summary>
    /// Specifies a custom brand color for the card.
    /// The color will be displayed in a non-obtrusive manner.
    /// </summary>
    /// <remarks>
    /// **Do** use this to brand cards to your color.
    /// **Don't** use this to indicate status.
    /// </remarks>
    [property: JsonPropertyName("themeColor")] string? ThemeColor = null,
    /// <summary>
    /// This is meant to be rendered in a prominent way, at the very top of the card.
    /// Use it to introduce the content of the card in such a way users will immediately know what to expect.
    /// </summary>
    /// <example>
    /// Daily news
    /// New bug opened
    /// Task <name of task> assigned
    /// </example>
    /// <remarks>
    /// **Do** keep title short, don't make it a long sentence.
    /// **Do** mention the name of the entity being referenced in the title.
    /// **Don't** use hyperlinks (via Markdown) in the title.
    /// </remarks>
    [property: JsonPropertyName("title")] string? Title = null,
    /// <summary>
    /// Required if <see cref="Summary"/> is <c>null</c>, otherwise optional.
    /// This is meant to be displayed in a normal font below the card's title.
    /// Use it to display content, such as the description of the entity being referenced, or an abstract of a news article.
    /// </summary>
    /// <remarks>
    /// **Do** use simple Markdown, such as bold or italics to emphasize words, and links to external resources.
    /// **Don't** include any call to action in the text property.
    /// Users should be able to not read it and still understand what the card is all about.
    /// </remarks>
    [property: JsonPropertyName("text")] string? Text = null,
    /// <summary>
    /// A collection of sections to include in the card.
    /// <seealso cref="MessageSection"/>
    /// </summary>
    [property: JsonPropertyName("sections")] IList<MessageSection>? Sections = null,
    /// <summary>
    /// A collection of actions that can be invoked on this card.
    /// <seealso cref="OpenUriAction"/>
    /// </summary>
    [property: JsonPropertyName("potentialAction")] IList<OpenUriAction>? PotentialActions = null
)
{
    [JsonPropertyName("@type")]
    public string Type => "MessageCard";

    [JsonPropertyName("@context")]
    public string Context => "http://schema.org/extensions";
}

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Nogic.Teams.Notifications.Entities
{
    /// <summary>
    /// Entity class for <see cref="MessageCard.Sections"/>
    /// https://docs.microsoft.com/outlook/actionable-messages/message-card-reference#section-fields
    /// </summary>
    public record MessageSection(
        /// <summary>
        /// This is displayed in a font that stands out while not as prominent as <see cref="MessageCard.Title"/>.
        /// It is meant to introduce the section and summarize its content, similarly to how <see cref="MessageCard.Title"/> is meant to summarize the whole card.
        /// </summary>
        /// <remarks>
        /// **Do** keep title short, don't make it a long sentence.
        /// **Do** mention the name of the entity being referenced in the title.
        /// **Don't** use hyperlinks (via Markdown) in the title.
        /// </remarks>
        [property: JsonPropertyName("title")] string? Title = null,
        /// <summary>
        /// When set to <c>true</c>, this marks the start of a logical group of information.
        /// Typically, <see cref="StartGroup"/> set to <c>true</c> will be visually separated from previous card elements.
        /// For example, Outlook uses a subtle horizontal separation line.
        /// </summary>
        [property: JsonPropertyName("startGroup")] bool? StartGroup = null,
        /// <summary>
        /// Forms a logical group.
        /// <see cref="ActivityTitle"/>, <see cref="ActivitySubtitle"/> and <see cref="ActivityText"/> will be displayed alongside <see cref="ActivityImage"/>,
        /// using a layout appropriate for the form factor of the device the card is being viewed on.
        /// For instance, in Outlook on the Web, <see cref="ActivityTitle"/>, <see cref="ActivitySubtitle"/> and <see cref="ActivityText"/> are displayed on the right of <see cref="ActivityImage"/>, using a two-column layout.
        /// </summary>
        /// <remarks>
        /// Use the activity fields for scenarios such as:
        /// - Someone did something
        ///   - Use <see cref="ActivityImage"/> to display the picture of that person.
        /// - A news article abstract
        ///   - Use <see cref="ActivityImage"/> to display the picture associated with the article
        /// </remarks>
        [property: JsonPropertyName("activityImage")] string? ActivityImage = null,
        /// <summary>
        /// Forms a logical group.
        /// <see cref="ActivityTitle"/>, <see cref="ActivitySubtitle"/> and <see cref="ActivityText"/> will be displayed alongside <see cref="ActivityImage"/>,
        /// using a layout appropriate for the form factor of the device the card is being viewed on.
        /// For instance, in Outlook on the Web, <see cref="ActivityTitle"/>, <see cref="ActivitySubtitle"/> and <see cref="ActivityText"/> are displayed on the right of <see cref="ActivityImage"/>, using a two-column layout.
        /// </summary>
        /// <remarks>
        /// Use the activity fields for scenarios such as:
        /// - Someone did something
        ///   - Use <see cref="ActivityTitle"/> to summarize what they did. Make it short and to the point.
        /// </remarks>
        [property: JsonPropertyName("activityTitle")] string? ActivityTitle = null,
        /// <summary>
        /// Forms a logical group.
        /// <see cref="ActivityTitle"/>, <see cref="ActivitySubtitle"/> and <see cref="ActivityText"/> will be displayed alongside <see cref="ActivityImage"/>,
        /// using a layout appropriate for the form factor of the device the card is being viewed on.
        /// For instance, in Outlook on the Web, <see cref="ActivityTitle"/>, <see cref="ActivitySubtitle"/> and <see cref="ActivityText"/> are displayed on the right of <see cref="ActivityImage"/>, using a two-column layout.
        /// </summary>
        /// <remarks>
        /// Use the activity fields for scenarios such as:
        /// - Someone did something
        ///   - Use <see cref="ActivitySubtitle"/> to show, for instance, the date and time the action was taken, or the person's handle.
        ///     - <see cref="ActivitySubtitle"/> will be rendered in a more subdued font
        ///     - **Don't** include essential information
        ///     - **Don't** include calls to action
        ///     - **Avoid** Markdown formatting
        /// - A news article abstract
        ///   - Use <see cref="ActivitySubtitle"/> to display the date and time the article was originally posted
        /// </remarks>
        [property: JsonPropertyName("activitySubtitle")] string? ActivitySubtitle = null,
        /// <summary>
        /// Forms a logical group.
        /// <see cref="ActivityTitle"/>, <see cref="ActivitySubtitle"/> and <see cref="ActivityText"/> will be displayed alongside <see cref="ActivityImage"/>,
        /// using a layout appropriate for the form factor of the device the card is being viewed on.
        /// For instance, in Outlook on the Web, <see cref="ActivityTitle"/>, <see cref="ActivitySubtitle"/> and <see cref="ActivityText"/> are displayed on the right of <see cref="ActivityImage"/>, using a two-column layout.
        /// </summary>
        /// <remarks>
        /// Use the activity fields for scenarios such as:
        /// - Someone did something
        ///   - Use <see cref="ActivityText"/> to provide details about the activity.
        ///     - **Do** use simple Markdown to emphasize words or link to external sources
        ///     - **Don't** include calls to action
        /// - A news article abstract
        ///   - Use <see cref="ActivityText"/> to display the actual abstract
        /// </remarks>
        [property: JsonPropertyName("activityText")] string? ActivityText = null,
        /// <summary>
        /// Use this to make an image the centerpiece of your card.
        /// </summary>
        [property: JsonPropertyName("heroImage")] SectionImage? HeroImage = null,
        /// <summary>
        /// This is very similar to <see cref="MessageCard.Text"/>. It can be used for the same purpose.
        /// </summary>
        [property: JsonPropertyName("text")] string? Text = null,
        /// <summary>
        /// They are a very important component of a section.
        /// They often contain the information that really matters to the user.
        /// <para>
        /// Facts are displayed in such a way that they can be read quickly and efficiently.
        /// For example, in Outlook on the Web, facts are presented in a two-column layout, with <see cref="MessageFact.Name"/> rendered in a slightly more prominent font:
        /// </para>
        /// </summary>
        /// <remarks>
        /// **Do** use them instead of embedding important information inside <see cref="Text"/> or <see cref="MessageCard.Text"/>.
        /// **Do** keep <see cref="MessageFact.Name"/> short.
        /// **Avoid** making <see cref="MessageFact.Value"/> too long.
        /// **Avoid** using Markdown formatting for both <see cref="MessageFact.Name"/> and <see cref="MessageFact.Value"/>.
        /// Let facts be rendered as intended as that is how they will have the most impact.
        /// **Do** however use Markdown for links in <see cref="MessageFact.Value"/> only.
        /// For instance, if a fact references an external document, make the value of that fact a link to the document.
        /// **Don't** add a fact without a real purpose.
        /// For instance, a fact that would always have the same value across all cards is not interesting and a waste of space.
        /// </remarks>
        [property: JsonPropertyName("facts")] IList<MessageFact>? Facts = null,
        /// <summary>
        /// This allows for the inclusion of a photo gallery inside a section.
        /// That photo gallery will always be displayed in a way that is easy to consume regardless of the form factor of the device it is being viewed on.
        /// </summary>
        [property: JsonPropertyName("images")] IList<SectionImage>? Images = null,
        /// <summary>
        /// A collection of actions that can be invoked on this section.
        /// <seealso cref="OpenUriAction"/>
        /// </summary>
        [property: JsonPropertyName("potentialAction")] IList<OpenUriAction>? PotentialActions = null
    )
    { }

    /// <summary>
    /// Defines an image as used by <see cref="MessageSection.HeroImage"/> and <see cref="MessageSection.Images"/>.
    /// https://docs.microsoft.com/outlook/actionable-messages/message-card-reference#image-object
    /// </summary>
    public record SectionImage(
        /// <summary>
        /// The URL to the image.
        /// </summary>
        [property: JsonPropertyName("image")] string Image,
        /// <summary>
        /// A short description of the image.
        /// Typically, it is displayed in a tooltip as the user hovers their mouse over the image.
        /// </summary>
        [property: JsonPropertyName("title")] string Title
    )
    { }

    /// <summary>
    /// Contains the information that really matters to the user.
    /// </summary>
    public record MessageFact(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("value")] string Value
    )
    { }
}

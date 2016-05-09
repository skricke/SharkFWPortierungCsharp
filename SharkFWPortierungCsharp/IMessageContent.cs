using System.Collections.Generic;

namespace Shark.ASIP {
  /// <summary>
  ///   Containing content information of a shark message. It can be signed separated from the whole message.
  /// </summary>
  public interface IMessageContent {
    /// <summary>
    ///   The logical sender of the content.
    /// </summary>
    IPeerSemanticTag LogicalSender { get; set; }
    /// <summary>
    ///   Marks the content as signed with a seperate signature or not.
    /// </summary>
    bool Signed { get; set; }
    /// <summary>
    ///   The commands insert, expose or raw are available for any message.
    /// </summary>
    ASIPCommand Command { get; set; }
    /// <summary>
    ///   The real content with information like knowledges or interests. Raw formated text is also possible.
    /// </summary>
    IEnumerable<IASIPContent> Content { get; }
    /// <summary>
    ///   The signature of the message content to confirm the contents authencity.
    /// </summary>
    IMessageSignature signature { get; set; }

    /// <summary>
    ///   Adds new content to the enumeration of ASIPContents.
    /// </summary>
    /// <param name="newContent">The new Content to be add to the enumeration of contents.</param>
    void addContent(IASIPContent newContent);
    /// <summary>
    ///   Remove the given content from the enumeration of given contents, if found. If not found nothing happens.
    /// </summary>
    /// <param name="content">The content to be removed.</param>
    void removeContent(IASIPContent content);
  }
}
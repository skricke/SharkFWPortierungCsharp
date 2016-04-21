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
    ASIPCommand Command { get; }
    /// <summary>
    ///   The real content with information like knowledges or interests. Raw formated text is also possible.
    /// </summary>
    IEnumerable<ASIPContent> Content { get; }
    /// <summary>
    ///   The signature of the message content to confirm the contents authencity.
    /// </summary>
    IMessageSignature signature { get; set; }
  }
}
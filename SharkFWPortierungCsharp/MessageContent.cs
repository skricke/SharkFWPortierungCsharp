using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  class MessageContent : IMessageContent {
    /// <summary>
    ///   The logical sender of the content.
    /// </summary>
    public IPeerSemanticTag LogicalSender { get; set; }
    /// <summary>
    ///   Marks the content as signed with a seperate signature or not.
    /// </summary>
    public bool Signed { get; set; }
    /// <summary>
    ///   The commands insert, expose or raw are available for any message.
    /// </summary>
    public ASIPCommand Command { get; set; }
    /// <summary>
    ///   The real content with information like knowledges or interests. Raw formated text is also possible.
    /// </summary>
    public IList<IASIPContent> Content { get; }
    /// <summary>
    ///   The signature of the message content to confirm the contents authencity.
    /// </summary>
    public IMessageSignature Signature { get; set; }

    public MessageContent(IPeerSemanticTag logicalSender, bool signed, ASIPCommand command, 
                          IList<IASIPContent> content, IMessageSignature signature) {
      LogicalSender = logicalSender;
      Signed = signed;
      Command = command;
      Content = content;
      Signature = signature;

    }

    /// <summary>
    ///   Adds new content to the enumeration of ASIPContents.
    /// </summary>
    /// <param name="newContent">The new Content to be add to the enumeration of contents.</param>
    public void addContent(IASIPContent newContent) {
      Content.Add(newContent);
    }
    /// <summary>
    ///   Remove the given content from the enumeration of given contents, if found. If not found nothing happens.
    /// </summary>
    /// <param name="content">The content to be removed.</param>
    public void removeContent(IASIPContent content) {
      Content.Remove(content);
    }
  }
}

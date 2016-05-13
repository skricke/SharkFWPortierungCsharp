using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  public class OutMessage : Message, IOutMessage {
    /// <summary>
    ///   The header of the message with meta data for used version, format, sender/receiver, encryption and signature.
    /// </summary>
    public IMessageHeader Header { get; }
    /// <summary>
    ///   Content with logical sender, seperate signature (optional) and the real content in form of insertion, exposing or the raw data.
    /// </summary>
    public IOutMessageContent Content { get; }
    /// <summary>
    ///   The signature of the message.
    /// </summary>
    public IMessageSignature Signature { get; }

    //private OutMessage() { }

    public OutMessage(IMessageHeader head, IOutMessageContent content) {
      Header = head;
      Content = content;
      Signature = null;
    }

    public OutMessage(IMessageHeader head, IOutMessageContent content, IMessageSignature signature) : this(head, content) {
      Signature = signature;

    }
  }
}

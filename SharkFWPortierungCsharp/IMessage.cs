using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  /// <summary>
  ///   The messages wich shark sends and receives between peers for exchanging knowledges or exposing interests.
  /// </summary>
  public interface IMessage {
    // TODO cmd / unit ?? (online bnf)
    /// <summary>
    ///   The header of the message with meta data for used version, format, sender/receiver, encryption and signature.
    /// </summary>
    IMessageHeader Header { get; }
    /// <summary>
    ///   Content with logical sender, seperate signature (optional) and the real content in form of insertion, exposing or the raw data.
    /// </summary>
    IMessageContent Content { get; }
    /// <summary>
    ///   The signature of the message.
    /// </summary>
    IMessageSignature Signature { get; }
  }
}

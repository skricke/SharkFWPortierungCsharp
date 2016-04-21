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
    IMessageHeader Header { get; }
    IMessageContent Content { get; }
    IMessageSignature Signature { get; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  public interface IOutMessageContent : IMessageContent {
    new IList<IInterest> Content { get; }

    //private OutMessageContent() { }
    //public OutMessageContent(IPeerSemanticTag logicalSender, bool signed, ASIPCommand command,
    //                      IInterest content, IMessageSignature signature) {
    //  LogicalSender = logicalSender;
    //  Signed = signed;
    //  Command = command;
    //  Content = new List<IInterest>();
    //  Content.Add(content);
    //  Signature = signature;
    //}

    //public OutMessageContent(IPeerSemanticTag logicalSender, bool signed, ASIPCommand command,
    //                      IList<IInterest> content, IMessageSignature signature) {
    //  LogicalSender = logicalSender;
    //  Signed = signed;
    //  Command = command;
    //  Content = content;
    //  Signature = signature;
    //}
  }
}

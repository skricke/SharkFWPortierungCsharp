using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  public interface IInMessageContent : IMessageContent {
    new IList<IKnowledge> Content { get; }

    //private InMessageContent() { }
    //public InMessageContent(IPeerSemanticTag logicalSender, bool signed, ASIPCommand command,
    //                      IKnowledge content, IMessageSignature signature) {
    //  LogicalSender = logicalSender;
    //  Signed = signed;
    //  Command = command;
    //  Content = new List<IKnowledge>();
    //  Content.Add(content);
    //  Signature = signature;
    //}

    //public InMessageContent(IPeerSemanticTag logicalSender, bool signed, ASIPCommand command,
    //                      IList<IKnowledge> content, IMessageSignature signature) {
    //  LogicalSender = logicalSender;
    //  Signed = signed;
    //  Command = command;
    //  Content = content;
    //  Signature = signature;
    //}
  }
}

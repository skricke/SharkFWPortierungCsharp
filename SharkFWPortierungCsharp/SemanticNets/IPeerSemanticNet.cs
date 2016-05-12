using System.Collections.Generic;

namespace Shark.ASIP {
  public interface IPeerSemanticNet : ISemanticNet {
    /// <summary>
    ///   The PeerSemanticTag represents the nodes in the semantic net. Each tag is related to a semanticTagId.
    /// </summary>
    new IDictionary<string, IPeerSemanticTag> SemanticTagsTable { get; set; }
  }
}

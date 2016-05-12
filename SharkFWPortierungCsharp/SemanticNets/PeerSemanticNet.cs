using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticNets {
  public class PeerSemanticNet : SemanticNet, IPeerSemanticNet {
    /// <summary>
    ///   The PeerSemanticTag represents the nodes in the semantic net. Each tag is related to a semanticTagId.
    /// </summary>
    public new IDictionary<string, IPeerSemanticTag> SemanticTagsTable { get; set; }

    public PeerSemanticNet() {
      SemanticTagsTable = new Dictionary<string, IPeerSemanticTag>();
    }
  }
}

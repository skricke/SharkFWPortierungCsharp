using System.Collections.Generic;

namespace Shark.ASIP {
  interface IPeerSemanticNet : ISemanticNet {
    /// <summary>
    ///   The PeerSemanticTag represents the node in the peer semantic net.
    /// </summary>
    new IPeerSemanticTag SemanticTag { get; set; }
  }
}

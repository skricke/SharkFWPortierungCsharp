using System.Collections.Generic;

namespace Shark.ASIP {
  interface ISpatialSemanticNet : ISemanticNet {
    /// <summary>
    ///   The SpatialSemanticTag represents the node in the spatial semantic net.
    /// </summary>
    new ISpatialSemanticTag SemanticTag { get; set; }
  }
}

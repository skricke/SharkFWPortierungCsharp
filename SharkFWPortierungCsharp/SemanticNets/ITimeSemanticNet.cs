using System.Collections.Generic;

namespace Shark.ASIP {
  interface ITimeSemanticNet : ISemanticNet {
    /// <summary>
    ///   The TimeSemanticTag represents the node in the time semantic net.
    /// </summary>
    new ITimeSemanticTag SemanticTag { get; set; }
  }
}

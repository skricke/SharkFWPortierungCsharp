using System.Collections.Generic;

namespace Shark.ASIP {
  interface ISpatialSemanticNet : ISemanticNet {
    /// <summary>
    ///   The SpatialSemanticTag represents the nodes in the semantic net. Each tag is related to a semanticTagId.
    /// </summary>
    new IDictionary<string, ISpatialSemanticTag> SemanticTagsTable { get; set; }
  }
}

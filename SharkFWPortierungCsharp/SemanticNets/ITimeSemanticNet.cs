using System.Collections.Generic;

namespace Shark.ASIP {
  public interface ITimeSemanticNet : ISemanticNet {
    /// <summary>
    ///   The TimeSemanticTag represents the nodes in the semantic net. Each tag is related to a semanticTagId.
    /// </summary>
    new IDictionary<string, ITimeSemanticTag> SemanticTagsTable { get; set; }
  }
}

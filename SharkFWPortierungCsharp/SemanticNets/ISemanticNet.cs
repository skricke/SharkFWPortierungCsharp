using System.Collections.Generic;

namespace Shark.ASIP {
  /// <summary>
  ///   Organizes Semantic Tags like a net. The tags can be set in relationship to each other. Every relationship contans two IDs of the associated SemanticTags.
  /// </summary>
  interface ISemanticNet {
    /// <summary>
    /// 
    /// </summary>
    string SemanticTagId { get; set; }
    /// <summary>
    ///   The SemanticTag represents the node in the semantic net.
    /// </summary>
    ISemanticTag SemanticTag { get; set; }
    /// <summary>
    ///   The relations between the Tags.
    /// </summary>
    IEnumerable<IProperty> Relations { get; }

    /// <summary>
    ///   Adds a new association between two Semantic Tags.
    /// </summary>
    /// <param name="property"> The associated relationship.</param>
    void addRelation(IProperty property);
    /// <summary>
    ///   Removes an association if found in Relations or does nothing.
    ///   If two equal properties exist in the Relations only the first hit will be removed.
    /// </summary>
    /// <param name="property">The relation to be removed.</param>
    void removeRelation(IProperty property);

  }
}

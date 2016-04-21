namespace Shark.ASIP {
  /// <summary>
  /// A Property contains a directed relationship between two SemanticTags, which are represented by their ID.
  /// </summary>
  public interface IProperty {
    /// <summary>
    ///   The name of the property relationship.
    /// </summary>
    string Name { get; set; }
    /// <summary>
    ///   The first ID of the source SemanticTag.
    /// </summary>
    string SourceId { get; set; }
    /// <summary>
    /// The second ID pointing to the target SemanticTag.
    /// </summary>
    string TargetId { get; set; }
  }
}
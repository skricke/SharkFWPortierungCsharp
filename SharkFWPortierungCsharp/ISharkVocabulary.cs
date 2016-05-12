namespace Shark.ASIP {
  /// <summary>
  ///   In a shark vocabulary all semantic tags defined by one peer are summarized. Each SemanticTag represents something and is described 
  ///   by its subject identifier.
  /// </summary>
  public interface ISharkVocabulary {
    /// <summary>
    ///   Contains the Semantic tags connected in a semantic net to represent the topic dimension.
    /// </summary>
    ISemanticNet TopicDim { get; }
    /// <summary>
    ///   Contains the Semantic tags connected in a semantic net to represent the type dimension.
    /// </summary>
    ISemanticNet TypeDim { get; }
    /// <summary>
    ///   Contains the peer semantic tags connected in a semantic net to represent the peers.
    /// </summary>
    IPeerSemanticNet PeerDim { get; }
    /// <summary>
    ///   Contains the SpatialSemanticTags connected in a semantic net to represent the Location dimension.
    /// </summary>
    ISpatialSemanticNet LocationDim { get; }
    /// <summary>
    ///   Contains the TimeSemanticTags connected in a semantic net to represent the time dimension.
    /// </summary>
    ITimeSemanticNet TimeDim { get; }
  }
}
namespace Shark.ASIP {
  /// <summary>
  ///   In a shark vocabulary all semantic tags defined by one peer are summarized. Each SemanticTag represents something and is described 
  ///   by its subject identifier.
  /// </summary>
  public interface ISharkVocabulary {
    // TODO vocabulary              = '{' 
    ISemanticNet TopicDim { get; }
    ISemanticNet TypeDim { get; }
    IPeerSemanticNet PeerDim { get; }
    ISpatialSemanticNet LocationDim { get; }
    ITimeSemanticNet TimeDim { get; }
    //### VOCABULARY ###
    //
    //topicDim                = semanticNet ;
    //typeDim                 = semanticNet ;
    //peerDim                 = peerSemanticTagNet ;
    //locationDim             = spatialSemanticTagNet ;
    //timeDim                 = timeSemanticTagNet ;
  }
}
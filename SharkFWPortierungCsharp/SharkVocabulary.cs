using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  /// <summary>
  ///   Implements the Interface. In a shark vocabulary all semantic tags defined by one peer are summarized. Each SemanticTag represents something and is described 
  ///   by its subject identifier.
  /// </summary>
  /// <see cref="ISharkVocabulary"/>
  public class SharkVocabulary : ISharkVocabulary {
    /// <summary>
    ///   Contains the Semantic tags connected in a semantic net to represent the topic dimension.
    /// </summary>
    public ISemanticNet TopicDim { get; }
    /// <summary>
    ///   Contains the Semantic tags connected in a semantic net to represent the type dimension.
    /// </summary>
    public ISemanticNet TypeDim { get; }
    /// <summary>
    ///   Contains the peer semantic tags connected in a semantic net to represent the peers.
    /// </summary>
    public IPeerSemanticNet PeerDim { get; }
    /// <summary>
    ///   Contains the SpatialSemanticTags connected in a semantic net to represent the Location dimension.
    /// </summary>
    public ISpatialSemanticNet LocationDim { get; }
    /// <summary>
    ///   Contains the TimeSemanticTags connected in a semantic net to represent the time dimension.
    /// </summary>
    public ITimeSemanticNet TimeDim { get; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticNets {
  public class SpatialSemanticNet : SemanticNet, ISpatialSemanticNet {
    /// <summary>
    ///   The SpatialSemanticTag represents the nodes in the semantic net. Each tag is related to a semanticTagId.
    /// </summary>
    public new IDictionary<string, ISpatialSemanticTag> SemanticTagsTable { get; set; }
  }
}

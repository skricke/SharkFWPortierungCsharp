﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticNets {
  public class TimeSemanticNet : SemanticNet, ITimeSemanticNet {
    /// <summary>
    ///   The TimeSemanticTag represents the nodes in the semantic net. Each tag is related to a semanticTagId.
    /// </summary>
    public new IDictionary<string, ITimeSemanticTag> SemanticTagsTable { get; set; }

    public TimeSemanticNet() {
      SemanticTagsTable = new Dictionary<string, ITimeSemanticTag>();
    }
  }
}

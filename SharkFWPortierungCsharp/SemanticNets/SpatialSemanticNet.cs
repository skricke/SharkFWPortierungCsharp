using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticNets {
  class SpatialSemanticNet : SemanticNet, ISpatialSemanticNet {
    ISpatialSemanticTag ISpatialSemanticNet.SemanticTag { get; set; }
  }
}

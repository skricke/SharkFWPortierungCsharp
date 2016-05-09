using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticNets {
  class TimeSemanticNet : SemanticNet, ITimeSemanticNet {
    ITimeSemanticTag ITimeSemanticNet.SemanticTag { get; set; }
  }
}

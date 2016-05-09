using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticNets {
  class PeerSemanticNet : SemanticNet, IPeerSemanticNet {
    IPeerSemanticTag IPeerSemanticNet.SemanticTag { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  class InfoSpace : Interest, IInfoSpace {
    //private InfoSpace() { }
    public InfoSpace(Directions direction) : base(direction) { }

    public InfoSpace(ISemanticTagSet topics, ISemanticTagSet types, IList<IPeerSemanticTag> approvers, IPeerSemanticTag sender,
                    IList<IPeerSemanticTag> recipients, IList<ISpatialSemanticTag> locations, IList<ITimeSemanticTag> times, Directions direction) :
                    base(topics, types, approvers, sender, recipients, locations, times, direction) { }
  }
}

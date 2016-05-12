using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  public class InformationData : IInformationData {
    public IInfoSpace InfoSpace { get; }
    public IInfoMetaData MetaInfos { get; }

    public InformationData(IInfoSpace space, IInfoMetaData meta) {
      InfoSpace = space;
      MetaInfos = meta;
    }
  }
}

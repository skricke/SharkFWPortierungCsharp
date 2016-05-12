using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  public class Information : IInformation {
    public IInformationData InfoData { get; }
    public byte InfoContent { get; set; }

    public Information(IInformationData data, byte content) {
      InfoData = data;
      InfoContent = content;
    }
  }
}

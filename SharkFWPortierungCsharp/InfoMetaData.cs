using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  class InfoMetaData : IInfoMetaData {
    public string Name { get; set; }
    public uint Offset { get; set; }
    public uint Length { get; set; }

    public InfoMetaData(string name, uint offset, uint length) {
      Name = name;
      Offset = offset;
      Length = length;
    }
  }
}

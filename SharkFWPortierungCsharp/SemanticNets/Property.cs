using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticNets {
  public class Property : IProperty {
    public string Name { get; set; }
    public string SourceId { get; set; }
    public string TargetId { get; set; }

    public Property(string relationName, string sourceID, string targetID) {
      Name = relationName;
      SourceId = sourceID;
      TargetId = targetID;
    }

  }
}

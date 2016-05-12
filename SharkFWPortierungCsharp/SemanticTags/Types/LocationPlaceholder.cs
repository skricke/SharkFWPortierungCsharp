using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticTags.Types {
  public class LocationPlaceholder : ILocation {
    string Name { get; set; }

    public LocationPlaceholder(string locationName) {
      Name = locationName;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticTags {
  class SpatialSemanticTag : SemanticTag, ISpatialSemanticTag {
    /// <summary> Location Property returns spatial information.
    ///           Locations are described via WKT. </summary>
    /// <see href="http://docs.opengeospatial.org/is/12-063r5/12-063r5.html"/>
    /// <value> The locations. </value>
    public IList<ILocation> Locations { get; }

    public SpatialSemanticTag(string name, IList<string> siList) : base(name, siList) {

    }

    public SpatialSemanticTag(string name, IList<string> siList, IList<ILocation> locations) : this(name, siList) {
      Locations = locations;
    }
    // TODO add and remove Location geometry with WKT-Support
    /// <summary>
    ///   Adds a location to the property of Locations.
    /// </summary>
    public void addLocation(ILocation newLocation) {
      Locations.Add(newLocation);
    }

    /// <summary>
    ///   Removes the Location on the given index.
    /// </summary>
    /// <param name="index">The index of the location, which will be deleted.</param>
    /// <exception cref="SharkASIPIllegalArguementException"> Thrown if index out of bound. </exception>
    public void removeLocation(int index) {
      Locations.RemoveAt(index);
    }
  }
}

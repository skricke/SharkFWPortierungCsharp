using System.Collections.Generic;

namespace Shark {
  namespace ASIP {

    /// <summary> Interface for spatial semantic tag for describing locations. </summary>
    /// 
    /// Information or information request can be location based. A SpatialSemanticTag can describe locations. 
    /// WKT (well known text) is supported by Shark Framework.
    /// <see href="http://docs.opengeospatial.org/is/12-063r5/12-063r5.html"/>
    /// 
    /// <remarks> sk, 15.03.2016. </remarks>
    public interface ISpatialSemanticTag : ISemanticTag {

      /// <summary> Location Property returns spatial information.
      ///           Locations are described via WKT. </summary>
      /// <see href="http://docs.opengeospatial.org/is/12-063r5/12-063r5.html"/>
      /// <value> The locations. </value>
      IList<Location> Locations { get; }

      // TODO add and remove Location geometry with WKT-Support
      void addLocation();
      void removeLocation();
    }
  }
}
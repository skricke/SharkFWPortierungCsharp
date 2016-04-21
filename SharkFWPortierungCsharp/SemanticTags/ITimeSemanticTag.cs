﻿using Shark.ASIP.SemanticTags;
using System.Collections.Generic;

namespace Shark {
  namespace ASIP {

    /// <summary> Time semantic tags extends a semantic tag with time parameter(s). 
    ///           It describes in which period of time an information has its validity. </summary>
    ///
    /// <remarks> sk, 15.03.2016. </remarks>
    public interface ITimeSemanticTag : ISemanticTag {

      /// <summary> Property for valid times of an TimeSemanticTag. </summary>
      ///
      /// <value> The times in between the SemanticTag is valid. </value>
      IList<Time> Times { get; }

      // TODO add and remove Location times
      void addTime();
      void removeTime();
    }
  }
}
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
      IList<ITime> Times { get; }

      // TODO add and remove Location times
      /// <summary>
      ///   Adds a valid time period.
      /// </summary>
      void addTime(ITime time);

      /// <summary>
      ///   Remove time data on the given index.
      /// </summary>
      /// <param name="index">The index of the time in the list.</param>
      /// <exception cref="SharkASIPIllegalArguementException"> Thrown if index out of bound. </exception>
      void removeTime(int index);
    }
  }
}
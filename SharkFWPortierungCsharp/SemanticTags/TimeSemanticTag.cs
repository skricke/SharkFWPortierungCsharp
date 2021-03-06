﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticTags {
  public class TimeSemanticTag : SemanticTag, ITimeSemanticTag {
    /// <summary> Property for valid times of an TimeSemanticTag. </summary>
    ///
    /// <value> The times in between the SemanticTag is valid. </value>
    public IList<ITime> Times { get; }

    public TimeSemanticTag(string name, IList<string> siList) : base(name, siList) { }
    public TimeSemanticTag(string name, IList<string> siList, IList<ITime> times) : this(name, siList) {
      Times = times;
    }

    public TimeSemanticTag(string name, string si, ITime time) : base(name, si) {
      IList<ITime> timeList = new List<ITime>();
      timeList.Add(time);
      Times = timeList;
    }
    // TODO add and remove Location times
    /// <summary>
    ///   Adds a valid time period.
    /// </summary>
    public void addTime(ITime time) {
      Times.Add(time);
    }

    /// <summary>
    ///   Remove time data on the given index.
    /// </summary>
    /// <param name="index">The index of the time in the list.</param>
    /// <exception cref="SharkASIPIllegalArguementException"> Thrown if index out of bound. </exception>
    public void removeTime(int index) {
      Times.RemoveAt(index);
    }
  }
}

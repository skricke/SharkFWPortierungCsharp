namespace Shark.ASIP {

  /// <summary> Interface for time used by TimeSemanticTags for describing time periods in between an information is valid. </summary>
  ///
  /// <remarks> sk, 15.03.2016. </remarks>
  public interface ITime {
    /// <summary>
    ///   Defines the format type of the time specification. Supported are UTC, Unix and Sharktime.
    /// </summary>
    TimeType Format { get; set; }
    // TODO all timetypes in any time?

    /// <summary> The From-Property contains the start point in time (UTC-formatted).</summary>
    ///
    /// <value> The starttime timestamp. </value>
    int FromUtc { get; set; }

    /// <summary> The From-Property contains the start point in time (Unix-formatted).</summary>
    ///
    /// <value> The starttime. </value>
    int FromUnix { get; set; }

    /// <summary> The From-Property contains the start point in time (Sharkspecific-formatted).</summary>
    ///
    /// <value> The starttime. </value>
    int FromShark { get; set; }

    /// <summary> Contain the length of time(duration) from the starttime. </summary>
    ///
    /// <value> The duration. </value>
    int Duration { get; set; }
    
  }
}
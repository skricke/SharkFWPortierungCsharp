namespace Shark.ASIP {

  /// <summary> Interface for time used by TimeSemanticTags for describing time periods in between an information is valid. </summary>
  ///
  /// <remarks> sk, 15.03.2016. </remarks>
  public interface Time {
    /// <summary>
    ///   Defines the format type of the time specification. Supported are UTC, Unix and Sharktime.
    /// </summary>
    TimeType Format { get; set; }

    /// <summary> The From-Property contains the start point in time </summary>
    ///
    /// <value> The starttime. </value>
    int From { get; set; }

    /// <summary> Contain the length of time(duration) from the starttime. </summary>
    ///
    /// <value> The duration. </value>
    int Duration { get; set; }
    
    // TODO: timeformat s                   = '{'
    //                              from ','
    //                              duration
    //                          '}' ;
    //from                    = '"from":' utcTime ',' unixTime ',' sharkTime ;
    //utcTime                 = '{' '"utcTime":' ( https://www.ietf.org/rfc/rfc3339.txt Part 5.6 Date and Time on the Internet: Timestamps) '}' ;
    //unixTime                = '{' '"unixTime":' number '}' ;
    //sharkTime               = '{' '"sharkTime":' void '}' ;
    //duration                = '"duration":' number ;
  }
}
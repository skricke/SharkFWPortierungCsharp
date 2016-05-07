namespace Shark {
  namespace ASIP {

    /// <summary> Supported values that represent time formats for TimeSemanticTag time specifications. </summary>
    /// <see cref="Shark.ASIP.Time"/>
    /// <see cref="Shark.ASIP.ITimeSemanticTag"/>
    /// 
    /// <remarks> sk, 15.03.2016. </remarks>
    public enum TimeType {
      /// <summary> An enum constant representing the UTC Time option. </summary>
      UTC,
      /// <summary> An enum constant representing the Unix Time option. </summary>
      UNIX,
      /// <summary> An enum constant representing the Shark Time option. </summary>
      SHARK
    }
  }
}
namespace Shark {
  namespace ASIP {
    /// <summary>
    ///   The available modi of communication directions.
    /// </summary>
    /// 
    /// There are just 4 combinations which are
    /// defined by constants in Shark.
    ///  
    /// DIRECTION_IN - peer want's to send information
    /// DIRECTION_OUT - peer want's to receive information
    /// DIRECTION_INOUT - peer want's to send and retrieve information
    /// DIRECTION_NOTHING - peer doesn't want to exchange these information at all
    /// 
    /// <author>sk</author>
    /// <version>14032016</version>
    /// <see href="https://github.com/SharedKnowledge/SharkFW/blob/master/src/java/core/net/sharkfw/knowledgeBase/ContextSpace.java"/>
    public enum Directions {
      /// <summary>
      /// Peer want's to send information.
      /// </summary>
      IN = 0,
      /// <summary>
      /// Peer want's to receive information.
      /// </summary>
      OUT = 1,
      /// <summary>
      /// Peer want's to send and retrieve information.
      /// </summary>
      INOUT = 2,
      /// <summary>
      /// Peer doesn't want to exchange these information at all.
      /// </summary>
      NO = 3
    }
  }
}
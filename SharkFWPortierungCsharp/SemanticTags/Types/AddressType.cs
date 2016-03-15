namespace Shark {
  namespace ASIP {

    /// <summary> Supported values that represent adress types for PeerSemanticTag adresses. </summary>
    /// <see cref="Shark.ASIP.Address"/>
    /// <see cref="Shark.ASIP.PeerSemanticTag"/>
    /// 
    /// <remarks> sk, 15.03.2016. </remarks>
    public enum AddressType {
      /// <summary> An enum constant representing the TCP option. </summary>
      TCP,
      /// <summary> An enum constant representing the HTTP option. </summary>
      HTTP,
      /// <summary> An enum constant representing the MAIL option. </summary>
      MAIL
    }
  }
}
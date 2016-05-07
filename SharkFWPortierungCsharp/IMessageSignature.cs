namespace Shark.ASIP {
  /// <summary>
  ///   The Signature used in and for messages.
  /// </summary>
  public interface IMessageSignature {
    // signature               = text ;
    /// <summary>
    ///   Generates a signature.
    /// </summary>
    void generateSignature();
  }
}
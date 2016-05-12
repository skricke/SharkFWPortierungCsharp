using System.Collections.Generic;

namespace Shark.ASIP {
  /// <summary>
  /// The header of every message gives META-information to the peers.
  /// </summary>
  public interface IMessageHeader {
    //TODO optional STs only peer, spatial or time allowed.

    /// <summary>
    ///   The actual version number of the ASIP.
    /// </summary>
    float Version { get; set; }
    /// <summary>
    ///   Contains the format of the message.
    /// </summary>
    string Format { get; set; }
    /// <summary>
    ///  Nullable EncryptionKey.
    /// </summary>
    string EncryptedKey { get; set; }
    /// <summary>
    ///   Optional SemanticTag for adressing the sender of the message.
    /// </summary>
    ISemanticTag Sender { get; }
    /// <summary>
    ///   Optional List of all receiver SemanticTags of the message.
    /// </summary>
    IList<IPeerSemanticTag> Receiver { get; }
    /// <summary>
    ///   Shows if the message was signed with a signature or not.
    /// </summary>
    bool Signed { get; set; }
    /// <summary>
    ///   The TTL (Time to Live) value sets the living time of the message. Possible as standard number or unixTime or utcTime.
    /// </summary>
    uint TimeToLive { get; set; } // TODO unix/utcTime

    /// <summary>
    ///   Adds a receiver to the list of SemanticTags.
    /// </summary>
    /// <param name="receiver">The new (additional) receiver of the message.</param>
    void addReceiver(IPeerSemanticTag receiver);
    /// <summary>
    ///   Removes the first existing receiver from the Receiver list or does nothing if not found.
    /// </summary>
    /// <param name="receiver">The receiver to be deleted from the receive-list.</param>
    void removeReceiver(IPeerSemanticTag receiver);
  }
}
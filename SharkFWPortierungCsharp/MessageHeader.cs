using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  public class MessageHeader : IMessageHeader {
    /// <summary>
    ///   The actual version number of the ASIP.
    /// </summary>
    public float Version { get; set; }
    /// <summary>
    ///   Contains the format of the message.
    /// </summary>
    public string Format { get; set; }
    /// <summary>
    ///  Nullable EncryptionKey.
    /// </summary>
    public string EncryptedKey { get; set; }
    /// <summary>
    ///   Optional SemanticTag for adressing the sender of the message.
    /// </summary>
    public ISemanticTag Sender { get; }
    /// <summary>
    ///   Optional List of all receiver SemanticTags of the message.
    /// </summary>
    public IList<IPeerSemanticTag> Receiver { get; } //TODO optional spatial or time semantic tags.
    /// <summary>
    ///   Shows if the message was signed with a signature or not.
    /// </summary>
    public bool Signed { get; set; }
    /// <summary>
    ///   The TTL (Time to Live) value sets the living time of the message. Possible as standard number or unixTime or utcTime.
    /// </summary>
    public uint TimeToLive { get; set; } // TODO unix/utcTime

    private MessageHeader() { }
    public MessageHeader(float Version, string Format, string EncryptedKey, ISemanticTag Sender, IList<IPeerSemanticTag> Receiver, bool Signed, uint ttl) {
      // TODO check if standardimplementation of constructor properties holds.
    }

    /// <summary>
    ///   Adds a receiver to the list of SemanticTags.
    /// </summary>
    /// <param name="receiver">The new (additional) receiver of the message.</param>
    public void addReceiver(IPeerSemanticTag receiver) {
      Receiver.Add(receiver);
    }
    /// <summary>
    ///   Removes the first existing receiver from the Receiver list or does nothing if not found.
    /// </summary>
    /// <param name="receiver">The receiver to be deleted from the receive-list.</param>
    public void removeReceiver(IPeerSemanticTag receiver) {
      Receiver.Remove(receiver);
    }
  }
}

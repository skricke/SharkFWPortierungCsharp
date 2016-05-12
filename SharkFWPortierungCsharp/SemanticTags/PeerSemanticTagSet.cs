using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticTags {
  public class PeerSemanticTagSet : SemanticTagSet, IPeerSemanticTagSet {
    // 
    // addSemanticTag added and has function of merge, but without return-value
    // mergeSemanticTags is merging two sets in the meaning of merge.
    // merge - checked for existing tags and add the sis if a tag already exists or creates a new tag.

    /// <summary> Returns the semantic tags from the PeerSemanticTagSet. </summary>
    ///
    /// <value> The semantic tags. </value>
    public new IList<IPeerSemanticTag> SemanticTags { get; }

    public PeerSemanticTagSet() {
      SemanticTags = new List<IPeerSemanticTag>();
    }

    /// <summary> Creates a semantic tag from given name and subject identifiers and adds it to the SemanticTags,
    ///           but only if no identical tag already exists in the set.</summary>
    /// TODO: two functionalities - redesign?
    /// 
    /// <param name="name"> The semantic tag`s name. </param>
    /// <param name="si">  The first initial subject identifier. </param>
    /// <param name="address"> The single adress of the peer.</param>
    ///
    /// <returns> The created semantic tag. </returns>
    /// <exception cref="SharkASIPException">Throws an Exception if an identical tag already exists.</exception>
    public IPeerSemanticTag createPeerSemanticTag(string name, string si, IAddress address) {
      IPeerSemanticTag tag = new PeerSemanticTag(name, si, address);
      SemanticTags.Add(tag);

      return tag;
    }

    /// <summary> Creates a semantic tag from given name and subject identifiers and adds it to the SemanticTags,
    ///           but only if no identical tag already exists in the set.</summary>
    /// TODO: two functionalities - redesign?
    /// 
    /// <param name="name"> The semantic tag`s name. </param>
    /// <param name="sis">  The subject identifiers. </param>
    /// <param name="addresses"> The adresses of the peer.</param>
    ///
    /// <returns> The created semantic tag. </returns>
    /// <exception cref="SharkASIPException">Throws an Exception if an identical tag already exists.</exception>
    public IPeerSemanticTag createPeerSemanticTag(string name, string[] sis, IList<IAddress> addresses) {
      IPeerSemanticTag tag = new PeerSemanticTag(name, sis, addresses);
      SemanticTags.Add(tag);

      return tag;
    }
  }
}

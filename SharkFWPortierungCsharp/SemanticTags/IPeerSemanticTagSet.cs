using System.Collections.Generic;

namespace Shark {
  namespace ASIP {

    /// <summary> A set of semantic tags which have no additional relation to each other. Tags can be added and removed.
    ///           </summary>
    /// 
    /// <see href="https://github.com/SharedKnowledge/SharkFW/blob/master/src/java/core/net/sharkfw/knowledgeBase/STSet.java"/>
    /// 
    /// <remarks> sk, 15.03.2016. </remarks>

    public interface IPeerSemanticTagSet : ISemanticTagSet {
      // TODO PeerSemanticTagSet diff to STSet (Not all functions assumed yet):
      // 
      // addSemanticTag added and has function of merge, but without return-value
      // mergeSemanticTags is merging two sets in the meaning of merge.
      // merge - checked for existing tags and add the sis if a tag already exists or creates a new tag.

      /// <summary> Returns the semantic tags from the PeerSemanticTagSet. </summary>
      ///
      /// <value> The semantic tags. </value>
      new IList<IPeerSemanticTag> SemanticTags { get; }

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
      IPeerSemanticTag createPeerSemanticTag(string name, string si, IAddress address);

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
      IPeerSemanticTag createPeerSemanticTag(string name, string[] sis, IList<IAddress> addresses);
      
    }
  }
}
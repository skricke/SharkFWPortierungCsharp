using System.Collections.Generic;

namespace Shark {
  namespace ASIP {

    /// <summary> A set of semantic tags which have no additional relation to each other. Tags can be added and removed.
    ///           </summary>
    /// 
    /// <see href="https://github.com/SharedKnowledge/SharkFW/blob/master/src/java/core/net/sharkfw/knowledgeBase/STSet.java"/>
    /// 
    /// <remarks> sk, 15.03.2016. </remarks>

    public interface SemanticTagSet {
      // TODO SemanticTagSet diff to STSet (Not all functions assumed yet):
      // 
      // addSemanticTag added and has function of merge, but without return-value
      // mergeSemanticTag is merging two sets in the meaning of merge.
      // merge - checked for existing tags and add the sis if a tag already exists or creates a new tag.

      /// <summary> Returns the semantic tags from the SemanticTagSet. </summary>
      ///
      /// <value> The semantic tags. </value>
      IList<SemanticTag> SemanticTags { get; }

      /// <summary> Creates a semantic tag from given name and subject identifiers and adds it to the tags. </summary>
      /// TODO: two functionalities - redesign?
      /// 
      /// <param name="name"> The semantic tag`s name. </param>
      /// <param name="sis">  The subject identifiers. </param>
      ///
      /// <returns> The created semantic tag. </returns>
      SemanticTag createSemanticTag(string name, string[] sis);

      /// <summary> Merge semantic tag. </summary>
      ///
      /// <param name="tagSet"> Set the tag belongs to. </param>
      ///
      /// <returns> A SemanticTag. </returns>
      SemanticTag mergeSemanticTag(SemanticTagSet tagSet);

      /// <summary> Adds a semantic tag. If the same tag already exists, only the new sis will be added to the exsitent tag. 
      ///           Otherwise a new tag is add. </summary>
      ///
      /// <param name="tag">  The tag. </param>
      void addSemanticTag(SemanticTag tag);

      /// <summary> Removes the semantic tag described by tag. </summary>
      ///
      /// <param name="tag">  The tag which have to be removed. </param>
      ///
      /// <returns> true if it succeeds, false if the tag wasn´t found. </returns>
      bool removeSemanticTag(SemanticTag tag);
      // TODO: remove by name and sis
    }
  }
}
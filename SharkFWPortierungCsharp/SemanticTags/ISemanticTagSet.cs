using System.Collections.Generic;

namespace Shark {
  namespace ASIP {

    /// <summary> A set of semantic tags which have no additional relation to each other. Tags can be added and removed.
    ///           </summary>
    /// 
    /// <see href="https://github.com/SharedKnowledge/SharkFW/blob/master/src/java/core/net/sharkfw/knowledgeBase/STSet.java"/>
    /// 
    /// <remarks> sk, 15.03.2016. </remarks>

    public interface ISemanticTagSet {
      // TODO SemanticTagSet diff to STSet (Not all functions assumed yet):
      // 
      // addSemanticTag added and has function of merge, but without return-value
      // mergeSemanticTags is merging two sets in the meaning of merge.
      // merge - checked for existing tags and add the sis if a tag already exists or creates a new tag.

      /// <summary> Returns the semantic tags from the SemanticTagSet. </summary>
      ///
      /// <value> The semantic tags. </value>
      IList<ISemanticTag> SemanticTags { get; }

      /// <summary> Creates a semantic tag from given name and subject identifiers and adds it to the SemanticTags,
      ///           but only if no identical tag already exists in the set.</summary>
      /// TODO: two functionalities - redesign?
      /// 
      /// <param name="name"> The semantic tag`s name. </param>
      /// <param name="sis">  The subject identifiers. </param>
      ///
      /// <returns> The created semantic tag. </returns>
      /// <exception cref="SharkASIPException">Throws an Exception if an identical tag already exists.</exception>
      ISemanticTag createSemanticTag(string name, string[] sis);
      // TODO ??Java-Version has additional method for single si - neccessary?

      /// <summary>Merge a semantic tag set to the actual set. Only unknown Tags will be copied into the actual semantic tag set, with its properties.</summary>
      ///
      /// <param name="tagSet"> Set the tags belongs to. </param>
      ///
      /// <returns> The merged SemanticTagSet. </returns>
      /// <exception cref="SharkASIPException">Throws an Exception if the Tags couldn´t be merged.</exception>
      ISemanticTagSet mergeSemanticTags(ISemanticTagSet tagSet);

      /// <summary> Adds a semantic tag copy. If the same tag already exists, only the new sis will be added to the exsitent tag. 
      ///           Otherwise a new tag is add. </summary>
      ///
      /// <param name="tag">  The tag. </param>
      /// <exception cref="SharkASIPException">Throws an Exception if the Tag couldn't be created.</exception>
      void addSemanticTag(ISemanticTag tag);

      /// <summary> Removes the semantic tag described by tag. </summary>
      ///
      /// <param name="tag">  The tag which have to be removed. </param>
      ///
      /// <returns> true if it succeeds, false if the tag wasn´t found. </returns>
      /// <exception cref="SharkASIPException">Throws an Exception if remove action failed.</exception>
      bool removeSemanticTag(ISemanticTag tag);
      /// <summary>
      ///   Removes the semantic tag described by the tag´s name. Does nothing if no tag with this name exists.
      /// </summary>
      /// <param name="name"> The name of the SemanticTag which has to be removed.</param>
      /// <returns> true if it succeeds, false if the tag wasn´t found to remove. </returns>
      /// <exception cref="SharkASIPException">Throws an Exception if remove action failed.</exception>
      bool removeSemanticTag(string name);
      /// <summary>
      ///   Removes the semantic tag described by even one of the given subject identifiers or does nothing if no such tag was found in the set.
      /// </summary>
      /// <param name="sis">The subject identifiers for the SemanticTag.</param>
      /// <returns> true if it succeeds, false if the tag wasn´t found to remove. </returns>
      /// <exception cref="SharkASIPException">Throws an Exception if remove action failed.</exception>
      bool removeSemanticTag(string[] sis);

      /// <summary>
      ///   Returns the first hit of a SemanticTag with the given subject identifier. 
      /// </summary>
      /// <param name="si"> The single subject identifier to search for in the tags.</param>
      /// <returns>The first match of SemanticTag with the given si, or null if no such tag was found.</returns>
      ISemanticTag getSemanticTag(string si);
      /// <summary>      
      ///   Returns the first hit of a SemanticTag with one of the given subject identifier. 
      /// </summary>
      /// <param name="sis">An array of subject identifier.</param>
      /// <returns>The first match of SemanticTag with one of the given sis, or null if no such tag was found.</returns>
      ISemanticTag getSemanticTag(string[] sis);
      /// <summary>
      ///   Returns all SemanticTags if its name matching the given pattern.
      /// </summary>
      /// <param name="pattern">The pattern for comparison to the semantig tag names.</param>
      /// <returns>An enumeration of references to the matching objects in the actual SemanticTagSet.</returns>
      /// <exception cref="SharkASIPException">Throws an Exception if pattern matching fails.</exception>
      IEnumerator<ISemanticTag> getSemanticTagsByName(string pattern);

      /// <summary>
      ///   The most simple fragmentation. Check if the given tag exists and return a SemanticTagSet with that tag in it.
      /// </summary>
      /// <param name="anchor">The wanted tag.</param>
      /// <returns>A SemanticTagSet with the given tag, or null if the tag couldn´t been found.</returns>
      ISemanticTagSet fragment(ISemanticTag anchor);

      // TODO FragmentationParameter(3), Contextualization(4), Listener(add, remove)
      // href=https://github.com/SharedKnowledge/SharkFW/blob/master/sharkfw/core/src/main/java/net/sharkfw/knowledgeBase/STSet.java

      /// <summary>
      ///   Returns if the semantic tag set is empty or not.
      /// </summary>
      /// <returns>True if the actual tag set is empty.</returns>
      bool isEmpty();

      /// <summary>
      ///   Give the size of the actual SemanticTagSet.
      /// </summary>
      /// <returns>The number of all semantic tags in this set.</returns>
      int size();
    }
  }
}
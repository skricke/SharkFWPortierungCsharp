using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticTags {
  public class SemanticTagSet : ISemanticTagSet {
    // 
    // addSemanticTag added and has function of merge, but without return-value
    // mergeSemanticTags is merging two sets in the meaning of merge.
    // merge - checked for existing tags and add the sis if a tag already exists or creates a new tag.

    /// <summary> Returns the semantic tags from the SemanticTagSet. </summary>
    ///
    /// <value> The semantic tags. </value>
    public IList<ISemanticTag> SemanticTags { get; }

    public SemanticTagSet() {
      SemanticTags = new List<ISemanticTag>();
    }

    /// <summary> Creates a semantic tag from given name and subject identifiers and adds it to the SemanticTags,
    ///           but only if no identical tag already exists in the set.</summary>
    /// TODO: two functionalities - redesign?
    /// 
    /// <param name="name"> The semantic tag`s name. </param>
    /// <param name="si">  The first intial subject identifiers. </param>
    ///
    /// <returns> The created semantic tag. </returns>
    /// <exception cref="SharkASIPException">Throws an Exception if an identical tag already exists.</exception>
    public ISemanticTag createSemanticTag(string name, string si) {
      ISemanticTag tag = new SemanticTag(name, si);
      SemanticTags.Add(tag);

      return tag;
    }


    /// <summary> Creates a semantic tag from given name and subject identifiers and adds it to the SemanticTags,
    ///           but only if no identical tag already exists in the set.</summary>
    /// TODO: two functionalities - redesign?
    /// 
    /// <param name="name"> The semantic tag`s name. </param>
    /// <param name="sis">  The subject identifiers. </param>
    ///
    /// <returns> The created semantic tag. </returns>
    /// <exception cref="SharkASIPException">Throws an Exception if an identical tag already exists.</exception>
    public ISemanticTag createSemanticTag(string name, string[] sis) {
      ISemanticTag tag = new SemanticTag(name, sis);
      SemanticTags.Add(tag);

      return tag;
    }

    // TODO ??Java-Version has additional method for single si - neccessary?

    /// <summary> Merge a semantic tag set to the actual set. Only unknown Tags will be copied into the actual semantic tag set, with its properties.</summary>
    ///
    /// <param name="tagSet"> SemanticTagSet the tags belongs to. </param>
    ///
    /// <returns> The merged SemanticTagSet. </returns>
    /// <exception cref="SharkASIPException">Throws an Exception if the Tags couldn´t be merged.</exception>
    public ISemanticTagSet mergeSemanticTags(ISemanticTagSet tagSet) {
      foreach (ISemanticTag tag in tagSet.SemanticTags) {
        if (!SemanticTags.Contains(tag)) {
          SemanticTags.Add(tag);
        }
      }

      return this;
    }

    /// <summary> Adds a semantic tag copy. If the same tag already exists, only the new sis will be added to the exsitent tag. 
    ///           Otherwise a new tag is add. </summary>
    ///
    /// <param name="tag">  The tag. </param>
    /// <exception cref="SharkASIPException">Throws an Exception if the Tag couldn't be created.</exception>
    public void addSemanticTag(ISemanticTag tag) {
      SemanticTags.Add(tag);
    }

    /// <summary> Removes the semantic tag described by tag. </summary>
    ///
    /// <param name="tag">  The tag which have to be removed. </param>
    ///
    /// <returns> true if it succeeds, false if the tag wasn´t found. </returns>
    /// <exception cref="SharkASIPException">Throws an Exception if remove action failed.</exception>
    public bool removeSemanticTag(ISemanticTag tag) {
      return SemanticTags.Remove(tag);
    }

    /// <summary>
    ///   Removes the semantic tag described by the tag´s name. Does nothing if no tag with this name exists.
    ///   If more then one tag has the searched name all will be removed.
    /// </summary>
    /// <param name="name"> The name of the SemanticTag which has to be removed.</param>
    /// <returns> true if it succeeds, false if the tag wasn´t found to remove. </returns>
    /// <exception cref="SharkASIPException">Throws an Exception if remove action failed.</exception>
    public bool removeSemanticTag(string name) {
      bool found = false;
      foreach (ISemanticTag tag in SemanticTags) {
        if (tag.Name == name) {
          found = true;
          SemanticTags.Remove(tag);
        }
      }

      return found;
    }

    /// <summary>
    ///   Removes the semantic tags described by even one of the given subject identifiers or does nothing if no such tag was found in the set.
    /// </summary>
    /// <param name="sis">The subject identifiers for the SemanticTag.</param>
    /// <returns> true if it succeeds, false if the tag wasn´t found to remove. </returns>
    /// <exception cref="SharkASIPException">Throws an Exception if remove action failed.</exception>
    public bool removeSemanticTag(string[] sis) {
      bool removed = false;
      foreach (var tag in SemanticTags) {
        foreach (var tagSi in tag.SIS) {
          // TODO should error if tag removed -> removing over temp removeTagList; extension to possible double removes
          for (int i = 0; i < sis.Length; i++) {
            if (sis[i] == tagSi) {
              SemanticTags.Remove(getSemanticTag(sis[i]));
              removed = true;
            }
          }  
        }
      }

      return removed;
    }

    /// <summary>
    ///   Returns the first hit of a SemanticTag with the given subject identifier. 
    /// </summary>
    /// <param name="si"> The single subject identifier to search for in the tags.</param>
    /// <returns>The first match of SemanticTag with the given si, or null if no such tag was found.</returns>
    public ISemanticTag getSemanticTag(string si) {
      bool found = false;
      ISemanticTag foundTag = null;

      foreach (var tag in SemanticTags) {
        foreach (var tagSi in tag.SIS) {
          if (tagSi == si && !found) {
            foundTag = tag;
          }
        }
      }

      return foundTag;
    }

    /// <summary>      
    ///   Returns the first hit of a SemanticTag with one of the given subject identifier. 
    /// </summary>
    /// <param name="sis">An array of subject identifier.</param>
    /// <returns>The first match of SemanticTag with one of the given sis, or null if no such tag was found.</returns>
    public ISemanticTag getSemanticTag(string[] sis) {
      ISemanticTag foundTag = null;

      for (int i = 0; i < sis.Length; i++) {
        foundTag = getSemanticTag(sis[i]);

        if (foundTag != null) {
          i = sis.Length;
        }
      }

      return foundTag;
    }

    /// <summary>
    ///   Returns all SemanticTags if its name matching the given pattern.
    /// </summary>
    /// <param name="pattern">The pattern for comparison to the semantig tag names.</param>
    /// <returns>An enumeration of references to the matching objects in the actual SemanticTagSet.</returns>
    /// <exception cref="SharkASIPException">Throws an Exception if pattern matching fails.</exception>
    public IEnumerator<ISemanticTag> getSemanticTagsByName(string pattern) {
      IList<ISemanticTag> foundTags = null;
      foreach (var tag in SemanticTags) {
        if (tag.Name == pattern) {
          foundTags.Add(tag); 
        }
      }

      return foundTags.GetEnumerator();
    }

    /// <summary>
    ///   The most simple fragmentation. Check if the given tag exists and return a SemanticTagSet with that tag in it.
    /// </summary>
    /// <param name="anchor">The wanted tag.</param>
    /// <returns>A SemanticTagSet with the given tag, or null if the tag couldn´t been found.</returns>
    public ISemanticTagSet fragment(ISemanticTag anchor) {
      ISemanticTagSet tagSet = null;

      foreach (var tag in SemanticTags) {
        if (tag.Equals(anchor)) {
          tagSet = new SemanticTagSet();
          tagSet.addSemanticTag(tag);
          break;
        }
      }

      return tagSet;
    }

    // TODO FragmentationParameter(3), Contextualization(4), Listener(add, remove)
    // href=https://github.com/SharedKnowledge/SharkFW/blob/master/sharkfw/core/src/main/java/net/sharkfw/knowledgeBase/STSet.java

    /// <summary>
    ///   Returns if the semantic tag set is empty or not.
    /// </summary>
    /// <returns>True if the actual tag set is empty.</returns>
    public bool isEmpty() {
      bool empty = false;
      if (size() == 0) {
        empty = true;
      }
      return empty;
    }

    /// <summary>
    ///   Give the size of the actual SemanticTagSet.
    /// </summary>
    /// <returns>The number of all semantic tags in this set.</returns>
    public int size() {
      return SemanticTags.Count;
    }
  }
}

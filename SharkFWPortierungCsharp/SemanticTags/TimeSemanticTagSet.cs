using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticTags {
  public class TimeSemanticTagSet : SemanticTagSet, ITimeSemanticTagSet {
    // 
    // addSemanticTag added and has function of merge, but without return-value
    // mergeSemanticTags is merging two sets in the meaning of merge.
    // merge - checked for existing tags and add the sis if a tag already exists or creates a new tag.

    /// <summary> Returns the semantic tags from the TimeSemanticTagSet. </summary>
    ///
    /// <value> The semantic tags. </value>
    public new IList<ITimeSemanticTag> SemanticTags { get; }

    public TimeSemanticTagSet() {
      SemanticTags = new List<ITimeSemanticTag>();
    }

    /// <summary> Creates a semantic tag from given name and subject identifiers and adds it to the SemanticTags,
    ///           but only if no identical tag already exists in the set.</summary>
    /// TODO: two functionalities - redesign?
    /// 
    /// <param name="name"> The semantic tag`s name. </param>
    /// <param name="si">  The first initial subject identifier. </param>
    /// <param name="time"> The single time of the tag.</param>
    ///
    /// <returns> The created semantic tag. </returns>
    /// <exception cref="SharkASIPException">Throws an Exception if an identical tag already exists.</exception>
    public ITimeSemanticTag createTimeSemanticTag(string name, string si, ITime time) {
      ITimeSemanticTag tag = new TimeSemanticTag(name, si, time);
      SemanticTags.Add(tag);

      return tag;
    }

    /// <summary> Creates a semantic tag from given name and subject identifiers and adds it to the SemanticTags,
    ///           but only if no identical tag already exists in the set.</summary>
    /// TODO: two functionalities - redesign?
    /// 
    /// <param name="name"> The semantic tag`s name. </param>
    /// <param name="sis">  The subject identifiers. </param>
    /// <param name="times"> The times of timeSemanticTag. </param>
    ///
    /// <returns> The created semantic tag. </returns>
    /// <exception cref="SharkASIPException">Throws an Exception if an identical tag already exists.</exception>
    public ITimeSemanticTag createTimeSemanticTag(string name, string[] sis, IList<ITime> times) {
      ITimeSemanticTag tag = new TimeSemanticTag(name, sis, times);
      SemanticTags.Add(tag);

      return tag;
    }
  }
}

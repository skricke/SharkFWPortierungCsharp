using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticTags {
  public class SpatialSemanticTagSet : SemanticTagSet, ISpatialSemanticTagSet {
    // 
    // addSemanticTag added and has function of merge, but without return-value
    // mergeSemanticTags is merging two sets in the meaning of merge.
    // merge - checked for existing tags and add the sis if a tag already exists or creates a new tag.

    /// <summary> Returns the semantic tags from the SpatialSemanticTagSet. </summary>
    ///
    /// <value> The semantic tags. </value>
    public new IList<ISpatialSemanticTag> SemanticTags { get; }

    public SpatialSemanticTagSet() {
      SemanticTags = new List<ISpatialSemanticTag>();
    }

    /// <summary> Creates a semantic tag from given name and subject identifiers and adds it to the SemanticTags,
    ///           but only if no identical tag already exists in the set.</summary>
    /// TODO: two functionalities - redesign?
    /// 
    /// <param name="name"> The semantic tag`s name. </param>
    /// <param name="si">  The first initial subject identifier. </param>
    /// <param name="location"> The single location of the tag.</param>
    ///
    /// <returns> The created semantic tag. </returns>
    /// <exception cref="SharkASIPException">Throws an Exception if an identical tag already exists.</exception>
    public ISpatialSemanticTag createSpatialSemanticTag(string name, string si, ILocation location) {
      ISpatialSemanticTag tag = new SpatialSemanticTag(name, si, location);
      SemanticTags.Add(tag);

      return tag;
    }

    /// <summary> Creates a semantic tag from given name and subject identifiers and adds it to the SemanticTags,
    ///           but only if no identical tag already exists in the set.</summary>
    /// TODO: two functionalities - redesign?
    /// 
    /// <param name="name"> The semantic tag`s name. </param>
    /// <param name="sis">  The subject identifiers. </param>
    /// <param name="locations"> The locations of SpatialSemanticTag.</param>
    ///
    /// <returns> The created semantic tag. </returns>
    /// <exception cref="SharkASIPException">Throws an Exception if an identical tag already exists.</exception>
    public ISpatialSemanticTag createSpatialSemanticTag(string name, string[] sis, IList<ILocation> locations) {
      ISpatialSemanticTag tag = new SpatialSemanticTag(name, sis, locations);
      SemanticTags.Add(tag);

      return tag;
    }
  }
}

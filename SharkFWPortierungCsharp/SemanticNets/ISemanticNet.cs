using System.Collections.Generic;

namespace Shark.ASIP {
  /// <summary>
  ///   Organizes Semantic Tags like a net. The tags can be set in relationship to each other. Every relationship contans two IDs of the associated SemanticTags.
  /// </summary>
  public interface ISemanticNet {
    /// <summary>
    ///   The SemanticTag represents the nodes in the semantic net. Each tag is related to a semanticTagId.
    /// </summary>
    IDictionary<string, ISemanticTag> SemanticTagsTable { get; set; }
    /// <summary>
    ///   The relations between the Tags.
    /// </summary>
    IList<IProperty> Relations { get; }

    /// <summary>
    ///   Adds a SemanticTag with an identifying id to the SemanticTagsTable but only under the condition that such a key tag doesn´t already exist in the dictionary.
    ///   Otherwise nothing happens.
    /// </summary>
    /// <param name="semanticTagId">The ID of the SemanticTag.</param>
    /// <param name="tag">The SemanticTag itself.</param>
    void addSemanticTag(string semanticTagId, ISemanticTag tag);
    /// <summary>
    ///   Removes the first found entry of SemanticTag including relations with it´s ID and the ID itself, if not found nothing happens.
    ///   Searching by the semanticTagId.
    /// </summary>
    /// <param name="semanticTagId">The ID of the Semantic Tag whose entry will be removed.</param>
    void removeSemanticTag(string semanticTagId);
    /// <summary>
    ///   Removes the first found entry of SemanticTag including relations with it´s ID and the ID itself, if not found nothing happens.
    ///   Searching by the tag.
    /// </summary>
    /// <param name="tag">The SemanticTag whose entry has to be removed.</param>
    void removeSemanticTag(ISemanticTag tag);
    /// <summary>
    ///   Searching in the SemanticTagsTable for an existing entry with the given semanticTagId.
    /// </summary>
    /// <param name="semanticTagId">The wanted semanticTagId.</param>
    /// <returns>The SemanticTag of the entry with an equal semanticTagId.</returns>
    ISemanticTag findSemanticTag(string semanticTagId);
    /// <summary>
    ///   Searching in the SemanticTagsTable for an existing entry with the given semanticTag.
    /// </summary>
    /// <param name="tag">The SemanticTag to be found.</param>
    /// <returns>The key (semanticTagId) of the entry with an equal semanticTag.</returns>
    string findSemanticTag(ISemanticTag tag);

    /// <summary>
    ///   Adds a new association between two Semantic Tags but only under the condition that such a relationship doesn´t already exist in the dictionary.
    ///   Otherwise nothing happens. Even a different relation name creates a new property.
    /// </summary>
    /// <param name="property"> The associated relationship.</param>
    void addRelation(IProperty property);
    /// <summary>
    ///   Adds a new association between two Semantic Tags but only under the condition that such a relationship doesn´t already exist in the dictionary.
    ///   Otherwise nothing happens. Even a different relation name creates a new property.
    /// </summary>
    /// <param name="relationName">The name of the relationship between the two SemanticTags.</param>
    /// <param name="sourceID">The semantic tag id of the relation source. </param>
    /// <param name="targetID">The semantic tag id of the relation´s target.</param>
    void addRelation(string relationName, string sourceID, string targetID);
    /// <summary>
    ///   Removes an association if found in Relations or does nothing.
    ///   If two equal properties exist in the Relations only the first hit will be removed.
    /// </summary>
    /// <param name="property">The relation to be removed.</param>
    void removeRelation(IProperty property);
    /// <summary>
    ///   Removes all associations with the given semanticTagId found in Relations or does nothing.
    /// </summary>
    /// <param name="semanticTagId">The relations to the Semantic Tag with that ID have to be removed.</param>
    void removeRelation(string semanticTagId);
    /// <summary>
    ///   Finds all relations with the given semantic tag id.
    /// </summary>
    /// <param name="semanticTagID">The wanted relations ID. </param>
    /// <returns>A list with all matched properties of the given SemanticTagID, whatever if matched in source or target id.</returns>
    IList<IProperty> findRelationsById(string semanticTagID);
    /// <summary>
    ///   Finds all relations with the same given relationName.
    /// </summary>
    /// <param name="relationName">The name of the relations which are wanted.</param>
    /// <returns>A list with all matched properties of the given relation name.</returns>
    IList<IProperty> findRelationsByRelationName(string relationName);

  }
}

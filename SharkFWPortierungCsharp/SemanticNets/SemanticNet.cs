using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticNets {
  public class SemanticNet : ISemanticNet {
    public IList<IProperty> Relations { get; }
    public IDictionary<string, ISemanticTag> SemanticTagsTable { get; set; }
    
    public void addRelation(IProperty property) {
      if (!existingRelation(property)) {
        Relations.Add(property);
      }
    }
    
    public void addRelation(string relationName, string sourceID, string targetID) {
      IProperty newProperty = new Property(relationName, sourceID, targetID);
      addRelation(newProperty);
    }

    public void addSemanticTag(string semanticTagId, ISemanticTag tag) {
      if (!SemanticTagsTable.ContainsKey(semanticTagId)) {
        SemanticTagsTable.Add(semanticTagId, tag);
      }
    }

    public IList<IProperty> findRelationsById(string semanticTagID) {
      return (IList<IProperty>) Relations.Where(relation => relation.SourceId == semanticTagID || relation.TargetId == semanticTagID);
    }

    public IList<IProperty> findRelationsByRelationName(string relationName) {
      return (IList<IProperty>) Relations.Where(relation => relation.Name == relationName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tag"></param>
    /// <returns>The SemanticTagId of the given tag.</returns>
    public string findSemanticTag(ISemanticTag tag) {
      return SemanticTagsTable.Single(x => x.Value.Equals(tag)).Key;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="semanticTagId"></param>
    /// <returns>The SemanticTag which matches to the semanticTagId.</returns>
    public ISemanticTag findSemanticTag(string semanticTagId) {
      return SemanticTagsTable[semanticTagId];
    }

    /// <summary>
    ///   Removes all relations with the given semanticTagId.
    /// </summary>
    /// <param name="semanticTagId"></param>
    public void removeRelation(string semanticTagId) {
      IList<IProperty> removeList = findRelationsById(semanticTagId);
      foreach (IProperty relation in removeList) {
        Relations.Remove(relation);
      }
    }

    public void removeRelation(IProperty property) {
      Relations.Remove(property);
    }

    public void removeSemanticTag(ISemanticTag tag) {
      SemanticTagsTable.Remove(findSemanticTag(tag));
    }

    public void removeSemanticTag(string semanticTagId) {
      SemanticTagsTable.Remove(semanticTagId);
    }

    private bool existingRelation(IProperty property) {
      bool exists = false;
      for (int i = 0; i < Relations.Count; i++) {
        if (Relations[i].Name == property.Name &&
            Relations[i].SourceId == property.SourceId &&
            Relations[i].TargetId == property.TargetId) {
          exists = true;
          i = Relations.Count;
        }
      }

      return exists;
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticTags {
  public class SemanticTag : ISemanticTag {
    public string Name { get; set; }
    /// <summary>
    ///   URIs as subject identifiers. http://www.w3.org/Addressing/URL/5_URI_BNF.html
    /// </summary>
    public IList<string> SIS { get; }

    private SemanticTag() { }
    public SemanticTag(string name, IList<string> siList) {
      Name = name;
      SIS = siList;
    }

    /// <summary>
    ///   Constructor for a semantigTag with one single subject identifier as initialisation.
    /// </summary>
    /// <param name="name">Name of the SemanticTag.</param>
    /// <param name="si">The first subject identifier. </param>
    public SemanticTag(string name, string si) {
      Name = name;
      SIS = new List<string>();
      SIS.Add(si);
    }

    public void addSI(string newSI) {
      SIS.Add(newSI);
    }

    public void removeSI(string subjectIdentifier) {
      SIS.Remove(subjectIdentifier);
    }
  }
}

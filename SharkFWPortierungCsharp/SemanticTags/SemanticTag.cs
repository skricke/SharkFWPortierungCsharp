using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticTags {
  class SemanticTag : ISemanticTag {
    public string Name { get; set; }
    /// <summary>
    ///   URIs as subject identifiers. http://www.w3.org/Addressing/URL/5_URI_BNF.html
    /// </summary>
    public IList<string> SIS { get; }

    public SemanticTag(string name, IList<string> siList) {
      Name = name;
      SIS = siList;
    }

    public void addSI(string newSI) {
      SIS.Add(newSI);
    }

    public void removeSI(string subjectIdentifier) {
      SIS.Remove(subjectIdentifier);
    }
  }
}

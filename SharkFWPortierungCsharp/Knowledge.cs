using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  public class Knowledge : IKnowledge {
    public ISharkVocabulary Vocabulary { get; }
    public IInformation Infos { get; }

    private Knowledge() { }
    public Knowledge(ISharkVocabulary vocabulary, IInformation infos) {
      Vocabulary = vocabulary;
      Infos = infos;
    }
  }
}

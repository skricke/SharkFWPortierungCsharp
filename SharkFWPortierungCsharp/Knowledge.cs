using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  class Knowledge : IKnowledge {
    public ISharkVocabulary Vocabulary { get; }
    public IEnumerable<IInformation> Infos { get; }

    private Knowledge() { }
    public Knowledge(ISharkVocabulary vocabulary, IEnumerable<IInformation> infos) {
      Vocabulary = vocabulary;
      Infos = infos;
    }
  }
}

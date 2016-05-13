using System.Collections.Generic;

namespace Shark {
  namespace ASIP {
    // TODO XML-Comment for Knowledge 
    public interface IKnowledge : IASIPContent {
      // TODO Design and Implement Knowledge from BNF-File
      ISharkVocabulary Vocabulary { get; }
      IInformation Infos { get; }
    }
  }
}
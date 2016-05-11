using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP {
  class ASIPEngine : IASIPEngine {
    /// <summary>
    ///   Send the insert command for insertion of the Knowledge.
    /// </summary>
    /// 
    /// <param name="givenKens">The knowledges to be send.</param>
    /// <exception cref="SharkASIPException">Throws an Exception if the Knowledge couldn't be insert.</exception>
    public void insert(IList<IKnowledge> givenKens) {
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Send an expose command for Receiving of the Knowledge(s) which the Interest is in.
    /// </summary>
    /// 
    /// <param name="wantedInterests">The Interests from which Knowledges are wanted.</param> 
    /// <exception cref="SharkASIPException">Throws an Exception if the wanted Knowledge of the given Interest couldn't be expose.</exception>
    public void expose(IList<IInterest> wantedInterests) {
      throw new NotImplementedException();
    }

    /// <summary>
    ///   New Command for ...
    /// </summary>
    /// <exception cref="SharkASIPException">Throws an Exception if the raw-format failed.</exception>
    public void raw() {
      // TODO Describe and rework raw-command
      throw new NotImplementedException();
    }
  }
}

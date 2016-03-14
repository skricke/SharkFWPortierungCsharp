﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///   Namespace for Semantic Internet Protocol (ASIP) for the SHARK Framework
/// </summary>
namespace ASIP {
  /// <summary>
  ///   This is an interface for the new Semantic Internet Protocol (ASIP) Support of the Shark Framework for P2P-<strong>Shar</strong>ed <strong>K</strong>nowledge.
  /// </summary>
  /// 
  /// <author>sk</author>
  /// <version>14032016</version>
  /// <see href="https://github.com/SharedKnowledge"/>
  /// 
  interface ASIPEngine {
    /// <summary>
    ///   Send the insert command for insertion of the Knowledge.
    /// </summary>
    /// 
    /// <param name="givenKens">The knowledges to be send.</param>
    /// <exception cref="">Throws an Exception if the Knowledge couldn't be insert.</exception>
    void insert(IList<Knowledge> givenKens);
     
    /// <summary>
    ///   Send an expose command for Receiving of the Knowledge(s) which the Interest is in.
    /// </summary>
    /// 
    /// <param name="wantedInterests">The Interests from which Knowledges are wanted.</param> 
    /// <exception cref="">Throws an Exception if the wanted Knowledge of the given Interest couldn't be expose.</exception>
    void expose(IList<Interest> wantedInterests);

    /// <summary>
    ///   New Command for ...
    /// </summary>
    void raw();
    // TODO Describe and rework raw-command
  }
}

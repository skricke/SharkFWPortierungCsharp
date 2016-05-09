using System.Collections.Generic;

namespace Shark {
  namespace ASIP {
    /// <summary>
    ///   An interface defining the interest.
    /// </summary>
    /// 
    /// An interest in shark is used to describe the context in which a peer is
    /// willing to exchange information (Receiving and sending Knowledges). 
    /// 
    /// An interest defines seven aspects (constraints) in which a peer is willing 
    /// to exchange information.
    /// 
    /// Each aspect can be set. If set, communication takes place if interest
    /// have mutual interest. A mutual interest can be calculated by contextualising
    /// an interest with another on. 
    /// 
    /// Unset aspects are interpreted as no constraints. Anything is allowed.
    /// 
    /// Thus, the most general interest has no aspect set, meaning: any get-methode return
    /// nulls. A peer is interested in virtually everything.
    /// 
    /// Arbitrary combinations are possible. Application can decide just to define
    /// topics but no locations etc. That's quite similiar to Wikipedia. Others could
    /// decide to define topics and peer which looks like a social network application.
    /// 
    /// Using location aspect leads directly to a location based system. Using all
    /// aspects leads to a system that combines social network, wikipedia and
    /// location based systems. SharkNet is such a system which is a demonstration
    /// of those Shark features. 
    /// 
    /// <author>sk</author>
    /// <version>14032016</version>
    /// <see href="https://github.com/SharedKnowledge/SharkFW/blob/master/src/java/core/net/sharkfw/asip/ASIPInterest.java"/>
    /// 
    public interface IInterest : IASIPContent {
      // TODO List of Properties? TopicS, etc. implicites more than one or done by the Set?
      /// <summary>
      ///   Interest property for Topics to be set.
      /// </summary>
      /// 
      /// Topics are stored in semantic tag sets. They describe their semantics. 
      /// That’s done with a subject identiﬁer, which have a Set of URIs (generally URL's)
      /// describing the same thing named with a topic name. 
      ISemanticTagSet Topics { get; set; }
      /// <summary>
      ///   The Type of Interest. // TODO Comment/Define the types.
      /// </summary>
      /// 
      ISemanticTagSet Types { get; set; }
      /// <summary>
      /// Trusted Peers that verificate the Information of an individual Peer.
      /// </summary>
      /// 
      /// Allows to be interested in someones Knowledge under the condition of this Peer
      /// being verificated (like "Web of Trust") by someone in the Approvers List.
      /// Approvers are trusted by own peer and can be set/ add.
      IList<IPeerSemanticTag> Approvers { get; set; }
      /// <summary>
      ///   It´s the Originators peer of an Knowledge. He could have signed the message but must not.
      /// </summary>
      /// TODO multiple senders?
      /// The Sender is the first Source of the specified message - the Originator. He can sign the message
      /// for better secure Source Identification but it´s not necessary.
      IPeerSemanticTag Sender { get; set; }
      /// <summary>
      /// The Remote Peers of an interest.
      /// </summary>
      IList<IPeerSemanticTag> Recipients { get; set; } // TODO recipients or receivers ?? BNF vs JAVA
      /// <summary>
      /// The spatial Location of an interest belonging on earth coordinates.
      /// </summary>
      IList<ISpatialSemanticTag> Locations { get; set; }
      /// <summary>
      /// The Time Dimension of the Interest. 
      /// </summary>
      /// 
      /// Time semantic tags describe a period of time.
      /// They are mainly used to describe time frames in which interests or information oﬀering are valid.
      IList<ITimeSemanticTag> Times { get; set; }
      /// <summary>
      /// The Direction of interest. Possible directions are NO, IN, OUT or INOUT. 
      /// It Specifies if an interest can be send or received.
      /// </summary>
      Directions Direction { get; set; }
    }
  }
}
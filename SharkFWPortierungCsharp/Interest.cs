using System.Collections.Generic;

namespace Shark.ASIP {
  public class Interest : IInterest {
    public ISemanticTagSet Topics { get; set; }
    public ISemanticTagSet Types { get; set; }
    public IList<IPeerSemanticTag> Approvers { get; set; }
    public IPeerSemanticTag Sender { get; set; }
    public IList<IPeerSemanticTag> Recipients { get; set; }
    public IList<ISpatialSemanticTag> Locations { get; set; }
    public IList<ITimeSemanticTag> Times { get; set; }
    public Directions Direction { get; set; }

    private Interest() { }
    public Interest(Directions direction) {
      Direction = direction;
    }

    public Interest(ISemanticTagSet topics, ISemanticTagSet types, IList<IPeerSemanticTag> approvers, IPeerSemanticTag sender, 
                    IList<IPeerSemanticTag> recipients, IList<ISpatialSemanticTag> locations, IList<ITimeSemanticTag> times, Directions direction) {
      Topics = topics;
      Types = types;
      Approvers = approvers;
      Sender = sender;
      Recipients = recipients;
      Locations = locations;
      Times = times;
      Direction = direction;
    }
  }
}

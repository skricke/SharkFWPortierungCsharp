using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shark.ASIP;
using Shark.ASIP.SemanticTags;
using Shark.ASIP.SemanticNets;
using Shark.ASIP.SemanticTags.Types;
using Shark.ASIP.Conversion;

namespace SharkTestKonsole {
  class Program {
    private static IList<IPeerSemanticTag> approvers;
    private static IMessageContent content;
    private static IMessageHeader head;
    private static IList<IPeerSemanticTag> recipients;

    static void Main(string[] args) {
      IASIPEngine engine;
      Shark.Development.SharkDevelopmentPlaceholder connection;

      IMessage message;
      string msg = "";
      IInterest interest;
      IKnowledge knowledge;

      IPeerSemanticTag sender;
      IPeerSemanticTag receiverPeer;
      ISpatialSemanticTag receiverSpatial;
      ITimeSemanticTag receiverTime;

      ISemanticNet topicNet;
      ISemanticNet typeNet;
      //IPeerTaxonomy peerTax;

      String[] sis;
      String[] addresses;

      IPeerSemanticTagSet peers;
      ISpatialSemanticTagSet locations;
      ITimeSemanticTagSet times;

      ISemanticTagSet topics;
      ISemanticTagSet types;

      sis = new String[] { "www.test.de", "www.test1.de" };
      addresses = new String[] { "tcp://test.de", "tcp://test1.de" };

      peers = new PeerSemanticTagSet(); //JAVA: InMemoSharkKB.createInMemoPeerSTSet();
      IAddress adr1 = new Address();
      IAddress adr2 = new Address();
      adr1.generateTCPAddress("addr1.de");
      adr2.generateTCPAddress("addr2.de");
      sender = peers.createPeerSemanticTag("SENDER", "www.si1.de", adr1);
      receiverPeer = peers.createPeerSemanticTag("RECEIEVER", "www.si2.de", adr2);

      topics = new SemanticTagSet();//JAVA: InMemoSharkKB.createInMemoSTSet();
      topics.createSemanticTag("Topcic1", "www.topic1.de");
      topics.createSemanticTag("Topcic2", "www.topic2.de");

      types = new SemanticTagSet();//JAVA: InMemoSharkKB.createInMemoSTSet();
      types.createSemanticTag("Types1", "www.types1.de");
      types.createSemanticTag("Types2", "www.types2.de");

      topicNet = new SemanticNet();//JAVA: InMemoSharkKB.createInMemoSemanticNet();
      ISemanticTag topicTag1 = new SemanticTag("Topcic1", "www.topic1.de");
      ISemanticTag topicTag2 = new SemanticTag("Topcic2", "www.topic2.de");
      topicNet.addSemanticTag("TopcicTag1", topicTag1);
      topicNet.addSemanticTag("TopcicTag2", topicTag2);
      IProperty propertyRelation = new Property("pairs", "TopcicTag1", "TopcicTag2");
      topicNet.addRelation(propertyRelation); 

      typeNet = new SemanticNet();//JAVA: InMemoSharkKB.createInMemoSemanticNet();
      ISemanticTag typeTag1 = new SemanticTag("Types1", "www.types1.de");
      ISemanticTag typeTag2 = new SemanticTag("Types2", "www.types2.de");
      typeNet.addSemanticTag("typeTag1", typeTag1);
      typeNet.addSemanticTag("typeTag2", typeTag2);
      
      IProperty typeRelation = new Property("pairs", "typeTag1", "typeTag2");
      typeNet.addRelation(typeRelation);

      //peerTax = InMemoSharkKB.createInMemoPeerTaxonomy();
      //peerTax.createPeerTXSemanticTag("SENDER", "www.si1.de", "tcp://addr1.de");

      approvers = peers.SemanticTags;
      locations = new SpatialSemanticTagSet();
      times = new TimeSemanticTagSet();


      interest = new Interest(topics, types, approvers, sender, recipients, locations.SemanticTags, times.SemanticTags, Directions.INOUT); // new Interest(topics, types, approvers, sender, recipients, locations, times, Directions.INOUT);
      head = new MessageHeader(1.0f, "JSON", "", sender, peers.SemanticTags, false, 10);

      IASIPContent infoContent = new Interest(Directions.INOUT);
      content = new MessageContent(sender, false, ASIPCommand.INSERT, infoContent, null);
      message = new Message(head, content);


      msg = JSONConverter.convertInterestToJSON(interest);
      Console.WriteLine(msg);
      
    }
  }
}

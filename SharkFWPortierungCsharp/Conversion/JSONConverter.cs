using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.Conversion { 
  /// <summary>
  /// Provides JSON-Conversion for ASIP-Messages in Shark Framework.
  /// </summary>
  /// 
  /// Methods can be used to convert from and to JSON. 
  /// Or from JSON to Class, of corse.
  /// 
  /// Following Objects are supported:
  /// <ul>
  ///   <li>Interest</li>
  ///   <li>Knowledge</li>
  /// </ul>
  public static class JSONConverter {
    //    cmd                     = '{'
    //                              header ','
    //                              '"content":' content
    //                          '}' signature ;
    //header                  = '"version":' floatNumber ','
    //                          '"format":' text ','
    //                          '"encryptedKey":' text | void ','
    //                          '"sender":' optionalSemanticTag ','
    //                          '"receiver":' '[' optionalSemanticTags ']' ','
    //                          '"signed":' bool ','
    //                          '"ttl":' number | ( unixTime | utcTime) ;
    //optionalSemanticTag     = peerSemanticTag | spatialSemanticTag | timeSemanticTag ;
    //optionalSemanticTags    = optionalSemanticTag { ',' optionalSemanticTag
    //  };
    //  content                 = '{'
    //                            '"logSender":' logicalSender ','
    //                            '"signed":' bool ','
    //                            ( insert | expose | raw )
    //                          '}' signature ;
    //signature               = text ;
    //insert                  = '"insert":' '[' {knowledges
    //} ']' ;
    ////expose                  = '"expose":' '[' {interests} ']' ;
    //raw                     = '"raw":' text ;
    //logicalSender           = peerSemanticTag ;
    public static string convertMessageToJSON(IMessage message) {
      string json = "{" + Environment.NewLine;
      json += JSONConverter.convertHeader(message.Header) + ",";
      json += "\"content\":\"";

      //json += "\"expose\":\"[" + convertInterestsToJSON(content.Content) + "\"]";
      //switch (message.Content.Command) {
      //  case ASIPCommand.EXPOSE:
      //    json += convertOutContent(message.Content);
      //    break;
      //  case ASIPCommand.INSERT:
      //    json += convertInContent(message.Content);
      //    break;
      //}
      json += Environment.NewLine
        + "}"
        + message.Signature;

      return json;
    }

    public static string convertInMessageToJSON(IInMessage message) {
      string json = "{" + Environment.NewLine;
      json += JSONConverter.convertHeader(message.Header) + ",";
      json += "\"content\":\"";

      //json += "\"expose\":\"[" + convertInterestsToJSON(content.Content) + "\"]";
      json += convertInContent(message.Content);
      json += Environment.NewLine
        + "}"
        + message.Signature;

      return json;
    }

    public static string convertOutMessageToJSON(IOutMessage message) {
      string json = "{" + Environment.NewLine;
      json += JSONConverter.convertHeader(message.Header) + ",";
      json += "\"content\":";

      //json += "\"expose\":\"[" + convertInterestsToJSON(content.Content) + "\"]";
      
      json += convertOutContent(message.Content);
          
        
      json += Environment.NewLine
        + "}"
        + message.Signature;

      return json;
    }

    private static string convertHeader(IMessageHeader head) {
      string json = "";

      json += "\"version\":\"" + head.Version + "\"," + Environment.NewLine
      + "\"format\":\"" + head.Format + "\"," + Environment.NewLine
      + "\"encryptedKey\":\"" + head.EncryptedKey + "\"," + Environment.NewLine
      + "\"sender\":\"" + semanticTagToJSON(head.Sender) + "\"," + Environment.NewLine
      + "\"receiver\":[" + peerSemanticTagsToJSON(head.Receiver) + "]," + Environment.NewLine
      + "\"signed\":\"" + head.Signed  + "\"," + Environment.NewLine
      + "\"ttl\":\"" + head.TimeToLive + "\"" + Environment.NewLine;

      return json;
    }

    private static string convertInContent(IInMessageContent content) {
      string json = "{" + Environment.NewLine;
      json += "\"logSender\":" + peerSemanticTagToJSON(content.LogicalSender) + "," + Environment.NewLine
        + "\"signed\":\"" + content.Signed + "\"," + Environment.NewLine;

      switch (content.Command) {
        case ASIPCommand.EXPOSE:
          //json += "\"expose\":\"[" + convertInterestsToJSON(content.Content) + "\"]";
          break;
        case ASIPCommand.INSERT:
          json += "\"insert\":\"[" + convertKnowledgesToJSON(content.Content) + "\"]";
          break;
        case ASIPCommand.RAW:
          json += "\"raw\":\"" + content.Content + "\"";
          break;
      }

      json += Environment.NewLine + "}"
        + content.Signature;

      return json;
    }

    private static string convertOutContent(IOutMessageContent content) {
      string json = "{" + Environment.NewLine;
      json += "\"logSender\":" + peerSemanticTagToJSON(content.LogicalSender) + "," + Environment.NewLine
        + "\"signed\":\"" + content.Signed + "\"," + Environment.NewLine;

      switch (content.Command) {
        case ASIPCommand.EXPOSE:
          json += "\"expose\":[" + convertInterestsToJSON(content.Content) + "]";
          break;
        case ASIPCommand.INSERT:
          //json += "\"insert\":\"[" + convertKnowledgesToJSON(content.Content) + "\"]";
          break;
        case ASIPCommand.RAW:
          json += "\"raw\":\"" + content.Content + "\"";
          break;
      }

      json += Environment.NewLine + "}"
        + content.Signature;

      return json;
    }

    /// <summary>
    ///   Converts an interest object into a string, which is conform with JSON-format.
    /// </summary>
    /// <param name="interest">The Interest to be converted.</param>
    /// <returns>The object values as JSON-formatted string.</returns>
    public static string convertInterestToJSON(IInterest interest) {
        // TODO Complete JSON-Method and comment it
        string json = "{" + Environment.NewLine;
      
      if (interest != null) {
        string topics = "\"topics\":["
          + JSONConverter.semanticTagsToJSON(interest.Topics)
          + "], " + Environment.NewLine;

        string types = "\"types\":["
          + JSONConverter.semanticTagsToJSON(interest.Types)
          + "], " + Environment.NewLine;

        string approvers = "\"approvers\":["
          + JSONConverter.peerSemanticTagsToJSON(interest.Approvers)
          + "], " + Environment.NewLine;

        List<IPeerSemanticTag> senderlist = new List<IPeerSemanticTag>();
        senderlist.Add(interest.Sender);
        string sender = "\"sender\":"
          + JSONConverter.peerSemanticTagsToJSON(senderlist)
          + ", " + Environment.NewLine;

        string recipients = "\"recipients\":["
          + JSONConverter.peerSemanticTagsToJSON(interest.Recipients)
          + "], " + Environment.NewLine;

        string locations = "\"locations\":["
         + JSONConverter.spatialSemanticTagsToJSON(interest.Locations)
         + "], " + Environment.NewLine;

        string times = "\"times\":["
         + JSONConverter.timeSemanticTagsToJSON(interest.Times)
         + "], " + Environment.NewLine;

        string direction = "\"direction\":\""
         + interest.Direction
         + "\"" + Environment.NewLine;

        json += topics + types + approvers + sender + recipients + locations + times + direction;
      }
        json += Environment.NewLine + "}";

        return json;
      }
      
      /// <summary>
      ///   Serializes a list of interests into JSON-Format.
      /// </summary>
      /// <param name="interests">The List of interests which have to be serialized.</param>
      /// <returns>The interests values as string. String is JSON conform.</returns>
      public static string convertInterestsToJSON(IList<IInterest> interests) {
        string json = "";
        if (interests != null) {
          for (int i = 0; i < interests.Count; i++) {
            if (i > 0) {
              json += ", ";
            }
            json += JSONConverter.convertInterestToJSON(interests[i]);
          }
        }
        return json;
      }
    /// <summary>
    /// knowledges              = knowledge { ',' knowledge } ;
    /// knowledge               = '{'
    /// '"vocabulary":' vocabulary ','
    /// '"infoData":' '[' infoDatas ']' ','
    /// infoContent
    /// '}' ;
    /// vocabulary              = '{' topicDim ',' typeDim ',' peerDim ',' locationDim ',' timeDim '}' ;
    /// infoDatas               = infoData { ',' infoData
    /// };
    /// infoData                = '{'
    /// '"infoSpace":' infoSpace ','
    /// '"infoMetaData":' '[' [infoMetaDatas] ']'
    /// '}' ;
    /// infoMetaDatas           = infoMetaData { ',' infoMetaData
    /// };
    /// infoMetaData            = '{'
    /// '"name": ' text ','
    /// '"offset":' number ','
    /// '"length":' number
    /// '}' ;
    /// infoContent             = '{'
    /// '"byteStream":' text
    /// '}' ;
    /// infoSpace               = '{'
    /// topics ','
    /// types ','
    /// approvers ','
    /// senders ','
    /// recipients ','
    /// locations ','
    /// times ','
    /// direction
    /// '}'
    /// </summary>
    /// <param name="ken"></param>
    /// <returns></returns>
    public static string convertKnowledgeToJSON(IKnowledge ken) {
      string json = "{" + Environment.NewLine;
      json += "\"vocabulary\":\"" + convertVocabulary(ken.Vocabulary) + "\"," + Environment.NewLine
        + "\"infoData\":\"[" + convertInfoData(ken.Infos.InfoData) + "]\"," + Environment.NewLine
        + convertInfoContent(ken.Infos.InfoContent) + Environment.NewLine
        + "}" + Environment.NewLine;
 
      return json;
    }

    public static string convertKnowledgesToJSON(IList<IKnowledge> kens) {
      string json = "";
      if (kens != null) {
        for (int i = 0; i < kens.Count; i++) {
          if (i > 0) {
            json += ", ";
          }
          json += JSONConverter.convertKnowledgeToJSON(kens[i]);
        }
      }
      return json;
    }

    private static string convertVocabulary(ISharkVocabulary vocabulary) {
      string json = "{" + Environment.NewLine
        + convertSemanticNet(vocabulary.TopicDim) + "," 
        + convertSemanticNet(vocabulary.TypeDim) + "," 
        + convertSemanticNet(vocabulary.PeerDim) + "," 
        + convertSemanticNet(vocabulary.LocationDim) + "," 
        + convertSemanticNet(vocabulary.TimeDim) + Environment.NewLine
        + "}" + Environment.NewLine;
      //topicDim = semanticNet;
      //typeDim = semanticNet;
      //peerDim = peerSemanticTagNet;
      //locationDim = spatialSemanticTagNet;
      //timeDim = timeSemanticTagNet;    
     
      return json;
    }

    private static string convertSemanticNet(ISemanticNet net) {
      string json = "{" + Environment.NewLine
        + "\"stTable\":[";

      foreach (var entry in net.SemanticTagsTable) {
        json += "{\"id\":\"" + entry.Key + "\"},";
        //if (net is IPeerSemanticNet) {
        //  json += peerSemanticTagToJSON(entry.Value);
        //} else if (net is ISpatialSemanticNet) {
        //  json += spatialSemanticTagToJSON(entry.Value);
        //} else if (net is ITimeSemanticNet) {
        //  json += timeSemanticTagToJSON(entry.Value);
        //} else  {
          json += semanticTagToJSON(entry.Value);
        //}
      }

      json += "]," + Environment.NewLine
        + "\"relations\":[" + convertProperties(net.Relations) + "]" + Environment.NewLine
        + "}" + Environment.NewLine;

      return json;
    }

    private static string convertProperties(IList<IProperty> properties) {
      string json = "";
      if (properties != null) {
        for (int i = 0; i < properties.Count; i++) {
          if (i > 0) {
            json += ", ";
          }
          json += convertProperty(properties[i]);
        }
      }
      return json;
    }
    
    private static string convertProperty(IProperty property) {
      string json = "{" + Environment.NewLine
                  + "\"propertyName\":\"" + property.Name + "," + Environment.NewLine
                  + "\"sourceId\":\"" + property.SourceId + "," + Environment.NewLine
                  + "\"targetId\":\"" + property.TargetId + Environment.NewLine
                  + "}" + Environment.NewLine;

      return json;
    }

    //infoDatas = infoData {"," infoData};
    private static string convertInfoData(IInformationData data) {
      string json = "{" + Environment.NewLine
        + "\"infoSpace\":\"" + convertInfoSpace(data.InfoSpace) + "\"," + Environment.NewLine
        + "\"infoMetaData\":\"["+ convertInfoMetaDatas(data.MetaInfos) + "\"]" + Environment.NewLine
        + "}" + Environment.NewLine;
   
        return json;
    }

    private static string convertInfoSpace(IInfoSpace infoSpace) {
      return convertInterestToJSON(infoSpace);      
    }

    /// infoMetaDatas           = infoMetaData { ',' infoMetaData
    /// };
    private static string convertInfoMetaDatas(IInfoMetaData meta) {
      string json =  "{" + Environment.NewLine
        + "\"name\":\"" + meta.Name + "\"," + Environment.NewLine
        + "\"offset\":\"" + meta.Offset + Environment.NewLine
        + "\"length\":\"" + meta.Length + Environment.NewLine
        + "}" + Environment.NewLine;

      return json;
    }

    private static string convertInfoContent(byte content) {
      string json = "{" + Environment.NewLine
        +"\"byteStream\":\"" + content + "\"" + Environment.NewLine
        + "}" + Environment.NewLine;
      return json;
    }

    /// <summary>
    /// Format:
    ///   semanticTagName         = '"name":' name ;
    ///   semanticTagSI           = '"sis":' '[' {subjectIdentifiers} ']' ;
    ///   semanticTag             = '{'
    ///     semanticTagName ','
    ///     semanticTagSI
    ///   '}' ;      
    ///   semanticTags            = semanticTag { ',' semanticTag
    ///   };
    /// </summary>
    /// <param name="tagset"></param>
    /// <returns></returns>
    private static string semanticTagsToJSON(ISemanticTagSet tagset) {
      IList<ISemanticTag> tags = tagset.SemanticTags;
      string json = "";
      //foreach (ISemanticTag tag in tags.SemanticTags) {
      if (tags != null) {
        if (tags != null) {
          for (int i = 0; i < tags.Count; i++) {
            if (i > 0) {
              json += ", ";
            }
            json += semanticTagToJSON(tags[i]);
          }
        }
      }
      return json;
    }

    private static string semanticTagToJSON(ISemanticTag tag) {
      string json = "";
      
      if (tag != null) {               
            json += "{" + Environment.NewLine
              + "\"name\":\"" + tag.Name + "\"," + Environment.NewLine
              + "\"sis\":[" + JSONConverter.sisToJSON(tag.SIS) + "]" + Environment.NewLine
              + "}" + Environment.NewLine;
      }
      return json;
    }


    /// <summary>
    /// Format:
    ///   peerSemanticTag         = '{'
    ///   semanticTag ','
    ///   '"addresses":' '[' {addresses } ']'
    ///   '}' ;
    ///   peerSemanticTags        = peerSemanticTag { ',' peerSemanticTag };
    /// </summary>
    /// <param name="tags">The PeerSemanticTags to be converted.</param>
    /// <returns></returns>
    private static string peerSemanticTagsToJSON(IList<IPeerSemanticTag> tags) {

      //IList<ISemanticTag> tags = tagset.SemanticTags;
      string json = "";
      //foreach (ISemanticTag tag in tags.SemanticTags) {
      if (tags != null) {
        for (int i = 0; i < tags.Count; i++) {
          if (i > 0) {
            json += ", ";
          }
          json += peerSemanticTagToJSON(tags[i]);
        }
      }
      return json;

    }

    private static string peerSemanticTagToJSON(IPeerSemanticTag tag) {
      string json = "";

      if (tag != null) {        
        json += "{" + Environment.NewLine
          + "\"name\":\"" + tag.Name + "\"," + Environment.NewLine
          + "\"sis\":[" + JSONConverter.sisToJSON(tag.SIS) + "], " + Environment.NewLine
          + "\"addresses\":[" + JSONConverter.addressesToJSON(tag.Addresses) + "]" + Environment.NewLine
          + "}" + Environment.NewLine;        
      }
      return json;

    }

    /// <summary>
    /// Format:
    ///  spatialSemanticTag      = '{'
    ///  semanticTag ','
    ///  '"locations":' '[' {locations } ']'
    ///  '}' ;
    ///  spatialSemanticTags     = spatialSemanticTag { ',' spatialSemanticTag };
    /// </summary>
    /// <param name="tags">The SpatialSemanticTags to be converted.</param>
    /// <returns></returns>
    private static string spatialSemanticTagsToJSON(IList<ISpatialSemanticTag> tags) {
        //IList<ISemanticTag> tags = tagset.SemanticTags;
        string json = "";
      //foreach (ISemanticTag tag in tags.SemanticTags) {
        if (tags != null) {
          for (int i = 0; i < tags.Count; i++) {
            if (i > 0) {
              json += ", ";
            }
            json += "{" + Environment.NewLine
              + "\"name\":\"" + tags[i].Name + "\"," + Environment.NewLine
              + "\"sis\":[" + JSONConverter.sisToJSON(tags[i].SIS) + "], " + Environment.NewLine
              + "\"locations\":[" + JSONConverter.locationsToJSON(tags[i].Locations) + "]" + Environment.NewLine
              + "}" + Environment.NewLine;
          }
        }
        return json;
      }

      /// <summary>
      /// Format:
      ///  timeSemanticTag         = '{'
      ///   semanticTag ','
      ///   '"times":' '[' { times } ']'
      ///  '}' ;
      ///  timeSemanticTags        = timeSemanticTag { ',' timeSemanticTag };
      /// </summary>
      /// <param name="tags">The TimeSemanticTags to be converted.</param>
      /// <returns></returns>
      private static string timeSemanticTagsToJSON(IList<ITimeSemanticTag> tags) {
        //IList<ISemanticTag> tags = tagset.SemanticTags;
        string json = "";
      //foreach (ISemanticTag tag in tags.SemanticTags) {
        if (tags != null) {
          for (int i = 0; i < tags.Count; i++) {
            if (i > 0) {
              json += ", ";
            }
            json += "{" + Environment.NewLine
              + "\"name\":\"" + tags[i].Name + "\"," + Environment.NewLine
              + "\"sis\":[" + JSONConverter.sisToJSON(tags[i].SIS) + "], " + Environment.NewLine
              + "\"times\":[" + JSONConverter.timesToJSON(tags[i].Times) + "]" + Environment.NewLine
              + "}" + Environment.NewLine;
          }
        }
        return json;
      }

      /// <summary>
      /// Format:
      ///   time                    = '{'
      ///       from ','
      ///       duration
      ///   '}' ;
      ///   from                    = '"from":' utcTime ',' unixTime ',' sharkTime ;
      ///   utcTime                 = '{' '"utcTime":' ( https://www.ietf.org/rfc/rfc3339.txt Part 5.6 Date and Time on the Internet: Timestamps) '}' ;
      ///   unixTime                = '{' '"unixTime":' number '}' ;
      ///   sharkTime               = '{' '"sharkTime":' void '}' ;
      ///   duration                = '"duration":' number ;
      ///   
      /// </summary>
      /// <param name="times"></param>
      /// <returns></returns>
      private static string timesToJSON(IList<ITime> times) {
        string json = "";
        if (times != null) {
          for (int i = 0; i < times.Count; i++) {
            if (i > 0) {
              json += ", ";
            }
            json += "{" + Environment.NewLine
              + "\"from\": "
                + "{ \"utcTime\":\"" + times[i].FromUtc + "\"}, "
                + "{ \"unixTime\":\"" + times[i].FromUnix + "\"}, "
                + "{ \"sharkTime\":\"" + times[i].FromShark + "\"}," + Environment.NewLine
              + "\"duration\":\"" + times[i].Duration + "\"" + Environment.NewLine
              + "}" + Environment.NewLine;
          }
        }
        return json;
      }

      /// <summary>
      /// Format:
      ///   locations               = location { ',' location } ;
      ///   location                = '{' '"location":' ewkt '}' ;
      ///   ewkt                    = defined at:
      ///       http://docs.opengeospatial.org/is/12-063r5/12-063r5.html ;
      /// </summary>
      /// <param name="locations"></param>
      /// <returns></returns>
      private static string locationsToJSON(IList<ILocation> locations) {
        string json = "";
        for (int i = 0; i < locations.Count; i++) {
          if (i > 0) {
            json += ", ";
          }
          json += "{" + Environment.NewLine
            + "\"location\":\"" + locations[i] + Environment.NewLine
            + "}" + Environment.NewLine;
        }

        return json;
      }

      /// <summary>
      /// Format:  
      ///   address                 = '{'
      ///     '"address":' gcf (volle Addresse)
      ///   '}' ;
      ///   addresses               = address { ',' address };
      /// </summary>
      /// <param name="addresses"></param>
      /// <returns></returns>
      private static string addressesToJSON(IList<IAddress> addresses) {
        string json = "";
        for (int i = 0; i < addresses.Count; i++) {
          if (i > 0) {
            json += ", ";
          }
          json += "{" + Environment.NewLine
            + "\"address\":\"" + addresses[i] + "\"" + Environment.NewLine
            + "}" + Environment.NewLine;
        }

        return json;
      }

      /// <summary>
      /// Format:
      ///   subjectIdentifiers      = subjectIdentifier { ',' subjectIdentifier } ;
      ///   subjectIdentifier       = uri ;
      ///   uri                     = '"uri":' http://www.w3.org/Addressing/URL/5_URI_BNF.html ;
      /// </summary>
      /// <param name="sis">The subject identifiers for conversion.</param>
      /// <returns>Values as JSON-String.</returns>
      private static string sisToJSON(IList<string> sis) {
        string json = "";
        for (int i = 0; i < sis.Count; i++) {
          if(i > 0) {
            json += ", ";
          }
          json += "\"uri\":\"" + sis[i] + "\""; 
        }        

        return json;
      }
    }  
}

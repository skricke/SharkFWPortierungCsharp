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
      /// <summary>
      ///   Converts an interest object into a string, which is conform with JSON-format.
      /// </summary>
      /// <param name="interest">The Interest to be converted.</param>
      /// <returns>The object values as JSON-formatted string.</returns>
      public static string convertInterestToJSON(IInterest interest) {
        // TODO Complete JSON-Method and comment it
        string json = "{" + Environment.NewLine;

        //String topics = "\"topics\": {" + Environment.NewLine
        //  + "\""
        //  + interest.Topics // TODO Conversion of SemanticTags
        //  + "\""
        //  + "}"; // | void

        string topics = "{ \"topics\": [ " 
          + JSONConverter.semanticTagsToJSON(interest.Topics) 
          + " ]"
          + "}, " + Environment.NewLine;

        string types = "{ \"types\": [ "
          + JSONConverter.semanticTagsToJSON(interest.Types)
          + " ]"
          + "}, " + Environment.NewLine;

        string approvers = "{ \"approvers\": [ "
          + JSONConverter.peerSemanticTagsToJSON(interest.Approvers)
          + " ]"
          + "}, " + Environment.NewLine;

        List<IPeerSemanticTag> senderlist = new List<IPeerSemanticTag>();
        senderlist.Add(interest.Sender);
        string sender = "{ \"sender\": "
          + JSONConverter.peerSemanticTagsToJSON(senderlist)
          + "}, " + Environment.NewLine;

        string recipients = "{ \"recipients\": [ "
          + JSONConverter.peerSemanticTagsToJSON(interest.Recipients)
          + " ]"
          + "}, " + Environment.NewLine;

        string locations = "{ \"locations\": [ "
         + JSONConverter.spatialSemanticTagsToJSON(interest.Locations)
         + " ]"
         + "}, " + Environment.NewLine;

        string times = "{ \"times\": [ "
         + JSONConverter.timeSemanticTagsToJSON(interest.Times)
         + " ]"
         + "}, " + Environment.NewLine;

        string direction = "{ \"direction\": "
         + interest.Direction
         + "} " + Environment.NewLine;

        json += topics + types + approvers + sender + recipients + locations + times + direction;
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
        for (int i = 0; i < interests.Count; i++) {
          if (i > 0) {
            json += ", ";
          }
          json += JSONConverter.convertInterestToJSON(interests[i]);
        }

        return json;
      }

      // TODO convert KNOWLEDGES
      public static string convertKnowledgeToJSON(IKnowledge ken) {
        string json = "";

        return json;
      }

      public static string convertKnowledgesToJSON(IKnowledge kens) {
        string json = "";

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
      private static string semanticTagsToJSON(ISemanticTagSet tagset)  {
        IList<ISemanticTag> tags = tagset.SemanticTags;
        string json =  "";
        //foreach (ISemanticTag tag in tags.SemanticTags) {
        for (int i = 0; i < tags.Count; i++) {
          if (i > 0) {
            json += ", ";
          }
          json += "{" + Environment.NewLine
            + "\"name\": " + tags[i].Name + "," + Environment.NewLine
            + "\"sis\": [" + JSONConverter.sisToJSON(tags[i].SIS) + "]" + Environment.NewLine
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
        for (int i = 0; i < tags.Count; i++) {
          if (i > 0) {
            json += ", ";
          }
          json += "{" + Environment.NewLine
            + "\"name\": " + tags[i].Name + "," + Environment.NewLine
            + "\"sis\": [" + JSONConverter.sisToJSON(tags[i].SIS) + "], " + Environment.NewLine
            + "\"addresses\": [" + JSONConverter.addressesToJSON(tags[i].Addresses) + "]" + Environment.NewLine
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
        for (int i = 0; i < tags.Count; i++) {
          if (i > 0) {
            json += ", ";
          }
          json += "{" + Environment.NewLine
            + "\"name\": " + tags[i].Name + "," + Environment.NewLine
            + "\"sis\": [" + JSONConverter.sisToJSON(tags[i].SIS) + "], " + Environment.NewLine
            + "\"locations\": [" + JSONConverter.locationsToJSON(tags[i].Locations) + "]" + Environment.NewLine
            + "}" + Environment.NewLine;
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
        for (int i = 0; i < tags.Count; i++) {
          if (i > 0) {
            json += ", ";
          }
          json += "{" + Environment.NewLine
            + "\"name\": " + tags[i].Name + "," + Environment.NewLine
            + "\"sis\": [" + JSONConverter.sisToJSON(tags[i].SIS) + "], " + Environment.NewLine
            + "\"times\": [" + JSONConverter.timesToJSON(tags[i].Times) + "]" + Environment.NewLine
            + "}" + Environment.NewLine;
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
        for (int i = 0; i < times.Count; i++) {
          if (i > 0) {
            json += ", ";
          }
          json += "{" + Environment.NewLine
            + "\"from\": "
              + "{ \"utcTime\": " + times[i].FromUtc + "}, "
              + "{ \"unixTime\": " + times[i].FromUnix + "}, "
              + "{ \"sharkTime\": " + times[i].FromShark + "}," + Environment.NewLine
            + "\"duration\": " + times[i].Duration + Environment.NewLine
            + "}" + Environment.NewLine;
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
            + "\"location\": " + locations[i] + Environment.NewLine
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
            + "\"address\": " + addresses[i] + Environment.NewLine
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
      private static string sisToJSON(string[] sis) {
        string json = "";
        for (int i = 0; i < sis.Length; i++) {
          if(i > 0) {
            json += ", ";
          }
          json += "\"uri\": " + sis[i]; 
        }        

        return json;
      }
    }  
}

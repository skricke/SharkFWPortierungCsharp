using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark {
  namespace ASIP {
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
    class JSONConverter {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="interest"></param>
      /// <returns></returns>
      public static String convertInterestToJSON(IInterest interest) {
        // TODO Complete JSON-Method and comment it
        String json = "{" + Environment.NewLine;
        String topics = "\"topics\": {" + Environment.NewLine
          + "\""
          + interest.Topics // TODO Conversion of SemanticTags
          + "\""
          + "}"; // | void

        //String types =  '"types":' '{' '"' { semanticTags} | void '"' '}' ;
        //String approvers = '{' '"approvers":' '[' { peerSemanticTags} | void ']' '}';
        //String sender = '{' '"sender":' { peerSemanticTags} | void '}';
        //String recipients = '{' '"recipients":' '[' { peerSemanticTags} | void ']' '}';
        //String locations = '{' '"locations":' '[' { spatialSemanticTags} | void ']' '}';
        //String times = '{' '"times":' '[' { timeSemanticTags} | void ']' '}';
        //String direction = '{' '"direction":' 'IN' | 'OUT' | 'INOUT' | 'NO' '}';

        json += topics + "," + Environment.NewLine;
        //json += types + "," + Environment.NewLine;
        //json += approvers + "," + Environment.NewLine;
        //json += sender + "," + Environment.NewLine;
        //json += recipients + "," + Environment.NewLine;
        //json += locations + "," + Environment.NewLine;
        //json += times + "," + Environment.NewLine;
        //json += direction + "," + Environment.NewLine;

        json += Environment.NewLine + "}";



        return json;
      }
      // TODO interests = interest { ',' interest };
    }

  }
}

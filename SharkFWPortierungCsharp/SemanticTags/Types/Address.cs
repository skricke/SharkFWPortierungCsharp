namespace Shark {
  namespace ASIP {

    /// <summary> Interface for adress used by PeerSemanticTags. Supported are TCP-, HTTP- and MAIL-Adresses. </summary>
    ///
    /// <remarks> sk, 15.03.2016. </remarks>
    public interface Address {

      /// <summary> Gets or sets the type of an Address. </summary>
      ///
      /// <value> The Address type. </value>
      AddressType Type { get; set; }

      /// <summary> Gets or sets the end point of the Address. </summary>
      ///
      /// <value> The end point. </value>
      string endPoint { get; set; }

      // TODO: Address
      //  address                 = '{'
      //                          '"address":' gcf
      //                        '}' ;
      //  addresses               = address { ',' address
      //    };
      //    gcf                     = tcpEndpoint | httpEndpoint | mailEndpoint ;
      //  endPoint                = ( character | '.' | '-' ) { ( character | '.' | '-' ) };
      //  port                    = number ;
      //  tcpEndpoint             = 'tcp' '://' endPoint[':' port] ;
      //  httpEndpoint            = 'http' '://' endPoint[':' port] ;
      //  mailEndpoint            = 'mail' '://' user '@' endPoint[';' mbSize] ;
    }
  }
}
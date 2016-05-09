namespace Shark {
  namespace ASIP {

    /// <summary> Interface for adress used by PeerSemanticTags. Supported are TCP-, HTTP- and MAIL-Adresses. </summary>
    ///
    /// <remarks> sk, 15.03.2016. </remarks>
    public interface IAddress {

      /// <summary> Gets or sets the type of an Address. </summary>
      ///
      /// <value> The Address type. </value>
      AddressType Type { get; set; }

      /// <summary> Gets the complete Address. </summary>
      ///
      /// <value> The real address. </value>
      string Address { get; }

      /// <summary>
      ///   Generates a valid TCP-Address from the given endPoint. Format looks like: 
      ///     tcpEndpoint = 'tcp' '://' endPoint[':' port] ;
      ///     .
      ///   A static implementation is recommended. The Port is optional.      
      /// </summary>
      /// <param name="endPoint">The endPoint of the address.</param>
      /// <returns>A valid address for usage in shark system.</returns>
      /// <exception cref="SharkASIPIllegalArguementException">Thrown if a parameter uses characters, which aren´t allowed.</exception>
      string generateTCPAddress(string endPoint);
      /// <summary>
      ///   Generates a valid TCP-Address from the given endPoint and the optional Port. Format looks like: 
      ///     tcpEndpoint = 'tcp' '://' endPoint[':' port] ;
      ///     .
      ///   A static implementation is recommended.      
      /// </summary>
      /// <param name="endPoint">The endPoint of the address.</param>
      /// <param name="port">The Port of the TCP-Address.</param>
      /// <returns>A valid address for usage in shark system.</returns>
      /// <exception cref="SharkASIPIllegalArguementException">Thrown if a parameter uses characters, which aren´t allowed.</exception>
      string generateTCPAddress(string endPoint, uint port);

      /// <summary>
      ///   Generates a valid HTTP-Address from the given endPoint. Format looks like: 
      ///     httpEndpoint = 'http' '://' endPoint[':' port] ;
      ///     .
      ///   A static implementation is recommended. The Port is optional.      
      /// </summary>
      /// <param name="endPoint">The endPoint of the address.</param>
      /// <returns>A valid address for usage in shark system.</returns>
      /// <exception cref="SharkASIPIllegalArguementException">Thrown if a parameter uses characters, which aren´t allowed.</exception>
      string generateHTTPAddress(string endPoint);
      /// <summary>
      ///   Generates a valid HTTP-Address from the given endPoint. Format looks like: 
      ///     httpEndpoint = 'http' '://' endPoint[':' port] ;
      ///     .
      ///   A static implementation is recommended. The Port is optional.      
      /// </summary>
      /// <param name="endPoint">The endPoint of the address.</param>
      /// <param name="port">The Port of the HTTP-Address.</param>
      /// <returns>A valid address for usage in shark system.</returns>
      /// <exception cref="SharkASIPIllegalArguementException">Thrown if a parameter uses characters, which aren´t allowed.</exception>
      string generateHTTPAddress(string endPoint, uint port);

      /// <summary>
      ///   Generates a valid Mail-Address from the given endPoint. Format looks like: 
      ///     mailEndpoint = 'mail' '://' user '@' endPoint[';' mbSize] ;
      ///     .
      ///   A static implementation is recommended. The mbSize is optional.      
      /// </summary>
      /// <param name="endPoint">The endPoint of the address.</param>
      /// <param name="user">The username of the Mail-Address.</param>
      /// <returns>A valid address for usage in shark system.</returns>
      /// <exception cref="SharkASIPIllegalArguementException">Thrown if a parameter uses characters, which aren´t allowed.</exception>
      string generateMailAddress(string user, string endPoint);
      /// <summary>
      ///   Generates a valid Mail-Address from the given endPoint. Format looks like: 
      ///     mailEndpoint = 'mail' '://' user '@' endPoint[';' mbSize] ;
      ///     .
      ///   A static implementation is recommended. The Port is optional.      
      /// </summary>
      /// <param name="endPoint">The endPoint of the address.</param>
      /// <param name="user">The username of the Mail-Address.</param>
      /// <param name="mbSize">The size in MB.</param>
      /// <returns>A valid address for usage in shark system.</returns>
      /// <exception cref="SharkASIPIllegalArguementException">Thrown if a parameter uses characters, which aren´t allowed.</exception>
      string generateMailAddress(string user, string endPoint, uint mbSize);
      
    }
  }
}
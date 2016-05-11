using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticTags.Types {
  class Address : IAddress {
    public AddressType Type { get; private set; }
    public string CompleteAddress { get; private set; }

    public Address() {
      Type = AddressType.NULL;
      CompleteAddress = "";
    }

    /// <summary>
    ///   Generates a valid HTTP-Address from the given endPoint. Format looks like: 
    ///     httpEndpoint = 'http' '://' endPoint[':' port] ;
    ///     .
    ///   A static implementation is recommended. The Port is optional.      
    /// </summary>
    /// <param name="endPoint">The endPoint of the address.</param>
    /// <returns>A valid address for usage in shark system.</returns>
    /// <exception cref="SharkASIPIllegalArguementException">Thrown if a parameter uses characters, which aren´t allowed.</exception>
    public string generateHTTPAddress(string endPoint) {
      checkParameter(endPoint);
      string httpEndpoint = "http://" + endPoint;
      Type = AddressType.HTTP;
      CompleteAddress = httpEndpoint;

      return httpEndpoint;
    }

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
    public string generateHTTPAddress(string endPoint, uint port) {
      this.generateHTTPAddress(endPoint);
      CompleteAddress += ":" + port;

      return CompleteAddress;
    }

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
    public string generateMailAddress(string user, string endPoint) {
      // TODO endPoint verifizieren
      checkParameter(user + endPoint);
      string mailEndpoint = "mail://" + user + "@" + endPoint;
      Type = AddressType.MAIL;
      CompleteAddress = mailEndpoint;

      return mailEndpoint;
    }

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
    public string generateMailAddress(string user, string endPoint, uint mbSize) {
      this.generateMailAddress(user, endPoint);
      CompleteAddress += ";" + mbSize;

      return CompleteAddress;
    }

    /// <summary>
    ///   Generates a valid TCP-Address from the given endPoint. Format looks like: 
    ///     tcpEndpoint = 'tcp' '://' endPoint[':' port] ;
    ///     .
    ///   A static implementation is recommended. The Port is optional.      
    /// </summary>
    /// <param name="endPoint">The endPoint of the address.</param>
    /// <returns>A valid address for usage in shark system.</returns>
    /// <exception cref="SharkASIPIllegalArguementException">Thrown if a parameter uses characters, which aren´t allowed.</exception>
    public string generateTCPAddress(string endPoint) {
      checkParameter(endPoint);
      string tcpEndpoint = "tcp://" + endPoint;
      Type = AddressType.TCP;
      CompleteAddress = tcpEndpoint;

      return tcpEndpoint;
    }

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
    public string generateTCPAddress(string endPoint, uint port) {
      this.generateTCPAddress(endPoint);
      CompleteAddress += ":" + port;

      return CompleteAddress;
    }

    private void checkParameter(string parameter) {
      string pattern = @"*[\w\.\-]";
      // Instantiate the regular expression object.
      Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
      
      if (!r.IsMatch(parameter)) {
        throw new SharkASIPIllegalArguementException("Parameter uses characters, which aren´t allowed.");
      }
    }
  }
}

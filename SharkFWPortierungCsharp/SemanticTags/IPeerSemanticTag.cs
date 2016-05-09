using System.Collections.Generic;

namespace Shark {
  namespace ASIP {

    /// <summary> Peers are considered regular semantic tags which also have a number of addresses, that
    /// can be used to communicate with the peer. The addresses must comply to the shark address
    /// schema </summary>
    ///
    /// <see href="https://github.com/SharedKnowledge/SharkFW/blob/master/src/java/core/net/sharkfw/protocols/Protocols.java"/>
    /// <remarks> sk, 15.03.2016. </remarks>
    public interface IPeerSemanticTag : ISemanticTag {

      /// <summary> Property with the addresses of the PeerSemanticTag. </summary>
      ///
      /// <value> The addresses. </value>
      IList<IAddress> Addresses { get; }

      /// <summary> Adds a TCP address to 'port'. </summary>
      ///
      /// <param name="endPoint"> The end point. </param>
      /// <param name="port">     The port. </param>
      /// <exception cref="SharkASIPIllegalArguementException"> Thrown if wrong Parameter given. </exception>
      void addTCPAddress(string endPoint, int port);

      /// <summary> Adds a HTTP address to 'port'. </summary>
      ///
      /// <param name="endPoint"> The end point. </param>
      /// <param name="port">     The port. </param>
      /// <exception cref="SharkASIPIllegalArguementException"> Thrown if wrong Parameter given. </exception>
      void addHTTPAddress(string endPoint, int port);

      /// <summary> Adds a mail address. </summary>
      ///
      /// <param name="user">     The user. </param>
      /// <param name="endPoint"> The end point. </param>
      /// <param name="mbSize">   Size of the megabytes. </param>
      /// <exception cref="SharkASIPIllegalArguementException"> Thrown if wrong Parameter given. </exception>
      void addMAILAddress(string user, string endPoint, int mbSize);

      /// <summary> Removes the address described by remAddress. </summary>
      ///
      /// <param name="remAddress"> The address wanted to be removed. </param>s
      void removeAddress(IAddress remAddress);
    }
  }
}
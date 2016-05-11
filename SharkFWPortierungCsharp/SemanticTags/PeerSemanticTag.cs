using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark.ASIP.SemanticTags {
  class PeerSemanticTag : SemanticTag, IPeerSemanticTag {
    public IList<IAddress> Addresses { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="endPoint"></param>
    /// <param name="port"></param>
    /// <exception cref="SharkASIPIllegalArguementException"> Thrown if wrong Parameter given. </exception>
    public void addHTTPAddress(string endPoint, uint port) {
      IAddress newAddress = new Types.Address();
      newAddress.generateHTTPAddress(endPoint, port);

      Addresses.Add(newAddress);
    }

    public void addMAILAddress(string user, string endPoint, uint mbSize) {
      IAddress newAddress = new Types.Address();
      newAddress.generateMailAddress(user, endPoint, mbSize);

      Addresses.Add(newAddress);
    }

    public void addTCPAddress(string endPoint, uint port) {
      IAddress newAddress = new Types.Address();
      newAddress.generateTCPAddress(endPoint, port);

      Addresses.Add(newAddress);
    }

    public void removeAddress(IAddress remAddress) {
      Addresses.Remove(remAddress);
    }
  }
}

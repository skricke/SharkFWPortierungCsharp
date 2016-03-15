using System;

namespace Shark {
  namespace ASIP {

    /// <summary> Exception for signalling shark framework has a SIP error. </summary>
    ///
    /// <remarks> sk, 15.03.2016. </remarks>
    class SharkASIPException : SharkException {
      /// <summary>
      ///   Unique ID for serialisation. Normally not necessary in C# Serialization but kept because of the Java-Version.
      /// </summary>
      /// "E16DAE2C-4F60-4C10-A725-6979CCA22670"
      private static readonly Guid serialVersionUID = new Guid("E16DAE2C-4F60-4C10-A725-6979CCA22670");

      /// <summary> Default constructor. </summary>
      /// Inherited from SharkException-class.
      /// 
      /// <remarks> sk, 15.03.2016. </remarks>
      public SharkASIPException() : base() {
      }

      /// <summary> Creates a new Instance of SharkASIPException-Class with the given error message. 
      ///           Message add "ASIP: " before Errormessage.</summary>
      ///
      /// <remarks> sk, 15.03.2016. </remarks>
      ///
      /// <param name="errorMessage">  The string for wanted error-message. </param>
      public SharkASIPException(String errorMessage) : base("ASIP: " + errorMessage) {
      }

      /// <summary> Creates a new Instance of SharkASIPException-Class with the given error message. 
      ///           Additionally it shows the message of a given BaseException. 
      ///           Message add "ASIP: " before Errormessage. </summary>
      ///
      /// <remarks> sk, 15.03.2016. </remarks>
      ///
      /// <param name="errorMessage"> The string for wanted error-message. </param>
      /// <param name="cause">        The cause of thrown Exception gives the Message of underlying BaseException. </param>
      public SharkASIPException(String errorMessage, Exception cause) : base("ASIP: " + errorMessage + " Cause: " + cause.GetBaseException().Message) {
      }
    }
  }
}


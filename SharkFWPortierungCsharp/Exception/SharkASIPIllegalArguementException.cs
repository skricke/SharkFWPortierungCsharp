using System;

namespace Shark {
  namespace ASIP {

    /// <summary> Exception for IllegalArguementException in ASIP shark framework. </summary>
    ///
    /// <remarks> sk, 15.03.2016. </remarks>
    class SharkASIPIllegalArguementException : SharkASIPException {
      /// <summary>
      ///   Unique ID for serialisation. Normally not necessary in C# Serialization but kept because of the Java-Version.
      /// </summary>
      /// "3405B8EC-1E38-4093-A981-7166EFAF7540"
      private static readonly Guid serialVersionUID = new Guid("3405B8EC-1E38-4093-A981-7166EFAF7540");

      /// <summary> Default constructor. </summary>
      /// Inherited from SharkException-class.
      /// 
      /// <remarks> sk, 15.03.2016. </remarks>
      public SharkASIPIllegalArguementException() : base() {
      }

      /// <summary> Creates a new Instance of SharkASIPException-Class with the given error message. 
      ///           Message add "ASIP: " before Errormessage.</summary>
      ///
      /// <remarks> sk, 15.03.2016. </remarks>
      ///
      /// <param name="errorMessage">  The string for wanted error-message. </param>
      public SharkASIPIllegalArguementException(String errorMessage) : base(errorMessage) {
      }

      /// <summary> Creates a new Instance of SharkASIPException-Class with the given error message. 
      ///           Additionally it shows the message of a given BaseException. 
      ///           Message add "ASIP: " before Errormessage. </summary>
      ///
      /// <remarks> sk, 15.03.2016. </remarks>
      ///
      /// <param name="errorMessage"> The string for wanted error-message. </param>
      /// <param name="cause">        The cause of thrown Exception gives the Message of underlying BaseException. </param>
      public SharkASIPIllegalArguementException(String errorMessage, Exception cause) : base(errorMessage, cause) {
      }
    }
  }
}


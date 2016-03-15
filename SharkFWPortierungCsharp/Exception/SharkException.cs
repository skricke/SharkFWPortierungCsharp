using System;

namespace Shark {

  /// <summary> Basic Exception for signalling shark errors. </summary>
  ///
  /// <remarks> sk, 15.03.2016. </remarks>
  class SharkException : Exception {
    /// <summary>
    ///   Unique ID for serialisation. Normally not necessary in C# Serialization but kept because of the Java-Version.
    /// </summary>
    /// {67040FE5-6DEC-4F3F-98E2-75BC7B2A2789}
    private static readonly Guid serialVersionUID = new Guid("67040FE5-6DEC-4F3F-98E2-75BC7B2A2789");

    /// <summary> Default constructor. </summary>
    /// Inherited from Exception-class.
    /// 
    /// <remarks> sk, 15.03.2016. </remarks>
    public SharkException() : base() {
    }

    /// <summary> Creates a new Instance of SharkException-Class with the given error message. </summary>
    ///
    /// <remarks> sk, 15.03.2016. </remarks>
    ///
    /// <param name="errorMessage">  The string for wanted error-message. </param>
    public SharkException(String errorMessage) : base(errorMessage) {
    }

    /// <summary> Creates a new Instance of SharkException-Class with the given error message. 
    ///           Additionally it shows the message of a given BaseException. </summary>
    ///
    /// <remarks> sk, 15.03.2016. </remarks>
    ///
    /// <param name="errorMessage"> The string for wanted error-message. </param>
    /// <param name="cause">        The cause of thrown Exception gives the Message of underlying BaseException. </param>
    public SharkException(String errorMessage, Exception cause) : base(errorMessage + cause.GetBaseException().Message) {
    }
  }
}


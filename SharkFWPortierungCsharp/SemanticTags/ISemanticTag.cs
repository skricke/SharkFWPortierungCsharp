namespace Shark.ASIP {

  /// <summary> A semantic tag. </summary>
  ///
  /// <remarks> sk, 15.03.2016. </remarks>
  public interface ISemanticTag {
    
    /// <summary> Property with get and set methods for the semanticTagName. </summary>
    ///
    /// <value> The name. </value>
    string Name { get; set; }

    /// <summary> Gets the actual subject identifiers. A subjectIdentifier is a uri: http://www.w3.org/Addressing/URL/5_URI_BNF.html. </summary>
    ///
    /// <value> The subjectIdentifiers. </value>
    /// <exception cref="SharkASIPIllegalArguementException">Thrown if the SI has a wrong URI-format.</exception>
    string[] SIS { get; }

    /// <summary> Adds the subject identifier. </summary>
    ///
    /// <param name="newSI"> The new subject identifier to be add. </param>
    void addSI(string newSI);

    /// <summary> Remove the subject identifier. </summary>
    ///
    /// <param name="subjectIdentifier"> The subject identifier to be removed. </param>
    void removeSI(string subjectIdentifier);

  }
}
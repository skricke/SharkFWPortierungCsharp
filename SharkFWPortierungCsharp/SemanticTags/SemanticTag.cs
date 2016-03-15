﻿namespace Shark.ASIP {

  /// <summary> A semantic tag. </summary>
  ///
  /// <remarks> sk, 15.03.2016. </remarks>
  public interface SemanticTag {
    
    /// <summary> Property with get and set methods for the semanticTagName. </summary>
    ///
    /// <value> The name. </value>
    string Name { get; set; }

    /// <summary> Gets or sets the subject identifiers. </summary>
    ///
    /// <value> The subjectIdentifiers. </value>
    /// <exception cref="SharkASIPIllegalArguementException">Thrown if the SI has a wrong URI-format.</exception>
    string[] SIS { get; set; }

    /// <summary> Adds the sis. </summary>
    ///
    /// <param name="newSIS"> The new sis to be add. </param>
    void addSIS(string newSIS);

  }
}
namespace Shark.ASIP {
  /// <summary>
  ///   The available commands in the Semantic Internet Protocol (ASIP).
  /// </summary>
  public enum ASIPCommand {
    /// <summary>
    ///   The insert command signalize an insertion of a Knowledge.
    /// </summary>
    INSERT,
    /// <summary>
    ///   The expose command signalize that a peer wants to receive Knowledge(s) which he is interested in.
    /// </summary>
    EXPOSE,
    /// <summary>
    ///   Marks a shark message as raw formatted.
    /// </summary>
    RAW
  }
}
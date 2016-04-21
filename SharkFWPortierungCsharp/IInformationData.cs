namespace Shark.ASIP {
  public interface IInformationData {    
    IInfoSpace infoSpace { get; }
    IInfoMetaData metaInfos { get; } //TODO Design? belongs to Information, multiple in bnf
    
  }
}
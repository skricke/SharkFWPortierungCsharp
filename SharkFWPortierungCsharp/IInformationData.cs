namespace Shark.ASIP {
  public interface IInformationData {    
    IInfoSpace InfoSpace { get; }
    IInfoMetaData MetaInfos { get; } //TODO Design? belongs to Information, multiple in bnf
    
  }
}
namespace Shark.ASIP {
  public interface IInfoMetaData {
    
    string Name { get; set; }
    uint Offset { get; set; }
    uint Length { get; set; }
  }
}
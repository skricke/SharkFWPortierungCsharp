namespace Shark.ASIP {
  public interface IInformation {
    IInformationData InfoData { get; }
    byte InfoContent { get; set; }
  }
}
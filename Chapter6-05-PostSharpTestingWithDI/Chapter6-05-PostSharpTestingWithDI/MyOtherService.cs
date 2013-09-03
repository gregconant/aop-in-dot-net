namespace Chapter6_05_PostSharpTestingWithDI {
  public interface IMyOtherService {
    void DoOtherThing();
  }
  
  public class MyOtherService : IMyOtherService {
    public void DoOtherThing() {
      // lied, not actually doing anything.
    }
  }
}

using System.Web;

namespace Ch4_MobileBrowserAspNet {
  public class MobileDetect {
    private readonly HttpRequest _httpRequest;

    public MobileDetect(HttpContext context) {
      _httpRequest = context.Request;

    }

    public bool IsMobile() {
      // we're going to pretend we're on a mobile device,
      // because otherwise this will be a difficult demo
      return true;
      return _httpRequest.Browser.IsMobileDevice &&
             (IsAndroid() || IsApple() || IsWindowsPhone());
    }

    public bool IsAndroid() {
      return _httpRequest.UserAgent.Contains("Android");
    }

    public bool IsApple() {
      return _httpRequest.UserAgent.Contains("iPhone") ||
             _httpRequest.UserAgent.Contains("iPad");
    }

    public bool IsWindowsPhone() {
      return _httpRequest.UserAgent.Contains("Windows Phone OS");
    }
  }
}

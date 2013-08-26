using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch4_MobileBrowserAspNet.Modules {
  public class MobileInterstitialModule : IHttpModule {
    public void Dispose() {
      // don't need anything here - no resources we have to dispose
    }

    public void Init(HttpApplication context) {
      context.BeginRequest += new EventHandler(context_BeginRequest);
    }

    void context_BeginRequest(object sender, EventArgs e) {

      if (NoThanksCookieIsSet()) {
        return;
      }
      if (OnMobileInterstitial() || ComingFromMobileInterstitial()) {
        return;
      }

      var context = HttpContext.Current;
      
      // check for mobile user
      var detection = new MobileDetect(context);
      if (detection.IsMobile()) {
        // get page they were trying to get to
        var url = context.Request.RawUrl;
        var encodedUrl = HttpUtility.UrlEncode(url);
        // pass this page to the splash page so that if they
        // don't want the mobile app, we can send them on
        // their way (as they probably wanted all along)
        context.Response.Redirect(
          "MobileInterstitial.aspx?returnUrl=" + encodedUrl);
      }
    }

    private bool NoThanksCookieIsSet() {
      return HttpContext.Current.Request.Cookies["NoThanks"] != null;
    }

    private bool ComingFromMobileInterstitial() {
      var httpRequest = HttpContext.Current.Request;
      if (httpRequest.UrlReferrer == null) {
        return false;
      }
      return httpRequest.UrlReferrer.AbsoluteUri
                        .Contains("MobileInterstitial.aspx");
    }

    private bool OnMobileInterstitial() {
      var httpRequest = HttpContext.Current.Request;
      return httpRequest.RawUrl
                        .Contains("MobileInterstitial.aspx");
      
    }
  }
}
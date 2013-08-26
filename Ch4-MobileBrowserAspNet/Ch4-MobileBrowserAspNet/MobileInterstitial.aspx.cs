using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ch4_MobileBrowserAspNet {
  public partial class MobileInterstitial : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
      btnDownload.Click += btnDownload_Click;
      btnNoThanks.Click += btnNoThanks_Click;
    }
    
    protected void btnNoThanks_Click(object sender, EventArgs e) {
      var splashCookie = new HttpCookie("NoThanks", "set");
      // never ask them again! at least for 2 minutes.
      splashCookie.Expires = DateTime.Now.AddMinutes(2);
      Response.Cookies.Add(splashCookie);

      var returnUrl = Request.QueryString["returnUrl"] ?? "Default.aspx";
      Response.Redirect(HttpUtility.UrlDecode(returnUrl));
    }

    protected void btnDownload_Click(object sender, EventArgs e) {
      var mobileDetect = new MobileDetect(Context);
      if (mobileDetect.IsAndroid()) {
        Response.Redirect(
          "market://search?q=pname:com.myappname.android");
      } else if (mobileDetect.IsApple()) {
        Response.Redirect("http://itunes.com/apps/appname");
      } else if (mobileDetect.IsWindowsPhone()) {
        Response.Redirect(
          "http://windowsphone.com/s?appid={my-app-id-guid}");
      }
      else {
        Response.Redirect("UnsupportedBrowser.aspx");
      }

    }

  }
}
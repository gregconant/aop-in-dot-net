using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ch4_MobileBrowserAspNet {
  public partial class UnsupportedBrowser : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
      btnBack.Click += new EventHandler(btnBack_Click);
    }

    void btnBack_Click(object sender, EventArgs e) {
      Response.Redirect("Default.aspx");
    }
  }
}
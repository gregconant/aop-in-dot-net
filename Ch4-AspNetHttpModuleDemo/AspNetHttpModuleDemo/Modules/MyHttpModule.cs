using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetHttpModuleDemo.Modules {
  public class MyHttpModule : IHttpModule {
    public void Dispose() {
      throw new NotImplementedException();
    }

    public void Init(HttpApplication context) {
      context.BeginRequest += new EventHandler(context_BeginRequest);
      context.EndRequest += new EventHandler(context_EndRequest);
    }
    
    void context_BeginRequest(object sender, EventArgs e) {
      var app = (HttpApplication) sender;
      app.Response.Write("Before the page is requested");
    }

    void context_EndRequest(object sender, EventArgs e) {
      var app = (HttpApplication) sender;
      app.Response.Write("After the page is handled");
    }

  }
}
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MobileInterstitial.aspx.cs"
  Inherits="Ch4_MobileBrowserAspNet.MobileInterstitial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Splash Page</title>
  <meta name="viewport" 
        content="user-scalable=no, width=device-width" />
</head>

<body>
  <h2>Check out our mobile app!</h2>
  <p>We made a mobile app that tells you the same thing as our normal site,
  but is way more annoying to download and use!</p>
  <form id="mobileAppForm" runat="server">
    <asp:Button ID="btnDownload" Text="Get the App" runat="server" 
      onclick="btnDownload_Click" />
    <asp:Button ID="btnNoThanks" Text="Thanks Anyway" runat="server" 
      onclick="btnNoThanks_Click" />
  </form>
</body>
</html>

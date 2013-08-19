using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UIThreadingExample.Aspects;

namespace UIThreadingExample {
  public partial class Form1 : Form {
    private TwitterService _twitter;

    public Form1() {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e) {
      _twitter = new TwitterService();
    }

    private void updateButton_Click(object sender, EventArgs e) {
      GetNewTweet();
    }

    [WorkerThread]
    private void GetNewTweet() {
      var tweet = _twitter.GetTweet();
      UpdateTweetListBox(tweet);
    }

    [UIThread]
    private void UpdateTweetListBox(string tweet) {
      listTweets.Items.Add(tweet);
    }
  }
}

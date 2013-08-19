namespace UIThreadingExample {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.updateButton = new System.Windows.Forms.Button();
      this.listTweets = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // updateButton
      // 
      this.updateButton.Location = new System.Drawing.Point(13, 13);
      this.updateButton.Name = "updateButton";
      this.updateButton.Size = new System.Drawing.Size(75, 23);
      this.updateButton.TabIndex = 0;
      this.updateButton.Text = "Update";
      this.updateButton.UseVisualStyleBackColor = true;
      this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
      // 
      // listTweets
      // 
      this.listTweets.FormattingEnabled = true;
      this.listTweets.Location = new System.Drawing.Point(121, 13);
      this.listTweets.Name = "listTweets";
      this.listTweets.Size = new System.Drawing.Size(151, 212);
      this.listTweets.TabIndex = 1;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.listTweets);
      this.Controls.Add(this.updateButton);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button updateButton;
    private System.Windows.Forms.ListBox listTweets;
  }
}


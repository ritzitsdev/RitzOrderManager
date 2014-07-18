namespace OrderDispatcher
{
  partial class ConfigFolders
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.lBoxWatched = new System.Windows.Forms.ListBox();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnRemove = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.lblMessage = new System.Windows.Forms.Label();
      this.btnOK = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lBoxWatched
      // 
      this.lBoxWatched.FormattingEnabled = true;
      this.lBoxWatched.Location = new System.Drawing.Point(13, 47);
      this.lBoxWatched.Name = "lBoxWatched";
      this.lBoxWatched.Size = new System.Drawing.Size(435, 134);
      this.lBoxWatched.TabIndex = 0;
      // 
      // btnAdd
      // 
      this.btnAdd.Location = new System.Drawing.Point(13, 201);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(75, 23);
      this.btnAdd.TabIndex = 1;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // btnRemove
      // 
      this.btnRemove.Location = new System.Drawing.Point(118, 201);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(75, 23);
      this.btnRemove.TabIndex = 2;
      this.btnRemove.Text = "Remove";
      this.btnRemove.UseVisualStyleBackColor = true;
      this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(13, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(244, 20);
      this.label1.TabIndex = 3;
      this.label1.Text = "Folders currently being monitored";
      // 
      // lblMessage
      // 
      this.lblMessage.AutoSize = true;
      this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMessage.Location = new System.Drawing.Point(12, 249);
      this.lblMessage.MaximumSize = new System.Drawing.Size(435, 0);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(0, 20);
      this.lblMessage.TabIndex = 4;
      this.lblMessage.UseMnemonic = false;
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(368, 319);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 5;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // ConfigFolders
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(460, 354);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.lblMessage);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnRemove);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.lBoxWatched);
      this.Name = "ConfigFolders";
      this.Text = "Settings";
      this.Load += new System.EventHandler(this.ConfigFolders_Load_1);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox lBoxWatched;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnRemove;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.Button btnOK;
  }
}
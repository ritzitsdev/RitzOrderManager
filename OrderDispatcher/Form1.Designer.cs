namespace OrderDispatcher
{
  partial class Form1
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
      this.btnRefresh = new System.Windows.Forms.Button();
      this.btnPrintHere = new System.Windows.Forms.Button();
      this.btnOutlab = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.configureFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.btnDetails = new System.Windows.Forms.Button();
      this.lblSettingsChanged = new System.Windows.Forms.Label();
      this.btnHistory = new System.Windows.Forms.Button();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnRefresh
      // 
      this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnRefresh.Location = new System.Drawing.Point(10, 35);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(120, 27);
      this.btnRefresh.TabIndex = 0;
      this.btnRefresh.Text = "Refresh Order List";
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // btnPrintHere
      // 
      this.btnPrintHere.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnPrintHere.Location = new System.Drawing.Point(11, 317);
      this.btnPrintHere.Name = "btnPrintHere";
      this.btnPrintHere.Size = new System.Drawing.Size(186, 34);
      this.btnPrintHere.TabIndex = 1;
      this.btnPrintHere.Text = "Print Selected Order In-Store";
      this.btnPrintHere.UseVisualStyleBackColor = true;
      this.btnPrintHere.Click += new System.EventHandler(this.btnPrintHere_Click);
      // 
      // btnOutlab
      // 
      this.btnOutlab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOutlab.Location = new System.Drawing.Point(205, 317);
      this.btnOutlab.Name = "btnOutlab";
      this.btnOutlab.Size = new System.Drawing.Size(205, 34);
      this.btnOutlab.TabIndex = 2;
      this.btnOutlab.Text = "Send Selected Order To Outlab";
      this.btnOutlab.UseVisualStyleBackColor = true;
      this.btnOutlab.Click += new System.EventHandler(this.btnOutlab_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(596, 24);
      this.menuStrip1.TabIndex = 3;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureFoldersToolStripMenuItem});
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
      this.settingsToolStripMenuItem.Text = "Settings";
      // 
      // configureFoldersToolStripMenuItem
      // 
      this.configureFoldersToolStripMenuItem.Name = "configureFoldersToolStripMenuItem";
      this.configureFoldersToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
      this.configureFoldersToolStripMenuItem.Text = "Configure Folders";
      this.configureFoldersToolStripMenuItem.Click += new System.EventHandler(this.configureFoldersToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // btnDetails
      // 
      this.btnDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDetails.Location = new System.Drawing.Point(418, 317);
      this.btnDetails.Name = "btnDetails";
      this.btnDetails.Size = new System.Drawing.Size(166, 34);
      this.btnDetails.TabIndex = 4;
      this.btnDetails.Text = "View Order Details";
      this.btnDetails.UseVisualStyleBackColor = true;
      this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
      // 
      // lblSettingsChanged
      // 
      this.lblSettingsChanged.AutoSize = true;
      this.lblSettingsChanged.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblSettingsChanged.Location = new System.Drawing.Point(13, 372);
      this.lblSettingsChanged.MaximumSize = new System.Drawing.Size(435, 0);
      this.lblSettingsChanged.Name = "lblSettingsChanged";
      this.lblSettingsChanged.Size = new System.Drawing.Size(0, 20);
      this.lblSettingsChanged.TabIndex = 5;
      // 
      // btnHistory
      // 
      this.btnHistory.Location = new System.Drawing.Point(418, 35);
      this.btnHistory.Name = "btnHistory";
      this.btnHistory.Size = new System.Drawing.Size(166, 27);
      this.btnHistory.TabIndex = 7;
      this.btnHistory.Text = "View History - Resend Order";
      this.btnHistory.UseVisualStyleBackColor = true;
      this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(596, 476);
      this.Controls.Add(this.btnHistory);
      this.Controls.Add(this.lblSettingsChanged);
      this.Controls.Add(this.btnDetails);
      this.Controls.Add(this.btnOutlab);
      this.Controls.Add(this.btnPrintHere);
      this.Controls.Add(this.btnRefresh);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.Text = "Order Manager";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.Button btnPrintHere;
    private System.Windows.Forms.Button btnOutlab;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem configureFoldersToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.Button btnDetails;
    public System.Windows.Forms.Label lblSettingsChanged;
    private System.Windows.Forms.Button btnHistory;

  }
}


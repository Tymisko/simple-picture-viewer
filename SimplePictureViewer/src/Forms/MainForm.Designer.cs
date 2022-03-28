namespace SimplePictureViewer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._pb = new System.Windows.Forms.PictureBox();
            this._btnClose = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this._btnNextImage = new System.Windows.Forms.Button();
            this._btnPreviousImage = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this._openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._folderTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this._helpTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SupFileFormatsTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this._projectTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this._lbEmptyPb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._pb)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pb
            // 
            resources.ApplyResources(this._pb, "_pb");
            this._pb.Name = "_pb";
            this._pb.TabStop = false;
            // 
            // _btnClose
            // 
            resources.ApplyResources(this._btnClose, "_btnClose");
            this._btnClose.Name = "_btnClose";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // _btnNextImage
            // 
            resources.ApplyResources(this._btnNextImage, "_btnNextImage");
            this._btnNextImage.Name = "_btnNextImage";
            this._btnNextImage.UseVisualStyleBackColor = true;
            this._btnNextImage.Click += new System.EventHandler(this.BtnNextImage_Click);
            // 
            // _btnPreviousImage
            // 
            resources.ApplyResources(this._btnPreviousImage, "_btnPreviousImage");
            this._btnPreviousImage.Name = "_btnPreviousImage";
            this._btnPreviousImage.UseVisualStyleBackColor = true;
            this._btnPreviousImage.Click += new System.EventHandler(this.BtnPreviousImage_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openToolStripMenuItem,
            this._helpTSMItem});
            resources.ApplyResources(this.MenuStrip, "MenuStrip");
            this.MenuStrip.Name = "MenuStrip";
            // 
            // _openToolStripMenuItem
            // 
            this._openToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this._openToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._folderTSMItem});
            this._openToolStripMenuItem.Name = "_openToolStripMenuItem";
            resources.ApplyResources(this._openToolStripMenuItem, "_openToolStripMenuItem");
            // 
            // _folderTSMItem
            // 
            this._folderTSMItem.Name = "_folderTSMItem";
            resources.ApplyResources(this._folderTSMItem, "_folderTSMItem");
            this._folderTSMItem.Click += new System.EventHandler(this.FolderTSMItem_Click);
            // 
            // _helpTSMItem
            // 
            this._helpTSMItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this._helpTSMItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._helpTSMItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SupFileFormatsTSMItem,
            this._projectTSMItem});
            this._helpTSMItem.Name = "_helpTSMItem";
            resources.ApplyResources(this._helpTSMItem, "_helpTSMItem");
            // 
            // SupFileFormatsTSMItem
            // 
            this.SupFileFormatsTSMItem.Name = "SupFileFormatsTSMItem";
            resources.ApplyResources(this.SupFileFormatsTSMItem, "SupFileFormatsTSMItem");
            this.SupFileFormatsTSMItem.Click += new System.EventHandler(this.SupportedFileFormatsTSMItem_Click);
            // 
            // _projectTSMItem
            // 
            this._projectTSMItem.Name = "_projectTSMItem";
            resources.ApplyResources(this._projectTSMItem, "_projectTSMItem");
            this._projectTSMItem.Click += new System.EventHandler(this.ProjectTSMItem_Click);
            // 
            // _lbEmptyPb
            // 
            resources.ApplyResources(this._lbEmptyPb, "_lbEmptyPb");
            this._lbEmptyPb.Name = "_lbEmptyPb";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this._lbEmptyPb);
            this.Controls.Add(this._btnPreviousImage);
            this.Controls.Add(this._btnNextImage);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this._pb);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._pb)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox _pb;
        private Button _btnClose;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button _btnNextImage;
        private Button _btnPreviousImage;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem _openToolStripMenuItem;
        private ToolStripMenuItem _folderTSMItem;
        private ToolStripMenuItem _helpTSMItem;
        private ToolStripMenuItem SupFileFormatsTSMItem;
        private ToolStripMenuItem _projectTSMItem;
        private Label _lbEmptyPb;
    }
}
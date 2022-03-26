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
            this.PbImage = new System.Windows.Forms.PictureBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnNextImage = new System.Windows.Forms.Button();
            this.btnPreviousImage = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImgTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderTsmItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SupFileFormatsTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectTSMItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbEmptyPb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbImage)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbImage
            // 
            resources.ApplyResources(this.PbImage, "PbImage");
            this.PbImage.Name = "PbImage";
            this.PbImage.TabStop = false;
            // 
            // BtnClose
            // 
            resources.ApplyResources(this.BtnClose, "BtnClose");
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnNextImage
            // 
            resources.ApplyResources(this.btnNextImage, "btnNextImage");
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.UseVisualStyleBackColor = true;
            this.btnNextImage.Click += new System.EventHandler(this.BtnNextImage_Click);
            // 
            // btnPreviousImage
            // 
            resources.ApplyResources(this.btnPreviousImage, "btnPreviousImage");
            this.btnPreviousImage.Name = "btnPreviousImage";
            this.btnPreviousImage.UseVisualStyleBackColor = true;
            this.btnPreviousImage.Click += new System.EventHandler(this.BtnPreviousImage_Click);
            // 
            // MenuStrip
            // 
            resources.ApplyResources(this.MenuStrip, "MenuStrip");
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Name = "MenuStrip";
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.openToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImgTSMItem,
            this.folderTsmItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            // 
            // ImgTSMItem
            // 
            resources.ApplyResources(this.ImgTSMItem, "ImgTSMItem");
            this.ImgTSMItem.Name = "ImgTSMItem";
            this.ImgTSMItem.Click += new System.EventHandler(this.ImgTSMItem_Click);
            // 
            // folderTsmItem
            // 
            resources.ApplyResources(this.folderTsmItem, "folderTsmItem");
            this.folderTsmItem.Name = "folderTsmItem";
            this.folderTsmItem.Click += new System.EventHandler(this.FolderTSMItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.helpToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SupFileFormatsTSMItem,
            this.projectTSMItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // SupFileFormatsTSMItem
            // 
            resources.ApplyResources(this.SupFileFormatsTSMItem, "SupFileFormatsTSMItem");
            this.SupFileFormatsTSMItem.Name = "SupFileFormatsTSMItem";
            this.SupFileFormatsTSMItem.Click += new System.EventHandler(this.SupportedFileFormatsTSMItem_Click);
            // 
            // projectTSMItem
            // 
            resources.ApplyResources(this.projectTSMItem, "projectTSMItem");
            this.projectTSMItem.Name = "projectTSMItem";
            this.projectTSMItem.Click += new System.EventHandler(this.ProjectTSMItem_Click);
            // 
            // lbEmptyPb
            // 
            resources.ApplyResources(this.lbEmptyPb, "lbEmptyPb");
            this.lbEmptyPb.Name = "lbEmptyPb";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lbEmptyPb);
            this.Controls.Add(this.btnPreviousImage);
            this.Controls.Add(this.btnNextImage);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.PbImage);
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbImage)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox PbImage;
        private Button BtnClose;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnNextImage;
        private Button btnPreviousImage;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem ImgTSMItem;
        private ToolStripMenuItem folderTsmItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem SupFileFormatsTSMItem;
        private ToolStripMenuItem projectTSMItem;
        private Label lbEmptyPb;
    }
}
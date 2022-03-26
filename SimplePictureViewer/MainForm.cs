using System.IO;

namespace SimplePictureViewer
{
    public partial class MainForm : Form
    {
        private OpenFileDialog _openFileDialog;
        private FolderBrowserDialog _folderBrowserDialog;

        public MainForm()
        {
            InitializeComponent();

            _openFileDialog = new OpenFileDialog();
            _folderBrowserDialog = new FolderBrowserDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnPreviousImage_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnNextImage_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void ImgTSMItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FolderTSMItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ProjectTSMItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SupportedFileFormatsTSMItem_Click(object sender, EventArgs e)
        {

        }
    }
}
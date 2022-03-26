using System.IO;

namespace SimplePictureViewer
{
    public partial class MainForm : Form
    {
        private OpenFileDialog _openFileDialog;
        private FolderBrowserDialog _folderBrowserDialog;

        private enum OpenType
        {
            File, 
            Folder
        }

        private event Action<OpenType> OnPictureContentSelected;

        public MainForm()
        {
            InitializeComponent();

            _openFileDialog = new OpenFileDialog();
            _folderBrowserDialog = new FolderBrowserDialog();

            BtnClose.Enabled = false;

            btnPreviousImage.Enabled = false;
            btnPreviousImage.Visible = false;

            btnNextImage.Enabled = false;
            btnNextImage.Visible = false;

            OnPictureContentSelected += EnableButtons;
        }

        private void EnableButtons(OpenType openType)
        {
            switch (openType)
            {
                case OpenType.File:
                    DisableNavigationButtons();
                    break;

                case OpenType.Folder:
                    EnableNavitagionButtons();
                    break;

                default:
                    DisableNavigationButtons();
                    BtnClose.Enabled = false;
                    throw new ArgumentException("Not supported OpenType");
            }

            lbEmptyPb.Visible = false;
            lbEmptyPb.Enabled = false;

            BtnClose.Enabled = true;
        }
        private void DisableNavigationButtons()
        {
            btnPreviousImage.Enabled = false;
            btnPreviousImage.Visible = false;

            btnNextImage.Enabled = false;
            btnNextImage.Visible = false;
        }
        private void EnableNavitagionButtons()
        {
            btnPreviousImage.Enabled = true;
            btnPreviousImage.Visible = true;

            btnNextImage.Enabled = true;
            btnNextImage.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            PbImage.Image = null;

            lbEmptyPb.Visible = true;
            lbEmptyPb.Enabled = true;

            BtnClose.Enabled = false;
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
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PbImage.Image = Image.FromFile(_openFileDialog.FileName);
                OnPictureContentSelected?.Invoke(OpenType.File);
            }
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
            throw new NotImplementedException();
        }
    }
}
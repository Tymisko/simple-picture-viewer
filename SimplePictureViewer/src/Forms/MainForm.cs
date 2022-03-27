using System.IO;
using System.Linq;

namespace SimplePictureViewer
{
    public partial class MainForm : Form
    {
        private OpenFileDialog _openFileDialog;

        private FolderBrowserDialog _folderBrowserDialog;
        private List<string> _imagesInSelectedPath;
        private int _displayedImgIndex;

        private readonly List<string> _supportedImageExtensions = new List<string>()
        {
            "BMP", "GIF", "JPEG", "JPG", "EXIF", "PNG", "TIFF", "SVG"
        };

        private enum OpenType
        {
            File,
            Folder
        }

        public MainForm()
        {
            InitializeComponent();
            KeyPreview = true;

            _openFileDialog = new OpenFileDialog();
            _folderBrowserDialog = new FolderBrowserDialog();
            _imagesInSelectedPath = new List<string>();
            _displayedImgIndex = -1;

            _btnClose.Enabled = false;
            RemoveNavitagionButtons();

            this.KeyDown += BtnNextImage_OnKeyDown;
            this.KeyDown += BtnPreviousImage_OnKeyDown;
        }

        private void SetPictureBoxContent(OpenType openType, string sourcePath)
        {
            _pb.Visible = true;
            switch (openType)
            {
                case OpenType.File:
                    _pb.Image = Image.FromFile(sourcePath);
                    break;

                case OpenType.Folder:
                    _imagesInSelectedPath = GetImagesPathsFrom(sourcePath);
                    if (_imagesInSelectedPath.Count > 0)
                    {
                        _pb.Image = Image.FromFile(_imagesInSelectedPath[++_displayedImgIndex]);
                    }
                    else
                    {
                        ResetForm();
                        return;
                    }

                    break;

                default:
                    throw new ArgumentException("Unsupported OpenType");
            }

            lbEmptyPb.Visible = false;
        }

        private List<string> GetImagesPathsFrom(string folderPath)
        {
            string[] filesPathInSelected = Directory.GetFiles(folderPath);

            List<string> imagesInSelectedPath = new List<string>();
            foreach (var filePath in filesPathInSelected)
            {
                if (_supportedImageExtensions.Contains(Path.GetExtension(filePath).ToUpperInvariant().Trim('.')))
                {
                    imagesInSelectedPath.Add(filePath);
                }
            }

            return imagesInSelectedPath;
        }

        private void EnableButtons(OpenType openType)
        {
            switch (openType)
            {
                case OpenType.File:
                    RemoveNavitagionButtons();
                    break;

                case OpenType.Folder:
                    _btnPreviousImage.Visible = true;
                    _btnPreviousImage.Enabled = false;
                    _btnNextImage.Visible = true;
                    break;

                default:
                    RemoveNavitagionButtons();
                    _btnClose.Enabled = false;
                    throw new ArgumentException("Not supported OpenType");
            }

            _btnClose.Enabled = true;
        }

        private void RemoveNavitagionButtons()
        {
            _btnPreviousImage.Visible = false;
            _btnNextImage.Visible = false;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            _pb.Image = null;
            _pb.Visible = false;

            _displayedImgIndex = -1;
            _imagesInSelectedPath = new List<string>();

            lbEmptyPb.Visible = true;

            RemoveNavitagionButtons();
            _btnClose.Enabled = false;
        }

        private void BtnPreviousImage_Click(object sender, EventArgs e)
        {
            _pb.Image = Image.FromFile(_imagesInSelectedPath[--_displayedImgIndex]);

            bool isBeforeLastImage = _displayedImgIndex == _imagesInSelectedPath.Count - 2;
            bool isFirstImage = _displayedImgIndex == 0;
            if (isFirstImage)
            {
                _btnPreviousImage.Enabled = false;
            }
            else if (isBeforeLastImage)
            {
                _btnNextImage.Enabled = true;
            }
        }

        private void BtnPreviousImage_OnKeyDown(object? sender, KeyEventArgs e)
        {
            bool isBtnPreviousImageDisabled = !_btnPreviousImage.Enabled;
            bool isBtnPreviousImageHidden = !_btnPreviousImage.Visible;
            bool isNotDKeyPressed = !(e.KeyCode == Keys.A);
            if (isBtnPreviousImageDisabled || isBtnPreviousImageHidden || isNotDKeyPressed)
            {
                return;
            }

            BtnPreviousImage_Click(sender, e);
        }

        private void BtnNextImage_Click(object sender, EventArgs e)
        {
            _pb.Image = Image.FromFile(_imagesInSelectedPath[++_displayedImgIndex]);

            bool isLastImage = _displayedImgIndex == _imagesInSelectedPath.Count - 1;
            bool isNotFirstImage = _displayedImgIndex > 0;
            if (isLastImage)
            {
                _btnNextImage.Enabled = false;
                return;
            }
            else if (isNotFirstImage)
            {
                _btnPreviousImage.Enabled = true;
            }
        }

        private void BtnNextImage_OnKeyDown(object sender, KeyEventArgs e)
        {
            bool isBtnNextImageDisabled = !_btnNextImage.Enabled;
            bool isBtnNextImageHidden = !_btnNextImage.Visible;
            bool isNotDKeyPressed = !(e.KeyCode == Keys.D);
            if (isBtnNextImageDisabled || isBtnNextImageHidden || isNotDKeyPressed)
            {
                return;
            }

            BtnNextImage_Click(sender, e);
        }

        private void ImgTSMItem_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetPictureBoxContent(OpenType.File, _openFileDialog.FileName);
                EnableButtons(OpenType.File);
            }
        }

        private void FolderTSMItem_Click(object sender, EventArgs e)
        {
            if (_folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFolderPath = _folderBrowserDialog.SelectedPath;
                SetPictureBoxContent(OpenType.Folder, selectedFolderPath);
                EnableButtons(OpenType.Folder);
            }
        }

        private void ProjectTSMItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", @"https://github.com/Tymisko/simple-picture-viewer");
        }

        private void SupportedFileFormatsTSMItem_Click(object sender, EventArgs e)
        {
            string message = "Supported image extensions: \n- " + String.Join("\n- ", _supportedImageExtensions);
            MessageBox.Show(message, "Supported Extensions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
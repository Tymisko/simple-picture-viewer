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

        private event Action<OpenType, string> OnPictureContentSelected;

        public MainForm()
        {
            InitializeComponent();
            KeyPreview = true;

            _openFileDialog = new OpenFileDialog();
            _folderBrowserDialog = new FolderBrowserDialog();
            _imagesInSelectedPath = new List<string>();

            BtnClose.Enabled = false;
            RemoveNavitagionButtons();

            OnPictureContentSelected += EnableButtons;
            OnPictureContentSelected += SetPictureBoxContent;

            this.KeyDown += BtnNextImage_OnKeyDown;
            this.KeyDown += BtnPreviousImage_OnKeyDown;
        }

        private void SetPictureBoxContent(OpenType openType, string sourcePath)
        {
            PbImage.Visible = true;
            switch (openType)
            {
                case OpenType.File:
                    PbImage.Image = Image.FromFile(sourcePath);
                    break;

                case OpenType.Folder:
                    _imagesInSelectedPath = GetImagesPathsFrom(sourcePath);
                    if (_imagesInSelectedPath.Count > 0)
                    {
                        PbImage.Image = Image.FromFile(_imagesInSelectedPath[_displayedImgIndex++]);
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

        private void EnableButtons(OpenType openType, string sourcePath)
        {
            switch (openType)
            {
                case OpenType.File:
                    RemoveNavitagionButtons();
                    break;

                case OpenType.Folder:
                    btnPreviousImage.Visible = true;
                    btnPreviousImage.Enabled = false;
                    btnNextImage.Visible = true;
                    break;

                default:
                    RemoveNavitagionButtons();
                    BtnClose.Enabled = false;
                    throw new ArgumentException("Not supported OpenType");
            }

            BtnClose.Enabled = true;
        }

        private void RemoveNavitagionButtons()
        {
            btnPreviousImage.Visible = false;
            btnNextImage.Visible = false;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            PbImage.Image = null;
            PbImage.Visible = false;

            _displayedImgIndex = 0;
            _imagesInSelectedPath = new List<string>();

            lbEmptyPb.Visible = true;

            RemoveNavitagionButtons();
            BtnClose.Enabled = false;
        }

        private void BtnPreviousImage_Click(object sender, EventArgs e)
        {

            bool isBeforeLastImage = _displayedImgIndex == _imagesInSelectedPath.Count - 2;
            bool isFirstImage = _displayedImgIndex == 0;            
            if(isFirstImage)
            {
                btnPreviousImage.Enabled = false;
                return;
            }
            else if (isBeforeLastImage)
            {
                btnNextImage.Enabled = true;
            }
            PbImage.Image = Image.FromFile(_imagesInSelectedPath[--_displayedImgIndex]);
        }

        private void BtnPreviousImage_OnKeyDown(object? sender, KeyEventArgs e)
        {
            bool isBtnPreviousImageDisabled = !btnPreviousImage.Enabled;
            bool isBtnPreviousImageHidden = !btnPreviousImage.Visible;
            bool isNotDKeyPressed = !(e.KeyCode == Keys.A);
            if (isBtnPreviousImageDisabled || isBtnPreviousImageHidden || isNotDKeyPressed)
            {
                return;
            }

            BtnPreviousImage_Click(sender, e);
        }

        private void BtnNextImage_Click(object sender, EventArgs e)
        {
            bool isLastImage = _displayedImgIndex == _imagesInSelectedPath.Count - 1;
            bool isNotFirstImage = _displayedImgIndex > 0;
            if (isLastImage)
            {
                btnNextImage.Enabled = false;
                return;
            }
            else if (isNotFirstImage)
            {
                btnPreviousImage.Enabled = true;
            }
            PbImage.Image = Image.FromFile(_imagesInSelectedPath[++_displayedImgIndex]);
        }

        private void BtnNextImage_OnKeyDown(object sender, KeyEventArgs e)
        {
            bool isBtnNextImageDisabled = !btnNextImage.Enabled;
            bool isBtnNextImageHidden = !btnNextImage.Visible;
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
                OnPictureContentSelected?.Invoke(OpenType.File, _openFileDialog.FileName);
            }
        }

        private void FolderTSMItem_Click(object sender, EventArgs e)
        {
            if (_folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFolderPath = _folderBrowserDialog.SelectedPath;
                OnPictureContentSelected?.Invoke(OpenType.Folder, selectedFolderPath);
            }
        }

        private void ProjectTSMItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe" ,@"https://github.com/Tymisko/simple-picture-viewer");
        }

        private void SupportedFileFormatsTSMItem_Click(object sender, EventArgs e)
        {
            string message = "Supported image extensions: \n- " + String.Join("\n- ", _supportedImageExtensions);
            MessageBox.Show(message, "Supported Extensions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
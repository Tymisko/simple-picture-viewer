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

            _openFileDialog = new OpenFileDialog();
            _folderBrowserDialog = new FolderBrowserDialog();

            BtnClose.Enabled = false;
            RemoveNavitagionButtons();

            OnPictureContentSelected += EnableButtons;
            OnPictureContentSelected += SetPictureBoxContent;
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

            lbEmptyPb.Visible = true;

            RemoveNavitagionButtons();
            BtnClose.Enabled = false;
        }

        private void BtnPreviousImage_Click(object sender, EventArgs e)
        {
            PbImage.Image = Image.FromFile(_imagesInSelectedPath[--_displayedImgIndex]);
            if(_displayedImgIndex == 0)
            {
                btnPreviousImage.Enabled = false;
            }
            else if (_displayedImgIndex == _imagesInSelectedPath.Count - 2)
            {
                btnNextImage.Enabled = true;
            }
        }

        private void BtnNextImage_Click(object sender, EventArgs e)
        {
            PbImage.Image = Image.FromFile(_imagesInSelectedPath[++_displayedImgIndex]);
            if (_displayedImgIndex == _imagesInSelectedPath.Count - 1)
            {
                btnNextImage.Enabled = false;
            }
            else if (_displayedImgIndex > 0)
            {
                btnPreviousImage.Enabled = true;
            }
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
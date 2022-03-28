using SimplePictureViewer.Helpers;

namespace SimplePictureViewer
{
    public partial class MainForm : Form
    {
        private readonly string[] _supportedImageExtensions = new[] { "BMP", "GIF", "JPEG", "JPG", "EXIF", "PNG", "TIFF", "SVG" };

        private string[] _imagesPathsInSelectedFolder;
        private int _currentImageIndex;

        private bool _folderHasSeveralImages;
        private bool _isLastImage;
        private bool _isFirstImage;
        private bool _isFolderLoaded;

        private FileHelper<OpenedFolderData> _openedFolderDataFileHelper;

        public MainForm()
        {
            InitializeComponent();

            _openedFolderDataFileHelper = new(Program.OpenedFolderDataPath);

            if (File.Exists(Program.OpenedFolderDataPath))
            {
                LoadPreviouslyOpenedFolderData();
                RefreshUI();
            }
            else
            {
                _currentImageIndex = -1;
                _imagesPathsInSelectedFolder = Array.Empty<string>();

                _btnPreviousImage.Enabled = false;
                _btnNextImage.Enabled = false;
                _btnClose.Enabled = false;
            }

            KeyPreview = true;
            PreviewKeyDown += PreviewKeyDownEventHandler;
            KeyDown += KeyDownEventHandler;
        }

        private void LoadPreviouslyOpenedFolderData()
        {
            var previouslyOpenedFolderData = _openedFolderDataFileHelper.DeserializeFromJson();

            _currentImageIndex = previouslyOpenedFolderData.CurrentImageIndex;
            _isFolderLoaded = previouslyOpenedFolderData.IsFolderLoaded;
            _isFirstImage = previouslyOpenedFolderData.IsFirstImage;
            _isLastImage = previouslyOpenedFolderData.IsLastImage;
            _imagesPathsInSelectedFolder = previouslyOpenedFolderData.ImagesPathsInSelectedFolder;
            _folderHasSeveralImages = previouslyOpenedFolderData.FolderHasSeveralImages;

            File.Delete(Program.OpenedFolderDataPath);
        }

        private void FolderTSMItem_Click(object sender, EventArgs e)
        {
            _imagesPathsInSelectedFolder = GetImagesFromSelectedFolder();
            if (_imagesPathsInSelectedFolder.Length > 0)
            {
                _folderHasSeveralImages = _imagesPathsInSelectedFolder.Length > 1;
                _currentImageIndex = 0;
                RefreshUI();
            }
        }

        private void RefreshUI()
        {
            _isFolderLoaded = _currentImageIndex != -1;

            _pb.Image = _isFolderLoaded ? Image.FromFile(_imagesPathsInSelectedFolder[_currentImageIndex]) : null;
            _pb.Visible = _isFolderLoaded;

            _lbEmptyPb.Visible = !_isFolderLoaded;

            _isFirstImage = _currentImageIndex == 0;
            _isLastImage = _currentImageIndex == _imagesPathsInSelectedFolder.Length - 1;

            _btnNextImage.Enabled = _folderHasSeveralImages && !_isLastImage;
            _btnPreviousImage.Enabled = _folderHasSeveralImages && !_isFirstImage;
            _btnClose.Enabled = _isFolderLoaded;
        }

        private string[] GetImagesFromSelectedFolder()
        {
            FolderBrowserDialog folderBrowserDialog = new();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                var selectedFolderPath = folderBrowserDialog.SelectedPath;
                string[] filesPathInSelected = Directory.GetFiles(selectedFolderPath);

                List<string> imagesInSelectedPath = new();
                foreach (var filePath in filesPathInSelected)
                {
                    if (_supportedImageExtensions.Contains(Path.GetExtension(filePath).ToUpperInvariant().Trim('.')))
                    {
                        imagesInSelectedPath.Add(filePath);
                    }
                }

                return imagesInSelectedPath.ToArray();
            }

            return Array.Empty<string>();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            _currentImageIndex = -1;
            _folderHasSeveralImages = false;
            RefreshUI();
        }

        private void BtnPreviousImage_Click(object sender, EventArgs e)
        {
            if (!_isFirstImage) _currentImageIndex--;
            RefreshUI();
        }

        private void BtnNextImage_Click(object sender, EventArgs e)
        {
            if (!_isLastImage) _currentImageIndex++;
            RefreshUI();
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

        internal void KeyDownEventHandler(object sender, KeyEventArgs eventArgs)
        {
            switch (eventArgs.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    BtnPreviousImage_Click(sender, eventArgs);
                    break;

                case Keys.Right:
                case Keys.D:
                    BtnNextImage_Click(sender, eventArgs);
                    break;
            }
        }

        internal void PreviewKeyDownEventHandler(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isFolderLoaded)
            {
                SaveCurrentlyOpenedFolderDataToFile();
            }
        }

        private void SaveCurrentlyOpenedFolderDataToFile()
        {
            OpenedFolderData openedFolderData = GetCurrentlyOpenFolderData();
            _openedFolderDataFileHelper.SerializeToJson(openedFolderData);
        }

        private OpenedFolderData GetCurrentlyOpenFolderData()
        {
            OpenedFolderData openedFolderData = new();

            openedFolderData.ImagesPathsInSelectedFolder = _imagesPathsInSelectedFolder;
            openedFolderData.CurrentImageIndex = _currentImageIndex;
            openedFolderData.FolderHasSeveralImages = _folderHasSeveralImages;
            openedFolderData.IsLastImage = _isLastImage;
            openedFolderData.IsFirstImage = _isFirstImage;
            openedFolderData.IsFolderLoaded = _isFolderLoaded;

            return openedFolderData;
        }
    }

    internal class OpenedFolderData
    {
        public string[] ImagesPathsInSelectedFolder;
        public int CurrentImageIndex;

        public bool FolderHasSeveralImages;
        public bool IsLastImage;
        public bool IsFirstImage;
        public bool IsFolderLoaded;
    }
}
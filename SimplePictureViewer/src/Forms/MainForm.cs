namespace SimplePictureViewer
{
    public partial class MainForm : Form
    {
        private string[] _supportedImageExtensions = new[] { "BMP", "GIF", "JPEG", "JPG", "EXIF", "PNG", "TIFF", "SVG" };

        private string[] _imagesPathsInSelectedFolder;
        private int _currentImageIndex;

        private bool _folderHasSeveralImages;
        private bool _isLastImage;
        private bool _isFirstImage;
        private bool _isFolderLoaded;

        public MainForm()
        {
            InitializeComponent();

            _currentImageIndex = -1;
            _isFolderLoaded = false;

            _btnPreviousImage.Enabled = false;
            _btnNextImage.Enabled = false;
            _btnClose.Enabled = false;

            KeyPreview = true;
            PreviewKeyDown += PreviewKeyDownEventHandler;
            KeyDown += KeyDownEventHandler;
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
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                var selectedFolderPath = folderBrowserDialog.SelectedPath;
                string[] filesPathInSelected = Directory.GetFiles(selectedFolderPath);

                List<string> imagesInSelectedPath = new List<string>();
                foreach (var filePath in filesPathInSelected)
                {
                    if (_supportedImageExtensions.Contains(Path.GetExtension(filePath).ToUpperInvariant().Trim('.')))
                    {
                        imagesInSelectedPath.Add(filePath);
                    }
                }

                return imagesInSelectedPath.ToArray();
            }

            return new string[0];
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

        internal void PreviewKeyDownEventHandler(object secnder, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }
    }
}
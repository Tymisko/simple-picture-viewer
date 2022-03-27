namespace SimplePictureViewer
{
    internal enum OpenType
    {
        None,
        File,
        Folder
    }

    internal class DisplayManager
    {
        private OpenType _currentOpenType;

        private List<string> _imagesPaths;

        private int _displayedImgIndex;

        private bool _isLastImageDisplayed;
        private bool _isFirstImageDisplayed;

        private PictureBox _pictureBox;

        private Button _previousImageBtn;
        private Button _nextImageBtn;
        private Button _closeImage;

        private Label _emptyPictureBoxLabel;

        internal DisplayManager(PictureBox pictureBox,
                                Label emptyPictureBoxLabel,
                                Button nextImage,
                                Button previousImage,
                                Button closeImage)
        {
            _pictureBox = pictureBox;
            _emptyPictureBoxLabel = emptyPictureBoxLabel;

            _previousImageBtn = previousImage;
            _nextImageBtn = nextImage;
            _closeImage = closeImage;

            _displayedImgIndex = -1;
            _imagesPaths = new List<string>();
        }

        internal void InitUISettings()
        {
            CloseDisplay();
        }

        internal void DisplaySupportedExtensions()
        {
            string message = "Supported image extensions: \n- " + String.Join("\n- ", ImagesManager.SupportedImageExtensions);
            MessageBox.Show(message, "Supported Extensions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal void DisplayImage(string imagePath)
        {
            InitUISettings();
            if (imagePath != string.Empty)
            {
                _currentOpenType = OpenType.File;
                _pictureBox.Image = Image.FromFile(imagePath);

                SetButtonsStatuses();
                _pictureBox.Visible = true;
                _emptyPictureBoxLabel.Visible = false;
            }
        }

        internal void DisplayFolderImages(List<string> imagesPaths)
        {
            InitUISettings();
            if (imagesPaths.Count > 0)
            {
                _currentOpenType = OpenType.Folder;
                InitFolderImagesDisplaying(imagesPaths);
                _pictureBox.Visible = true;
                _emptyPictureBoxLabel.Visible = false;
            }
        }

        internal void CloseDisplay()
        {
            _currentOpenType = OpenType.None;
            _emptyPictureBoxLabel.Visible = true;

            _displayedImgIndex = -1;
            _imagesPaths = new List<string>();

            _isFirstImageDisplayed = false;
            _isLastImageDisplayed = false;

            _pictureBox.Image = null;
            _pictureBox.Visible = false;

            SetButtonsStatuses();
        }

        private void InitFolderImagesDisplaying(List<string> imagesInSelectedFolder)
        {
            _imagesPaths = imagesInSelectedFolder;

            var firstImagePath = _imagesPaths[++_displayedImgIndex];
            _pictureBox.Image = Image.FromFile(firstImagePath);
            _isFirstImageDisplayed = true;

            SetButtonsStatuses();
        }

        private void SetButtonsStatuses()
        {
            switch (_currentOpenType)
            {
                case OpenType.File:
                    _previousImageBtn.Visible = false;
                    _nextImageBtn.Visible = false;
                    _closeImage.Enabled = true;
                    break;

                case OpenType.Folder:
                    _previousImageBtn.Visible = true;
                    _previousImageBtn.Enabled = !_isFirstImageDisplayed;
                    _nextImageBtn.Visible = true;
                    _closeImage.Enabled = true;
                    break;

                case OpenType.None:
                    _previousImageBtn.Visible = false;
                    _nextImageBtn.Visible = false;
                    _closeImage.Enabled = false;
                    break;

                default:
                    throw new InvalidOperationException("Unhandled open type.");
            }
        }

        internal void DisplayNextImage()
        {
            ChangeDisplayedImage(_changeDirection.Next);
        }

        internal void DisplayPreviousImage()
        {
            ChangeDisplayedImage(_changeDirection.Previous);
        }

        private enum _changeDirection
        {
            Next, Previous
        }

        private void ChangeDisplayedImage(_changeDirection buttonType)
        {            
            bool isFolderOpenType = _currentOpenType == OpenType.Folder;
            if(!isFolderOpenType) return;

            bool isPreviousImageButtonEnabled = _previousImageBtn.Enabled;
            bool isNextImageButtonEnabled = _nextImageBtn.Enabled;

            string imageToDisplayPath;
            switch (buttonType)
            {
                case _changeDirection.Previous:
                    if (!isPreviousImageButtonEnabled) return;

                    imageToDisplayPath = _imagesPaths[--_displayedImgIndex];
                    _isFirstImageDisplayed = _displayedImgIndex == 0;
                    if (_isFirstImageDisplayed)
                    {
                        _previousImageBtn.Enabled = false;
                    }
                    else if (!isNextImageButtonEnabled && _isLastImageDisplayed)
                    {
                        _nextImageBtn.Enabled = true;
                    }

                    break;

                case _changeDirection.Next:
                    if (!isNextImageButtonEnabled) return;

                    imageToDisplayPath = _imagesPaths[++_displayedImgIndex];
                    _isLastImageDisplayed = _displayedImgIndex == _imagesPaths.Count - 1;

                    if (_isLastImageDisplayed)
                    {
                        _nextImageBtn.Enabled = false;
                    }
                    else if (!isPreviousImageButtonEnabled && _isFirstImageDisplayed)
                    {
                        _previousImageBtn.Enabled = true;
                    }

                    break;
                default:
                    throw new ArgumentException("Wrong image change direction.");
            }
            _pictureBox.Image = Image.FromFile(imageToDisplayPath);
        }
    }
}

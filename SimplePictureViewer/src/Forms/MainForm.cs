using System.IO;
using System.Linq;

namespace SimplePictureViewer
{
    public partial class MainForm : Form
    {
        private DisplayManager _displayManager;

        public MainForm()
        {
            InitializeComponent();

            _displayManager = new DisplayManager(_pb, _lbEmptyPb,_btnNextImage, _btnPreviousImage, _btnClose);

            _displayManager.InitUISettings();

            KeyPreview = true;
            PreviewKeyDown += PreviewKeyDownEventHandler;
            KeyDown += KeyDownEventHandler;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            _displayManager.CloseDisplay();
        }

        private void BtnPreviousImage_Click(object sender, EventArgs e)
        {
            _displayManager.DisplayPreviousImage();
        }
        private void BtnNextImage_Click(object sender, EventArgs e)
        {
            _displayManager.DisplayNextImage();
        }

        private void ImgTSMItem_Click(object sender, EventArgs e)
        {
            string imagePath = ImagesManager.GetSelectedImagePath();
            _displayManager.DisplayImage(imagePath);
        }

        private void FolderTSMItem_Click(object sender, EventArgs e)
        {
            var imagesPaths = ImagesManager.GetImagesPathsFromSelectedFolder();
            _displayManager.DisplayFolderImages(imagesPaths);
        }

        private void ProjectTSMItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", @"https://github.com/Tymisko/simple-picture-viewer");
        }

        private void SupportedFileFormatsTSMItem_Click(object sender, EventArgs e)
        {
            _displayManager.DisplaySupportedExtensions();
        }
        internal void KeyDownEventHandler(object sender, KeyEventArgs eventArgs)
        {
            switch (eventArgs.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    _displayManager.DisplayPreviousImage();
                    break;

                case Keys.Right:
                case Keys.D:
                    _displayManager.DisplayNextImage();
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
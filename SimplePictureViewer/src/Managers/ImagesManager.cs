namespace SimplePictureViewer
{
    internal static class ImagesManager
    {
        private static FolderBrowserDialog _folderBrowserDialog;
        private static OpenFileDialog _openFileDialog;

        static ImagesManager()
        {
            _folderBrowserDialog = new FolderBrowserDialog();
            _openFileDialog = new OpenFileDialog();
        }

        internal static List<string> SupportedImageExtensions { get; } = new List<string>
        {
            "BMP", "GIF", "JPEG", "JPG", "EXIF", "PNG", "TIFF", "SVG"
        };

        internal static List<string> GetImagesPathsFromSelectedFolder()
        {
            var selectedFolderPath = GetSelectedFolderPath();
            if (selectedFolderPath == string.Empty)
            {
                return new List<string>();
            }

            string[] filesPathInSelected = Directory.GetFiles(selectedFolderPath);

            List<string> imagesInSelectedPath = new List<string>();
            foreach (var filePath in filesPathInSelected)
            {
                if (SupportedImageExtensions.Contains(Path.GetExtension(filePath).ToUpperInvariant().Trim('.')))
                {
                    imagesInSelectedPath.Add(filePath);
                }
            }

            return imagesInSelectedPath;
        }

        private static string GetSelectedFolderPath()
        {
            if (_folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                return _folderBrowserDialog.SelectedPath;
            }

            return string.Empty;
        }

        internal static string GetSelectedImagePath()
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return _openFileDialog.FileName;
            }

            return string.Empty;
        }
    }
}

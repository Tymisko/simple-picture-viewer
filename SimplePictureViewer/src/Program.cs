namespace SimplePictureViewer
{
    internal static class Program
    {
        public static readonly string OpenedFolderDataPath = Path.Combine(
            Path.GetDirectoryName(Application.ExecutablePath), "openedFolderData.json");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
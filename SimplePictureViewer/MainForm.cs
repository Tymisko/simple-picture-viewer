namespace SimplePictureViewer
{
    public partial class MainForm : Form
    {
        OpenFileDialog ofd;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            BtnClose.Enabled = false;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                PbImage.Image = Image.FromFile(ofd.FileName);
                BtnClose.Enabled = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            PbImage.Image = null;
            BtnClose.Enabled = false;
        }
    }
}
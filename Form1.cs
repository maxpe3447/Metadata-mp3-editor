using System;
using System.Windows.Forms;
using TagLib;

namespace Visual_Mp3
{
    public partial class Form1 : Form
    {
        private string ErrorSearchFile = "The specified path is not correct or the file extension is invalid";
        private string FileWay;
        private File tfile;
        public Form1()
        {
            InitializeComponent();
        }
        private string OpenDialog()
        {
            var opd = new OpenFileDialog();
            opd.Filter = "*.mp3 | *.mp3";
            if (opd.ShowDialog() == DialogResult.OK){
                return opd.FileName;
            }
            return ErrorSearchFile;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FileWay = OpenDialog();
            if (FileWay == ErrorSearchFile)
                MessageBox.Show(ErrorSearchFile, "Fatal Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else 
            {
                tfile = File.Create(FileWay);
                string title        = tfile.Tag.Title;
                string[] artist     = tfile.Tag.Artists;
                string album        = tfile.Tag.Album;
                TimeSpan duration   = tfile.Properties.Duration;
                string comment      = tfile.Tag.Comment;

                richTextBoxArtist.Text      = string.Join(" ", artist);
                richTextBoxTittle.Text      = title;
                richTextBoxAlbum.Text       = album;
                richTextBoxDuration.Text    = duration.ToString();
                richTextBoxName.Text        = comment;
            }
        }

        private void richTextBoxTittle_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tfile.Tag.Title     = richTextBoxTittle.Text;
            tfile.Tag.Artists   = richTextBoxArtist.Text.Split(' ');
            tfile.Tag.Album     = richTextBoxAlbum.Text;
            tfile.Tag.Comment   = richTextBoxName.Text;

            tfile.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBoxArtist.Clear();
            richTextBoxTittle.Clear();
            richTextBoxAlbum.Clear();
            richTextBoxDuration.Clear();
            richTextBoxName.Clear();

            FileWay = "";
        }
    }
}

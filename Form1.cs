using System;
using System.Windows.Forms;
using TagLib;                       // Стороняя библиотека с открытым исходным кодом

namespace Visual_Mp3
{
    public partial class Form1 : Form
    {
        private string ErrorSearchFile = "The specified path is not correct or the file extension is invalid";
        private string FileWay;
        private File tfile;                 // Переменная для хранения информации про файл
        public Form1()
        {
            InitializeComponent();
        }
        private string OpenDialog()         // Ф-ция для открытия проводника
        {
            var opd = new OpenFileDialog();
            opd.Filter = "*.mp3 | *.mp3";   // Поиск именно mp3-файлов
            if (opd.ShowDialog() == DialogResult.OK)
            {
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
                string title = tfile.Tag.Title;              // Название
                string[] artist = tfile.Tag.Artists;            // Артист/артисты
                string album = tfile.Tag.Album;              // Альбом
                TimeSpan duration = tfile.Properties.Duration;    // Длина песни
                string comment = tfile.Tag.Comment;            // Коментарии к песне

                // Вывод даных
                richTextBoxArtist.Text = string.Join(" ", artist);
                richTextBoxTittle.Text = title;
                richTextBoxAlbum.Text = album;
                richTextBoxDuration.Text = duration.ToString();
                richTextBoxName.Text = comment;
            }
        }

        private void richTextBoxTittle_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Сохранение изменений в тегах
            tfile.Tag.Title = richTextBoxTittle.Text;
            tfile.Tag.Artists = richTextBoxArtist.Text.Split(' ');
            tfile.Tag.Album = richTextBoxAlbum.Text;
            tfile.Tag.Comment = richTextBoxName.Text;

            tfile.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Очистка полей с тегами
            richTextBoxArtist.Clear();
            richTextBoxTittle.Clear();
            richTextBoxAlbum.Clear();
            richTextBoxDuration.Clear();
            richTextBoxName.Clear();

            FileWay = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

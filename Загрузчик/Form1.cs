using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Загрузчик
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        async void Form1_Load(object sender, EventArgs e)
        {
            Opacity = 1;
            KeyDown += (s, a) => { if (a.KeyValue == (char)Keys.Escape) Close(); };
            KeyDown += (s, a) => { if (a.KeyValue == (char)Keys.Enter) add_pic_Click(add_pic, null); };
        }
            
        public void add_pic_Click(object sender, EventArgs e)
        {
            try
            {
                string url = textBox1.Text;//присваивание переменной ссылку
                string file_download = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/{Path.GetFileName(new Uri(url).LocalPath)}";
                ListViewItem item = new ListViewItem(Path.GetFileName(new Uri(url).LocalPath));

                listView1.Items.Add(item);

                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += (s, a) =>
                    {
                        progressBar1.Value = a.ProgressPercentage;
                        label_speed.Text = $"Скачивание {a.ProgressPercentage.ToString()}%   {(a.BytesReceived / 1048576.0).ToString("#.## МБ")}";
                    };
                    wc.OpenRead(url);
                    string size = (Convert.ToDouble(wc.ResponseHeaders["Content-Length"]) / 1048576).ToString("#.##");
                    item.SubItems.Add(size);
                    wc.DownloadFileAsync(new Uri(url), file_download);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace AMCap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //声明视频类
        AMCap.baseClass.cVideo video;
        private void Form1_Load(object sender, EventArgs e)
        {
            video = new baseClass.cVideo(pictureBox1.Handle, pictureBox1.Width, pictureBox1.Height);
            video.StartWebCam();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("c:\\AMCap");
            if (!di.Exists)
            {
                Directory.CreateDirectory("c:\\AMCap");
            }
            string path = "C:\\AMCap\\" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".jpeg";
            if (pictureBox2.Image != null)
            {
                Bitmap bt = new Bitmap(pictureBox2.Image);
                bt.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                bt.Dispose();
            }
            else
            {
                video.GrabImage(pictureBox1.Handle, path);
            }
            tsslPath.Text = "已经保存至：" + path;
        }

        Bitmap bt = null;
        Image ig;
        Graphics g;
        Bitmap btt = null;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (bt != null)
                    bt.Dispose();
                if (btt != null)
                    btt.Dispose();
                pictureBox2.Image = null;
                int i = comboBox1.SelectedIndex;
                video.GrabImage(pictureBox1.Handle, "C:\\ls.bmp");
                switch (i)
                {
                    case 0:
                        bt = new Bitmap("C:\\ls.bmp");
                        btt = new Bitmap(bt, 320, 240);
                        pictureBox2.Image = (Image)btt;
                        break;
                    case 1:
                        bt = new Bitmap("C:\\ls.bmp");
                        btt = new Bitmap(bt, 320, 240);
                        ig = (Image)Properties.Resources._01;
                        g = Graphics.FromImage(btt);
                        g.DrawImage(ig, 0, 0, 320, 240);
                        pictureBox2.Image = null;
                        pictureBox2.Image = (Image)btt;
                        break;
                    case 2:
                        bt = new Bitmap("C:\\ls.bmp");
                        btt = new Bitmap(bt, 320, 240);
                        ig = (Image)Properties.Resources._02;
                        g = Graphics.FromImage(btt);
                        g.DrawImage(ig, 0, 0, 320, 240);
                        pictureBox2.Image = (Image)btt;
                        break;
                    case 3:
                        bt = new Bitmap("C:\\ls.bmp");
                        btt = new Bitmap(bt, 320, 240);
                        ig = (Image)Properties.Resources._03;
                        g = Graphics.FromImage(btt);
                        g.DrawImage(ig, 0, 0, 320, 240);
                        pictureBox2.Image = (Image)btt;
                        break;
                    case 4:
                        bt = new Bitmap("C:\\ls.bmp");
                        btt = new Bitmap(bt, 320, 240);
                        ig = (Image)Properties.Resources._04;
                        g = Graphics.FromImage(btt);
                        g.DrawImage(ig, 0, 0, 320, 240);
                        pictureBox2.Image = (Image)btt;
                        break;
                    case 5:
                        bt = new Bitmap("C:\\ls.bmp");
                        btt = new Bitmap(bt, 320, 240);
                        ig = (Image)Properties.Resources._05;
                        g = Graphics.FromImage(btt);
                        g.DrawImage(ig, 0, 0, 320, 240);
                        pictureBox2.Image = (Image)btt;
                        break;
                }
            }
            catch
            {
                MessageBox.Show("警告：无法找到摄像头！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            video.GrabImage(pictureBox1.Handle, "C:\\ls.bmp");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (bt != null)
                {
                    bt.Dispose();
                }
                if (btt != null)
                {
                    btt.Dispose();
                }
                FileInfo fi = new FileInfo("C:\\ls.bmp");
                if (fi.Exists)
                {
                    File.Delete("C:\\ls.bmp");
                }
                DirectoryInfo di = new DirectoryInfo("c:\\AMCap");
                if (di.Exists)
                {
                    di.Delete(true);
                }
            }
            catch
            {
                MessageBox.Show("警告：大头贴正在被占用！","警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

    }
}

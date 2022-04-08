using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE363_6202414.Forms
{
    public partial class Gallery : Form
    {
        private int imageNumber = 1;

        private void LoadNextImage()
        {
            if (imageNumber == 14)
            {
                imageNumber = 1;
            }
            picSilder.ImageLocation = String.Format(@"images\{0}.png", imageNumber);
            imageNumber++;
        }

        public Gallery()
        {
            InitializeComponent();
        }


        private void Search_Load(object sender, EventArgs e)
        {
            timeCout.Start();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        private void timeCout_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timeCout.Start();
        }
    }
}

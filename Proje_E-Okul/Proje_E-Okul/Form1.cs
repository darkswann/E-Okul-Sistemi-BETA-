using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_E_Okul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frm_OgrenciNotlar frm = new Frm_OgrenciNotlar();
            frm.numara = textBox1.Text;
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmen frm5 = new FrmOgretmen();
            frm5.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

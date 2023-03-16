using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_E_Okul
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-38NPAJJ;Initial Catalog=BonusOkul;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersler frm02 = new FrmDersler();
            frm02.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup frm56 = new FrmKulup();
            frm56.Show();
        }

        private void FrmOgretmen_Load(object sender, EventArgs e)
        {

        }

        private void BtnOgrenci_Click(object sender, EventArgs e)
        {
            FrmOgrenci frm31 = new FrmOgrenci();
            frm31.Show();
        }

        private void BtnSinav_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar snv = new FrmSinavNotlar();
            snv.Show();
        }
    }
}

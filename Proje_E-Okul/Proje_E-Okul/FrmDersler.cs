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
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
 
        DataSet1TableAdapters.Tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();
        private void FrmDersler_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.LightYellow;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtKulupAd.Text);
            MessageBox.Show("Başarıyla Ders Eklenmiştir","Başarılı");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                ds.DersSil(byte.Parse(txtKulupID.Text));
                MessageBox.Show("Başarıyla Ders Silinmiştir","Başarılı");
            }

            catch(Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
        
        }

        private void btnGuncel_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(txtKulupAd.Text,byte.Parse(txtKulupID.Text));
            MessageBox.Show("Ders Başarıyla Güncellenmiştir","Başarılı");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}

using Proje_E_Okul.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Proje_E_Okul
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds2 = new DataTable1TableAdapter();
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-38NPAJJ;Initial Catalog=BonusOkul;Integrated Security=True");
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

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds2.OgrenciListesi();
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Kulupler",bgl);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbKulup.DisplayMember = "KulupAd"; // Ekranda Gözükecek Kısım
            cmbKulup.ValueMember = "KulupID"; // Ekranın Altında Gözükecek Yazının ID'si
            cmbKulup.DataSource = dt;
            bgl.Close();
        }
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            if(rdErkek.Checked == true)
            {
                c = "Erkek";
            }

            if(rdKız.Checked == true)
            {
                c = "Kız";
            }
            ds2.OgrenciEkle(txtOgrAd.Text,txtSoyad.Text,byte.Parse(cmbKulup.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci Başarıyla Eklenmiştir","Başarılı");
            dataGridView1.DataSource = ds2.OgrenciListesi();
            txtOgrAd.Text = "";
            txtSoyad.Text = "";
            rdErkek.Checked = false;
            rdKız.Checked = false;

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds2.OgrSil(txtOgrID.Text);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds2.OgrenciListesi();
        }

        private void cmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtOgrID.Text = cmbKulup.SelectedValue.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            txtOgrID.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtOgrAd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }

            catch(Exception hata)
            {
                DialogResult result1 = MessageBox.Show("Bir Hata Oluştu Hata Kodunu Görmek İçin Evet'e Tıklayabilirsiniz", "Hata", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(result1 == DialogResult.OK)
                {
                    MessageBox.Show(hata.ToString());
                }
            }
            
        }

        private void btnGuncel_Click(object sender, EventArgs e)
        {
            ds2.ogrGuncelle(txtOgrAd.Text,txtSoyad.Text,byte.Parse(cmbKulup.SelectedValue.ToString()),c,int.Parse(txtOgrID.Text));
            MessageBox.Show("Başarıyla Öğrenci Güncellendi","Başarılı");
            dataGridView1.DataSource = ds2.OgrenciListesi();
        }

        private void rdErkek_CheckedChanged(object sender, EventArgs e)
        {
            if(rdErkek.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void rdKız_CheckedChanged(object sender, EventArgs e)
        {
            if(rdKız.Checked == true)
            {
                c = "Kız";
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource =  ds2.OgrenciGetir(txtAra.Text);
        }
    }
}

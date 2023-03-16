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
using System.Security.Cryptography;
using Proje_E_Okul.DataSet1TableAdapters;

namespace Proje_E_Okul
{
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }
        int sinav1, sinav2, sinav3, proje;
        double ort;
        int notid;
        DataSet1TableAdapters.DataTable1TableAdapter ds2 = new DataTable1TableAdapter();
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-38NPAJJ;Initial Catalog=BonusOkul;Integrated Security=True");
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds31 = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds31.NotListesi(int.Parse(txtOgrID.Text));
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

        private void FrmSinavNotlar_Load(object sender, EventArgs e) // bu taraf buglıdır yakında düzenlenip tekrar güncellenecektir
        {
            dataGridView1.DataSource = ds2.OgrenciListesi();
            bgl.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Dersler", bgl);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbDers.DisplayMember = "dersAd"; // Ekranda Gözükecek Kısım
            cmbDers.ValueMember = "dersID"; // Ekranın Altında Gözükecek Yazının ID'si
            cmbDers.DataSource = dt;
            bgl.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse( dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtOgrID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            
            
            //string durum;
            sinav1 = int.Parse(txtSinav1.Text);
            sinav2 = int.Parse(txtSinav2.Text);
            sinav3 = int.Parse(txtSinav3.Text);
            proje = int.Parse(txtProje.Text);
            ort = (sinav1 + sinav2 + sinav3 + proje) / 4;
            txtOrt.Text = ort.ToString();

            if(ort >= 50)
            {
                txtDurum.Text = "True";
            }
            else
            {
                txtDurum.Text = "False";
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds31.NotGuncelle(byte.Parse(cmbDers.SelectedValue.ToString()), int.Parse(txtOgrID.Text),byte.Parse(txtSinav1.Text),byte.Parse(txtSinav2.Text), byte.Parse(txtSinav3.Text), byte.Parse(txtProje.Text), decimal.Parse(txtOrt.Text), bool.Parse(txtDurum.Text),notid);
            MessageBox.Show("Başarıyla Öğrenci Güncellendi", "Başarılı");
            dataGridView1.DataSource = ds2.OgrenciListesi();
        }
    }
}

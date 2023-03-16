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

namespace Proje_E_Okul
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-38NPAJJ;Initial Catalog=BonusOkul;Integrated Security=True");
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Kulupler", bgl);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Kulupler (kulupAd) values (@p1)",bgl);
            komut.Parameters.AddWithValue("@p1", txtKulupAd.Text);
            komut.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kulup Eklenmiştir","Başarılı");
            listele();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut2 = new SqlCommand("Delete From Tbl_Kulupler Where kulupID=@p1",bgl);
            komut2.Parameters.AddWithValue("@p1", txtKulupID.Text);
            komut2.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kulüp Silindi","Başarılı");
            listele();
        }

        private void btnGuncel_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand komut3 = new SqlCommand("Update Tbl_Kulupler Set kulupAd=@p1 Where kulupID=@p2",bgl);
            komut3.Parameters.AddWithValue("@p1",txtKulupAd.Text);
            komut3.Parameters.AddWithValue("@p2",txtKulupID.Text);
            komut3.ExecuteNonQuery();
            bgl.Close();
            MessageBox.Show("Kulüp Güncellendi", "Başarılı");
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

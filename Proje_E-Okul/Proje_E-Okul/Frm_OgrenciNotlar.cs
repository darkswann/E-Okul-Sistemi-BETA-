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
    public partial class Frm_OgrenciNotlar : Form
    {
        public Frm_OgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection(@"Data Source=DESKTOP-38NPAJJ;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Frm_OgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select dersAd,sınav1,sınav2,sınav3,proje,ortalama,durum From Tbl_Notlar\r\nINNER JOIN Tbl_Dersler ON Tbl_Notlar.dersID = Tbl_Dersler.dersID Where ogrenciID=@p1", bgl);
            komut.Parameters.AddWithValue("@p1",numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            bgl.Open();
            SqlCommand komut2 = new SqlCommand("Select ogrenciAd,ogrenciSoyad From Tbl_Ogrenciler Where ogrenciID=1", bgl);
            komut.Parameters.AddWithValue("@p2", numara);
            SqlDataReader dr1 = komut2.ExecuteReader();
            while (dr1.Read())
            {
                this.Text = dr1[0].ToString() + " " + dr1[1].ToString();
                
            }
            bgl.Close();
        }
    }
}

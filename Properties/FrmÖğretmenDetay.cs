using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NotKayitSistemi.Properties
{
    public partial class FrmÖğretmenDetay : Form
    {
        public FrmÖğretmenDetay()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-HLMQ9PKG;Initial Catalog=DbNotKayıt;Integrated Security=True");

        private void FrmÖğretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayıtDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", MskNumara.Text);
            komut.Parameters.AddWithValue("@P2", TxtAd.Text);
            komut.Parameters.AddWithValue("@P3", TxtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci sisteme eklendi.");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            MskNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(TxtSinav1.Text);
            s2 = Convert.ToDouble(TxtSinav2.Text);
            s3 = Convert.ToDouble(TxtSinav3.Text);
            ortalama = (s1 + s2 + s3) / 3;
            LblOrtalama.Text = Convert.ToString(ortalama);
            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }


            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set OGRS1 =@P1,OGRS2=@P2,OGRS3=@P3,ORTALAMA=@P4,DURUM=@P5 WHERE OGRNUMARA=@P6", baglanti);
            komut.Parameters.AddWithValue("@P1", TxtSinav1.Text);
            komut.Parameters.AddWithValue("@P2", TxtSinav2.Text);
            komut.Parameters.AddWithValue("@P3", TxtSinav3.Text);
            komut.Parameters.AddWithValue("@P4", decimal.Parse(LblOrtalama.Text));
            komut.Parameters.AddWithValue("@P5", durum);
            komut.Parameters.AddWithValue("@P6", MskNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci güncellendi.");
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(Durum) From TBLDERS where Durum='True' ", baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                LblGecenSayisi.Text = dr[0].ToString();
            }
            dr.Close();

            SqlCommand komut2 = new SqlCommand("Select Count(Durum) From TBLDERS where Durum='False' ", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblKalanSayisi.Text = dr2[0].ToString();
            }
            dr2.Close();
            baglanti.Close();

        }






    }
}

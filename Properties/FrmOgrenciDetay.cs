using System;
using System.Data.SqlClient;
using System.Windows.Forms;
// Data Source=LAPTOP-HLMQ9PKG;Initial Catalog=DbNotKayıt;Integrated Security=True
namespace NotKayitSistemi.Properties
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-HLMQ9PKG;Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            LblNumara.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLDERS where OGRNUMARA= @p1", baglanti); ;
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                LblSinav1.Text = dr[4].ToString();
                LblSinav2.Text = dr[5].ToString();
                LblSinav3.Text = dr[6].ToString();
                LblOrtalama.Text = dr[7].ToString();
                LblDurum.Text = dr[8].ToString();

            }
            if (LblDurum.Text == "True")
            {
                LblDurum.Text = "Geçti";

            }
            else
            {
                LblDurum.Text = "Kaldı";
            }
            baglanti.Close();
        }
    }
}

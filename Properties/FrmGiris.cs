using System;
using System.Windows.Forms;

namespace NotKayitSistemi.Properties
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOgrenciDetay frm = new FrmOgrenciDetay();
            frm.numara = maskedTextBox1.Text;
            frm.Show();

        }

        private void FrmGiriş_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "1111")
            {
                FrmÖğretmenDetay fr = new FrmÖğretmenDetay();
                fr.Show();
            }
        }
    }
}

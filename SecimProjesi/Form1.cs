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


namespace SecimProjesi
{
    public partial class SecimSistemi : Form
    {
        public SecimSistemi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=WIN-A1KQTFGPIJ3\SQLEXPRESS;Initial Catalog=dbSecimProjesi;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBL_SECİM (ILCEAD,APARTISI,BPARTISI,CPARTISI,DPARTISI,EPARTISI) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtilce.Text);
            komut.Parameters.AddWithValue("@p2", txtA.Text);
            komut.Parameters.AddWithValue("@p3", txtB.Text);
            komut.Parameters.AddWithValue("@p4", txtC.Text);
            komut.Parameters.AddWithValue("@p5", txtD.Text);
            komut.Parameters.AddWithValue("@p6", txtE.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Tesekkürler...");
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikle fr = new FrmGrafikle();
            fr.Show();

            this.Hide();
        }
    }
}

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
    public partial class FrmGrafikle : Form
    {
        public FrmGrafikle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=WIN-A1KQTFGPIJ3\SQLEXPRESS;Initial Catalog=dbSecimProjesi;Integrated Security=True");
        private void FrmGrafikle_Load(object sender, EventArgs e)
        {
            //ilce Adlarını Comboboxa cekme 
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select ILCEAD from TBL_SECİM ",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["ILCEAD"]);
            }
            baglanti.Close();

            //grafiğe toplam sonucları getirme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select SUM(APARTISI),SUM(BPARTISI),SUM(CPARTISI),SUM(DPARTISI),SUM(EPARTISI) from TBL_SECİM", baglanti);
            SqlDataReader DR2 = komut2.ExecuteReader();
            while (DR2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A PARTİSİ", DR2[0]);
                chart1.Series["Partiler"].Points.AddXY("B PARTİSİ", DR2[1]);
                chart1.Series["Partiler"].Points.AddXY("C PARTİSİ", DR2[2]);
                chart1.Series["Partiler"].Points.AddXY("D PARTİSİ", DR2[3]);
                chart1.Series["Partiler"].Points.AddXY("E PARTİSİ", DR2[4]);

            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBL_SECİM where ILCEAD=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value =int.Parse( dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());
                lbla.Text = dr[2].ToString();
                lblb.Text = dr[3].ToString();
                lblc.Text = dr[4].ToString();
                lbld.Text = dr[5].ToString();
                lble.Text = dr[6].ToString();

            }
            baglanti.Close();
        }
    }
}

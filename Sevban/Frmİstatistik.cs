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

namespace Sevban
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=Monster1771\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");




        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count (*) from Tbl_Personel", baglanti);
            SqlDataReader r1 = komut1.ExecuteReader();
            while (r1.Read()) 
            {
              LblToplamPersonel.Text = r1[0].ToString();
            }
            baglanti.Close();
            
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count (*) from Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader r2 = komut2.ExecuteReader();
            while (r2.Read())
            {
                LblEvliPersonel.Text = r2[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count (*) from Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader r3 = komut3.ExecuteReader();
            while (r3.Read())
            {
                LblBekarPersonel.Text = r3[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count (distinct(PerSEhir)) from Tbl_Personel ", baglanti);
            SqlDataReader r4 = komut4.ExecuteReader();
            while (r4.Read())
            {
                LblSehir.Text = r4[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum (PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader r5 = komut5.ExecuteReader();
            while (r5.Read())
            {
                LblToplamMaas.Text = r5[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg (PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader r6 = komut6.ExecuteReader();
            while (r6.Read())
            {
                LblOrtalamaMaas.Text = r6[0].ToString();
            }
            baglanti.Close();
        }
    }
}

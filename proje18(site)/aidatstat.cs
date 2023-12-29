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


namespace proje18_site_
{
    public partial class aidatstat : Form
    {
        public aidatstat()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=MMD\\SQLEXPRESS;Initial Catalog=site;Integrated Security=True");


        private void aidatstat_Load(object sender, EventArgs e)
        {
            //toplam daire sayısı
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("select count(*) from Tbl_Aidat",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while(dr1.Read()) 
            { 
                label3.Text = dr1[0].ToString();
            }

            baglanti.Close();

            //toplam toplanan aidat
            baglanti.Open();

            SqlCommand komut2 = new SqlCommand("select sum(aidat) from Tbl_Aidat", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                label4.Text = dr2[0].ToString();
            }

            baglanti.Close();
        }
    }
}

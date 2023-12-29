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
using System.Reflection.Emit;

namespace proje18_site_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=MMD\\SQLEXPRESS;Initial Catalog=site;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {// TODO: This line of code loads data into the 'siteDataSet1.Tbl_Aidat' table. You can move, or remove it, as needed.

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        void Temizle()
        {
            txtno.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtaidat.Text = "";
            msktarih.Text = "";
            txtno.Focus();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_AidatTableAdapter.Fill(this.siteDataSet1.Tbl_Aidat);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into Tbl_Aidat(daireNo,ad,soyad,aidat,tarih) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtno.Text);
            komut.Parameters.AddWithValue("@p2", txtad.Text);
            komut.Parameters.AddWithValue("@p3", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p4", txtaidat.Text);
            komut.Parameters.AddWithValue("@p5", msktarih.Text);
            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Kişi başarıyla eklendi.");
        }



        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtno.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtaidat.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msktarih.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("delete from Tbl_Aidat where daireno=@s1", baglanti);
            komutsil.Parameters.AddWithValue("@s1",txtno.Text);
            komutsil.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Daire silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutguncelle = new SqlCommand("update Tbl_Aidat set ad=@g2,soyad=@g3,aidat=@g4,tarih=@g5 where daireno=@g1", baglanti);
            komutguncelle.Parameters.AddWithValue("@g1", txtno.Text);
            komutguncelle.Parameters.AddWithValue("@g2", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@g3", txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@g4", txtaidat.Text);
            komutguncelle.Parameters.AddWithValue("@g5", msktarih.Text);
            komutguncelle.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Daire bilgileri güncellendi.");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            aidatstat a = new aidatstat();
            a.Show();
        }
    }
}

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

namespace HastaneOtomasyon
{
    public partial class DoktorKayit : Form
    {
        public DoktorKayit()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server=YourDataBase;Database=HastaneOtomasyonDB;Trusted_Connection=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO tbl_doktorlar(tc, adSoyad, Dtarih, dYeri, cinsiyet, Adres, telefon, bolum) " +
                    "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)", conn);

                cmd.Parameters.AddWithValue("@p1", txtTc.Text.Trim());
                cmd.Parameters.AddWithValue("@p2", txtAd.Text.Trim());
                cmd.Parameters.AddWithValue("@p3", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@p4", txtDtarih.Text.Trim());
                cmd.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
                cmd.Parameters.AddWithValue("@p6", txtAdres.Text.Trim());
                cmd.Parameters.AddWithValue("@p7", txtTelefon.Text.Trim());
                cmd.Parameters.AddWithValue("@p8", cmbBolum.SelectedValue);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Kayıt başarıyla eklendi.");

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                VeriGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void DoktorKayit_Load(object sender, EventArgs e)
        {
            try
            {
                DBconnection dbc = new DBconnection();
                DataTable dt = dbc.Baglanti("SELECT BolumID, BolumAdi FROM tbl_bolumler");
                cmbBolum.DataSource = dt;
                cmbBolum.DisplayMember = "BolumAdi";
                cmbBolum.ValueMember = "BolumID";

                cmbCinsiyet.Items.Add("Erkek");
                cmbCinsiyet.Items.Add("Kadın");

                VeriGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VeriGetir()
        {
            try
            {
                DBconnection dbc = new DBconnection();
                DataTable dt = dbc.Baglanti("SELECT d.tc, d.adSoyad, d.Dtarih, d.dYeri, d.cinsiyet, d.Adres, d.telefon, b.BolumAdi FROM tbl_doktorlar d INNER JOIN tbl_bolumler b ON d.bolum = b.BolumID");
                dataGridView1.DataSource = dt;

                dataGridView1.Columns["tc"].HeaderText = "TC Kimlik No";
                dataGridView1.Columns["adSoyad"].HeaderText = "Ad ve Soyad";
                dataGridView1.Columns["Dtarih"].HeaderText = "Doğum Tarihi";
                dataGridView1.Columns["dYeri"].HeaderText = "Doğum Yeri";
                dataGridView1.Columns["cinsiyet"].HeaderText = "Cinsiyet";
                dataGridView1.Columns["Adres"].HeaderText = "Adres";
                dataGridView1.Columns["telefon"].HeaderText = "Telefon";
                dataGridView1.Columns["BolumAdi"].HeaderText = "Bölüm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata: " + ex.Message);
            }
        }

    }
}

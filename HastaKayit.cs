using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastaneOtomasyon
{
    public partial class HastaKayit : Form
    {
        public HastaKayit()
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
                    "INSERT INTO tbl_hastalar(tc, adSoyad, Dtarih, dYeri, cinsiyet, Adres, telefon, guvence) " +
                    "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)", conn);


                cmd.Parameters.AddWithValue("@p1", txtTc.Text.Trim());
                cmd.Parameters.AddWithValue("@p2", txtAd.Text.Trim());
                cmd.Parameters.AddWithValue("@p3", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@p4", txtDtarih.Text.Trim());
                cmd.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
                cmd.Parameters.AddWithValue("@p6", txtAdres.Text.Trim());
                cmd.Parameters.AddWithValue("@p7", txtTelefon.Text.Trim());
                cmd.Parameters.AddWithValue("@p8", cmbSosyal.Text);

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

        private void HastaKayit_Load(object sender, EventArgs e)
        {
            VeriGetir();

            cmbCinsiyet.Items.Add("Kadın");
            cmbCinsiyet.Items.Add("Erkek");

            cmbSosyal.Items.Add("SSK");
            cmbSosyal.Items.Add("Bağkur");
            cmbSosyal.Items.Add("Yeşil Kart");
        }

        private void VeriGetir()
        {
            try
            {
                DBconnection dbc = new DBconnection();
                DataTable dt = dbc.Baglanti("SELECT * FROM tbl_hastalar");
                dataGridView1.DataSource = dt;

                dataGridView1.Columns["tc"].HeaderText = "TC Kimlik No";
                dataGridView1.Columns["adSoyad"].HeaderText = "Ad ve Soyad";
                dataGridView1.Columns["Dtarih"].HeaderText = "Doğum Tarihi";
                dataGridView1.Columns["dYeri"].HeaderText = "Doğum Yeri";
                dataGridView1.Columns["cinsiyet"].HeaderText = "Cinsiyet";
                dataGridView1.Columns["Adres"].HeaderText = "Adres";
                dataGridView1.Columns["telefon"].HeaderText = "Telefon";
                dataGridView1.Columns["guvence"].HeaderText = "Sosyal Güvence";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata: " + ex.Message);
            }
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneOtomasyon
{
    public partial class Randevu : Form
    {
        public Randevu()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server=YourDataBase;Database=HastaneOtomasyonDB;Trusted_Connection=True;");

        private void Randevu_Load(object sender, EventArgs e)
        {
            VeriGetir();
            DBconnection dbc = new DBconnection();
            DataTable dtDoktor = dbc.Baglanti("SELECT adSoyad, tc FROM tbl_doktorlar");
            comboBox1.DataSource = dtDoktor;
            comboBox1.DisplayMember = "adSoyad";
            comboBox1.ValueMember = "tc";

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_randevu(HastaTc, HastaAdi, DoktorTc, Bolum, Tarih) VALUES " +
                    "(@p1, " +
                    "(SELECT adSoyad FROM tbl_hastalar WHERE tc = @p1), " +   // Hasta adını çekiyoruz
                    "@p2, " +
                    "(SELECT bolum FROM tbl_doktorlar WHERE tc = @p2), " +
                    "@p3)", conn);

                cmd.Parameters.AddWithValue("@p1", textBox1.Text);         // Hasta TC
                cmd.Parameters.AddWithValue("@p2", comboBox1.SelectedValue); // Doktor TC
                cmd.Parameters.AddWithValue("@p3", dateTimePicker1.Value);   // Tarih

                cmd.ExecuteNonQuery();

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                MessageBox.Show("Randevu başarıyla oluşturuldu.");
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
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT r.IslemNo, r.HastaTc, h.adSoyad AS HastaAdi, d.adSoyad AS DoktorAdi, b.BolumAdi, r.Tarih FROM tbl_randevu r INNER JOIN tbl_hastalar h ON r.HastaTc = h.tc INNER JOIN tbl_doktorlar d ON r.DoktorTc = d.tc INNER JOIN tbl_bolumler b ON d.bolum = b.BolumID", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                // Kolon başlıklarını düzenleme
                dataGridView1.Columns["IslemNo"].HeaderText = "İşlem No";
                dataGridView1.Columns["HastaTc"].HeaderText = "Hasta TC";
                dataGridView1.Columns["HastaAdi"].HeaderText = "Hasta Adı";
                dataGridView1.Columns["DoktorAdi"].HeaderText = "Doktor Adı";
                dataGridView1.Columns["BolumAdi"].HeaderText = "Bölüm";
                dataGridView1.Columns["Tarih"].HeaderText = "Randevu Tarihi";

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata: " + ex.Message);
            }
        }




    }
}


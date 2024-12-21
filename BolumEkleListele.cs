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
    public partial class BolumEkleListele : Form
    {
        public BolumEkleListele()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=YourDataBase;Database=HastaneOtomasyonDB;Trusted_Connection=True;");
        void VeriGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_bolumler", conn);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE tbl_bolumler SET BolumAdi = @p1 WHERE BolumId=@p2", conn);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                cmd.Parameters.AddWithValue("@p2", ıd);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Bölüm başarıyla Güncellendi!");
                VeriGetir(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM tbl_bolumler WHERE BolumID = @p2", conn);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                cmd.Parameters.AddWithValue("@p2", ıd);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Bölüm başarıyla Silindi!");
                VeriGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_bolumler (BolumAdi) VALUES (@P1)", conn);
                cmd.Parameters.AddWithValue("@P1", textBox1.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Bölüm başarıyla eklendi!");
                conn.Close();
                VeriGetir();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void BolumEkleListele_Load(object sender, EventArgs e)
        {
            VeriGetir();
        }
        int ıd;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            ıd = (int)dataGridView1.CurrentRow.Cells[0].Value;
        }
    }
}

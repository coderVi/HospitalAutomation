using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon
{
    public partial class GirisSayfası : Form
    {
        DBconnection dbconn = new DBconnection();
        public GirisSayfası()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici = textBox1.Text;
            string ksifre = textBox2.Text;
            DataTable result = dbconn.Baglanti("Select kAdi,sifre from tbl_user");
            foreach (DataRow row in result.Rows)
            {
                if (row["kAdi"].ToString() == kullanici && row["sifre"].ToString() == ksifre)
                {
                    MessageBox.Show("Giriş Başarılı");
                    Anasayfa anasayfa = new Anasayfa();
                    anasayfa.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Giriş");
                }
            }
        }

        private void GirisSayfası_Load(object sender, EventArgs e)
        {

        }
    }
}

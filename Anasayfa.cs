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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            BolumEkleListele bolumEkleListele = new BolumEkleListele();
            bolumEkleListele.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            HastaKayit hastaKayit = new HastaKayit();
            hastaKayit.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DoktorKayit d = new DoktorKayit();
            d.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Randevu randevu = new Randevu();
            randevu.Show();
        }
    }
}

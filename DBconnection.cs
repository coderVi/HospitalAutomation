using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneOtomasyon
{
    public class DBconnection
    {
        SqlConnection conn = new SqlConnection("Server=YourDatabase;Database=HastaneOtomasyonDB;Trusted_Connection=True;");

         public DataTable Baglanti(string sorgu)
        {
            SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}

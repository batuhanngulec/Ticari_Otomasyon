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

namespace Ticari_Otomasyon
{
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void giderListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_GIDERLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        void temizle()
        {
            TxtDogalgaz.Text = "";
            TxtEkstra.Text = "";
            TxtElektrik.Text = "";
            TxtId.Text = "";
            TxtInternet.Text = "";
            TxtMaaslar.Text = "";
            TxtSu.Text = "";
            CmbAy.Text = "";
            CmbYil.Text = "";
            RchNotlar.Text = "";

        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            giderListesi();
            temizle();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER " +
                "(AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbAy.Text);
            komut.Parameters.AddWithValue("@p2", CmbYil.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(TxtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(TxtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtMaaslar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(TxtEkstra.Text));
            komut.Parameters.AddWithValue("@p9", RchNotlar.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider tabloya eklendi", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            giderListesi();
            //temizle();






        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                TxtId.Text = dr["ID"].ToString();
                CmbAy.Text = dr["AY"].ToString();
                CmbYil.Text = dr["YIL"].ToString();
                TxtElektrik.Text = dr["ELEKTRIK"].ToString();
                TxtSu.Text = dr["SU"].ToString();
                TxtDogalgaz.Text = dr["DOGALGAZ"].ToString();
                TxtInternet.Text = dr["INTERNET"].ToString();
                TxtMaaslar.Text = dr["MAASLAR"].ToString();
                TxtEkstra.Text = dr["EKSTRA"].ToString();
                RchNotlar.Text = dr["NOTLAR"].ToString();

            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_GIDERLER where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", TxtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            giderListesi();
            MessageBox.Show("Giderler listeden Silindi","Uyari",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            temizle();




        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_GIDERLER set " +
                "AY=@P1,YIL=@P2,ELEKTRIK=@P3,SU=@P4,DOGALGAZ=@P5,INTERNET=@P6,MAASLAR=@P7,EKSTRA=@P8,NOTLAR=@P9 where ID=@P10",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", CmbAy.Text);
            komut.Parameters.AddWithValue("@P2", CmbYil.Text);
            komut.Parameters.AddWithValue("@P3", decimal.Parse(TxtElektrik.Text));
            komut.Parameters.AddWithValue("@P4", decimal.Parse(TxtSu.Text));
            komut.Parameters.AddWithValue("@P5", decimal.Parse(TxtDogalgaz.Text));
            komut.Parameters.AddWithValue("@P6", decimal.Parse(TxtInternet.Text));
            komut.Parameters.AddWithValue("@P7", decimal.Parse(TxtMaaslar.Text));
            komut.Parameters.AddWithValue("@P8", decimal.Parse(TxtEkstra.Text));
            komut.Parameters.AddWithValue("@P9", RchNotlar.Text);
            komut.Parameters.AddWithValue("@P10", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            giderListesi();
            temizle();

        }
    }
}

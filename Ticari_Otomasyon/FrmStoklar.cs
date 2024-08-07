﻿using System;
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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
                                // ornek denemeler // 
            //chartControl1.Series["Series 1"].Points.AddPoint("Istanbul",4);
            //chartControl1.Series["Series 1"].Points.AddPoint("Izmir", 5);
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 6);
            //chartControl1.Series["Series 1"].Points.AddPoint("Adana", 6);


            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,SUM(ADET) AS 'Miktar' FROM TBL_URUNLER GROUP BY" +
                " URUNAD",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            // char için stok miktarı listeleme
            SqlCommand komut = new SqlCommand("Select URUNAD,SUM(ADET) AS 'Miktar' FROM TBL_URUNLER GROUP BY " +
                "URUNAD", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse(dr[1].ToString()));
            }
            bgl.baglanti().Close();

            // charta firma sehır sayısı çekme
            SqlCommand komut2 = new SqlCommand("Select IL,Count(*) From TBL_FIRMALAR Group By IL",bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr2[0]),int.Parse(dr2[1].ToString()));

            }
            bgl.baglanti().Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmStokDetay fr = new FrmStokDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if(dr != null)
            {
                fr.ad = dr["URUNAD"].ToString();
            }
            fr.Show();
        }
    }
}

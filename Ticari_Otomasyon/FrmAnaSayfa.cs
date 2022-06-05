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
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,Sum(ADET) as 'Adet' From TBL_URUNLER " +
                "group by URUNAD having Sum(ADET)<=20 order by Sum(ADET)", bgl.baglanti());
            da.Fill(dt);
            GridControlStoklar.DataSource = dt;
              
        }

        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select top 10 TARIH,SAAT,BASLIK From TBL_NOTLAR order by ID desc", bgl.baglanti());
            da.Fill(dt);
            GridControlAjanda.DataSource = dt;

        }
        void firmaHareketler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec Firmahareket2", bgl.baglanti());
            da.Fill(dt);
            GridControlHareketler.DataSource = dt;
        }

        void fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,TELEFON1 From TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            GridControlFihrist.DataSource = dt;
        }
        void haberler()
        {
            XmlTextReader xmlOku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmlOku.Read())
            {
                if(xmlOku.Name == "title")
                {
                    listBox1.Items.Add(xmlOku.ReadString());
                }
            }
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            stoklar();
            ajanda();
            firmaHareketler();
            fihrist();
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
            haberler();


        }
    }
}

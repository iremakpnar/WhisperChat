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


namespace WhisperChat
{
    public partial class resimguncelle : Form
    {
        public String userId { get; set; }

        public resimguncelle()
        {
            InitializeComponent();
        }
                
        SqlConnection baglanti = new SqlConnection("Data Source=IREM\\SQLEXPRESS;Initial Catalog=whisperChat;Integrated Security=True");

        bool durum;

        public String numara;

        private void resimguncelle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            lblNumara.Text = userId ;
            SqlCommand komut = new SqlCommand("Select adsoyad From tblKisi Where numara=" + numara, baglanti);
            baglanti.Close();
        }


        private void btnGuncellenecekResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtResim.Text = openFileDialog1.FileName;
            pictureBox2.ImageLocation = txtResim.Text;
        }


        void tekrarkntrl()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From tblAyar Where numara=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1", lblNumara.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            baglanti.Close();

        }

        private void btnResiKydt_Click(object sender, EventArgs e)
        {
            tekrarkntrl();
            if (durum == true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Insert Into tblAyar (resimkayit, numara) Values (@P1, @P2)", baglanti);
                komut.Parameters.AddWithValue("@P1", txtResim.Text);
                komut.Parameters.AddWithValue("@P2", userId);

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Resim Başarıyla Kaydedildi.");
            }
            else
            {
                MessageBox.Show("Kayıtlı Resminiz Mevcut.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }     
        }
        

        private void resimguncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings ayarlaradon = new settings();
            ayarlaradon.Show();
        }

        private void btnResmiGuncelle_Click(object sender, EventArgs e)
        {
            //int numara= int.Parse()
        }
    }
}

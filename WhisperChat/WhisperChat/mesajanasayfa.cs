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
    public partial class mesajanasayfa : Form
    {
        public mesajanasayfa()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=IREM\\SQLEXPRESS;Initial Catalog=whisperChat;Integrated Security=True");
        //SqlCommand komut;

        public string numara;
        
        private void mesajanasayfa_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select adsoyad From tblKisi Where numara=" + numara, baglanti);

            SqlDataReader dr = komut.ExecuteReader();
           
            while (dr.Read())
            {
                lblAdSoyad.Text = dr["adsoyad"].ToString();
            }

            baglanti.Close();
            gelenkutusu();
            gidenkutusu();
        }

        void gelenkutusu()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From tblMesaj Where alici =" + numara, baglanti);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        void gidenkutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From tblMesaj Where gonderen =" + numara, baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView3.DataSource = dt2;
        }

        private void btnMsjGndr_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert Into tblMesaj(gonderen,alici,konu,mesaj) Values (@P1,@P2,@P3,@P4)", baglanti);
            komut.Parameters.AddWithValue("@P1", numara);
            komut.Parameters.AddWithValue("@P2", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@P3", textBox1.Text);
            komut.Parameters.AddWithValue("@P4", richTextBox1.Text);

            if(baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Mesaj Başarıyla Gönderildi.");
            maskedTextBox1.Clear();
            textBox1.Clear();
            richTextBox1.Clear();
            gidenkutusu();

        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void mesajanasayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            gelenkutusu();
            gidenkutusu();
        }

        private void btnmailgoster_Click(object sender, EventArgs e)
        {
            mailekrani msjgoruntuleme = new mailekrani();

            msjgoruntuleme.a= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            msjgoruntuleme.b = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            msjgoruntuleme.c = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            msjgoruntuleme.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mailekrani msjgoruntule = new mailekrani();
           
            msjgoruntule.a = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            msjgoruntule.b = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            msjgoruntule.c = dataGridView3.CurrentRow.Cells[3].Value.ToString();

            msjgoruntule.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settings ayarlar = new settings();
            ayarlar.userId = numara;
            ayarlar.Show();
        }
    }  
}

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
using System.IO;

namespace WhisperChat
{
    public partial class kayıt : Form
    {
        
        
        public kayıt()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=IREM\\SQLEXPRESS;Initial Catalog=whisperChat;Integrated Security=True");
        SqlCommand komut ;

        private void button1_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand("Insert Into tblKisi (adsoyad, numara, sifre) Values (@P1, @P2, @P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", textBox1.Text);
            komut.Parameters.AddWithValue("@P2", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@P3", maskedTextBox2.Text);
         
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaydınız Başarılı Bir Şekilde Gerçekleştirildi");
            textBox1.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            Form1 geri = new Form1();
            geri.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Close();
        }

        private void kayıt_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}    



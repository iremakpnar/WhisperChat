using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace WhisperChat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlCommand komut;
        SqlConnection baglanti = new SqlConnection("Data Source=IREM\\SQLEXPRESS;Initial Catalog=whisperChat;Integrated Security=True");
    

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false; 
            sifredegistir frm = new sifredegistir();
            frm.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            kayıt frm = new kayıt();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("Select * From tblKisi Where numara=@P1 and sifre=@P2", baglanti);
            komut.Parameters.AddWithValue("@P1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@P2", maskedTextBox2.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                mesajanasayfa msjanasyf = new mesajanasayfa();
                msjanasyf.numara = maskedTextBox1.Text;
                msjanasyf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş!");
            }

            baglanti.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                maskedTextBox2.PasswordChar = '\0';
            }
            else
            {
                maskedTextBox2.PasswordChar = '•';
            }
        }

    }
}

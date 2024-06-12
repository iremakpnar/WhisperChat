using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Net.Mail;
using System.Data.SqlClient;


namespace WhisperChat
{
    public partial class sifredegistir : Form
    {
        public sifredegistir()
        {
            InitializeComponent();
        }

        public bool MailGonder(string konu, string icerik)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("Mail Adresiniz");
            ePosta.To.Add(txtMail.Text);

            ePosta.Subject = konu;
            ePosta.Body = icerik;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("Mail Adresiniz.", "Mail Şifreniz.");
            client.Port = 587;
            client.Host = "smtp.outlook.com";
            client.EnableSsl = true;
            client.Send(ePosta);
            object userState = true;
            bool kontrol = true;
            try
            {
                client.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                MessageBox.Show(ex.Message);
            }
            return kontrol;
        }


        string sifre;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Data Source=IREM\\SQLEXPRESS;Initial Catalog=whisperChat;Integrated Security=True");
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand komut = new SqlCommand("Select * From users where mail='" + txtMail.Text + "'");
                komut.Connection = baglanti;
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    sifre = oku["sifre"].ToString();

                    LblHata.Visible = true;
                    LblHata.ForeColor = Color.Green;
                    LblHata.Text = "Girmiş Olduğunuz Bilgiler Uyuşuyor !! Şifreniz Mail Olarak Gönderildi";

                    progressBar1.Visible = true;
                    progressBar1.Maximum = 900000;
                    progressBar1.Minimum = 90;

                    for (int j = 90; j < 900000; j++)
                    {
                        progressBar1.Value = j;
                    }

                    MailGonder("ŞİFRE HATIRLATMA", "Şifreniz :" + sifre);
                    baglanti.Close();
                }
                else
                {
                    LblHata.Visible = true;
                    LblHata.ForeColor = Color.Red;
                    LblHata.Text = "Girmiş Olduğunuz Bilgiler Uyuşmamaktadır ! ";
                }
            }
            catch (Exception)
            {
                LblHata.Visible = true;
                LblHata.ForeColor = Color.Red;
                LblHata.Text = "Mail Gönderme Hatası";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Close();
        }

    }

}
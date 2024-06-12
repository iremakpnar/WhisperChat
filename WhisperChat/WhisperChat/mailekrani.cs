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
    public partial class mailekrani : Form
    {
        public mailekrani()
        {
            InitializeComponent();
        }


        public string a, b, c;

        private void mailekrani_Load(object sender, EventArgs e)
        {
            textBox1.Text = a;
            textBox2.Text = b;
            richTextBox1.Text = c;
        }

    }
}

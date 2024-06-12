using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhisperChat
{
    public partial class settings : Form
    {
        public String userId { get; set; }
        public settings()
        {
            InitializeComponent();
        }

        private void btnResimDegistir_Click(object sender, EventArgs e)
        {
            resimguncelle rsmgnclle = new resimguncelle();
            rsmgnclle.userId = userId;
            rsmgnclle.Show();
            this.Close();
        }

    }
}

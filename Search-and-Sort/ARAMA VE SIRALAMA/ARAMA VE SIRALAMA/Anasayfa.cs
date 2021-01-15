using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARAMA_VE_SIRALAMA
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Siralama frm = new Siralama();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Arama frm = new Arama();
            frm.Show();
        }
    }
}

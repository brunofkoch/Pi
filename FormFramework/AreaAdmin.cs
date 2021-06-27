using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormFramework
{
    public partial class AreaAdmin : Form
    {
        public AreaAdmin()
        {
            InitializeComponent();
        }

     
        private void AreaAdmin_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManterProvas mProvas = new ManterProvas();
            mProvas.MdiParent = this;
            mProvas.Show();
        }
    }
}

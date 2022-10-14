//Navid-Derakhshandeh
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Industrial_Processes
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void tempToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Temp frm = new Temp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void eventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Event frm = new Event();
            frm.MdiParent = this;
            frm.Show();
        }

        private void valvesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Valves frm = new Valves();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}

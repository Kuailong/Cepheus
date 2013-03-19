using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo
{
    public partial class InterfaceRelatorio : Form
    {
        public InterfaceRelatorio()
        {
            InitializeComponent();
            this.ShowDataGrid(dgGame);
        }

        private void gamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowDataGrid(dgGame);
        }

        private void desenvolvedorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowDataGrid(dgDeveloper);
        }

        private void ShowDataGrid(DataGridView dgv)
        {
            dgGame.Hide();
            dgDeveloper.Hide();
            dgType.Hide();

            dgv.Show();
        }

        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowDataGrid(dgType);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

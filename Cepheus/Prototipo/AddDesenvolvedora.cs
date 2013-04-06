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
    public partial class AddDesenvolvedora : Form
    {
        public string NameDesenv { get; set; }
        public string DescriptDesenv { get; set; }

        public AddDesenvolvedora()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.NameDesenv = txtDesenvolvedoraName.Text;
            this.DescriptDesenv = txtDevelpDescrip.Text;
            this.Close();
        }
    }
}

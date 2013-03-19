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
    public partial class Interface1 : Form
    {
        public Interface1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form2 = new Interface2();
            this.Hide();
            form2.ShowDialog();
            this.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var addDesenv = new AddDesenvolvedora();
            addDesenv.ShowDialog();
            var desenvName = addDesenv.NameDesenv;
            cbxDesenv.Items.Add(desenvName);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var addType = new AddType();
            addType.ShowDialog();
            var nameType = addType.NameType;
            listBox1.Items.Add(nameType);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Hide();
            var intRelatorio = new InterfaceRelatorio();
            intRelatorio.ShowDialog();
            this.Show();
        }
    }
}

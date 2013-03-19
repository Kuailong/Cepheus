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

        private void button14_Click(object sender, EventArgs e)
        {
            var addDesenv = new AddDesenvolvedora();
            addDesenv.ShowDialog();
            var desenvName = new ComboBoxItem(addDesenv.NameDesenv, addDesenv.NameDesenv);
            cbxDesenv.Items.Add(desenvName);
            cbxDesenv.SelectedText = desenvName.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var addType = new AddType();
            addType.ShowDialog();
            var nameType = addType.NameType;
            listBox1.Items.Add(nameType);
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var intRelatorio = new InterfaceRelatorio();
            intRelatorio.ShowDialog();
            this.Show();
        }

        private void trackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Interface2();
            this.Hide();
            form2.ShowDialog();
            this.Show();
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ComboBoxItem(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}

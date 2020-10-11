using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tree
{
    public partial class Add_Root : Form
    {
        main_form f;
        public Add_Root(main_form f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                errorProvider1.SetError(textBox1, "you must enter number!!!");
            else
            {
                f.Root_name = textBox1.Text;
                f.create_root = true;
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
            else if (e.KeyCode == Keys.Escape)
                button2_Click(sender, e);

        }
    }
}

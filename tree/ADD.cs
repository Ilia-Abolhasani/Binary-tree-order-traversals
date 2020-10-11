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
    public partial class ADD : Form
    {
        main_form f;
        Node n;
        public ADD(main_form f, Node n)
        {
            InitializeComponent();
            this.f = f;
            this.n = n;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
                errorProvider1.SetError(textBox1, "you must enter number!!!");
            else
            {
                if (n==n.father.left)
                    f.Add_Node(textBox1.Text, main_form.Side.Left, n.father);
                else
                    f.Add_Node(textBox1.Text, main_form.Side.Right, n.father);
            }
            this.Close();            
        }        
        private void button2_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tree
{
    public partial class Node : Panel
    {
        public Node left;
        public Node Right;
        public Node father;
        public Label name;
        public main_form.node_Role Role;
        main_form f;        
        public int h;        
        public Node(string s,main_form.node_Role Role,main_form f,Size size)
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.Transparent;
            this.f = f;
            this.Role = Role;
            left   =null;
            Right  =null;
            father = null;
            name = new Label();
            this.Controls.Add(name);            
            name.BackColor = System.Drawing.Color.Transparent;
            this.Size = size;
            if (Role == main_form.node_Role.real)
                this.BackgroundImage = global::tree.Properties.Resources.node;                
            else
                this.BackgroundImage = global::tree.Properties.Resources.node_temp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            set_lable(s);
            name.MouseClick += name_MouseClick;
            this.MouseClick += name_MouseClick;
        }        
        void name_MouseClick(object sender, MouseEventArgs e)
        {
            if (Role==main_form.node_Role.display)
            {
                ADD temp = new ADD(f,this);
                temp.ShowDialog();
            }
        }
        public Node(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        int get_hight(Node n)
        {
            if (n.father == null)
                return 1;
            return 1 + get_hight(n.father);
        }        
        public void set_lable(string s)
        {
            name.Size = new System.Drawing.Size(0, 0);
            name.AutoSize = true;
            float f=(this.Size.Width/4);
            float font=18F;
            font -= get_hight(this)* 1.7F;
            name.Font = new System.Drawing.Font("Microsoft Sans Serif", font, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            name.Text = s;
            name.Location = new Point((this.Size.Width - name.Size.Width) / 2, (this.Size.Height- name.Size.Height) / 2);
        }        
    }
}

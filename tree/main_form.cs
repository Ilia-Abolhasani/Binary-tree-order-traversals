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
    public partial class main_form : Form
    {        
        #region Data
        public enum node_Role { real, display }
        public enum Side { Left, Right }       
        LinkedList<Node> Store;
        LinkedList<Node> choise;
        Node root;
        bool Unique = true;
        bool exist_node;
        public string Root_name = "";
        public bool create_root = false;
        public main_form()
        {
            InitializeComponent();
            Store = new LinkedList<Node>();
            choise = new LinkedList<Node>();            
        }
        #endregion
        #region Show & Add
        public void Exist_node(Node node,string name)
        {
            if (node.name.Text == name)
                exist_node = true;
            else
            {
              if (node.left != null)
                  Exist_node(node.left, name);
              if (node.Right != null)
                  Exist_node(node.Right, name);
            }
        }        
        public void clear_show()
        {
            foreach (var item in choise)
            {
                groupBox4.Controls.Remove(item);
                if (item.father.left == item)
                    item.father.left = null;
                else
                    item.father.Right = null;
            }
            try
            {
                choise.Clear();
            }
            catch { }
        }
        public void Show_choise(Node temp)
        {
            if (temp == null)
                return;
            if (temp.left != null)
                Show_choise(temp.left);
            else if (temp.left == null)
                Add_choise(Side.Left, temp);                
            if (temp.Right != null)
                Show_choise(temp.Right);
            else if (temp.Right == null)
                Add_choise(Side.Right, temp);
            set_all_of_location();
            groupBox4.Refresh();
        }
        public void Add_choise(Side side, Node father)
        {
            Size size = new System.Drawing.Size(60 - (father.h * 7), 60 - (father.h * 7));
            Node temp = new Node("add", node_Role.display, this, size);
            temp.h = father.h + 1;
            choise.AddLast(temp);
            this.groupBox4.Controls.Add(temp);
            temp.father = father;
            if (Side.Left == side)
                father.left = temp;
            else
                father.Right = temp;
            temp.set_lable(temp.name.Text);
        }
        public void Add_Node(string name,Side side, Node father)
        {
            textBox1.Text = "add new node... press «add node» button";                        
            exist_node = false;
            Exist_node(root, name);
            if (!exist_node|| !Unique)
            {                
            clear_show();
            Size size = new System.Drawing.Size(60 - (father.h * 7), 60 - (father.h * 7));
            Node temp = new Node(name, node_Role.real, this, size);
            temp.father = father;
            temp.h = father.h + 1;
            Store.AddLast(temp);            
            this.groupBox4.Controls.Add(temp);
            if (Side.Left == side)
                father.left = temp;
            else
                father.Right = temp;     
            temp.set_lable(temp.name.Text);
            set_all_of_location();
            set_Scrolling();
            }
            else
            {
                MessageBox.Show("this name in use for another node!!!");
            }
            groupBox4.Refresh();
        }
        #region location
        private void main_form_SizeChanged(object sender, EventArgs e)
        {
            set_all_of_location();
        }       
        public void set_all_of_location()
        {
            try
            {

            foreach (var item in Store)
                set_location(item);
            foreach (var item in choise)
                set_location(item);
            }
            catch (Exception)
            {
                
               
            }
        }
        public void set_location(Node temp)
        {                                                                    
            Point point = new Point();
            point.Y = (temp.h-1) *75 + 25;
            point.X = (groupBox4.Size.Width / (pow2(temp.h-1) + 1)) * get_x_index(temp);            
            temp.Location = point;
        }        
        public int get_x_index(Node temp)
        {
            if (temp.father==null)
	            return 1;
            else if (temp.father.Right == temp)
                return (get_x_index(temp.father) * 2);
            else 
                return (get_x_index(temp.father) * 2)-1;
        }
        public int pow2(int a)
        {
            int ans = 1;
            for (int i = 0; i < a; i++)
                ans *= 2;
            return ans;
        }
        #endregion        
        #endregion
        #region Scrolling        
        public void set_Scrolling()
        {
            clear_show();
            label2.Text = clean_string(Preorder_Scrolling(root, ""));
            label3.Text = clean_string(Inorder_Scrolling(root, ""));
            label5.Text = clean_string(Posorder_Scrolling(root, ""));
        }
        String clean_string(String s)
        {
            return s;
        }
        public string Preorder_Scrolling(Node temp,string s)
        {
            s += temp.name.Text+" , ";
            if (temp.left != null)
                s= Preorder_Scrolling(temp.left, s);
            if (temp.Right!= null)
                s=Preorder_Scrolling(temp.Right, s);
            return s;
        }
        public string Inorder_Scrolling(Node temp, string s)
        {

            if (temp.left != null)
                s = Inorder_Scrolling(temp.left, s);
            s += temp.name.Text + " , ";
            if (temp.Right != null)
                s = Inorder_Scrolling(temp.Right, s);
            return s;
        }
        public string Posorder_Scrolling(Node temp, string s)
        {
            if (temp.Right != null)
                s = Posorder_Scrolling(temp.Right, s);
            if (temp.left != null)
                s = Posorder_Scrolling(temp.left, s);
            s += temp.name.Text + " , ";
            return s;
        }
        #endregion
        #region evnents
        private void button1_Click(object sender, EventArgs e)
        {
            if (!create_root )
            {
                textBox1.Text = "Choose a name for the root node...   ignore press «Esc»     create press «enter»";
                Add_Root f = new Add_Root(this);
                f.ShowDialog();
                if (create_root)
                {
                    Size size = new System.Drawing.Size(60, 60);            
                    root = new Node(Root_name, node_Role.real, this,size);
                    Store.AddFirst(root);
                    root.father = null;            
                    this.groupBox4.Controls.Add(root);
                    root.h = 1; 
                    set_all_of_location();
                    set_Scrolling();
                    textBox1.Text = "add new node... press «add node» button";                        
                }
                else
                    textBox1.Text = "Click the «add root» button...";
            }
            else            
                textBox1.Text = "You already have added the root ! for add new node press «add node» button";                        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (create_root)
            {                
            clear_show();
            textBox1.Text = "You can click gray nodes and Serve as new node add to your tree";
            Show_choise(root);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            clear_show();
            groupBox4.Controls.Clear();
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(label6);
            label2.Text = "-";
            label3.Text = "-";
            label5.Text = "-";
            create_root = false;
            groupBox4.Refresh();
            try
            {
            Store.Clear();
            }
            catch {}
            groupBox4.Refresh();
            textBox1.Text = "To start Click the «add root» button...";
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            textBox1.Clear();
        }     
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                Unique = true;
            }
            else
            {
                Unique = false;
            }
        }
        #endregion  
        #region Graphic
        private Point center_node(Point point,Node node)
        {
            point.X += (node.Size.Width) / 2;
            point.Y += (node.Size.Height) / 2;
            return point;
        }

        public void all_line(Graphics g)
        {                                        
                foreach (var item in Store)
                {
                    if (item.left != null)
                    {
                        if (item.left.Role==node_Role.real)
                            line(g, center_node(item.Location, item), center_node(item.left.Location, item.left),5);
                        else
                            line(g, center_node(item.Location, item), center_node(item.left.Location, item.left),2);

                    }
                    if (item.Right != null)
                    {
                        if (item.Right.Role==node_Role.real)
                            line(g, center_node(item.Location, item), center_node(item.Right.Location, item.Right),5);
                        else
                            line(g, center_node(item.Location, item), center_node(item.Right.Location, item.Right),2);

                    }
                }            
        }

        public void line(Graphics g, Point A, Point B,int pen_width)
        {
            using (Pen mypen = new Pen(Color.Black, pen_width))
            {
                g.DrawLine(mypen, A, B);
            }
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics= e.Graphics;
            all_line(graphics);
        }

        #endregion         
        private void main_form_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Welcome to the binary tree Project :) To start Click the «add root» button...";
        }
    }
}

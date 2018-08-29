using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algo
{
    public partial class StackQueue : Form
    {
        Stack<String> stack = new Stack<String>();
        Queue<String> queue = new Queue<String>();
        List<String> list = new List<String>();

        public StackQueue()
        {
            InitializeComponent();
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtElement.Text))
            {
                MessageBox.Show("Enter Value");
                txtElement.Clear();
                txtElement.Focus();
            }
            else
            {

                String add;
                add = txtElement.Text;
                stack.Push(add);

                txtElement.Clear();
                txtElement.Focus();
                stackListBox.Items.Clear();
                foreach (String s in stack)
                {
                    stackListBox.Items.Add((Environment.NewLine + s.ToString()));

                }
            }    

        }

        private void btnPop_Click(object sender, EventArgs e)
        {

            if (stack.Count > 0)
            {
                stack.Pop();
                stackListBox.Items.Clear();
                foreach (String s in stack)
                {
                    stackListBox.Items.Add((Environment.NewLine + s.ToString()));
                }
            }
            else
                MessageBox.Show("Empty Stack");

        }

        private void btnPeek_Click(object sender, EventArgs e)
        {

            if (stack.Count > 0)
            {
                var element = stack.Peek();
                MessageBox.Show("Element at the top of stack is  " + element.ToString());
            }
            else
                MessageBox.Show("Empty Stack");
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            var element = stack.Count();
            MessageBox.Show("Number of Element is: " + element.ToString());

        }

        
    }
}

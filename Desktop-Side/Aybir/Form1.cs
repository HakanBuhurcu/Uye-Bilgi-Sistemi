using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aybir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Form3 form3= new Form3();
            form3.Show();
            this.Hide();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

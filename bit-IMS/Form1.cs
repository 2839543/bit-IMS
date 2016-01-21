using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bit_IMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要退出吗?", "退出系统", messButton);
            if (dr == DialogResult.OK)
            {
                this.Close();
               // Application.Exit();
            }
            
        }

        private void menu_teacher_add_Click(object sender, EventArgs e)
        {
            teacher teacher = new teacher(); 
            teacher.Show();
        }

        private void menu_teacher_roster_Click(object sender, EventArgs e)
        {

        }

        private void menu_about_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
    }
}

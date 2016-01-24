using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Data.Common;
using System.Data.SQLite;
using bit_IMS.App_code;

/********************************************************************************

** 作者： haoxiaoqi

** 创始时间：2016-1-19 

** 描述：

**  教师数据处理，…

*********************************************************************************/
namespace bit_IMS
{
    public partial class Bit_Form : Form
    {
        public Bit_Form()
        {
            
            InitializeComponent();
        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Enabled = false;
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
            teacher teacher = new teacher(this); 
            teacher.Show();
             
        }

        private void menu_teacher_roster_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Enabled = true; 
            //把首页 放置到最后
            this.panel1.SendToBack();
            this.dataGridView1.Show();

            this.menu_teacher_roster.Enabled = false ;

            this.menu_home.Enabled = true;
            this.menu_teacher_add.Enabled = true;
            this.menu_teacher_update.Enabled = true;
            this.menu_teacher_del.Enabled = true;
             
        }

        private void menu_about_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void menu_contact_Click(object sender, EventArgs e)
        {
            //调用发邮件
            System.Diagnostics.Process.Start("mailto:2839543@qq.com"); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDataGridView();
             
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
          DataGridViewCellCollection cells =  this.dataGridView1.CurrentRow.Cells;
           Teacher t = new Teacher();

          t.name       =  cells[0].Value.ToString();  
          t.sex        =  cells[1].Value.ToString(); 
          t.birth      =  cells[2].Value.ToString(); 
          t.minzu      =  cells[3].Value.ToString(); 
          t.xueli      =  cells[4].Value.ToString(); 
          t.zzmm       =  cells[5].Value.ToString(); 
          t.zhicheng   =  cells[6].Value.ToString(); 
          t.xuexiao    =  cells[7].Value.ToString(); 
          t.tel        =  cells[8].Value.ToString(); 
          t.address    =  cells[9].Value.ToString();


          GlobalConf.teacher = t;

            teacher teacher = new teacher(this);
            teacher.Show();  

        }

        private void menu_teacher_del_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection cells = this.dataGridView1.CurrentRow.Cells;

             string name = cells[0].Value.ToString();
                string tel = cells[8].Value.ToString();

            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要删除["+ name +"]吗?", "删除教师信息", messButton);
            if (dr == DialogResult.OK)
            { 
                Sqlite_teacher_T.Delete(name, tel);
                loadDataGridView();
            } 
           
        }

        private void loadDataGridView() {

            using (SQLiteConnection con = new SQLiteConnection(GlobalConf.DB_PATH))
            {
                con.Open();
                string sqlStr = @"SELECT *
                                    FROM teacher";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlStr, con))
                {


                    cmd.CommandType = CommandType.Text;
                    SQLiteDataAdapter dbDataAdapter = new SQLiteDataAdapter(cmd);
                    DataSet dataSet = new DataSet();

                    dbDataAdapter.Fill(dataSet, "teacher");
                    dataGridView1.DataSource = dataSet.Tables["teacher"];
                   
                }
            }  
        }

        private void menu_update_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow.Selected)
            {
                DataGridViewCellCollection cells = this.dataGridView1.CurrentRow.Cells;
                Teacher t = new Teacher();

                t.name = cells[0].Value.ToString();
                t.sex = cells[1].Value.ToString();
                t.birth = cells[2].Value.ToString();
                t.minzu = cells[3].Value.ToString();
                t.xueli = cells[4].Value.ToString();
                t.zzmm = cells[5].Value.ToString();
                t.zhicheng = cells[6].Value.ToString();
                t.xuexiao = cells[7].Value.ToString();
                t.tel = cells[8].Value.ToString();
                t.address = cells[9].Value.ToString();


                GlobalConf.teacher = t;

                teacher teacher = new teacher(this);
                teacher.Show();
            }
            else
            {
                MessageBox.Show("没有选择教师记录");
            }
            
        }

        private void menu_home_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Enabled = false;
            //把首页放到最前
            this.panel1.BringToFront();


            this.menu_teacher_roster.Enabled = true;

            this.menu_home.Enabled = false;
            this.menu_teacher_add.Enabled = false;
            this.menu_teacher_update.Enabled = false;
            this.menu_teacher_del.Enabled = false;
        } 
    }
}

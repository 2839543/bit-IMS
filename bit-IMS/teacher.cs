using bit_IMS.App_code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SQLite; 


/********************************************************************************

** 作者： haoxiaoqi

** 创始时间：2016-1-21

** 描述：

**  教师数据处理，…

*********************************************************************************/
namespace bit_IMS
{
    public partial class teacher : Form
    {
        Bit_Form form1;

        public teacher()
        { 
            InitializeComponent();
        }

        public teacher(Bit_Form form)
        {
            this.form1 = form;
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            this.Close(); 
            teacher teacher = new teacher();
            teacher.Show();
        }

        private void teacher_Load(object sender, EventArgs e)
        {


            if (GlobalConf.teacher != null)
            {
                 this.tbx_name.Text              =    GlobalConf.teacher.name;
                // this.rdb_male.Checked ? "男" : "女";          =    GlobalConf.teacher.sex;
               // this.dt_birth.Value=  GlobalConf.teacher.birth;
                this.cbx_minzu.Text                   =    GlobalConf.teacher.minzu;
                this.cbx_xueli.Text                     =    GlobalConf.teacher.xueli;
                this.cbx_zzmm.Text                       =    GlobalConf.teacher.zzmm;
                this.tbx_zhicheng.Text               =    GlobalConf.teacher.zhicheng;
                this.tbx_xuexiao.Text                  =    GlobalConf.teacher.xuexiao;
                this.tbx_tel.Text                        =    GlobalConf.teacher.tel;
                this.tbx_address.Text                =    GlobalConf.teacher.address;
            }
            else {
                this.cbx_xueli.SelectedIndex = 1;
                this.cbx_minzu.SelectedIndex = 1;
                this.cbx_zzmm.SelectedIndex = 1;
            }
        }

        private void cbx_minzu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string name = this.tbx_name.Text;
            string sex = this.rdb_male.Checked ? "男" : "女";
            string birth = this.dt_birth.Value.ToShortDateString();
            string minzu = this.cbx_minzu.Text;
            string xueli = this.cbx_xueli.Text;
            string zzmm = this.cbx_zzmm.Text;
            string zhicheng = this.tbx_zhicheng.Text;
            string xuexiao = this.tbx_xuexiao.Text;
            string tel = this.tbx_tel.Text;
            string address = this.tbx_address.Text;

            if (Sqlite_teacher_T.Insert(name, sex, birth, minzu, xueli, zzmm, zhicheng, xuexiao, tel, address) > 0)
            {
                MessageBox.Show("添加["+name+"]成功");
                this.btn_reset_Click(null, null);
                loadDataGridView();
            }
            else
            {

                MessageBox.Show("保存[" + name + "]失败");
            }

        }

        private void loadDataGridView()
        {

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
                    this.form1.dataGridView1.DataSource = dataSet.Tables["teacher"];

                }
            }
        }
    }
}

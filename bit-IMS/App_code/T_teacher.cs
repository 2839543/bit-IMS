using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SQLite;


/********************************************************************************

** 作者： haoxiaoqi

** 创始时间：2016-1-23 

** 描述：

**  教师数据处理，…

*********************************************************************************/

namespace bit_IMS.App_code
{

    public class Sqlite_teacher_T
    {

        public Sqlite_teacher_T()   //无参数构造函数
        {
            SQLiteConnection conn = null;
            conn = new SQLiteConnection(GlobalConf.DB_PATH);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  
        }


        public static void Select()
        {

            using (SQLiteConnection con = new SQLiteConnection(GlobalConf.DB_PATH))
            {
                con.Open();
                string sqlStr = @"SELECT *
                                    FROM teacher";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlStr, con))
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine(dr["hero_id"].ToString() + dr["hero_name"]);
                        }
                    }
                }
            }
        }




        public static int Insert(String name, String sex, String birth, String minzu, String xueli, String zzmm, String zhicheng, String xuexiao, String tel, String address)
        {
            using (SQLiteConnection con = new SQLiteConnection(GlobalConf.DB_PATH))
            {
                con.Open();
                string sqlStr = @"INSERT INTO teacher ( name,  sex,  birth, minzu, xueli, zzmm, zhicheng, xuexiao , tel,  address)
                                  VALUES
                                  (
                                      '" + name + "','" + sex + "','" + birth + "','" + minzu + "','" + xueli + "','" + zzmm + "','" + zhicheng + "','" + xuexiao + "','" + tel + "','" + address +
                                  "')";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlStr, con))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(String name, String sex, DateTime birth, String minzu, String xueli, String zzmm, String zhicheng, String xuexiao, String tel, String address)
        {
            using (SQLiteConnection con = new SQLiteConnection(GlobalConf.DB_PATH))
            {
                con.Open();
                string sqlStr = @"UPDATE teacher
                                     SET  sex = '" + sex +"',  birth = '"+ birth +"', minzu = '"+minzu+"', xueli = '"+ xueli + "', zzmm = '"+ zzmm 
                                                  +"', zhicheng = '"+ zhicheng +"', xuexiao = '" + xuexiao +"', tel = '" + tel + "',  address = '"+address 
                                                  + "') WHERE name = '"+ name +"'";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlStr, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(string name ,string tel )
        {
            using (SQLiteConnection con = new SQLiteConnection(GlobalConf.DB_PATH))
            {
                con.Open();
                string sqlStr = @"DELETE FROM teacher where name='"+ name +"' and  tel = '"+ tel +"'";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlStr, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteAll()
        {
            using (SQLiteConnection con = new SQLiteConnection(GlobalConf.DB_PATH))
            {
                con.Open();
                string sqlStr = @"DELETE FROM teacher";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlStr, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public class Teacher
    {
       public string name = String.Empty;
       public string sex = String.Empty;
       public string birth = String.Empty;
       public string minzu = String.Empty;
       public string xueli = String.Empty;
       public string zzmm = String.Empty;
       public string zhicheng = String.Empty;
       public string xuexiao = String.Empty;
       public string tel = String.Empty;
       public string address = String.Empty;


        public Teacher()
        {

        }
        public  Teacher(string name, string sex, string birth, string minzu, string xueli, string zzmm, string zhicheng,
            string xuexiao, string tel, string address)
        {
            this.name       = name;
            this.sex        = sex;
            this.birth      = birth;
            this.minzu      = minzu;
            this.xueli      = xueli;
            this.zzmm       = zzmm;
            this.zhicheng   = zhicheng;
            this.xuexiao    = xuexiao;
            this.tel        = tel;
            this.address    = address;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormUpdatePwd_User : Form
    {
        public FormUpdatePwd_User()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtisPwd.Text == "" || txtNewPwd.Text == "" || txtOldPwd.Text == "")
            {
                MessageBox.Show("有空项！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNewPwd.Text != txtisPwd.Text)
            {
                MessageBox.Show("密码不匹配！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Dao dao = new Dao();
            dao.connect();
            string sql = $"select Password from Table_User where UserAccount='{FormStart.acc}'";
            SqlDataReader reader = dao.read(sql);
            reader.Read();
            if (reader[0].ToString() != txtOldPwd.Text)
            {
                MessageBox.Show("密码不正确！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {

                sql = $"update Table_User set Password='{txtisPwd.Text}' where UserAccount = '{FormStart.acc}'";
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("修改成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    reader.Close();
                    dao.DaoClose();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("修改失败！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("ERROR！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


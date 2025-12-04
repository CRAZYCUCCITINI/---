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
    public partial class FormUpdateUserType : Form
    {
        public FormUpdateUserType()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (txtID.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("有空项", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Dao dao = new Dao();
            dao.connect();

            string sqlCheck = $"SELECT TypeID FROM Table_UserType WHERE TypeID = '{txtID.Text}'";
            SqlDataReader reader = dao.read(sqlCheck);
            // 若reader能读取到数据，说明账号存在

            bool exists = reader.Read();
            if (exists && txtID.Text != FormManageUserType.tid)
            {
                MessageBox.Show("编号已存在", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reader.Close();
                dao.DaoClose();
                return;
            }
            else
            {
                string sql = $"update Table_UserType set TypeID ='{txtID.Text}',Type = '{txtName.Text}' where TypeID = '{FormManageUserType.tid}'";
                if (dao.Execute(sql) > 0)
                {
                    reader.Close();
                    dao.DaoClose();
                    MessageBox.Show("修改成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    reader.Close();
                    dao.DaoClose();
                    MessageBox.Show("修改失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUpdateUserType_Load(object sender, EventArgs e)
        {
            txtID.Text = FormManageUserType.tid;
            txtName.Text = FormManageUserType.tname;
        }
    }
}

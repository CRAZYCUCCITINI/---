using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormAddBookType : Form
    {
        public FormAddBookType()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txttypeID.Text.Trim() == "" || txtTypeName.Text.Trim() == "")
            {
                MessageBox.Show("有空项", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Dao dao = new Dao();
            dao.connect();

            string sqlCheck = $"SELECT TypeID FROM Table_BookType WHERE TypeID = '{txttypeID.Text}'";
            SqlDataReader reader = dao.read(sqlCheck);
            // 若reader能读取到数据，说明账号存在
            bool exists = reader.Read();

            if (exists)
            {
                MessageBox.Show("编号已存在", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reader.Close();
                dao.DaoClose();
                return;
            }
            else
            {
                string sql = $"insert into Table_BookType values ('{txttypeID.Text}','{txtTypeName.Text}')";
                try
                {
                    if (dao.Execute(sql) > 0)
                    {
                        reader.Close();
                        dao.DaoClose();
                        MessageBox.Show("添加成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        reader.Close();
                        dao.DaoClose();
                        MessageBox.Show("添加失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                catch
                {
                    reader.Close();
                    dao.DaoClose();
                    MessageBox.Show("ERROR", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

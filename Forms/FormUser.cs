using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
        }

        private void 反馈到管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确认退出吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            this.label1.Text = $"读者：{FormStart.name}  {FormStart.acc}";
        }

        private void 注销账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确认注销账号吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                string acc = FormStart.acc;
                Dao dao = new Dao();
                dao.connect();
                string sql = $"delete Table_User where UserAccount = '{acc}'";
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("注销账号成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dao.DaoClose();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注销账号失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    dao.DaoClose();
                }
            }
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpdatePwd_User form = new FormUpdatePwd_User();
            form.ShowDialog();   
        }

        private void 租借图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBororwBook form = new FormBororwBook();
            form.ShowDialog();
        }

        private void 归还图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReturnBook form = new FormReturnBook();
            form.ShowDialog();
        }
    }
}

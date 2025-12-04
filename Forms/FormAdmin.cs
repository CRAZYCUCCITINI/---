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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void 图书管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 图书管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确认退出吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            this.label1.Text = $"管理员：{FormStart.name}  {FormStart.acc}";
        }

        private void 注销账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确认注销账号吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                string acc = FormStart.acc;
                Dao dao = new Dao();
                dao.connect();
                string sql = $"delete Table_Admin where AdminAccount = '{acc}'";
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("注销账号成功","消息",MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            FormUpdatePwd_Admin form = new FormUpdatePwd_Admin();
            form.ShowDialog();
        }

        private void 添加图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddBook form = new FormAddBook();
            form.ShowDialog();
        }

        private void 图书管理1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManage form = new FormManage();
            form.ShowDialog();
        }

        private void 查看用户租借ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCheckBorrow form = new FormCheckBorrow(); 
            form.ShowDialog();
        }

        private void 读者管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageUser form = new FormManageUser(); 
            form.ShowDialog();
        }

        private void 图书类别管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageBookType form = new FormManageBookType(); 
            form.ShowDialog();
        }

        private void 用户信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageUserType form = new FormManageUserType(); 
            form.ShowDialog();
        }
    }
}

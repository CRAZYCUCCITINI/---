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
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister form = new FormRegister();
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
             if (DialogResult.Yes == MessageBox.Show("确认退出吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.Close();
            }
        }
        public static string acc;
        public static string name;
        private void AdminLogin()
        {
            string acc = txtAccount.Text;
            string pwd = txtPassword.Text;

            Dao dao = new Dao();
            dao.connect();
            string sql = $"select * from Table_Admin where AdminAccount ='{acc}' and Password = '{pwd}'";
            SqlDataReader reader = dao.read(sql);
            if (reader.Read())
            {
                FormStart.acc = acc;
                sql = $"select [Name] from Table_Admin where AdminAccount='{acc}'";
                reader = dao.read(sql);
                reader.Read();
                FormStart.name = reader[0].ToString();

                txtAccount.Text = "";
                txtPassword.Text = "";

                reader.Close();
                dao.DaoClose();

                FormAdmin form = new FormAdmin();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("账号和密码错误！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void UserLogin()
        {
            string acc = txtAccount.Text;
            string pwd = txtPassword.Text;

            Dao dao = new Dao();
            dao.connect();
            string sql = $"select * from Table_User where UserAccount ='{acc}' and Password = '{pwd}'";
            SqlDataReader reader = dao.read(sql);
            if (reader.Read())
            {
                string sqlCheck = $"select Used from Table_User where UserAccount = '{acc}'";
                reader = dao.read(sqlCheck);
                reader.Read();
                if ((bool)reader[0] != true)
                {
                    MessageBox.Show("你的账号已停用！\n\r请联系管理员", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FormStart.acc = acc;
                sql = $"select [Name] from Table_User where UserAccount='{acc}'";
                reader = dao.read(sql);
                reader.Read();
                FormStart.name = reader[0].ToString();

                txtAccount.Text = "";
                txtPassword.Text = "";

                reader.Close();
                dao.DaoClose();

                FormUser form = new FormUser();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("账号和密码错误！", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtAccount.Text == ""|| txtPassword.Text == "")
            {
                MessageBox.Show("有空项", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                return;
            }
            if (rbtnAdmin.Checked)
            {
                AdminLogin();
            }
            if (rbtnUser.Checked)
            {
                UserLogin();
            }
        }

        private void FormStart_Load(object sender, EventArgs e)
        {

        }
    }
}

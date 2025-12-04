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
    public partial class FormManageUser : Form
    {
        public FormManageUser()
        {
            InitializeComponent();
        }

        public static string acc;
        private void LoadUserInfo()
        {
            dgv.Rows.Clear();
            Dao dao = new Dao();
            dao.connect();
            string sql = $"select UserAccount,Name,Occupation,Sex,ID,Tel,Used from Table_User ";
            SqlDataReader reader = dao.read(sql);

            while (reader.Read())
            {
                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());

            }
            reader.Close();
            dao.DaoClose();
        }
        private void FormManageUser_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
            if(dgv.Rows.Count > 1 )
            {
                lblAcc.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            }
            acc = lblAcc.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(lblAcc.Text == "NULL")
            {
                MessageBox.Show("未选中", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Dao dao = new Dao();
            dao.connect();
            string sql = $"update Table_User set Used = 0 where UserAccount = '{lblAcc.Text}'";
            if(dao.Execute(sql) > 0)
            {
                dao.DaoClose();
                MessageBox.Show("用户被停止登录", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserInfo();
            }
            else
            {
                dao.DaoClose();
                MessageBox.Show("操作失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblAcc.Text == "NULL")
            {
                MessageBox.Show("未选中", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Dao dao = new Dao();
            dao.connect();
            string sql = $"update Table_User set Used = 1 where UserAccount = '{lblAcc.Text}'";
            if (dao.Execute(sql) > 0)
            {
                dao.DaoClose();
                MessageBox.Show("用户被允许登录", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserInfo();
            }
            else
            {
                dao.DaoClose();
                MessageBox.Show("操作失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblAcc.Text = dgv.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyWords.Text.Trim();
            dgv.Rows.Clear();
            Dao dao = new Dao();
            dao.connect();
            string sql = $"select UserAccount,Name,Occupation,Sex,ID,Tel,Used from Table_User where UserAccount like '%{keyword}%' or Name like '%{keyword}%' or Sex like '%{keyword}%' or Used like '%{keyword}%'";
            SqlDataReader reader = dao.read(sql);
            while (reader.Read())
            {
                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());
            }
            reader.Close();
            dao.DaoClose();

        }

        private void lblAcc_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormUpdateUser form = new FormUpdateUser();
            form.ShowDialog();
        }
    }
}

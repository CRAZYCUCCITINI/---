using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BookManageSystem
{
    public partial class FormManageBookType : Form
    {
        public FormManageBookType()
        {
            InitializeComponent();
        }
        public static string tid;
        public static string tname;
        private void loadTypes()
        {
            dgv.Rows.Clear();
            Dao dao = new Dao();
            dao.connect();
            string sql = $"select * from Table_BookType";
            SqlDataReader reader = dao.read(sql);

            while (reader.Read())
            {

                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString());
            }
            reader.Close();
            dao.DaoClose();
        }

        

        private void FormManageBookType_Load(object sender, EventArgs e)
        {
            loadTypes();
            if(dgv.Rows.Count == 1)
            {
                ;
            }
            else
            {
                lblID.Text = dgv.CurrentRow.Cells[0].Value.ToString();
                lblType.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                tid = dgv.CurrentRow.Cells[0].Value.ToString();
                tname = dgv.CurrentRow.Cells[1].Value.ToString();
            }
        }
            
        

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("选中无效数据！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = dgv.CurrentRow.Cells[0].Value.ToString();
            string type = dgv.CurrentRow.Cells[1].Value.ToString();
            lblID.Text = id;
            lblType.Text = type;

            tid = dgv.CurrentRow.Cells[0].Value.ToString();
            tname = dgv.CurrentRow.Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadTypes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = txtKeyWords.Text.Trim();
            Dao dao = new Dao();
            dao.connect();
            string sql = $"select * from Table_BookType where TypeID like '%{key}%' or Type like '%{key}%' ";
            SqlDataReader reader = dao.read(sql);

            dgv.Rows.Clear();

            while (reader.Read())
            {

                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString());
            }
            reader.Close();
            dao.DaoClose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "NULL")
            {
                MessageBox.Show("未选中图书类型", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            Dao dao = new Dao();
            dao.connect();
            string sql = $"delete Table_BookType where TypeID = '{lblID.Text}'";
            if (dao.Execute(sql) > 0)
            {
                lblID.Text = "NULL";
                lblType.Text = "NULL";
                loadTypes();
                dao.DaoClose();
                MessageBox.Show("删除成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dao.DaoClose();
                MessageBox.Show("删除失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAddBookType form = new FormAddBookType();
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormUpdateBookType form = new FormUpdateBookType();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

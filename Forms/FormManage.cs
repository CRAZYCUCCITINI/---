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
    public partial class FormManage : Form
    {
        public FormManage()
        {
            InitializeComponent();
        }

        public static string bid;
        public static string bname;
        public static string author;
        public static string press;
        public static string pubdate;
        public static string type;
        public static int quantity;

        private void button2_Click(object sender, EventArgs e)
        {
            FormAddBook form = new FormAddBook();
            form.ShowDialog();
        }
        private void LoadBooks()

        {
            dgv.Rows.Clear();
            Dao dao = new Dao();
            dao.connect();
            string sql = $"select * from Table_Book";
            SqlDataReader reader = dao.read(sql);

            while (reader.Read())
            {

                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), 
                    reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),
                    reader[6].ToString(), reader[7].ToString());
            }
            reader.Close();
            dao.DaoClose();
        }

        private void FormManage_Load(object sender, EventArgs e)
        {
            LoadBooks();
            if (dgv.Rows.Count == 1)
            {
                ;
            }
            else
            {
                lblID.Text = dgv.CurrentRow.Cells[0].Value.ToString();
                lblBookName.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                bid = dgv.CurrentRow.Cells[0].Value.ToString();
                bname = dgv.CurrentRow.Cells[1].Value.ToString();
                author = dgv.CurrentRow.Cells[2].Value.ToString();
                press = dgv.CurrentRow.Cells[3].Value.ToString();
                pubdate = dgv.CurrentRow.Cells[4].Value.ToString();
                type = dgv.CurrentRow.Cells[5].Value.ToString();
                quantity = int.Parse(dgv.CurrentRow.Cells[6].Value.ToString());
            }
        }
            
        

        private void dgv_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("选中无效数据！","消息",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            string id = dgv.CurrentRow.Cells[0].Value.ToString();
            string name = dgv.CurrentRow.Cells[1].Value.ToString();

            lblID.Text = id;
            lblBookName.Text = name;

            bid = dgv.CurrentRow.Cells[0].Value.ToString();
            bname = dgv.CurrentRow.Cells[1].Value.ToString();
            author = dgv.CurrentRow.Cells[2].Value.ToString();
            press = dgv.CurrentRow.Cells[3].Value.ToString();
            pubdate = dgv.CurrentRow.Cells[4].Value.ToString();
            type = dgv.CurrentRow.Cells[5].Value.ToString();
            quantity = int.Parse(dgv.CurrentRow.Cells[6].Value.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            LoadBooks();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = txtKeyWords.Text.Trim();
            Dao dao = new Dao();
            dao.connect();
            string sql = $"select * from Table_Book where bookName like '%{key}%' or Author like '%{key}%' or Press like '%{key}%'";
            SqlDataReader reader = dao.read(sql);

            dgv.Rows.Clear();

            while (reader.Read())
            {

                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                    reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),
                    reader[6].ToString(), reader[7].ToString());
            }
            reader.Close();
            dao.DaoClose();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "NULL")
            {
                MessageBox.Show("未选中图书","消息",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            Dao dao = new Dao();
            dao.connect();
            string sql = $"delete Table_Book where bookID = '{lblID.Text}'";
            if(dao.Execute(sql) > 0)
            {
                lblID.Text = "NULL";
                lblBookName.Text = "NULL";
                LoadBooks();
                dao.DaoClose();
                MessageBox.Show("下架成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dao.DaoClose();
                MessageBox.Show("删除失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormUpdateBook form = new FormUpdateBook(); 
            form.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

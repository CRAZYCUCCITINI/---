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
    public partial class FormReturnBook : Form
    {
        public FormReturnBook()
        {
            InitializeComponent();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadBorrowInfo()
        {
            dgv.Rows.Clear();
            Dao dao = new Dao();
            dao.connect();
            string sql = $"select * from Table_Borrow where UserAccount = '{FormStart.acc}' ";
            SqlDataReader reader = dao.read(sql);

            while (reader.Read())
            {
                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());

            }
            reader.Close();
            dao.DaoClose();
        }

        private void FormReturnBook_Load(object sender, EventArgs e)
        {
            LoadBorrowInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("未选中数据", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int key = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
            Dao dao = new Dao();
            dao.connect();
            string sqlDelete = $"delete Table_Borrow where [key]= {key}";
            string sqlUpdate = $"update Table_Book set Quantity = Quantity + " +
                $"{int.Parse(dgv.CurrentRow.Cells[6].Value.ToString())} where bookID = '{dgv.CurrentRow.Cells[3].Value.ToString()}'";
            if (dao.Execute(sqlUpdate) + dao.Execute(sqlDelete) >= 2)
            {
                dao.DaoClose();
                MessageBox.Show("归还成功","消息",MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBorrowInfo();
                

            }
            else
            {
                dao.DaoClose();
                MessageBox.Show("归还失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

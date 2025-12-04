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
    public partial class FormCheckBorrow : Form
    {
        public FormCheckBorrow()
        {
            InitializeComponent();
        }

        private void LoadBorrowInfo()
        {
            dgv.Rows.Clear();
            Dao dao = new Dao();
            dao.connect();
            string sql = $"select * from Table_Borrow ";
            SqlDataReader reader = dao.read(sql);

            while (reader.Read())
            {
                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());

            }
            reader.Close();
            dao.DaoClose();
        }
        private void FormCheckBorrow_Load(object sender, EventArgs e)
        {
            LoadBorrowInfo();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyWords.Text.Trim();
            Dao dao = new Dao();
            dao.connect();
            string sql = $"select * from Table_Borrow where bookName like '%{keyword}%' or Name like '%{keyword}%'";
            dgv.Rows.Clear();
            SqlDataReader reader = dao.read(sql);
            while (reader.Read())
            {
                dgv.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString());
            }
            reader.Close();
            dao.DaoClose();

        }
    }
}

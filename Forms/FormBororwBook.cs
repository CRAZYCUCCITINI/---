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
    public partial class FormBororwBook : Form
    {
        public FormBororwBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = dgv.CurrentRow.Cells[1].Value.ToString();
            string id = dgv.CurrentRow.Cells[0].Value.ToString();
            int count = int.Parse(cobCount.Text);
            DateTime date = DateTime.Now;
            

            Dao dao = new Dao();
            dao.connect();
            

            //判断库存是否充足

            string sqlFlag = $"select bookID from Table_Book where Quantity >= '{count}' and bookID = {id}";
            SqlDataReader reader1 = dao.read(sqlFlag);
            if (!reader1.Read())
            {
                MessageBox.Show("库存不足!","消息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                reader1.Close();
                dao.DaoClose();
                return;
            }

            string sqlInsert = $"insert into Table_Borrow (UserAccount, Name, bookID, bookName, Date, Count) values ('{FormStart.acc}','{FormStart.name}','{id}','{name}','{date}','{count}')";
            string sqlUpdate = $"update Table_Book set Quantity = Quantity-{count},RentNum = RentNum + {count} where bookID = '{id}'";
            if(dao.Execute(sqlInsert) + dao.Execute(sqlUpdate) >= 2)
            {
                dao.DaoClose();
                MessageBox.Show("借书成功","消息",MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBook();
            }
            else
            {
                dao.DaoClose() ;
                MessageBox.Show("租借失败！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }


        private void LoadBook()
        {
            dgv.Rows.Clear();
            Dao dao = new Dao();
            dao.connect();
            string sql = "select * from Table_Book";
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
        private void FormBororwBook_Load(object sender, EventArgs e)
        {
            LoadBook();
            cobCount.Text = "1";
            if(dgv.Rows.Count == 1)
            {
                ;
            }
            else
            {
                lblName.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            }
               
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.CurrentRow== null || dgv.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("选中无效数据","消息",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lblName.Text = dgv.CurrentRow.Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }
    }
}

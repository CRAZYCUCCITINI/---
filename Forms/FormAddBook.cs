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
    public partial class FormAddBook : Form
    {
        public FormAddBook()
        {
            InitializeComponent();
        }

        private void FormAddBook_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“bookMSDataSet.Table_BookType”中。您可以根据需要移动或移除它。
            //this.table_BookTypeTableAdapter.Fill(this.bookMSDataSet.Table_BookType);
            Dao dao = new Dao();
            List<dynamic> bookTypes = new List<dynamic>();

            try
            {
                // 1. 添加默认的"请选择"选项
                /*bookTypes.Add(new
                {
                    Value = (string)"0",  // 确保类型与数据库一致
                    Display = "请选择图书类型"
                });*/

                // 2. SQL查询
                string sql = "SELECT TypeID, Type FROM Table_BookType ORDER BY Type;";

                // 3. 执行查询
                using (SqlDataReader reader = dao.read(sql))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // 获取当前行的值
                            string typeId = reader["TypeID"].ToString();
                            string typeName = reader["Type"].ToString();

                            bookTypes.Add(new
                            {
                                Value = typeId,
                                Display = typeName
                            });
                        }
                    }
                    // using语句会自动关闭reader，不需要手动reader.Close()
                }

                // 4. 绑定到下拉框
                cobType.DataSource = bookTypes;
                cobType.DisplayMember = "Display";
                cobType.ValueMember = "Value";
                cobType.SelectedIndex = 0;  // 默认选中"请选择"
            }
            catch (Exception ex)
            {
                MessageBox.Show($"图书类型加载失败：{ex.Message}", "错误",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dao.DaoClose();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtBookID.Text.Trim()==""||txtAuthor.Text.Trim()==""||txtBookName.Text.Trim()==""||
                txtPress.Text.Trim() == "" || TxtQuantity.Text.Trim() == "")
            {
                MessageBox.Show("有空项","消息",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            Dao dao = new Dao();
            dao.connect();

            string sqlCheck = $"SELECT bookID FROM Table_Book WHERE bookID = '{txtBookID.Text}'";
            SqlDataReader reader = dao.read(sqlCheck);
            // 若reader能读取到数据，说明账号存在

            bool exists = reader.Read();
            if (exists)
            {
                MessageBox.Show("图书编号已存在", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dao.DaoClose();
                return;
            }
            else
            {
                string sql = $"insert into Table_Book values ('{txtBookID.Text}','{txtBookName.Text}'," +
                $"'{txtAuthor.Text}','{txtPress.Text}','{dTPub.Value}','{cobType.Text}','{int.Parse(TxtQuantity.Text)}','0')";
                try
                {
                    if (dao.Execute(sql) > 0)
                    {
                        dao.DaoClose();
                        MessageBox.Show("添加成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        dao.DaoClose();
                        MessageBox.Show("添加失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                catch
                {
                    dao.DaoClose();
                    MessageBox.Show("ERROR", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
            }
            
        }

        private void cobType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

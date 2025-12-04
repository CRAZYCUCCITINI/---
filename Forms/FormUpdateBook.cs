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
    public partial class FormUpdateBook : Form
    {
        public FormUpdateBook()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void FormUpdateBook_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“bookMSDataSet1.Table_BookType”中。您可以根据需要移动或移除它。
            //this.table_BookTypeTableAdapter.Fill(this.bookMSDataSet1.Table_BookType);
            Dao dao = new Dao();
            List<dynamic> bookTypes = new List<dynamic>();

            try
            {
                // 1. 添加默认的"请选择"选项
                //bookTypes.Add(new
                //{
                //    Value = (string)"0",  // 确保类型与数据库一致
                 //   Display = "请选择图书类型"
                //});

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
            txtAuthor.Text = FormManage.author;
            txtID.Text = FormManage.bid;
            txtName.Text = FormManage.bname;
            txtPress.Text = FormManage.press;
            dtPub.Value = DateTime.Parse(FormManage.pubdate);
            txtQuantity.Text = FormManage.quantity.ToString();
            cobType.Text = FormManage.type;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text==""||txtName.Text==""||txtAuthor.Text==""||txtPress.Text==""||cobType.Text==""||txtQuantity.Text==""||dtPub.Text=="")
            {
                MessageBox.Show("有空项","消息",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            Dao dao = new Dao();
            dao.connect();

            string sqlCheck = $"SELECT bookID FROM Table_Book WHERE bookID = '{txtID.Text}'";
            SqlDataReader reader = dao.read(sqlCheck);
            // 若reader能读取到数据，说明账号存在

            bool exists = reader.Read();
            if (exists && txtID.Text != FormManage.bid)
            {
                MessageBox.Show("图书编号已存在", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reader.Close();
                dao.DaoClose();
                return;
            }

            else
            {


                string sql = $"update Table_Book set bookID ='{txtID.Text}',bookName = '{txtName.Text}'," +
                    $"Author = '{txtAuthor.Text}',Press = '{txtPress.Text}',type = '{cobType.Text}', " +
                    $"Quantity = '{int.Parse(txtQuantity.Text)}', PublishDate = '{dtPub.Value}' where bookID = '{FormManage.bid}'";
                if (dao.Execute(sql) > 0)
                {
                    reader.Close();
                    dao.DaoClose();
                    MessageBox.Show("修改成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    reader.Close();
                    dao.DaoClose();
                    MessageBox.Show("修改失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cobType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

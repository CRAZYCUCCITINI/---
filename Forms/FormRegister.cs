using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            //判断文本框是否为空
            if (txtAccount.Text == "" || txtID.Text == "" || txtName.Text == "" || txtPassword.Text == ""
                || txtTel.Text == "" || cobSex.Text == "")
            {
                MessageBox.Show("有空项", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Dao dao = new Dao();
            dao.connect();

            string account = txtAccount.Text;
            string id = txtID.Text;
            string name = txtName.Text;
            string password = txtPassword.Text;
            string phone = txtTel.Text;
            string sex = cobSex.Text;
            string type = cobType.Text;

            string sqlCheck = $"SELECT UserAccount FROM Table_User WHERE UserAccount = '{account}'";
            SqlDataReader reader = dao.read(sqlCheck);
            // 若reader能读取到数据，说明账号存在
            bool exists = reader.Read();
            if (exists)
            {
                MessageBox.Show("账号已存在", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dao.DaoClose();
                return;
            }
            else
            {
                //添加
                string sql = $"insert into Table_User values('{account}','{password}'," +
                    $"'{name}','{type}','{sex}','{id}','{phone}','1')";
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("注册成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                dao.DaoClose();
            }
            reader.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“bookMSDataSet2.Table_UserType”中。您可以根据需要移动或移除它。
            //this.table_UserTypeTableAdapter.Fill(this.bookMSDataSet2.Table_UserType);
            Dao dao = new Dao();
            List<dynamic> bookTypes = new List<dynamic>();

            try
            {
                
             

                // 2. SQL查询
                string sql = "SELECT TypeID, Type FROM Table_UserType ORDER BY Type;";

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

        private void txtType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

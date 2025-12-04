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
    public partial class FormUpdateUser : Form
    {
        public FormUpdateUser()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUpdateUser_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“bookMSDataSet3.Table_UserType”中。您可以根据需要移动或移除它。
            //this.table_UserTypeTableAdapter.Fill(this.bookMSDataSet3.Table_UserType);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtName.Text == "" || cobType.Text == "" || cobSex.Text == "" ||  txtID.Text == "" || txtTel.Text == "")
            {
                MessageBox.Show("有空项", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Dao dao = new Dao();
            dao.connect();
            string sql = $"UPDATE Table_User SET Name = '{txtName.Text}',  Occupation = '{cobType.Text}', Sex = '{cobSex.Text}',   ID = '{txtID.Text}',  Tel = '{txtTel.Text}'WHERE UserAccount = '{FormManageUser.acc}'";
            if (dao.Execute(sql) > 0)
            {
                dao.DaoClose();
                MessageBox.Show("修改成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {
                dao.DaoClose();
                MessageBox.Show("修改失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cobType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

namespace BookManageSystem
{
    partial class FormUpdateUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cobType = new System.Windows.Forms.ComboBox();
            this.tableUserTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.bookMSDataSet3 = new BookManageSystem.BookMSDataSet3();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lable2 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            //this.table_UserTypeTableAdapter = new BookManageSystem.BookMSDataSet3TableAdapters.Table_UserTypeTableAdapter();
            this.cobSex = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tableUserTypeBindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.bookMSDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // cobType
            // 
            this.cobType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobType.FormattingEnabled = true;
            this.cobType.Location = new System.Drawing.Point(783, 106);
            this.cobType.Name = "cobType";
            this.cobType.Size = new System.Drawing.Size(384, 39);
            this.cobType.TabIndex = 34;
            this.cobType.SelectedIndexChanged += new System.EventHandler(this.cobType_SelectedIndexChanged);
            // 
            // tableUserTypeBindingSource
            // 
            this.tableUserTypeBindingSource.DataMember = "Table_UserType";
            //this.tableUserTypeBindingSource.DataSource = this.bookMSDataSet3;
            // 
            // bookMSDataSet3
            // 
            //this.bookMSDataSet3.DataSetName = "BookMSDataSet3";
            //this.bookMSDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.Location = new System.Drawing.Point(286, 391);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(121, 58);
            this.btnUpdate.TabIndex = 33;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(825, 391);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 58);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtID.Location = new System.Drawing.Point(783, 189);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(384, 39);
            this.txtID.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(667, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 31);
            this.label7.TabIndex = 29;
            this.label7.Text = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(667, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 31);
            this.label5.TabIndex = 28;
            this.label5.Text = "类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(68, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 31);
            this.label3.TabIndex = 25;
            this.label3.Text = "性别";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(184, 106);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(384, 39);
            this.txtName.TabIndex = 22;
            // 
            // lable2
            // 
            this.lable2.AutoSize = true;
            this.lable2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable2.Location = new System.Drawing.Point(68, 109);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(62, 31);
            this.lable2.TabIndex = 21;
            this.lable2.Text = "姓名";
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTel.Location = new System.Drawing.Point(184, 278);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(384, 39);
            this.txtTel.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(68, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 31);
            this.label1.TabIndex = 35;
            this.label1.Text = "电话";
            // 
            // table_UserTypeTableAdapter
            // 
            //this.table_UserTypeTableAdapter.ClearBeforeFill = true;
            // 
            // cobSex
            // 
            this.cobSex.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobSex.FormattingEnabled = true;
            this.cobSex.Items.AddRange(new object[] {
            "F",
            "M"});
            this.cobSex.Location = new System.Drawing.Point(184, 189);
            this.cobSex.Name = "cobSex";
            this.cobSex.Size = new System.Drawing.Size(384, 39);
            this.cobSex.TabIndex = 37;
            // 
            // FormUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 514);
            this.Controls.Add(this.cobSex);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cobType);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lable2);
            this.Name = "FormUpdateUser";
            this.Text = "FormUpdateUser";
            this.Load += new System.EventHandler(this.FormUpdateUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableUserTypeBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.bookMSDataSet3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cobType;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lable2;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label1;
        //private BookMSDataSet3 bookMSDataSet3;
        private System.Windows.Forms.BindingSource tableUserTypeBindingSource;
        //private BookMSDataSet3TableAdapters.Table_UserTypeTableAdapter table_UserTypeTableAdapter;
        private System.Windows.Forms.ComboBox cobSex;
    }
}
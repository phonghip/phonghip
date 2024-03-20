namespace Assignment.FormLeader
{
    partial class Team
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
            btnDelete = new Button();
            btnCreate = new Button();
            txtSearch = new TextBox();
            dgvUser = new DataGridView();
            lblUser = new Label();
            btnUpdate = new Button();
            btnTask = new Button();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label2 = new Label();
            rdLeader = new RadioButton();
            rdMember = new RadioButton();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label1 = new Label();
            label3 = new Label();
            cboFilter = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvUser).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(446, 304);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(123, 27);
            btnDelete.TabIndex = 34;
            btnDelete.Text = "Delete user";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(237, 506);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(123, 27);
            btnCreate.TabIndex = 32;
            btnCreate.Text = "Create mode";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(399, 46);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search username";
            txtSearch.Size = new Size(170, 23);
            txtSearch.TabIndex = 29;
            txtSearch.TextChanged += cboFilter_SelectedIndexChanged;
            // 
            // dgvUser
            // 
            dgvUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUser.Location = new Point(11, 75);
            dgvUser.MultiSelect = false;
            dgvUser.Name = "dgvUser";
            dgvUser.ReadOnly = true;
            dgvUser.RowTemplate.Height = 25;
            dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUser.Size = new Size(558, 223);
            dgvUser.TabIndex = 28;
            dgvUser.SelectionChanged += dgvUser_SelectionChanged;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUser.Location = new Point(41, 22);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(81, 18);
            lblUser.TabIndex = 27;
            lblUser.Text = "Welcome";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(117, 506);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(102, 27);
            btnUpdate.TabIndex = 35;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnTask
            // 
            btnTask.Location = new Point(376, 506);
            btnTask.Name = "btnTask";
            btnTask.Size = new Size(85, 27);
            btnTask.TabIndex = 36;
            btnTask.Text = "Back to tasks";
            btnTask.UseVisualStyleBackColor = true;
            btnTask.Click += btnTask_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(rdLeader);
            groupBox1.Controls.Add(rdMember);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(13, 348);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(557, 132);
            groupBox1.TabIndex = 42;
            groupBox1.TabStop = false;
            groupBox1.Text = "User details";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(187, 89);
            label4.Name = "label4";
            label4.Size = new Size(35, 17);
            label4.TabIndex = 45;
            label4.Text = "Role";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(288, 42);
            label2.Name = "label2";
            label2.Size = new Size(66, 17);
            label2.TabIndex = 44;
            label2.Text = "Password";
            // 
            // rdLeader
            // 
            rdLeader.AutoSize = true;
            rdLeader.Location = new Point(304, 87);
            rdLeader.Name = "rdLeader";
            rdLeader.Size = new Size(60, 19);
            rdLeader.TabIndex = 43;
            rdLeader.TabStop = true;
            rdLeader.Text = "Leader";
            rdLeader.UseVisualStyleBackColor = true;
            rdLeader.CheckedChanged += enableUpdateCreate;
            // 
            // rdMember
            // 
            rdMember.AutoSize = true;
            rdMember.Location = new Point(228, 87);
            rdMember.Name = "rdMember";
            rdMember.Size = new Size(70, 19);
            rdMember.TabIndex = 42;
            rdMember.TabStop = true;
            rdMember.Text = "Member";
            rdMember.UseVisualStyleBackColor = true;
            rdMember.CheckedChanged += enableUpdateCreate;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(363, 41);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(127, 23);
            txtPassword.TabIndex = 41;
            txtPassword.TextChanged += enableUpdateCreate;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(115, 41);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(125, 23);
            txtUsername.TabIndex = 40;
            txtUsername.TextChanged += enableUpdateCreate;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(40, 42);
            label1.Name = "label1";
            label1.Size = new Size(69, 17);
            label1.TabIndex = 37;
            label1.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(225, 49);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 44;
            label3.Text = "Filter :";
            // 
            // cboFilter
            // 
            cboFilter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cboFilter.FormattingEnabled = true;
            cboFilter.Items.AddRange(new object[] { "Member", "Leader", "Free", "None" });
            cboFilter.Location = new Point(269, 46);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(121, 23);
            cboFilter.TabIndex = 43;
            cboFilter.Text = "Filter";
            cboFilter.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // Team
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 545);
            Controls.Add(label3);
            Controls.Add(cboFilter);
            Controls.Add(btnTask);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnCreate);
            Controls.Add(txtSearch);
            Controls.Add(dgvUser);
            Controls.Add(lblUser);
            Controls.Add(groupBox1);
            Name = "Team";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Team Manager";
            Load += Team_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUser).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDelete;
        private Button btnCreate;
        private TextBox txtSearch;
        private DataGridView dgvUser;
        private Label lblUser;
        private Button btnUpdate;
        private Button btnTask;
        private GroupBox groupBox1;
        private Label label4;
        private Label label2;
        private RadioButton rdLeader;
        private RadioButton rdMember;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label1;
        private Label label3;
        private ComboBox cboFilter;
    }
}
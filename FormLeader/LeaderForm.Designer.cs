namespace Assignment.FormLeader
{
    partial class LeaderForm
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
            cboFilter = new ComboBox();
            txtSearch = new TextBox();
            dgvTask = new DataGridView();
            lblUser = new Label();
            label1 = new Label();
            btnLogout = new Button();
            btnStatus = new Button();
            btnCommentList = new Button();
            rtxtComment = new RichTextBox();
            lblComment = new Label();
            btnComment = new Button();
            btnCreateTask = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnTeam = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTask).BeginInit();
            SuspendLayout();
            // 
            // cboFilter
            // 
            cboFilter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cboFilter.FormattingEnabled = true;
            cboFilter.Items.AddRange(new object[] { "Your Task", "Completed Task", "Unfinished Task", "None" });
            cboFilter.Location = new Point(543, 51);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(121, 23);
            cboFilter.TabIndex = 14;
            cboFilter.Text = "Filter";
            cboFilter.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(696, 51);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search task's title";
            txtSearch.Size = new Size(170, 23);
            txtSearch.TabIndex = 13;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvTask
            // 
            dgvTask.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTask.Location = new Point(12, 80);
            dgvTask.MultiSelect = false;
            dgvTask.Name = "dgvTask";
            dgvTask.ReadOnly = true;
            dgvTask.RowTemplate.Height = 25;
            dgvTask.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTask.Size = new Size(854, 223);
            dgvTask.TabIndex = 12;
            dgvTask.SelectionChanged += dgvTask_SelectionChanged;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUser.Location = new Point(136, 34);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(81, 18);
            lblUser.TabIndex = 11;
            lblUser.Text = "Welcome";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(499, 54);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 15;
            label1.Text = "Filter :";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom;
            btnLogout.Location = new Point(512, 509);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(86, 27);
            btnLogout.TabIndex = 16;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnStatus
            // 
            btnStatus.Anchor = AnchorStyles.Bottom;
            btnStatus.Location = new Point(248, 509);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(123, 27);
            btnStatus.TabIndex = 17;
            btnStatus.Text = "Mark as Done";
            btnStatus.UseVisualStyleBackColor = true;
            btnStatus.Click += btnStatus_Click;
            // 
            // btnCommentList
            // 
            btnCommentList.Location = new Point(53, 490);
            btnCommentList.Name = "btnCommentList";
            btnCommentList.Size = new Size(86, 27);
            btnCommentList.TabIndex = 23;
            btnCommentList.Text = "List";
            btnCommentList.UseVisualStyleBackColor = true;
            btnCommentList.Click += btnCommentList_Click;
            // 
            // rtxtComment
            // 
            rtxtComment.Location = new Point(53, 388);
            rtxtComment.Name = "rtxtComment";
            rtxtComment.Size = new Size(765, 96);
            rtxtComment.TabIndex = 21;
            rtxtComment.Text = "";
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblComment.Location = new Point(53, 365);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(150, 20);
            lblComment.TabIndex = 20;
            lblComment.Text = "Comment on the task";
            // 
            // btnComment
            // 
            btnComment.Location = new Point(732, 490);
            btnComment.Name = "btnComment";
            btnComment.Size = new Size(86, 27);
            btnComment.TabIndex = 19;
            btnComment.Text = "Submit";
            btnComment.UseVisualStyleBackColor = true;
            btnComment.Click += btnComment_Click;
            // 
            // btnCreateTask
            // 
            btnCreateTask.Location = new Point(743, 309);
            btnCreateTask.Name = "btnCreateTask";
            btnCreateTask.Size = new Size(123, 27);
            btnCreateTask.TabIndex = 24;
            btnCreateTask.Text = "Create new Task";
            btnCreateTask.UseVisualStyleBackColor = true;
            btnCreateTask.Click += btnCreateTask_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(612, 309);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(123, 27);
            btnEdit.TabIndex = 25;
            btnEdit.Text = "Edit Task";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 309);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(123, 27);
            btnDelete.TabIndex = 26;
            btnDelete.Text = "Delete Task";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnTeam
            // 
            btnTeam.Anchor = AnchorStyles.Bottom;
            btnTeam.Location = new Point(392, 510);
            btnTeam.Name = "btnTeam";
            btnTeam.Size = new Size(101, 27);
            btnTeam.TabIndex = 27;
            btnTeam.Text = "Manage team";
            btnTeam.UseVisualStyleBackColor = true;
            btnTeam.Click += btnTeam_Click;
            // 
            // LeaderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 549);
            Controls.Add(btnTeam);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnCreateTask);
            Controls.Add(btnCommentList);
            Controls.Add(rtxtComment);
            Controls.Add(lblComment);
            Controls.Add(btnComment);
            Controls.Add(btnLogout);
            Controls.Add(btnStatus);
            Controls.Add(label1);
            Controls.Add(cboFilter);
            Controls.Add(txtSearch);
            Controls.Add(dgvTask);
            Controls.Add(lblUser);
            MinimumSize = new Size(894, 588);
            Name = "LeaderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Task Management - Leader View";
            Load += LeaderForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTask).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboFilter;
        private TextBox txtSearch;
        private DataGridView dgvTask;
        private Label lblUser;
        private Label label1;
        private Button btnLogout;
        private Button btnStatus;
        private Button btnCommentList;
        private RichTextBox rtxtComment;
        private Label lblComment;
        private Button btnComment;
        private Button btnCreateTask;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnTeam;
    }
}
namespace Assignment.FormMember
{
    partial class MemberTask
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
            components = new System.ComponentModel.Container();
            lblUser = new Label();
            dgvTask = new DataGridView();
            taskBindingSource = new BindingSource(components);
            txtSearch = new TextBox();
            btnLogout = new Button();
            btnComment = new Button();
            lblComment = new Label();
            rtxtComment = new RichTextBox();
            btnStatus = new Button();
            btnCommentList = new Button();
            cboFilter = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTask).BeginInit();
            ((System.ComponentModel.ISupportInitialize)taskBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Lucida Bright", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUser.Location = new Point(136, 33);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(81, 18);
            lblUser.TabIndex = 0;
            lblUser.Text = "Welcome";
            // 
            // dgvTask
            // 
            dgvTask.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTask.Location = new Point(12, 79);
            dgvTask.MultiSelect = false;
            dgvTask.Name = "dgvTask";
            dgvTask.ReadOnly = true;
            dgvTask.RowTemplate.Height = 25;
            dgvTask.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTask.Size = new Size(854, 223);
            dgvTask.TabIndex = 1;
            dgvTask.SelectionChanged += dgvTask_SelectionChanged;
            // 
            // taskBindingSource
            // 
            taskBindingSource.DataSource = typeof(Task);
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(696, 50);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search task's title";
            txtSearch.Size = new Size(170, 23);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom;
            btnLogout.Location = new Point(466, 474);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(86, 27);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnComment
            // 
            btnComment.Location = new Point(739, 454);
            btnComment.Name = "btnComment";
            btnComment.Size = new Size(86, 27);
            btnComment.TabIndex = 6;
            btnComment.Text = "Submit";
            btnComment.UseVisualStyleBackColor = true;
            btnComment.Click += btnComment_Click;
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblComment.Location = new Point(60, 329);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(150, 20);
            lblComment.TabIndex = 7;
            lblComment.Text = "Comment on the task";
            // 
            // rtxtComment
            // 
            rtxtComment.Location = new Point(60, 352);
            rtxtComment.Name = "rtxtComment";
            rtxtComment.Size = new Size(765, 96);
            rtxtComment.TabIndex = 8;
            rtxtComment.Text = "";
            // 
            // btnStatus
            // 
            btnStatus.Anchor = AnchorStyles.Bottom;
            btnStatus.Location = new Point(305, 474);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(123, 27);
            btnStatus.TabIndex = 9;
            btnStatus.Text = "Mark as Done";
            btnStatus.UseVisualStyleBackColor = true;
            btnStatus.Click += btnStatus_Click;
            // 
            // btnCommentList
            // 
            btnCommentList.Location = new Point(60, 454);
            btnCommentList.Name = "btnCommentList";
            btnCommentList.Size = new Size(86, 27);
            btnCommentList.TabIndex = 11;
            btnCommentList.Text = "List";
            btnCommentList.UseVisualStyleBackColor = true;
            btnCommentList.Click += btnCommentList_Click;
            // 
            // cboFilter
            // 
            cboFilter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cboFilter.FormattingEnabled = true;
            cboFilter.Items.AddRange(new object[] { "Your Task", "Completed Task", "Unfinished Task", "None" });
            cboFilter.Location = new Point(543, 50);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(121, 23);
            cboFilter.TabIndex = 4;
            cboFilter.Text = "Filter";
            cboFilter.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(496, 53);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 10;
            label1.Text = "Filter :";
            // 
            // MemberTask
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 513);
            Controls.Add(btnCommentList);
            Controls.Add(label1);
            Controls.Add(btnLogout);
            Controls.Add(btnStatus);
            Controls.Add(rtxtComment);
            Controls.Add(lblComment);
            Controls.Add(btnComment);
            Controls.Add(cboFilter);
            Controls.Add(txtSearch);
            Controls.Add(dgvTask);
            Controls.Add(lblUser);
            MaximizeBox = false;
            MaximumSize = new Size(894, 552);
            Name = "MemberTask";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Task Management - Member View";
            Load += MemberTask_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTask).EndInit();
            ((System.ComponentModel.ISupportInitialize)taskBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUser;
        private DataGridView dgvTask;
        private TextBox txtSearch;
        private Button btnLogout;
        private BindingSource taskBindingSource;
        private Button btnComment;
        private Label lblComment;
        private RichTextBox rtxtComment;
        private Button btnStatus;
        private Button btnCommentList;
        private ComboBox cboFilter;
        private Label label1;
    }
}
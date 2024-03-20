namespace Assignment.FormMember
{
    partial class CommentList
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
            dgvComment = new DataGridView();
            label2 = new Label();
            lblTask = new Label();
            btnDelete = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvComment).BeginInit();
            SuspendLayout();
            // 
            // dgvComment
            // 
            dgvComment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComment.Location = new Point(12, 77);
            dgvComment.MultiSelect = false;
            dgvComment.Name = "dgvComment";
            dgvComment.ReadOnly = true;
            dgvComment.RowTemplate.Height = 25;
            dgvComment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvComment.Size = new Size(776, 227);
            dgvComment.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(265, 26);
            label2.Name = "label2";
            label2.Size = new Size(125, 22);
            label2.TabIndex = 2;
            label2.Text = "Viewing Task:";
            // 
            // lblTask
            // 
            lblTask.AutoSize = true;
            lblTask.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTask.Location = new Point(396, 26);
            lblTask.Name = "lblTask";
            lblTask.Size = new Size(23, 22);
            lblTask.TabIndex = 3;
            lblTask.Text = "U";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(307, 330);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(85, 25);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(425, 332);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // CommentList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 378);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(lblTask);
            Controls.Add(label2);
            Controls.Add(dgvComment);
            Name = "CommentList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Your Comment List";
            Load += CommentList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvComment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvComment;
        private Label label2;
        private Label lblTask;
        private Button btnDelete;
        private Button btnClose;
    }
}
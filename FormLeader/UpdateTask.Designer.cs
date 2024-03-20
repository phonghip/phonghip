namespace Assignment.FormLeader
{
    partial class UpdateTask
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtTitle = new TextBox();
            rtxtDescription = new RichTextBox();
            dateDueDate = new DateTimePicker();
            cbStatus = new CheckBox();
            cboAssignee = new ComboBox();
            lblTask = new Label();
            label6 = new Label();
            btnUpdate = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(79, 119);
            label1.Name = "label1";
            label1.Size = new Size(48, 22);
            label1.TabIndex = 0;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(79, 177);
            label2.Name = "label2";
            label2.Size = new Size(104, 22);
            label2.TabIndex = 1;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(79, 337);
            label3.Name = "label3";
            label3.Size = new Size(87, 22);
            label3.TabIndex = 2;
            label3.Text = "Due Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(79, 399);
            label4.Name = "label4";
            label4.Size = new Size(160, 22);
            label4.TabIndex = 3;
            label4.Text = "Completion Status";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(79, 464);
            label5.Name = "label5";
            label5.Size = new Size(82, 22);
            label5.TabIndex = 4;
            label5.Text = "Assignee";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(249, 117);
            txtTitle.Margin = new Padding(3, 4, 3, 4);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Task's title";
            txtTitle.Size = new Size(172, 27);
            txtTitle.TabIndex = 5;
            txtTitle.TextChanged += enableUpdate;
            // 
            // rtxtDescription
            // 
            rtxtDescription.Location = new Point(249, 177);
            rtxtDescription.Margin = new Padding(3, 4, 3, 4);
            rtxtDescription.MaximumSize = new Size(348, 127);
            rtxtDescription.MinimumSize = new Size(348, 127);
            rtxtDescription.Name = "rtxtDescription";
            rtxtDescription.Size = new Size(348, 127);
            rtxtDescription.TabIndex = 6;
            rtxtDescription.Text = "";
            rtxtDescription.TextChanged += enableUpdate;
            // 
            // dateDueDate
            // 
            dateDueDate.Location = new Point(249, 332);
            dateDueDate.Margin = new Padding(3, 4, 3, 4);
            dateDueDate.MinDate = new DateTime(2023, 7, 21, 0, 0, 0, 0);
            dateDueDate.Name = "dateDueDate";
            dateDueDate.Size = new Size(228, 27);
            dateDueDate.TabIndex = 7;
            dateDueDate.ValueChanged += enableUpdate;
            // 
            // cbStatus
            // 
            cbStatus.AutoSize = true;
            cbStatus.Location = new Point(249, 400);
            cbStatus.Margin = new Padding(3, 4, 3, 4);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(85, 24);
            cbStatus.TabIndex = 8;
            cbStatus.Text = "Finished";
            cbStatus.UseVisualStyleBackColor = true;
            // 
            // cboAssignee
            // 
            cboAssignee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboAssignee.FormattingEnabled = true;
            cboAssignee.Location = new Point(249, 463);
            cboAssignee.Margin = new Padding(3, 4, 3, 4);
            cboAssignee.MaxDropDownItems = 10;
            cboAssignee.Name = "cboAssignee";
            cboAssignee.Size = new Size(279, 28);
            cboAssignee.TabIndex = 9;
            cboAssignee.SelectedIndexChanged += enableUpdate;
            // 
            // lblTask
            // 
            lblTask.AutoSize = true;
            lblTask.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTask.Location = new Point(319, 35);
            lblTask.Name = "lblTask";
            lblTask.Size = new Size(29, 26);
            lblTask.TabIndex = 11;
            lblTask.Text = "U";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(249, 35);
            label6.Name = "label6";
            label6.Size = new Size(67, 26);
            label6.TabIndex = 10;
            label6.Text = "Task:";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(176, 557);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(99, 40);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(350, 557);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(99, 40);
            btnClose.TabIndex = 13;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // UpdateTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(641, 635);
            Controls.Add(btnClose);
            Controls.Add(btnUpdate);
            Controls.Add(lblTask);
            Controls.Add(label6);
            Controls.Add(cboAssignee);
            Controls.Add(cbStatus);
            Controls.Add(dateDueDate);
            Controls.Add(rtxtDescription);
            Controls.Add(txtTitle);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(657, 671);
            Name = "UpdateTask";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Update Task";
            Load += UpdateTask_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtTitle;
        private RichTextBox rtxtDescription;
        private DateTimePicker dateDueDate;
        private CheckBox cbStatus;
        private ComboBox cboAssignee;
        private Label lblTask;
        private Label label6;
        private Button btnUpdate;
        private Button btnClose;
    }
}
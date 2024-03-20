namespace Assignment.FormLeader
{
    partial class AddTask
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
            btnClose = new Button();
            btnCreate = new Button();
            cboAssignee = new ComboBox();
            cbStatus = new CheckBox();
            dateDueDate = new DateTimePicker();
            rtxtDescription = new RichTextBox();
            txtTitle = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(298, 390);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(87, 30);
            btnClose.TabIndex = 27;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(146, 390);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(87, 30);
            btnCreate.TabIndex = 26;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // cboAssignee
            // 
            cboAssignee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboAssignee.FormattingEnabled = true;
            cboAssignee.Location = new Point(202, 332);
            cboAssignee.MaxDropDownItems = 10;
            cboAssignee.Name = "cboAssignee";
            cboAssignee.Size = new Size(245, 23);
            cboAssignee.Sorted = true;
            cboAssignee.TabIndex = 23;
            cboAssignee.SelectedIndexChanged += enableCreate;
            // 
            // cbStatus
            // 
            cbStatus.AutoSize = true;
            cbStatus.Location = new Point(202, 285);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(70, 19);
            cbStatus.TabIndex = 22;
            cbStatus.Text = "Finished";
            cbStatus.UseVisualStyleBackColor = true;
            // 
            // dateDueDate
            // 
            dateDueDate.Location = new Point(202, 234);
            dateDueDate.MinDate = new DateTime(2023, 7, 21, 0, 0, 0, 0);
            dateDueDate.Name = "dateDueDate";
            dateDueDate.Size = new Size(200, 23);
            dateDueDate.TabIndex = 21;
            dateDueDate.ValueChanged += enableCreate;
            // 
            // rtxtDescription
            // 
            rtxtDescription.Location = new Point(202, 118);
            rtxtDescription.MaximumSize = new Size(305, 96);
            rtxtDescription.MinimumSize = new Size(305, 96);
            rtxtDescription.Name = "rtxtDescription";
            rtxtDescription.Size = new Size(305, 96);
            rtxtDescription.TabIndex = 20;
            rtxtDescription.Text = "";
            rtxtDescription.TextChanged += enableCreate;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(202, 73);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Task's title";
            txtTitle.Size = new Size(151, 23);
            txtTitle.TabIndex = 19;
            txtTitle.TextChanged += enableCreate;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(53, 333);
            label5.Name = "label5";
            label5.Size = new Size(69, 17);
            label5.TabIndex = 18;
            label5.Text = "Assignee";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(53, 284);
            label4.Name = "label4";
            label4.Size = new Size(128, 17);
            label4.TabIndex = 17;
            label4.Text = "Completion Status";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(53, 238);
            label3.Name = "label3";
            label3.Size = new Size(70, 17);
            label3.TabIndex = 16;
            label3.Text = "Due Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(53, 118);
            label2.Name = "label2";
            label2.Size = new Size(84, 17);
            label2.TabIndex = 15;
            label2.Text = "Description";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(53, 74);
            label1.Name = "label1";
            label1.Size = new Size(39, 17);
            label1.TabIndex = 14;
            label1.Text = "Title";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(186, 19);
            label6.Name = "label6";
            label6.Size = new Size(144, 22);
            label6.TabIndex = 24;
            label6.Text = "Create new task";
            // 
            // AddTask
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 432);
            Controls.Add(btnClose);
            Controls.Add(btnCreate);
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
            Name = "AddTask";
            Text = "Create Task";
            Load += AddTask_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Button btnCreate;
        private ComboBox cboAssignee;
        private CheckBox cbStatus;
        private DateTimePicker dateDueDate;
        private RichTextBox rtxtDescription;
        private TextBox txtTitle;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
    }
}
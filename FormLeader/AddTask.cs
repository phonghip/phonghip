using Assignment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = Assignment.Models.Task;

namespace Assignment.FormLeader
{
    public partial class AddTask : Form
    {
        public delegate void CreateTaskEvent();
        public event CreateTaskEvent? CreateTask;

        public AddTask()
        {
            InitializeComponent();
            dateDueDate.MinDate = DateTime.Now;
        }

        private void enableCreate(object sender, EventArgs e)
        {
            bool allFieldsFilled =
                cboAssignee.SelectedItem != null &&
                !string.IsNullOrEmpty(txtTitle.Text) &&
                !string.IsNullOrEmpty(rtxtDescription.Text) &&
                dateDueDate.Value != null;

            // Enable the "Update" button if all fields are filled
            btnCreate.Enabled = allFieldsFilled;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Dispose();

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Create new task {txtTitle.Text} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                using (var context = new TaskManagementContext())
                {
                    var task = new Task()
                    {
                        Title = txtTitle.Text,
                        Description = rtxtDescription.Text,
                        DueDate = dateDueDate.Value,
                        CompletionStatus = cbStatus.Checked,
                        UserId = (int)cboAssignee.SelectedValue
                    };

                    context.Tasks.Add(task);
                    context.SaveChanges();
                }
                CreateTask.Invoke();
            }
        }

        private void AddTask_Load(object sender, EventArgs e)
        {
            using (var context = new TaskManagementContext())
            {
                cboAssignee.DataSource = context.Users.ToList();
                cboAssignee.DisplayMember = "Username";
                cboAssignee.ValueMember = "UserId";
            }
        }
    }
}

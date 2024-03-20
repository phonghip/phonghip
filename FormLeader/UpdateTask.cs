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
    public partial class UpdateTask : Form
    {
        public delegate void TaskUpdateEvent();
        private Task selectedTask;
        public event TaskUpdateEvent TaskUpdate;

        public UpdateTask(Task selectedTask)
        {
            InitializeComponent();
            this.selectedTask = selectedTask;
        }

        private void UpdateTask_Load(object sender, EventArgs e)
        {
            lblTask.Text = selectedTask.Title;
            txtTitle.Text = selectedTask.Title;
            rtxtDescription.Text = selectedTask.Description;
            dateDueDate.Value = selectedTask.DueDate.Value;
            cbStatus.Checked = selectedTask.CompletionStatus.Value;
            using (var context = new TaskManagementContext())
            {
                cboAssignee.DataSource = context.Users.ToList();
                cboAssignee.DisplayMember = "Username";
                cboAssignee.ValueMember = "UserID";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Apply changes to task: {selectedTask.Title} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                using (var context = new TaskManagementContext())
                {
                    var task = context.Tasks.Find(selectedTask.TaskId);
                    task.Title = txtTitle.Text;
                    task.Description = rtxtDescription.Text;
                    task.DueDate = dateDueDate.Value;
                    task.CompletionStatus = cbStatus.Checked;
                    task.UserId = (int)cboAssignee.SelectedValue;
                    context.SaveChanges();
                }

                TaskUpdate.Invoke();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure delete this task?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using (var context = new TaskManagementContext())
                {
                    var task = context.Comments.Find(selectedTask.TaskId);
                    context.Comments.Remove(task);
                    context.SaveChanges();
                }
            }
        }

        private void enableUpdate(object sender, EventArgs e)
        {
            bool allFieldsFilled =
                cboAssignee.SelectedItem != null &&
                !string.IsNullOrEmpty(txtTitle.Text) &&
                !string.IsNullOrEmpty(rtxtDescription.Text) &&
                dateDueDate.Value != null;

            // Enable the "Update" button if all fields are filled
            btnUpdate.Enabled = allFieldsFilled;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Dispose();
    }
}

using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = Assignment.Models.Task;

namespace Assignment.FormMember
{
    public partial class MemberTask : Form
    {
        private User loginUser;
        private BindingSource source;

        public MemberTask(User u)
        {
            InitializeComponent();
            loginUser = u;
            this.FormClosing += MemberTask_FormClosing;
        }

        private void MemberTask_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"Welcome {loginUser.Username}";
            LoadTasks();
            cboFilter.SelectedIndex = 3;
        }

        private void LoadTasks()
        {
            try
            {
                using (var context = new TaskManagementContext())
                {
                    var tasklist = context.Tasks
                                    .Select(task => new
                                    {
                                        task.TaskId,
                                        task.Title,
                                        task.Description,
                                        task.DueDate,
                                        Status = task.CompletionStatus.Value ? "Done" : "In Progress", // Set the status as a string
                                        Assignee = task.User.Username
                                    })
                                    .ToList();

                    DataTable dataTable = new DataTable();
                    dataTable = ToDataTable(tasklist);
                    dataTable.Columns["Status"].DataType = typeof(string);
                    source = new BindingSource();
                    DataView view = new DataView(dataTable);
                    source.DataSource = view;
                    dgvTask.DataSource = source;

                    dgvTask.Columns["TaskId"].Width = 39;
                    dgvTask.Columns["TaskId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvTask.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    dgvTask.Columns["DueDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    dgvTask.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvTask.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvTask.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvTask.Columns["Assignee"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    foreach (DataGridViewColumn column in dgvTask.Columns) { column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tasks: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvTask.ClearSelection();
        }
        private void dgvTask_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTask.SelectedRows.Count == 0)
            {
                HideEdit();
                return;
            }

            var selectedTask = dgvTask.SelectedRows[0];

            if (selectedTask.Cells["Assignee"].Value.Equals(loginUser.Username))
            {
                ShowEdit();
                if (selectedTask.Cells["Status"].Value.Equals("Done")) btnStatus.Text = "Unmark as Done";
                else btnStatus.Text = "Mark as Done";
            }
            else
            {
                HideEdit();
            }
        }
        private void btnCommentList_Click(object sender, EventArgs e)
        {
            if (dgvTask.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please choose a task", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var selectedTask = new Task();
            using (var context = new TaskManagementContext())
            {
                selectedTask = context.Tasks.Find(dgvTask.SelectedRows[0].Cells["TaskId"].Value);
            }
            CommentList newform = new CommentList(selectedTask, loginUser);
            newform.Show();
        }
        private void btnComment_Click(object sender, EventArgs e)
        {
            var selectedTask = dgvTask.SelectedRows[0];
            DialogResult result = MessageBox.Show($"Add comment on task: {selectedTask.Cells["Title"].Value} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (var context = new TaskManagementContext())
                {
                    Comment comment = new Comment()
                    {
                        TaskId = int.Parse(selectedTask.Cells["TaskID"].Value.ToString()),
                        UserId = loginUser.UserId,
                        CommentText = rtxtComment.Text,
                        CommentDate = DateTime.Now
                    };
                    context.Comments.Add(comment);
                    context.SaveChanges();
                    MessageBox.Show("Comment submited!", "Submited", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rtxtComment.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Comment cancelled!", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvTask.ClearSelection();
            ApplyFilter();
        }
        private void ApplyFilter()
        {
            string filter = cboFilter.SelectedItem.ToString();
            string filterHolder = string.Empty;
            string search = $"Title like '%{txtSearch.Text}%'";

            if (filter.Equals("Completed Task")) filterHolder = "Status = 'Done'";
            else if (filter.Equals("Your Task")) filterHolder = $"Assignee = '{loginUser.Username}'";
            else if (filter.Equals("Unfinished Task")) filterHolder = "Status = 'In Progress'";
            else filterHolder = string.Empty;

            source.Filter = string.Join(" AND ", new[] { filterHolder, search }.Where(f => !string.IsNullOrEmpty(f)));
        }
        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (dgvTask.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please choose a task", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var selected = dgvTask.SelectedRows[0];
            string status = "";
            if (selected.Cells["Status"].Value.Equals("Done")) status = "uncomplete";
            else status = "finished";
            DialogResult dr = MessageBox.Show($"Set task's status to {status} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using (TaskManagementContext context = new())
                {
                    var task = context.Tasks.Find(selected.Cells["TaskId"].Value);
                    if (selected.Cells["Status"].Value.Equals("Done")) task.CompletionStatus = false;
                    else task.CompletionStatus = true;
                    context.SaveChanges();
                    LoadTasks();
                }
            }
        }
        private void ShowEdit()
        {
            this.Height = 552;
            btnLogout.Location = new Point(466, 474);
            btnStatus.Enabled = true;
            btnStatus.Visible = true;
            lblComment.Visible = true;
            btnComment.Enabled = true;
            btnCommentList.Enabled = true;
            rtxtComment.Enabled = true;
        }
        private void HideEdit()
        {
            this.Height = 391;
            btnLogout.Location = new Point(401, 313);
            btnStatus.Enabled = false;
            btnStatus.Visible = false;
            lblComment.Visible = false;
            btnComment.Enabled = false;
            btnCommentList.Enabled = false;
            rtxtComment.Enabled = false;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvTask.ClearSelection();
            ApplyFilter();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Dispose(false);
            LoginForm login = new();
            login.Show();
        }
        private void MemberTask_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();
        public DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

    }
}

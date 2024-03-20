using Assignment.FormMember;
using Assignment.Models;
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
using System.Xml;
using Task = Assignment.Models.Task;

namespace Assignment.FormLeader
{
    public partial class LeaderForm : Form
    {
        BindingSource source;
        private User loginUser;

        public LeaderForm(User user)
        {
            this.loginUser = user;
            InitializeComponent();
            this.FormClosing += MemberTask_FormClosing;
        }

        private void LeaderForm_Load(object sender, EventArgs e)
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

        private void btnComment_Click(object sender, EventArgs e)
        {
            if (dgvTask.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please choose a task", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
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

        private void btnEdit_Click(object sender, EventArgs e)
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
            UpdateTask newform = new UpdateTask(selectedTask);
            newform.TaskUpdate += ReloadForm;
            newform.Show();
        }

        private void dgvTask_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTask.SelectedRows.Count != 0)
            {
                var selectedTask = dgvTask.SelectedRows[0];
                if (selectedTask.Cells["Status"].Value.Equals("Done")) btnStatus.Text = "Unmark as Done";
                else btnStatus.Text = "Mark as Done";
            }
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvTask.ClearSelection();
            ApplyFilter();
        }

        private void btnTeam_Click(object sender, EventArgs e)
        {
            Team team = new Team(loginUser);
            team.Show();
            this.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTask.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please choose a task", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult dr = MessageBox.Show("Are you sure delete this task?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using (var context = new TaskManagementContext())
                {
                    int id = int.Parse(dgvTask.SelectedRows[0].Cells[0].Value.ToString());
                    var taskComments = context.Comments.Where(c => c.TaskId == id).ToList();
                    foreach (var comment in taskComments)
                    {
                        context.Comments.Remove(comment);
                    }

                    var task = context.Tasks.Find(dgvTask.SelectedRows[0].Cells[0].Value);
                    context.Tasks.Remove(task);
                    context.SaveChanges();
                }
            }
            ReloadForm();
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            AddTask addTask = new AddTask();
            addTask.CreateTask += ReloadForm;
            addTask.Show();
        }

        private void ReloadForm() => LeaderForm_Load(null, EventArgs.Empty);
        private void ApplyFilter()
        {
            string filter = cboFilter.SelectedItem.ToString();
            string filterHolder = string.Empty;
            string search = $"Title LIKE '%{txtSearch.Text}%'";

            if (filter.Equals("Completed Task")) filterHolder = "Status = 'Done'";
            else if (filter.Equals("Your Task")) filterHolder = $"Assignee = '{loginUser.Username}'";
            else if (filter.Equals("Unfinished Task")) filterHolder = "Status = 'In Progress'";
            else filterHolder = string.Empty;

            source.Filter = string.Join(" AND ", new[] { filterHolder, search }.Where(f => !string.IsNullOrEmpty(f)));
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
        public static bool IsNullable(Type t) => !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        private void MemberTask_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();

    }
}

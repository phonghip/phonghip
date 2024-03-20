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
using Task = Assignment.Models.Task;

namespace Assignment.FormMember
{
    public partial class CommentList : Form
    {
        private Task selectedTask;
        private User user;

        public CommentList(Task selectedTask, User user)
        {
            InitializeComponent();
            this.selectedTask = selectedTask;
            this.user = user;
        }

        private void CommentList_Load(object sender, EventArgs e)
        {
            lblTask.Text = selectedTask.Title;
            LoadComments();
            if (user.Role.Equals("Member")) dgvComment.SelectionChanged += dgvComment_SelectionChanged;
            else dgvComment.SelectionChanged -= dgvComment_SelectionChanged;
        }

        private void LoadComments()
        {
            using (var context = new TaskManagementContext())
            {
                string userHeader = "Submitted by";
                var commentList = context.Comments
                                    .Where(comment => comment.TaskId == selectedTask.TaskId)
                                    .OrderBy(comment => comment.CommentDate)
                                    .Select(comment => new
                                    {
                                        comment.CommentId,
                                        comment.CommentText,
                                        comment.CommentDate,
                                        Comment_By = comment.User.Username
                                    }).ToList();
                dgvComment.DataSource = commentList;
            }
            foreach (DataGridViewColumn column in dgvComment.Columns) { column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; }
            dgvComment.Columns[0].Visible = false;
            dgvComment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvComment.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvComment.Columns[1].HeaderText = "Comment";
            dgvComment.Columns[2].HeaderText = "Comment Date";
            dgvComment.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvComment.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvComment.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure delete this comment?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using (var context = new TaskManagementContext())
                {
                    var comment = context.Comments.Find(dgvComment.SelectedRows[0].Cells[0].Value);
                    context.Comments.Remove(comment);
                    context.SaveChanges();
                }
                LoadComments();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Dispose();

        private void dgvComment_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvComment.SelectedRows.Count != 0)
            {
                if (dgvComment.SelectedRows[0].Cells[3].Value.Equals(user.Username)) btnDelete.Enabled = true;
                else btnDelete.Enabled = false;
            }
        }
    }
}

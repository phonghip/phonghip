using Assignment.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using User = Assignment.Models.User;

namespace Assignment.FormLeader
{
    public partial class Team : Form
    {
        private User loginUser;
        private BindingSource source;

        public Team(User user)
        {
            InitializeComponent();
            this.loginUser = user;
            this.FormClosing += Team_FormClosing;
        }

        private void Team_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"Welcome {loginUser.Username}";
            LoadData();
            cboFilter.SelectedIndex = 3;
        }

        private void LoadData()
        {
            using (var context = new TaskManagementContext())
            {
                var userList = context.Users
                                .Select(u => new
                                {
                                    u.UserId,
                                    u.Username,
                                    u.Password,
                                    u.Role,
                                    Tasks = string.Join(", ", u.Tasks.Select(t => t.Title))
                                })
                                .ToList();

                DataTable dataTable = new DataTable();
                dataTable = ToDataTable(userList);
                source = new BindingSource();
                DataView view = new DataView(dataTable);
                source.DataSource = view;
                dgvUser.DataSource = source;

                dgvUser.Columns[0].HeaderText = "ID";
                dgvUser.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dgvUser.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvUser.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvUser.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvUser.Columns[4].HeaderText = "Assigned Tasks";
                dgvUser.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvUser.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                foreach (DataGridViewColumn column in dgvUser.Columns) { column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; }
            }
        }

        private void ApplyFilter()
        {
            string filter = cboFilter.SelectedItem.ToString();
            string filterHolder = string.Empty;
            string search = $"Username LIKE '%{txtSearch.Text}%'";

            if (filter.Equals("Member")) filterHolder = "Role = 'Member'";
            else if (filter.Equals("Leader")) filterHolder = "Role = 'Leader'";
            else if (filter.Equals("Free")) filterHolder = "Tasks = ''";
            else filterHolder = string.Empty;

            source.Filter = string.Join(" AND ", new[] { filterHolder, search }.Where(f => !string.IsNullOrEmpty(f)));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please choose an User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult dr = MessageBox.Show($"Delete user {dgvUser.SelectedRows[0].Cells[1].Value}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using (var context = new TaskManagementContext())
                {
                    int id = int.Parse(dgvUser.SelectedRows[0].Cells[0].Value.ToString());
                    var taskComments = context.Comments.Where(c => c.UserId == id).ToList();
                    foreach (var comment in taskComments)
                    {
                        context.Comments.Remove(comment);
                    }

                    var user = context.Users.Find(dgvUser.SelectedRows[0].Cells[0].Value);
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
                MessageBox.Show("User deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadForm();
            }
        }

        private void dgvUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count != 0)
            {
                var selectedUser = dgvUser.SelectedRows[0];
                txtUsername.Text = selectedUser.Cells[1].Value.ToString();
                txtPassword.Text = selectedUser.Cells[2].Value.ToString();
                rdMember.Checked = selectedUser.Cells[3].Value.Equals("Member");
                rdLeader.Checked = !rdMember.Checked;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text.Equals("Update mode"))
            {
                btnUpdate.Text = "Update";
                txtUsername.Enabled = false;
                return;
            }
            if (dgvUser.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please choose an User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult dr = MessageBox.Show($"Update user {dgvUser.SelectedRows[0].Cells[1].Value}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using (var context = new TaskManagementContext())
                {
                    var user = context.Users.Find(dgvUser.SelectedRows[0].Cells[0].Value);
                    user.Password = txtPassword.Text;
                    user.Role = rdMember.Checked ? "Member" : "Leader";
                    context.SaveChanges();
                }
                MessageBox.Show("User updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadForm();
            }
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            LeaderForm leaderForm = new LeaderForm(loginUser);
            this.Dispose();
            leaderForm.Show();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Text.Equals("Create new user"))
            {
                using (var context = new TaskManagementContext())
                {
                    User user = context.Users.FirstOrDefault(u => u.Username == txtUsername.Text);
                    if (user != null)
                    {
                        MessageBox.Show("Username already exist!", "Create Fail!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        user = new()
                        {
                            Username = txtUsername.Text,
                            Password = txtPassword.Text,
                            Role = rdMember.Checked ? "Member" : "Leader"
                        };
                        DialogResult dr = MessageBox.Show($"Create new {user.Role}\nwith {user.Username}: {user.Password} ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            context.Users.Add(user);
                            context.SaveChanges();
                            btnCreate.Text = "Create mode";
                            btnUpdate.Text = "Update";
                            txtUsername.ReadOnly = true;
                        }
                        ReloadForm();
                    }
                }
            }
            else //btncreate text : create mode
            {
                btnUpdate.Text = "Update mode";
                btnCreate.Text = "Create new user";
                txtUsername.ReadOnly = false;
            }
        }


        private void Team_FormClosing(object? sender, FormClosingEventArgs e) => Application.Exit();
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
        private void enableUpdateCreate(object sender, EventArgs e)
        {
            bool allFieldsFilled =
                (rdLeader.Checked || rdMember.Checked) &&
                !string.IsNullOrEmpty(txtUsername.Text) &&
                !string.IsNullOrEmpty(txtPassword.Text);

            // Enable the "Update" button if all fields are filled
            btnUpdate.Enabled = allFieldsFilled;
            btnCreate.Enabled = allFieldsFilled;
        }
        private void ReloadForm() => Team_Load(null, EventArgs.Empty);
        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();
    }
}

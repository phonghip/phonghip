
using Assignment.FormLeader;
using Assignment.FormMember;
using Assignment.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Assignment
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim().Length == 0 || txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please fill out the required data");
                return;
            }

            using (var context = new TaskManagementContext())
            {
                User login = context.Users.FirstOrDefault(u => u.Username == txtUsername.Text && u.Password == txtPassword.Text);
                if (login == null)
                {
                    MessageBox.Show("Please Check Your Username and Password", "Login Fail!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (login.Role.Equals("Member"))
                {
                    this.Dispose(false);
                    MemberTask newForm = new MemberTask(login);
                    newForm.Show();
                }
                else if (login.Role.Equals("Leader"))
                {
                    this.Dispose(false);
                    LeaderForm newForm = new LeaderForm(login);
                    newForm.Show();
                }

            }

        }
    }
}

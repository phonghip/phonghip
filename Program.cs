using Assignment.FormMember;

namespace Assignment
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }

//1	john_doe        password1   Member
//2	jane_smith      password2   Member
//3	mark_johnson    admin       Leader
//4	susan_white     password4   Member
//5	peter_brown     admin       Leader
}
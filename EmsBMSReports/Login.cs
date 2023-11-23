using System;

namespace EmsBMSReports
{

    public partial class Login
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btLoginLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if ((UserID.Text == "ADMIN123" | UserID.Text == "SUPERADMIN" | UserID.Text == "MACTUS") & (UsrPassword.Text == "Password@123" | UsrPassword.Text == "Admin@123" | UsrPassword.Text == "Mactus@123"))
                {


                }
            }

            catch (Exception )
            {

            }
            // CheckUserLogin(UserID.Text, UsrPassword.Text)
        }


        private void btLogout_Click(object sender, EventArgs e)
        {
            MactusReportLib.MactusReportLib.g_sCurrent_login_UserID = "";
            UserID.Text = "";
            UsrPassword.Text = "";
        }

        private void Login_New_Load(object sender, EventArgs e)
        {
            Label5.Text = "";
            btLoginLogin.Enabled = false;



        }

        private void UserID_TextChanged(object sender, EventArgs e)
        {
            if (UserID.Text.Length >= 6 & UserID.Text.Length <= 12 & UsrPassword.Text.Length > 6)
            {
                btLoginLogin.Enabled = true;
            }
            else
            {
                btLoginLogin.Enabled = false;
            }
        }

        private void UsrPassword_TextChanged(object sender, EventArgs e)
        {
            if (UserID.Text.Length >= 6 & UserID.Text.Length <= 12 & UsrPassword.Text.Length > 6)
            {
                btLoginLogin.Enabled = true;
            }
            else
            {
                btLoginLogin.Enabled = false;
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
    }
}
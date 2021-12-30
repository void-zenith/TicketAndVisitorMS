using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TicketAndVisitorMS
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void loginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (userTextBox.Text.Contains("admin"))
            {
                AdminPage adminPage = new AdminPage();
                adminPage.Show();
            }
            else
            {
                EmployeePage employeePage = new EmployeePage();
                employeePage.Show();
            }
        }

        private void eyeIcon_MouseDown(object sender, MouseEventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = false;
        }

        private void eyeIcon_MouseUp(object sender, MouseEventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = true;
        }

        private void userTextBox_Enter(object sender, EventArgs e)
        {
            if (userTextBox.Text == "Username" || userTextBox.Text == "")
            {
                passwordTextBox.UseSystemPasswordChar = false;
                passwordTextBox.Text = "Password";
                userTextBox.Text = "";
            }
        }

        private void userTextBox_Leave(object sender, EventArgs e)
        {
            if (userTextBox.TextLength == 0 && userTextBox.Text == "")
            {
                userTextBox.Text = "Username";
            }
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "Password" && !passwordTextBox.UseSystemPasswordChar)
            {
                passwordTextBox.UseSystemPasswordChar = true;
                passwordTextBox.Text = "";
            }
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == "")
            {
                passwordTextBox.UseSystemPasswordChar = false;
                passwordTextBox.Text = "Password";
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dragDropPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void anoDragDropPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
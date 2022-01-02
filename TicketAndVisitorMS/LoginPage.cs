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
using System.Xml.Serialization;
using System.IO;

namespace TicketAndVisitorMS
{
    public partial class LoginPage : Form
    {
        private readonly string folderPath;
        private List<Employee> employeesList;
        private readonly XmlSerializer employeeXmlSerializer;
        private readonly string employeeXMLFilePath;

        public LoginPage()
        {
            InitializeComponent();
            folderPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            employeeXMLFilePath = folderPath + "\\EmployeeDetails.xml";
            employeeXmlSerializer = new XmlSerializer(typeof(List<Employee>));
        }

        private List<Employee> EmployeesList
        {
            get
            {
                FileStream employeeFS;
                employeesList = new List<Employee>();
                if (File.Exists(employeeXMLFilePath))
                {
                    employeeFS = new FileStream(employeeXMLFilePath, FileMode.Open, FileAccess.Read);
                    List<Employee> allEmp = (List<Employee>)employeeXmlSerializer.Deserialize(employeeFS);
                    employeesList.AddRange(allEmp);
                    return employeesList;
                }
                else
                {
                    string message = "Desired File not found";
                    string title = "File not Found";
                    _ = MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void loginBtn_Click(object sender, EventArgs e)
        {
            List<Employee> employees = EmployeesList;
            bool match = false;

            if (!String.IsNullOrEmpty(userTextBox.Text) && !String.IsNullOrEmpty(passwordTextBox.Text))
            {
                foreach (Employee employee in employees)
                {
                    if (employee.employeeUserName == userTextBox.Text.Trim() && employee.employeePassword == passwordTextBox.Text.Trim())
                    {
                        match = true;

                        this.Hide();
                        if (employee.employeeRole == "Admin")
                        {
                            AdminPage adminPage = new AdminPage();
                            adminPage.Show();
                        }
                        if (employee.employeeRole == "Staff")
                        {
                            EmployeePage employeePage = new EmployeePage();
                            employeePage.Show();
                        }
                    }

                    if (match) break;
                }

                if (!match)
                {
                    MessageBox.Show("Invalid username or password", "Login Failed!");
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed!");
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
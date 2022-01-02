using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace TicketAndVisitorMS
{
    public partial class AdminPage : Form
    {
        private readonly XmlSerializer employeeSerializer;
        private List<Employee> employeeList;
        private List<TicketDetails> ticketDetailsList;
        private List<VisitorDetails> visitorDetailsList;
        private List<DailyReport> dailyReports;
        private readonly string folderPath;
        private readonly string ticketDetailsPathCSV;
        private readonly string visitorDetailsPathCSV;
        private readonly string employeeDetailsPathXML;
        private bool isRowSelected = false;

        public AdminPage()
        {
            InitializeComponent();
            ticketDetailsList = new List<TicketDetails>();
            employeeList = new List<Employee>();
            employeeSerializer = new XmlSerializer(typeof(List<Employee>));

            visitorDetailsList = new List<VisitorDetails>();
            folderPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            ticketDetailsPathCSV = folderPath + "\\TicketDetails.csv";
            employeeDetailsPathXML = folderPath + "\\EmployeeDetails.xml";
            visitorDetailsPathCSV = folderPath + "\\VisitorDetails.csv";
        }

        private void MakeAdminPanelVisible(bool showDailyReportPanel = false, bool showWeeklyReportPanel = false, bool showManageemployeePanel = false, bool showTicketDetailsPanel = false)
        {
            dailyReportPanel.Visible = showDailyReportPanel;
            weeklyReportPanel.Visible = showWeeklyReportPanel;
            manageEmployeePanel.Visible = showManageemployeePanel;
            ticketDetailsPanel.Visible = showTicketDetailsPanel;
        }

        private void adminTicketDetailsLabel_Click(object sender, EventArgs e)
        {
            isRowSelected = false;
            MakeAdminPanelVisible(showTicketDetailsPanel: true);
            ticketDetailsPanel.BringToFront();
        }

        private void adminManageEmployeeLabel_Click(object sender, EventArgs e)
        {
            isRowSelected = false;
            MakeAdminPanelVisible(showManageemployeePanel: true);
            manageEmployeePanel.BringToFront();
        }

        private void adminWeeklyReportLabel_Click(object sender, EventArgs e)
        {
            MakeAdminPanelVisible(showWeeklyReportPanel: true);
            weeklyReportPanel.BringToFront();
        }

        private void adminDailyReportLabel_Click(object sender, EventArgs e)
        {
            MakeAdminPanelVisible(showDailyReportPanel: true);
            dailyReportPanel.BringToFront();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void clearInputFields()
        {
            TicketIDBox.Text = "";
            categoryCombobox.Text = "Select Category";
            totalPriceTextbox.Text = "";
            dayCombobox.Text = "Select Day";
            durationCombobox.Text = "Select Duration";
            noOfIndividualTextBox.Text = "";
        }

        private void ticketAddBtn_Click(object sender, EventArgs e)
        {
            ticketDetailsList = new List<TicketDetails>();
            if (!String.IsNullOrWhiteSpace(TicketIDBox.Text) &&
                    !String.IsNullOrWhiteSpace(noOfIndividualTextBox.Text) &&
                    !String.IsNullOrWhiteSpace(totalPriceTextbox.Text))
            {
                if (categoryCombobox.SelectedIndex > -1 && dayCombobox.SelectedIndex > -1)
                {
                    TicketDetails ticketDetails = new TicketDetails
                    {
                        ticketID = $"T + {Convert.ToString(DateTime.Now.ToString("yyMMddHHmmssff"))}",
                        ticketCategory = categoryCombobox.SelectedItem.ToString(),
                        ticketNoOfIndividuals = Convert.ToInt32(noOfIndividualTextBox.Text.Trim()),
                        ticketDuration = durationCombobox.SelectedItem.ToString(),
                        ticketDay = dayCombobox.SelectedItem.ToString(),
                        ticketPrice = Convert.ToDouble(totalPriceTextbox.Text.Trim()),
                    };
                    ticketDetailsList.Add(ticketDetails);
                    ticketDetailsDataGrid.Rows.Add(ticketDetails.ticketID,
                        ticketDetails.ticketCategory,
                        ticketDetails.ticketNoOfIndividuals,
                        ticketDetails.ticketDuration,
                        ticketDetails.ticketDay,
                        ticketDetails.ticketPrice);
                    ticketDetailsDataGrid.Refresh();
                    ticketDetailsDataGrid.ClearSelection();
                    clearInputFields();
                }
                else
                {
                    MessageBox.Show("Please select a item from combobox", "Invalid input");
                }
            }
            else
            {
                MessageBox.Show("Text Fields are empty", "Invalid input");
            }
        }

        private void exportTicketDetailsBtn_Click(object sender, EventArgs e)
        {
            if (ticketDetailsDataGrid.RowCount != 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog
                {
                    Filter = "CSV (*.csv)|*.csv",
                    FileName = "TicketDetails.csv",
                };
                bool error = false;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(fileDialog.FileName))
                    {
                        try
                        {
                            File.Delete(fileDialog.FileName);
                        }
                        catch (IOException)
                        {
                            error = true;
                            MessageBox.Show("There was some error while saving the file.", "Invalid Export");
                        }
                    }

                    if (!error)
                    {
                        string[] lines = new string[ticketDetailsDataGrid.RowCount + 1];

                        for (int i = 0; i < ticketDetailsDataGrid.RowCount + 1; i++)
                        {
                            for (int j = 0; j < ticketDetailsDataGrid.ColumnCount; j++)
                            {
                                if (i == 0)
                                {
                                    lines[i] = lines[i] + ticketDetailsDataGrid.Columns[j].HeaderText + ",";
                                }
                                else
                                {
                                    lines[i] = lines[i] + ticketDetailsDataGrid.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }
                        }

                        File.WriteAllLines(ticketDetailsPathCSV, lines, Encoding.UTF8);
                        MessageBox.Show("The data has been exported successfully", "Successful Export");
                    }
                }
                else
                {
                    MessageBox.Show("There was some error while saving the file.", "Invalid Export");
                }
            }
            else
            {
                MessageBox.Show("There are no datas to export.", "Invalid Export");
            }
        }

        private void ticketClearBtn_Click(object sender, EventArgs e)
        {
            clearInputFields();
        }

        private void ticketEditBtn_Click(object sender, EventArgs e)
        {
            if (ticketDetailsDataGrid.SelectedRows.Count > 0)
            {
                if (isRowSelected)
                {
                    if (!String.IsNullOrWhiteSpace(TicketIDBox.Text) &&
                    !String.IsNullOrWhiteSpace(noOfIndividualTextBox.Text) &&
                    !String.IsNullOrWhiteSpace(totalPriceTextbox.Text))
                    {
                        if (categoryCombobox.SelectedIndex > -1 && dayCombobox.SelectedIndex > -1)
                        {
                            ticketDetailsDataGrid.Rows[0].Cells[0].Value = TicketIDBox.Text.Trim();
                            ticketDetailsDataGrid.Rows[0].Cells[1].Value = categoryCombobox.SelectedItem.ToString();
                            ticketDetailsDataGrid.Rows[0].Cells[2].Value = noOfIndividualTextBox.Text.Trim();
                            ticketDetailsDataGrid.Rows[0].Cells[3].Value = durationCombobox.SelectedItem.ToString();
                            ticketDetailsDataGrid.Rows[0].Cells[4].Value = dayCombobox.SelectedItem.ToString();
                            ticketDetailsDataGrid.Rows[0].Cells[5].Value = totalPriceTextbox.Text.Trim();

                            clearInputFields();
                            isRowSelected = false;
                        }
                        else
                        {
                            MessageBox.Show("Please select a item from combobox", "Invalid input");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Text Fields are empty", "Invalid input");
                    }
                }
                else
                {
                    MessageBox.Show("No Row Selected", "Invalid Selection");
                }
            }
            else
            {
                MessageBox.Show("No Row Selected", "Invalid edit");
            }
        }

        private void ticketDetailsDataGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                isRowSelected = true;
                TicketIDBox.Text = ticketDetailsDataGrid.SelectedRows[0].Cells[0].Value.ToString();
                categoryCombobox.SelectedItem = ticketDetailsDataGrid.SelectedRows[0].Cells[1].Value.ToString();
                noOfIndividualTextBox.Text = ticketDetailsDataGrid.SelectedRows[0].Cells[2].Value.ToString();
                durationCombobox.SelectedItem = ticketDetailsDataGrid.SelectedRows[0].Cells[3].Value.ToString();
                dayCombobox.SelectedItem = ticketDetailsDataGrid.SelectedRows[0].Cells[4].Value.ToString();
                totalPriceTextbox.Text = ticketDetailsDataGrid.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Rows to select", "Invalid Selection");
            }
        }

        private void importTicketDetailsBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "CSV (*.csv)|*.csv",
                FileName = "TicketDetails.csv"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fileDialog.FileName))
                {
                    ticketDetailsList = new List<TicketDetails>();
                    DataTable dt = new DataTable();
                    string[] lines = File.ReadAllLines(fileDialog.FileName);

                    if (lines.Length > 0)
                    {
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] line = lines[i].Split(',');
                            TicketDetails ticketDetails = new TicketDetails
                            {
                                ticketID = line[0],
                                ticketCategory = line[1],
                                ticketNoOfIndividuals = Convert.ToInt32(line[2]),
                                ticketDuration = line[3],
                                ticketDay = line[4],
                                ticketPrice = Convert.ToDouble(line[5]),
                            };
                            ticketDetailsList.Add(ticketDetails);
                            ticketDetailsDataGrid.Rows.Add(ticketDetails.ticketID,
                               ticketDetails.ticketCategory,
                               ticketDetails.ticketNoOfIndividuals,
                               ticketDetails.ticketDuration,
                               ticketDetails.ticketDay,
                               ticketDetails.ticketPrice);
                        };
                        MessageBox.Show("The data has been imported successfully", "Successful Import");
                    }
                }
                else
                {
                    MessageBox.Show("Specified File not found", "File not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There was some error while saving the file.", "Invalid Export");
            }
        }

        private void ticketDeleteBtn_Click(object sender, EventArgs e)
        {
            if (ticketDetailsDataGrid.RowCount > 0)
            {
                if (ticketDetailsDataGrid.SelectedRows.Count > 0)
                {
                    var messageResult = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete!!", MessageBoxButtons.YesNo);

                    if (messageResult == DialogResult.Yes)
                    {
                        ticketDetailsDataGrid.Rows.RemoveAt(ticketDetailsDataGrid.SelectedRows[0].Index);
                    }
                }
                else
                {
                    MessageBox.Show("No Row Selected", "Invalid Delete");
                }
            }
            else
            {
                MessageBox.Show("The table is empty.", "Invalid Delete");
            }
        }

        //all about add employee from here

        private void clearEmpInputFields()
        {
            employeeIdTextBox.Text = "";
            employeeNameTextBox.Text = "";
            employeeUserNameTextBox.Text = "";
            employeePasswordTextBox.Text = "";
            employeeRoleCombobox.Text = "Select Role";
            employeeAddressTextBox.Text = "";
            employeeEmailTextBox.Text = "";
            employeeMobileNoTextBox.Text = "";
        }

        private void addEmployeeBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(employeeIdTextBox.Text)
                && !String.IsNullOrEmpty(employeeNameTextBox.Text)
                && !String.IsNullOrEmpty(employeeUserNameTextBox.Text)
                && !String.IsNullOrEmpty(employeePasswordTextBox.Text)
                && !String.IsNullOrEmpty(employeeAddressTextBox.Text)
                && !String.IsNullOrEmpty(employeeEmailTextBox.Text)
                && !String.IsNullOrEmpty(employeeMobileNoTextBox.Text))
            {
                if (employeeRoleCombobox.SelectedIndex > -1)
                {
                    employeeList = new List<Employee>();

                    Employee employee = new Employee
                    {
                        employeeID = $"E{employeeIdTextBox.Text.Trim()}",
                        employeeName = employeeNameTextBox.Text.Trim(),
                        employeeUserName = employeeUserNameTextBox.Text.Trim(),
                        employeePassword = employeePasswordTextBox.Text.Trim(),
                        employeeRole = employeeRoleCombobox.SelectedItem.ToString(),
                        employeeAddress = employeeAddressTextBox.Text.Trim(),
                        employeeEmail = employeeEmailTextBox.Text.Trim(),
                        employeeMobileNumber = employeeMobileNoTextBox.Text.Trim(),
                    };
                    employeeList.Add(employee);
                    employeeDatailsDatagrid.Rows.Add(employee.employeeID, employee.employeeUserName, employee.employeeName, employee.employeeEmail, employee.employeeMobileNumber, employee.employeeAddress, employee.employeeRole, employee.employeePassword);

                    employeeDatailsDatagrid.Refresh();
                    employeeDatailsDatagrid.ClearSelection();
                    clearEmpInputFields();
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("Text Fields are empty", "Invalid input");
            }
        }

        private void clearEmployeeInputFields_Click(object sender, EventArgs e)
        {
            clearEmpInputFields();
        }

        private void exportEmployeeBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Filter = "XML-File | *.xml",
                FileName = "EmployeeDetails.xml",
            };
            bool error = false;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fileDialog.FileName))
                {
                    try
                    {
                        File.Delete(fileDialog.FileName);
                    }
                    catch (IOException)
                    {
                        error = true;
                        MessageBox.Show("There was some error while saving the file.", "Invalid Export");
                    }
                }
            }
            else
            {
                MessageBox.Show("There was some error while saving the file.", "Invalid Export");
            }

            if (!error)
            {
                employeeList = new List<Employee>();
                for (int i = 0; i < employeeDatailsDatagrid.Rows.Count; i++)
                {
                    Employee employee = new Employee
                    {
                        employeeID = employeeDatailsDatagrid.Rows[i].Cells[0].Value.ToString(),
                        employeeUserName = employeeDatailsDatagrid.Rows[i].Cells[1].Value.ToString(),
                        employeeName = employeeDatailsDatagrid.Rows[i].Cells[2].Value.ToString(),
                        employeeEmail = employeeDatailsDatagrid.Rows[i].Cells[3].Value.ToString(),
                        employeeMobileNumber = employeeDatailsDatagrid.Rows[i].Cells[4].Value.ToString(),
                        employeeAddress = employeeDatailsDatagrid.Rows[i].Cells[5].Value.ToString(),
                        employeeRole = employeeDatailsDatagrid.Rows[i].Cells[6].Value.ToString(),
                        employeePassword = employeeDatailsDatagrid.Rows[i].Cells[7].Value.ToString(),
                    };
                    employeeList.Add(employee);
                }
                FileStream employeeFile = new FileStream(@employeeDetailsPathXML, FileMode.Create, FileAccess.ReadWrite);
                employeeSerializer.Serialize(employeeFile, employeeList);
                MessageBox.Show("The data has been exported successfully", "Successful Export");
                employeeFile.Close();
            }
        }

        private void importEmployeeBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "XML-File | *.xml",
                FileName = "EmployeeDetails.xml",
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(employeeDetailsPathXML))
                {
                    FileStream employeeFile = new FileStream(@employeeDetailsPathXML, FileMode.Open, FileAccess.Read);
                    employeeList = (List<Employee>)employeeSerializer.Deserialize(employeeFile);
                    employeeFile.Close();
                    foreach (var list in employeeList)
                    {
                        employeeDatailsDatagrid.Rows.Add(list.employeeID,
                          list.employeeUserName, list.employeeName,
                          list.employeeEmail, list.employeeMobileNumber,
                          list.employeeAddress, list.employeeRole, list.employeePassword
                          );
                    }
                    MessageBox.Show("The data has been imported successfully", "Successful Import");
                }
                else
                {
                    MessageBox.Show("Specified File not found", "File not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There was some error while saving the file.", "Invalid Export");
            }
        }

        private void employeeDatailsDatagrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                isRowSelected = true;
                employeeIdTextBox.Text = employeeDatailsDatagrid.SelectedRows[0].Cells[0].Value.ToString();
                employeeUserNameTextBox.Text = employeeDatailsDatagrid.SelectedRows[0].Cells[1].Value.ToString();
                employeeNameTextBox.Text = employeeDatailsDatagrid.SelectedRows[0].Cells[2].Value.ToString();
                employeeEmailTextBox.Text = employeeDatailsDatagrid.SelectedRows[0].Cells[3].Value.ToString();
                employeeMobileNoTextBox.Text = employeeDatailsDatagrid.SelectedRows[0].Cells[4].Value.ToString();
                employeeAddressTextBox.Text = employeeDatailsDatagrid.SelectedRows[0].Cells[5].Value.ToString();
                employeeRoleCombobox.SelectedItem = employeeDatailsDatagrid.SelectedRows[0].Cells[6].Value.ToString();
                employeePasswordTextBox.Text = employeeDatailsDatagrid.SelectedRows[0].Cells[7].Value.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Rows to select", "Invalid Selection");
            }
        }

        private void editEmployeeBtn_Click(object sender, EventArgs e)
        {
            if (employeeDatailsDatagrid.SelectedRows.Count > 0)
            {
                if (isRowSelected)
                {
                    if (!String.IsNullOrWhiteSpace(employeeIdTextBox.Text) &&
                    !String.IsNullOrWhiteSpace(employeeUserNameTextBox.Text) &&
                    !String.IsNullOrWhiteSpace(employeeNameTextBox.Text) &&
                    !String.IsNullOrWhiteSpace(employeeEmailTextBox.Text) &&
                    !String.IsNullOrWhiteSpace(employeeMobileNoTextBox.Text) &&
                    !String.IsNullOrWhiteSpace(employeeAddressTextBox.Text) &&
                    !String.IsNullOrWhiteSpace(employeePasswordTextBox.Text))
                    {
                        employeeDatailsDatagrid.SelectedRows[0].Cells[0].Value = employeeIdTextBox.Text.Trim();
                        employeeDatailsDatagrid.SelectedRows[0].Cells[1].Value = employeeUserNameTextBox.Text.Trim();
                        employeeDatailsDatagrid.SelectedRows[0].Cells[2].Value = employeeNameTextBox.Text.Trim();
                        employeeDatailsDatagrid.SelectedRows[0].Cells[3].Value = employeeEmailTextBox.Text.Trim();
                        employeeDatailsDatagrid.SelectedRows[0].Cells[4].Value = employeeMobileNoTextBox.Text.Trim();
                        employeeDatailsDatagrid.SelectedRows[0].Cells[5].Value = employeeAddressTextBox.Text.Trim();
                        employeeDatailsDatagrid.SelectedRows[0].Cells[6].Value = employeeRoleCombobox.SelectedItem.ToString();
                        employeeDatailsDatagrid.SelectedRows[0].Cells[7].Value = employeePasswordTextBox.Text.Trim();
                        clearEmpInputFields();
                        isRowSelected = false;
                    }
                    else
                    {
                        MessageBox.Show("Text Fields are empty", "Invalid input");
                    }
                }
                else
                {
                    MessageBox.Show("No Row Selected", "Invalid Selection");
                }
            }
            else
            {
                MessageBox.Show("No Row Selected", "Invalid edit");
            }
        }

        private void deleteEmployeeBtn_Click(object sender, EventArgs e)
        {
            if (employeeDatailsDatagrid.RowCount > 0)
            {
                if (employeeDatailsDatagrid.SelectedRows.Count > 0)
                {
                    var messageResult = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete!!", MessageBoxButtons.YesNo);

                    if (messageResult == DialogResult.Yes)
                    {
                        employeeDatailsDatagrid.Rows.RemoveAt(employeeDatailsDatagrid.SelectedRows[0].Index);
                    }
                }
                else
                {
                    MessageBox.Show("No Row Selected", "Invalid Delete");
                }
            }
            else
            {
                MessageBox.Show("The table is empty.", "Invalid Delete");
            }
        }

        private void generateDailyReportBtn_Click(object sender, EventArgs e)
        {
            List<TicketDetails> allTicketDetails = new List<TicketDetails>();
            List<VisitorDetails> allVisitors = new List<VisitorDetails>();
            List<DailyReport> dailyReports = new List<DailyReport>();

            try
            {
                if (File.Exists(ticketDetailsPathCSV))
                {
                    string[] linesTicket = File.ReadAllLines(ticketDetailsPathCSV);
                    ticketDetailsList = new List<TicketDetails>();

                    if (linesTicket.Length > 0)
                    {
                        ticketDetailsList = new List<TicketDetails>();

                        for (int i = 1; i < linesTicket.Length; i++)
                        {
                            string[] lineTicket = linesTicket[i].Split(',');
                            TicketDetails ticketDetails = new TicketDetails
                            {
                                ticketID = lineTicket[0],
                                ticketCategory = lineTicket[1],
                                ticketNoOfIndividuals = Convert.ToInt32(lineTicket[2]),
                                ticketDuration = lineTicket[3],
                                ticketDay = lineTicket[4],
                                ticketPrice = Convert.ToDouble(lineTicket[5]),
                            };
                            ticketDetailsList.Add(ticketDetails);
                        };
                        allTicketDetails.AddRange(ticketDetailsList);
                    }
                }
                else
                {
                    MessageBox.Show("Specified File not found", "File not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (File.Exists(visitorDetailsPathCSV))
                {
                    visitorDetailsList = new List<VisitorDetails>();
                    string[] linesVisitor = File.ReadAllLines(visitorDetailsPathCSV);

                    if (linesVisitor.Length > 0)
                    {
                        for (int i = 1; i < linesVisitor.Length; i++)
                        {
                            string[] lineVisitor = linesVisitor[i].Split(',');
                            VisitorDetails visitorDetails = new VisitorDetails
                            {
                                visitorTicketNo = lineVisitor[0],
                                visitorCheckInTime = lineVisitor[1],
                                visitorCheckOutTime = lineVisitor[2],
                                visitorDuration = lineVisitor[3],
                                visitorDay = lineVisitor[4],
                                visitorTotalPrice = lineVisitor[5],
                                visitorName = lineVisitor[6],
                                visitorDate = Convert.ToDateTime(lineVisitor[7]),
                                visitorContactNo = lineVisitor[8],
                                visitorTicketInfoID = lineVisitor[9],
                                visitorCategory = lineVisitor[10],
                                visitorNoOfIndividual = lineVisitor[11],
                            };
                            visitorDetailsList.Add(visitorDetails);
                        };
                        allVisitors.AddRange(visitorDetailsList);
                    }
                }
                else
                {
                    MessageBox.Show("Specified File not found", "File not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int[] groups = new int[3];

                for (int i = 0; i < visitorDetailsList.Count; i++)
                {
                    bool match = false;
                    for (int j = 0; j < ticketDetailsList.Count; j++)
                    {
                        if (visitorDetailsList[i].visitorTicketInfoID == ticketDetailsList[j].ticketID &&
                            visitorDetailsList[i].visitorDate.Date == datePickerDailyReport.Value.Date)
                        {
                            if (string.Compare(ticketDetailsList[j].ticketCategory, "Group") == 0)
                            {
                                groups[0] += Convert.ToInt32(ticketDetailsList[j].ticketNoOfIndividuals);
                                match = true;
                            }
                            else if (string.Compare(ticketDetailsList[j].ticketCategory, "Adult") == 0)
                            {
                                groups[1] += Convert.ToInt32(ticketDetailsList[j].ticketNoOfIndividuals);
                                match = true;
                            }
                            else if (string.Compare(ticketDetailsList[j].ticketCategory, "Child (5-12)") == 0)
                            {
                                groups[2] += Convert.ToInt32(ticketDetailsList[j].ticketNoOfIndividuals);
                                match = true;
                            }
                            if (match) { break; }
                        }
                    }
                }
                DailyReport groupDailyReport = new DailyReport
                {
                    Date = DateTime.Now.Date,
                    Category = "Group",
                    TotalVisitor = groups[0]
                };
                DailyReport adultDailyReport = new DailyReport
                {
                    Date = DateTime.Now.Date,
                    Category = "Adult",
                    TotalVisitor = groups[1]
                };
                DailyReport childDailyReport = new DailyReport
                {
                    Date = DateTime.Now.Date,
                    Category = "Child (5-12)",
                    TotalVisitor = groups[2]
                };

                dailyReports.Add(groupDailyReport);
                dailyReports.Add(adultDailyReport);
                dailyReports.Add(childDailyReport);
                dailyVisitorReportDataGrid.DataSource = dailyReports;
                dailyVisitorReportDataGrid.Refresh();
                GenerateDailyReportChart(dailyReports);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void GenerateDailyReportChart(List<DailyReport> dailyReports)
        {
            dailyTotalVisitorChart.Series["TotalVisitor"].Points.Clear();
            for (int i = 0; i < dailyReports.Count; i++)
            {
                Console.WriteLine(dailyReports[i].Category);

                dailyTotalVisitorChart.Series["TotalVisitor"].Points.AddXY(dailyReports[i].Category, dailyReports[i].TotalVisitor);
            }
        }

        private int GetDayIndex(string day)
        {
            switch (day)
            {
                case "Sun":
                    return 0;

                case "Mon":
                    return 1;

                case "Tue":
                    return 2;

                case "Wed":
                    return 3;

                case "Thu":
                    return 4;

                case "Fri":
                    return 5;

                case "Sat":
                    return 6;

                default:
                    return 0;
            }
        }

        private void GenerateWeeklyReportChart(List<WeeklyReport> weeklyReports)
        {
            totalEarningWeeklyChart.Series["TotalEarning"].Points.Clear();
            totalVisitorWeeklyChart.Series["TotalVisitor"].Points.Clear();
            for (int i = 0; i < weeklyReports.Count; i++)
            {
                totalEarningWeeklyChart.Series["TotalEarning"].Points.AddXY(weeklyReports[i].Day, weeklyReports[i].TotalEarning);
                totalVisitorWeeklyChart.Series["TotalVisitor"].Points.AddXY(weeklyReports[i].Day, weeklyReports[i].TotalVisitor);
            }
        }

        private void generateWeeklyReportBtn_Click(object sender, EventArgs e)
        {
            List<TicketDetails> allTicketDetails = new List<TicketDetails>();
            List<VisitorDetails> allVisitors = new List<VisitorDetails>();
            List<WeeklyReport> weeklyReports = new List<WeeklyReport>();

            try
            {
                if (File.Exists(ticketDetailsPathCSV))
                {
                    string[] linesTicket = File.ReadAllLines(ticketDetailsPathCSV);
                    ticketDetailsList = new List<TicketDetails>();

                    if (linesTicket.Length > 0)
                    {
                        ticketDetailsList = new List<TicketDetails>();

                        for (int i = 1; i < linesTicket.Length; i++)
                        {
                            string[] lineTicket = linesTicket[i].Split(',');
                            TicketDetails ticketDetails = new TicketDetails
                            {
                                ticketID = lineTicket[0],
                                ticketCategory = lineTicket[1],
                                ticketNoOfIndividuals = Convert.ToInt32(lineTicket[2]),
                                ticketDuration = lineTicket[3],
                                ticketDay = lineTicket[4],
                                ticketPrice = Convert.ToDouble(lineTicket[5]),
                            };
                            ticketDetailsList.Add(ticketDetails);
                        };
                        allTicketDetails.AddRange(ticketDetailsList);
                    }
                }
                else
                {
                    MessageBox.Show("Specified File not found", "File not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (File.Exists(visitorDetailsPathCSV))
                {
                    visitorDetailsList = new List<VisitorDetails>();
                    string[] linesVisitor = File.ReadAllLines(visitorDetailsPathCSV);

                    if (linesVisitor.Length > 0)
                    {
                        for (int i = 1; i < linesVisitor.Length; i++)
                        {
                            string[] lineVisitor = linesVisitor[i].Split(',');
                            VisitorDetails visitorDetails = new VisitorDetails
                            {
                                visitorTicketNo = lineVisitor[0],
                                visitorCheckInTime = lineVisitor[1],
                                visitorCheckOutTime = lineVisitor[2],
                                visitorDuration = lineVisitor[3],
                                visitorDay = lineVisitor[4],
                                visitorTotalPrice = lineVisitor[5],
                                visitorName = lineVisitor[6],
                                visitorDate = Convert.ToDateTime(lineVisitor[7]),
                                visitorContactNo = lineVisitor[8],
                                visitorTicketInfoID = lineVisitor[9],
                                visitorCategory = lineVisitor[10],
                                visitorNoOfIndividual = lineVisitor[11],
                            };
                            visitorDetailsList.Add(visitorDetails);
                        };
                        allVisitors.AddRange(visitorDetailsList);
                    }
                }
                else
                {
                    MessageBox.Show("Specified File not found", "File not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            int[] earning = new int[7];
            int[] visit = new int[7];

            for (int i = 0; i < visitorDetailsList.Count; i++)
            {
                bool match = false;
                for (int j = 0; j < ticketDetailsList.Count; j++)
                {
                    if (visitorDetailsList[i].visitorTicketInfoID == ticketDetailsList[j].ticketID)
                    {
                        switch (visitorDetailsList[i].visitorDate.ToString("ddd"))
                        {
                            case "Sun":
                                earning[0] += Convert.ToInt32(ticketDetailsList[j].ticketPrice);
                                visit[0] += Convert.ToInt32(ticketDetailsList[j].ticketNoOfIndividuals);
                                match = true;
                                break;

                            case "Mon":
                                earning[1] += Convert.ToInt32(ticketDetailsList[j].ticketPrice);
                                visit[1] += Convert.ToInt32(ticketDetailsList[j].ticketNoOfIndividuals);
                                match = true;
                                break;

                            case "Tue":
                                earning[2] += Convert.ToInt32(ticketDetailsList[j].ticketPrice);
                                visit[2] += Convert.ToInt32(ticketDetailsList[j].ticketNoOfIndividuals);
                                match = true;
                                break;

                            case "Wed":
                                earning[3] += Convert.ToInt32(ticketDetailsList[j].ticketPrice);
                                visit[3] += Convert.ToInt32(ticketDetailsList[j].ticketNoOfIndividuals);
                                match = true;
                                break;

                            case "Thu":
                                earning[4] += Convert.ToInt32(ticketDetailsList[j].ticketPrice);
                                visit[4] += Convert.ToInt32(ticketDetailsList[j].ticketNoOfIndividuals);
                                match = true;
                                break;

                            case "Fri":
                                earning[5] += Convert.ToInt32(ticketDetailsList[j].ticketPrice);
                                visit[5] += Convert.ToInt32(ticketDetailsList[j].ticketNoOfIndividuals);
                                match = true;
                                break;

                            case "Sat":
                                earning[6] += Convert.ToInt32(ticketDetailsList[j].ticketPrice);
                                visit[6] += Convert.ToInt32(ticketDetailsList[j].ticketNoOfIndividuals);
                                match = true;
                                break;
                        }
                        if (match) { break; }
                    }
                }
            }

            for (int i = 0; i < 7; i++)
            {
                WeeklyReport weeklyReport = new WeeklyReport
                {
                    Date = weeklyChartStartDate.Value.Date.AddDays(i),
                    Day = weeklyChartStartDate.Value.Date.AddDays(i).ToString("ddd"),
                    TotalEarning = earning[GetDayIndex(weeklyChartStartDate.Value.Date.AddDays(i).ToString("ddd"))],
                    TotalVisitor = visit[GetDayIndex(weeklyChartStartDate.Value.Date.AddDays(i).ToString("ddd"))],
                };
                weeklyReports.Add(weeklyReport);
            }
            foreach (WeeklyReport weeklyReport in weeklyReports)
            {
                Console.WriteLine(weeklyReport.TotalVisitor);
            }
            weeklyChartDataGrid.DataSource = weeklyReports;
            weeklyChartDataGrid.Refresh();

            GenerateWeeklyReportChart(weeklyReports);
        }

        private void employeeSortBtn_Click(object sender, EventArgs e)
        {
        }
    }
}
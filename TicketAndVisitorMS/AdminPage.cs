using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace TicketAndVisitorMS
{
    public partial class AdminPage : Form
    {
        private readonly XmlSerializer employeeSerializer;
        private readonly XmlSerializer ticketDetailsSerializer;
        private List<Employee> employeeList;
        private List<TicketDetails> ticketDetailsList;
        private List<VisitorDetails> visitorDetailsList;
        private readonly string folderPath;
        private readonly string ticketDetailsPathCSV;
        private bool isRowSelected = false;

        public AdminPage()
        {
            InitializeComponent();
            ticketDetailsList = new List<TicketDetails>();
            employeeList = new List<Employee>();
            visitorDetailsList = new List<VisitorDetails>();
            folderPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            ticketDetailsPathCSV = folderPath + "\\TicketDetails.csv";
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
            MakeAdminPanelVisible(showTicketDetailsPanel: true);
            ticketDetailsPanel.BringToFront();
        }

        private void adminManageEmployeeLabel_Click(object sender, EventArgs e)
        {
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
                FileName = "ticketInfos.csv"
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
                    }
                }
                else
                {
                    MessageBox.Show("Specified File not found", "File not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
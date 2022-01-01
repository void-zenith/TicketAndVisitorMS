using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TicketAndVisitorMS
{
    public partial class EmployeePage : Form
    {
        //to know if any row has been selected or not since i've added double click event to select a row
        private bool isRowSelected = false;

        private string visitorDetailsURL = "C:/ASP .net/VisitorAndTicketMS/TicketAndVisitorMS/TicketAndVisitorMS/VisitorDetails.xml";

        //initializing serializer
        private XmlSerializer visitorSerializer;

        //initializing list
        private List<VisitorDetails> visitorDetailsList;

        private List<TicketDetails> ticketDetailsList;

        private readonly string folderPath;
        private readonly string ticketDetailsPathCSV;
        private readonly string visitorDetailsPathCSV;

        public EmployeePage()
        {
            InitializeComponent();
            visitorDetailsList = new List<VisitorDetails>();
            folderPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            ticketDetailsPathCSV = folderPath + "\\TicketDetails.csv";
            visitorDetailsPathCSV = folderPath + "\\VisitorDetails.csv";
            visitorSerializer = new XmlSerializer(typeof(List<VisitorDetails>));
        }

        private void clearTextBox()
        {
            VisitorNameBox.Text = "";
            ContactNoBox.Text = "";
            CategoryBox.Text = "";
            DurationBox.Text = "";
            TicketInfoIdBox.Text = "";
            TotalPriceBox.Text = "";
            visitorDatePicker.Value = DateTime.Today.Date;
            TicketIDBox.Text = "";
            ContactNoBox.Text = "";
            NoOfIndividualBox.Text = "";
            VisitorNameBox.Text = "";
            DayBox.Text = "";
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            visitorDetailsList = new List<VisitorDetails>();

            VisitorDetails visitorDetails = new VisitorDetails
            {
                visitorTicketNo = $"V + {Convert.ToString(DateTime.Now.ToString("yyMMddHHmmssff"))}",
                visitorName = VisitorNameBox.Text.Trim(),
                visitorCategory = CategoryBox.Text.Trim(),
                visitorCheckInTime = CheckInTimePicker.Value.ToString("hh:mm tt"),
                visitorCheckOutTime = CheckOutTimePicker.Value.ToString("hh:mm tt"),
                visitorContactNo = ContactNoBox.Text.Trim(),
                visitorDate = visitorDatePicker.Value.Date,
                visitorDay = DayBox.Text.Trim(),
                visitorNoOfIndividual = NoOfIndividualBox.Text.Trim(),
                visitorDuration = DurationBox.Text.Trim(),
                visitorTicketInfoID = TicketInfoIdBox.Text.Trim(),
                visitorTotalPrice = TotalPriceBox.Text.Trim(),
            };

            visitorDetailsList.Add(visitorDetails);
            visitorDataGridView.Rows.Add(visitorDetails.visitorTicketNo, visitorDetails.visitorCheckInTime,
                visitorDetails.visitorCheckOutTime, visitorDetails.visitorDuration,
                visitorDetails.visitorDay, visitorDetails.visitorTotalPrice,
                visitorDetails.visitorName, visitorDetails.visitorDate,
                visitorDetails.visitorContactNo, visitorDetails.visitorTicketInfoID,
                visitorDetails.visitorCategory, visitorDetails.visitorNoOfIndividual);
            visitorDataGridView.Refresh();
            visitorDataGridView.ClearSelection();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (visitorDataGridView.SelectedRows.Count > 0)
            {
                if (isRowSelected)
                {
                    if (!String.IsNullOrWhiteSpace(TicketIDBox.Text) &&
                      !String.IsNullOrWhiteSpace(ContactNoBox.Text) &&
                      !String.IsNullOrWhiteSpace(NoOfIndividualBox.Text) &&
                      !String.IsNullOrWhiteSpace(VisitorNameBox.Text))
                    {
                        visitorDataGridView.Rows[0].Cells[0].Value = TicketIDBox.Text.Trim();
                        visitorDataGridView.Rows[0].Cells[1].Value = ContactNoBox.Text.Trim();
                        visitorDataGridView.Rows[0].Cells[2].Value = NoOfIndividualBox.Text.Trim();
                        visitorDataGridView.Rows[0].Cells[3].Value = VisitorNameBox.Text.Trim();
                        clearTextBox();
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

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (visitorDataGridView.RowCount > 0)
            {
                if (visitorDataGridView.SelectedRows.Count > 0)
                {
                    var messageResult = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete!!", MessageBoxButtons.YesNo);

                    if (messageResult == DialogResult.Yes)
                    {
                        visitorDataGridView.Rows.RemoveAt(visitorDataGridView.SelectedRows[0].Index);
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

        //garna baki cha

        private void visitorDataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                isRowSelected = true;
                TicketIDBox.Text = visitorDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                ContactNoBox.Text = visitorDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                NoOfIndividualBox.Text = visitorDataGridView.SelectedRows[0].Cells[2].Value.ToString();
                VisitorNameBox.Text = visitorDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Rows to select", "Invalid Selection");
            }
        }

        private void importVisitorDetailsBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "CSV (*.csv)|*.csv",
                FileName = "VisitorDetails.csv"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fileDialog.FileName))
                {
                    visitorDetailsList = new List<VisitorDetails>();
                    DataTable dt = new DataTable();
                    string[] lines = File.ReadAllLines(fileDialog.FileName);

                    if (lines.Length > 0)
                    {
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string[] line = lines[i].Split(',');
                            VisitorDetails visitorDetails = new VisitorDetails
                            {
                                visitorTicketNo = line[0],
                                visitorCheckInTime = line[1],
                                visitorCheckOutTime = line[2],
                                visitorDuration = line[3],
                                visitorDay = line[4],
                                visitorTotalPrice = line[5],
                                visitorName = line[6],
                                visitorDate = Convert.ToDateTime(line[7]),
                                visitorContactNo = line[8],
                                visitorTicketInfoID = line[9],
                                visitorCategory = line[10],
                                visitorNoOfIndividual = line[11],
                            };
                            visitorDetailsList.Add(visitorDetails);
                            visitorDataGridView.Rows.Add(visitorDetails.visitorTicketNo, visitorDetails.visitorCheckInTime,
               visitorDetails.visitorCheckOutTime, visitorDetails.visitorDuration,
               visitorDetails.visitorDay, visitorDetails.visitorTotalPrice,
               visitorDetails.visitorName, visitorDetails.visitorDate,
               visitorDetails.visitorContactNo, visitorDetails.visitorTicketInfoID,
               visitorDetails.visitorCategory, visitorDetails.visitorNoOfIndividual);
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

        private void exportToCSVBtn_Click(object sender, EventArgs e)
        {
            if (visitorDataGridView.RowCount != 0)
            {
                SaveFileDialog fileDialog = new SaveFileDialog
                {
                    Filter = "CSV (*.csv)|*.csv",
                    FileName = "VisitorDetails.csv",
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
                        string[] lines = new string[visitorDataGridView.RowCount + 1];

                        for (int i = 0; i < visitorDataGridView.RowCount + 1; i++)
                        {
                            for (int j = 0; j < visitorDataGridView.ColumnCount; j++)
                            {
                                if (i == 0)
                                {
                                    lines[i] = lines[i] + visitorDataGridView.Columns[j].HeaderText + ",";
                                }
                                else
                                {
                                    lines[i] = lines[i] + visitorDataGridView.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }
                        }

                        File.WriteAllLines(visitorDetailsPathCSV, lines, Encoding.UTF8);
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

        private void openCSVBtn_Click(object sender, EventArgs e)
        {
            string folderPath = "C:/ASP .net/VisitorAndTicketMS/TicketAndVisitorMS/TicketAndVisitorMS/dailyreport.csv";
            if (File.Exists(folderPath))
            {
                System.Diagnostics.Process.Start(folderPath);
            }
            else
            {
                MessageBox.Show("File Does not exist.");
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void MakePanelVisible(bool showEnterVisitorDetailsPanel = false, bool showsearchVisitorDetailsPanel = false)
        {
            enterVisitorPanel.Visible = showEnterVisitorDetailsPanel;
            searchPanel.Visible = showsearchVisitorDetailsPanel;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label16_Click(object sender, EventArgs e)
        {
            MakePanelVisible(showEnterVisitorDetailsPanel: true);
            enterVisitorPanel.BringToFront();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            MakePanelVisible(showsearchVisitorDetailsPanel: true);
            searchPanel.BringToFront();
        }

        private void ticketInfoDataGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                TicketInfoIdBox.Text = ticketInfoDataGrid.SelectedRows[0].Cells[0].Value.ToString();
                CategoryBox.Text = ticketInfoDataGrid.SelectedRows[0].Cells[1].Value.ToString();
                NoOfIndividualBox.Text = ticketInfoDataGrid.SelectedRows[0].Cells[2].Value.ToString();
                DurationBox.Text = ticketInfoDataGrid.SelectedRows[0].Cells[3].Value.ToString();
                DayBox.Text = ticketInfoDataGrid.SelectedRows[0].Cells[4].Value.ToString();
                TotalPriceBox.Text = ticketInfoDataGrid.SelectedRows[0].Cells[5].Value.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Rows to select", "Invalid Selection");
            }
        }

        private void importTicketDetailsEmpPage_Click(object sender, EventArgs e)
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
                            ticketInfoDataGrid.Rows.Add(ticketDetails.ticketID,
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
    }
}
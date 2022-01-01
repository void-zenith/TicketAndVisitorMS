using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        private readonly string folderPath;
        private readonly string ticketDetailsPathCSV;
        private readonly string visitorDetailsPathCSV;

        private List<TicketDetails> ticketDetailsList;

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
                visitorDuration = DurationBox.Text.Trim(),
                visitorTicketInfoID = TicketInfoIdBox.Text.Trim(),
                visitorTotalPrice = TotalPriceBox.Text.Trim(),
            };
            visitorDetailsList.Add(visitorDetails);
            visitorDataGridView.Rows.Add(visitorDetails.visitorTicketNo, visitorDetails.visitorCheckInTime, visitorDetails.visitorCheckOutTime, visitorDetails.visitorDuration,
                visitorDetails.visitorDay, visitorDetails.visitorTotalPrice,
                visitorDetails.visitorName, visitorDetails.visitorDate,
                visitorDetails.visitorContactNo);
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private void saveToXMLBtn_Click(object sender, EventArgs e)
        {
            if (!(visitorDataGridView.RowCount == 0))
            {
                FileStream fileStream = new FileStream(visitorDetailsURL, FileMode.OpenOrCreate, FileAccess.Write);
                fileStream.Close();

                DataSet dataSet = new DataSet();
                DataTable dataTable = new DataTable();

                dataTable.TableName = "DailyReport";

                foreach (DataGridViewColumn col in visitorDataGridView.Columns)
                {
                    dataTable.Columns.Add(col.Name);
                }
                dataSet.Tables.Add(dataTable);
                foreach (DataGridViewRow row in visitorDataGridView.Rows)
                {
                    DataRow dataRow = dataSet.Tables["DailyReport"].NewRow();
                    foreach (DataGridViewColumn col in visitorDataGridView.Columns)
                    {
                        dataRow[col.Name] = row.Cells[col.Index].Value;
                    }
                    dataSet.Tables["DailyReport"].Rows.Add(dataRow);
                }
                dataSet.WriteXml(@visitorDetailsURL);
                MessageBox.Show("The File has been added Successfully");
            }
            else
            {
                MessageBox.Show("No data to export", "Export Failed");
            }
        }

        private void loadFromXMLBtn_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@visitorDetailsURL);
            foreach (DataRow item in dataSet.Tables["DailyReport"].Rows)
            {
                int n = visitorDataGridView.Rows.Add();
                Console.WriteLine(item[0]);
                for (int i = 0; i < visitorDataGridView.ColumnCount; i++)
                {
                    visitorDataGridView.Rows[n].Cells[i].Value = item[i];
                }
            }
            MessageBox.Show("The data has been imported successfully", "Successful Import");
        }

        private void exportToCSVBtn_Click(object sender, EventArgs e)
        {
            string csv = string.Empty;

            //Add the Header row for CSV file.
            foreach (DataGridViewColumn column in visitorDataGridView.Columns)
            {
                csv += column.HeaderText + ',';
            }

            //Add new line.
            csv += "\r\n";

            //Adding the Rows
            foreach (DataGridViewRow row in visitorDataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //Add the Data rows.
                    csv += cell.Value.ToString().Replace(",", ";") + ',';
                }
                //Add new line.
                csv += "\r\n";
            }
            //Exporting to CSV.
            string folderPath = "C:/ASP .net/VisitorAndTicketMS/TicketAndVisitorMS/TicketAndVisitorMS/";
            File.WriteAllText(folderPath + "dailyreport.csv", csv);
            MessageBox.Show("The data has been exported successfully", "Successful Export");
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
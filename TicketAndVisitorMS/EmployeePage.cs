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
         bool isRowSelected = false;

        //initializing serializer
        XmlSerializer visitorSerializer;
        //initializing list
        List<TicketVisitorDetails> visitorDetails;
        public EmployeePage()
        {
            InitializeComponent();
            visitorDetails = new List<TicketVisitorDetails>();
            visitorSerializer = new XmlSerializer(typeof(List<TicketVisitorDetails>));
        }

        private void clearTextBox()
        {
            ticketNoBox.Text = "";
            nameBox.Text = "";
            bookingdateBox.Text = "";
            ticketDetailsBox.Text = "";
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(ticketNoBox.Text) &&
                !String.IsNullOrWhiteSpace(nameBox.Text) &&
                !String.IsNullOrWhiteSpace(bookingdateBox.Text) &&
                !String.IsNullOrWhiteSpace(ticketDetailsBox.Text))
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = ticketNoBox.Text.Trim();
                dataGridView1.Rows[n].Cells[1].Value = nameBox.Text.Trim();
                dataGridView1.Rows[n].Cells[2].Value = bookingdateBox.Text.Trim();
                dataGridView1.Rows[n].Cells[3].Value = ticketDetailsBox.Text.Trim();
                clearTextBox();
            }
            else {
                MessageBox.Show("Text Fields are empty", "Invalid input");
            }
          
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (isRowSelected)
                {
                    if (!String.IsNullOrWhiteSpace(ticketNoBox.Text) &&
                      !String.IsNullOrWhiteSpace(nameBox.Text) &&
                      !String.IsNullOrWhiteSpace(bookingdateBox.Text) &&
                      !String.IsNullOrWhiteSpace(ticketDetailsBox.Text))
                    {
                        dataGridView1.Rows[0].Cells[0].Value = ticketNoBox.Text.Trim();
                        dataGridView1.Rows[0].Cells[1].Value = nameBox.Text.Trim();
                        dataGridView1.Rows[0].Cells[2].Value = bookingdateBox.Text.Trim();
                        dataGridView1.Rows[0].Cells[3].Value = ticketDetailsBox.Text.Trim();
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var messageResult = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete!!", MessageBoxButtons.YesNo);

                if (messageResult == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                }
            }
            else {
                MessageBox.Show("No Row Selected", "Invalid edit");
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                isRowSelected = true;
                var selected = dataGridView1.SelectedRows[0];
                ticketNoBox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                nameBox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                bookingdateBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                ticketDetailsBox.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
            catch (ArgumentOutOfRangeException) { 
                MessageBox.Show("No Rows to select","Invalid Selection"); 
            }
        }

        private void saveToXMLBtn_Click(object sender, EventArgs e)
        {
            if (!(dataGridView1.RowCount == 0)) {
                FileStream fileStream = new FileStream("C:/ASP .net/VisitorAndTicketMS/TicketAndVisitorMS/TicketAndVisitorMS/VisitorDetails.xml", FileMode.OpenOrCreate, FileAccess.Write);
                fileStream.Close();

                DataSet dataSet = new DataSet();
                DataTable dataTable = new DataTable();

                dataTable.TableName = "DailyReport";

                foreach (DataGridViewColumn col in dataGridView1.Columns) {
                    dataTable.Columns.Add(col.Name);
                }
                dataSet.Tables.Add(dataTable);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataRow dataRow = dataSet.Tables["DailyReport"].NewRow();
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        dataRow[col.Name] = row.Cells[col.Index].Value;
                    }
                    dataSet.Tables["DailyReport"].Rows.Add(dataRow);
                }
                dataSet.WriteXml(@"C:/ASP .net/VisitorAndTicketMS/TicketAndVisitorMS/TicketAndVisitorMS/VisitorDetails.xml");
                MessageBox.Show("The File has been added Successfully");
            }
            else
            {
                MessageBox.Show("No data to export", "Export Failed");
            }
        }
    }
}

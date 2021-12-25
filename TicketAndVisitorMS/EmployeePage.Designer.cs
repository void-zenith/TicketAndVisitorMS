
namespace TicketAndVisitorMS
{
    partial class EmployeePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.clearBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.bookingdateBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ticketDetailsBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.namelabel = new System.Windows.Forms.Label();
            this.TicketNoBox = new System.Windows.Forms.TextBox();
            this.ticketnolabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TicketNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Namehead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openCSVBtn = new System.Windows.Forms.Button();
            this.exportToCSVBtn = new System.Windows.Forms.Button();
            this.loadFromXMLBtn = new System.Windows.Forms.Button();
            this.saveToXMLBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.clearBtn);
            this.panel1.Controls.Add(this.editBtn);
            this.panel1.Controls.Add(this.addBtn);
            this.panel1.Controls.Add(this.bookingdateBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ticketDetailsBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nameBox);
            this.panel1.Controls.Add(this.namelabel);
            this.panel1.Controls.Add(this.TicketNoBox);
            this.panel1.Controls.Add(this.ticketnolabel);
            this.panel1.Location = new System.Drawing.Point(59, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 250);
            this.panel1.TabIndex = 0;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(716, 185);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(104, 49);
            this.clearBtn.TabIndex = 9;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(564, 185);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(104, 49);
            this.editBtn.TabIndex = 8;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(408, 185);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(104, 49);
            this.addBtn.TabIndex = 7;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // bookingdateBox
            // 
            this.bookingdateBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bookingdateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookingdateBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bookingdateBox.Location = new System.Drawing.Point(564, 24);
            this.bookingdateBox.Name = "bookingdateBox";
            this.bookingdateBox.Size = new System.Drawing.Size(182, 28);
            this.bookingdateBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(394, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "Booking Date:";
            // 
            // ticketDetailsBox
            // 
            this.ticketDetailsBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ticketDetailsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketDetailsBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ticketDetailsBox.Location = new System.Drawing.Point(208, 118);
            this.ticketDetailsBox.Name = "ticketDetailsBox";
            this.ticketDetailsBox.Size = new System.Drawing.Size(497, 28);
            this.ticketDetailsBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ticket Details:";
            // 
            // nameBox
            // 
            this.nameBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nameBox.Location = new System.Drawing.Point(164, 70);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(182, 28);
            this.nameBox.TabIndex = 1;
            // 
            // namelabel
            // 
            this.namelabel.AutoSize = true;
            this.namelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namelabel.Location = new System.Drawing.Point(35, 69);
            this.namelabel.Name = "namelabel";
            this.namelabel.Size = new System.Drawing.Size(84, 29);
            this.namelabel.TabIndex = 2;
            this.namelabel.Text = "Name:";
            // 
            // TicketNoBox
            // 
            this.TicketNoBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TicketNoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TicketNoBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TicketNoBox.Location = new System.Drawing.Point(164, 23);
            this.TicketNoBox.Name = "TicketNoBox";
            this.TicketNoBox.Size = new System.Drawing.Size(182, 28);
            this.TicketNoBox.TabIndex = 0;
            // 
            // ticketnolabel
            // 
            this.ticketnolabel.AutoSize = true;
            this.ticketnolabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketnolabel.Location = new System.Drawing.Point(35, 22);
            this.ticketnolabel.Name = "ticketnolabel";
            this.ticketnolabel.Size = new System.Drawing.Size(123, 29);
            this.ticketnolabel.TabIndex = 0;
            this.ticketnolabel.Text = "Ticket No:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.deleteBtn);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.openCSVBtn);
            this.panel2.Controls.Add(this.exportToCSVBtn);
            this.panel2.Controls.Add(this.loadFromXMLBtn);
            this.panel2.Controls.Add(this.saveToXMLBtn);
            this.panel2.Location = new System.Drawing.Point(59, 347);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1148, 387);
            this.panel2.TabIndex = 1;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(190, 24);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(104, 49);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TicketNo,
            this.Namehead,
            this.BookingDate,
            this.TicketDetails});
            this.dataGridView1.Location = new System.Drawing.Point(40, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1065, 150);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // TicketNo
            // 
            this.TicketNo.HeaderText = "Ticket No";
            this.TicketNo.MinimumWidth = 6;
            this.TicketNo.Name = "TicketNo";
            this.TicketNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TicketNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.TicketNo.Width = 125;
            // 
            // Namehead
            // 
            this.Namehead.HeaderText = "Name";
            this.Namehead.MinimumWidth = 6;
            this.Namehead.Name = "Namehead";
            this.Namehead.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Namehead.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Namehead.Width = 125;
            // 
            // BookingDate
            // 
            this.BookingDate.HeaderText = "Booking Date";
            this.BookingDate.MinimumWidth = 6;
            this.BookingDate.Name = "BookingDate";
            this.BookingDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BookingDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.BookingDate.Width = 125;
            // 
            // TicketDetails
            // 
            this.TicketDetails.HeaderText = "Ticket Details";
            this.TicketDetails.MinimumWidth = 6;
            this.TicketDetails.Name = "TicketDetails";
            this.TicketDetails.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TicketDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.TicketDetails.Width = 125;
            // 
            // openCSVBtn
            // 
            this.openCSVBtn.Location = new System.Drawing.Point(736, 24);
            this.openCSVBtn.Name = "openCSVBtn";
            this.openCSVBtn.Size = new System.Drawing.Size(104, 49);
            this.openCSVBtn.TabIndex = 13;
            this.openCSVBtn.Text = "Open CSV file";
            this.openCSVBtn.UseVisualStyleBackColor = true;
            this.openCSVBtn.Click += new System.EventHandler(this.openCSVBtn_Click);
            // 
            // exportToCSVBtn
            // 
            this.exportToCSVBtn.Location = new System.Drawing.Point(1020, 24);
            this.exportToCSVBtn.Name = "exportToCSVBtn";
            this.exportToCSVBtn.Size = new System.Drawing.Size(104, 49);
            this.exportToCSVBtn.TabIndex = 12;
            this.exportToCSVBtn.Text = "Export to CSV";
            this.exportToCSVBtn.UseVisualStyleBackColor = true;
            this.exportToCSVBtn.Click += new System.EventHandler(this.exportToCSVBtn_Click);
            // 
            // loadFromXMLBtn
            // 
            this.loadFromXMLBtn.Location = new System.Drawing.Point(36, 24);
            this.loadFromXMLBtn.Name = "loadFromXMLBtn";
            this.loadFromXMLBtn.Size = new System.Drawing.Size(130, 49);
            this.loadFromXMLBtn.TabIndex = 11;
            this.loadFromXMLBtn.Text = "Load from XML";
            this.loadFromXMLBtn.UseVisualStyleBackColor = true;
            this.loadFromXMLBtn.Click += new System.EventHandler(this.loadFromXMLBtn_Click);
            // 
            // saveToXMLBtn
            // 
            this.saveToXMLBtn.Location = new System.Drawing.Point(875, 24);
            this.saveToXMLBtn.Name = "saveToXMLBtn";
            this.saveToXMLBtn.Size = new System.Drawing.Size(104, 49);
            this.saveToXMLBtn.TabIndex = 10;
            this.saveToXMLBtn.Text = "Save to XML";
            this.saveToXMLBtn.UseVisualStyleBackColor = true;
            this.saveToXMLBtn.Click += new System.EventHandler(this.saveToXMLBtn_Click);
            // 
            // EmployeePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 784);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "EmployeePage";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ticketnolabel;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox bookingdateBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ticketDetailsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label namelabel;
        private System.Windows.Forms.TextBox TicketNoBox;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button openCSVBtn;
        private System.Windows.Forms.Button exportToCSVBtn;
        private System.Windows.Forms.Button loadFromXMLBtn;
        private System.Windows.Forms.Button saveToXMLBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Namehead;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketDetails;
    }
}


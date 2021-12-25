
namespace TicketAndVisitorMS
{
    partial class LoginPage
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
            this.leftPanel = new System.Windows.Forms.Panel();
            this.homeImage = new System.Windows.Forms.PictureBox();
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.systemLabel = new System.Windows.Forms.Label();
            this.systemForLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.passwordPanel = new System.Windows.Forms.Panel();
            this.eyeIcon = new System.Windows.Forms.PictureBox();
            this.passwordIcon = new System.Windows.Forms.PictureBox();
            this.userNamePanel = new System.Windows.Forms.Panel();
            this.userIcon = new System.Windows.Forms.PictureBox();
            this.minimizeBtn = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homeImage)).BeginInit();
            this.welcomePanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.passwordPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eyeIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordIcon)).BeginInit();
            this.userNamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.leftPanel.Controls.Add(this.homeImage);
            this.leftPanel.Controls.Add(this.welcomePanel);
            this.leftPanel.Location = new System.Drawing.Point(-16, -13);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(568, 685);
            this.leftPanel.TabIndex = 0;
            // 
            // homeImage
            // 
            this.homeImage.BackgroundImage = global::TicketAndVisitorMS.Properties.Resources.undraw_through_the_park_lxnl;
            this.homeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.homeImage.Location = new System.Drawing.Point(54, 206);
            this.homeImage.Name = "homeImage";
            this.homeImage.Size = new System.Drawing.Size(467, 409);
            this.homeImage.TabIndex = 4;
            this.homeImage.TabStop = false;
            // 
            // welcomePanel
            // 
            this.welcomePanel.Controls.Add(this.systemLabel);
            this.welcomePanel.Controls.Add(this.systemForLabel);
            this.welcomePanel.Controls.Add(this.welcomeLabel);
            this.welcomePanel.Location = new System.Drawing.Point(84, 38);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(410, 162);
            this.welcomePanel.TabIndex = 3;
            this.welcomePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // systemLabel
            // 
            this.systemLabel.AutoSize = true;
            this.systemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemLabel.Location = new System.Drawing.Point(85, 94);
            this.systemLabel.Name = "systemLabel";
            this.systemLabel.Size = new System.Drawing.Size(238, 29);
            this.systemLabel.TabIndex = 2;
            this.systemLabel.Text = "Management System";
            // 
            // systemForLabel
            // 
            this.systemForLabel.AutoSize = true;
            this.systemForLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemForLabel.Location = new System.Drawing.Point(104, 64);
            this.systemForLabel.Name = "systemForLabel";
            this.systemForLabel.Size = new System.Drawing.Size(198, 29);
            this.systemForLabel.TabIndex = 1;
            this.systemForLabel.Text = "Ticket and Visitor";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(129, 31);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(151, 29);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome To";
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(129)))), ((int)(((byte)(134)))));
            this.rightPanel.Controls.Add(this.label1);
            this.rightPanel.Controls.Add(this.button1);
            this.rightPanel.Controls.Add(this.passwordPanel);
            this.rightPanel.Controls.Add(this.userNamePanel);
            this.rightPanel.Controls.Add(this.minimizeBtn);
            this.rightPanel.Controls.Add(this.closeBtn);
            this.rightPanel.Location = new System.Drawing.Point(545, -10);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(601, 685);
            this.rightPanel.TabIndex = 1;
            // 
            // passwordPanel
            // 
            this.passwordPanel.BackColor = System.Drawing.Color.White;
            this.passwordPanel.Controls.Add(this.passwordTextBox);
            this.passwordPanel.Controls.Add(this.eyeIcon);
            this.passwordPanel.Controls.Add(this.passwordIcon);
            this.passwordPanel.Location = new System.Drawing.Point(65, 296);
            this.passwordPanel.Name = "passwordPanel";
            this.passwordPanel.Size = new System.Drawing.Size(453, 55);
            this.passwordPanel.TabIndex = 3;
            // 
            // eyeIcon
            // 
            this.eyeIcon.BackgroundImage = global::TicketAndVisitorMS.Properties.Resources.eye_48px;
            this.eyeIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.eyeIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eyeIcon.Location = new System.Drawing.Point(415, 14);
            this.eyeIcon.Name = "eyeIcon";
            this.eyeIcon.Size = new System.Drawing.Size(27, 26);
            this.eyeIcon.TabIndex = 6;
            this.eyeIcon.TabStop = false;
            // 
            // passwordIcon
            // 
            this.passwordIcon.BackgroundImage = global::TicketAndVisitorMS.Properties.Resources.password_48px;
            this.passwordIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.passwordIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.passwordIcon.Location = new System.Drawing.Point(5, 11);
            this.passwordIcon.Name = "passwordIcon";
            this.passwordIcon.Size = new System.Drawing.Size(31, 36);
            this.passwordIcon.TabIndex = 5;
            this.passwordIcon.TabStop = false;
            // 
            // userNamePanel
            // 
            this.userNamePanel.BackColor = System.Drawing.Color.White;
            this.userNamePanel.Controls.Add(this.userTextBox);
            this.userNamePanel.Controls.Add(this.userIcon);
            this.userNamePanel.Location = new System.Drawing.Point(65, 223);
            this.userNamePanel.Name = "userNamePanel";
            this.userNamePanel.Size = new System.Drawing.Size(453, 55);
            this.userNamePanel.TabIndex = 2;
            // 
            // userIcon
            // 
            this.userIcon.BackgroundImage = global::TicketAndVisitorMS.Properties.Resources.user_48px;
            this.userIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.userIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userIcon.Location = new System.Drawing.Point(5, 5);
            this.userIcon.Name = "userIcon";
            this.userIcon.Size = new System.Drawing.Size(31, 50);
            this.userIcon.TabIndex = 4;
            this.userIcon.TabStop = false;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackgroundImage = global::TicketAndVisitorMS.Properties.Resources.subtract_52px;
            this.minimizeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.minimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeBtn.Location = new System.Drawing.Point(488, 14);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(30, 36);
            this.minimizeBtn.TabIndex = 1;
            this.minimizeBtn.TabStop = false;
            // 
            // closeBtn
            // 
            this.closeBtn.BackgroundImage = global::TicketAndVisitorMS.Properties.Resources.multiply_60px;
            this.closeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Location = new System.Drawing.Point(531, 7);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(33, 48);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.TabStop = false;
            this.closeBtn.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // userTextBox
            // 
            this.userTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.userTextBox.Location = new System.Drawing.Point(59, 20);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(355, 21);
            this.userTextBox.TabIndex = 5;
            this.userTextBox.Text = "Username";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.passwordTextBox.Location = new System.Drawing.Point(51, 19);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(355, 21);
            this.passwordTextBox.TabIndex = 6;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.button1.Location = new System.Drawing.Point(176, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(217, 58);
            this.button1.TabIndex = 4;
            this.button1.Text = "Login ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.label1.Location = new System.Drawing.Point(65, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Login to your account";
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 664);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginPage";
            this.Text = "LoginPage";
            this.leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.homeImage)).EndInit();
            this.welcomePanel.ResumeLayout(false);
            this.welcomePanel.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.passwordPanel.ResumeLayout(false);
            this.passwordPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eyeIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordIcon)).EndInit();
            this.userNamePanel.ResumeLayout(false);
            this.userNamePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel welcomePanel;
        private System.Windows.Forms.Label systemLabel;
        private System.Windows.Forms.Label systemForLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.PictureBox homeImage;
        private System.Windows.Forms.PictureBox closeBtn;
        private System.Windows.Forms.PictureBox minimizeBtn;
        private System.Windows.Forms.Panel passwordPanel;
        private System.Windows.Forms.Panel userNamePanel;
        private System.Windows.Forms.PictureBox userIcon;
        private System.Windows.Forms.PictureBox passwordIcon;
        private System.Windows.Forms.PictureBox eyeIcon;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}
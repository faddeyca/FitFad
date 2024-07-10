namespace FitFad.Desktop
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
            UserNameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            UserNameLabel = new Label();
            LoginPageLabel = new Label();
            PasswordLabel = new Label();
            RememberCheckBox = new CheckBox();
            LoginButton = new Button();
            LoadingPictureBox = new PictureBox();
            ProgressLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)LoadingPictureBox).BeginInit();
            SuspendLayout();
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new Point(179, 101);
            UserNameTextBox.Margin = new Padding(4);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(275, 29);
            UserNameTextBox.TabIndex = 0;
            UserNameTextBox.TextChanged += UserNameTextBox_TextChanged;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(179, 170);
            PasswordTextBox.Margin = new Padding(4);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(275, 29);
            PasswordTextBox.TabIndex = 1;
            PasswordTextBox.TextChanged += PasswordTextBox_TextChanged;
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Location = new Point(47, 104);
            UserNameLabel.Margin = new Padding(4, 0, 4, 0);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(84, 21);
            UserNameLabel.TabIndex = 2;
            UserNameLabel.Text = "Username:";
            // 
            // LoginPageLabel
            // 
            LoginPageLabel.AutoSize = true;
            LoginPageLabel.Location = new Point(179, 40);
            LoginPageLabel.Margin = new Padding(4, 0, 4, 0);
            LoginPageLabel.Name = "LoginPageLabel";
            LoginPageLabel.Size = new Size(177, 21);
            LoginPageLabel.TabIndex = 3;
            LoginPageLabel.Text = "Connect to the database";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(47, 173);
            PasswordLabel.Margin = new Padding(4, 0, 4, 0);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(79, 21);
            PasswordLabel.TabIndex = 4;
            PasswordLabel.Text = "Password:";
            // 
            // RememberCheckBox
            // 
            RememberCheckBox.AutoSize = true;
            RememberCheckBox.Location = new Point(179, 239);
            RememberCheckBox.Margin = new Padding(4);
            RememberCheckBox.Name = "RememberCheckBox";
            RememberCheckBox.Size = new Size(162, 25);
            RememberCheckBox.TabIndex = 5;
            RememberCheckBox.Text = "Remember details?";
            RememberCheckBox.UseVisualStyleBackColor = true;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(358, 234);
            LoginButton.Margin = new Padding(4);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(96, 32);
            LoginButton.TabIndex = 6;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // LoadingPictureBox
            // 
            LoadingPictureBox.Image = Properties.Resources.loading;
            LoadingPictureBox.Location = new Point(12, 283);
            LoadingPictureBox.Name = "LoadingPictureBox";
            LoadingPictureBox.Size = new Size(50, 50);
            LoadingPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            LoadingPictureBox.TabIndex = 7;
            LoadingPictureBox.TabStop = false;
            LoadingPictureBox.Visible = false;
            // 
            // ProgressLabel
            // 
            ProgressLabel.AutoSize = true;
            ProgressLabel.Location = new Point(78, 298);
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new Size(14, 21);
            ProgressLabel.TabIndex = 8;
            ProgressLabel.Text = " ";
            ProgressLabel.Visible = false;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(540, 345);
            Controls.Add(ProgressLabel);
            Controls.Add(LoadingPictureBox);
            Controls.Add(LoginButton);
            Controls.Add(RememberCheckBox);
            Controls.Add(PasswordLabel);
            Controls.Add(LoginPageLabel);
            Controls.Add(UserNameLabel);
            Controls.Add(PasswordTextBox);
            Controls.Add(UserNameTextBox);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "LoginPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginPage";
            ((System.ComponentModel.ISupportInitialize)LoadingPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UserNameTextBox;
        private TextBox PasswordTextBox;
        private Label UserNameLabel;
        private Label LoginPageLabel;
        private Label PasswordLabel;
        private CheckBox RememberCheckBox;
        private Button LoginButton;
        private PictureBox LoadingPictureBox;
        private Label ProgressLabel;
    }
}
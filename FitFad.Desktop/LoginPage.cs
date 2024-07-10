using System.Security;

namespace FitFad.Desktop
{
    public partial class LoginPage : Form
    {
        private static Application.ApplicationContext _context = Application.ApplicationContext.Instance;
        private bool _hasCredentials = false;

        public LoginPage()
        {
            InitializeComponent();
            if (_context.HasCredentials)
            {
                _hasCredentials = true;
                UserNameTextBox.Text = _context.Username;
                PasswordTextBox.Text = new string('*', 8);
                RememberCheckBox.Checked = true;
            }
        }

        private SecureString GetPassword()
        {
            var password = new SecureString();
            foreach (var c in PasswordTextBox.Text)
            {
                password.AppendChar(c);
            }
            password.MakeReadOnly();
            return password;
        }

        private bool isSubscribedToProgressChange = false;

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            if (!isSubscribedToProgressChange)
            {
                _context.NewProgressStage += ProgressStage_Update;
                isSubscribedToProgressChange = true;
            }

            SaveAndDisableControls(this);
            ProgressLabel.Visible = true;
            LoadingPictureBox.Visible = true;

            try
            {
                if (_hasCredentials)
                {
                    await _context.Login(RememberCheckBox.Checked);
                }
                else
                {
                    await _context.Login(UserNameTextBox.Text, GetPassword(), RememberCheckBox.Checked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RestoreControlStates();
                ProgressLabel.Visible = false;
                LoadingPictureBox.Visible = false;
            }
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            _hasCredentials = false;
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_hasCredentials)
            {
                _hasCredentials = false;
                PasswordTextBox.Text = string.Empty;
            }
        }

        Dictionary<Control, bool> controlStates = new Dictionary<Control, bool>();

        private void SaveAndDisableControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Label || control is PictureBox)
                {
                    continue;
                }
                controlStates[control] = control.Enabled;
                control.Enabled = false;
                if (control.HasChildren)
                {
                    SaveAndDisableControls(control);
                }
            }
        }

        private void RestoreControlStates()
        {
            foreach (var entry in controlStates)
            {
                entry.Key.Enabled = entry.Value;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                LoginButton.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ProgressStage_Update(string stage)
        {
            if (ProgressLabel.InvokeRequired)
            {
                ProgressLabel.Invoke(new Action(() => ProgressStage_Update(stage)));
            }
            else
            {
                ProgressLabel.Text = stage;
            }
        }
    }
}

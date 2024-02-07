using OpenFuryKMS.UserControls;
using System.Windows.Forms;

namespace OpenFuryKMS
{
    public partial class MainForm : Form
    {
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            ChildPanel.Controls.Clear();
            ChildPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            HomeButton.PerformClick();
        }

        private void HomeButton_Click(object sender, System.EventArgs e)
        {
            HomeControl home = new HomeControl();
            addUserControl(home);
        }
        private void WindowsButton_Click(object sender, System.EventArgs e)
        {
            WindowsControl windows = new WindowsControl();
            addUserControl(windows);
        }
        private void OfficeButton_Click(object sender, System.EventArgs e)
        {
            OfficeControl office = new OfficeControl();
            addUserControl(office);
        }
        private void SettingsButton_Click(object sender, System.EventArgs e)
        {
            SettingsControl settings = new SettingsControl();
            addUserControl(settings);
        }
    }
}
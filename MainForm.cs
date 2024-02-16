using FontAwesome.Sharp;
using OpenFuryKMS.Properties;
using OpenFuryKMS.Resources;
using OpenFuryKMS.UserControls;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;


namespace OpenFuryKMS
{
    public partial class MainForm : Form
    {
        private Panel leftBorderBtn;
        private IconButton currentBtn;
        private string _currentButton, _lastActive;

        OfficeHandler officeHandler = new OfficeHandler();

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(200, 255, 245);
            public static Color color2 = Color.DodgerBlue;
            public static Color color3 = Color.FromArgb(235, 60, 0);
            public static Color color4 = Color.FromArgb(10, 160, 135);
        }

        public MainForm()
        {
            InitializeComponent();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(4, 40);
            menuPnl.Controls.Add(leftBorderBtn);

            leftPnl.Size = new Size(2, 560);

            windowsBtn.Enabled = WindowsHandler.ProductName.Contains("Windows 10") || WindowsHandler.ProductName.Contains("Windows 11");
            officeBtn.Enabled = officeHandler.DirChecker();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            LoadLanguage();
            homeBtn.PerformClick();
        }

        public void LoadLanguage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
            homeBtn.Text = Language.homeBtn;
            settingsBtn.Text = Language.settingsBtn;
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            childPnl.Controls.Clear();
            childPnl.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void ActiveButton(object senderBtn, Color color, bool isOfficeButton = false)
        {
            if (senderBtn != null)
            {
                ResetButton();
                Control control = isOfficeButton ? officeBtn : (Control)senderBtn;
                if (senderBtn is IconButton)
                {
                    currentBtn = (IconButton)senderBtn;
                    currentBtn.BackColor = Color.FromArgb(40, 40, 40);
                    currentBtn.ForeColor = color;
                    currentBtn.IconColor = color;
                }
                if (isOfficeButton)
                {
                    officeBtn.Image = Properties.Resources.colorIcon;
                    officeBtn.Refresh();
                    officeBtn.BackColor = Color.FromArgb(40, 40, 40);
                    officeBtn.ForeColor = color;
                }
                //LeftBorder
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(2, control.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void ResetButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(30, 30, 30);
                currentBtn.ForeColor = Color.White;
                currentBtn.IconColor = Color.White;
            }

            if (officeBtn != null)
            {
                officeBtn.BackColor = Color.FromArgb(30, 30, 30);
                officeBtn.ForeColor = Color.White;
                officeBtn.Image = Properties.Resources.whiteIcon;
            }
        }

        private void homeBtn_Click(object sender, System.EventArgs e)
        {
            _currentButton = sender.ToString();
            if (_currentButton != _lastActive)
            {
                _lastActive = _currentButton;
                ActiveButton(sender, RGBColors.color1);
                HomeControl home = new HomeControl();
                addUserControl(home);
            }
        }
        private void windowsBtn_Click(object sender, System.EventArgs e)
        {
            _currentButton = sender.ToString();
            if (_currentButton != _lastActive)
            {
                _lastActive = _currentButton;
                ActiveButton(sender, RGBColors.color2);
                WindowsControl windows = new WindowsControl();
                addUserControl(windows);
            }
        }
        private void officeBtn_Click(object sender, System.EventArgs e)
        {
            _currentButton = sender.ToString();
            if (_currentButton != _lastActive)
            {
                _lastActive = _currentButton;
                ActiveButton(sender, RGBColors.color3, true);
                OfficeControl office = new OfficeControl();
                addUserControl(office);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }

        private void settingsBtn_Click(object sender, System.EventArgs e)
        {
            _currentButton = sender.ToString();
            if (_currentButton != _lastActive)
            {
                _lastActive = _currentButton;
                ActiveButton(sender, RGBColors.color4);
                SettingsControl settings = new SettingsControl();
                addUserControl(settings);
            }
        }
    }
}
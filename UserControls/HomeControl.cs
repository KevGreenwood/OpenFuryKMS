using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenFuryKMS.UserControls
{
    public partial class HomeControl : UserControl
    {
        WindowsHandler WinHandler = new WindowsHandler();
        PowershellHandler Pwsh = new PowershellHandler();
        OfficeHandler officeHandler = new OfficeHandler();

        string CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public HomeControl()
        {
            InitializeComponent();
            versionLbl.Text = Resources.Language.versionLbl + "0.1.0-beta.1";

            if (WindowsHandler.ProductName.Contains("Windows 10") || WindowsHandler.ProductName.Contains("Windows 11"))
            {
                WinLbl.Text = $"{Resources.Language.osLbl} {WinHandler.GetMinimalInfo} ✅";
                WinLbl.ForeColor = Color.Green;
            }
            else
            {
                WinLbl.Text = $"{Resources.Language.osLbl} {WinHandler.GetMinimalInfo} ❌";
                WinLbl.ForeColor = Color.Red;
            }
            PwshLbl.Text = "Shell: PowerShell " + Pwsh.ExecuteCommand("$PSVersionTable.PSVersion");

            bool IsInstalled = officeHandler.DirChecker();
            if (IsInstalled == true)
            {
                OfficeLbl.Text = $"Software: {officeHandler.GetProductName()} ✅";
                OfficeLbl.ForeColor = Color.Green;
            }
            else
            {
                OfficeLbl.Text = "Office is not installed ❌";
                OfficeLbl.ForeColor = Color.Red;
            }
            Directory.SetCurrentDirectory(CurrentDirectory);
        }
    }
}

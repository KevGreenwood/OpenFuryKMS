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
            WinLbl.Text = WinHandler.GetMinimalInfo;
            PwshLbl.Text = "Powershell " + Pwsh.ExecuteCommand("$PSVersionTable.PSVersion");

            bool IsInstalled = officeHandler.DirChecker();
            if (IsInstalled == true)
            {
                OfficeLbl.Text = officeHandler.GetProductName();
            }
            else
            {
                OfficeLbl.Text = "Office is not installed";
            }

            Directory.SetCurrentDirectory(CurrentDirectory);
        }
    }
}

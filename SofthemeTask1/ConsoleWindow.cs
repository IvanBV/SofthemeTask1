using System;
using System.Windows.Forms;

namespace SofthemeTask1
{
    /// <summary>
    /// Custom console window
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Core core = new Core(this);
            core.Run();
        }

        public void Print(String str)
        {
            Sysout.Text += String.Format("{0}", str);
        }

        public void PrintLine(String str)
        {
            Sysout.Text += String.Format("{0}\n", str);
        }
    }
}

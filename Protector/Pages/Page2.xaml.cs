using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MinecraftConnection;

namespace Protector.Pages
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public static MinecraftCommands command;

        public Page2()
        {
            InitializeComponent();
        }

        public static bool InitiateRCON(string ip, ushort port, string pwd)
        {
            try 
            {
                command = new MinecraftCommands(ip, port, pwd);
                return true;
            } catch { return false; }
        }

        private string SendCommand(string cmd) 
        {
            return command.SendCommand(cmd);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                cmdBox.Text = "";
                string response = SendCommand(cmdBox.Text);
                consoleBox.Text += $"\n{response}";
            }
        }
    }
}

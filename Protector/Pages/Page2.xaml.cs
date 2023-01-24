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

        public int InitiateRCON(string ip, ushort port, string pwd)
        {
            try 
            {
                command = new MinecraftCommands(ip, port, pwd);
                string response = SendCommand("list");
                if (response == "") 
                {
                    return 0;
                } else
                {
                    consoleBox.Text += $"Connected to server {ip}:{port} RCON successfully!\n";
                    return 1;
                }
            } catch
            {
                return 2; 
            }
        }

        private string SendCommand(string cmd) 
        {
            return command.SendCommand(cmd);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string response = SendCommand(cmdBox.Text);
                consoleBox.Text += $"\n> {cmdBox.Text}\n{response}";
                cmdBox.Text = "";
            }
        }
    }
}

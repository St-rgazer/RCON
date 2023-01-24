using Protector.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Protector
{
    public partial class MainWindow : Window
    {
        string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string espiDir;

        public MainWindow()
        {
            espiDir = $"{appdata}\\espi";
            InitializeComponent();
            if (!Directory.Exists(espiDir))
            {
                Directory.CreateDirectory(espiDir);
            }
        }

        public void ChangeFrame(int page)
        {
            switch (page) 
            {
                case 1:
                    mainFrame.Content = new Page1();
                    return;
                case 2:
                    mainFrame.Content = new Page2();
                    return;

            }

        }
    

        public void XXit(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void Panel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void topEnter(object sender, MouseEventArgs e)
        {
            Label b = sender as Label;
            Color col = (Color)ColorConverter.ConvertFromString("#445F79");
            b.Background = new SolidColorBrush(col);
        }

        private void topLeave(object sender, MouseEventArgs e)
        {
            Label b = sender as Label;
            Color col = (Color)ColorConverter.ConvertFromString("#2C3E50");
            b.Background = new SolidColorBrush(col);
        }
    }
}

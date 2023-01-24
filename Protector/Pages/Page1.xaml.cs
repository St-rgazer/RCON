﻿using Protector.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Protector
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        public Page1()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (ipBox.Text == "" & portBox.Text == "")
            {
                errorLabel.Content = "Please input the server details.";
                return; 
            }
            bool success = Page2.InitiateRCON(ipBox.Text, ushort.Parse(portBox.Text), passwordBox.Password);
            if (success) 
            {
                Page2 page = new Page2();
                NavigationService.Navigate(page);
            } else
            {
                errorLabel.Content =  "There was an error connecting to the RCON";
            }
            
        }

        private void PreviewT(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }
        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
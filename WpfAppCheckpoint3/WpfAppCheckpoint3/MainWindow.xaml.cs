using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace WpfAppCheckpoint3
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DisplayFileButton_Click(object sender, RoutedEventArgs e)
        {
            string Path = FilePathTxtBox.Text;
            var request = (HttpWebRequest)WebRequest.Create($"http://localhost:1234/file/{ Path }");
            request.Method = "GET";
            request.ContentType = "application/xml";
            if (Path != "")
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream newStream = response.GetResponseStream();
                StreamReader transformStream = new StreamReader(newStream, Encoding.UTF8);
                string returnString = transformStream.ReadToEnd();
                FileInfoBox.ItemsSource = returnString;
            }
            else
            {
                MessageBox.Show("This file don't exist!");
            }
        }

        private void DeleteFileButton_Click(object sender, RoutedEventArgs e)
        {
            string Path = FilePathTxtBox.Text;
            var request = (HttpWebRequest)WebRequest.Create($"http://localhost:1234/file/{ Path }");
            request.Method = "DELETE";
            request.ContentType = "application/xml";
            Stream dataStream = request.GetRequestStream();
            dataStream.Close();

            if (Path != "")
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string returnString = response.StatusCode.ToString();
                if (returnString == "OK")
                {
                    FileInfoBox.ItemsSource = "Selected files is deleted!";
                }
            }
            else
            {
                MessageBox.Show("This file don't exist!");
            }
        }

        private void CreateFileButton_Click(object sender, RoutedEventArgs e)
        {
            string Path = FilePathTxtBox.Text;
            var request = (HttpWebRequest)WebRequest.Create($"http://localhost:1234/file/{ Path }");
            request.Method = "PUT";
            request.ContentType = "application/xml";
            Stream dataStream = request.GetRequestStream();
            dataStream.Close();

            if (Path != "")
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string returnString = response.StatusCode.ToString();
                if (returnString == "OK")
                {
                    FileInfoBox.ItemsSource = "New File is created";
                }
            }
            else
            {
                MessageBox.Show("You don't enter a valid file type!");
            }
        }
    }
}

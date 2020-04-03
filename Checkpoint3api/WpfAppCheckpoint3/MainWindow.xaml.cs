using System;
using System.Collections.Generic;
using System.IO;
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
            if (Path != "" && File.Exists(Path))
            {
                FileInfoBox.ItemsSource = File.ReadAllText(Path);
            }
            else
            {
                MessageBox.Show("This file don't exist!");
            }
        }

        private void DeleteFileButton_Click(object sender, RoutedEventArgs e)
        {
            string Path = FilePathTxtBox.Text;
            if (Path != "" && File.Exists(Path))
            {
                FileInfoBox.ItemsSource = File.ReadAllText(Path);
            }
            else
            {
                MessageBox.Show("This file don't exist!");
            }
        }

        private void CreateFileButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

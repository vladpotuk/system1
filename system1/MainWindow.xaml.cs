using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace LaunchApplications
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaunchNotepad_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe");
        }

        private void LaunchCalculator_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void LaunchPaint_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("mspaint.exe");
        }

        private void LaunchCustomApp_Click(object sender, RoutedEventArgs e)
        {
            
            string customAppPath = @"C:\MyCustomApp\MyCustomApp.exe";
            Process.Start(customAppPath);
        }
    }
}

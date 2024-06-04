﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace system1
{

    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private List<Process> processes;

        public MainWindow()
        {
            InitializeComponent();

            
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); 
            timer.Tick += Timer_Tick;

           
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            processes = Process.GetProcesses().ToList();

           
            ProcessListView.ItemsSource = processes;
        }

        private void UpdateIntervalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                int interval = int.Parse(UpdateIntervalTextBox.Text);

                
                if (interval <= 0)
                {
                    MessageBox.Show("Інтервал оновлення має бути додатнім числом.", "Помилка");
                    return;
                }

               
                timer.Interval = TimeSpan.FromSeconds(interval);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неправильний формат інтервалу оновлення.", "Помилка");
            }
        }
    }
}
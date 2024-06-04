using System;
using System.Diagnostics;
using System.Windows;

namespace system1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartProcessButton_Click(object sender, RoutedEventArgs e)
        {
            string firstNumber = FirstNumberTextBox.Text;
            string secondNumber = SecondNumberTextBox.Text;
            string operation = OperationTextBox.Text;

            // Перевірка введених даних
            if (string.IsNullOrWhiteSpace(firstNumber) || string.IsNullOrWhiteSpace(secondNumber) || string.IsNullOrWhiteSpace(operation))
            {
                ResultTextBlock.Text = "Please enter valid inputs.";
                return;
            }

            // Запуск дочірнього процесу
            Process process = new Process();
            process.StartInfo.FileName = "ChildProcess.exe"; // Замініть на шлях до вашого дочірнього процесу
            process.StartInfo.Arguments = $"{firstNumber} {secondNumber} {operation}";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();

            // Отримання результату з дочірнього процесу
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // Відображення результату
            ResultTextBlock.Text = result;
        }
    }
}

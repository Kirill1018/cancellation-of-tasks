using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
namespace Cancellation_of_tasks
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (float i = 0; i < 100.00; i++)
            {
                Task task1 = new Task(() => bar1.Value = i), task2 = new Task(() => bar2.Value = i), task3 = new Task(() => bar3.Value = i), task4 = new Task(() => bar4.Value = i), task5 = new Task(Message);
                task1.Start();
                task2.Start();
                task3.Start();
                task4.Start();
                Task.WhenAll(task1, task2, task3, task4).Wait();
                task5.Start();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e) { new CancellationTokenSource().Cancel(); }
        public static void Message() { MessageBox.Show("копирование завершено"); }
    }
}
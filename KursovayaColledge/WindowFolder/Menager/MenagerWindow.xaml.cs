using KursovayaColledge.ClassFolder;
using KursovayaColledge.PageFolder.ClientFolder;
using KursovayaColledge.PageFolder.ZakazFolder;
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
using System.Windows.Shapes;

namespace KursovayaColledge.WindowFolder.Menager
{
    /// <summary>
    /// Логика взаимодействия для MenagerWindow.xaml
    /// </summary>
    public partial class MenagerWindow : Window
    {
        public MenagerWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ZakazListPage());
        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ZakazAddPage());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void ListBookBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ZakazListPage());
        }
    }
}

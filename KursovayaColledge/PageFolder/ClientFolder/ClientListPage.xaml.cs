using KursovayaColledge.ClassFolder;
using KursovayaColledge.DataFolder;
using KursovayaColledge.PageFolder.AdminFolder;
using KursovayaColledge.ClassFolder;
using KursovayaColledge.DataFolder;
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

namespace KursovayaColledge.PageFolder.ClientFolder
{
    /// <summary>
    /// Логика взаимодействия для ClientListPage.xaml
    /// </summary>
    public partial class ClientListPage : Page
    {
        public ClientListPage()
        {
            InitializeComponent();
            DgUser.ItemsSource = DBEntities.GetContext().Client
                .ToList().OrderBy(u => u.ClientName);
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = DBEntities.GetContext()
                .Client.Where(u => u.ClientName
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.ClientName);
            if (DgUser.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        

        

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "клиента для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new ClientEditPage(DgUser.SelectedItem as Client));
            }
        }

        private void ExportToExcelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

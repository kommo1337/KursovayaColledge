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
    /// Логика взаимодействия для ClientEditPage.xaml
    /// </summary>
    public partial class ClientEditPage : Page
    {
        Client client = new Client();
        public ClientEditPage(Client client)
        {
            InitializeComponent();
            DataContext = client;

            this.client.ClientId = client.ClientId;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client = DBEntities.GetContext().Client
                    .FirstOrDefault(u => u.ClientId == client.ClientId);
                client.ClientName = NameTb.Text;
                client.ClientSecondName = SecondNameTb.Text;
                client.ClientLastName = LastNameTb.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ClientListPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}

using KursovayaColledge.ClassFolder;
using KursovayaColledge.DataFolder;
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
    /// Логика взаимодействия для ClientAddPage.xaml
    /// </summary>
    public partial class ClientAddPage : Page
    {
        public ClientAddPage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                DBEntities.GetContext().Client.Add(new Client()
                {
                    ClientName = NameTb.Text,
                    ClientSecondName = SecondNameTb.Text,
                    ClientLastName = LastNameTb.Text
                });
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Клиент успешно добавлен");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }
        }
    }
}

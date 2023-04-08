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

namespace KursovayaColledge.PageFolder.ZakazFolder
{
    /// <summary>
    /// Логика взаимодействия для ZakazAddPage.xaml
    /// </summary>
    public partial class ZakazAddPage : Page
    {
        public ZakazAddPage()
        {
            InitializeComponent();
            EmployeeCb.ItemsSource = DBEntities.GetContext().Employee.ToList();
            UserCb.ItemsSource = DBEntities.GetContext().User.ToList();
            ItemCb.ItemsSource = DBEntities.GetContext().Zakaz.ToList();
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = EmployeeCb.SelectedIndex + 1;
                int index2 = UserCb.SelectedIndex + 1;
                int index3 = ItemCb.SelectedIndex + 1;
                DBEntities.GetContext().Zakaz.Add(new Zakaz()
                {
                    ZakazDate = DateTime.Parse(DateTb.Text),
                    EmployeeId = index,
                    UserId = index2,
                    ItemId = index3,
                    Description = DescriptionTb.Text
                });
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Заказ успешно добавлен");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ZakazListPage());
        }
    }
}

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
    /// Логика взаимодействия для ZakazEditPage.xaml
    /// </summary>
    public partial class ZakazEditPage : Page
    {
        Zakaz zakaz = new Zakaz();
        public ZakazEditPage(Zakaz zakaz)
        {
            InitializeComponent();
            DataContext = zakaz;
            this.zakaz.ZakazId = zakaz.ZakazId;
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
                zakaz = DBEntities.GetContext().Zakaz
                    .FirstOrDefault(u => u.ZakazId == zakaz.ZakazId);
                zakaz.ZakazDate = DateTime.Parse(DateTb.Text);
                zakaz.EmployeeId = index;
                zakaz.UserId = index2;
                zakaz.ItemId = index3;
                zakaz.Description = DescriptionTb.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Данные успешно отредактированы");
                NavigationService.Navigate(new ZakazListPage());
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

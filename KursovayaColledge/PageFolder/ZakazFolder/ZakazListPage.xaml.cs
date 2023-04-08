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
    /// Логика взаимодействия для ZakazListPage.xaml
    /// </summary>
    public partial class ZakazListPage : Page
    {
        public ZakazListPage()
        {
            InitializeComponent();
            DgUser.ItemsSource = DBEntities.GetContext().Zakaz
                .ToList().OrderBy(u => u.ZakazDate);
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "заказ для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new ZakazEditPage(DgUser.SelectedItem as Zakaz));
            }
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Zakaz zakaz = DgUser.SelectedItem as Zakaz;

            if (DgUser.SelectedItems == null)
            {
                MBClass.ErrorMB("Выберите заказ" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"заказ с датой" +
                    $"{zakaz.ZakazDate}?"))
                {
                    DBEntities.GetContext().Zakaz
                        .Remove(DgUser.SelectedItem as Zakaz);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Заказ удален");
                    DgUser.ItemsSource = DBEntities.GetContext()
                        .Zakaz.ToList().OrderBy(u => u.ZakazDate);
                }

            }
        }



        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = DBEntities.GetContext()
                .Zakaz.Where(u => u.ZakazDate.ToString()
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.ZakazDate);
            if (DgUser.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void ExportToExcelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

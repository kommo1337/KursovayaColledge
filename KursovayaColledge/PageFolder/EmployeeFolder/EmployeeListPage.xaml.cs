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

namespace KursovayaColledge.PageFolder.EmployeeFolder
{
    /// <summary>
    /// Логика взаимодействия для EmployeeListPage.xaml
    /// </summary>
    public partial class EmployeeListPage : Page
    {
        public EmployeeListPage()
        {
            InitializeComponent();
            DgUser.ItemsSource = DBEntities.GetContext().Employee
                .ToList().OrderBy(u => u.EmployeeName);
        }

       

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = DgUser.SelectedItem as Employee;

            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите работника" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"работника с именем " +
                    $"{employee.EmployeeName}?"))
                {
                    DBEntities.GetContext().Employee
                        .Remove(DgUser.SelectedItem as Employee);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("работник удален");
                    DgUser.ItemsSource = DBEntities.GetContext()
                        .Employee.ToList().OrderBy(u => u.EmployeeName);
                }

            }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "работника для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EmployeeEditPage(DgUser.SelectedItem as Employee));
            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = DBEntities.GetContext()
                .Employee.Where(u => u.EmployeeName
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.EmployeeName);
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

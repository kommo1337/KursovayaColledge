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
    /// Логика взаимодействия для EmployeeAddPage.xaml
    /// </summary>
    public partial class EmployeeAddPage : Page
    {
        public EmployeeAddPage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().Employee.Add(new Employee()
                {
                    EmployeeName = NameTb.Text,
                    EmployeeSecondName = SecondNameTb.Text,
                    EmployeeLastName = LastNameTb.Text
                });
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Работник успешно добавлен");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
                throw;
            }
        }
    }
}

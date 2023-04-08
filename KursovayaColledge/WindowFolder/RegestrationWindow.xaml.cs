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
using System.Windows.Shapes;

namespace KursovayaColledge.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для RegestrationWindow.xaml
    /// </summary>
    public partial class RegestrationWindow : Window
    {
        public RegestrationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().User.Add(new User()
                {
                    UserName = loginTB.Text,
                    UserPassword = PasswordTB.Text,
                    RoleId = 2
                });
                DBEntities.GetContext().SaveChanges();

                MBClass.InfoMB("Вы успешно зарегистрировались");
                new AutorisationWindow().Show();
                Close();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}

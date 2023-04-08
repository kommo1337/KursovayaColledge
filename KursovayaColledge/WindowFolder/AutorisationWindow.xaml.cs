using KursovayaColledge.ClassFolder;
using KursovayaColledge.DataFolder;
using KursovayaColledge.WindowFolder.AdminFolder;
using KursovayaColledge.WindowFolder.ClientFolder;
using KursovayaColledge.WindowFolder.DirectorFolder;
using KursovayaColledge.WindowFolder.EployerFolder;
using KursovayaColledge.WindowFolder.Menager;

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
    /// Логика взаимодействия для AutorisationWindow.xaml
    /// </summary>
    public partial class AutorisationWindow : Window
    {
        public AutorisationWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new RegestrationWindow().Show();
            Close();
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var user = DBEntities.GetContext()
                    .User.FirstOrDefault(u => u.UserName == LoginTB.Text);

                if (user == null)
                {
                    MBClass.ErrorMB("Введен неверный логин");
                    LoginTB.Focus();
                    return;
                }
                if (user.UserPassword != PaswordTB.Text)
                {
                    MBClass.ErrorMB("Введен неверный пароль");
                    PaswordTB.Focus();
                    return;
                }
                else
                {
                    switch (user.RoleId)
                    {
                        case 1:
                            new AdminWindow().Show();
                            Close();
                            break;
                        case 2:
                            new DirectorWindow().Show();
                            break;
                        case 3:
                            new EmployerWindow().Show();
                            break;
                        case 4:
                            new ClientWindow().Show();
                            break;
                        case 5:
                            new MenagerWindow().Show();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        
    }
    }


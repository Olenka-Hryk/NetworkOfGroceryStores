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

namespace NetworkOfGroceryStores
{
    /// <summary>
    /// Логика взаимодействия для ProfileUserWindow.xaml
    /// </summary>
    public partial class ProfileUserWindow : Window
    {
        public ProfileUserWindow()
        {
            InitializeComponent();
            if (AcountWindow.AdminOrNot)
            {
                Login_textBox.Text = "dbadmin";
                Password_textBox.Text = "12345";
                PIB_textBox.Text = "Урбанська Надія Романівна";
                DateBirth_textBox.Text = "1997-12-19";
                QuantitySale_textBox.Text = "20";
                Salary_textBox.Text = "790";
            }
            if (!AcountWindow.AdminOrNot)
            {
                Login_textBox.Text = "cashier";
                Password_textBox.Text = "02042017";
                PIB_textBox.Text = "Урбанська Надія Романівна";
                DateBirth_textBox.Text = "1997-12-19";
                QuantitySale_textBox.Text = "20";
                Salary_textBox.Text = "790";
            }
        }

        private void ExitProfile_button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

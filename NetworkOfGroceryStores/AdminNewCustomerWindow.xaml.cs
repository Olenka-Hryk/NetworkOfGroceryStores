using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AdminNewCustomerWindow.xaml
    /// </summary>
    public partial class AdminNewCustomerWindow : Window
    {
        SqlConnection conn;

        public AdminNewCustomerWindow()
        {
            InitializeComponent();
        }

        private void AddCustomer_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlCommand query = new SqlCommand("INSERT INTO Customers VALUES('" +Surname.Text+"','"+Name.Text+"', '"+MiddleName.Text+"', '"+DateTime.Parse(DataBirth.Text)+"','"+Phone.Text+"', '"+NumberCard.Text+"', "+Int16.Parse(Discount.Text)+")", conn);
                query.ExecuteNonQuery();
                MessageBox.Show("Клієнта записано в базу даних!", "Додавання: ", MessageBoxButton.OK, MessageBoxImage.Information);
                Surname.Text = "";
                Name.Text = "";
                MiddleName.Text = "";
                DataBirth.Text = "";
                Phone.Text = "";
                NumberCard.Text = "";
                Discount.Text = "";
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AdminNewWorkerWindow.xaml
    /// </summary>
    public partial class AdminNewWorkerWindow : Window
    {
        SqlConnection conn;
        public AdminNewWorkerWindow()
        {
            InitializeComponent();
        }

        private void AddCustomer_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlCommand query = new SqlCommand("INSERT INTO vTimetableWorkers VALUES('" + Surname.Text + "','" + Name.Text + "', '" + MiddleName.Text + "', '" + DateTime.Parse(DataBirth.Text) + "','" + DateTime.Parse(DataWork.Text) + "', '" + Double.Parse(Salary.Text) + "')", conn);
                query.ExecuteNonQuery();
                MessageBox.Show("Працівника записано в базу даних!", "Додавання: ", MessageBoxButton.OK, MessageBoxImage.Information);
                Surname.Text = "";
                Name.Text = "";
                MiddleName.Text = "";
                DataBirth.Text = "";
                DataWork.Text = "";
                Salary.Text = "";
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

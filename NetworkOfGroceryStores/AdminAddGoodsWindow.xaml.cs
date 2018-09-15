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
    /// Логика взаимодействия для AdminAddGroup.xaml
    /// </summary>
    public partial class AdminAddGroup : Window
    {
        SqlConnection conn;
        public AdminAddGroup()
        {
            InitializeComponent();
        }

        private void AddCustomer_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlCommand query = new SqlCommand("INSERT INTO Products VALUES("+(comboBox.SelectedIndex + 1) +", '" + name.Text + "','"+firm.Text+"')", conn);
                query.ExecuteNonQuery();

                SqlCommand query1 = new SqlCommand("INSERT INTO Reserve VALUES("+(comboBox_Copy1.SelectedIndex + 1)+",(SELECT MAX([ID_product]) FROM Products), '90008','"+DateTime.Parse(dateexpiration.Text)+"', "+Int16.Parse(quantity.Text)+", "+float.Parse(price.Text)+",'"+barcode.Text+"',"+Int16.Parse(productSize.Text)+")", conn);
                query1.ExecuteNonQuery();
                MessageBox.Show("Продукт додано до бази даних!", "Додавання: ", MessageBoxButton.OK, MessageBoxImage.Information);
                name.Text = "";
                firm.Text = "";
                quantity.Text = "";
                dateexpiration.Text = "";
                price.Text = "";
                barcode.Text = "";
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
